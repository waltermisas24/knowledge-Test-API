using KnowledgeTestAPI.Domain.Entities;

namespace KnowledgeTestAPI.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employees> GetAll();
        Task<Employee> GetById(int id);
    }
}
