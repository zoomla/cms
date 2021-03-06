﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ZoomLa.BLL;
using ZoomLa.Model;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using ZoomLa.Components;
using ZoomLa.Common;

public partial class manage_WeiXin_UpdateCode : CustomerPageAction
{
    M_QrCode mq = new M_QrCode();
    B_QrCode bq = new B_QrCode();
    B_Admin badmin = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Call.SetBreadCrumb(Master, "<li><a href='" + CustomerPageAction.customPath2 + "Main.aspx'>工作台</a></li><li><a href='Default.aspx'>微信管理</a></li><li><a href='QrCode.aspx'>生成二维码</a></li><li><a href='QrCodeManage.aspx'>[二维码管理]</a></li>");
            
            int id=Convert.ToInt32(Request["ID"]);
            DataTable dt = bq.Sel(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                ShowImgs.Visible = true;
                this.Level.SelectedValue = dt.Rows[0]["CodeLevel"].ToString();
                this.Version.SelectedValue = dt.Rows[0]["CodeVersion"].ToString();
                ImgCode.ImageUrl = SiteConfig.SiteOption.UploadDir + "/" + dt.Rows[0]["ImageUrl"].ToString();
                if (Convert.ToInt32(dt.Rows[0]["Type"]) == 0)
                {
                    this.crt1.Visible = true;
                    this.TabTitle1.Visible = true;
                    this.crt2.Visible = false;
                    this.TabTitle2.Visible = false;
                    this.TxtContent.Text = dt.Rows[0]["CodeContents"].ToString();
                }
                else if (Convert.ToInt32(dt.Rows[0]["Type"]) == 1)
                {
                    this.crt1.Visible = false;
                    this.TabTitle1.Visible = false;
                    this.crt2.Visible = true;
                    this.TabTitle2.Visible = true;
                    string tit = dt.Rows[0]["CodeContents"].ToString();
                    string[] str = tit.Split(new Char[] { ';' });
                    {
                        if (str.Length > 0)
                        {
                            //for (int i = 0; i > str.Length; i++)
                            //{
                            FN.Value = str[0].Split(new Char[] { ':' })[2];
                            TEL.Value = str[1].Split(new Char[] { ':' })[1];
                            EMAIL.Value = str[2].Split(new Char[] { ':' })[1];
                            MSN.Value = str[3].Split(new Char[] { ':' })[1];
                            QQ.Value = str[4].Split(new Char[] { ':' })[1];
                            URL.Value = str[5].Split(new Char[] { ':' })[1] + ":" + str[5].Split(new Char[] { ':' })[2];
                            // }
                        }
                    }
                }
                TxtZoneCode.Text = "<img src='" + SiteConfig.SiteOption.UploadDir + "/" + dt.Rows[0]["ImageUrl"] + "'/>";
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        FileDownload(Server.MapPath(this.ImgCode.ImageUrl.ToString()));
    }

    private void FileDownload(string FullFileName)
    {
        SafeSC.DownFile(function.PToV(FullFileName));
    }
    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        if (TxtContent.Text.Trim() == String.Empty)
        {
            function.WriteErrMsg("数据不能为空!");
            return;
        }
        if (TxtContent.Text.Length > 140)
        {
            function.WriteErrMsg("长度不能超过140个字符");
            return;
        }
        ImgCode.ImageUrl = null;
        this.ShowImgs.Visible = true;
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        //qrCodeEncoder.QRCodeBackgroundColor = System.Drawing.Color.WhiteSmoke;
        //qrCodeEncoder.QRCodeForegroundColor = System.Drawing.Color.YellowGreen;

        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        try
        {
            int scale = Convert.ToInt16(TxtSize.Text);
            qrCodeEncoder.QRCodeScale = scale;
        }
        catch
        {
            function.WriteErrMsg("无效大小");
            return;
        }
        try
        {
            int version = Convert.ToInt16(this.Version.SelectedValue);
            qrCodeEncoder.QRCodeVersion = version;
        }
        catch
        {
            function.WriteErrMsg("无效版本");
        }

