using MyPlaylist.Models.ManageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Services
{
    public interface IPlaylistService
    {
        void Add(PlaylistModelView playlist,string Userid);
        IEnumerable<PlaylistModelView> GetAll(string UserId);

        PlaylistModelView GetById(long id);

        void Update(long id, PlaylistModelView playlistModel);
        IEnumerable<TrackModelView> GetTracks(long id);

        void RemovePlaylist(long id);
    }
}
