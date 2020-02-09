using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

 namespace DataAccessLayer
{

    public interface IEmployeeRepository : IDisposable
    {
        IQueryable<Employee> GetEmployees(Expression<Func<Employee, bool>> predicate);
        void DeleteEmployee(int EmpID);
        void Save();

    }
}
