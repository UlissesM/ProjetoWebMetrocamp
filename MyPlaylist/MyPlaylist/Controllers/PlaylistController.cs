using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPlaylist.Models;
using MyPlaylist.Models.ManageViewModels;
using MyPlaylist.Services;

namespace MyPlaylist.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IPlaylistService _playlistService;
        private readonly ITrackService _trackService;
        public PlaylistController(IPlaylistService playlistService, UserManager<ApplicationUser> userManager, ITrackService trackService)
        {
            _playlistService = playlistService;
            _trackService = trackService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var playlist= _playlistService.GetAll(userId);
            return View(playlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddUser(PlaylistModelView playlistModel)
        {
            var userId = _userManager.GetUserId(User);
            _playlistService.Add(playlistModel, userId);
             return  RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            var playlistId = _playlistService.GetById(id);

            return View(playlistId);
        }

        public IActionResult EditPlaylist(PlaylistModelView playlistModel)
        {
            _playlistService.Update(playlistModel.Id, playlistModel);

            return RedirectToAction("Index");
        }

        public IActionResult RemovePlaylist(PlaylistModelView playlistModel)
        {
            _playlistService.RemovePlaylist(playlistModel.Id);

            return RedirectToAction("Index");
        }

        public IActionResult TracksPlaylist(long id)
        {

            var playlist = _playlistService.GetById(id);
            var tracks = _playlistService.GetTracks(id);
            if (tracks.Count()>0)
            {
                tracks.ToList().ForEach(x =>
                {
                    x.PlaylistName = playlist.Title;
                    x.PlaylistId = playlist.Id;
                });
                return View(tracks);
            }
            else
            {
                var listOther = new List<TrackModelView>() { new TrackModelView { PlaylistName = playlist.Title,PlaylistId=id } };
                return View(listOther);
            }
       
        }

        public IActionResult CreateTrack(long id)
        {

            return View(new TrackModelView { PlaylistId=id});
        }

        public IActionResult CreateTrackToPlaylist(TrackModelView trackModelView)
        {

            _trackService.Add(trackModelView);
            return RedirectToAction("TracksPlaylist",new { id = trackModelView.PlaylistId});
        }

        public IActionResult EditTrack(long id)
        {
            var trackId = _trackService.GetById(id);

            return View(trackId);
        }

        public IActionResult ChangeTrack(TrackModelView trackModel)
        {
            _trackService.Update(trackModel.Id, trackModel);

            return RedirectToAction("TracksPlaylist", new { id = trackModel.PlaylistId });
        }


        public IActionResult RemoveTrack(long id)
        {
            var track = _trackService.GetById(id);
            _trackService.Remove(track.Id);
            return RedirectToAction("TracksPlaylist", new { id = track.PlaylistId });
        }
        
        public IActionResult GetAllTracks()
        {
            var list = new List<TrackModelView>();
            var userId = _userManager.GetUserId(User);
            var playlists = _playlistService.GetAll(userId);

            playlists.ToList().ForEach(x=> {
                list.AddRange(_trackService.GetTracks(x.Id));
            });
            return View(list);
        }


    }
}