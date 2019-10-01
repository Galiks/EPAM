using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.DAO
{
    public class ScheduleDao : IScheduleDao
    {
        private readonly string connectionString;

        public ScheduleDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CTP"].ConnectionString;
        }

        public int? AddSchedule(Schedule grade)
        {
            throw new NotImplementedException();
        }

        public void DeleteSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(Schedule grade)
        {
            throw new NotImplementedException();
        }
    }
}
