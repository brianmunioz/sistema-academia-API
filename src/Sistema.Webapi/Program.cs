var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options=>{
        options.Path = "/openapi";
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();



app.MapControllers();
app.Run();

