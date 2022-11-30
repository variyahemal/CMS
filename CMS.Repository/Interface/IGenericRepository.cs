using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll(
          Expression<Func<T, bool>> filter = null,

          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disabledTracking = true);
    }
}
