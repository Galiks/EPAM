using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        private Guid password;

        public int IdUser { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public byte[] UserPhoto { get; set; }
        public string Password
        {
            set
            {
                password = EncryptionPassword(value);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Birthday.GetHashCode() ^ Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User value))
            {
                throw new ArgumentException("Ooops. Argument Exception");
            }

            return value.Name.Equals(this.Name) ^ value.Birthday.Equals(this.Birthday) ^ value.Age.Equals(this.Age);
        }

        public override string ToString()
        {
            return $"{IdUser}; {Name}; {Birthday}; {Age}";
        }

        public Guid EncryptionPassword(string password)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(password);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            //заносить в БД пароль в стринговом представлении не стоит, лучше использовать тип ячейки Uniqueidentifier.
            return new Guid(hash);
        }
    }
}
