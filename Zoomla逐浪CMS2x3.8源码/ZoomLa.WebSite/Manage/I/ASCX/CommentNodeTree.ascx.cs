﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZoomLa.BLL;

public partial class Manage_I_ASCX_CommentNodeTree : System.Web.UI.UserControl
{
    B_Node nodeBll = new B_Node();
    //----节点
    string path = CustomerPageAction.customPath2 + "I/Content/";
    string hasChild = "<a href='javascript:;' id='a{0}' class='list1' ><span class='list_span'>{1}</span><span class='fa fa-chevron-down'></span></a>";
    string noChild = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        noChild = "<a href='javascript:;' onclick='ShowMain(\"\",\"" + path + "CommentManage.aspx?NodeID={0}\");'>{1}</a>";
        BindNode();
    }
    public string GetLI(DataTable dt, int pid = 0)
    {
        string result = "";
        DataRow[] dr = dt.Select("ParentID='" + pid + "'");
        for (int i = 0; i < dr.Length; i++)
        {
            result += "<li>";
            if (dt.Select("ParentID='" + Convert.ToInt32(dr[i]["NodeID"]) + "'").Length > 0)
            {
                result += string.Format(hasChild, dr[i]["NodeID"], dr[i]["NodeName"]);
                result += "<ul class='tvNav tvNav_ul' style='display:none;'>" + GetLI(dt, Convert.ToInt32(dr[i]["NodeID"])) + "</ul>";
            }
            else
            {
                result += string.Format(noChild, dr[i]["NodeID"], dr[i]["NodeName"]);
            }
            result += "</li>";
        }
        return result;
    }
    protected void BindNode()
    {
        nodeHtml.Text = "<ul class='tvNav'><li><a  class='list1' id='a0' href='javascript:;' onclick='ShowMain(\"\",\"" + path + "CommentManage.aspx\");' ><span class='list_span'>全部内容</span><span class='fa fa-list'></span></a>" + GetLI(nodeBll.SelectNodeHtmlXML())+ "</li></ul>";
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        
    }
}