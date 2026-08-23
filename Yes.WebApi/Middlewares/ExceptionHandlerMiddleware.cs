namespace Yes.WebApi.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(exception.Message);
    }
}
