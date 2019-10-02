using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Logic
{
    public class GradeLogic : IGradeLogic
    {
        public int? AddGrade(string number, string letter, string kidsInClass)
        {
            throw new NotImplementedException();
        }

        public void DeleteGrade(string id)
        {
            throw new NotImplementedException();
        }

        public Grade GetGradeById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grade> GetGrades()
        {
            throw new NotImplementedException();
        }

        public void UpdateGrade(string id, string number, string letter, string kidsInClass)
        {
            throw new NotImplementedException();
        }
    }
}
