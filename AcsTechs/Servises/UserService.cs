using AcsTechs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace AcsTechs.Servises
{
    public class UserService
    {
        public string connect = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;

        public List<UserModels> GetUserList()
        {
            List<UserModels> userModels = new List<UserModels>();
            dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UserPROCEDURE",connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@user", "GetUserList");
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    for(int i=0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        UserModels user = new UserModels();
                        user.ID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ID"]);
                        user.FirstName = Convert.ToString(dataSet.Tables[0].Rows[i]["FirstName"]);
                        user.FinalName = Convert.ToString(dataSet.Tables[0].Rows[i]["FinalName"]);
                        user.EmailUser = Convert.ToString(dataSet.Tables[0].Rows[i]["EmailUser"]);
                        user.MobileNumber = Convert.ToString(dataSet.Tables[0].Rows[i]["MobileNumber"]);
                        user.UserName = Convert.ToString(dataSet.Tables[0].Rows[i]["UserName"]);
                        userModels.Add(user);





                    }
                }

            }
            return userModels;
        }

        public void AddUser(UserModels usermodels)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand sqlCommand = new SqlCommand("UserPROCEDURE", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@user", "AddUser");

                sqlCommand.Parameters.AddWithValue("@FirstName", usermodels.FirstName);
                sqlCommand.Parameters.AddWithValue("@FinalName", usermodels.FinalName);
                sqlCommand.Parameters.AddWithValue("@EmailUser", usermodels.EmailUser);
                sqlCommand.Parameters.AddWithValue("@MobileNumber", usermodels.MobileNumber);

                sqlCommand.Parameters.AddWithValue("@UserName", usermodels.UserName);
                sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();


            }


        }
    }
}