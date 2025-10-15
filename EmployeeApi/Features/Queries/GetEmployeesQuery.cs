using EmployeeApi.Models;
using MediatR;
using System.Collections.Generic;

namespace EmployeeApi.Features.Queries
{
    public record GetEmployeesQuery() : IRequest<IEnumerable<Employee>>;
}
