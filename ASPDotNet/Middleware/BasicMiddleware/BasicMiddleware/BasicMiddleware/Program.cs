var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Configure the HTTP request pipeline.


app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});


app.Run();