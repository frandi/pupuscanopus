using model = SharedLibs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.API.ViewModels
{
    public class AddSchoolVm
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public model.School ToSchool()
        {
            var school = new model.School();
            school.Name = Name;
            school.Address = Address;

            return school;
        }
    }
}
