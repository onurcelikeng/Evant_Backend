using Evant.BO;
using Evant.BO.Models;
using Evant.DAL.Helper;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Evant.DAL
{
    public sealed class EventsOperationDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public EventsOperationDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public ResultModel EventOperation(EventOperationModel model)
        {
            ResultModel result = new ResultModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "EventOperationSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = model.EventId;
            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = model.PersonId;
            sqlCommand.Parameters.Add("@IsGoing", SqlDbType.Bit).Value = model.IsGoing;
            sqlCommand.Parameters.Add("@IsInterested", SqlDbType.Bit).Value = model.IsInterested;

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

        public EventOperationBO GetEventOperationStatistic(int eventId)
        {
            EventOperationBO result = new EventOperationBO();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetEventOperationStatisticSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new EventOperationBO()
                    {
                        IsGoing = sqlReader["IsGoing"] as string,
                        IsInterested = sqlReader["IsInterested"] as string
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        }

        public EventOperationStatusModel EventOperationStatus(int eventId, int personId)
        {
            EventOperationStatusModel result = new EventOperationStatusModel();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "EventOperationStatusSP",
            };

            sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    result = new EventOperationStatusModel()
                    {
                        IsGoing = (bool)sqlReader["IsGoing"],
                        IsInterested = (bool)sqlReader["IsInterested"]
                    };
                }
            }

            connectionHelper.connection.Close();

            return result;
        } 
    }
}