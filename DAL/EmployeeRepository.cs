using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly DBEntities _context;

        public EmployeeRepository(DBEntities _context)
        {
            this._context = _context;
        }
        public IEnumerable<Employee> GetEmployees(Expression<Func<Employee, bool>> predicate)
        {
         
            return _context.Employees.Where(predicate).AsEnumerable();
        }
        public void DeleteEmployee(int EmpID)
        {
            Employee emp = _context.Employees.Find(EmpID);
            _context.Employees.Remove(emp);
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
