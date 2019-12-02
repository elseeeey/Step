using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18._11._2019
{
    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        // стандартный конструктор без параметров
        public User()
        { }

        public User(string login, string password, string email, int number)
        {
            Login = login;
            Password = password;
            Email = email;
            PhoneNumber = number;

        }
    }
}
