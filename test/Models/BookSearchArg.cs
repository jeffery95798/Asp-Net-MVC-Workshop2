using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class BookSearchArg
    {
        [DisplayName("書名")]
        public string BOOK_NAME { get; set; }
        [DisplayName("書ID")]
        public string BOOK_ID { get; set; }
        [DisplayName("書籍類別")]
        public string BOOK_CLASS_ID { get; set; }
        [DisplayName("購書日期")]
        public string BOOK_BOUGHT_DATE { get; set; }
        [DisplayName("借閱狀態")]
        public string BOOK_STATUS { get; set; }
    }
}