namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var result = context.Genres
                  .Where(g => genreNames.Contains(g.Name))
                  .Select(genre => new
                  {
                      Id = genre.Id,
                      Genre = genre.Name,
                      Games = genre.Games
                          .Where(g => g.Purchases.Any())
                          .Select(game => new
                          {
                              Id = game.Id,
                              Title = game.Name,
                              Developer = game.Developer.Name,
                              Tags = string.Join(", ", game.GameTags.Select(g => g.Tag.Name)),
                              Players = game.Purchases.Count
                          })
                          .OrderByDescending(game => game.Players)
                          .ThenBy(game => game.Id)
                          .ToArray(),
                      TotalPlayers = genre.Games.Sum(g => g.Purchases.Count)
                  })
                  .OrderByDescending(g => g.TotalPlayers)
                  .ThenBy(g => g.Id)
                  .ToArray();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return json;

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var purchaseType = Enum.Parse<PurchaseType>(storeType);

            var users =
                context
                .Users
                .Select(x => new ExportUserDto
                {
                    Username = x.Username,
                    Purchases = x.Cards
                    .SelectMany(p => p.Purchases)
                    .Where(t=>t.Type == purchaseType)
                    .Select(p => new ExportPurchaseDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Genre = p.Game.Genre.Name,
                            Title = p.Game.Name,
                            Price = p.Game.Price

                        }

                    })
                    .OrderBy(d => d.Date)
                    .ToArray(),

                    TotalSpent = x.Cards.SelectMany(p => p.Purchases)
                    .Where(t=>t.Type == purchaseType)
                    .Sum(p => p.Game.Price)

                })
                .Where(p=>p.Purchases.Any())
                .OrderByDescending(t => t.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var sb = new StringBuilder();


            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]),
                                 new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();


        }
    }
}