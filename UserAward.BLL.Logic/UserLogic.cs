using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using UserAward.DAL_Interface.Interface;

namespace UserAward.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public bool AddUser(string name, string birthday)
        {
            if (!String.IsNullOrEmpty(name))
            {
                var rightBirthday = DateTime.Parse(birthday);

                var newUser = new User { IdUser = SetIdUser(), Name = name, Birthday = rightBirthday, Age = SetAge(rightBirthday) };

                _userDao.AddUser(newUser);

                return true;
            }

            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userDao.GetUsers().ToList();
        }

        private int SetIdUser()
        {
            if (GetUsers().ToList().Count == 0)
            {
                return 1;
            }
            else
            {
                return GetUsers().ToList().Last().IdUser + 1;
            }
        }

        public int SetAge(DateTime birthday)
        {

            if (DateTime.Today.Month > birthday.Month)
            {
                return (DateTime.Today.Year - birthday.Year);
            }
            else
            {
                return (DateTime.Today.Year - birthday.Year) - 1;
            }
        }

        public bool DeleteUser(int id)
        {
            if (GetUserById(id) != null)
            {
                _userDao.DeleteUser(id);

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return _userDao.GetUserByName(name).ToList();
            }

            return null;
        }

        public IEnumerable<User> GetUserByLetter(string letter)
        {
            char userLetter;
            if (Char.TryParse(letter, out userLetter))
            {
                if (Char.IsLetter(userLetter))
                {
                    return _userDao.GetUserByLetter(userLetter).ToList();
                }
            }

            return null;
        }

        public IEnumerable<User> GetUserByWord(string word)
        {
            if (!String.IsNullOrEmpty(word))
            {
                return _userDao.GetUserByWord(word).ToList();
            }

            return null;
        }

        public bool UpdateUser(string id, string name, string birthday)
        {
            DateTime dateTime;
            int userId;

            if (DateTime.TryParse(birthday, out dateTime) && (Int32.TryParse(id, out userId)))
            {
                if (GetUserById(userId) != null)
                {
                    _userDao.UpdateUser(userId, name, dateTime, SetAge(dateTime));

                    return true;
                }
                else
                {
                    Console.WriteLine($"DB has no information");

                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Incorrect id or birthday");
                return false;
            }
        }

        public bool Rewarding(string idUser, string idAward)
        {
            int userId;
            int awardId;

            if (Int32.TryParse(idUser, out userId) && Int32.TryParse(idAward, out awardId))
            {
                var user = GetUserById(userId);

                if ((user != null))
                {
                    if (_userDao.GetAwardFromUserAward(userId).ContainsKey(awardId))
                    {
                        Console.WriteLine($"This user already has award like this");
                        return false;
                    }
                    else
                    {
                        _userDao.Reawrding(user, awardId);

                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"DB doesn't know this user");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Incorrect User's ID or Award's ID");
                return false;
            }
        }

        public void GetAwardFromUserAward(string id)
        {
            int userId;
            if (Int32.TryParse(id, out userId))
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    if (_userDao.GetAwardFromUserAward(userId).ToList().Count == 0)
                    {
                        Console.WriteLine($"DB has no information");
                    }
                    else
                    {
                        Console.WriteLine($"User {user.Name} have awards: ");
                        foreach (var item in _userDao.GetAwardFromUserAward(userId).ToList())
                        {
                            Console.WriteLine($"{item.Key} : {item.Value}{Environment.NewLine}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"DB has no information about this user");
                }
            }
            else
            {
                Console.WriteLine($"Incorrect ID");
            }
        }

        public User GetUserById<T>(T id)
        {
            int userId;
            if (Int32.TryParse(id.ToString(), out userId))
            {
                var result = _userDao.GetUserById((userId));
                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Incorrect ID");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}