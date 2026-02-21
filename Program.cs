using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference(options => { options.Title = "ExamenU1 API";});

app.UseHttpsRedirection();

app.MapControllers();
app.Run();