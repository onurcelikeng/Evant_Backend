using Evant.BO;
using Evant.BO.Models;
using Evant.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Evant.BO.AdminModels;

namespace Evant.DAL
{
    public sealed class UserDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public UserDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public TokenBO Register(RegisterModel model)
        {
            TokenBO token = new TokenBO();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "RegisterSP",
            };

            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = model.Name;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = model.Email;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = model.Password;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    token = new TokenBO()
                    {
                        IsSuccess = (bool)sqlReader["IsSuccess"],
                        AccessToken = sqlReader["AccessToken"] as string,
                        Message = sqlReader["Message"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return token;
        }

        public TokenBO Login(LoginModel model)
        {
            TokenBO token = new TokenBO();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "LoginSP"
            };

            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = model.Email;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = model.Password;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    token = new TokenBO()
                    {
                        IsSuccess = (bool)sqlReader["IsSuccess"],
                        AccessToken = sqlReader["AccessToken"] as string,
                        Message = sqlReader["Message"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return token;
        }

        public UserBO GetMe(string token)
        {
            UserBO user = new UserBO();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetMeSP"
            };

            sqlCommand.Parameters.Add("@AccessToken", SqlDbType.NVarChar).Value = token;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    user = new UserBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Name = sqlReader["Name"] as string,
                        Email = sqlReader["Email"] as string,
                        IsAdmin = (bool)sqlReader["IsAdmin"]
                    };
                }
            }

            connectionHelper.connection.Close();

            return user;
        }

        public UserBO GetPersonInformation(int personId)
        {
            UserBO user = new UserBO();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetPersonInformationSP"
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    user = new UserBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Name = sqlReader["Name"] as string,
                        Email = sqlReader["Email"] as string,
                        IsAdmin = (bool)sqlReader["IsAdmin"]
                    };
                }
            }

            connectionHelper.connection.Close();

            return user;
        }

        public List<FollowerModel> GetFollowers(int personId)
        {
            List<FollowerModel> list = new List<FollowerModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "FollowersSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new FollowerModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Name = sqlReader["Name"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public List<FollowingModel> GetFollowing(int personId)
        {
            List<FollowingModel> list = new List<FollowingModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "FollowingSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new FollowingModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Name = sqlReader["Name"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public ResultModel ChangePassword(ChangePasswordModel model)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ChangePasswordSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = model.PersonId;
            sqlCommand.Parameters.Add("@NewPassword", SqlDbType.Int).Value = model.NewPassword;
            sqlCommand.Parameters.Add("@OldPassword", SqlDbType.Int).Value = model.OldPassword;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new ResultModel()
                    {
                        IsSuccess = (bool)sqlReader["IsSuccess"],
                        Message = sqlReader["Message"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        }

        public ResultModel DeleteAccount(int personId)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteAccountSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new ResultModel()
                    {
                        IsSuccess = (bool)sqlReader["IsSuccess"],
                        Message = sqlReader["Message"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        }

        public List<UserModel> Admin_GetAllUsers()
        {
            List<UserModel> list = new List<UserModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_AllUsersSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new UserModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Name = sqlReader["Name"] as string,
                        Email = sqlReader["Email"] as string,
                        AccessToken = sqlReader["AccessToken"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public ResultModel Admin_UserUpdate(int id, string name, string email)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_UserUpdateSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new ResultModel()
                    {
                        IsSuccess = (bool)sqlReader["IsSuccess"],
                        Message = sqlReader["Message"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        }
    }
}