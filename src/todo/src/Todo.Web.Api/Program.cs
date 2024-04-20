using Todo.Common.ApplicationInsights;
using Todo.SqlServer;
using Todo.Web.Api.Dependencies.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApiConfiguration(builder.Configuration)
    .AddApplicationInsightsConfiguration()
    .AddSqlServerConfiguration(builder.Configuration);

var app = builder.Build();

app.UseOpenApiIfEnabled();

app.MapGet("/api/ping", () => "pong");

await SqlServerInitialization.Initialize(app.Services, CancellationToken.None);

await app.RunAsync(CancellationToken.None);