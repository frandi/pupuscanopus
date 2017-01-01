using model = SharedLibs.Data;
using SharedLibs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repository
{
    public interface ISchoolRepository: IBaseRepository<model.School>
    {
    }
}
