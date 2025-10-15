using Dapper;
using EmployeeApi.Data;
using EmployeeApi.Features.Queries;
using EmployeeApi.Models;
using MediatR;

namespace EmployeeApi.Features.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly DapperContext _context;

        public GetEmployeesHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var sql = "SELECT EmployeeID, FirstName, LastName, Email, HireDate FROM Employees";
            using var connection = _context.CreateConnection();
            var employees = await connection.QueryAsync<Employee>(sql);
            return employees;
        }
    }
}
