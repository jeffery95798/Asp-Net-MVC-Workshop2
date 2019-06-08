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

        
        /// 新增Book
        /// <returns>BookID</returns>
        public int InsertBook(Models.Book book)
        {
            string sql = @" INSERT INTO BOOK_DATA
						 (
						    BOOK_NAME,BOOK_CLASS_ID,BOOK_AUTHOR,BOOK_BOUGHT_DATE,BOOK_PUBLISHER,BOOK_NOTE,BOOK_STATUS,BOOK_KEEPER,
                            CREATE_DATE,CREATE_USER,MODIFY_DATE,MODIFY_USER
						 )
						VALUES
						(
							@BOOK_NAME,@BOOK_CLASS_ID,@BOOK_AUTHOR,@BOOK_BOUGHT_DATE,@BOOK_PUBLISHER,@BOOK_NOTE,@BOOK_STATUS,@BOOK_KEEPER,
                            @CREATE_DATE,@CREATE_USER,@MODIFY_DATE,@MODIFY_USER
						)
						Select SCOPE_IDENTITY()";
            int BookId;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", book.BOOK_NAME));
                cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", book.BOOK_CLASS_ID));
                cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", book.BOOK_AUTHOR));
                cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", book.BOOK_BOUGHT_DATE));
                cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", book.BOOK_PUBLISHER));
                cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", book.BOOK_NOTE));
                cmd.Parameters.Add(new SqlParameter("@BOOK_STATUS", book.BOOK_STATUS));
                cmd.Parameters.Add(new SqlParameter("@BOOK_KEEPER", book.BOOK_KEEPER));
                cmd.Parameters.Add(new SqlParameter("@CREATE_DATE", book.CREATE_DATE));
                cmd.Parameters.Add(new SqlParameter("@CREATE_USER", book.CREATE_USER));
                cmd.Parameters.Add(new SqlParameter("@MODIFY_DATE", book.MODIFY_DATE));
                cmd.Parameters.Add(new SqlParameter("@MODIFY_USER", book.MODIFY_USER));
                BookId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return BookId;
        }


        /// <summary>
        /// 刪除客戶
        /// </summary>
        public void DeleteBookById(string BookId)
        {
            try
            {
                string sql = "Delete FROM BOOK_DATA Where BookID=@BookId";
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

        public List<Models.BookSearchArg> GetBookByCondtioin()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * 
                           FROM BOOK_DATA";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookDataToList(dt);
        }

        private List<Models.BookSearchArg> MapBookDataToList(DataTable bookData)
        {
            List<Models.BookSearchArg> result = new List<BookSearchArg>();
            foreach (DataRow row in bookData.Rows)
            {
                result.Add(new BookSearchArg()
                {
                    BOOK_ID = row["BOOK_ID"].ToString(),
                    BOOK_NAME = row["BOOK_NAME"].ToString(),
                    BOOK_CLASS_ID = row["BOOK_CLASS_ID"].ToString(),
                    BOOK_BOUGHT_DATE = row["BOOK_BOUGHT_DATE"].ToString(),
                    BOOK_STATUS = row["BOOK_STATUS"].ToString(),
                });
            }
            return result;
        }
    }
}