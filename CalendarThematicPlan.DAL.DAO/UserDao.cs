using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CalendarThematicPlan.DAL.DAO
{
    public class UserDao : IUserDao
    {
        private readonly string connectionString;

        public UserDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CTP"].ConnectionString;
        }

        public int? AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@FirstName",
                        Value = user.FirstName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@LastName",
                        Value = user.LastName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Patronymic",
                        Value = user.Patronymic,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = user.Email,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = user.Password,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Role",
                        Value = user.Role,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Position",
                        Value = user.Position,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@UserPhoto",
                        Value = user.UserPhoto,
                        SqlDbType = SqlDbType.VarBinary,
                        Direction = ParameterDirection.Input
                    },
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

        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "DeleteUser";
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

        public User GetUserByEmail(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetUserByEmail";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = email,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new User
                        {
                            Id = (int?)reader["id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Patronymic = (string)reader["Patronymic"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            Position = (string)reader["Position"],
                            UserPhoto = (byte[])reader["UserPhoto"]
                        };
                    }
                }
            }

            return null;
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetUserById";
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
                        return new User
                        {
                            Id = id,
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Patronymic = (string)reader["Patronymic"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            Position = (string)reader["Position"],
                            UserPhoto = (byte[])reader["UserPhoto"]
                        };
                    }
                }
            }
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetUsers";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            Id = (int?)reader["id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Patronymic = (string)reader["Patronymic"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            Position = (string)reader["Position"],
                            UserPhoto = (byte[])reader["UserPhoto"]
                        };
                    }
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = user.Id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@FirstName",
                        Value = user.FirstName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@LastName",
                        Value = user.LastName,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Patronymic",
                        Value = user.Patronymic,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = user.Email,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = user.Password,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Role",
                        Value = user.Role,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Position",
                        Value = user.Position,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@UserPhoto",
                        Value = user.UserPhoto,
                        SqlDbType = SqlDbType.VarBinary,
                        Direction = ParameterDirection.Input
                    },
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
