using model = SharedLibs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.API.ViewModels
{
    public class AddClassroomVm
    {
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public model.Classroom ToClassroom()
        {
            var classroom = new model.Classroom();
            classroom.SchoolId = SchoolId;
            classroom.Name = Name;
            classroom.Description = Description;

            return classroom;
        }
    }
}
