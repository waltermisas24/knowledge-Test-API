using KnowledgeTestAPI.Infraestructure.Entitites;

namespace KnowledgeTestAPI.Domain.Entities
{
    public class Employees
    {
        public string status { get; set; }
        public List<DataEmployee> data { get; set; }
        public string message { get; set; }
    }
}
