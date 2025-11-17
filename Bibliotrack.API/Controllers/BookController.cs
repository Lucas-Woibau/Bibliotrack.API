using Bibliotrack.Application.Commands.BookCommands.AddBook;
using Bibliotrack.Application.Commands.BookCommands.DeleteBook;
using Bibliotrack.Application.Commands.BookCommands.UpdateBook;
using Bibliotrack.Application.Queries.Book.GetAllBooks;
using Bibliotrack.Application.Queries.Book.GetBooksById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBooksQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
