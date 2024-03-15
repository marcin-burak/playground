using Notes.Web.Features;
using Notes.Web.Infrastructure.Mongo;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMongo()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();