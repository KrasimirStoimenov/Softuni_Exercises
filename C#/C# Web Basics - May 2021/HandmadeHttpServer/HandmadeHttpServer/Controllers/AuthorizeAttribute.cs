using System;

namespace HandmadeHttpServer.Controllers
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute
    {
    }
}
