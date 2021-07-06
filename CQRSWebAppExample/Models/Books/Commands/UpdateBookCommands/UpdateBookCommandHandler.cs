using CQRSWebAppExample.Models.Data;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWebAppExample.Models.Books.Commands.UpdateBookCommands
{
	public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
	{

		private readonly BooksContext _context;

		public UpdateBookCommandHandler(BooksContext context) =>
			_context = context;


		public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
		{
			Book book = _context.Set<Book>().FirstOrDefault(b => b.Id == request.Id);
			if (book == null)
				throw new ArgumentException("Not Found");

			book.AuthorId = request.AuthorId;
			book.Name = request.Name;
			book.PublishDate = request.PublishDate;

			await _context.SaveChangesAsync(cancellationToken);
			return book.Id;
		}
	}
}
