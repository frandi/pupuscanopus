using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;

namespace Student.API.ViewModels
{
    public class AddStudentVm
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public model.Student ToStudent()
        {
            var student = new model.Student();
            student.Code = Code;
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.DateOfBirth = DateOfBirth;

            return student;
        }
    }
}
