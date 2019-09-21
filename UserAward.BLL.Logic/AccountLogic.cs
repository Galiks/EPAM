using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;

namespace UserAward.BLL.Logic
{
    public class AccountLogic : IAccountLogic
    {
        public int? AddAccount(string email, string password, string role, string createdAt, DateTime loggedInto, DateTime passwordLifetime, string idUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string idAccount)
        {
            throw new NotImplementedException();
        }

        public Guid EncryptionPassword(string password)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(password);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            //заносить в БД пароль в стринговом представлении не стоит, лучше использовать тип ячейки Uniqueidentifier.
            return new Guid(hash);
        }

        public Account GetAccountByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(string email, string password, string role, string createdAt, DateTime loggedInto, DateTime passwordLifetime, string idUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateLoggerIntoAccount(int idUser, DateTime loggerInto)
        {
            throw new NotImplementedException();
        }

        public void UpdatePasswordLifetimeAccount(int idUser, DateTime passwordLifetime)
        {
            throw new NotImplementedException();
        }
    }
}
