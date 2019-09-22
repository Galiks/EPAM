using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;
using UserAward.DAL.Interface;

namespace UserAward.BLL.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountDao accountDao;
        private readonly IUserDao userDao;

        public AccountLogic(IAccountDao accountDao, IUserDao userDao)
        {
            this.accountDao = accountDao;
            this.userDao = userDao;
        }

        public int? AddAccount(string email, string password, string role, string idUser)
        {
            #region Validation
            if (Validation.Validation.IsEmptyStrings(email, password, role, idUser))
            {
                throw new ArgumentNullException("Parametres must be not null");
            }

            if (!Validation.Validation.IsRightEmail(email))
            {
                throw new ArgumentException("Incorrect email");
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                throw new ArgumentException("Incorrect user's id");
            }

            bool isUserExists = userDao.GetUserById(realIdUser) is null;

            if (isUserExists)
            {
                throw new Exception("User doesn't exists");
            }
            #endregion

            DateTime createdAt = DateTime.Now;
            DateTime passwordLifetime = createdAt.AddYears(1);

            Account account = new Account()
            {
                Email = email,
                Password = EncryptionPassword(password).ToString(),
                Role = role,
                IdUser = realIdUser,
                CreatedAt = createdAt,
                IsBlocked = false,
                LoggedInto = DateTime.MaxValue,
                PasswordLifetime = passwordLifetime
            };

            try
            {
                return accountDao.AddAccount(account);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool DeleteAccount(string idAccount)
        {
            if (Validation.Validation.IsEmptyStrings(idAccount))
            {
                throw new ArgumentNullException("Parametres must be not null");
            }

            if (!int.TryParse(idAccount, out int realIdAccount))
            {
                throw new ArgumentException("Invalid account's id");
            }

            try
            {
                accountDao.DeleteAccount(realIdAccount);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            if (Validation.Validation.IsEmptyStrings(email))
            {
                throw new ArgumentNullException("Parametres must be not null");
            }

            return accountDao.GetAccountByEmail(email);
        }

        public bool UpdateAccount(string email, string password, string role, string createdAt, string loggedInto, string passwordLifetime, bool isBlocked, string idUser)
        {
            #region Validation
            if (Validation.Validation.IsEmptyStrings(idUser))
            {
                throw new ArgumentNullException("Parametres must be not null");
            }

            if (!Validation.Validation.IsRightEmail(email))
            {
                throw new ArgumentException("Incorrect email");
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                throw new ArgumentException("Incorrect user's id");
            }


            if (!DateTime.TryParse(createdAt, out DateTime realCreatedAt) && !string.IsNullOrWhiteSpace(createdAt))
            {
                throw new ArgumentException("Incorrect created time");
            }


            if (!DateTime.TryParse(createdAt, out DateTime realLoggedInto) && !string.IsNullOrWhiteSpace(loggedInto))
            {
                throw new ArgumentException("Incorrect created time");
            }

            if (!DateTime.TryParse(createdAt, out DateTime realPasswordLifetime) && !string.IsNullOrWhiteSpace(passwordLifetime))
            {
                throw new ArgumentException("Incorrect created time");
            }
            #endregion

            try
            {
                Account account = accountDao.GetAccountByIdUser(realIdUser);

                account.Email = string.IsNullOrWhiteSpace(email) ? account.Email : email;
                account.Password = string.IsNullOrWhiteSpace(password) ? account.Password : EncryptionPassword(password).ToString();
                account.Role = string.IsNullOrWhiteSpace(role) ? account.Role : role;
                account.CreatedAt = realCreatedAt == default(DateTime) ? account.CreatedAt : realCreatedAt;
                account.LoggedInto = realLoggedInto == default(DateTime) ? account.LoggedInto : realLoggedInto;
                account.PasswordLifetime = realPasswordLifetime == default(DateTime) ? account.PasswordLifetime : realPasswordLifetime;
                account.IsBlocked = isBlocked;

                accountDao.UpdateAccount(account);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateLoggerIntoAccount(string idUser, string loggerInto)
        {
            #region Validation
            if (Validation.Validation.IsEmptyStrings(loggerInto))
            {
                throw new ArgumentNullException("Parametres must be not null");
            }

            if (!DateTime.TryParse(loggerInto, out DateTime realLoggerInto))
            {
                throw new ArgumentException("Invalid account's LoggerInto");
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                throw new ArgumentException("Invalid account's id user");
            }

            bool isAccountExists = accountDao.GetAccountByIdUser(realIdUser) is null;
            if (isAccountExists)
            {
                throw new Exception("Account is not exists");
            }
            #endregion

            try
            {
                accountDao.UpdateLoggerIntoAccount(realIdUser, realLoggerInto);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdatePasswordLifetimeAccount(string idUser, string passwordLifetime)
        {
            #region Validation
            if (Validation.Validation.IsEmptyStrings(passwordLifetime))
            {
                throw new ArgumentNullException("Parametres must be not null");
            }

            if (!DateTime.TryParse(passwordLifetime, out DateTime realPasswordLifetime))
            {
                throw new ArgumentException("Invalid account's LoggerInto");
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                throw new ArgumentException("Invalid account's id user");
            }

            bool isAccountExists = accountDao.GetAccountByIdUser(realIdUser) is null;
            if (isAccountExists)
            {
                throw new Exception("Account is not exists");
            }
            #endregion

            try
            {
                accountDao.UpdatePasswordLifetimeAccount(realIdUser, realPasswordLifetime);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
