using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController] // ✅ บอกว่าเป็น API Controller
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/employees
        // สร้างพนักงานใหม่ผ่าน API
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // กำหนดค่าที่ server เป็นคนจัดการเอง
            employee.CreatedById = "API";
            employee.CreateOn = DateTime.Now;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            // คืน 201 Created + URL ของ resource ที่สร้าง
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/employees/5
        // แก้ไขข้อมูลพนักงาน
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee updated)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            // อัปเดตเฉพาะฟิลด์ที่อนุญาตให้เปลี่ยน
            employee.EmpNo = updated.EmpNo;
            employee.FirstName = updated.FirstName;
            employee.LastName = updated.LastName;
            employee.PhoneNumber = updated.PhoneNumber;
            employee.EmailAddress = updated.EmailAddress;
            employee.Country = updated.Country;
            employee.DateOfBirth = updated.DateOfBirth;
            employee.Address = updated.Address;
            employee.Department = updated.Department;
            employee.Designation = updated.Designation;

            // กำหนด Modified
            employee.ModifiedById = "API";
            employee.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent(); // 204
        }

        // DELETE: api/employees/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
