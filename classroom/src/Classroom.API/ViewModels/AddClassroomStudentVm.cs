using model = SharedLibs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.API.ViewModels
{
    public class AddClassroomStudentVm
    {
        public Guid ClassroomId { get; set; }
        public Guid StudentId { get; set; }

        public model.ClassroomStudent ToClassroomStudent()
        {
            var classStudent = new model.ClassroomStudent();
            classStudent.ClassroomId = ClassroomId;
            classStudent.StudentId = StudentId;

            return classStudent;
        }
    }
}
