using IRunesApp.ViewModels.Track;

namespace IRunesApp.Services.Interfaces
{
    public interface ITracksService
    {
        public void CreateTrack(string name, string link, decimal price,string albumId);

        public TrackInfoViewModel GetTrack(string trackId);

    }
}
