using MyPlaylist.Models.ManageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Services
{
    public interface ITrackService 
    {
        void Add(TrackModelView playlist);
        IEnumerable<TrackModelView> GetAll();
        IEnumerable<TrackModelView> GetTracks(long id);
        void Update(long playlistId, TrackModelView trackModel);
        void Remove(long id);
        TrackModelView GetById(long id);
    }
}
