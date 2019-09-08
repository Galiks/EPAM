using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.BLL.Interface
{
    public interface IAwardLogic
    {
        bool AddAward(string title, string description);
        bool UpdateAward(string id, string title, string description);
        bool DeleteAward(string id);
        Award GetAwardById(string id);
        IEnumerable<Award> GetAwardByLetter(string letter);
        IEnumerable<Award> GetAwardByWord(string word);
        IEnumerable<Award> GetAwardByTitle(string title);
        IEnumerable<Award> GetAwards();
    }
}
