﻿using IRunesApp.ViewModels.Track;
using System.Collections.Generic;

namespace IRunesApp.ViewModels.Album
{
    public class AlbumDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<TrackListingViewModel> Tracks { get; set; }
    }
}
