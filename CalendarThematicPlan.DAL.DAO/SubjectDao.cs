using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.DAO
{
    public class SubjectDao : ISubjectDao
    {
        private readonly string connectionString;

        public SubjectDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CTP"].ConnectionString;
        }

        public int? AddSubject(Subject subject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "AddSubject";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = subject.Name,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Hours",
                        Value = subject.Hours,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    }
                });

                var id = new SqlParameter
                {
                    ParameterName = "Id_output",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(id);

                connection.Open();

                command.ExecuteNonQuery();

                return (int?)id.Value;
            }
        }

        public void DeleteSubject(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "DeleteSubject";
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

        public Subject GetSubjectById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetSubjectById";
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
                        return new Subject
                        {
                            Id = id,
                            Name = (string)reader["Name"],
                            Hours = (int)reader["Hours"]
                        };
                    }
                }
            }
            return null;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetSubjects";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Subject
                        {
                            Id = (int?)reader["id"],
                            Name = (string)reader["Name"],
                            Hours = (int)reader["Hours"]
                        };
                    }
                }
            }
        }

        public IEnumerable<Subject> GetSubjectsByWord(string word)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetSubjectsByWord";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Word",
                        Value = word,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Subject
                        {
                            Id = (int?)reader["id"],
                            Name = (string)reader["Name"],
                            Hours = (int)reader["Hours"]
                        };
                    }
                }
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "UpdateSubject";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = subject.Id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = subject.Name,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Hours",
                        Value = subject.Hours,
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
