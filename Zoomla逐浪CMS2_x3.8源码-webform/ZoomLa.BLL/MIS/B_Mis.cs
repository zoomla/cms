﻿using System;
using System.Data;
using ZoomLa.Model;
using ZoomLa.Common;
using ZoomLa.SQLDAL;
using System.Data.SqlClient;
namespace ZoomLa.BLL 
{
    public class B_Mis
    {
        public B_Mis()
        {
            strTableName = initMod.TbName;
            PK = initMod.PK;
        }
        private string PK, strTableName;
        private M_Mis initMod = new M_Mis();
        public DataTable Sel(int ID)
        {
            return Sql.Sel(strTableName, PK, ID);
        }
        public M_Mis SelReturnModel(int ID)
        {
            using (SqlDataReader reader = Sql.SelReturnReader(strTableName, PK, ID))
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
        private M_Mis SelReturnModel(string strWhere)
        {
            using (SqlDataReader reader = Sql.SelReturnReader(strTableName, strWhere))
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
        public DataTable Sel()
        {
            return Sql.Sel(strTableName);
        }
        public DataTable SelByUTT(string uname,string type,string txtkey) 
        {
            string sql = "Select * From " + strTableName + " Where ParentID=0 And Inputer=@uname And type like @type  And Title Like @txtkey Order By ID Desc";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("uname", uname), new SqlParameter("type", type), new SqlParameter("txtkey", "%"+txtkey+"%") };
            return SqlHelper.ExecuteTable(CommandType.Text,sql,sp);
        }
        public DataTable SelByField(string field, string value) 
        {
            SafeSC.CheckDataEx(field);
            string sql = "Select * From " + strTableName + " Where " + field + " =@value";
            SqlParameter[] sp = new SqlParameter[] {new SqlParameter("value",value) };
            return SqlHelper.ExecuteTable(CommandType.Text,sql,sp);
        }
        public DataTable selbytitle(string username, string type, string title)
        {
            SqlParameter[] sp =new SqlParameter[]{ 
                new SqlParameter("username",username),
                new SqlParameter("type",'%'+type+'%'),
                new SqlParameter("title",'%'+title+'%'),
            };
            return SqlHelper.ExecuteTable(CommandType.Text, "Select * From " + strTableName + " where parentid=0 and Inputer=@username and type like @type and title like @title", sp);
        }
        public bool UpdateByID(M_Mis model)
        {
            return Sql.UpdateByIDs(strTableName, PK, model.ID.ToString(), initMod.GetFieldAndPara(), initMod.GetParameters());
        }
        public bool Del(int ID)
        {
            return Sql.Del(strTableName, ID);
        }
        public int insert(M_Mis model)
        {
            return Sql.insert(strTableName, initMod.GetParameters(), initMod.GetParas(), initMod.GetFields());
            
        }
    }
}
