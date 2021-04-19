using Microsoft.AspNetCore.Builder;

public static class MeuMiddlewareExtension
{
    public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MeuMiddleware>();
    }
}
