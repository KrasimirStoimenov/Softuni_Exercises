﻿using System.Threading.Tasks;
using HandmadeHttpServer.Controllers;
using HandmadeHttpServer.App.Controllers;

namespace HandmadeHttpServer.App
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            await new HttpServer(routes => routes
                 .MapStaticFiles()
                 .MapGet<HomeController>("/", c => c.Index())
                 .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                 .MapGet<HomeController>("/Google", c => c.ToGoogle())
                 .MapGet<HomeController>("/Error", c => c.Error())
                 .MapGet<HomeController>("/StaticFiles", c=>c.StaticFiles())
                 .MapGet<AccountController>("/Login", c => c.Login())
                 .MapGet<AccountController>("/Logout", c => c.Logout())
                 .MapGet<AccountController>("/Cookies", c => c.CookieCheck())
                 .MapGet<AccountController>("/Session", c => c.SessionCheck())
                 .MapGet<AccountController>("/Authentication", c => c.AuthenticationCheck())
                 .MapGet<AnimalsController>("/Cats", c => c.Cats())
                 .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                 .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
                 .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
                 .MapGet<CatsController>("/Cats/Create", c => c.Create())
                 .MapPost<CatsController>("/Cats/Save", c => c.Save()))
             .Start();
        }
    }
}
