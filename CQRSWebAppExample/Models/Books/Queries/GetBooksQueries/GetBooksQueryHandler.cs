using AutoMapper;
using CQRSWebAppExample.Models.Data;
using CQRSWebAppExample.Models.DataModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWebAppExample.Models.Books.Queries.GetBooksQueries
{
	public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDataModel>>
	{
		private readonly BooksContext _context;
		private readonly IMapper _mapper;

		public GetBooksQueryHandler(BooksContext context, IMapper mapper) =>
			(_context, _mapper) = (context, mapper);

		public async Task<List<BookDataModel>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
		{
			var booksQuery = _context.Set<Book>()
				.AsQueryable();
				
			var result = await _mapper.ProjectTo<BookDataModel>(booksQuery)
				.ToListAsync();

			return result;
		}
	}
}
