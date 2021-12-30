namespace CoreRankingAPI.Middlewares;

public class ClientAccessMiddleware
{
    private readonly RequestDelegate next;

    public ClientAccessMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!ClientAccessControl.ProcessRequest(context.Connection.RemoteIpAddress?.ToString())
            | string.IsNullOrEmpty(context.Connection.RemoteIpAddress.ToString()))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.ContentType = "text/plain";

            await context.Response.WriteAsync("LIMITE DE REQUISIÇÃO ATINGIDO");

            return;
        }

        await next(context);
    }
}