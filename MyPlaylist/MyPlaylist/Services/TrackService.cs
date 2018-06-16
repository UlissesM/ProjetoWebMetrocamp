using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlaylist.Models;
using MyPlaylist.Models.ManageViewModels;
using MyPlaylist.Repository;

namespace MyPlaylist.Services
{
    public class TrackService : ITrackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrackRepository _track;

        public TrackService(IUnitOfWork unitOfWork, ITrackRepository trackRepository)
        {
            _unitOfWork = unitOfWork;
            _track = trackRepository;

        }
        public void Add(TrackModelView playlist)
        {
            _track.Add(new Track { PlaylistId = playlist.PlaylistId, Title = playlist.Title, Artist = playlist.Artist, UrlTrack = playlist.UrlTrack });
            _unitOfWork.Commit();
        }

        public IEnumerable<TrackModelView> GetAll()
        {
            var list = new List<TrackModelView>();
            var tracks=_track.GetAll();
            tracks.ToList().ForEach(x =>
            {
                list.Add(GetTrackModelView(x));
            });

            return list;
        }

        public TrackModelView GetById(long id)
        {
            var track = _track.GetById(id);
            return GetTrackModelView(track);
        }

        public IEnumerable<TrackModelView> GetTracks(long id)
        {
            var list = new List<TrackModelView>();
            var tracks = _track.GetAll().Where(t => t.PlaylistId == id);
            tracks.ToList().ForEach(t =>
           {
               list.Add(GetTrackModelView(t));
           });

            return list;
        }

        public void Remove(long id)
        {
            var track = _track.GetById(id);
            _track.Remove(track);
            _unitOfWork.Commit();
        }

        public void Update(long tracktId, TrackModelView trackModel)
        {
            var track = _track.GetById(tracktId);
            track.Title = trackModel.Title;
            track.Artist = trackModel.Artist;
            track.UrlTrack = trackModel.UrlTrack;
            _unitOfWork.Commit();
        }

        private TrackModelView GetTrackModelView(Track track)
        {
            return new TrackModelView
            {
                Title = track.Title,
                Artist = track.Artist,
                UrlTrack = track.UrlTrack,
                Id = track.Id,
                PlaylistId=track.PlaylistId
                
            };
        }
    }
}

