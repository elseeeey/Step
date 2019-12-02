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

namespace Homework_18._11._2019
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string login;
        private string password;
        private string email;
        private int number;

        public Window1()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Length > 5 && PasswordTextBox.Password.Length > 8)
            {
                List<User> users = new List<User>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream("persons.xml", FileMode.Open))
                {
                    users = (List<User>)formatter.Deserialize(fs);
                    foreach (var item in users)
                    {
                       if(login==item.Login && password==item.Password)
                       {
                            MessageBox.Show("You were logined in");
                       }
                    } 
                }
                using (FileStream fs = new FileStream("persons.xml", FileMode.Create))
                {
                    User user = new User(login, password, email, number);
                    users = (List<User>)formatter.Deserialize(fs);
                    foreach (var item in users)
                    {
                        formatter.Serialize(fs, user);
                    }
                }
            }
            else
            {
                MessageBox.Show("Write Login or Password Correctly");
            }
        }
    }
}
