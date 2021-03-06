﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZoomLa.BLL;
using ZoomLa.Common;
using ZoomLa.Model;
 
public partial class MIS_OA_Mail_MailManage : System.Web.UI.Page
{
    B_User uBll = new B_User();
    B_Message mBll = new B_Message();
    M_UserInfo uMod = new M_UserInfo();
    //public string DefUrl { get { return string.IsNullOrEmpty(Request.QueryString["url"]) ? "Message.aspx" : Request.QueryString["url"]; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            uMod = uBll.GetLogin();
            string url = Request.QueryString["view"];
            if (!string.IsNullOrEmpty(url))
            { 
                function.Script(this, "$('#mailhref').attr('src', '"+ url +".aspx');$('#"+url+"').addClass('active');");
            }
        }
    }
    public int GetUnreadMsg()
    {
        DataTable dt = mBll.GetUnReadMail(uMod.UserID);
        
        return dt.Rows.Count;
    }
}