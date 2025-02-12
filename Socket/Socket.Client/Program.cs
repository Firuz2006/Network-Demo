using System.Net.Sockets;
using System.Text;

namespace Socket.Client;

internal static class Program
{
    private static void Main()
    {
        const string serverAddress = "127.0.0.1";
        const int port = 9000;

        var clientSocket =
            new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(serverAddress, port);

        const string message = "Hello, TCP Server!";
        var messageBytes = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(messageBytes);
        Console.WriteLine("Sent: " + message);

        var buffer = new byte[1024];
        var bytesRead = clientSocket.Receive(buffer);
        var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Received: " + response);

        clientSocket.Close();
    }
}