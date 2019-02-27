﻿namespace ZoomLaCMS.Manage.Guest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ZoomLa.BLL;
    using ZoomLa.BLL.Message;
    using ZoomLa.Common;
    using ZoomLa.Model;
    using ZoomLa.SQLDAL;
    public partial class BKVersionList : CustomerPageAction
    {
        B_Baike bkBll = new B_Baike();
        B_BaikeEdit editBll = new B_BaikeEdit();
        public int ZStatus { get { return DataConvert.CLng(Request.QueryString["Status"]); } }
        private string Flow { get { return Request.QueryString["Flow"] ?? ""; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                B_ARoleAuth.CheckEx(ZLEnum.Auth.content, "BaikeManage");
                BatAudit_Btn.Visible = ZStatus == 0;
                BatUnAudit_Btn.Visible = ZStatus != 0;
                MyBind();
            }
        }
        private void MyBind()
        {
            EGV.DataSource = editBll.SelBy(ZStatus, SKey_T.Text, Flow);
            EGV.DataBind();
        }
        protected void EGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EGV.PageIndex = e.NewPageIndex;
            MyBind();
        }
        protected void EGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del2":
                    editBll.Del(Convert.ToInt32(e.CommandArgument));
                    break;
            }
            MyBind();
        }
        protected void EGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public string GetStatus()
        {
            int status = DataConvert.CLng(Eval("Status"));
            return editBll.GetStatus(status);
        }
        protected void BatDel_Btn_Click(object sender, EventArgs e)
        {
            editBll.DelByIDS(Request.Form["idchk"]);
            MyBind();
        }
        protected void BatAudit_Btn_Click(object sender, EventArgs e)
        {
            string ids = Request.Form["idchk"];
            if (!string.IsNullOrEmpty(ids))
            {
                editBll.BatStatus(ids, 1);
                foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    editBll.Apply(Convert.ToInt32(id));
                }
            }
            function.WriteSuccessMsg("审核并应用成功");
            MyBind();
        }
        protected void BatUnAudit_Btn_Click(object sender, EventArgs e)
        {
            editBll.BatStatus(Request.Form["idchk"], (int)ZLEnum.ConStatus.UnAudit);
            MyBind();
        }
        protected void BatReject_Btn_Click(object sender, EventArgs e)
        {
            string msg = Request.Form["msg_t"] ?? "";
            msg = msg.Trim(',');
            editBll.BatReject(Request.Form["idchk"], msg);
            MyBind();
        }

        protected void Search_B_Click(object sender, EventArgs e)
        {
            MyBind();
        }
    }
}