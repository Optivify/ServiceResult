namespace Optivify.ServiceResult.Sample.WeatherForcasts
{
    public class WeatherForecastService
    {
        private static string[] Cities = new[] { "London", "Paris", "Amsterdam", "Berlin", "Cape Town", "Stockholm", "Tokyo", "Seoul", "Hanoi", "San Francisco" };

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private WeatherForecast GetWeatherForecast(string city, DateTime dateTime)
        {
            return new WeatherForecast
            {
                City = city,
                DateTime = dateTime,
                TemperatureC = Random.Shared.Next(10, 40),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        public Result<WeatherForecast> GetByCity(string? city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return Result.Invalid(new ValidationError { PropertyName = nameof(city), ErrorMessage = "City cannot be empty." });
            }

            var cityFound = Cities.Count(x => string.Equals(x, city, StringComparison.OrdinalIgnoreCase)) > 0;

            if (!cityFound)
            {
                return Result.NotFound("City not found.");
            }

            var now = DateTime.UtcNow;

            return this.GetWeatherForecast(city, now);
        }
    }
}
