using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Memory.DAO
{
    public class UserDaoMemory : IUserDao
    {
        private static List<User> users;
        //first parameter - User's ID, second - Award's ID
        private static Dictionary<int?, int?> usersAwards;
        private readonly IAwardDao awardDao;

        public static List<User> Users { get => users; private set => users = value; }
        public static Dictionary<int?, int?> UsersAwards { get => usersAwards; private set => usersAwards = value; }

        static UserDaoMemory()
        {
            Users = new List<User>();
            UsersAwards = new Dictionary<int?, int?>();
        }

        public UserDaoMemory(IAwardDao awardDao)
        {
            this.awardDao = awardDao;
            //Users = new List<User>();
            //UsersAwards = new Dictionary<int?, int?>();
        }

        public int AddUser(User user)
        {
            try
            {
                Users.Add(user);
                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteUser(int id)
        {
            var user = Users.Where(u => u.IdUser == id).FirstOrDefault();
            Users.Remove(user);
            return 1;
        }

        public IEnumerable<Award> GetAwardFromUserAward(int idUser)
        {
            foreach (var item in UsersAwards)
            {
                if (item.Key == idUser)
                {
                    yield return awardDao.GetAwardById(idUser);
                }
            }
        }

        public User GetUserById(int id)
        {
            return Users.Where(u => u.IdUser == id).FirstOrDefault();
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
            return Users;
        }

        public int Reawrding(User user, int idAward)
        {
            UsersAwards.Add(user.IdUser, idAward);
            return 1;
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
