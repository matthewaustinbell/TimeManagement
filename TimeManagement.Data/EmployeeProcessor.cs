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
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "DELETE FROM Employee WHERE id=@Id",
                    new {Id = employeeId});
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "UPDATE Employee SET first_name = @FirstName, last_name = @LastName, address=@Adress, home_phone=@HomePhone, cell_phone=@CellPhone WHERE id=@Id",
                    new
                    {
                        employee.Id, employee.FirstName, employee.LastName, employee.Address, employee.HomePhone,
                        employee.CellPhone
                    });
            }
        }
    }
}
