using System.Net.Sockets;
using System.Text;

namespace Tcp.Client;

internal static class Program
{
    private static void Main()
    {
        const string serverAddress = "127.0.0.1";
        const int port = 52005;

        var client = new TcpClient(serverAddress, port);
        var stream = client.GetStream();

        const string message = "Hello, TCP Server!";
        var messageBytes = Encoding.UTF8.GetBytes(message);
        stream.Write(messageBytes, 0, messageBytes.Length);
        Console.WriteLine("Sent: " + message);

        client.Close();
    }
}