using System;
using System.Collections.Generic;
using EmpManagement.Models;
using System.Linq;
using LinqKit;

namespace EmpManagement.BL
{
    public class EmpBL
    {
        EmpMgmtEntities empl = new EmpMgmtEntities();
        public List<EmpModel> GetEmployees(EmpModel query)
        {
            var data = new List<EmpModel>();
            try
            {
                var predicate = PredicateBuilder.True<Emp>();
                if (!string.IsNullOrEmpty(query.Location))
                {
                    predicate = predicate.And(a => a.Location == query.Location);
                }
                if (query.Salary!=0)
                {
                    predicate = predicate.And(a => a.Salary == query.Salary);
                }
                if (query.Age !=null && query.Age != 0)
                {
                    predicate = predicate.And(a => a.Age == query.Age);
                }
                data = empl.Emps.AsExpandable().Where(predicate).Select(w => new EmpModel { Age = w.Age, EmpID = w.EmpID, FirstName = w.FirstName, LastName = w.LastName, MaritalStatus = w.MaritalStatus,Location=w.Location,Salary=w.Salary.Value }).ToList();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
            return data;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var toBeDeleted = empl.Emps.Where(a => a.EmpID == id).FirstOrDefault();
                empl.Emps.Remove(toBeDeleted);
                empl.SaveChanges();

            }
            catch
            {

                return false;
            }
            return true;
        }
    }
}
