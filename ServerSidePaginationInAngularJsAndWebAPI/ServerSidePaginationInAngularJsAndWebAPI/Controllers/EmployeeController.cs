using System.Web.Http;
using ServerSidePaginationInAngularJsAndWebAPI.Models;
using ServerSidePaginationInAngularJsAndWebAPI.DBOperation;

namespace ServerSidePaginationInAngularJsAndWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public EmployeeList GetEmployees(int pageIndex, int pageSize)
        {
            EmployeeInfo empInfo = new EmployeeInfo();
            EmployeeList empList = empInfo.GetEmployees(pageIndex, pageSize);
            return empList;
        }
    }
}
