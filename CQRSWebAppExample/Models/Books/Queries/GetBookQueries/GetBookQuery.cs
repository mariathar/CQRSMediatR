using CQRSWebAppExample.Models.DataModel;
using MediatR;
using System;

namespace CQRSWebAppExample.Models.Books.Queries.GetBookQueries
{
	public class GetBookQuery: IRequest<BookDataModel>
	{
		public Guid Id { get; set; }
	}
}
