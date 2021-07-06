using MediatR;
using System;

namespace CQRSWebAppExample.Models.Books.Commands.UpdateBookCommands
{
	/// <summary>
	/// Команда редактирования записи книги
	/// </summary>
	public class UpdateBookCommand : IRequest<Guid>
	{
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public Guid Id { get; set; }
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
