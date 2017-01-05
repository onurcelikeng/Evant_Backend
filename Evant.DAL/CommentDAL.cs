using Evant.BO;
using Evant.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Evant.BO.Models;
using Evant.BO.AdminModels;

namespace Evant.DAL
{
    public sealed class CommentDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public CommentDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public ResultModel AddComment(AddCommentModel model)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddCommentSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = model.EventId;
            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = model.PersonId;
            sqlCommand.Parameters.Add("@Title", SqlDbType.NVarChar).Value = model.Title;
            sqlCommand.Parameters.Add("@Content", SqlDbType.NVarChar).Value = model.Content;

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

        public List<CommentBO> GetAllComments(int eventId)
        {
            List<CommentBO> list = new List<CommentBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetAllCommentsSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new CommentBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        PersonId = Convert.ToInt32(sqlReader["PersonId"]),
                        Content = sqlReader["Content"] as string,
                        Title = sqlReader["Title"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        Date = (DateTime)sqlReader["Date"]
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public List<CommentModel> Admin_GetAllComments()
        {
            List<CommentModel> list = new List<CommentModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_AllCommentsSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new CommentModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Content = sqlReader["Content"] as string,
                        Title = sqlReader["Title"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        Date = ((DateTime)sqlReader["Date"]).Date.ToString("dd/MM/yyyy"),
                        EventName = sqlReader["EventName"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public void Admin_DeleteComment(int commentId)
        {
            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_DeleteCommentSP",
            };

            sqlCommand.Parameters.Add("@CommentId", SqlDbType.Int).Value = commentId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            connectionHelper.connection.Close();
        }

        public ResultModel Admin_CommentUpdate(int id, string title, string content)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_CommentUpdateSP",
            };

            sqlCommand.Parameters.Add("@CommentId", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
            sqlCommand.Parameters.Add("@Content", SqlDbType.NVarChar).Value = content;

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