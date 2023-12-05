using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.Extensions.Logging;

namespace ElgamalSandbox.Data.Postgres
{
	/// <summary>
	/// Конфиг проекта
	/// </summary>
	public class PostgresDbOptions
	{
		/// <summary>
		/// Строка подключения к БД
		/// </summary>
		public string ConnectionString { get; set; } = default!;

		/// <summary>
		/// Фабрика логгера для команд SQL
		/// </summary>
		public ILoggerFactory? SqlLoggerFactory { get; set; }

		/// <summary>
		/// Включить аудит БД
		/// </summary>
		public bool EnableAudit { get; set; } = true;

		/// <summary>
		/// Параметры сериализатора для аудита
		/// </summary>
		public JsonSerializerOptions AuditSerializerOptions { get; set; } = new JsonSerializerOptions
		{
			Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
			WriteIndented = false,
		};
	}
}
