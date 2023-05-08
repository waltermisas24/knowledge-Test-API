using KnowledgeTestAPI.Domain.Entities;
using KnowledgeTestAPI.Domain.Interfaces;
using KnowledgeTestAPI.Infraestructure.Interfaces;

namespace KnowledgeTestAPI.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employees> GetAll()
        {
            Employees employee = new Employees();
            var respons = _employeeRepository.GetAll();

            employee.data = CalculateAnualSalary(respons.Result);                       
            employee.status = "Success";
            employee.message = "Successfully! record has been fetched";

            return Task.FromResult(employee);
        }

        public Task<Employee> GetById(int id)
        {
            Employee employee = new Employee();
            var respons = _employeeRepository.GetById(id);

            employee.data = CalculateAnualSalary(respons.Result);

            employee.status = "Success";
            employee.message = "Successfully! record has been fetched";

            return Task.FromResult(employee);
        }

        private DataEmployee CalculateAnualSalary(DataEmployee result)
        {
            result.employee_anual_salary = result.employee_salary * 12;

            return result;
        }

        private List<DataEmployee> CalculateAnualSalary(List<DataEmployee> result)
        {
            foreach (var employee in result)
            {
                employee.employee_anual_salary = employee.employee_salary * 12;
            }

            return result;
        }
    }
}
