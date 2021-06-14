using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HandmadeHttpServer.Http;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;
using HandmadeHttpServer.Routing;

namespace HandmadeHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.ipAddress, this.port);
            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(5000, routingTable)
        {
        }

        public async Task Start()
        {
            listener.Start();

            Console.WriteLine($"Server started at {this.ipAddress}:{this.port}");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await this.ReadRequest(networkStream);


                try
                {
                    var request = HttpRequest.ParseHttpRequest(requestText);

                    var response = this.routingTable.ExecuteRequest(request);

                    this.PrepareSession(request, response);

                    this.LogPipeline(request, response);

                    await WriteResponse(networkStream, response);
                }
                catch (Exception ex)
                {

                    await HandleError(networkStream, ex);
                }

                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream stream)
        {
            var requestBuilder = new StringBuilder();

            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            do
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                requestBuilder.Append(request);
            }
            while (stream.DataAvailable);


            return requestBuilder.ToString();
        }

        private void PrepareSession(HttpRequest request, HttpResponse response)
        {
            response.AddCookie(HttpSession.SessionCookieName, request.Session.Id);
        }

        private void LogPipeline(HttpRequest request, HttpResponse response)
        {
            var separator = new string('-', 50);

            var log = new StringBuilder();

            log.AppendLine();
            log.AppendLine(separator);

            log.AppendLine("REQUEST:");
            log.AppendLine(request.ToString());

            log.AppendLine();

            log.AppendLine("RESPONSE:");
            log.AppendLine(response.ToString());

            log.AppendLine();

            Console.WriteLine(log);
        }

        private async Task HandleError(NetworkStream networkStream, Exception exception)
        {
            var errorMessage = $"{exception.Message}{Environment.NewLine}{exception.StackTrace}";

            var errorResponse = HttpResponse.ForError(errorMessage);

            await WriteResponse(networkStream, errorResponse);
        }

        private async Task WriteResponse(NetworkStream stream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await stream.WriteAsync(responseBytes);
        }
    }
}
