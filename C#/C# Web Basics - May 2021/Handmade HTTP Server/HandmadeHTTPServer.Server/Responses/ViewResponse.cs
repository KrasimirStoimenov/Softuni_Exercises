﻿using HandmadeHTTPServer.Server.Http;
using HandmadeHTTPServer.Server.Http.HttpResponse;
using System.IO;
using System.Linq;

namespace HandmadeHTTPServer.Server.Responses
{
    public class ViewResponse : HttpResponse
    {
        private const char pathSeparator = '/';

        public ViewResponse(string viewName, string controllerName, object model)
            : base(HttpStatusCode.OK)
        {
            this.GetHtml(viewName, controllerName, model);
        }

        private void GetHtml(string viewName, string controllerName, object model)
        {
            if (!viewName.Contains(pathSeparator))
            {
                viewName = controllerName + pathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart(pathSeparator) + ".cshtml");

            if (!File.Exists(viewPath))
            {
                this.PrepareMissingViewError(viewPath);

                return;
            }

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.PrepareContent(viewContent, HttpContentType.Html);
        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(m => new
                {
                    m.Name,
                    Value = m.GetValue(model)
                });

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{openingBrackets}{entry.Name}{closingBrackets}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
