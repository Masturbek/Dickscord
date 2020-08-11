using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Progect1.Models.AuthModel
{
    public class RegistrationModel
    {

        public void Registration(AccauntRegistration acc)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            byte[] bt = new byte[256];
            using (MemoryStream fs = new MemoryStream(bt))
            {
                formatter.Serialize(fs, acc);

                Debug.WriteLine("Объект сериализован");
            }
            BinaryFormatter formatter1 = new BinaryFormatter();
            using (MemoryStream fs = new MemoryStream(bt))
            {
                AccauntRegistration acc2 = (AccauntRegistration)formatter1.Deserialize(fs);

                Debug.WriteLine($"Объект десериализован: {acc2.Login} {acc2.Password} {acc2.Email}");     
            }
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
}
