namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Globalization;
    using MusicHub.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersToImport = JsonConvert.DeserializeObject<Writer[]>(jsonString);

            var sb = new StringBuilder();

            var validWritersToImport = new List<Writer>();

            foreach (var writerDto in writersToImport)
            {
                var isValid = IsValid(writerDto);

                if (!isValid)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                validWritersToImport.Add(writerDto);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writerDto.Name));


            }



            context.Writers.AddRange(validWritersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();



        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDtos = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var sb = new StringBuilder();

            var producersToImport = new List<Producer>();




            foreach (var producerDto in producersDtos)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }



                var producer = new Producer
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture)
                    });
                }

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                producersToImport.Add(producer);
            }

            context.Producers.AddRange(producersToImport);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]),
                                new XmlRootAttribute("Songs"));

            var songs = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var songsToAdd = new List<Song>();

            foreach (var songDto in songs)
            {
                var genre = Enum.TryParse(songDto.Genre, out Genre genreResult);
                var album = context.Albums.Find(songDto.AlbumId);
                var writer = context.Writers.Find(songDto.WriterId);
                var songTitle = songsToAdd.Any(s => s.Name == songDto.Name);

                if (!IsValid(songDto) || !genre || album == null || writer == null || songTitle)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var songToAdd = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", null),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genreResult,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price

                };

                songsToAdd.Add(songToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, songToAdd.Name, songToAdd.Genre, songToAdd.Duration));
            }

            context.Songs.AddRange(songsToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]),
                                new XmlRootAttribute("Performers"));

            var performers = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var performersToAdd = new List<Performer>();

            foreach (var performerDto in performers)
            {

                var validSongCount = context.Songs.Count(s => performerDto.PerformerSongs.Any(i => i.Id == s.Id));





                if (!IsValid(performerDto) || validSongCount != performerDto.PerformerSongs.Length)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,

                };
                foreach (var songsDto in performerDto.PerformerSongs)
                {

                    performer.PerformerSongs.Add(new SongPerformer
                    { SongId = songsDto.Id });


                }


                performersToAdd.Add(performer);
                sb.AppendLine($"Imported {performer.FirstName} ({performer.PerformerSongs.Count} songs)");
            }

            context.Performers.AddRange(performersToAdd);

            context.SaveChanges();


            return sb.ToString().TrimEnd();


        }

        private static bool IsValid(object obj)
        {
            var validationContex = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContex, validationResult, true);

        }

    }
}