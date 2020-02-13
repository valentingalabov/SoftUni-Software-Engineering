using IRunesApp.Services.Interfaces;
using IRunesApp.ViewModels.Album;
using IRunesApp.ViewModels.Track;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunesApp.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/login");
            }

            var viewModel = new AlbumIdViewModel
            { AlbumId = albumId };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string albumId, string name, string link, decimal price)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/login");
            }
            if (name.Length < 4 || name.Length > 20)
            {
                return Redirect($"/Tracks/Create?albumId={albumId}");
            }

            tracksService.CreateTrack(name, link, price, albumId);

            return Redirect("/Albums/All");

        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/login");
            }

            var track = tracksService.GetTrack(trackId);


            var viewModel = new TrackWithAlbumViewModel
            {
                AlbumId = albumId,
                Track = track
            };

            return View(viewModel);
        }

    }
}
