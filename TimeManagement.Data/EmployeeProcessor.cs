using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace TimeManagement.Data
{
    class EmployeeProcessor : IEmployeeProcessor
    {
        private readonly string connectionString; 

        EmployeeProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO Employee (first_name, last_name, address, home_phone, cell_phone) VALUES (@FirstName, @LastName, @Address, @HomePhone, @CellPhone)",
                new { employee.FirstName, employee.LastName, employee.Address, employee.HomePhone, employee.CellPhone });
            }
        }

        

        public void Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
