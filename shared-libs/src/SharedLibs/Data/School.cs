using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Data
{
    public class School: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
