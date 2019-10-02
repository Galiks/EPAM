using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CalendarThematicPlan.DAL.DAO
{
    public class ScheduleDao : IScheduleDao
    {
        private readonly string connectionString;

        public ScheduleDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CTP"].ConnectionString;
        }

        public int? AddSchedule(Schedule schedule)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "AddSchedule";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Date",
                        Value = schedule.Date,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Room",
                        Value = schedule.Room,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_subject",
                        Value = schedule.IdSubject,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_grade",
                        Value = schedule.IdGrade,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = schedule.IdUser,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    }
                });

                var id = new SqlParameter
                {
                    ParameterName = "@Id_output",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(id);

                connection.Open();

                command.ExecuteNonQuery();

                return (int?)id.Value;
            }

        }

        public void DeleteSchedule(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "DeleteSchedule";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public Schedule GetScheduleById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetScheduleById";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Schedule
                        {
                            Id = id,
                            Date = (DateTime)reader["Date"],
                            Room = (string)reader["Room"],
                            IdSubject = (int)reader["Id_subject"],
                            IdGrade = (int)reader["Id_grade"],
                            IdUser = (int)reader["Id_user"]
                        };
                    }
                }
            }

            return null;
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetSchedules";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Schedule
                        {
                            Id = (int?)reader["id"],
                            Date = (DateTime)reader["Date"],
                            Room = (string)reader["Room"],
                            IdSubject = (int)reader["Id_subject"],
                            IdGrade = (int)reader["Id_grade"],
                            IdUser = (int)reader["Id_user"]
                        };
                    }
                }
            }
        }

        public void UpdateSchedule(Schedule schedule)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "UpdateSchedule";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = schedule.Id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Date",
                        Value = schedule.Date,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Room",
                        Value = schedule.Room,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_subject",
                        Value = schedule.IdSubject,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_grade",
                        Value = schedule.IdGrade,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = schedule.IdUser,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
