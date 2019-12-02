using BL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {

        [HttpGet]
        public EmployeeDTO getEmployeeById(int id)
        {
            IList<EmployeeDTO> listEmployees = new List<EmployeeDTO>();
            EmployeeBL employeeBL = new EmployeeBL();

            listEmployees = employeeBL.getListEmployee(id);
            return listEmployees.FirstOrDefault();
        }

        [HttpGet]
        public IList<EmployeeDTO> getListEmployees()
        {
            IList<EmployeeDTO> listEmployees = new List<EmployeeDTO>();
            EmployeeBL employeeBL = new EmployeeBL();

            listEmployees = employeeBL.getListEmployee(0);
            return listEmployees;
        }

    }
}
