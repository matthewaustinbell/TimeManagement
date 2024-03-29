﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.Data;

namespace TimeManagement.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider employeeProvider;
        private readonly IEmployeeProcessor employeeProcessor;

        public EmployeeController(IEmployeeProvider employeeProvider, IEmployeeProcessor employeeProcessor)
        {
            this.employeeProvider = employeeProvider;
            this.employeeProcessor = employeeProcessor;
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeProvider.Get();
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            employeeProcessor.Create(employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            employeeProcessor.Update(employee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeProcessor.Delete(id);
        }
    }
}
