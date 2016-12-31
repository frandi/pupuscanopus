using SharedLibs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;

namespace Student.Repository
{
    public interface IStudentRepository: IBaseRepository<model.Student>
    {
        
    }
}
