using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface ISubjectLogic
    {
        int? AddSubject(string name, string hours);
        Subject GetSubjectById(string id);
        IEnumerable<Subject> GetSubjects();
        void UpdateSubject(string id, string name, string hours);
        void DeleteSubject(string id);
        IEnumerable<Subject> GetSubjectsByWord(string word);
    }
}
