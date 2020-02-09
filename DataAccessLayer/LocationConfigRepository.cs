using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LinqKit;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class LocationConfigRepository : ILocationConfigRepository, IDisposable
    {
        private readonly DataAccessEntities _context;

        public LocationConfigRepository(DataAccessEntities _context)
        {
            this._context = _context;
        }
        public IQueryable<LocationConfig> GetLocations(Expression<Func<LocationConfig, bool>> predicate)
        {
            IQueryable<LocationConfig> result;
            try
            {

                result = _context.LocationConfigs.AsExpandable().Where(predicate);
            }
            catch
            {
                throw;
            }
            return result;
        }
       
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
