using model = SharedLibs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibs.Repositories;

namespace Classroom.Repository
{
    public interface IClassroomRepository: IBaseRepository<model.Classroom>
    {
        
    }
}
