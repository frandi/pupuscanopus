using Classroom.Data;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SharedLibs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using model = SharedLibs.Data;

namespace Classroom.Repository
{
    public class ClassroomStudentRepository: BaseRepository<ClassroomDbContext>, IClassroomStudentRepository
    {
        public ClassroomStudentRepository(ClassroomDbContext db, IDistributedCache cache)
            : base(db, cache)
        {

        }

        public void Add(model.ClassroomStudent item)
        {
            _db.ClassroomStudents.Add(item);
            _db.SaveChanges();
        }
        
        public void Delete(Guid classroomId, Guid studentId)
        {
            var item = _db.ClassroomStudents.Find(classroomId, studentId);
            if(item != null)
            {
                _db.ClassroomStudents.Remove(item);
                _db.SaveChanges();

                _cache.Remove(CacheHelper.GetSingleClassroomStudentKey(classroomId, studentId));
            }
        }

        public void DeleteByClassroom(Guid classroomId)
        {
            var items = _db.ClassroomStudents.Where(cs => cs.ClassroomId == classroomId);
            if(items.Any())
            {
                _db.ClassroomStudents.RemoveRange(items);
                _db.SaveChanges();

                _cache.Remove(CacheHelper.GetListClassroomStudentsKey(classroomId));
            }
        }

        public bool Exists(Guid classroomId, Guid studentId)
        {
            var item = GetById(classroomId, studentId);

            return item != null;
        }
        
        public IEnumerable<model.ClassroomStudent> GetByClassroom(Guid classroomId)
        {
            IEnumerable<model.ClassroomStudent> items = null;

            string cachedItems = _cache.GetString(CacheHelper.GetListClassroomStudentsKey(classroomId));
            if (!string.IsNullOrEmpty(cachedItems))
            {
                items = JsonConvert.DeserializeObject<IEnumerable<model.ClassroomStudent>>(cachedItems);
            }

            if(items == null)
            {
                items = _db.ClassroomStudents.Where(cs => cs.ClassroomId == classroomId);

                if(items.Any())
                {
                    _cache.SetString(CacheHelper.GetListClassroomStudentsKey(classroomId), JsonConvert.SerializeObject(items));
                }
            }

            return items;
        }
        
        public model.ClassroomStudent GetById(Guid classroomId, Guid studentId)
        {
            model.ClassroomStudent item = null;

            string cachedItem = _cache.GetString(CacheHelper.GetSingleClassroomStudentKey(classroomId, studentId));
            if (!string.IsNullOrEmpty(cachedItem))
            {
                item = JsonConvert.DeserializeObject<model.ClassroomStudent>(cachedItem);
            }

            if (item == null)
            {
                item = _db.ClassroomStudents.Find(classroomId, studentId);

                if(item != null)
                {
                    _cache.SetString(CacheHelper.GetSingleClassroomStudentKey(classroomId, studentId), JsonConvert.SerializeObject(item));
                }
            }

            return item;
        }
    }
}
