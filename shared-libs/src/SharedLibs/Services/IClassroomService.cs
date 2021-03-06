﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Services
{
    public interface IClassroomService
    {
        void CreateSchool(Data.School school);
        IEnumerable<Data.School> GetSchools();
        Data.School GetSchool(Guid id);

        void CreateClassroom(Data.Classroom classroom);
        IEnumerable<Data.Classroom> GetClassrooms();
        Data.Classroom GetClassroom(Guid id);

        void AddStudentToClassroom(Data.ClassroomStudent classStudent);
        void RemoveStudentFromClassroom(Data.ClassroomStudent classStudent);
    }
}
