using Classroom.Data;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Repository
{
    public class ClassroomRepository : BaseRepository<ClassroomDbContext>, IClassroomRepository
    {
        public ClassroomRepository(ClassroomDbContext db, IDistributedCache cache)
            : base(db, cache)
        {
            
        }

        public void Add(model.Classroom item)
        {
            _db.Classrooms.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item = _db.Classrooms.Find(id);
            if(item != null)
            {
                _db.Classrooms.Remove(item);
                _db.SaveChanges();

                _cache.Remove(CacheHelper.GetSingleClassroomKey(id));
            }
        }

        public bool Exists(Guid id)
        {
            var item = GetById(id);

            return item != null;
        }

        public IEnumerable<model.Classroom> GetAll()
        {
            return _db.Classrooms.Include(c => c.School);
        }

        public model.Classroom GetById(Guid id)
        {
            model.Classroom item = null;

            string cachedItem = _cache.GetString(CacheHelper.GetSingleClassroomKey(id));
            if (!string.IsNullOrEmpty(cachedItem))
            {
                item = JsonConvert.DeserializeObject<model.Classroom>(cachedItem);
            }

            if (item == null)
            {
                item = _db.Classrooms
                    .Include(c => c.School)
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

                if(item != null)
                {
                    _cache.SetString(CacheHelper.GetSingleClassroomKey(id), JsonConvert.SerializeObject(item, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                }
            }

            return item;
        }

        public void Update(model.Classroom item)
        {
            var dbItem = _db.Classrooms.Find(item.Id);
            if(dbItem != null)
            {
                dbItem.SchoolId = item.SchoolId;
                dbItem.Name = item.Name;
                dbItem.Description = item.Description;

                _db.Classrooms.Update(dbItem);
                _db.SaveChanges();

                _cache.Remove(CacheHelper.GetSingleClassroomKey(item.Id));
            }
        }
    }
}
