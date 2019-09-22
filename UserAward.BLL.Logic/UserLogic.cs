using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UserAward.BLL.Interface;
using UserAward.DAL.Interface;

namespace UserAward.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        private readonly IAwardDao _awardDao;

        public UserLogic(IUserDao userDao, IAwardDao awardDao)
        {
            _userDao = userDao;
            _awardDao = awardDao;
        }

        public int? AddUser(string name, string birthday, byte[] userPhoto)
        {
            if (Validation.Validation.IsEmptyStrings(name, birthday))
            {
                throw new ArgumentNullException(nameof(name), "Parameters must be not null");
            }

            if (DateTime.TryParse(birthday, out DateTime rightBirthday))
            {

                int age = SetAge(rightBirthday);

                if (!Validation.Validation.IsRightAge(age))
                {
                    throw new ArgumentException(nameof(birthday), "Incorrect date of birthday");
                }

                var newUser = new User { Name = name, Birthday = rightBirthday, Age = SetAge(rightBirthday), UserPhoto = userPhoto };

                return _userDao.AddUser(newUser);

            }
            else
            {
                throw new ArgumentException(nameof(birthday), "Incorrect date of birthday");
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return _userDao.GetUsers().ToList();
        }

        private int? SetIdUser()
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

        public bool DeleteUser(string id)
        {
            if (int.TryParse(id, out int userId))
            {
                if (GetUserById(id) != null)
                {
                    _userDao.DeleteUser(userId);

                    return true;
                }
                else
                {
                    throw new NullReferenceException("This user does not exists");
                }
            }
            else
            {
                throw new ArgumentException($"Incorrect ID");
            }
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return _userDao.GetUserByName(name).ToList();
            }

            throw new ArgumentNullException($"Name is null");
        }

        public IEnumerable<User> GetUserByLetter(string letter)
        {
            if (char.TryParse(letter, out char userLetter))
            {
                if (char.IsLetter(userLetter))
                {
                    return _userDao.GetUserByLetter(userLetter).ToList();
                }
            }

            throw new ArgumentException($"Your letter is not letter");
        }

        public IEnumerable<User> GetUserByWord(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return _userDao.GetUserByWord(word).ToList();
            }

            throw new ArgumentNullException($"Word is null");
        }

        public bool UpdateUser(string id, string name, string birthday, byte[] userPhoto)
        {
            if (!int.TryParse(id, out int userId))
            {
                throw new ArgumentException($"Incorrect user's id");
            }

            if (!DateTime.TryParse(birthday, out DateTime realBirthday) && !string.IsNullOrWhiteSpace(birthday))
            {
                throw new ArgumentException("Incorrect created time");
            }

            User user = GetUserById(userId);

            user.Name = string.IsNullOrWhiteSpace(name) ? user.Name : name;
            user.Birthday = realBirthday == default(DateTime) ? user.Birthday : realBirthday;
            user.Age = realBirthday == default(DateTime) ? user.Age : SetAge(realBirthday);
            user.UserPhoto = userPhoto == null ? user.UserPhoto : userPhoto;

            try
            {
                _userDao.UpdateUser(userId, user);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            //if (DateTime.TryParse(birthday, out DateTime dateTime) && (int.TryParse(id, out int userId)))
            //{
            //    if (GetUserById(userId) != null)
            //    {
            //        User user = new User { Name = name, Birthday = dateTime, Age = SetAge(dateTime), UserPhoto = userPhoto };

            //        _userDao.UpdateUser(userId, user);

            //        return true;
            //    }
            //    else
            //    {
            //        //Console.WriteLine($"DB has no information");
            //        throw new NullReferenceException($"DB has no information");
            //        //return false;
            //    }
            //}
            //else
            //{
            //    throw new ArgumentException($"Incorrect id or birthday");
            //    //Console.WriteLine($"Incorrect id or birthday");
            //    //return false;
            //}
        }

        public bool Rewarding(string idUser, string idAward)
        {

            if (int.TryParse(idUser, out int userId) && int.TryParse(idAward, out int awardId))
            {
                var user = GetUserById(userId);

                if ((user != null))
                {
                    var awardsByUser = _awardDao.GetAwardFromUserAward(userId); //_userDao.GetAwardFromUserAward(userId);
                    if (awardsByUser.Any(award => award.IdAward == awardId))
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

        public IEnumerable<Award> GetAwardFromUserAward(string id)
        {
            if (int.TryParse(id, out int userId))
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    List<Award> awardsByUser = _awardDao.GetAwardFromUserAward(userId).ToList(); //_userDao.GetAwardFromUserAward(userId).ToList();
                    if (awardsByUser.Count == 0)
                    {
                        throw new NullReferenceException($"DB has no information");
                        //Console.WriteLine($"DB has no information");
                    }
                    else
                    {
                        return awardsByUser;
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
            if (int.TryParse(id.ToString(), out int userId))
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
