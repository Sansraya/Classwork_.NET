namespace Sem2.Middleware
{
    public class RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var requestDateTime= DateTime.UtcNow;
            var requestMethod = context.Request.Method;
            var path = context.Request.Path;
            var userRole= "Anonymous";

            
            await next(context);

            if (context?.User?.Identity?.IsAuthenticated == true)
            {
                var roleClaim = context.User.Claims.Where(c => c.Type.Contains("role")).Select(c => c.Value);
                if (roleClaim.Any())
                {
                    userRole = string.Join(",", roleClaim);
                }
            }

            var statusCode = context.Response.StatusCode;
            var responseTime = (DateTime.UtcNow - requestDateTime).TotalMilliseconds;

            logger.LogInformation($"[{requestDateTime}] {requestMethod} {path} | User: {userRole} | Status: {statusCode} | Time: {responseTime}ms");

        }
    }
}
