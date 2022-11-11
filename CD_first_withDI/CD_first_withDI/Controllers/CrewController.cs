using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CD_first_withDI.CustomerData;
using CD_first_withDI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CD_first_withDI.Controllers
{
    [ApiController]
    public class CrewController : ControllerBase
    {
        private SqlEmployeeData employeedata;
        public CrewController(SqlEmployeeData data)
        {
            employeedata = data;

        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCrewList()
        {
            return Ok(employeedata.GetCrewList());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employeedata.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with id {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee customer)
        {
            employeedata.AddEmployee(customer);
            
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + 
                HttpContext.Request.Path + '/' + customer.IdEmployee, customer);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var cus = employeedata.GetEmployee(id);
            if(cus != null)
            {
                employeedata.DeleteEmployee(id);
                return Ok();
            }
            return NotFound($"Cannot find the employee with Id: {id}");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(int id, Employee customer)
        {
            var cus = employeedata.GetEmployee(id);
            if (cus != null)
            {
                customer.IdEmployee = cus.IdEmployee;
                var cust = employeedata.EditEmployee(customer);
                return Ok(cust);
            }
            return NotFound($"Cannot find the employee with Id: {id}");
        }
    }
}
