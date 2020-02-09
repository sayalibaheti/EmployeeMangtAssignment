using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;
using LinqKit;

namespace BusinessLogicLayer
{
    public class EmployeeBL
    {
        private IEmployeeRepository _EmpRepository;
        private ILocationConfigRepository _LocRepository;

        public EmployeeBL()
        {
            this._EmpRepository = new EmployeeRepository(new DataAccessEntities());
            this._LocRepository = new LocationConfigRepository(new DataAccessEntities());
        }

        public EmployeeBL(IEmployeeRepository empRepository, ILocationConfigRepository locRepository)
        {
            this._EmpRepository = empRepository;
            this._LocRepository = locRepository;
        }

        public List<EmployeeDTO> GetEmployeeList(EmployeeDTO query)
        {
            var data = new List<EmployeeDTO>();
            try
            {
                var predicate = PredicateBuilder.True<Employee>();
                if (!string.IsNullOrEmpty(query.Location))
                {
                    var set = new List<string>(query.Location.Split(','));

                    predicate = predicate.And(q => set.Any(str => str.Contains(q.Location)));
                }
                if (query.Salary != 0)
                {
                    predicate = predicate.And(a => a.salary == query.Salary);
                }
                if (query.Age != 0)
                {
                    int year = DateTime.Now.Year - query.Age;
                    predicate = predicate.And(a => a.Age.Year == year);
                }
                var _data = _EmpRepository.GetEmployees(predicate);
                if (data != null)
                {
                    data = _data.Select(a => new EmployeeDTO
                    {
                        FirstName = a.FirstName,
                        Age = (DateTime.Now.Year - a.Age.Year),
                        EmpID = a.EmpID,
                        LastName = a.LastName,
                        Location = a.Location,
                        MaritalStatus = a.MaritalStatus,
                        Salary = a.salary
                    }).ToList();
                }
            }
            catch
            {
                throw;

            }
            return data;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                _EmpRepository.DeleteEmployee(id);

                _EmpRepository.Save();
            }
            catch
            {

                return false;
            }
            return true;
        }

        public List<LocationDTO> GetLocations()
        {
            List<LocationDTO> list = new List<LocationDTO>();
            try
            {
                var predicate = PredicateBuilder.True<LocationConfig>();
                var result = _LocRepository.GetLocations(predicate.And(a => a.IsActive == true));
                if (result != null)
                {
                    list = result.Select(a => new LocationDTO { Location = a.LocationName, LocationId = a.LocationId }).ToList();
                }
            }
            catch
            {

                throw;
            }
            return list;
        }

    }
}
