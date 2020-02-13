using IRunesApp.Models;
using IRunesApp.Services.Interfaces;
using IRunesApp.ViewModels.Track;
using System.Linq;

namespace IRunesApp.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTrack(string name, string link, decimal price,string albumId)
        {
            var track = new Track
            {
                Name = name,
                Link=link,
                Price=price,
                AlbumID = albumId

            };

            db.Tracks.Add(track);
            db.SaveChanges();

        }

        public TrackInfoViewModel GetTrack(string trackId)
        {
            return db.Tracks.Where(t => t.Id == trackId)
                .Select(t => new TrackInfoViewModel
                {
                      Name = t.Name,
                      Price= t.Price,
                      Link= t.Link
                }).FirstOrDefault();
        }
    }
}
