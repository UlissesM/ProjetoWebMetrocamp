using MyPlaylist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Data.ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
