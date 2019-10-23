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

namespace CalendarThematicPlan.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private static readonly Logger loggerException = LogManager.GetLogger("exception");
        private static readonly Logger loggerUser = LogManager.GetLogger("user");

        private readonly IUserDao userDao;
        private readonly ISubjectDao subjectDao;

        public event EventHandler LogException;
        public event EventHandler LogUser;

        public UserLogic(IUserDao userDao, ISubjectDao subjectDao)
        {
            this.userDao = userDao;
            this.subjectDao = subjectDao;

            LogException += LoggerException;
            LogUser += LoggerUser;
        }

        public int? AddUser(string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto)
        {
            if (Validator.IsStringsNull(firstName, lastName, patronymic, email, password, role, position))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (!Validator.IsRightEmail(email))
            {
                var exception = new ArgumentException($"Email не соответствует требованиям{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            User user = userDao.GetUserByEmail(email);
            if (user != null)
            {
                var exception = new ArgumentException($"Пользователь с таким Email уже есть{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            try
            {
                password = EncryptionPassword(password);

                User newUser = new User { FirstName = firstName, LastName = lastName, Patronymic = patronymic, Email = email, Password = password, Position = position, Role = role, UserPhoto = userPhoto };

                var result = userDao.AddUser(newUser);
                LogUser($"Добавлен новый пользователь {newUser}", new EventArgs());
                return result;
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
        }

        public void DeleteUser(string id)
        {
            if (!int.TryParse(id, out int idUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            User user = userDao.GetUserById(idUser);

            if (user == null)
            {
                var exception = new ArgumentException($"Пользователя с таким идентификатором не существует{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            try
            {
                userDao.DeleteUser(idUser);
                LogUser($"Удалён пользователь {user}", new EventArgs());
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
        }

        public User GetUserByEmail(string email)
        {
            if (Validator.IsStringsNull(email))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            return userDao.GetUserByEmail(email);
        }

        public User GetUserById(string id)
        {
            if (!int.TryParse(id, out int idUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
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
                LogException(exception, new EventArgs());
                throw exception;
            }


            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!Validator.IsRightEmail(email))
                {
                    var exception = new ArgumentException($"Email не соответствует требованиям{Environment.NewLine}");
                    LogException(exception, new EventArgs());
                    throw exception; 
                }
            }

            User user;
            if (idUser == default)
            {
                var exception = new ArgumentException($"Идентификатор пользователя неправильный{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
            else
            {
                user = userDao.GetUserById(idUser);

                if (user == null)
                {
                    var exception = new ArgumentException($"Пользователя с таким идентификатором не существует{Environment.NewLine}");
                    loggerException.Error(exception);
                    throw exception;
                }
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
                LogUser($"Обновлён пользователь {user}", new EventArgs());
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
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

        public IEnumerable<User> GetUsersBySubject(string id)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                var exception = new ArgumentException($"Идентификатор предмета должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (subjectDao.GetSubjectById(idSubject) == null)
            {
                var exception = new ArgumentException($"Предмета с таким идентификатором не существует{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            return userDao.GetUsersBySubject(idSubject);
        }

        public void LoggerException(object sender, EventArgs e)
        {
            loggerException.Error(sender.ToString());
        }

        public void LoggerUser(object sender, EventArgs e)
        {
            loggerUser.Info(sender.ToString());
        }

        public bool Authentication(string email, string password)
        {
            var user = GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }

            string passwordOfStranger = EncryptionPassword(password);

            if (user.Password == passwordOfStranger)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
