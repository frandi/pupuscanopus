using model = SharedLibs.Data;
using SharedLibs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repository
{
    public interface IClassroomStudentRepository
    {
        void Add(model.ClassroomStudent classStudent);
        void Delete(Guid classroomId, Guid studentId);
        void DeleteByClassroom(Guid classroomId);
        bool Exists(Guid classroomId, Guid studentId);
        model.ClassroomStudent GetById(Guid classroomId, Guid studentId);
        IEnumerable<model.ClassroomStudent> GetByClassroom(Guid classroomId);
    }
}
