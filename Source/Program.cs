using bsg_crud_app.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
builder.Services.ConfigureDbContext(builder.Configuration);

var app = builder.Build();

app.ConfigureWebApplication();

app.Run();
