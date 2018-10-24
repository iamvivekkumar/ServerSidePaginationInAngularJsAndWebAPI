using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ServerSidePaginationInAngularJsAndWebAPI.Models;


namespace ServerSidePaginationInAngularJsAndWebAPI.DBOperation
{
    public class EmployeeInfo
    {
        public EmployeeList GetEmployees(int pageIndex, int pageSize)
        {
            EmployeeList employeeList = new EmployeeList();
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmployees", connection);
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Employee> listEmp = new List<Employee>();
                    while (dr.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = dr["id"].ToString();
                        emp.Name = dr["name"].ToString();
                        emp.Email = dr["email"].ToString();
                        emp.Address = dr["address"].ToString();
                        listEmp.Add(emp);
                    }

                    dr.NextResult();

                    while (dr.Read())
                    {
                        employeeList.totalCount = dr["totalCount"].ToString();
                    }
                    employeeList.employees = listEmp;
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return employeeList;
        }
    }
}