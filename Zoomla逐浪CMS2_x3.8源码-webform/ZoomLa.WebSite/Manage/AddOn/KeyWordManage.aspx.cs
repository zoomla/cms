﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZoomLa.BLL;
using ZoomLa.Common;
public partial class Manage_I_Content_KeyWordManage : CustomerPageAction
{
    B_KeyWord bkeyword = new B_KeyWord();
    protected void Page_Load(object sender, EventArgs e)
    {
        string KWId = "";
        if (!Page.IsPostBack)
        {
            DataBind();
            if (Request.QueryString["KWId"] != null)
            {
                KWId = Request.QueryString["KWId"].Trim();
                DeleteKeyWords(KWId);
            }
        }
        Call.SetBreadCrumb(Master, "<li><a href='" + CustomerPageAction.customPath2 + "I/Main.aspx'>工作台</a></li><li><a href='ContentManage.aspx'>内容管理</a></li><li class='active'><a href='"+Request.RawUrl+"'>关键字管理</a></li>");
    }
    public void DataBind(string key = "")
    {
        DataTable dt = bkeyword.GetKeyWordAll();
        Egv.DataSource = dt;
        Egv.DataBind();
    }
    protected void txtPageFunc(string size)
    {
        int pageSize;
        if (!int.TryParse(size, out pageSize))//如果转换失败,即不是一个数字时
        {
            pageSize = Egv.PageSize;
        }
        else if (pageSize < 1)//小于1时,均恢复默认PageSize,默认PageSize是你给序的
        {
            pageSize = Egv.PageSize;
        }
        Egv.PageSize = pageSize;
        Egv.PageIndex = 0;//改变后回到首页
        size = pageSize.ToString();
        DataBind();
    }
    protected void Egv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Egv.PageIndex = e.NewPageIndex;
        DataBind();
    }
    private void DeleteKeyWords(string KWId)
    {
        B_KeyWord bkeywords = new B_KeyWord();
        if (bkeywords.DeleteByID(KWId))
        {
            HttpContext.Current.Response.Write("<script language=javascript> alert('删除成功！');window.document.location.href='KeyWordManage.aspx';</script>");
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string[] chkArr = GetChecked();
        if (chkArr != null)
        {
            for (int i = 0; i < chkArr.Length; i++)
            {
                int itemID = Convert.ToInt32(chkArr[i]);
                bkeyword.DeleteByID(itemID.ToString());
            }
        }
        DataBind(); 
    }
    private string[] GetChecked()
    {
        if (!string.IsNullOrEmpty(Request.Form["idchk"]))
        {
            string[] chkArr = Request.Form["idchk"].Split(',');
            return chkArr;
        }
        else
            return null;
    }
}
