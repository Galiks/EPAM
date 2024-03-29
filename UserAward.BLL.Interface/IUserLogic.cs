﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.BLL.Interface
{
    public interface IUserLogic
    {
        int? AddUser(string name, string birthday, byte[] userPhoto);
        bool DeleteUser(string id);
        User GetUserById<T>(T id);
        IEnumerable<User> GetUserByName(string name);
        IEnumerable<User> GetUserByLetter(string letter);
        IEnumerable<User> GetUserByWord(string word);
        IEnumerable<User> GetUsers();
        bool UpdateUser(string id, string name, string birthday, byte[] userPhoto);
        int SetAge(DateTime birthday);
        bool Rewarding(string idUser, string idAward);
        IEnumerable<Award> GetAwardFromUserAward(string id);
    }
}
