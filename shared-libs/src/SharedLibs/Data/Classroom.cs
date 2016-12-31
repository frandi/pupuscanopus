using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Data
{
    public class Classroom: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid SchoolId { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<ClassroomStudent> ClassroomStudents { get; set; }
    }
}
