using Microsoft.Extensions.Options;

namespace Todo.Web.Api.Dependencies.OpenApi;

internal static class Middleware
{
    public static WebApplication UseOpenApiIfEnabled(this WebApplication app)
    {
        var openApiOptions = app.Services.GetRequiredService<IOptions<OpenApiOptions>>();
        if (openApiOptions.Value.Enabled)
        {
            app
                .UseSwagger()
                .UseSwaggerUI();
        }

        return app;
    }
}
