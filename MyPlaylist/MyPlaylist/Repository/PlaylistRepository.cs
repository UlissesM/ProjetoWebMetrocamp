using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlaylist.Data;
using MyPlaylist.Models;

namespace MyPlaylist.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly Data.ApplicationDbContext _dbContext;
        public PlaylistRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Playlist playlist)
        {
            _dbContext.Add(playlist);
        }

        public IQueryable<Playlist> GetAll()
        {
            var playlist = _dbContext.Playlists;
            return playlist;
        }

        public Playlist GetById(long id)
        {
            return _dbContext.Playlists.Find(id);
        }

        public void Remove(Playlist playlist)
        {
            _dbContext.Remove(playlist);
        }
    }
}
