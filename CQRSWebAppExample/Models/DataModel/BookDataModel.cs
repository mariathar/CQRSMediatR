﻿using System;

namespace CQRSWebAppExample.Models.DataModel
{
	public class BookDataModel
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
	}
}
