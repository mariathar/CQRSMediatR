using CQRSWebAppExample.Models.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWebAppExample.Models.Books.Commands.CreateBooksCommands
{
	public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
	{

		private readonly BooksContext _context;

		public CreateBookCommandHandler(BooksContext context) =>
			_context = context;


		public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			Book book = new Book
			{
				Id = Guid.NewGuid(),
				AuthorId = request.AuthorId,
				Name = request.Name,
				PublishDate = request.PublishDate,
				CreateDate = DateTime.Now
			};

			await _context.AddAsync(book, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			return book.Id;
		}
	}
}
