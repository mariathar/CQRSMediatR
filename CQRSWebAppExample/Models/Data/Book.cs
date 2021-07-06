using System;

namespace CQRSWebAppExample.Models.Data
{
	public class Book
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Идентияикатор автора
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

		/// <summary>
		/// Дата создания записи
		/// </summary>
		public DateTime CreateDate { get; set; }
	}
}
