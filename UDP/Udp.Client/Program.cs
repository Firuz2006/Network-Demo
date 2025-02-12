using System.Net;
using System.Net.Sockets;
using System.Text;

internal static class Program
{
    static async Task Main()
    {
        using var udpClient = new UdpClient();

        var message = "Hello, UDP Server!";
        var data = Encoding.UTF8.GetBytes(message);
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 51002);

        await udpClient.SendAsync(data, data.Length, serverEndpoint);
        Console.WriteLine("Message sent to server.");
    }
}