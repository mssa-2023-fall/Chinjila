var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Configure the HTTP request pipeline.


//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});
app.Run(async context =>
{
    var path = context.Request.Path;
    if (path.Value?.Split('/').Length > 2)
        if (int.TryParse(path.Value?.Split('/')[1], out int a) & int.TryParse(path.Value?.Split('/')[2], out int b))
        { await context.Response.WriteAsync($"{a + b}");
            return;
        }
  
await context.Response.WriteAsync("Hello world!");
});

app.Run();