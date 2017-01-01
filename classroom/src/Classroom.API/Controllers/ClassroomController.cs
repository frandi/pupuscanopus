using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedLibs.Services;
using Classroom.API.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Classroom.API.Controllers
{
    [Route("api")]
    public class ClassroomController : Controller
    {
        private IClassroomService _classroomSvc;

        public ClassroomController(IClassroomService classroomSvc)
        {
            _classroomSvc = classroomSvc;
        }
        
        [HttpPost("CreateSchool")]
        public CreatedAtRouteResult CreateSchool([FromBody]AddSchoolVm school)
        {
            var item = school.ToSchool();
            _classroomSvc.CreateSchool(item);

            return CreatedAtRoute("GetSchool", new { id = item.Id }, SchoolVm.FromSchool(item));
        }

        [HttpGet("GetSchools")]
        public IEnumerable<SchoolVm> GetSchools()
        {
            var items = _classroomSvc.GetSchools();

            return items.Select(item => SchoolVm.FromSchool(item));
        }

        [HttpGet("GetSchool/{id}", Name = "GetSchool")]
        public SchoolVm GetSchool(Guid id)
        {
            var item = _classroomSvc.GetSchool(id);

            return SchoolVm.FromSchool(item);
        }

        [HttpPost("CreateClassroom")]
        public CreatedAtRouteResult CreateClassroom([FromBody]AddClassroomVm classroom)
        {
            var item = classroom.ToClassroom();
            _classroomSvc.CreateClassroom(item);

            return CreatedAtRoute("GetClassroom", new { id = item.Id }, ClassroomVm.FromClassroom(item));
        }

        [HttpGet("GetClassrooms")]
        public IEnumerable<ClassroomVm> GetClassrooms()
        {
            var items = _classroomSvc.GetClassrooms();

            return items.Select(item => ClassroomVm.FromClassroom(item));
        }

        [HttpGet("GetClassroom/{id}", Name = "GetClassroom")]
        public ClassroomVm GetClassroom(Guid id)
        {
            var item = _classroomSvc.GetClassroom(id);

            return ClassroomVm.FromClassroom(item);
        }

        [HttpPost("AddStudentToClassroom")]
        public void AddStudentToClassroom([FromBody]AddClassroomStudentVm classStudent)
        {
            _classroomSvc.AddStudentToClassroom(classStudent.ToClassroomStudent());
        }
    }
}
