using Microsoft.Extensions.Caching.Distributed;
using Student.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Repository
{
    public abstract class BaseRepository: IDisposable
    {
        protected StudentDbContext _db;
        protected IDistributedCache _cache;

        public BaseRepository(StudentDbContext db, IDistributedCache cache)
        {
            _db = db;
            _cache = cache;
        }

        public void Dispose()
        {
            _db.Dispose();
            _cache = null;
        }
    }
}
