using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Data
{
    public class StudentDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
