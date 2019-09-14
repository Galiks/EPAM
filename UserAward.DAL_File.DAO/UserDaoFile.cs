using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using UserAward.DAL.Interface;

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
            try
            {
                var allLines = File.ReadAllLines(pathToUserFile);
                for (int i = 0; i < allLines.Length; i++)
                {
                    var line = allLines[i];

                    if (line.Length > 0)
                    {
                        User user = DeserializeUser(line);
                        if (user.IdUser == id)
                        {
                            allLines[i] = string.Empty;

                            break;
                        }
                    }
                }
                File.WriteAllLines(pathToUserFile, allLines);

                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Award> GetAwardFromUserAward(int idUser)
        {
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
                                yield return awardDao.GetAwardById(realIdUser);
                            }
                        }
                    }
                }
            }
        }

        public User GetUserById(int id)
        {
            var user = GetUsers().Where(u => u.IdUser == id).FirstOrDefault();
            return user;
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

        public int UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
