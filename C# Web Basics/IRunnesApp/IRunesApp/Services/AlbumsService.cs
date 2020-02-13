using IRunesApp.Models;
using IRunesApp.Services.Interfaces;
using IRunesApp.ViewModels.Album;
using IRunesApp.ViewModels.Track;
using System.Collections.Generic;
using System.Linq;

namespace IRunesApp.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateAlbum(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0m
            };

            db.Albums.Add(album);
            db.SaveChanges();

        }

        public AlbumDetailsViewModel GetALbumDetails(string id)
        {
            var albums = db.Albums.Where(a => a.Id == id)
                .Select(a => new AlbumDetailsViewModel
                {
                    Id = id,
                    Cover= a.Cover,
                    Name = a.Name,
                    Price = a.Tracks.Sum(t => t.Price) * 0.87m,
                    Tracks = a.Tracks.Select(t => new TrackListingViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList()
                }).FirstOrDefault();

            var findAlbum = db.Albums.FirstOrDefault(a => a.Id == id);

            findAlbum.Price = albums.Price;
            db.SaveChanges();

            return albums;
        }

        public IEnumerable<AlbumsViewModel> GetAll()
        {
            var albums = db.Albums
                .Select(a => new AlbumsViewModel
                {
                    Id = a.Id,
                    Name = a.Name

                }).ToList();

            return albums;
        }
    }
}
