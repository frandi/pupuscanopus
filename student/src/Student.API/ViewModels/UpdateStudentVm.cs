using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.ViewModels
{
    public class UpdateStudentVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Data.Student ToStudent()
        {
            var student = new Data.Student();
            student.Id = Id;
            student.Code = Code;
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.DateOfBirth = DateOfBirth;

            return student;
        }
    }
}
