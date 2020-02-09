using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

 namespace DataAccessLayer
{

    public interface ILocationConfigRepository : IDisposable
    {
        IQueryable<LocationConfig> GetLocations(Expression<Func<LocationConfig, bool>> predicate);
       
    }
}
