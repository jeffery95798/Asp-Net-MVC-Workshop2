//變數存放
var x = "";
var book = [{ "Id": 0, "Name": "" }], book1 = [];
var myWindow = $("#Window"), grid = $("#Book_Grid");
for (i = 1; i <= $("#list>li").length; i++) {
    s = document.getElementById(i).innerHTML.split("|");
    if (s[4] == "0001") s[4] = "張三"; if (s[4] == "0002") s[4] = "李四"; if (s[4] == "0003") s[4] = "王五";
    if (s[4] == "0004") s[4] = "陳六"; if (s[4] == "0005") s[4] = "劉七"; if (s[4] == "0006") s[4] = "許八";
    book.push({ "Id": s[5], "Name": s[0], "day": s[1], "class": s[2], "status": s[3], "user": s[4] });
    book1.push({ "Id": s[5], "Name": s[0], "day": s[1], "class": s[2], "status": s[3], "user": s[4] });
}
Grid(book1)
//kendoDropDownList
$("#BOOK_BOUGHT_DATE1").kendoDatePicker({
    parseFormats: ["yyyyMMdd", "yyyy/MM/dd", "yyyy-MM-dd"],
    value: new Date(),
    min: new Date(),
    format: "yyyy-MM-dd"
});
$("#BOOK_CLASS_ID1").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Id",
    dataSource: [
        { Id: "BK", Name: "Banking" }, { Id: "DB", Name: "Database" },
        { Id: "DH", Name: "Dataware House" }, { Id: "EIS", Name: "EIS" },
        { Id: "IN", Name: "Internet" }, { Id: "LG", Name: "Languages" },
        { Id: "LR", Name: "Laws And Rules" }, { Id: "MG", Name: "Management" },
        { Id: "MK", Name: "Marketing" }, { Id: "NW", Name: "Networking" },
        { Id: "OS", Name: "Operating System" }, { Id: "SC", Name: "Security" },
        { Id: "SE", Name: "Software Engineering" }, { Id: "SI", Name: "System Integration" },
        { Id: "EAI", Name: "應用系統整合" }, { Id: "OT", Name: "Others" },
        { Id: "CHA", Name: "大陸相關書籍" }, { Id: "TRCD", Name: "內部訓練課程光碟" },
        { Id: "SECD", Name: "研討會/產品介紹光碟" }, { Id: "MENU", Name: "Menu 操作手冊" },
        { Id: "ATCD", Name: "公司內部各項活動光碟" }, { Id: "FM", Name: "家庭保健" },
        { Id: "TP", Name: "休閒旅遊" }, { Id: "CCS", Name: "客戶案例分享" }
    ]
});
$("#BOOK_BOUGHT_DATE2").kendoDatePicker({
    parseFormats: ["yyyyMMdd", "yyyy/MM/dd", "yyyy-MM-dd"],
    value: new Date(),
    min: new Date(),
    format: "yyyy-MM-dd"
});
$("#BOOK_CLASS_ID2").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Id",
    dataSource: [
        { Id: "BK", Name: "Banking" }, { Id: "DB", Name: "Database" },
        { Id: "DH", Name: "Dataware House" }, { Id: "EIS", Name: "EIS" },
        { Id: "IN", Name: "Internet" }, { Id: "LG", Name: "Languages" },
        { Id: "LR", Name: "Laws And Rules" }, { Id: "MG", Name: "Management" },
        { Id: "MK", Name: "Marketing" }, { Id: "NW", Name: "Networking" },
        { Id: "OS", Name: "Operating System" }, { Id: "SC", Name: "Security" },
        { Id: "SE", Name: "Software Engineering" }, { Id: "SI", Name: "System Integration" },
        { Id: "EAI", Name: "應用系統整合" }, { Id: "OT", Name: "Others" },
        { Id: "CHA", Name: "大陸相關書籍" }, { Id: "TRCD", Name: "內部訓練課程光碟" },
        { Id: "SECD", Name: "研討會/產品介紹光碟" }, { Id: "MENU", Name: "Menu 操作手冊" },
        { Id: "ATCD", Name: "公司內部各項活動光碟" }, { Id: "FM", Name: "家庭保健" },
        { Id: "TP", Name: "休閒旅遊" }, { Id: "CCS", Name: "客戶案例分享" }
    ]
});
$("#BOOK_STATUS2").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Id",
    dataSource: [{ Id: "A", Name: "可以借出" }, { Id: "B", Name: "已借出" }, { Id: "U", Name: "不可借出" }, { Id: "C", Name: "已借出(未領)" }]
});
$("#BOOK_KEEPER2").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Id",
    dataSource: [{ Id: "0001", Name: "張三" }, { Id: "0002", Name: "李四" },
    { Id: "0003", Name: "王五" }, { Id: "0004", Name: "陳六" },
    { Id: "0005", Name: "劉七" }, { Id: "0006", Name: "許八" }]
});
//修改
$("#UpdateBook").click(function () {
    $.ajax({
        type: "POST",
        url: "/Home/Update",
        data: "id=" + x + "|" + $("#BOOK_NAME2").val() + "|" + $("#BOOK_AUTHOR2").val() + "|" + $("#BOOK_PUBLISHER2").val() + "|" + $("#BOOK_NOTE2").val() + "|" + $("#BOOK_BOUGHT_DATE2").val() + "|" + $("#BOOK_CLASS_ID2").val() + "|" + $("#BOOK_STATUS2").val() + "|" + $("#BOOK_KEEPER2").val(),
        dataType: "json",
        success: function (response) {
            alert("修改成功")
        }
    });
    myWindow.data("kendoWindow").close();
});
//新增
$("#Insert").click(function () {
    $("#Search_Win").hide(); $("#Insert_Win").show(); $("#Update_Win").hide();
    myWindow.data("kendoWindow").center().open();
});
$("#InsertBook").click(function () {
    $.ajax({
        type: "POST",
        url: "/Home/InsertBook",
        data: "id=" + $("#BOOK_NAME1").val() + "|" + $("#BOOK_AUTHOR1").val() + "|" + $("#BOOK_PUBLISHER1").val() + "|" + $("#BOOK_NOTE1").val() + "|" + $("#BOOK_BOUGHT_DATE1").val() + "|" + $("#BOOK_CLASS_ID1").val(),
        dataType: "json",
        success: function (response) {
            alert("新增成功")
        }
    });
    myWindow.data("kendoWindow").close();
})
//啟動查詢介面
$("#Search").click(function () {
    $("#Search_Win").show(); $("#Insert_Win").hide(); $("#Update_Win").hide();
    myWindow.data("kendoWindow").center().open();
});
//建立查詢介面
$("#Window").kendoWindow({
    width: "600px",
    title: "",
    visible: false,
});
//查詢的下拉式選單
$("#BOOK_NAME").kendoDropDownList({
    filter: "startswith",
    dataTextField: "Name",
    dataValueField: "Name",
    noDataTemplate: "沒有找到相關數據!",
    dataSource: book
});
$("#BOOK_CLASS_NAME").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Name",
    dataSource: [{ Name: "" }, { Name: "Banking" }, { Name: "Database" }, { Name: "Dataware House" }, { Name: "EIS" },
    { Name: "Internet" }, { Name: "Languages" }, { Name: "Laws And Rules" }, { Name: "Management" },
    { Name: "Marketing" }, { Name: "Networking" }, { Name: "Operating System" }, { Name: "Security" },
    { Name: "Software Engineering" }, { Name: "System Integration" }, { Name: "應用系統整合" }, { Name: "Others" },
    { Name: "大陸相關書籍" }, { Name: "內部訓練課程光碟" }, { Name: "研討會/產品介紹光碟" }, { Name: "Menu 操作手冊" },
    { Name: "公司內部各項活動光碟" }, { Name: "家庭保健" }, { Name: "休閒旅遊" }, { Name: "客戶案例分享" }]
});
$("#BOOK_STATUS").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Name",
    dataSource: [{ Name: "" }, { Name: "可以借出" }, { Name: "已借出" }, { Name: "不可借出" }, { Name: "已借出(未領)" }]
});
$("#BOOK_KEEPER").kendoDropDownList({
    dataTextField: "Name",
    dataValueField: "Id",
    dataSource: [{ Id: "", Name: "" }, { Id: "0001", Name: "張三" }, { Id: "0002", Name: "李四" },
    { Id: "0003", Name: "王五" }, { Id: "0004", Name: "陳六" },
    { Id: "0005", Name: "劉七" }, { Id: "0006", Name: "許八" }]
});
//查詢結果
$("#SearchBook").click(function () {
    var search = [];
    for (i = 1; i <= $("#list>li").length; i++) {
        s = document.getElementById(i).innerHTML.split("|");
        if ((s[0] == $("#BOOK_NAME").val() || $("#BOOK_NAME").val() == "") &&
            (s[2] == $("#BOOK_CLASS_NAME").val() || $("#BOOK_CLASS_NAME").val() == "") &&
            (s[3] == $("#BOOK_STATUS").val() || $("#BOOK_STATUS").val() == "") &&
            (s[4] == $("#BOOK_KEEPER").val() || $("#BOOK_KEEPER").val() == "")) search.push({ "Id": s[5], "Name": s[0], "day": s[1], "class": s[2], "status": s[3], "user": s[4] });
    }
    Grid(search);
    myWindow.data("kendoWindow").close();
});
//kendoGrid
function Grid(data) {
    grid.kendoGrid({
        dataSource: {//資料來源
            type: "odata",
            data: data,
            pageSize: 10,
        },
        height: 550,
        toolbar: "圖書分類",
        pageable: {//分頁選單
            input: true,
            numeric: false
        },
        columns: [
            { field: "Id", title: "書籍編號", },
            { field: "class", title: "書籍類別", },
            { field: "Name", title: "書籍名稱", },
            { field: "day", title: "購書日期", },
            { field: "status", title: "借閱狀態", },
            { field: "user", title: "借閱人", },
            {
                command: [
                    {
                        name: "刪除", click: function (e) {//刪除按紐
                            e.preventDefault();
                            var tr = $(e.target).closest("tr");
                            var ss = this.dataItem(tr);
                            kendo.confirm("確定刪除「" + ss.Name + "」嗎?").then(function () {
                                $.ajax({
                                    type: "POST",
                                    url: "/Home/DeleteBookById",
                                    data: "id=" + ss.Id,
                                    dataType: "json",
                                    success: function (response) {
                                        alert("刪除成功")
                                    }
                                });
                                n = 0;
                                for (i = 0; i < book1.length; i++) {
                                    if (book1[i].Id == ss.Id) {
                                        break;
                                    } else {
                                        n++
                                    }
                                }
                                book1.splice(n, 1);
                                Grid(book1);
                            }, function () {
                            });
                        }
                    },
                    {
                        name: "修改", click: function (e) {
                            $("#Search_Win").hide(); $("#Insert_Win").hide(); $("#Update_Win").show();
                            e.preventDefault();
                            var tr = $(e.target).closest("tr");
                            var ss = this.dataItem(tr);
                            x = ss.Id;
                            myWindow.data("kendoWindow").center().open();
                        }
                    }
                ]
            }
        ],
        editable: true
    });
}