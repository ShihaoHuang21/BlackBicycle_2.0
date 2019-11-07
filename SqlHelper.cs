using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 自行车租赁系统
{
    public static class SqlHelper
    {

        public static string constr = "Data Source=.;Initial Catalog=Bike;Integrated Security=True;";
        /// <summary>
        /// 执行SQLCommand进行增删改，insert、update、delete，返回受影响的行数
        /// </summary>
        /// <param name="constr">连接的数据库字符串</param>
        /// <param name="sql">执行的sql操作语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// 执行SQLCommand的ExeCuteScalar（），查询返回一个值（结果集里的首行首列）
        /// </summary>
        /// <param name="constr">连接的数据库字符串</param>
        /// <param name="sql">执行的sql操作语句</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 执行查询SqlDataApter命令，返回一个DataTable对象
        /// </summary>
        /// <param name="constr">连接的数据库信息字符串</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                    sda.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行查询SqlDataApter命令，返回一个DataSet对象
        /// </summary>
        /// <param name="constr">连接的数据库信息字符串</param>
        /// <param name="sql">执行的sql语句</param>

        /// <returns></returns>
        public static DataSet ExcuteDataSet(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                    sda.Fill(ds);
                }
            }
            return ds;
        }


        /// <summary>
        /// 执行查询，返回一个SQLDataReader对象
        /// </summary>
        /// <param name="constr">连接的数据库字符串</param>
        /// <param name="sql">执行的sql语句</param>
        /// <returns></returns>

        /*返回SQLDataReader时，Connection和SQLCommand都不能关闭，关闭了的话返回的DataReader就没有任何数据了
         解决这个问题：调用ExecuteReader()时传入一个 叫 CommandBehavior的参数，
         表示用户关闭DataReader时、Connection和Command也自动被关闭。
         */
        public static SqlDataReader ExecuteDataReader(string constr, string sql)
        {
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            //CommandBehavior.CloseConnection这个参数表示当DataReader关闭时，Connection、Command也被自动关闭
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
    }
}
