using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Exceptions
{
    public class ClassroomException
    {
        public static ClassroomNotExistException NotExist(Guid classroomId)
        {
            return new ClassroomNotExistException(classroomId);
        }
    }

    public class ClassroomNotExistException: Exception
    {
        public ClassroomNotExistException(Guid classRoomId)
            : base($"Classroom {classRoomId} does not exist")
        {

        }
    }
}