        string errorCorrect = this.Level.SelectedValue;
        if (errorCorrect == "L")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
        else if (errorCorrect == "M")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
        else if (errorCorrect == "Q")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
        else if (errorCorrect == "H")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
        String data = "";
        if (this.TxtContent.Text.IndexOf("http://") > 0)
        {
            data = this.TxtContent.Text;
        }
        data = this.TxtContent.Text;
        System.Drawing.Image image = qrCodeEncoder.Encode(data, System.Text.Encoding.Default);
        try
        {
            mq.CodeContents = this.TxtContent.Text;
            mq.CodeLevel = this.Level.SelectedValue;
            mq.CodeVersion = DataConverter.CLng(this.Version.SelectedValue);
            mq.CodeType = "文字";
            mq.UserName = badmin.GetAdminLogin().AdminName;
            mq.Type = 0;
            image = SaveCode(qrCodeEncoder, Server.HtmlEncode(data), image, 0);
        }
        catch (Exception e1)
        {
            Response.Write(e1);
            return;
        }
        finally
        {
            if (image != null)
            {
                image.Dispose();
                image = null;
            }
        }
        BtnSave.Visible = true;
    }
    protected void BtnCreates_Click(object sender, EventArgs e)
    {
        ImgCode.ImageUrl = null;
        this.ShowImgs.Visible = true;
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        //二维码颜色
        //qrCodeEncoder.QRCodeBackgroundColor = System.Drawing.Color.WhiteSmoke;
        //qrCodeEncoder.QRCodeForegroundColor = System.Drawing.Color.YellowGreen;
        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        try
        {
            int scale = Convert.ToInt16(TxtSize.Text);
            qrCodeEncoder.QRCodeScale = scale;
        }
        catch
        {
            function.WriteErrMsg("无效大小");
            return;
        }
        try
        {
            int version = Convert.ToInt16(this.Version.SelectedValue);
            qrCodeEncoder.QRCodeVersion = version;
        }
        catch
        {
            function.WriteErrMsg("无效版本");
        }

        string errorCorrect = this.Level.SelectedValue;
        if (errorCorrect == "L")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
        else if (errorCorrect == "M")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
        else if (errorCorrect == "Q")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
        else if (errorCorrect == "H")
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
        String data = "MECARD:";

        data = data + " N:" + this.FN.Value + ";";


        data = data + " TEL:" + this.TEL.Value + ";";


        data = data + " EMAIL:" + this.EMAIL.Value + ";";


        data = data + " X-MSN:" + this.MSN.Value + ";";


        data = data + " X-QQ:" + this.QQ.Value + ";";


        data = data + " URL:" + this.URL.Value + ";";

        System.Drawing.Image image = qrCodeEncoder.Encode(Server.HtmlEncode(data), System.Text.Encoding.UTF8);
        try
        {
            mq.CodeType = "名片";
            mq.CodeLevel = this.Level.SelectedValue;
            mq.CodeVersion = DataConverter.CLng(this.Version.SelectedValue);
            mq.UserName = badmin.GetAdminLogin().AdminName;
            mq.CodeContents = data;
            mq.Type = 1;
            image = SaveCode(qrCodeEncoder, Server.HtmlEncode(data), image, 1);
        }
        catch (Exception e1)
        {
            Response.Write(e1);
            return;
        }
        finally
        {
            if (image != null)
            {
                image.Dispose();
                image = null;
            }
        }
        BtnSave.Visible = true;
    }

    
    private System.Drawing.Image SaveCode(QRCodeEncoder qrCodeEncoder, String data, System.Drawing.Image image, int Type)
    {
        image = qrCodeEncoder.Encode(data, System.Text.Encoding.Default);
        string upclass, newtimename, filenames, filesname, indexname, tempfilename;
        upclass = Server.HtmlEncode(Request.QueryString["menu"]);
        using (Bitmap bp = new Bitmap(image))
        {
            using (MemoryStream stream = new MemoryStream())
            {
                //bp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                filenames = "QrCode.jpg";
                if (filenames.Length > 0)
                {
                    if (filenames.IndexOf(".") > 0)
                    {
                        filesname = filenames.Substring(filenames.LastIndexOf(".")).ToLower();
                        Random indexcc = new Random();
                        indexname = Convert.ToString(indexcc.Next(9999));

                        if (!Directory.Exists(Server.MapPath(SiteConfig.SiteOption.UploadDir + "/QrCode")))
                        {
                            Directory.CreateDirectory(Server.MapPath(SiteConfig.SiteOption.UploadDir + "/QrCode"));
                        }
                        newtimename = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond);
                        tempfilename = SiteConfig.SiteOption.UploadDir + "/QrCode/" + newtimename + indexname + filesname;
                        try
                        {
                            image.Save(Server.MapPath(tempfilename));
                        }
                        catch (Exception err)
                        {
                            Response.Write(err);
                        }
                        ImgCode.ImageUrl = tempfilename;
                        string tit = TxtContent.Text;
                        if (Type == 1)
                        {
                            tit = data;
                        }
                        TxtZoneCode.Text = "<img src='" + tempfilename + "' alt='" + tit + "' />";
                        mq.ImageUrl = "QrCode/" + newtimename + indexname + filesname;

                        mq.CreateTime = DateTime.Now;
                        if (!string.IsNullOrEmpty(Request["ID"]))
                        {
                            mq.ID = DataConverter.CLng(Request["ID"]);
                            if (bq.UpdateByID(mq))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败');</script>");
                            }
                        }
                        else
                        {
                            bq.Insert(mq);
                        }
                    }
                }
            }
        }
        return image;
    }
}