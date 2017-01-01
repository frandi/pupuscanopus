using Classroom.Repository;
using model = SharedLibs.Data;
using SharedLibs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibs.Exceptions;

namespace Classroom.Service
{
    public class ClassroomService: IClassroomService
    {
        private ISchoolRepository _schoolRepo;
        private IClassroomRepository _classroomRepo;
        private IClassroomStudentRepository _classStudentRepo;
        private IStudentService _studentSvc;

        public ClassroomService(
            ISchoolRepository schoolRepo,
            IClassroomRepository classroomRepo, 
            IClassroomStudentRepository classStudentRepo,
            IStudentService studentSvc)
        {
            _schoolRepo = schoolRepo;
            _classroomRepo = classroomRepo;
            _classStudentRepo = classStudentRepo;
            _studentSvc = studentSvc;
        }

        public void AddStudentToClassroom(model.ClassroomStudent classStudent)
        {
            var classRoomExist = _classroomRepo.Exists(classStudent.ClassroomId);
            if (!classRoomExist)
                throw ClassroomException.NotExist(classStudent.ClassroomId);

            var student = _studentSvc.GetStudent(classStudent.StudentId);
            if (student == null)
                throw StudentException.NotExist(classStudent.StudentId);

            classStudent.StudentCode = student.Code;
            classStudent.StudentFirstName = student.FirstName;
            classStudent.StudentLastName = student.LastName;

            _classStudentRepo.Add(classStudent);
        }

        public void CreateClassroom(model.Classroom classroom)
        {
            _classroomRepo.Add(classroom);
        }

        public void CreateSchool(model.School school)
        {
            _schoolRepo.Add(school);
        }

        public IEnumerable<model.School> GetSchools()
        {
            return _schoolRepo.GetAll();
        }

        public model.School GetSchool(Guid id)
        {
            return _schoolRepo.GetById(id);
        }

        public IEnumerable<model.Classroom> GetClassrooms()
        {
            return _classroomRepo.GetAll();
        }

        public model.Classroom GetClassroom(Guid id)
        {
            return _classroomRepo.GetById(id);
        }

        public void RemoveStudentFromClassroom(model.ClassroomStudent classStudent)
        {
            var classRoomExist = _classroomRepo.Exists(classStudent.ClassroomId);
            if (!classRoomExist)
                throw ClassroomException.NotExist(classStudent.ClassroomId);

            _classStudentRepo.Delete(classStudent.ClassroomId, classStudent.StudentId);
        }
    }
}
