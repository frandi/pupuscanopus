using Student.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Data;
using model = SharedLibs.Data;
using SharedLibs.Services;

namespace Student.Service
{
    public class StudentService: IStudentService
    {
        private IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public model.Student GetStudent(Guid id)
        {
            return _studentRepo.GetById(id);
        }

        public IEnumerable<model.Student> GetStudents()
        {
            return _studentRepo.GetAll();
        }

        public void DeleteStudent(Guid id)
        {
            _studentRepo.Delete(id);
        }

        public void SaveStudent(model.Student student)
        {
            if (_studentRepo.Exists(student.Id))
                _studentRepo.Update(student);
            else
                _studentRepo.Add(student);
        }
    }
}
