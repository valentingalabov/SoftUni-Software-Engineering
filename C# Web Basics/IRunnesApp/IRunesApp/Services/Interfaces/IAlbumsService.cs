
using IRunesApp.Models;
using IRunesApp.ViewModels.Album;
using System.Collections.Generic;

namespace IRunesApp.Services.Interfaces
{
    public interface IAlbumsService
    {
        public void CreateAlbum(string name,string cover);

        public IEnumerable<AlbumsViewModel> GetAll();


        public AlbumDetailsViewModel GetALbumDetails(string id);
    }
}
