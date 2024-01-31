var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Apps_AspireStarter_ApiService>("apiservice");

builder.AddProject<Projects.Apps_AspireStarter_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
