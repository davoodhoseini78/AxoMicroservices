var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter(configurator: c =>
{
    
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

app.MapCarter();

app.Run();
