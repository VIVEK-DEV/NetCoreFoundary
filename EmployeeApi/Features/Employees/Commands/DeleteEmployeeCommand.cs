using MediatR;

namespace EmployeeApi.Features.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeID { get; set; }
    }
}