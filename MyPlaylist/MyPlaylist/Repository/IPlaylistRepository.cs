using MyPlaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Repository
{
    public interface IPlaylistRepository
    {
        void Add(Playlist playlist);
        IQueryable<Playlist> GetAll();

        Playlist GetById(long id);

        void Remove(Playlist playlist);
    }
}
