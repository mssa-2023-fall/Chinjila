using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Configure the HTTP request pipeline.


//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});

// /5/8 returns 13
//app.Run(async context =>
//{
//    var path = context.Request.Path;
//    if (path.Value?.Split('/').Length > 2)
//        if (int.TryParse(path.Value?.Split('/')[1], out int a) &
//        int.TryParse(path.Value?.Split('/')[2], out int b))
//        { await context.Response.WriteAsync($"{a + b}");
//            return;
//        }

//    await context.Response.WriteAsync("Hello world!");
//});


// https://localhost:xxxx/Some prompt => https://letmegooglethat.com/?q=[prompt]
//   context.Response.Redirect
//   [prompt] must be encoded correctly in query string form
app.Run(async context =>
{
    var path = context.Request.Path;
if (path.Value?.Length > 1) {
    var prompt = path.Value.Substring(2);
    var uri = new Uri($"https://letmegooglethat.com/?q={prompt}");
    context.Response.Redirect(UriHelper.Encode(uri));
        return;
    }

    var sampleUrl = "https://" + $"{context.Request.Host + context.Request.Path + "/what is the weather today?"}";
    var sampleUri = new Uri(sampleUrl);
   
    await context.Response.WriteAsync("<h1>LMGTFY</h1>");
   await context.Response.WriteAsync($"<h2>try this <a href={UriHelper.Encode(sampleUri)}>sampleUrl</a></h2>");
}
);

app.Run();