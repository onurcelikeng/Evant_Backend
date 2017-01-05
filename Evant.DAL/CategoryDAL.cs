using Evant.BO;
using Evant.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Evant.BO.Models;

namespace Evant.DAL
{
    public sealed class CategoryDAL
    {
        private ConnectionHelper connectionHelper;
        private SqlCommand sqlCommand;


        public CategoryDAL()
        {
            connectionHelper = new ConnectionHelper();
        }


        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> list = new List<CategoryModel>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetAllCategoriesSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new CategoryModel()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        Category = sqlReader["Category"] as string
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }

        public List<CategoryBO> GetBestCategories()
        {
            List<CategoryBO> list = new List<CategoryBO>();

            sqlCommand = new SqlCommand()
            {
                Connection = connectionHelper.connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetBestCategoriesSP",
            };

            connectionHelper.connection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var model = new CategoryBO()
                    {
                        Category = sqlReader["Category"] as string,
                        Size = Convert.ToInt32(sqlReader["Size"])
                    };

                    list.Add(model);
                }
            }

            connectionHelper.connection.Close();

            return list;
        }
    }
}