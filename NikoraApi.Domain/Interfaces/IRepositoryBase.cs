using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikoraApi.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class , IIdentity
    {
        Task Add(TEntity model);
        Task Update(TEntity model);
        Task Delete(int Id);
        Task Delete(TEntity model);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int Id);
        Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> predicate);
    }
}
