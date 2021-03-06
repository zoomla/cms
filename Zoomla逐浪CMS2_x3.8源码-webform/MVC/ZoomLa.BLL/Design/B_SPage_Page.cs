﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZoomLa.BLL.Helper;
using ZoomLa.Common;
using ZoomLa.Model.Design;
using ZoomLa.SQLDAL;
namespace ZoomLa.BLL.Design
{
    public class B_SPage_Page
    {
        private M_SPage_Page initMod = new M_SPage_Page();
        private string TbName, PK;
        public B_SPage_Page()
        {
            TbName = initMod.TbName;
            PK = initMod.PK;
        }
        public bool Del(int ID)
        {
            return DBCenter.Del(TbName, PK, ID);
        }
        public int Insert(M_SPage_Page model)
        {
            if (IsExist(model.PageName)) { model.PageName += "_"+function.GetRandomString(4,2); }
            return DBCenter.Insert(model);
        }
        public bool IsExist(string name, int id = 0)
        {
            List<SqlParameter> sp = new List<SqlParameter>(){new SqlParameter("name",name.Trim())};
            string where = "PageName =@name";
            if (id != 0) { where += " AND ID!=" + id; }
            return DBCenter.IsExist(TbName, where, sp);
        }
        public DataTable Sel()
        {
            return DBCenter.Sel(TbName);
        }
        public DataTable Sel(string name)
        {
            string where = " 1=1";
            List<SqlParameter> sp = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(name)) { where += " AND PageName LIKE @name"; sp.Add(new SqlParameter("name", "%" + name + "%")); }
            return SqlHelper.JoinQuery("A.*,B.UserName", TbName, "ZL_User", "A.UserID=B.UserID", where, "A.ID DESC", sp.ToArray());
        }
        public M_SPage_Page SelModelByName(string name)
        {
            if (string.IsNullOrEmpty(name)) { return null; }
            List<SqlParameter> sp = new List<SqlParameter>() { new SqlParameter("name", name) };
            using (DbDataReader reader = DBCenter.SelReturnReader(TbName, "PageName=@name", "", sp))
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
        public M_SPage_Page SelReturnModel(int ID)
        {
            using (DbDataReader reader = DBCenter.SelReturnReader(TbName, PK, ID))
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
        public bool UpdateByID(M_SPage_Page model)
        {
            if (IsExist(model.PageName, model.ID)) { model.PageName += "_"+function.GetRandomString(4,2); }
            return DBCenter.UpdateByID(model, model.ID);
        }
        public bool DelByIDS(string ids)
        {
            SafeSC.CheckIDSEx(ids);
            return DBCenter.DelByIDS(TbName, PK, ids);
        }
    }
}
