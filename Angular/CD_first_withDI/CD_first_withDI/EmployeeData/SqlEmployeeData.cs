using CD_first_withDI.Data;
using CD_first_withDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD_first_withDI.CustomerData
{
    public class SqlEmployeeData : IEmployeeData
    {
        DataContext dataContext;
        public SqlEmployeeData(DataContext ctx)
        {
            dataContext = ctx;
        }
        public void AddEmployee(Employee cus)
        {
            dataContext.Crew.Add(cus);
            dataContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            dataContext.Remove(dataContext.Crew.FirstOrDefault(x => x.IdEmployee == id));
            dataContext.SaveChanges();
        }

        public Employee EditEmployee(Employee customer)
        {
            Employee cus = dataContext.Crew.FirstOrDefault(x => x.IdEmployee == customer.IdEmployee);
            cus = customer;
            dataContext.SaveChanges();
            return cus;
        }

        public Employee GetEmployee(int id)
        {
            return dataContext.Crew.SingleOrDefault(x => x.IdEmployee == id);
        }

        public List<Employee> GetCrewList()
        {
            return dataContext.Crew.ToList();
        }
    }
}
