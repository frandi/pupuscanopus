using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;

namespace Classroom.API.ViewModels
{
    public class ClassroomVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SchoolId { get; set; }
        public string SchoolName { get; set; }

        public static ClassroomVm FromClassroom(model.Classroom item)
        {
            var vm = new ClassroomVm();
            vm.Id = item.Id;
            vm.Name = item.Name;
            vm.Description = item.Description;
            vm.SchoolId = item.SchoolId;
            if(item.School != null)
            {
                vm.SchoolName = item.School.Name;
            }
            
            return vm;
        }
    }
}
