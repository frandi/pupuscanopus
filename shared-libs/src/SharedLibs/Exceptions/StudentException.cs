using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Exceptions
{
    public class StudentException
    {
        public static StudentNotExistException NotExist(Guid studentId)
        {
            return new StudentNotExistException(studentId);
        }
    }

    public class StudentNotExistException: Exception
    {
        public StudentNotExistException(Guid studentId)
            : base($"Student {studentId} does not exist")
        {

        }
    }
}
