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
    public sealed class EventDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public EventDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public List<EventBO> GetAllEvents(string category)
        {
            List<EventBO> list = new List<EventBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetAllEventsSP",
            };

            sqlCommand.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new EventBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        Description = sqlReader["Description"] as string,
                        Category = sqlReader["Category"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public List<EventBO> GetUserEvents(int userId)
        {
            List<EventBO> list = new List<EventBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetUserEventsSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = userId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new EventBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        Description = sqlReader["Description"] as string,
                        Category = sqlReader["Category"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public List<EventBO> GetEventSearch(string input)
        {
            List<EventBO> list = new List<EventBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetEventSearchSP",
            };

            sqlCommand.Parameters.Add("@Input", SqlDbType.NVarChar).Value = input;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new EventBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        Description = sqlReader["Description"] as string,
                        Category = sqlReader["Category"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public List<EventBO> GetNewestEvents()
        {
            List<EventBO> list = new List<EventBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetNewestEventsSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new EventBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        Description = sqlReader["Description"] as string,
                        Category = sqlReader["Category"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public EventBO GetEventDetail(int eventId)
        {
            EventBO result = new EventBO();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetEventDetailSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new EventBO()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        PersonId = Convert.ToInt32(sqlReader["PersonId"]),
                        PersonName = sqlReader["PersonName"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        Description = sqlReader["Description"] as string,
                        Category = sqlReader["Category"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        }

        public ResultModel AddEvent(AddEventModel model)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddEventSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = model.PersonId;
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = model.Name;
            sqlCommand.Parameters.Add("@City", SqlDbType.NVarChar).Value = model.City;
            sqlCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = model.StartDate;
            sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = model.Description;
            sqlCommand.Parameters.Add("@CategoryId", SqlDbType.Int).Value = model.Category;

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

        public ResultModel RemoveEvent(int eventId)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "RemoveEventSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;

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

        public List<EventModel> Admin_GetAllEvents()
        {
            List<EventModel> list = new List<EventModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_AllEventsSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new EventModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        CreateDate = ((DateTime)sqlReader["CreateDate"]).Date.ToString("dd/MM/yyyy"),
                        Category = sqlReader["Category"] as string,                     
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public void Admin_DeleteEvent(int eventId)
        {
            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_DeleteEventSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            connectionHelper.connection.Close();
        }

        public ResultModel Admin_EventUpdate(EventUpdateModel model)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_EventUpdateSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = model.Id;
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = model.Name;
            sqlCommand.Parameters.Add("@City", SqlDbType.NVarChar).Value = model.City;
            sqlCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = model.StartDate;
            sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = model.Description;

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

        public EventModel Admin_EventUpdateDetails(int eventId)
        {
            EventModel result = new EventModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Admin_EventUpdateDetailsSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new EventModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        EventName = sqlReader["EventName"] as string,
                        PersonName = sqlReader["PersonName"] as string,
                        Category = sqlReader["Category"] as string,
                        City = sqlReader["City"] as string,
                        StartDate = ((DateTime)sqlReader["StartDate"]).Date.ToString("dd/MM/yyyy"),
                        Description = sqlReader["Description"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        }
    }
}