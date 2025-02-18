var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Reminders_ApiService>("apiservice");

builder.Build().Run();
