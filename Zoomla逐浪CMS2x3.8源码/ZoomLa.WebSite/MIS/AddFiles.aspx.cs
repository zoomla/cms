﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZoomLa.Model;
using ZoomLa.BLL;
using ZoomLa.Common;
using System.IO;

public partial class MIS_AddFiles : System.Web.UI.Page
{
    B_MisInfo bll = new B_MisInfo();
    M_MisInfo model = new M_MisInfo();
    DataTable dt = new DataTable();
    B_User buser = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        buser.CheckIsLogin("/MIS/AddProject.aspx");
        M_UserInfo info = buser.GetLogin();
        if (!IsPostBack)
        {
            if (function.IsNumeric(Request.QueryString["ID"]))
            {
                int ID = DataConverter.CLng(Request.QueryString["ID"]);
                model = bll.SelReturnModel(ID);
                TxtTit.Text = model.Title;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (function.IsNumeric(Request.QueryString["ID"]))
        {
            int ID = DataConverter.CLng(Request.QueryString["ID"]);
            model = bll.SelReturnModel(ID);
        }
        model.Title = TxtTit.Text;
        model.CreateTime = DateTime.Now;
        model.ProID = DataConverter.CLng(Request.QueryString["ProID"]);
        model.MID = DataConverter.CLng(Request.QueryString["MID"]);
        model.Inputer = buser.GetLogin().UserName;
        model.Type = DataConverter.CLng(Request.QueryString["Type"]);
        if (Request.QueryString["ID"] != null)
        {
            bll.UpdateByID(model);
            function.WriteSuccessMsg("修改成功！", "FilesList.aspx?ID=" + Request.QueryString["ID"] + "&ProID=" + Request.QueryString["ProID"] + "&MID=" + Request.QueryString["MID"] + "&Type=" + Request.QueryString["Type"]);
        }
        else
        {
            bll.insert(model);
            function.WriteSuccessMsg("添加成功！", "FilesList.aspx?ProID=" + Request.QueryString["ProID"] + "&MID=" + Request.QueryString["MID"] + "&Type=" + Request.QueryString["Type"]);
        }
    }
}