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
            else
            {
                throw new ArgumentNullException(nameof(name), "This parameter must be not null");
            }
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
                throw new NullReferenceException("This user does not exists");
            }
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return _userDao.GetUserByName(name).ToList();
            }

            throw new ArgumentNullException($"Name is null");
        }

        public IEnumerable<User> GetUserByLetter(string letter)
        {
            if (Char.TryParse(letter, out char userLetter))
            {
                if (Char.IsLetter(userLetter))
                {
                    return _userDao.GetUserByLetter(userLetter).ToList();
                }
            }

            throw new ArgumentException($"Your letter is not letter");
        }

        public IEnumerable<User> GetUserByWord(string word)
        {
            if (!String.IsNullOrEmpty(word))
            {
                return _userDao.GetUserByWord(word).ToList();
            }

            throw new ArgumentNullException($"Word is null");
        }

        public bool UpdateUser(string id, string name, string birthday)
        {

            if (DateTime.TryParse(birthday, out DateTime dateTime) && (Int32.TryParse(id, out int userId)))
            {
                if (GetUserById(userId) != null)
                {
                    _userDao.UpdateUser(userId, name, dateTime, SetAge(dateTime));

                    return true;
                }
                else
                {
                    //Console.WriteLine($"DB has no information");
                    throw new NullReferenceException($"DB has no information");
                    //return false;
                }
            }
            else
            {
                throw new ArgumentException($"Incorrect id or birthday");
                //Console.WriteLine($"Incorrect id or birthday");
                //return false;
            }
        }

        public bool Rewarding(string idUser, string idAward)
        {

            if (Int32.TryParse(idUser, out int userId) && Int32.TryParse(idAward, out int awardId))
            {
                var user = GetUserById(userId);

                if ((user != null))
                {
                    if (_userDao.GetAwardFromUserAward(userId).ContainsKey(awardId))
                    {
                        throw new Exception($"This user already has award like this");
                        //Console.WriteLine($"This user already has award like this");
                        //return false;
                    }
                    else
                    {
                        _userDao.Reawrding(user, awardId);

                        return true;
                    }
                }
                else
                {
                    throw new NullReferenceException($"DB doesn't know this user");
                    //Console.WriteLine($"DB doesn't know this user");
                    //return false;
                }
            }
            else
            {
                throw new ArgumentException($"Incorrect User's ID or Award's ID");
                //Console.WriteLine($"Incorrect User's ID or Award's ID");
                //return false;
            }
        }

        public void GetAwardFromUserAward(string id)
        {
            if (Int32.TryParse(id, out int userId))
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    if (_userDao.GetAwardFromUserAward(userId).ToList().Count == 0)
                    {
                        throw new NullReferenceException($"DB has no information");
                        //Console.WriteLine($"DB has no information");
                    }
                    else
                    {
                        Console.WriteLine($"User {user.Name} have awards: ");
                        foreach (var item in _userDao.GetAwardFromUserAward(userId).ToList())
                        {
                            if (item.Value.Length > 0)
                            {
                                Console.WriteLine($"{item.Key} : {item.Value}{Environment.NewLine}");
                            }
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException($"DB has no information about this user");
                    //Console.WriteLine($"DB has no information about this user");
                }
            }
            else
            {
                throw new ArgumentException($"Incorrect ID");
                //Console.WriteLine($"Incorrect ID");
            }
        }

        public User GetUserById<T>(T id)
        {
            if (Int32.TryParse(id.ToString(), out int userId))
            {
                var result = _userDao.GetUserById((userId));
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new NullReferenceException($"DB has no information about this user");
                    //Console.WriteLine($"Incorrect ID");
                    //return null;
                }
            }
            else
            {
                throw new ArgumentException($"Incorrect ID");
            }
        }
    }
}