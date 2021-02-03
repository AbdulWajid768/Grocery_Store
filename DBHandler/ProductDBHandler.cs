using ASSIGNMENT2_V1._0.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace ASSIGNMENT2_V1._0.DBHandler
{
    /// <summary>
    /// Handle the products table in grocery_store Database  
    /// </summary>
    class ProductDBHandler
    {
        private const string connectionStr = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=grocery_store;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDBHandler()
        {
            con = new SqlConnection(connectionStr);
        }

        /// <summary>
        /// Return all the products from Database
        /// </summary>
        /// <returns>ObservableCollection<Product></returns>
        public ObservableCollection<Product> GetAllProductsFromDB()
        {
            ObservableCollection<Product> list = new ObservableCollection<Product>();
            String query = "select * from products";
            con.Open();
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    list.Add(new Product { ID = dr.GetString(1), Name = dr.GetString(2), Price = dr.GetInt32(3), Quantity = dr.GetInt32(4) });
                }
            }
            con.Close();
            return list;
        }

        public bool IsProductIDExist(string pid)
        {
            String query = $"select * from products where pid = @pid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@pid", pid));
            con.Open();
            dr = cmd.ExecuteReader();
            bool flag = dr.HasRows;
            dr.Close();
            con.Close();
            return flag;
        }

        /// <summary>
        /// Check whether product id exist in Database or not
        /// </summary>
        /// <param name="pid">string</param>
        /// <returns>True/False</returns>
        public bool DeleteProductFromDB(string pid)
        {
            String query = $"delete from products where pid = @pid";
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@pid", pid));
            int rowsDeleted = cmd.ExecuteNonQuery();
            con.Close();
            return rowsDeleted >0;
        }

        /// <summary>
        /// Add product to the Database
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>True/False</returns>
        public bool AddProductToDB(Product product)
        {
            if (IsProductIDExist(product.ID))
            {
                return false;
            }
            String query = $"insert into products (pid, name, price, quantity) values(@pid, @n, @p, @q)";
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@pid", product.ID));
            cmd.Parameters.Add(new SqlParameter("@n", product.Name));
            cmd.Parameters.Add(new SqlParameter("@p", product.Price));
            cmd.Parameters.Add(new SqlParameter("@q", product.Quantity));
            int rowsInserted = cmd.ExecuteNonQuery();
            con.Close();
            return rowsInserted > 0;
        }
        /// <summary>
        /// Return specific product from Database
        /// </summary>
        /// <param name="pid">string</param>
        /// <returns></returns>
        public Product GetProductFromDB(string pid)
        {
            Product product = null;
            String query = $"select * from products where pid = @pid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@pid", pid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                product = new Product { ID = dr.GetString(1), Name = dr.GetString(2), Price = dr.GetInt32(3), Quantity = dr.GetInt32(4) };
            }
            dr.Close();
            con.Close();
            return product;
        }

        /// <summary>
        /// Update quantity of specfic product
        /// </summary>
        /// <param name="pid">string</param>
        /// <param name="quantity">int</param>
        /// <returns></returns>
        public bool UpdateProductQuantityInDB(string pid, int quantity)
        {
            String query = $"update products set quantity = @q where pid = @pid";
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@q", quantity));
            cmd.Parameters.Add(new SqlParameter("@pid", pid));
            int rowsDeleted = cmd.ExecuteNonQuery();
            con.Close();
            return rowsDeleted > 0;
        }

    }
}
