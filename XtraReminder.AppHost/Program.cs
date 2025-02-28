var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.XtraReminder_WebApi>("xtrareminder-webapi");

builder.Build().Run();
