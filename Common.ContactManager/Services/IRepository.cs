using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ContactManager.Services
{
    public interface IRepository <TId, TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        TId Insert(TEntity newData);
        bool Update(TId id,TEntity newData);
        bool Delete(TId id);
    }
}
