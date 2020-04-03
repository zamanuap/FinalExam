using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public interface IDataRepository<T>
    {
        IList<T> GetAll();
        T GetSingle(Expression<Func<T, bool>> where);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
      
    }
}
