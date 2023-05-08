using KnowledgeTestAPI.Domain.Entities;
using KnowledgeTestAPI.Infraestructure.Entitites;

namespace KnowledgeTestAPI.Infraestructure.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<DataEmployee>> GetAll();
        Task<DataEmployee> GetById(int id);
    }
}
