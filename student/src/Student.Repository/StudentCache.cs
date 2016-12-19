using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Repository
{
    public class StudentCache
    {
        private const string SINGLE_STUDENT_KEY_PREFIX = "student:single:";

        public static string GetSingleStudentKey(Guid id)
        {
            return $"{SINGLE_STUDENT_KEY_PREFIX}{id}";
        }
    }
}
