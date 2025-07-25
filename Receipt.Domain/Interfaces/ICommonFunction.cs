using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface ICommonFunction<T> where T : class
    {
        Task<IEnumerable<T>> GetDataFromDB(Expression<Func<T, bool>> expression = null);
        Task<bool> DeActivate(int id);
    }
}
