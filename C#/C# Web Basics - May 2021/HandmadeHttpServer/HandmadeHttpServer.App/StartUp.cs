using System.Threading.Tasks;
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
                 .MapControllers()
                 .MapPost<CatsController>("/Cats/Save", c => c.Save()))
             .Start();
        }
    }
}
