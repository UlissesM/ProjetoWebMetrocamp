using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlaylist.Models;
using MyPlaylist.Models.ManageViewModels;
using MyPlaylist.Repository;

namespace MyPlaylist.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrackService _trackService;
        public PlaylistService(IPlaylistRepository playlistRepository,IUnitOfWork unitOfWork,ITrackService trackService)
        {
            _playlistRepository = playlistRepository;
            _trackService = trackService;
            _unitOfWork = unitOfWork;
        }
        public void Add(PlaylistModelView playlist,string Userid)
        {
            if (playlist == null)
            {
                throw new NullReferenceException();
            }
            Playlist p = new Playlist() { Title=playlist.Title, UserId=Userid,Description=playlist.Description};
            _playlistRepository.Add(p);
            _unitOfWork.Commit();
        }

        public IEnumerable<PlaylistModelView> GetAll(string userId)
        { 
            
            var list = new List<PlaylistModelView>();
            var playlist= _playlistRepository.GetAll().Where(x=> x.UserId==userId);
            playlist.ToList().ForEach(p =>
            {
                list.Add(GetPlaylistModel(p));
            });

            return list;
        }

        public PlaylistModelView GetById(long id)
        {
            var playlist = _playlistRepository.GetById(id);
            return GetPlaylistModel(playlist);
        }

        public IEnumerable<TrackModelView> GetTracks(long id)
        {
            return _trackService.GetTracks(id);
        }

        public void RemovePlaylist(long id)
        {
            var playlist = _playlistRepository.GetById(id);
            var tracks = _trackService.GetTracks(id);
            foreach (var item in tracks)
            {
                _trackService.Remove(item.Id);
            }
            _playlistRepository.Remove(playlist);
            _unitOfWork.Commit();
        }

        public void Update(long id, PlaylistModelView playlistModel)
        {
            var playlist = _playlistRepository.GetById(id);
            playlist.Title = playlistModel.Title;
            playlist.Description = playlistModel.Description;
            _unitOfWork.Commit();
        }

        private PlaylistModelView GetPlaylistModel(Playlist playlist)
        {
            return new PlaylistModelView
            {
                Title = playlist.Title,
                UserId = playlist.UserId,
                Id = playlist.Id,
                Description = playlist.Description
            };
        }
    }
}
