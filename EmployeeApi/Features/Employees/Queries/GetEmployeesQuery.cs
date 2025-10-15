using EmployeeApi.Models;
using MediatR;
using System.Collections.Generic;

namespace EmployeeApi.Features.Employees.Queries
{
    public record GetEmployeesQuery() : IRequest<IEnumerable<EmployeeApi.Models.Employee>>;
}
