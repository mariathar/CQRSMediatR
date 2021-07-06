using AutoMapper;
using CQRSWebAppExample.Models.Data;
using CQRSWebAppExample.Models.DataModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWebAppExample.Models.Books.Queries.GetBookQueries
{
	public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDataModel>
	{
		private readonly BooksContext _context;
		private readonly IMapper _mapper;

		public GetBookQueryHandler(BooksContext context, IMapper mapper) =>
			(_context, _mapper) = (context, mapper);

		public async Task<BookDataModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
		{
			Book book = await _context.Set<Book>().FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

			if (book == null)
				throw new ArgumentException("Not found");

			return _mapper.Map<BookDataModel>(book);
		}
	}
}
