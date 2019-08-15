using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Entity;
using UserAward.DAL_Interface.Interface;

namespace UserAward.DAL_File.DAO
{
    public class UserDaoFile : IUserDao
    {
        private readonly string pathToUserFile;
        private readonly string pathToUserAwardsFile;

        private readonly IAwardDao awardDao;

        public UserDaoFile(IAwardDao awardDao)
        {
            this.awardDao = awardDao;

            pathToUserAwardsFile = ConfigurationManager.ConnectionStrings["userAwardsFile"].ConnectionString;
            pathToUserFile = ConfigurationManager.ConnectionStrings["userFile"].ConnectionString;
            using (var file = File.Open(pathToUserFile, FileMode.OpenOrCreate))
            {
                file.Close();
            }

            using (var file = File.Open(pathToUserAwardsFile, FileMode.OpenOrCreate))
            {
                file.Close();
            }
        }

        public int AddUser(User user)
        {
            using (StreamWriter writer = File.AppendText(pathToUserFile))
            {
                try
                {
                    writer.WriteLine(user);
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, string> GetAwardFromUserAward(int idUser)
        {
            string pathToAwardsFile = ConfigurationManager.ConnectionStrings["awardFile"].ConnectionString;
            Dictionary<int, string> result = new Dictionary<int, string>();

            using (StreamReader reader = new StreamReader(pathToUserAwardsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] informations = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        if (int.TryParse(informations[0], out int realIdUser) && int.TryParse(informations[1], out int realIdAward))
                        {
                            if (realIdUser == idUser)
                            {
                                result.Add(realIdAward, "");
                            }
                        }
                    }
                }
            }

            var awards = awardDao.GetAwards();

            foreach (var item in awards)
            {
                if (result.ContainsKey(item.IdAward))
                {
                    result[item.IdAward] = item.Title;
                }
            }

            return result;
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserByLetter(char letter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserByWord(string word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            using (StreamReader reader = new StreamReader(pathToUserFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        User user = DeserializeUser(line);
                        if (user != null)
                        {
                            yield return user;
                        }
                    }
                }
            }
        }

        private User DeserializeUser(string line)
        {
            string[] informations = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (int.TryParse(informations[0], out int ID) && DateTime.TryParse(informations[2], out DateTime birthday) && int.TryParse(informations[3], out int age))
            {
                return new User { IdUser = ID, Name = informations[1], Birthday = birthday, Age = age };
            }
            else
            {
                return null;
            }
        }

        public int Reawrding(User user, int idAward)
        {
            using (StreamWriter writer = File.AppendText(pathToUserAwardsFile))
            {
                try
                {
                    writer.WriteLine(new UsersAwards { UserId = user.IdUser, AwardId = idAward });
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int UpdateUser(int id, string name, DateTime birthday, int age)
        {
            throw new NotImplementedException();
        }
    }
}
