using SharedLibs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibs.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        bool Exists(Guid id);
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(Guid id);
    }
}
