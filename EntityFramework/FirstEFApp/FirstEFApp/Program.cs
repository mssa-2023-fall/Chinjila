using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using var db = new BloggingContext();

//// Note: This sample requires the database to be created before running.
////Console.WriteLine($"Database path: {db.DbPath}.");

//// Create
//Console.WriteLine("Inserting a new blog");
//db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
//db.SaveChanges();

//// Read
//Console.WriteLine("Querying for a blog");
//var blog = db.Blogs
//    .OrderBy(b => b.BlogId)
//    .First();

//// Update
//Console.WriteLine("Updating the blog and adding a post");
//blog.Url = "https://devblogs.microsoft.com/dotnet";

//var p = new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" };
//p.Author = new Author { Name = "Bob" };

//blog.Posts.Add(p);
//db.SaveChanges();


var query = from p2 in db.Posts select p2;
query = query.Where(p => p.Title.StartsWith("Hello")).Include("Blog").Include("Author");
//delayed evaluation
Post p = query.First();

Console.WriteLine(p.Title);
Console.WriteLine(p.BlogId);
Console.WriteLine(p.Blog.Url);
Console.WriteLine(p.Author.Name);




Console.WriteLine("Delete the blog");
//db.Remove(blog);
db.SaveChanges();