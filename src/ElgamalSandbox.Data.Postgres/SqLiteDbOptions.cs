using Microsoft.Extensions.Logging;

namespace ElgamalSandbox.Data.SqLite
{
    /// <summary>
    /// Конфиг проекта
    /// </summary>
    public class SqLiteDbOptions
    {
        /// <summary>
        /// Путь к БД
        /// </summary>
        public string Path { get; set; } = default!;

        /// <summary>
        /// Фабрика логгера для команд SQL
        /// </summary>
        public ILoggerFactory? SqlLoggerFactory { get; set; }
    }
}
