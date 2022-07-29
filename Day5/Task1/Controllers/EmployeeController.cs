using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var emplist = await _context.Employees.ToListAsync();
            return Ok(emplist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            var empobj = await _context.Employees.FindAsync(id);

            if (empobj == null)
                return NotFound("No Employee of with this ID exists");
            else
                return Ok(empobj);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            await _context.Employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok("New Employee Data Added Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            await _context.SaveChangesAsync();
            return Ok("Employee Data Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok("Employee data deleted from database successfully.");
        }
    }
}
   
