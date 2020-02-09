using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

 namespace DAL
{

    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees(Expression<Func<Employee, bool>> predicate);
        void DeleteEmployee(int EmpID);
        void Save();

    }
}
