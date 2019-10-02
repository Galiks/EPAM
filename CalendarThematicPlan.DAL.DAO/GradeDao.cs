using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CalendarThematicPlan.DAL.DAO
{
    public class GradeDao : IGradeDao
    {
        private readonly string connectionString;

        public GradeDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CTP"].ConnectionString;
        }

        public int? AddGrade(Grade grade)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddGrade";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Number",
                        Value = grade.Number,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Letter",
                        Value = grade.Letter,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@KidsInClass",
                        Value = grade.KidsInClass,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },
                });

                var id = new SqlParameter
                {
                    ParameterName = "@Id_output",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                };

                command.Parameters.Add(id);

                connection.Open();

                command.ExecuteNonQuery();

                return (int?)id.Value;
            }
        }

        public void DeleteGrade(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteGrade";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public Grade GetGradeById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetGradeById";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                });

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Grade
                        {
                            Id = id,
                            Number = (int)reader["Number"],
                            Letter = (string)reader["Letter"],
                            KidsInClass = (int)reader["KidsInClass"]
                        };
                    }
                }
            }

            return null;
        }

        public IEnumerable<Grade> GetGrades()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetGrades";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Grade
                        {
                            Id = (int?)reader["id"],
                            Number = (int)reader["Number"],
                            Letter = (string)reader["Letter"],
                            KidsInClass = (int)reader["KidsInClass"]
                        };
                    }
                }
            }
        }

        public void UpdateGrade(Grade grade)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UpdateGrade";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = grade.Id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Number",
                        Value = grade.Number,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Letter",
                        Value = grade.Letter,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@KidsInClass",
                        Value = grade.KidsInClass,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
