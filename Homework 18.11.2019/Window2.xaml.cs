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
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Homework_18._11._2019
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    /// 

    public partial class Window2 : Window
    {
        
        public Window2()
        {
            InitializeComponent();
        }

        public bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (LogTextBox.Text.Length > 5 && PhoneTextBox.Text.Length > 9 && PasswordTextBox.Password == RePasswordTextBox.Password && IsValidEmailAddress(MailTextBox.Text))
            {
                bool result = IsValidEmailAddress(MailTextBox.Text);
                List<User> users = new List<User>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                using (StreamWriter sw = new StreamWriter("persons.xml",true))
                {
                    sw.Write(LogTextBox.Text);
                    sw.Write(":");
                    sw.Write(PasswordTextBox.Password);
                    sw.Write(":");
                    sw.Write(MailTextBox.Text);
                    sw.Write(":");
                    sw.Write(PhoneTextBox.Text);
                }
                users.Add(new User()
                {
                    Login = LogTextBox.Text,
                    Email = MailTextBox.Text,
                    Password = PasswordTextBox.Password,
                    
                });

                Window1 window1 = new Window1();
                window1.Show();
            }
            else
            {
                MessageBox.Show("Fill in information correctly");
            }
        }

        
    }
    
}    