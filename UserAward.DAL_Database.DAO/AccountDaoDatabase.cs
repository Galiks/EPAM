using Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Database.DAO
{
    public class AccountDaoDatabase : IAccountDao
    {
        private readonly string _connectionString;

        public AccountDaoDatabase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Olympics"].ConnectionString;
        }
        public int? AddAccount(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddAccount";

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = account.Email,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = account.Password,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Role",
                        Value = account.Role,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@CreatedAt",
                        Value = account.CreatedAt,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@LoggedInto",
                        Value = account.LoggedInto,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@PasswordLifetime",
                        Value = account.CreatedAt,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@PasswordLifetime",
                        Value = account.CreatedAt,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@IsBlocked",
                        Value = account.IsBlocked,
                        SqlDbType = SqlDbType.Bit,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = account.IdUser,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },
                });

                var id = new SqlParameter
                {
                    ParameterName = "@Id_account",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                };

                connection.Open();

                return (int)id.Value;
            }
        }


        public void DeleteAccount(int idUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteAccount";

                var id = new SqlParameter("@Id_user", SqlDbType.Int)
                {
                    Value = idUser
                };

                command.Parameters.Add(id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public Account GetAccountByEmail(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAccountByEmail";

                var emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar)
                {
                    Value = email
                };

                command.Parameters.Add(emailParameter);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Account
                        {
                            IdAccount = (int)reader["id_account"],
                            IdUser = (int)reader["id_user"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            CreatedAt = (DateTime?)reader["CreatedAt"],
                            LoggedInto = (DateTime?)reader["LoggedInto"],
                            PasswordLifetime = (DateTime?)reader["PasswordLifetime"],
                            IsBlocked = (bool)reader["IsBlocked"]
                        };
                    }
                }
            }

            return null;
        }

        public Account GetAccountByIdUser(int idUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAccountByIdUser";

                var idUserParameter = new SqlParameter("@Id_user", SqlDbType.Int)
                {
                    Value = idUser
                };

                command.Parameters.Add(idUserParameter);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Account
                        {
                            IdAccount = (int)reader["id_account"],
                            IdUser = (int)reader["id_user"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            CreatedAt = (DateTime?)reader["CreatedAt"],
                            LoggedInto = (DateTime?)reader["LoggedInto"],
                            PasswordLifetime = (DateTime?)reader["PasswordLifetime"],
                            IsBlocked = (bool)reader["IsBlocked"]
                        };
                    }
                }
            }

            return null;
        }

        public void UpdateAccount(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateAccount";

                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = account.Email,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = account.Password,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Role",
                        Value = account.Role,
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@IsBlocked",
                        Value = account.IsBlocked,
                        SqlDbType = SqlDbType.Bit,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = account.IdUser,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    }
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void UpdateLoggerIntoAccount(int idUser, DateTime loggedInto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateLoggedIntoAccount";

                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = idUser,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@LoggedInto",
                        Value = loggedInto,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void UpdatePasswordLifetimeAccount(int idUser, DateTime passwordLifetime)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdatePasswordLifetimeAccount";

                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id_user",
                        Value = idUser,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    },

                    new SqlParameter
                    {
                        ParameterName = "@PasswordLifetime",
                        Value = passwordLifetime,
                        SqlDbType = SqlDbType.DateTime,
                        Direction = ParameterDirection.Input
                    },
                });

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
