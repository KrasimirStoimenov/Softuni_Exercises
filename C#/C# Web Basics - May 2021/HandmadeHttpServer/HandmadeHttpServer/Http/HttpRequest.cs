using System;
using System.Linq;
using System.Collections.Generic;

namespace HandmadeHttpServer.Http.HttpRequest
{
    public class HttpRequest
    {
        private const string newLine = "\r\n";

        private static Dictionary<string, HttpSession> Sessions = new();

        public HttpMethod Method { get; private set; }

        public HttpSession Session { get; private set; }

        public string Path { get; private set; }

        public string Body { get; private set; }

        public IReadOnlyDictionary<string, HttpHeader> Headers { get; private set; }

        public IReadOnlyDictionary<string, HttpCookie> Cookies { get; private set; }

        public IReadOnlyDictionary<string, string> Query { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static HttpRequest ParseHttpRequest(string request)
        {
            var lines = request.Split(newLine);

            var firstLineSplitted = lines[0].Split(" ");

            var method = ParseMethod(firstLineSplitted[0]);

            var url = firstLineSplitted[1];

            var (path, query) = ParseUrl(url);

            var headers = ParseHeaders(lines.Skip(1));

            var cookies = ParseCookies(headers);

            var session = GetSession(cookies);

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(newLine, bodyLines);

            var form = ParseForm(headers, body);

            return new HttpRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Cookies = cookies,
                Session = session,
                Body = body,
                Form = form
            };

        }

        private static HttpMethod ParseMethod(string request)
        {
            var parsed = Enum.TryParse<HttpMethod>(request, true, out var method);

            if (parsed)
            {
                return method;
            }

            throw new InvalidOperationException("Method is not supported!");
        }

        private static (string, Dictionary<string, string>) ParseUrl(string url)
        {
            var urlParts = url.Split("?", 2);

            var path = urlParts[0];
            var query = urlParts.Length > 1
                        ? ParseQuery(urlParts[1])
                        : new Dictionary<string, string>();

            return (path, query);
        }

        private static Dictionary<string, HttpHeader> ParseHeaders(IEnumerable<string> headers)
        {
            var currentHeaders = new Dictionary<string, HttpHeader>();
            foreach (var header in headers)
            {
                if (header == string.Empty)
                {
                    break;
                }

                var headerParts = header.Split(": ", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var name = headerParts[0];
                var value = headerParts[1];

                var currentHeader = new HttpHeader(name, value);

                currentHeaders.Add(name, currentHeader);
            }

            return currentHeaders;
        }

        private static Dictionary<string, HttpCookie> ParseCookies(Dictionary<string, HttpHeader> headers)
        {
            var cookies = new Dictionary<string, HttpCookie>();

            if (headers.ContainsKey(HttpHeader.Cookie))
            {
                var cookieHeader = headers[HttpHeader.Cookie];

                var allCookies = cookieHeader.Value.Split("; ");

                foreach (var cookie in allCookies)
                {
                    var cookieParts = cookie.Split('=');

                    var cookieName = cookieParts[0];
                    var cookieValue = cookieParts[1];

                    cookies.Add(cookieName, new HttpCookie(cookieName, cookieValue));
                }
            }

            return cookies;
        }

        private static HttpSession GetSession(Dictionary<string, HttpCookie> cookies)
        {
            var sessionId = cookies.ContainsKey(HttpSession.SessionCookieName)
                ? cookies[HttpSession.SessionCookieName].Value
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new HttpSession(sessionId)
                {
                    IsNew = true
                };
            }

            return Sessions[sessionId];
        }

        private static Dictionary<string, string> ParseQuery(string queryString)
        {
            return queryString
                .Split("&")
                .Select(part => part.Split("="))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0], part => part[1]);
        }

        private static Dictionary<string, string> ParseForm(Dictionary<string, HttpHeader> headers, string body)
        {
            var result = new Dictionary<string, string>();

            if (headers.ContainsKey(HttpHeader.ContentType) && headers[HttpHeader.ContentType].Value == HttpContentType.FormUrlEncoded)
            {
                result = ParseQuery(body);
            }

            return result;
        }
    }
}
