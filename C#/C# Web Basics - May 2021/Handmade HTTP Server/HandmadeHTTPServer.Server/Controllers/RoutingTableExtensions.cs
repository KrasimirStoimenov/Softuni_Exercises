using System;
using HandmadeHttpServer.Routing;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
        {
            return routingTable.MapGet(path, request => controllerFunction(CreateController<TController>(request)));
        }

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
        {
            return routingTable.MapPost(path, request => controllerFunction(CreateController<TController>(request)));
        }

        private static TController CreateController<TController>(HttpRequest request)
        {
            return (TController)Activator.CreateInstance(typeof(TController), new[] { request });
        }
    }
}
