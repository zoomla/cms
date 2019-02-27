﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZoomLa.Sns.BLL;
using ZoomLa.Model;
using ZoomLa.Components;
using ZoomLa.BLL;
using ZoomLa.Sns.Model;

public partial class MusicShow : Page
{
    #region 业务对象
    BookBLL bbll = new BookBLL();
    CollectTableBLL ctbll = new CollectTableBLL();
    B_User ubll = new B_User();
    #endregion
    int currentUser = 0;
    private Guid bID
    {
        get
        {
            if (ViewState["bID"] != null)
                return new Guid(ViewState["bID"].ToString());
            else return Guid.Empty;
        }
        set
        {
            ViewState["bID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        currentUser = ubll.GetLogin().UserID;
        ubll.CheckIsLogin();
        if (!IsPostBack)
        {
            M_UserInfo uinfo = ubll.GetUserByUserID(currentUser);
            ViewState["bID"] = new Guid(Request.QueryString["bID"].ToString());
            GetBooktable(bID);
        }
        this.WebUserControlComment1.GetcbID = bID;
        this.WebUserControlComment1.GetcuID = currentUser;
        this.WebUserControlComment1.Gettype = 2;
        this.WebUserControlCollect1.userID = currentUser;
        this.WebUserControlCollect1.ByID = bID;
        this.WebUserControlCollect1.stype = 2;
    }

    #region 方法
    //读取某条书籍
    private void GetBooktable(Guid ID)
    {
        BookTable bt = bbll.GetBooktableByID(ID);
        this.Label1.Text = "<h3>" + bt.BookTitle + "</h3>";
        this.Label2.Text = bt.BookContent;
        this.Label3.Text = bt.BookAnthor;
        this.Label4.Text = bt.BookOtherTitle;
        this.Label5.Text = bt.BookIsbn;
        this.Label7.Text = bt.BookConcerm;
        this.Label8.Text = bt.BookYear;
        this.Image1.ImageUrl = bt.Bookurl;
    }


    

    #endregion
}

