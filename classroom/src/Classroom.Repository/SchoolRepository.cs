using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;
using SharedLibs.Repositories;
using Classroom.Data;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Classroom.Repository
{
    public class SchoolRepository: BaseRepository<ClassroomDbContext>, ISchoolRepository
    {
        public SchoolRepository(ClassroomDbContext db, IDistributedCache cache)
            : base(db, cache)
        {

        }

        public void Add(model.School item)
        {
            _db.Schools.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item = _db.Schools.Find(id);
            if(item != null)
            {
                _db.Schools.Remove(item);
                _db.SaveChanges();

                _cache.Remove(CacheHelper.GetSingleSchoolKey(id));
            }
        }

        public bool Exists(Guid id)
        {
            var item = GetById(id);

            return item != null;
        }

        public IEnumerable<model.School> GetAll()
        {
            return _db.Schools;
        }

        public model.School GetById(Guid id)
        {
            model.School item = null;

            string cachedItem = _cache.GetString(CacheHelper.GetSingleSchoolKey(id));
            if (!string.IsNullOrEmpty(cachedItem))
            {
                item = JsonConvert.DeserializeObject<model.School>(cachedItem);
            }

            if (item == null)
            {
                item = _db.Schools.Find(id);

                if (item != null)
                {
                    _cache.SetString(CacheHelper.GetSingleSchoolKey(id), JsonConvert.SerializeObject(item));
                }
            }

            return item;
        }

        public void Update(model.School item)
        {
            var dbItem = _db.Schools.Find(item.Id);
            if(dbItem != null)
            {
                dbItem.Name = item.Name;
                dbItem.Address = item.Address;

                _db.Schools.Update(dbItem);
                _db.SaveChanges();

                _cache.Remove(CacheHelper.GetSingleSchoolKey(item.Id));
            }
        }
    }
}
