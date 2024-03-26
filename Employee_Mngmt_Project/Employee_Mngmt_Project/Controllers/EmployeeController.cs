using Employee_Mngmt_Project.Data;
using Employee_Mngmt_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Mngmt_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
            
        }

        [HttpPost("add_Employee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employeeModel)
        {
            if(employeeModel == null)
            {
                return BadRequest();
            }
            else
            {
                _db.employee.Add(employeeModel);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee Added Successfully!"
                }); 
            }
        }

        [HttpPut("update_Employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employeeModel)
        {
            if (employeeModel == null)
            {
                return BadRequest();
            }
            var user = _db.employee.AsNoTracking().FirstOrDefault(x => x.Id == employeeModel.Id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee Not Found."
                });
            }
            else
            {
                _db.Entry(employeeModel).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee Updated Successfully."
                });
            }
        }



        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var existingDelete = await _db.employee.FindAsync(Id);
            if (existingDelete != null)
            {
                _db.Remove(existingDelete);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee deleted successfully."
                });

            }
            return NotFound(new
            {
                StatusCode = 404,
                Message = "Employee not found."
            });
        }


        [HttpGet("Get All Employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employees = await _db.employee.ToListAsync();
            return Ok(employees);

        }

        [HttpGet("Get_Employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employeebyid = await _db.employee.FindAsync(id);

            if (employeebyid == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee Not Found."
                });
            }
            else 

            return Ok(employeebyid);
        }


    }
}
