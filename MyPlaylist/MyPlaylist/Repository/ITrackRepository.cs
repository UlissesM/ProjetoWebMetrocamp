using MyPlaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Repository
{
    public interface ITrackRepository
    {
        void Add(Track track);
        IQueryable<Track> GetAll();
        Track GetById(long id);
        void Remove(Track track);
      
    }
}
