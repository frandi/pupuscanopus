using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Service
{
    public interface IStudentService
    {
        IEnumerable<Data.Student> GetStudents();
        Data.Student GetStudent(Guid id);
        void SaveStudent(Data.Student student);
        void DeleteStudent(Guid id);
    }
}
