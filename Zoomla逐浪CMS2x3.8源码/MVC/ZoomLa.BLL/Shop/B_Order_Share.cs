﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZoomLa.BLL.Helper;
using ZoomLa.Model.Shop;
using ZoomLa.SQLDAL;
using ZoomLa.SQLDAL.SQL;

namespace ZoomLa.BLL.Shop
{
    public class B_Order_Share:ZL_Bll_InterFace<M_Order_Share>
    {
        public string TbName, TbView = "ZL_Order_ShareView", PK;
        public M_Order_Share initMod = new M_Order_Share();
        public B_Order_Share()
        {
            TbName = initMod.TbName;
            PK = initMod.PK;
        }
        public int Insert(M_Order_Share model)
        {
            return Sql.insertID(TbName, model.GetParameters(), BLLCommon.GetParas(model), BLLCommon.GetFields(model));
        }
        public bool Del(int ID)
        {
            return Sql.Del(TbName, ID);
        }
        public bool UpdateByID(M_Order_Share model)
        {
            return Sql.UpdateByIDs(TbName, PK, model.ID.ToString(), BLLCommon.GetFieldAndPara(model), model.GetParameters());
        }
        public DataTable Sel()
        {
            return Sql.Sel(TbName, "", "CDATE DESC");
        }
        public PageSetting SelPage(int cpage, int psize, int pid, int proid)
        {
            List<SqlParameter> sp = new List<SqlParameter>() { };
            string where = " 1=1 ";
            where += " AND Pid=" + pid;
            if (pid == 0)//主列表才需要按商品筛
            {
                where += " AND ProID=" + proid;
            }
            PageSetting setting = PageSetting.Single(cpage, psize, TbView, PK, where, "CDate DESC", sp);
            DBCenter.SelPage(setting);
            if (pid > 0)
            {
                setting.target = "EGV" + pid;
            }
            return setting;
        }
        /// <summary>
        /// 获取List的主信息
        /// </summary>
        public DataTable SelByProID(int proid)
        {
            string sql = "SELECT * FROM " + TbName + " WHERE ProID=" + proid + " AND Pid=0";
            return SqlHelper.ExecuteTable(sql);
        }
        public M_Order_Share SelReturnModel(int ID)
        {
            using (SqlDataReader reader = Sql.SelReturnReader(TbName, PK, ID))
            {
                if (reader.Read())
                {
                    return initMod.GetModelFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
