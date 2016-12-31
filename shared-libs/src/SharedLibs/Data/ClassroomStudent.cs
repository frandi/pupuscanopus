using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Data
{
    public class ClassroomStudent: BaseEntity
    {
        [NotMapped]
        public new Guid Id { get; set; }

        public Guid ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }

        public Guid StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
    }
}
