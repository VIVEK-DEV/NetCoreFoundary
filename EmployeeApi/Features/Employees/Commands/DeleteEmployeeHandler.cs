using Dapper;
using MediatR;
using EmployeeApi.Data;

namespace EmployeeApi.Features.Employees.Commands
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly DapperContext _context;

        public DeleteEmployeeHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var sql = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, request);
            return rows > 0;
        }
    }
}
