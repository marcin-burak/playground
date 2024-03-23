using Notes.Web.Infrastructure.SqlServer;
using Notes.Web.Initialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSqlServerConfiguration(builder.Configuration)
    .AddInitialization()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await Initialize.TryInitialize(app.Services, CancellationToken.None);

app.Run();