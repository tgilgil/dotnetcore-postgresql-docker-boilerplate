using System;

namespace Boilerplate.API.Database.Configuration
{
    /// <summary>
    /// Manipulate configurations injected by Heroku
    /// </summary>
    public class HerokuConfiguration
    {
        private static string _databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

        private const string Port = "5432";

        public static bool IsAvailable() => !string.IsNullOrEmpty(_databaseUrl);

        public static string GetConnectionString()
        {
            if (!IsAvailable())
            {
                throw new HerokuConfigurationNotFoundException();
            };

            var connectionString = _databaseUrl.Replace("postgres://", string.Empty);
            var parts = connectionString.Split('@');
            var credentials = parts[0].Split(':');

            var username = credentials[0];
            var password = credentials[1];

            var pgInfo = parts[1].Split(':');

            var host = pgInfo[0];
            var database = pgInfo[1].Replace("5432/", string.Empty);

            return $"Server={host};Port={Port};Database={database};Userid={username};Password={password};sslmode=Require;Trust Server Certificate=true;Timeout=1000;";
        }
    }

    public class HerokuConfigurationNotFoundException : Exception
    {
        public HerokuConfigurationNotFoundException() : base() { }
    }
}
