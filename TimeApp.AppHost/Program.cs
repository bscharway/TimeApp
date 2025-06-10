var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TimeApp>("timeapp")
    .WithExternalHttpEndpoints();

builder.Build().Run();
