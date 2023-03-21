using System.Linq;
using Microsoft.AspNetCore.Builder;
using ULinksBackend.Repositories.Interfaces;
using ULinksBackend.Repositories.Repositories;
using UsefulLinksBackend;
using UsefulLinksBackend.Database;
using UsefulLinksBackend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.Extensions.DependencyInjection;
using ULinksBackend.Services;
using ULinksBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// var dbCtx = new AppDbContext();
//
// dbCtx.Database.EnsureCreated();
//
//
// var ulink = new UsefulLink()
// {
//     Description = "desc",
//     Heading = "head",
//     Link = "https://example.com",
//     TagList = new List<ULinkTag>()
//     {
//     }
// };
//
// dbCtx.UsefulLinks.Add(ulink);
// dbCtx.SaveChanges();
//
// var links = dbCtx.UsefulLinks.Select(x => x).ToList();
//
// // var ultag = new ULinkTag()
// // {
// //     UsefulLinkId = 1,
// //     Name = "dsas"
// // };
// // dbCtx.ULinkTags.Add(ultag);
// // dbCtx.SaveChanges();
//
// var links2 = dbCtx.UsefulLinks.Select(x => x).ToList();
// return;


string adminLogin, adminPassword;

var config = builder.Configuration;

adminLogin = config["UserSettings:AdminLogin"];
adminPassword = config["UserSettings:AdminPassword"];

Storage.Login = adminLogin;
Storage.Password = adminPassword;


Storage.Token = "7a5c6826-4f56-4514-b4e6-bfa8ca63e2b6";


// Add services to the container.



// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("VueCorsPolicy", builder =>
//     {
//         builder
//             .AllowAnyHeader()
//             .AllowAnyMethod()
//             .AllowCredentials()
//             .WithOrigins("http://localhost:3005");
//     });
// });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddEntityFrameworkSqlite().AddDbContext<AppDbContext>();

builder.Services.AddTransient<ITagsRepository, TagsRepository>();
builder.Services.AddScoped<IUsefulLinksRepository, UsefulLinksRepository>();

builder.Services.AddTransient<ITagsService, TagsService>();


var appDb = new AppDbContext();

appDb.Database.EnsureCreated();

var tagsRepo = new TagsRepository(appDb);

Storage.AllTags = tagsRepo.GetTags().Result.Select(x=>x.Name).ToList();


var app = builder.Build();


//app.UseCors("VueCorsPolicy");
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();


string adminToken = "";


app.Use((context, next) =>
{
    string path = context.Request.Path.Value;

    if (path != null && path.StartsWith("/admin"))
    {
        string token = context.Request.Headers["token"];

        if (token != Storage.Token)
        {
            context.Response.StatusCode = 401;
            return context.Response.WriteAsync("token is invalid!!!");
        }
        else
        {
            return next(context);
        }
    }


    return next(context);
});

// app.UseSpaStaticFiles();
// app.UseSpa(configuration: builder =>
// {
//         builder.UseProxyToSpaDevelopmentServer("http://localhost:3005");
//     
// });


app.MapControllers();

app.Run();