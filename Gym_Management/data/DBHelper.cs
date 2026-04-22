using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Gym_Management.Data
{
    internal class DBHelper
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["GymManagementDb"]?.ConnectionString
            ?? throw new Exception("Không tìm thấy connection string 'GymManagementDb' trong App.config");

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = BuildCommand(conn, query, parameters, commandType))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message, ex);
                }
            }

            return dt;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = BuildCommand(conn, query, parameters, commandType))
            {
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thực hiện câu lệnh: " + ex.Message, ex);
                }
            }
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = BuildCommand(conn, query, parameters, commandType))
            {
                try
                {
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy giá trị: " + ex.Message, ex);
                }
            }
        }

        private SqlCommand BuildCommand(SqlConnection conn, string query, SqlParameter[] parameters, CommandType commandType)
        {
            SqlCommand cmd = new SqlCommand(query, conn)
            {
                CommandType = commandType,
                CommandTimeout = 120
            };

            if (parameters != null)
            {
                foreach (SqlParameter source in parameters)
                {
                    SqlParameter p = CloneParameter(source);
                    NormalizeParameterValue(p);
                    cmd.Parameters.Add(p);
                }
            }

            return cmd;
        }

        private static SqlParameter CloneParameter(SqlParameter source)
        {
            SqlParameter clone = new SqlParameter
            {
                ParameterName = source.ParameterName,
                SqlDbType = source.SqlDbType,
                Direction = source.Direction,
                Size = source.Size,
                Precision = source.Precision,
                Scale = source.Scale,
                TypeName = source.TypeName,
                Value = source.Value ?? DBNull.Value
            };

            if (source.SqlDbType == 0 && source.Value != null && source.Value != DBNull.Value)
            {
                clone = new SqlParameter(source.ParameterName, source.Value)
                {
                    Direction = source.Direction,
                    TypeName = source.TypeName
                };
            }

            return clone;
        }

        private static void NormalizeParameterValue(SqlParameter p)
        {
            if (p.Value == null)
            {
                p.Value = DBNull.Value;
                return;
            }

            if (p.Value is DateTime)
            {
                DateTime dtValue = (DateTime)p.Value;
                if (dtValue < new DateTime(1753, 1, 1))
                {
                    p.Value = DBNull.Value;
                }
            }
        }
    }
}
