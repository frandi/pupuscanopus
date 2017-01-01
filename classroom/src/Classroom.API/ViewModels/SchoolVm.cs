using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;

namespace Classroom.API.ViewModels
{
    public class SchoolVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public static SchoolVm FromSchool(model.School item)
        {
            var vm = new SchoolVm();
            vm.Id = item.Id;
            vm.Name = item.Name;
            vm.Address = item.Address;

            return vm;
        }
    }
}
