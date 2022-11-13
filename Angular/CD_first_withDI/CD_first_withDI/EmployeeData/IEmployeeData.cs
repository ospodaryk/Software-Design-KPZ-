using CD_first_withDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD_first_withDI.CustomerData
{
    public interface IEmployeeData
    {
        List<Employee> GetCrewList();
        Employee GetEmployee(int id);
        void AddEmployee(Employee cus);
        void DeleteEmployee(int id);
        Employee EditEmployee(Employee customer);

    }
}
