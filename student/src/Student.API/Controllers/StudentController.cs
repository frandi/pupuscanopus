using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Service;
using Student.API.ViewModels;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentService _studentSvc;

        public StudentController(IStudentService studentSvc)
        {
            _studentSvc = studentSvc;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Data.Student> Get()
        {
            return _studentSvc.GetStudents();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Data.Student Get(Guid id)
        {
            return _studentSvc.GetStudent(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]AddStudentVm value)
        {
            _studentSvc.SaveStudent(value.ToStudent());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateStudentVm value)
        {
            if (id != value.Id)
                BadRequest();

            _studentSvc.SaveStudent(value.ToStudent());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _studentSvc.DeleteStudent(id);
        }
    }
}
