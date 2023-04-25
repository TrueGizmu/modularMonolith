using ModularMonolith.Modules.Conferences.Api;
using ModularMonolith.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure()
    .AddConferences();

var app = builder.Build();

app.UseInfrastructure();

app.Run();