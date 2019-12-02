using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EmployeeBL
    {
        public EmployeeBL()
        {

        }

        public IList<EmployeeDTO> getListEmployee(int IdEmployee)
        {
            IList<EmployeeDTO> listEmployee = new List<EmployeeDTO>();
            EmployeeDAL employeeDAL = new EmployeeDAL();

            listEmployee = employeeDAL.getListEmployee(IdEmployee);

            return listEmployee;
        }


    }
}
