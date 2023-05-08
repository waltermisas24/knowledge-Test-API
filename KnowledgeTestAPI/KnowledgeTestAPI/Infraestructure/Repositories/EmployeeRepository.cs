using Newtonsoft.Json;
using KnowledgeTestAPI.Domain.Entities;
using KnowledgeTestAPI.Infraestructure.Entitites;
using KnowledgeTestAPI.Infraestructure.Interfaces;
using System.Collections.Generic;

namespace KnowledgeTestAPI.Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<List<DataEmployee>> GetAll()
        {
            List<DataEmployee> employees = new List<DataEmployee>();
            EmployeesEntitie employeeEntitie = new EmployeesEntitie();
            string url = "https://dummy.restapiexample.com/api/v1/employees";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    var resp = response.Content.ReadAsStringAsync().Result;
                    employeeEntitie = JsonConvert.DeserializeObject<EmployeesEntitie>(resp);
                }
            }
            catch (Exception)
            {

                throw;
            }

            employees = MapToEmployees(employeeEntitie);
            return Task.FromResult(employees);
        }

        public Task<DataEmployee> GetById(int id)
        {
            DataEmployee employee = new DataEmployee();
            EmployeeEntitie employeeEntitie = new EmployeeEntitie();
            string url = "https://dummy.restapiexample.com/api/v1/employee/" + id;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    var resp = response.Content.ReadAsStringAsync().Result;
                    employeeEntitie = JsonConvert.DeserializeObject<EmployeeEntitie>(resp);
                }
            }
            catch (Exception)
            {

                throw;
            }
            employee = MapToEmployee(employeeEntitie);
            return Task.FromResult(employee);
            
        }

        private DataEmployee MapToEmployee(EmployeeEntitie? employeeEntitie)
        {
            DataEmployee employee = new DataEmployee();

            employee.Id = employeeEntitie.data.Id;
            employee.employee_name = employeeEntitie.data.employee_name;
            employee.employee_salary = employeeEntitie.data.employee_salary;
            employee.employee_age = employeeEntitie.data.employee_age;
            employee.profile_image = employeeEntitie.data.profile_image;

            return employee;

        }

        private List<DataEmployee> MapToEmployees(EmployeesEntitie? employeeEntitie)
        {
            List<DataEmployee> employees = new List<DataEmployee>();

            foreach (var item in employeeEntitie.data)
            {
                DataEmployee employee = new DataEmployee();

                employee.Id = item.Id;
                employee.employee_name = item.employee_name;
                employee.employee_salary = item.employee_salary;
                employee.employee_age = item.employee_age;
                employee.profile_image = item.profile_image;

                employees.Add(employee);
            }

            return employees;
        }
    }
}
