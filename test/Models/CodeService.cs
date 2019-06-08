using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Models
{
    public class CodeService
    {
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString.ToString();
        }


        public List<SelectListItem> GetBook(string bookId)
        {
            DataTable dt = new DataTable();
            string sql = @"Select BOOK_ID As CodeId, BOOK_NAME As CodeName 
                           FROM BOOK_DATA
                           WHERE BOOK_ID != @BOOK_ID";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BOOK_ID", bookId));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);

                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得codeTable的部分資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCodeTable(string type)
        {
            DataTable dt = new DataTable();
            string sql = @"Select Distinct CODE_NAME As CodeName, CODE_ID As CodeID 
                           From dbo.BOOK_CODE 
                           Where CODE_TYPE = @Type";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Type", type));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }
        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CODE_ID"].ToString() + '-' + row["CODE_NAME"].ToString(),
                    Value = row["CODE_ID"].ToString()
                });
            }
            return result;
        }
    }
}