using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Database.DAO
{
    public class UserDaoDatabase : IUserDao
    {
        private readonly string _connectionString;

        public UserDaoDatabase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Olympics"].ConnectionString;
        }

        public int? AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddUser";

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = user.Name,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Birthday",
                        Value = user.Birthday,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Age",
                        Value = user.Age,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@UserPhoto",
                        Value = user.UserPhoto ?? System.Data.SqlTypes.SqlBinary.Null,
                        SqlDbType = SqlDbType.VarBinary,
                        Direction = ParameterDirection.Input
                    },


                });

                var id = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                };

                command.Parameters.Add(id);
                
                connection.Open();

                command.ExecuteNonQuery();

                return (int?)id.Value;
            }
        }

        public int DeleteUser(int wantedId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteUser";

                var id = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = wantedId
                };

                command.Parameters.Add(id);

                connection.Open();

                return (int)command.ExecuteNonQuery();
            }
        }

        public User GetUserById(int wantedId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserByID";

                var id = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = wantedId
                };

                command.Parameters.Add(id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new User
                        {
                            IdUser = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Birthday = (DateTime)reader["Birthday"],
                            Age = (int)reader["Age"],
                            UserPhoto = reader["UserPhoto"] is System.DBNull ? null : (byte[])reader["UserPhoto"],
                        };
                    }
                }

            }

            return null;
        }

        public IEnumerable<User> GetUserByLetter(char wantedLetter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "GetUserByLetter";

                var letter = new SqlParameter("@LETTER", SqlDbType.Char)
                {
                    Value = wantedLetter
                };

                command.Parameters.Add(letter);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            IdUser = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Birthday = (DateTime)reader["Birthday"],
                            Age = (int)reader["Age"],
                            UserPhoto = reader["UserPhoto"] is System.DBNull ? null : (byte[])reader["UserPhoto"],
                        };
                    }
                }

            }
        }

        public IEnumerable<User> GetUserByName(string wantedName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "GetUserByName";

                var name = new SqlParameter("@NAME", SqlDbType.NVarChar)
                {
                    Value = wantedName
                };

                command.Parameters.Add(name);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            IdUser = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Birthday = (DateTime)reader["Birthday"],
                            Age = (int)reader["Age"],
                            UserPhoto = reader["UserPhoto"] is System.DBNull ? null : (byte[])reader["UserPhoto"],
                        };
                    }
                }

            }
        }

        public IEnumerable<User> GetUserByWord(string wantedWord)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "GetUserByWord";

                var word = new SqlParameter("@WORD", SqlDbType.NVarChar)
                {
                    Value = wantedWord
                };

                command.Parameters.Add(word);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            IdUser = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Birthday = (DateTime)reader["Birthday"],
                            Age = (int)reader["Age"],
                            UserPhoto = reader["UserPhoto"] is System.DBNull ? null : (byte[])reader["UserPhoto"],
                        };
                    }
                }

            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.Text;

                command.CommandText = @"SELECT [id_user]
                                        ,[Name]
                                        ,[Birthday]
                                        ,[Age]
                                        ,[UserPhoto]
                                        FROM [Olympics].[dbo].[User]";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            IdUser = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Birthday = (DateTime)reader["Birthday"],
                            Age = (int)reader["Age"],
                            UserPhoto = reader["UserPhoto"] is System.DBNull ? null : (byte[])reader["UserPhoto"],
                        };
                    }
                }

            }
        }

        public int Reawrding(User user, int idAward)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Rewarding";

                var idForUser = new SqlParameter("@ID_user", SqlDbType.Int)
                {
                    Value = user.IdUser
                };

                command.Parameters.Add(idForUser);

                var idForAward = new SqlParameter("@ID_award", SqlDbType.Int)
                {
                    Value = idAward
                };

                command.Parameters.Add(idForAward);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();

            }
        }

        public int UpdateUser(int wantedId, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateUser";

                var id = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = wantedId
                };

                var name = new SqlParameter("@NAME", SqlDbType.NVarChar)
                {
                    Value = user.Name
                };

                var birthday = new SqlParameter("@BIRTHDAY", SqlDbType.DateTime)
                {
                    Value = user.Birthday
                };

                var age = new SqlParameter("@AGE", SqlDbType.Int)
                {
                    Value = user.Age
                };

                var userPhoto = new SqlParameter("@UserPhoto", SqlDbType.VarBinary)
                {
                    Value = user.UserPhoto ?? System.Data.SqlTypes.SqlBinary.Null
                };
                
                command.Parameters.AddRange(new[] { id, name, age, birthday, userPhoto });

                var idUpdate = new SqlParameter
                {
                    ParameterName = "@Id_update",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                };

                connection.Open();

                return (int)idUpdate.Value;
            }
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    var command = connection.CreateCommand();

            //    command.CommandType = CommandType.StoredProcedure;

            //    command.CommandText = "GetUserByEmail";

            //    var parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar)
            //    {
            //        Value = email
            //    };

            //    command.Parameters.Add(parameterEmail);

            //    connection.Open();

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            return new User
            //            {
            //                IdUser = (int)reader["id_user"],
            //                Name = (string)reader["Name"],
            //                Birthday = (DateTime)reader["Birthday"],
            //                Age = (int)reader["Age"],
            //                Email = (string)reader["Email"],
            //                Password = (string)reader["Password"],
            //                Role = (string)reader["Role"],
            //                UserPhoto = reader["UserPhoto"] is System.DBNull ? null : (byte[])reader["UserPhoto"],
            //            };
            //        }
            //    }

            //    return null;
            //}
        }
    }
}
