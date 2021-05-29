using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HandmadeHttpServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.ipAddress, this.port);
        }

        public async Task Start()
        {
            listener.Start();

            Console.WriteLine($"Server started at {this.ipAddress}:{this.port}");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();
                var stream = connection.GetStream();

                var requestText = await this.ReadRequest(stream);

                Console.WriteLine(requestText);

                await WriteResponse(stream);

                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream stream)
        {
            var requestBuilder = new StringBuilder();

            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            while (stream.DataAvailable)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                requestBuilder.Append(request);
            }

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream stream)
        {
            var content = "Hello from My Web Server";
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = @$"   HTTP/1.1 200 OK
                                Date:{DateTime.UtcNow}
                                Server:My web server
                                Content-Type: text/plain
                                Content-Length: {contentLength}

                                {content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            await stream.WriteAsync(responseBytes);
        }
    }
}
