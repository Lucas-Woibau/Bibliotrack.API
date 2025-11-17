using Bibliotrack.Application.Commands.LoanCommands.AddLoan;
using Bibliotrack.Application.Commands.LoanCommands.DeleteLoan;
using Bibliotrack.Application.Commands.LoanCommands.ReturnLoanBook;
using Bibliotrack.Application.Commands.LoanCommands.UpdateLoan;
using Bibliotrack.Application.Queries.LoanQueries.GetAllLoans;
using Bibliotrack.Application.Queries.LoanQueries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        public IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllLoansQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLoanCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var result = await _mediator.Send(new ReturnLoanBookCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
