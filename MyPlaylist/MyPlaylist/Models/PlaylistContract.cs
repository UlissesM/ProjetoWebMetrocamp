using MyPlaylist.Models.ManageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Models
{
    public class PlaylistContract
    {
        public PlaylistModelView Playlist { get; set; }
        public IEnumerable<TrackModelView> Tracks { get; set; }
    }
}
