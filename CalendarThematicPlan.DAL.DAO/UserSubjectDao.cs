using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CalendarThematicPlan.DAL.DAO
{
    public class UserSubjectDao : IUserSubjectDao
    {
        private readonly string connectionString;

        public UserSubjectDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CTP"].ConnectionString;
        }

        public int? AddUserSubject(UserSubject userSubject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "AddUserSubject";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id_subject",
                        Value = userSubject.IdSubject,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = userSubject.IdUser,
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

        public void DeleteUserSubject(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "DeleteUserSubject";
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

        public UserSubject GetUserSubjectById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetUserSubjectById";
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
                        return new UserSubject
                        {
                            Id = id,
                            IdSubject = (int)reader["Id_subject"],
                            IdUser = (int)reader["Id_user"]
                        };
                    }
                }
            }
            return null;
        }

        public IEnumerable<UserSubject> GetUserSubjects()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetUserSubjects";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new UserSubject
                        {
                            Id = (int?)reader["id"],
                            IdSubject = (int)reader["Id_subject"],
                            IdUser = (int)reader["Id_user"]
                        };
                    }
                }
            }
        }

        public void UpdateUserSubject(UserSubject userSubject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "UpdateUserSubject";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = userSubject.Id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_subject",
                        Value = userSubject.IdSubject,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = userSubject.IdUser,
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
