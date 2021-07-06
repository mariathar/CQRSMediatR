using CQRSWebAppExample.Models.Data;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWebAppExample.Models.Books.Commands.DeleteBookCommands
{
	public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
	{

		private readonly BooksContext _context;

		public DeleteBookCommandHandler(BooksContext context) =>
			_context = context;


		public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
		{
			Book book = _context.Set<Book>().FirstOrDefault(b => b.Id == request.Id);
			if (book == null)
				throw new ArgumentException("Not Found");

			 _context.Remove(book);
			await _context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}
