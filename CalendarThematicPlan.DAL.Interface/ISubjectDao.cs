using CalendarThematicPlan.Entity;
using System.Collections.Generic;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface ISubjectDao
    {
        int? AddSubject(Subject subject);
        Subject GetSubjectById(int id);
        IEnumerable<Subject> GetSubjects();
        void UpdateSubject(Subject subject);
        void DeleteSubject(int id);
        IEnumerable<Subject> GetSubjectsByWord(string word);
        IEnumerable<Subject> GetSubjectsByUser(int id);
    }
}
