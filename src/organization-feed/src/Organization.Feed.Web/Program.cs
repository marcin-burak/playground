using Organization.Feed.Web.Dependencies.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityDependency(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<InitializeIdentity>().TryInitializeIdentity(CancellationToken.None);
}

app.Run();