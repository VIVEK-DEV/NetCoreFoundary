using MediatR;

namespace EmployeeApi.Features.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
