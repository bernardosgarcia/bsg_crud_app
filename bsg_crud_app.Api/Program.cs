using bsg_crud_app.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureWebApplication();

app.Run();
