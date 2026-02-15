using Bibliotrack.Application.Commands.LoanCommands.AddLoan;
using Bibliotrack.Application.Commands.LoanCommands.DeleteLoan;
using Bibliotrack.Application.Commands.LoanCommands.ReturnLoanBook;
using Bibliotrack.Application.Commands.LoanCommands.UpdateLoan;
using Bibliotrack.Application.Queries.LoanQueries.GetAllLoans;
using Bibliotrack.Application.Queries.LoanQueries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotrack.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {
        public IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string? search, int page, int size)
        {
            var query = new GetAllLoansQuery(search, page, size);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateLoanCommand command)
        {
            command.SetIdLoan(id);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLoanCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}/return")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var result = await _mediator.Send(new ReturnLoanBookCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
