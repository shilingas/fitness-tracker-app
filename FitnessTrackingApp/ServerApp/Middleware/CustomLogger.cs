namespace FitnessTrackingApp.ServerApp.Middleware
{
    public class CustomLogger : ICustomLogger
    {
        private readonly ILogger<ICustomLogger> _logger;
        private readonly IConfiguration _configuration;

        public CustomLogger(ILogger<ICustomLogger> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        private bool IsLoggingEnabled()
        {
            return _configuration.GetValue<bool>("Logging:EnableBusinessLogicLogging");
        }

        public void LogError(string message)
        {
            if (IsLoggingEnabled())
            {
                _logger.LogError(message);
            }
        }

        public void LogInformation(string message)
        {
            if (IsLoggingEnabled())
            {
                _logger.LogInformation(message);
            }
        }

        public void LogWarning(string message)
        {
            if (IsLoggingEnabled())
            {
                _logger.LogWarning(message);
            }
        }
    }
}
