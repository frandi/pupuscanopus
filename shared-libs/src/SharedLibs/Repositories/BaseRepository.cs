using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Repositories
{
    public abstract class BaseRepository<TContext> where TContext: DbContext
    {
        protected TContext _db;
        protected IDistributedCache _cache;

        public BaseRepository(TContext db, IDistributedCache cache)
        {
            _db = db;
            _cache = cache;
        }
    }
}
