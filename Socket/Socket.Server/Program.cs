using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket.Server;

internal static class Program
{
    private static void Main()
    {
        const int port = 9000;
        var ipAddress = IPAddress.Any;
        var endPoint = new IPEndPoint(ipAddress, port);
        var serverSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(endPoint);
        serverSocket.Listen(10);

        while (true)
        {
            var clientSocket = serverSocket.Accept();
            var buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = clientSocket.Receive(buffer)) > 0)
            {
                var received = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + received);
                const string response = "Message received";
                var responseBytes = Encoding.UTF8.GetBytes(response);
                clientSocket.Send(responseBytes);
            }

            clientSocket.Close();
        }
    }
}