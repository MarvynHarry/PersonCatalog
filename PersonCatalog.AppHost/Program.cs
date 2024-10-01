var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PersonCatalog_API>("personcatalog-api");

builder.Build().Run();
