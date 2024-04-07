using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace EmpwithADO.Models
{
    public class EmployeeDataContext
    {
        SqlConnection _connection;
        SqlCommand _command;

        public EmployeeDataContext()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDBConn"].ConnectionString);
            
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            _command = new SqlCommand("sp_SelectEmps", _connection);
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _connection.Open();
            SqlDataReader _reader = _command.ExecuteReader();
            while(_reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpId = Convert.ToInt32(_reader["EmpId"]);
                employee.EmpName = Convert.ToString(_reader["EmpName"]);
                employee.DepID = Convert.ToString(_reader["DepID"]);
                employee.Salary = Convert.ToString(_reader["Salary"]);
                employee.Email = Convert.ToString(_reader["Email"]);
                employee.City = Convert.ToString(_reader["City"]);
                employees.Add(employee);
            }
            _reader.Close();
            _connection.Close();
            return employees;

        }
        public int InsertEmployee(Employee emp)
        {
            _command = new SqlCommand("sp_InsertEmps", _connection);
            _command.CommandType= System.Data.CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@empId", emp.EmpId);
            _command.Parameters.AddWithValue("@EmpName", emp.EmpName);
            _command.Parameters.AddWithValue("@DeptID", emp.DepID);
            _command.Parameters.AddWithValue("@Salary", emp.Salary);
            _command.Parameters.AddWithValue("@Email", emp.Email);
            _command.Parameters.AddWithValue("@City", emp.City);
            _connection.Open();
            int i= _command.ExecuteNonQuery();
            _connection.Close();
            return i;
        }
        public Employee GetDetails(int id)
        {
            Employee emp = new Employee();
            _command = new SqlCommand("sp_DetailsEmp", _connection);
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@empId", id);
            _connection.Open();
            SqlDataReader _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                
                emp.EmpId = Convert.ToInt32(_reader["EmpId"]);
                emp.EmpName = Convert.ToString(_reader["EmpName"]);
                emp.DepID = Convert.ToString(_reader["DepID"]);
                emp.Salary = Convert.ToString(_reader["Salary"]);
                emp.Email = Convert.ToString(_reader["Email"]);
                emp.City = Convert.ToString(_reader["City"]);
                
            }
            _reader.Close();
            _connection.Close();
            return emp;
        }
        public int DeleteEmp(int id) 
        {
            
            _command = new SqlCommand("sp_DeleteEmp", _connection);
            _command.CommandType= System.Data.CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("EmpId", id );
            _connection.Open();
            int i = _command.ExecuteNonQuery();
            _connection.Close();
            return i;

        } 
        public int EditEmployee(Employee emp)
        {
            
            _command = new SqlCommand("sp_UpdateEmp", _connection);
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@empId", emp.EmpId);
            _command.Parameters.AddWithValue("@EmpName", emp.EmpName);
            _command.Parameters.AddWithValue("@DeptID", emp.DepID);
            _command.Parameters.AddWithValue("@Salary", emp.Salary);
            _command.Parameters.AddWithValue("@Email", emp.Email);
            _command.Parameters.AddWithValue("@City", emp.City);
            _connection.Open();
            int i = _command.ExecuteNonQuery();
            _connection.Close();
            return i;
            
        }
    }
}