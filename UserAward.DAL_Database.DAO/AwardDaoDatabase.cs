using Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Database.DAO
{
    public class AwardDaoDatabase : IAwardDao
    {
        private readonly string _connectionString;

        public AwardDaoDatabase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Olympics"].ConnectionString;
        }

        public int AddAward(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddAward";

                var title = new SqlParameter("@TITLE", SqlDbType.NVarChar)
                {
                    Value = award.Title
                };

                command.Parameters.Add(title);

                var description = new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar)
                {
                    Value = award.Description
                };

                command.Parameters.Add(description);

                var awardImage = new SqlParameter("@AwardImage", SqlDbType.VarBinary)
                {
                    Value = award.AwardImage
                };

                command.Parameters.Add(awardImage);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int DeleteAward(int wantedId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteAward";

                var id = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = wantedId
                };

                command.Parameters.Add(id);

                connection.Open();

                return (int)command.ExecuteNonQuery();
            }
        }

        public int DeleteAwardFromAllUsers(int awardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteAwardFromAllUsers";

                var idAward = new SqlParameter("@AwardId", SqlDbType.Int)
                {
                    Value = awardId
                };

                command.Parameters.Add(idAward);

                connection.Open();

                return (int)command.ExecuteNonQuery();
            }
        }

        public int DeleteAwardFromUser(int userId, int awardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteAwardFromUser";

                var idAward = new SqlParameter("@AwardId", SqlDbType.Int)
                {
                    Value = awardId
                };

                var idUser = new SqlParameter("@UserId", SqlDbType.Int)
                {
                    Value = userId
                };

                command.Parameters.AddRange(new[] { idAward, idUser });

                connection.Open();

                return (int)command.ExecuteNonQuery();
            }
        }

        public Award GetAwardById(int wantedId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAwardByID";

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
                        return new Award
                        {
                            IdAward = (int)reader["id_award"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            AwardImage = reader["AwardImage"] is System.DBNull ? null : (byte[])reader["AwardImage"],
                        };
                    }
                }
            }

            return null;
        }

        public IEnumerable<Award> GetAwardByLetter(char wantedLetter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "GetAwardByLetter";

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
                        yield return new Award
                        {
                            IdAward = (int)reader["id_award"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            AwardImage = reader["AwardImage"] is System.DBNull ? null : (byte[])reader["AwardImage"],
                        };
                    }
                }

            }
        }

        public IEnumerable<Award> GetAwardByTitle(string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "GetAwardByTitle";

                var name = new SqlParameter("@TITLE", SqlDbType.NVarChar)
                {
                    Value = title
                };

                command.Parameters.Add(name);

                connection.Open();



                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Award
                        {
                            IdAward = (int)reader["id_award"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            AwardImage = reader["AwardImage"] is System.DBNull ? null : (byte[])reader["AwardImage"],
                        };
                    }
                }

            }
        }

        public IEnumerable<Award> GetAwardByWord(string wantedWord)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = "GetAwardByWord";

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
                        yield return new Award
                        {
                            IdAward = (int)reader["id_award"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            AwardImage = reader["AwardImage"] is System.DBNull ? null : (byte[])reader["AwardImage"],
                        };
                    }
                }

            }
        }

        public IEnumerable<Award> GetAwards()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAwards";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Award
                        {
                            IdAward = (int)reader["id_award"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            AwardImage = reader["AwardImage"] is System.DBNull ? null : (byte[])reader["AwardImage"],
                        };
                    }
                }
            }
        }

        public int UpdateAward(int wantedId, Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateAward";

                var id = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = wantedId
                };

                command.Parameters.Add(id);

                var title = new SqlParameter("@TITLE", SqlDbType.NVarChar)
                {
                    Value = award.Title
                };

                command.Parameters.Add(title);

                var description = new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar)
                {
                    Value = award.Description
                };

                command.Parameters.Add(description);

                var awardImage = new SqlParameter("@AwardImage", SqlDbType.VarBinary)
                {
                    Value = award.AwardImage
                };

                command.Parameters.Add(awardImage);

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
