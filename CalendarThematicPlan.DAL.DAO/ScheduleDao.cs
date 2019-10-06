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
                        ParameterName = "@ActualDate",
                        Value = schedule.ActualDate,
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
                    },

                    new SqlParameter
                    {
                        ParameterName = "@LessonTopic",
                        Value = schedule.LessonTopic,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Comment",
                        Value = schedule.Comment,
                        SqlDbType = SqlDbType.NVarChar,
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

        public IEnumerable<ReadableSchedule> GetReadableSchedules()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetReadableSchedules";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new ReadableSchedule
                        {
                            Date = (DateTime)reader["Date"],
                            ActualDate = (DateTime)reader["Actual date"],
                            Room = (string)reader["Room"],
                            GradeNumber = (int)reader["Grade number"],
                            GradeLetter = (string)reader["Grade letter"],
                            SubjectName = (string)reader["Subject name"],
                            TeacherFirstName = (string)reader["Teacher last name"],
                            TeacherLastName = (string)reader["Teacher first name"],
                            TecaherPatronymic = (string)reader["Teacher patronymic"],
                            LessonTopic = (string)reader["Lesson Topic"],
                            Comment = (string)reader["Comment"]
                        };
                    }
                }
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
                            ActualDate = (DateTime)reader["ActualDate"],
                            Room = (string)reader["Room"],
                            IdSubject = (int)reader["Id_subject"],
                            IdGrade = (int)reader["Id_grade"],
                            IdUser = (int)reader["Id_user"],
                            LessonTopic = (string)reader["LessonTopic"],
                            Comment = (string)reader["Comment"]
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
                            ActualDate = (DateTime)reader["ActualDate"],
                            Room = (string)reader["Room"],
                            IdSubject = (int)reader["Id_subject"],
                            IdGrade = (int)reader["Id_grade"],
                            IdUser = (int)reader["Id_user"],
                            LessonTopic = (string)reader["LessonTopic"],
                            Comment = (string)reader["Comment"]
                        };
                    }
                }
            }
        }

        public IEnumerable<ReadableSchedule> GetSchedulesByParameters(string firstName, string lastName, string patronymic, string subjectName, int gradeNumber, string gradeLetter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetSchedulesByParameters";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@UserFirstName",
                        Value = firstName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@UserLastName",
                        Value = lastName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@UserPatronymic",
                        Value = patronymic,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@SubjectName",
                        Value = subjectName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@GradeNumber",
                        Value = gradeNumber,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@GradeLetter",
                        Value = gradeLetter,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new ReadableSchedule
                        {
                            Date = (DateTime)reader["Date"],
                            ActualDate = (DateTime)reader["Actual date"],
                            Room = (string)reader["Room"],
                            GradeNumber = (int)reader["Grade number"],
                            GradeLetter = (string)reader["Grade letter"],
                            SubjectName = (string)reader["Subject name"],
                            TeacherFirstName = (string)reader["Teacher last name"],
                            TeacherLastName = (string)reader["Teacher first name"],
                            TecaherPatronymic = (string)reader["Teacher patronymic"],
                            LessonTopic = (string)reader["Lesson Topic"],
                            Comment = (string)reader["Comment"]
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
                        ParameterName = "@ActualDate",
                        Value = schedule.ActualDate,
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
                    },

                    new SqlParameter
                    {
                        ParameterName = "@LessonTopic",
                        Value = schedule.LessonTopic,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Comment",
                        Value = schedule.Comment,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
