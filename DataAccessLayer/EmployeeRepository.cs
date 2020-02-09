using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LinqKit;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly DataAccessEntities _context;

        public EmployeeRepository(DataAccessEntities _context)
        {
            this._context = _context;
        }
        public IQueryable<Employee> GetEmployees(Expression<Func<Employee, bool>> predicate)
        {
            IQueryable<Employee> result;
            try
            {

                result = _context.Employees.AsExpandable().Where(predicate);
            }
            catch
            {
               
                throw;
            }
            return result;
        }
        public void DeleteEmployee(int EmpID)
        {
            try
            {
                Employee emp = _context.Employees.Find(EmpID);
                _context.Employees.Remove(emp);
            }
            catch
            {
                throw;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
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
