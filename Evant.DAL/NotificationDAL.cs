using Evant.BO;
using Evant.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Evant.DAL
{
    public sealed class NotificationDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public NotificationDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public List<NotificationBO> GetAllNotifications(int personId)
        {
            List<NotificationBO> list = new List<NotificationBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetAllNotificationSP",
            };

            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new NotificationBO()
                    {
                        FollowerId = Convert.ToInt32(sqlReader["FollowerId"]),
                        Content = sqlReader["Content"] as string,
                        Date = (DateTime)sqlReader["Date"]
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }
    }
}