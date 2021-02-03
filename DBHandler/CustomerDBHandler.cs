using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASSIGNMENT2_V1._0.DBHandler
{
    /// <summary>
    /// Handle the customers table in grocery_store Database  
    /// </summary>
    class CustomerDBHandler
    {
        private const string connectionStr = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=grocery_store;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CustomerDBHandler()
        {
            con = new SqlConnection(connectionStr);
        }

    

        /// <summary>
        /// Check whether customer exist in Database or not
        /// </summary>
        /// <param name="uname">string</param>
        /// <param name="pswd">string</param>
        /// <returns>True/False</returns>
        public bool IsCustomerExist(string uname, string pswd)
        {
            String query = $"select * from customers where uname = @u and pswd=@p";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@u", uname));
            cmd.Parameters.Add(new SqlParameter("@p", pswd));
            con.Open();
            dr = cmd.ExecuteReader();
            bool flag = dr.HasRows;
            dr.Close();
            con.Close();
            return flag;
        }

        /// <summary>
        /// Check whether customer username exist in Database or not
        /// </summary>
        /// <param name="uname">string</param>
        /// <returns>True/False</returns>
        public bool IsCustomerUsernameExist(string uname)
        {
            String query = $"select * from customers where uname = @u";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@u", uname));
            con.Open();
            dr = cmd.ExecuteReader();
            bool flag = dr.HasRows;
            dr.Close();
            con.Close();
            return flag;
        }

        /// <summary>
        /// Add customer to Database
        /// </summary>
        /// <param name="uname">string</param>
        /// <param name="pswd">string</param>
        /// <returns>True/False</returns>
        public bool AddCustomerToDB(string uname, string pswd, string pno)
        {
            if (IsCustomerUsernameExist(uname))
            {
                return false;
            }
            String query = $"insert into customers (uname,pswd,pno) values(@u, @p, @pno)";
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@u",uname));
            cmd.Parameters.Add(new SqlParameter("@p", pswd));
            cmd.Parameters.Add(new SqlParameter("@pno", pno));
            int rowsInserted = cmd.ExecuteNonQuery();
            con.Close();
            return rowsInserted > 0;
        }
    }
}
