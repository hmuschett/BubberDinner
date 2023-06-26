using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Service;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}