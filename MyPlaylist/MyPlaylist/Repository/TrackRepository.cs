using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPlaylist.Data;
using MyPlaylist.Models;

namespace MyPlaylist.Repository
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TrackRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Track track)
        {
            _dbContext.Tracks.Add(track);
        }

        public IQueryable<Track> GetAll()
        {
            var tracks=  _dbContext.Tracks;
            return tracks;
        }

       

        public Track GetById(long id)
        {
            return _dbContext.Tracks.Find(id);
        }

        public void Remove(Track track)
        {
            _dbContext.Remove(track);
        }
    }
}
