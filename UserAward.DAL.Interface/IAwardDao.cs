using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.DAL.Interface
{
    public interface IAwardDao
    {
        int AddAward(Award award);
        int DeleteAward(int id);
        IEnumerable<Award> GetAwards();
        Award GetAwardById(int id);
        IEnumerable<Award> GetAwardByLetter(char letter);
        IEnumerable<Award> GetAwardByWord(string word);
        IEnumerable<Award> GetAwardByTitle(string title);
        int UpdateAward(int id, string title, string description);
    }
}
