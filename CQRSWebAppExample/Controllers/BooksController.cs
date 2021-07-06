using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSWebAppExample.Models.Books.Commands.CreateBooksCommands;
using CQRSWebAppExample.Models.Books.Commands.DeleteBookCommands;
using CQRSWebAppExample.Models.Books.Commands.UpdateBookCommands;
using CQRSWebAppExample.Models.Books.Queries.GetBooksQueries;
using CQRSWebAppExample.Models.DataModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRSWebAppExample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly ILogger<BooksController> _logger;
		private readonly IMediator _mediator;

		public BooksController(ILogger<BooksController> logger,
			IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IEnumerable<BookDataModel>> Get(CancellationToken cancellationToken)
		{
			return await _mediator.Send(new GetBooksQuery(), cancellationToken);
		}

		[HttpPost]
		public async Task<Guid> Post(CreateBookModel model, CancellationToken cancellationToken)
		{
			Guid bookId = await _mediator.Send(new CreateBookCommand()
			{
				AuthorId = model.AuthorId,
				Name = model.Name,
				PublishDate = model.PublishDate
			}, cancellationToken);

			return bookId;
		}

		[HttpPatch]
		[Route("{id}")]
		public async Task<Guid> Patch(Guid id, UpdateBookModel model, CancellationToken cancellationToken)
		{
			Guid bookId = await _mediator.Send(new UpdateBookCommand()
			{
				Id = id,
				AuthorId = model.AuthorId,
				Name = model.Name,
				PublishDate = model.PublishDate
			}, cancellationToken);

			return bookId;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		{
		    await _mediator.Send(new DeleteBookCommand()
			{
				Id = id
			}, cancellationToken);

			return Ok();
		}
	}
}
