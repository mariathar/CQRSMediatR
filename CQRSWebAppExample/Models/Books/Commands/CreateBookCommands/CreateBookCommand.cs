using MediatR;
using System;

namespace CQRSWebAppExample.Models.Books.Commands.CreateBooksCommands
{
	/// <summary>
	/// Команда создания записи книги
	/// </summary>
	public class CreateBookCommand: IRequest<Guid>
	{
		/// <summary>
		/// Идентификатор автора
		/// </summary>
		public Guid AuthorId { get; set; }
		/// <summary>
		/// Название книги
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата публикации
		/// </summary>
		public DateTime PublishDate { get; set; }
	}
}
