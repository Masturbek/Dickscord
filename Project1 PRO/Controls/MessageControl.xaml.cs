using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Progect1.Controls
{
    /// <summary>
    /// Логика взаимодействия для MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public MessageControl(string nickname,string date,string message)
        {
            InitializeComponent();
            Nickname = nickname;
            Date = date;
            Text = message;
        }

        public string Nickname
        {
            get { return nicknm.Text; }
            set { nicknm.Text = value; }
        }
        public string Date
        {
            get { return date.Text; }
            set { date.Text = value; }
        }
        public string Text
        {
            get { return messagetext.Text; }
            set { messagetext.Text = value; }
        }
        //public BitmapImage Image
        //{
        //    get { return image.ImageSource = "";}
        //    //set { messagetext.Text = value; }
        //}
    }
}
