namespace CoreRankingAPI.Middlewares;

public class HeaderHandlerMiddleware
{
    private readonly RequestDelegate next;

    public HeaderHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        foreach (var header in context.Request.Headers)
        {
            if (header.Key.Equals("WebRankingHeader") & header.Value.Equals("ServerName"))
            {
                await next(context);
                return;
            }
        }

        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        context.Response.ContentType = "text/plain";

        await context.Response.WriteAsync("USO PROIBIDO");
    }
}