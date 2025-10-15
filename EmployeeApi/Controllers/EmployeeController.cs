using EmployeeApi.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Features.Employees.Commands;


namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _mediator.Send(new GetEmployeesQuery());
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            if (command == null)
            return BadRequest();

            var employeeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployees), new { id = employeeId }, new { EmployeeID = employeeId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeCommand command)
        {
            if (id != command.EmployeeID) return BadRequest();
             var success = await _mediator.Send(command);
             return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var success = await _mediator.Send(new DeleteEmployeeCommand { EmployeeID = id });
            return success ? NoContent() : NotFound();
        }

    }
}
