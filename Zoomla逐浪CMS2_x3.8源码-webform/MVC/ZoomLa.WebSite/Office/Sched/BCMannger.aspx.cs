﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZoomLa.BLL;
using ZoomLa.Model;
using ZoomLa.Common;

namespace ZoomLaCMS.MIS.OA.Sched
{
    public partial class BCMannger : System.Web.UI.Page
    {
        M_OA_BC bcMod = new M_OA_BC();
        B_OA_BC bcBll = new B_OA_BC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }
        private void DataBind(string key = "")
        {
            DataTable dt = new DataTable();
            dt = bcBll.Sel();
            if (!string.IsNullOrEmpty(key.Trim()))
            {
                dt.DefaultView.RowFilter = "BCName Like '%" + key + "%'";
                dt = dt.DefaultView.ToTable();
            }
            EGV.DataSource = dt;
            EGV.DataBind();
        }
        protected void EGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EGV.PageIndex = e.NewPageIndex;
            DataBind();
        }
        protected void EGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName.ToLower())
            {
                case "del2":
                    bcBll.Del(DataConverter.CLng(e.CommandArgument.ToString()));
                    break;
            }
            DataBind();
        }
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            DataBind(searchText.Text.Trim());
        }
    }
}