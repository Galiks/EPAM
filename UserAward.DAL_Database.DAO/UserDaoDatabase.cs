using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Database.DAO
{
    public class UserDaoDatabase : IUserDao
    {
        private readonly string _connectionString;

        public UserDaoDatabase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["userAward"].ConnectionString;
        }

        public int AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddUser";

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = user.Name
                };

                command.Parameters.Add(name);

                var birthday = new SqlParameter("@Birthday", SqlDbType.DateTime)
                {
                    Value = user.Birthday
                };

                command.Parameters.Add(birthday);

                var age = new SqlParameter("@Age", SqlDbType.Int)
                {
                    Value = user.Age
                };

                command.Parameters.Add(age);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
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

                var name = new SqlParameter("@NAME", SqlDbType.VarChar)
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

                var word = new SqlParameter("@WORD", SqlDbType.VarChar)
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
                                        FROM [Olympics2].[dbo].[User]";

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

        public int UpdateUser(int wantedId, string wantedName, DateTime wantedBirthday, int wantedAge)
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

                command.Parameters.Add(id);

                var name = new SqlParameter("@NAME", SqlDbType.VarChar)
                {
                    Value = wantedName
                };

                command.Parameters.Add(name);

                var birthday = new SqlParameter("@BIRTHDAY", SqlDbType.DateTime)
                {
                    Value = wantedBirthday
                };

                command.Parameters.Add(birthday);

                var age = new SqlParameter("@AGE", SqlDbType.Int)
                {
                    Value = wantedAge
                };

                command.Parameters.Add(age);

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public IDictionary<int, string> GetAwardFromUserAward(int idUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                Dictionary<int, string> result = new Dictionary<int, string>();

                result.Clear();

                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAwardFromUser_Award";

                var id = new SqlParameter("@ID_USER", SqlDbType.Int)
                {
                    Value = idUser
                };

                command.Parameters.Add(id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((int)reader["id_award"], (string)reader["Title"]);
                    }
                }

                return result;
            }
        }
    }
}
