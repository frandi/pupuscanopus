using SharedLibs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibs.Data;
using System.Net.Http;
using Newtonsoft.Json;
using SharedLibs.Configs;

namespace SharedLibs.MicroServices
{
    public class StudentService : IStudentService
    {
        private MicroServiceConfig _config;

        public StudentService(MicroServiceConfig config)
        {
            _config = config;
        }

        public void DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(Guid id)
        {
            HttpClient client = new HttpClient();
            string url = $"{_config.StudentBaseUrl}/{id}";
            string result = client.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Student>(result);
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void SaveStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
