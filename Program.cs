using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi(); // genera /openapi/v1.json

app.MapScalarApiReference(options =>
{
    options.Title = "ExamenU1 API";
});


app.MapControllers();
app.Run();