using Student.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Data;

namespace Student.Service
{
    public class StudentService: IStudentService
    {
        private IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public Data.Student GetStudent(Guid id)
        {
            return _studentRepo.GetById(id);
        }

        public IEnumerable<Data.Student> GetStudents()
        {
            return _studentRepo.GetAll();
        }

        public void DeleteStudent(Guid id)
        {
            _studentRepo.Delete(id);
        }

        public void SaveStudent(Data.Student student)
        {
            if (_studentRepo.Exists(student.Id))
                _studentRepo.Update(student);
            else
                _studentRepo.Add(student);
        }
    }
}
