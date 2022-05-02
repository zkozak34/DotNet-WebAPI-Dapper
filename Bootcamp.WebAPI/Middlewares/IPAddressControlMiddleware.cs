using System.Net;

namespace Bootcamp.WebAPI.Middlewares
{
    public class IPAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IConfiguration _configuration;

        public IPAddressControlMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            _requestDelegate = requestDelegate;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var reqIpAddress = context.Connection.RemoteIpAddress;
            var serIpAddress = IPAddress.Parse(_configuration["WhiteIPAddress"]);
            if (serIpAddress.Equals(reqIpAddress))
            {
                await _requestDelegate.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden");
            }
        }
    }
}
