﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ZoomLa.Model.Design
{
    public class M_SPage_Page : M_Base
    {
        public int ID { get; set; }
        /// <summary>
        /// 页面标题
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// 页面SEO描述
        /// </summary>
        public string PageDesc { get; set; }
        /// <summary>
        /// 页面URL
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// 页面背景配置(disuse)
        /// </summary>
        public string PageBK { get; set; }
        /// <summary>
        /// 布局信息
        /// </summary>
        public string Layouts { get; set; }
        public int UserID { get; set; }
        public DateTime CDate { get; set; }
        /// <summary>
        /// 数据源标签
        /// </summary>
        public string PageDSLabel {get;set; }
        /// <summary>
        /// JS和CSS资源
        /// </summary>
        public string PageRes { get; set; }
        /// <summary>
        /// 页面底部
        /// </summary>
        public string PageBottom { get; set; }
        /// <summary>
        /// 预览链接
        /// </summary>
        public string ViewUrl {get;set; }
        public override string TbName { get { return "ZL_SPage_Page"; } }
        public override string PK { get { return "ID"; } }
        public M_SPage_Page()
        {
            Layouts = "[]";
            PageBK = "[]";
        }
        public override string[,] FieldList()
        {
            string[,] Tablelist = {
        		        		{"ID","Int","4"},
        		        		{"PageName","NVarChar","500"},
        		        		{"PageDesc","NVarChar","500"},
        		        		{"PageUrl","NVarChar","1000"},
        		        		{"PageBK","NVarChar","4000"},
        		        		{"Layouts","NText","200000"},
        		        		{"UserID","Int","4"},
        		        		{"CDate","DateTime","8"},
                                {"PageBottom","NText","200000"},
                                {"PageRes","NText","8000"},
                                {"ViewUrl","NVarChar","500"},
                                {"PageDSLabel","NVarChar","4000"}
        };
            return Tablelist;
        }
        public override SqlParameter[] GetParameters()
        {
            M_SPage_Page model = this;
            if (model.CDate <= DateTime.MinValue) { model.CDate = DateTime.Now; }
            SqlParameter[] sp = GetSP();
            sp[0].Value = model.ID;
            sp[1].Value = model.PageName;
            sp[2].Value = model.PageDesc;
            sp[3].Value = model.PageUrl;
            sp[4].Value = model.PageBK;
            sp[5].Value = model.Layouts;
            sp[6].Value = model.UserID;
            sp[7].Value = model.CDate;
            sp[8].Value = model.PageBottom;
            sp[9].Value = model.PageRes;
            sp[10].Value = model.ViewUrl;
            sp[11].Value = model.PageDSLabel;
            return sp;
        }
        public M_SPage_Page GetModelFromReader(DbDataReader rdr)
        {
            M_SPage_Page model = new M_SPage_Page();
            model.ID = Convert.ToInt32(rdr["ID"]);
            model.PageName = ConverToStr(rdr["PageName"]);
            model.PageDesc = ConverToStr(rdr["PageDesc"]);
            model.PageUrl = ConverToStr(rdr["PageUrl"]);
            model.PageBK = ConverToStr(rdr["PageBK"]);
            model.Layouts = ConverToStr(rdr["Layouts"]);
            model.UserID = ConvertToInt(rdr["UserID"]);
            model.CDate = ConvertToDate(rdr["CDate"]);
            model.PageBottom = ConverToStr(rdr["PageBottom"]);
            model.PageRes = ConverToStr(rdr["PageRes"]);
            model.ViewUrl = ConverToStr(rdr["ViewUrl"]);
            model.PageDSLabel = ConverToStr(rdr["PageDSLabel"]);
            rdr.Close();
            return model;
        }
    }
}
