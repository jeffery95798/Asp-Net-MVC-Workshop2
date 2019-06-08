using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Book
    {
        [DisplayName("書ID")]
        public int BOOK_ID { get; set; }
        [DisplayName("書名")]
        public string BOOK_NAME { get; set; }
        [DisplayName("書籍類別")]
        public string BOOK_CLASS_ID { get; set; }
        [DisplayName("書籍作者")]
        public string BOOK_AUTHOR { get; set; }
        [DisplayName("購書日期")]
        public string BOOK_BOUGHT_DATE { get; set; }
        [DisplayName("出版商")]
        public string BOOK_PUBLISHER { get; set; }
        [DisplayName("內容簡介")]
        public string BOOK_NOTE { get; set; }
        [DisplayName("借閱狀態")]
        public string BOOK_STATUS { get; set; }
        [DisplayName("書籍保管人")]
        public string BOOK_KEEPER { get; set; }
        [DisplayName("建立時間")]
        public string CREATE_DATE { get; set; }
        [DisplayName("建立使用者")]
        public string CREATE_USER { get; set; }
        [DisplayName("修改時間")]
        public string MODIFY_DATE { get; set; }
        [DisplayName("修改使用者")]
        public string MODIFY_USER { get; set; }
    }
}