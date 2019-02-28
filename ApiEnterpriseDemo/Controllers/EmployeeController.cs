using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEnterpriseDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEnterpriseDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Enterprise/{EnterpriseId}/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll(int EnterpriseId)
        {
            return context.Employees.Where(x => x.EnterpriseId == EnterpriseId).ToList();
        }

        [HttpGet("{id}", Name = "EmployeeCreate")]
        public IActionResult GetById(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return new CreatedAtRouteResult("EmployeeCreate", new { id = employee.Id }, employee);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Employee employee, int id)
        {
            if (employee.Id != id)
            {
                return BadRequest();
            }

            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = context.Enterprises.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            context.Enterprises.Remove(employee);
            context.SaveChanges();
            return Ok(employee);
        }
    }
}