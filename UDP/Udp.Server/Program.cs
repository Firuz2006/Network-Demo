using System.Net.Sockets;
using System.Text;

namespace Udp.Server;

internal static class Program
{
    static async Task Main()
    {
        using var udpServer = new UdpClient(51002);
        Console.WriteLine("UDP Server listening on port 51002...");

        while (true)
        {
            var received = await udpServer.ReceiveAsync();
            var message = Encoding.UTF8.GetString(received.Buffer);
            Console.WriteLine($"Received: {message} from {received.RemoteEndPoint}");
        }
    }
}