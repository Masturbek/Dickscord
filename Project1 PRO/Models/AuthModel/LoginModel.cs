using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Progect1.Models.LoginModel
{
    public class LoginModel
    {
        static int port = 8005;
        static string address = "127.0.0.1";
        static IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

        public string Login;
        public string Password;
        public void Authorization(string login, string password)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            NetworkStream nws = new NetworkStream(socket);
            BinaryWriter bw = new BinaryWriter(nws);
            BinaryReader br = new BinaryReader(nws);
            bw.Write("Client");
            bw.Write("LogIn");
            bw.Write(login);
            bw.Write(password);
        }
    }
}
