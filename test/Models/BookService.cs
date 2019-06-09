using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class BookService
    {
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString.ToString();
        }
        public List<Models.BookSearchArg> getsql()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * 
                           FROM BOOK_DATA,BOOK_CLASS,BOOK_CODE 
                           WHERE BOOK_DATA.BOOK_CLASS_ID=BOOK_CLASS.BOOK_CLASS_ID AND BOOK_DATA.BOOK_STATUS=BOOK_CODE.CODE_ID";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.putmodels(dt);
        }
        private List<Models.BookSearchArg> putmodels(DataTable bookData)
        {
            List<Models.BookSearchArg> result = new List<BookSearchArg>();
            foreach (DataRow row in bookData.Rows)
            {
                result.Add(new BookSearchArg()
                {
                    BOOK_NAME = row["BOOK_NAME"].ToString(),
                    BOOK_ID = row["BOOK_ID"].ToString(),
                    BOOK_CLASS_NAME = row["BOOK_CLASS_NAME"].ToString(),
                    BOOK_BOUGHT_DATE = row["BOOK_BOUGHT_DATE"].ToString(),
                    CODE_NAME = row["CODE_NAME"].ToString(),
                    BOOK_KEEPER = row["BOOK_KEEPER"].ToString()
                });
            }
            return result;
        }
        /// 新增Book
        /// <returns>BookID</returns>
        public void InsertBook(string BOOK_NAME, string BOOK_AUTHOR, string BOOK_PUBLISHER, string BOOK_NOTE, string BOOK_BOUGHT_DATE, string BOOK_CLASS_ID)
        {
            try
            {
                string sql = @" INSERT INTO BOOK_DATA
						     (
						        BOOK_NAME,BOOK_AUTHOR,BOOK_PUBLISHER,BOOK_NOTE,BOOK_BOUGHT_DATE,BOOK_CLASS_ID,BOOK_STATUS
						     )
						    VALUES
						    (
							    @BOOK_NAME,@BOOK_AUTHOR,@BOOK_PUBLISHER,@BOOK_NOTE,@BOOK_BOUGHT_DATE,@BOOK_CLASS_ID,@BOOK_STATUS,'A'
						    )
						    Select SCOPE_IDENTITY()";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", BOOK_NAME));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", BOOK_AUTHOR));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", BOOK_PUBLISHER));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", BOOK_NOTE));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", BOOK_BOUGHT_DATE));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", BOOK_CLASS_ID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 刪除
        /// </summary>
        public void DeleteBookById(string BookId)
        {
            try
            {
                string sql = "Delete FROM BOOK_DATA Where Book_ID=@BookId";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@BookId", BookId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void UpdateBook(string BOOK_ID, string BOOK_NAME, string BOOK_AUTHOR, string BOOK_PUBLISHER, string BOOK_NOTE, string BOOK_BOUGHT_DATE, string BOOK_CLASS_ID, string BOOK_STATUS, string BOOK_KEEPER)
        {
            try
            {
                string sql = @"UPDATE BOOK_DATA
                                 SET  BOOK_NAME=@BOOK_NAME,
                                      BOOK_AUTHOR=@BOOK_AUTHOR,
                                      BOOK_PUBLISHER=@BOOK_PUBLISHER,
                                      BOOK_NOTE=@BOOK_NOTE,
                                      BOOK_BOUGHT_DATE=@BOOK_BOUGHT_DATE,
                                      BOOK_CLASS_ID=@BOOK_CLASS_ID,
                                      BOOK_STATUS=@BOOK_STATUS,
                                      BOOK_KEEPER=@BOOK_KEEPER

                                WHERE BOOK_ID = @BOOK_ID";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", BOOK_NAME));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", BOOK_AUTHOR));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", BOOK_PUBLISHER));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", BOOK_NOTE));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", BOOK_BOUGHT_DATE));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", BOOK_CLASS_ID));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_STATUS", BOOK_STATUS));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_KEEPER", BOOK_KEEPER));
                    cmd.Parameters.Add(new SqlParameter("@BOOK_ID", BOOK_ID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}