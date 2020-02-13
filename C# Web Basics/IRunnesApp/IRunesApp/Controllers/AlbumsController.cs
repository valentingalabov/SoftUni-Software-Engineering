using IRunesApp.Services.Interfaces;
using IRunesApp.ViewModels.Album;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace IRunesApp.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var albums = albumsService.GetAll();

            var albumsView = new AlbumsListingViewModel
            { Albums = albums };




            return this.View(albumsView, "/All");
        }

        public HttpResponse Create()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();

        }

        [HttpPost]
        public HttpResponse Create(string name, string cover)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (name.Length < 4 || name.Length > 20)
            {
                return this.Error("Album's name must be in range [4-20]");
            }

            albumsService.CreateAlbum(name, cover);

            return All();

        }

        public HttpResponse Details(string id)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var viewModel = this.albumsService.GetALbumDetails(id);

            

            return this.View(viewModel);
        }

    }
}
