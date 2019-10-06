using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using CalendarThematicPlan.Validation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private static readonly Logger loggerException = LogManager.GetLogger("exception");

        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public int? AddUser(string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto)
        {
            if (Validator.IsStringsNull(firstName, lastName, patronymic, email, password, role, position))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!Validator.IsRightEmail(email))
            {
                var exception = new ArgumentException($"Email не соответствует требованиям{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            User user = userDao.GetUserByEmail(email);
            if (user != null)
            {
                var exception = new ArgumentException($"Пользователь с таким Email уже есть{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            try
            {
                password = EncryptionPassword(password);

                User newUser = new User { FirstName = firstName, LastName = lastName, Patronymic = patronymic, Email = email, Password = password, Position = position, Role = role, UserPhoto = userPhoto };

                return userDao.AddUser(newUser);
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public void DeleteUser(string id)
        {
            if (!int.TryParse(id, out int idUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            User user = userDao.GetUserById(idUser);

            if (user == null)
            {
                var exception = new ArgumentException($"Пользователя с таким идентификатором не существует{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            try
            {
                userDao.DeleteUser(idUser);
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public User GetUserByEmail(string email)
        {
            if (Validator.IsStringsNull(email))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            return userDao.GetUserByEmail(email);
        }

        public User GetUserById(string id)
        {
            if(!int.TryParse(id, out int idUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            return userDao.GetUserById(idUser);
        }

        public IEnumerable<User> GetUsers()
        {
            return userDao.GetUsers().ToList();
        }

        public void UpdateUser(string id, string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto)
        {
            if (!int.TryParse(id, out int idUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(email) & !Validator.IsRightEmail(email))
            {
                var exception = new ArgumentException($"Email не соответствует требованиям{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            User user;
            if (idUser == default)
            {
                var exception = new ArgumentException($"Идентификатор пользователя неправильный{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
            else
            {
                user = userDao.GetUserById(idUser);
            }

            user.FirstName = string.IsNullOrWhiteSpace(firstName) ? user.FirstName : firstName;
            user.LastName = string.IsNullOrWhiteSpace(lastName) ? user.LastName : lastName;
            user.Patronymic = string.IsNullOrWhiteSpace(patronymic) ? user.Patronymic : patronymic;
            user.Email = string.IsNullOrWhiteSpace(email) ? user.Email : email;
            user.Password = string.IsNullOrWhiteSpace(password) ? user.Password : EncryptionPassword(password);
            user.Role = string.IsNullOrWhiteSpace(role) ? user.Role : role;
            user.Position = string.IsNullOrWhiteSpace(position) ? user.Position : position;
            user.UserPhoto = userPhoto ?? user.UserPhoto;

            try
            {
                userDao.UpdateUser(user);
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public string EncryptionPassword(string password)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] byteHash;

            //создаем объект для получения средст шифрования  
            using (MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider())
            {

                //вычисляем хеш-представление в байтах  
                byteHash = CSP.ComputeHash(bytes);
            }

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            //заносить в БД пароль в стринговом представлении не стоит, лучше использовать тип ячейки Uniqueidentifier.
            return new Guid(hash).ToString();
        }

        public IEnumerable<User> GetUsersByWord(string word)
        {
            return userDao.GetUsersByWord(word);
        }
    }
}
