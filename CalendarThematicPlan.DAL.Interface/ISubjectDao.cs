using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface ISubjectDao
    {
        int? AddSubject(Subject grade);
        Subject GetSubjectById(int id);
        void UpdateSubject(Subject grade);
        void DeleteSubject(int id);
    }
}
