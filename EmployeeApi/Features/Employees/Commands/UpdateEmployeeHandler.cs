using Dapper;
using MediatR;
using EmployeeApi.Data;

namespace EmployeeApi.Features.Employees.Commands
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly DapperContext _context;

        public UpdateEmployeeHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE Employees
                        SET FirstName = @FirstName,
                            LastName = @LastName,
                            Email = @Email
                        WHERE EmployeeID = @EmployeeID";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, request);
            return rows > 0;
        }
    }
}