using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Memory.DAO
{
    public class AwardDaoMemory : IAwardDao
    {
        private static List<Award> awards;

        public static List<Award> Awards { get => awards; private set => awards = value; }

        static AwardDaoMemory()
        {
            Awards = new List<Award>();
        }

        public int AddAward(Award award)
        {
            Awards.Add(award);
            return 1;
        }

        public int DeleteAward(int id)
        {
            var award = Awards.Where(a => a.IdAward == id).FirstOrDefault();
            Awards.Remove(award);
            return 1;
        }

        public Award GetAwardById(int id)
        {
            return Awards.Where(a => a.IdAward == id).FirstOrDefault();
        }

        public IEnumerable<Award> GetAwardByLetter(char letter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByWord(string word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwards()
        {
            return Awards;
        }

        public int UpdateAward(int id, Award award)
        {
            throw new NotImplementedException();
        }
    }
}
