using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutuphaneotomasyonu.DAL;

namespace kutuphaneotomasyonu.Service
{
    public class UserService
    {
        UserDAL userDAL = new UserDAL();

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Kullanıcı adı ve şifre boş olamaz");
            }

            return userDAL.Login(username, password);
        }
    }
}
