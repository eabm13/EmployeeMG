using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {
        public EmployeeDAL()
        {

        }

        public IList<EmployeeDTO> getListEmployee(int IdEmployee)
        {           
            IList<EmployeeDTO> listEmployees = new List<EmployeeDTO>();
            listEmployees = getFullListEmployees();

            //search the employee with the id entered or the full list
            if (IdEmployee > 0)
            {
                return listEmployees.Where(x => x.id == IdEmployee).ToList();
            }
            else
            {
                return listEmployees;
            }

        }


        public IList<EmployeeDTO> getFullListEmployees()
        {
            IList<EmployeeDTO> listEmployee = new List<EmployeeDTO>();

            string apiUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";

            Uri address = new Uri(apiUrl);

            // Create the web request
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to GET method
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string stringReader = reader.ReadToEnd();

                if (!string.IsNullOrEmpty(stringReader))
                {
                    listEmployee = JsonConvert.DeserializeObject<EmployeeDTO[]>(stringReader);

                    for (int i = 0; i < listEmployee.Count; i++)
                    {
                        //calculate the annual salary
                        if (listEmployee[i].contractTypeName == "HourlySalaryEmployee")
                        {
                            listEmployee[i].annualSalary = 120 * listEmployee[i].hourlySalary * 12;
                        }
                        else
                        {
                            listEmployee[i].annualSalary = listEmployee[i].monthlySalary * 12;
                        }
                    }
                }
            }

            return listEmployee;
        }

    }
}
