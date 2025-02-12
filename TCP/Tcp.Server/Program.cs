using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tcp.Server;

internal static class Program
{
    private static void Main()
    {
        const int port = 52005;
        var server = new TcpListener(IPAddress.Any, port);

        server.Start();
        Console.WriteLine("Server started, waiting for connections...");

        while (true)
        {
            var client = server.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            var stream = client.GetStream();

            var buffer = new byte[1024];
            int bytesRead;
            var sb = new StringBuilder();

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            Console.WriteLine(sb.ToString());

            client.Close();
        }
    }
}