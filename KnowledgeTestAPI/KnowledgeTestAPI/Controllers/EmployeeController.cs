using KnowledgeTestAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestAPI.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("api/[controller]/employees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _employeeService.GetAll();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("api/[controller]/employee/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _employeeService.GetById(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
