using CQRSWebAppExample.Models.DataModel;
using MediatR;
using System.Collections.Generic;

namespace CQRSWebAppExample.Models.Books.Queries.GetBooksQueries
{
	public class GetBooksQuery: IRequest<List<BookDataModel>>
	{
	}
}
