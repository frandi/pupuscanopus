using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Data;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SharedLibs.Repositories;
using model = SharedLibs.Data;

namespace Student.Repository
{
    public class StudentRepository: BaseRepository<StudentDbContext>, IStudentRepository
    {
        public StudentRepository(StudentDbContext db, IDistributedCache cache)
            :base(db, cache)
        {

        }

        public void Add(model.Student item)
        {
            _db.Students.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item = _db.Students.Find(id);
            if(item != null)
            {
                _db.Students.Remove(item);
                _db.SaveChanges();

                _cache.Remove(StudentCache.GetSingleStudentKey(id));
            }
        }

        public bool Exists(Guid id)
        {
            var item = GetById(id);

            return item != null;
        }

        public IEnumerable<model.Student> GetAll()
        {
            return _db.Students;
        }

        public model.Student GetById(Guid id)
        {
            model.Student item = null;
            string cachedItem = _cache.GetString(StudentCache.GetSingleStudentKey(id));
            if (!string.IsNullOrEmpty(cachedItem))
            {
                item = JsonConvert.DeserializeObject<model.Student>(cachedItem);
            }

            if(item == null)
            {
                item = _db.Students.Find(id);

                if (item != null)
                {
                    string key = StudentCache.GetSingleStudentKey(item.Id);
                    string value = JsonConvert.SerializeObject(item);
                    _cache.SetString(key, value);
                }
            }
            
            return item;
        }

        public void Update(model.Student item)
        {
            var dbItem = _db.Students.Find(item.Id);
            if(dbItem != null)
            {
                dbItem = item;

                _db.Students.Update(dbItem);
                _db.SaveChanges();

                _cache.Remove(StudentCache.GetSingleStudentKey(item.Id));
            }
        }
    }
}
