using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repository
{
    public class CacheHelper
    {
        private const string SINGLE_CLASSROOM_KEY_PREFIX = "classroom:single:";
        private const string SINGLE_SCHOOL_KEY_PREFIX = "school:single:";
        private const string SINGLE_CLASS_STUDENT_KEY_PREFIX = "classstudent:single:";
        private const string LIST_CLASS_STUDENTS_KEY_PREFIX = "classstudent:list:";

        public static string GetSingleClassroomKey(Guid id)
        {
            return $"{SINGLE_CLASSROOM_KEY_PREFIX}{id}";
        }

        public static string GetSingleSchoolKey(Guid id)
        {
            return $"{SINGLE_SCHOOL_KEY_PREFIX}{id}";
        }

        public static string GetSingleClassroomStudentKey(Guid classroomId, Guid studentId)
        {
            return $"{SINGLE_CLASS_STUDENT_KEY_PREFIX}{classroomId}:{studentId}";
        }

        public static string GetListClassroomStudentsKey(Guid classroomId)
        {
            return $"{LIST_CLASS_STUDENTS_KEY_PREFIX}{classroomId}";
        }
    }
}
