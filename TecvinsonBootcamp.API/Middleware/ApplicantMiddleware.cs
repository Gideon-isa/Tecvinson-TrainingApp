namespace TecvinsonBootcamp.API.Middleware
{
    public class ApplicantMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;

        public ApplicantMiddleware(RequestDelegate next, ILogger<ApplicantMiddleware> ilogger)
        {
            _requestDelegate = next;
            _logger = ilogger;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong");
                
            }
        }
        
    }
}
