using Newtonsoft.Json;
using Progect1.Models.FriendModel;
using Progect1.ViewModels;
using Progect1.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Progect1.Models.LoginModel
{
     class LoginModel
     {
        LoginPageViewModel loginPageViewModel { get; }
        MainViewModel mainViewModel { get; }
        public LoginModel(LoginPageViewModel loginpageviewmodel,MainViewModel mainviewmodel)
        {
            loginPageViewModel = loginpageviewmodel;
            mainViewModel = mainviewmodel;
        }
        static int port = 8005;
        static string address = "127.0.0.1";
        static IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

        public void Authorization(AccountLogin accauntlogin)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            NetworkStream nws = new NetworkStream(socket);
            BinaryWriter bw = new BinaryWriter(nws);
            BinaryReader br = new BinaryReader(nws);
            bw.Write("Client");
            bw.Write("Login");
            string output = JsonConvert.SerializeObject(accauntlogin);
            bw.Write(output);

            //if (br.ReadBoolean()) Debug.WriteLine("Найден");
            //else { Debug.WriteLine("Не найден"); loginPageViewModel.ErrorTextMessage("Не все поля заполнены"); }
            switch (br.ReadString())
            {
                case "usernotfound": loginPageViewModel.ErrorTextMessage("Неправильный логин или пароль");
                    break;
                case "loginOk":
                    mainViewModel.Loading = Visibility.Visible;
                    FriendsLoading();
                    mainViewModel.Loading = Visibility.Collapsed;
                    break;
            }
            nws.Dispose(); bw.Dispose(); br.Dispose(); socket.Dispose();


        }

        void FriendsLoading()
        {
            
        }
    }
    [Serializable]
    public class AccountLogin
    {
        public AccountLogin(string login,string password)
        {
            Login = login;
            Password = password;
        }
        public string Login;
        public string Password;
    }
    [Serializable]
    public class FriendsSend
    {
        public ObservableCollection<Profile> SendFriends = new ObservableCollection<Profile>();
        public FriendsSend(ObservableCollection<Profile> sendfriends)
        {
            SendFriends = sendfriends;
        }
    }
}
