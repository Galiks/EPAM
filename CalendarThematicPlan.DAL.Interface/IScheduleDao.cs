﻿using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IScheduleDao
    {
        int? AddSchedule(Schedule schedule);
        Schedule GetScheduleById(int id);
        IEnumerable<Schedule> GetSchedules();
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
    }
}
