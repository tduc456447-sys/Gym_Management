using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Gym_Management.Data
{
    internal class DBHelper
    {
        private string connectionString = @"Data Source=QUANG\SQLEXPRESS;Initial Catalog=GymManagementV2;Integrated Security=True;TrustServerCertificate=True";

        public DBHelper() { }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            if (p.Value is DateTime)
                            {
                                DateTime dtValue = (DateTime)p.Value;
                                if (dtValue < new DateTime(1753, 1, 1))
                                    p.Value = DBNull.Value;
                            }

                            cmd.Parameters.Add(p);
                        }
                    }

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                    }
                }
            }

            return dt;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            if (p.Value is DateTime)
                            {
                                DateTime dtValue = (DateTime)p.Value;
                                if (dtValue < new DateTime(1753, 1, 1))
                                    p.Value = DBNull.Value;
                            }

                            cmd.Parameters.Add(p);
                        }
                    }

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thực hiện câu lệnh: " + ex.Message);
                    }
                }
            }

            return result;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            object result = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            if (p.Value is DateTime)
                            {
                                DateTime dtValue = (DateTime)p.Value;
                                if (dtValue < new DateTime(1753, 1, 1))
                                    p.Value = DBNull.Value;
                            }

                            cmd.Parameters.Add(p);
                        }
                    }

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy giá trị: " + ex.Message);
                    }
                }
            }

            return result;
        }
        public object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}