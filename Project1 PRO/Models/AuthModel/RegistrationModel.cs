using Newtonsoft.Json;
using Progect1.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Progect1.Models.AuthModel
{
     class RegistrationModel
    {
         RegistrationPageViewModel registrationPageViewModel;
        public RegistrationModel(RegistrationPageViewModel RegistrationPageViewModel)
        {
            registrationPageViewModel = RegistrationPageViewModel;
            //RegistrationPageViewModel.MainViewModel.OkReg = Visibility.Visible;
        }
        public void Registration(AccauntRegistration acc)
        {
            string output = JsonConvert.SerializeObject(acc);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005));
            NetworkStream nts = new NetworkStream(socket);
            BinaryReader br = new BinaryReader(nts);
            BinaryWriter bw = new BinaryWriter(nts);
            bw.Write("regclient");
            bw.Write("Registration");
            bw.Write(output);
            if(br.ReadBoolean() == true)
            registrationPageViewModel.MainViewModel.OkReg = Visibility.Visible;
        }
    }
    [Serializable]
    public class AccauntRegistration
    { 
        public string Login;
        public string Password; 
        public string Email;
        public AccauntRegistration(string login,string password,string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }
     public static class Validation
     {
        
        public static string LoginValidation(string Login)
        {
            if (String.IsNullOrEmpty(Login))
            {
                return "Поле не может быть пустым";
            }
            else
            {
                if (!String.IsNullOrEmpty(Login) & Login.Length < 6)
                { return "Логин может быть не короче 6 символов"; }
                else if (!String.IsNullOrEmpty(Login) & !Regex.IsMatch(Login, "^[a-zA-Z0-9]+$"))
                { return "Некорректный логин"; }
                else if(!OnlineOnlineValidate(Login,"Login"))
                { return "Такой логин уже зарегистрирован"; }
            }
            return "CorrectLogin";
        }
        public static string PasswordValidation(string Password)
        {
            if (String.IsNullOrEmpty(Password))
                return "Поле не может быть пустым";
            else if (Password.Length < 6)
                return "Пароль не может быть короче 6 символов";
            return "CorrectPassword";
            
        }
        public static string EmailValidation(string Email)
        {
            if (String.IsNullOrEmpty(Email))
            {
                return "Поле не может быть пустым";
            }
            else if(!String.IsNullOrEmpty(Email) & !Regex.IsMatch(Email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            { return "Некорректный Email"; }
            else if(!OnlineOnlineValidate(Email,"Email"))
            { return "Такой Email уже зарегистрирован"; }
            return "CorrectEmail";
        }
        public static bool OnlineOnlineValidate(string validate,string validatefield)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005));
            NetworkStream nts = new NetworkStream(socket);
            BinaryReader br = new BinaryReader(nts);
            BinaryWriter bw = new BinaryWriter(nts);
            bw.Write("regclient");
            bw.Write("OnlineValidate");
            bw.Write(validatefield);
            bw.Write(validate);
            return br.ReadBoolean();
        }
     }




















    //public void Registration(AccauntRegistration acc)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    // получаем поток, куда будем записывать сериализованный объект
    //    byte[] bt = new byte[256];
    //    using (MemoryStream fs = new MemoryStream(bt))
    //    {
    //        formatter.Serialize(fs, acc);

    //        Debug.WriteLine("Объект сериализован");
    //    }
    //    BinaryFormatter formatter1 = new BinaryFormatter();
    //    using (MemoryStream fs = new MemoryStream(bt))
    //    {
    //        AccauntRegistration acc2 = (AccauntRegistration)formatter1.Deserialize(fs);

    //        Debug.WriteLine($"Объект десериализован: {acc2.Login} {acc2.Password} {acc2.Email}");
    //    }
    //}
}
