using System.Collections.Generic;

namespace ServerSidePaginationInAngularJsAndWebAPI.Models
{
    public class EmployeeList
    {
        public List<Employee> employees { get; set; }
        public string totalCount { get; set; }
    }
}