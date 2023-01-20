using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using WebApiCoreWithEF.Context;
using WebApiCoreWithEF.Models;

namespace WebApiCoreWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly CompanyContext _companyContext;

        public EmployeeController(CompanyContext companyContext)
        {
           _companyContext = companyContext;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _companyContext.Employees;
        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            _companyContext.Employees.Add(value);
            _companyContext.SaveChanges();
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var employee = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (employee != null)
            {
                _companyContext.Entry<Employee>(employee).CurrentValues.SetValues(value);
                _companyContext.SaveChanges();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (student != null)
            {
                _companyContext.Employees.Remove(student);
                _companyContext.SaveChanges();
            }
        }
    }
}








