using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BDUBLL;
using BDUModel;
using System.Collections.Generic;
using System.IO;
using ZoomLa.Common;
using ZoomLa.Components;
using ZoomLa.BLL;
using ZoomLa.Model;

namespace ZoomLa.WebSite.User.UserZone.Pic
{
    public partial class PicTureList : Page
    {
        protected string UserName = "";
        public  string CategName = "";
        protected string UserID = "";
        protected string type = "";
        public  Guid categid;
        PicCateg_BLL categ = new PicCateg_BLL();
        PicCateg piccateg = new PicCateg();
        B_User buser = new B_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            categid =new Guid (Request.QueryString["CategID"].ToString ());
            piccateg = categ.GetPicCateg(categid);

            
            if(Request.QueryString["PicPws"]==null)
            {
                M_UserInfo mui = new M_UserInfo();
                mui = buser.GetLogin();
                if (mui.UserID != piccateg.PicCategUserID)
                {
                    if (piccateg.State==4)
                    {
                        Response.Write("<script>window.open('PhotoPws.aspx?CategID=" + Request.QueryString["CategID"] + "','newwindow','height=150,width=300,top=200,left=200,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');</script>");
                        Response.End();
                    }
                }
                if (!IsPostBack)
                {
                    M_UserInfo uinfo = buser.GetUserByUserID(buser.GetLogin().UserID);
                    switch (piccateg.State)
                    {
                        case 1:
                            type = "相册类型：所有人可见";
                            break;
                        case 2:
                            type = "相册类型：仅好友可见";
                            break;
                        case 3:
                            type = "相册类型：仅自己可见";
                            break;
                        case 4:
                            type = "相册类型：密码设置";
                            break;
                        default:
                            break;
                    }
                    UserName = "我";
                    Panel1.Visible = true;
                    LinkButton1.Attributes.Add("OnClick", "return confirm('你确定要删除这个相册吗？')");
                    CategName = piccateg.PicCategTitle;
                    Bind();
                }
            }
            else if (Request.QueryString["PicPws"] != null && Request.QueryString["PicPws"] == piccateg.PicCategPws)
            {
                if (!IsPostBack)
                {
                    B_User ubll = new B_User();                   
                    type = "密码设置";
                    UserName = ubll.GetUserByUserID(piccateg.PicCategUserID).UserName;
                    Panel1.Visible = true;
                    LinkButton1.Attributes.Add("OnClick", "return confirm('你确定要删除这个相册吗？')");
                    CategName = piccateg.PicCategTitle;
                    Bind();
                }
            }
        }

        private void Bind()
        {
            int CPage;
            int temppage;
            PicTure_BLL turebll = new PicTure_BLL();
            List<PicTure> list = new List<PicTure>();
            list = turebll.GetPicTureList(categid, null);
            if (Request.Form["DropDownList1"] != null)
            {
                temppage = Convert.ToInt32(Request.Form["DropDownList1"]);
            }
            else
            {
                temppage = Convert.ToInt32(Request.QueryString["CurrentPage"]);
            }
            CPage = temppage;
            if (CPage <= 0)
            {
                CPage = 1;
            }
            PagedDataSource cc = new PagedDataSource();
            cc.DataSource = list;
            cc.AllowPaging = true;
            cc.PageSize = 12;
            cc.CurrentPageIndex = CPage - 1;
            dltPicList.DataSource = cc;
            dltPicList.DataBind();

            Allnum.Text = list.Count.ToString();
            int thispagenull = cc.PageCount;//总页数
            int CurrentPage = cc.CurrentPageIndex;
            int nextpagenum = CPage - 1;//上一页
            int downpagenum = CPage + 1;//下一页
            int Endpagenum = thispagenull;
            if (thispagenull <= CPage)
            {
                downpagenum = thispagenull;
                Downpage.Enabled = false;
            }
            else
            {
                Downpage.Enabled = true;
            }
            if (nextpagenum <= 0)
            {
                nextpagenum = 0;
                Nextpage.Enabled = false;
            }
            else
            {
                Nextpage.Enabled = true;
            }

            Toppage.Text = "<a href=?Currentpage=0&CategID="+categid+">首页</a>";
            Nextpage.Text = "<a href=?Currentpage=" + nextpagenum.ToString() + "&CategID=" + categid + ">上一页</a>";
            Downpage.Text = "<a href=?Currentpage=" + downpagenum.ToString() + "&CategID=" + categid + ">下一页</a>";
            Endpage.Text = "<a href=?Currentpage=" + Endpagenum.ToString() + "&CategID=" + categid + ">尾页</a>";
            Nowpage.Text = CPage.ToString();
            PageSize.Text = thispagenull.ToString();
            pagess.Text = cc.PageSize.ToString();
            for (int i = 1; i <= thispagenull; i++)
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("?Currentpage=" + this.DropDownList1.Text + "&CategID = "+categid);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            PicTure_BLL ture = new PicTure_BLL();
            List<PicTure> pic = new List<PicTure>();
            pic=ture.GetPicTureList(categid, null);
            int i=0;
            while (i < pic.Count)
            {
                //DelPic.CleanFiles(AppDomain.CurrentDomain.BaseDirectory  + pic[i].PicUrl.ToString());
                ture.DelPic(pic[i].ID);
                i++;
            }
            PicCateg_BLL categ = new PicCateg_BLL();
            categ.Del(categid);
            Response.Write("<script>location.href='CategList.aspx'</script>");
        }       
    }
}
