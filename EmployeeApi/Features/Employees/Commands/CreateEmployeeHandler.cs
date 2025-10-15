using Dapper;
using MediatR;
using EmployeeApi.Data;

namespace EmployeeApi.Features.Employees.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly DapperContext _context;

        public CreateEmployeeHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO Employees (FirstName, LastName, Email)
                        VALUES (@FirstName, @LastName, @Email);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(sql, request);
            return id;
        }
    }
}
