using Evant.BO.Models;
using Evant.DAL.Helper;
using System;
using System.Data.SqlClient;
using System.Data;
using Evant.BO.AdminModels;
using System.Collections.Generic;

namespace Evant.DAL
{
    public sealed class FriendsOperationDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public FriendsOperationDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public ResultModel FriendOperation(int followedId, int followerId)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "FriendOperationSP",
            };

            sqlCommand.Parameters.Add("@FollowedId", SqlDbType.Int).Value = followedId;
            sqlCommand.Parameters.Add("@FollowerId", SqlDbType.Int).Value = followerId;

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

        public bool GetFriendOperationControl(int personId, int meId)
        {
            bool IsFollow = false;

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetFriendOperationControlSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;
            sqlCommand.Parameters.Add("@MeId", SqlDbType.Int).Value = meId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    IsFollow = (bool)sqlReader["IsFollow"];
                }
            }

            connectionHelper.connection.Close();

            return IsFollow;
        }

        public ResultModel RemoveFriendOperation(int id)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "RemoveFriendOperationSP",
            };

            sqlCommand.Parameters.Add("@FriendOperationId", SqlDbType.Int).Value = id;

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

        public List<FriendOperationModel> Admin_AllFriendOperations()
        {
            List<FriendOperationModel> list = new List<FriendOperationModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_AllFriendOperationsSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new FriendOperationModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Followed = sqlReader["Followed"] as string,
                        Follower = sqlReader["Follower"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }
    }
}