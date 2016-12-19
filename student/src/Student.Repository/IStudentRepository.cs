using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Data.Student> GetAll();
        Data.Student GetById(Guid id);
        bool Exists(Guid id);
        void Add(Data.Student item);
        void Update(Data.Student item);
        void Delete(Guid id);
    }
}
