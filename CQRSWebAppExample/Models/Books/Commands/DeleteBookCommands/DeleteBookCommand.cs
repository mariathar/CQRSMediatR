using MediatR;
using System;

namespace CQRSWebAppExample.Models.Books.Commands.DeleteBookCommands
{
	/// <summary>
	/// Команда удаления записи книги
	/// </summary>
	public class DeleteBookCommand : IRequest<Unit>
	{
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public Guid Id { get; set; }
	}
}
