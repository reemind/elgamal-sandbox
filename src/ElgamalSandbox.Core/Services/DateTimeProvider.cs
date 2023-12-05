using ElgamalSandbox.Core.Abstractions;

namespace ElgamalSandbox.Core.Services
{
	/// <inheritdoc/>
	public class DateTimeProvider : IDateTimeProvider
	{
		/// <inheritdoc/>
		public DateTime UtcNow => DateTime.UtcNow;
	}
}
