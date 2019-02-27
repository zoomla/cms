﻿namespace ZoomLa.BLL
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using ZoomLa.Model;
    using ZoomLa.Components;
    using ZoomLa.Common;
    using System.Collections.Generic;
    using ZoomLa.SQLDAL;
    using System.Data.SqlClient;
    using System.Linq;
    using Newtonsoft.Json;
    using SQLDAL.SQL;
    /// <summary>
    /// KeyWord 的摘要说明
    /// </summary>
    public class B_KeyWord
    {
        public string TbName, PK;
        private M_KeyWord initMod = new M_KeyWord();
        public B_KeyWord()
        {
            TbName = initMod.TbName;
            PK = initMod.PK;
        }
        public DataTable Sel(int ID)
        {
            return Sql.Sel(TbName, PK, ID);
        }
        public PageSetting SelPage(int cpage, int psize)
        {
            PageSetting setting = PageSetting.Single(cpage, psize, TbName, PK, "");
            DBCenter.SelPage(setting);
            return setting;
        }
        public M_KeyWord SelReturnModel(int ID)
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
        private M_KeyWord SelReturnModel(string strWhere)
        {
            using (SqlDataReader reader = Sql.SelReturnReader(TbName, strWhere))
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
            return Sql.Sel(TbName);
        }
        public DataTable SelAll(int type, string skey = "")
        {
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@skey", "%" + skey + "%") };
            string sql = "SELECT * FROM " + TbName + " WHERE KeywordType=" + type;
            if (!string.IsNullOrEmpty(skey))
            {
                sql += " AND KeywordText LIKE @skey";
            }
            sql += " ORDER BY KeywordID DESC";
            return SqlHelper.ExecuteTable(sql, sp);
        }
        /// <summary>
        /// 用于添加和修改页,直接Json,以优先级和文字长度排序
        /// </summary>
        public string SelToJson(int type = 1)
        {
            string sql = "SELECT KeyWordText AS n FROM " + TbName + " WHERE KeyWordType=" + type + " ORDER BY Priority,LEN(KeyWordText) DESC";
            return JsonConvert.SerializeObject(SqlHelper.ExecuteTable(sql));
        }
        /// <summary>
        /// 根据ID更新
        /// </summary>
        public bool UpdateByID(M_KeyWord model)
        {
            return Sql.UpdateByIDs(TbName, PK, model.KeyWordID.ToString(), BLLCommon.GetFieldAndPara(model), model.GetParameters());
        }
        public bool Del(int ID)
        {
            return Sql.Del(TbName, ID);
        }
        public int insert(M_KeyWord model)
        {
            return Sql.insert(TbName, model.GetParameters(), BLLCommon.GetParas(model), BLLCommon.GetFields(model));
        }
        public bool Add(M_KeyWord model)
        {
            return Sql.insertID(TbName, model.GetParameters(), BLLCommon.GetParas(model), BLLCommon.GetFields(model)) > 0;
        }
        public bool DeleteByID(string ID)
        {
            return Sql.Del(TbName, PK + "=" + ID);
        }
        public DataTable GetKeyWordAll()
        {
            return Sql.Sel(TbName, "", "");
        }
        public bool Update(M_KeyWord model)
        {
            return Sql.UpdateByIDs(TbName, PK, model.KeyWordID.ToString(), BLLCommon.GetFieldAndPara(model), model.GetParameters());
        }
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// 检测并添加关键字
        /// </summary>
        /// <param name="tagkey">关键字</param>
        /// <param name="type">关键字类型</param>
        public void AddKeyWord(string tagkey, int type)
        {
            string paras = "";
            if (string.IsNullOrEmpty(tagkey)) { return; }
            string[] keyarray = tagkey.Split(',').Distinct().ToArray();//去除重复项
            if (keyarray.Length <= 0) { return; }
            SqlParameter[] sp = new SqlParameter[keyarray.Length];
            for (int i = 0; i < keyarray.Length; i++)
            {
                string name = "@key" + i;
                keyarray[i] = keyarray[i].ToString().Replace(" ", "").Replace(",", "").Replace("'", "");
                if (string.IsNullOrEmpty(keyarray[i])) { continue; }
                sp[i] = new SqlParameter(name, keyarray[i]);
                paras += name + ",";
            }
            paras = paras.TrimEnd(',');
            string sql = "SELECT * FROM ZL_Keywords WHERE KeywordText IN (" + paras + ")";
            DataTable dt = SqlHelper.ExecuteTable(sql, sp);
            for (int i = 0; i < keyarray.Length; i++)
            {
                if (string.IsNullOrEmpty(keyarray[i])) continue;
                if (dt.Select("KeywordText='" + keyarray[i] + "'").Length < 1) { insert(new M_KeyWord() { KeywordText = keyarray[i], KeywordType = type }); }
            }
        }
        public M_KeyWord GetKeyWordByid(int ID)
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
        public M_KeyWord GetKeyByName(string KeyName)
        {
            string strSql = "select * from ZL_Keywords where KeyWordText=@Key";
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Key", SqlDbType.NVarChar,200)
            };
            sp[0].Value = KeyName;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, strSql, sp))
            {
                if (reader.Read())
                {
                    return initMod.GetModelFromReader(reader);
                }
                else
                    return new M_KeyWord();
            }
        }
        public bool IsExist(string KeyName)
        {
            string strSql = "select count(KeywordID) from ZL_Keywords where KeyWordText=@Key";
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Key", SqlDbType.NVarChar,200)
            };
            sp[0].Value = KeyName;
            return SqlHelper.ExistsSql(strSql, sp);
        }
        public int GetIDByName(string KeyName)
        {
            string strSql = "select KeywordID from ZL_Keywords where KeyWordText=@Key";
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Key", SqlDbType.NVarChar,200)
            };
            sp[0].Value = KeyName;
            return SqlHelper.ObjectToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql, sp));
        }
        public int GetNameListTotal(string keyword)
        {
            string strSql = "Select count(*) from ZL_KeyWords";
            strSql = strSql + " where KeywordText like @KeywordText";
            SqlParameter[] cmdParam = new SqlParameter[] {
                new SqlParameter("@KeywordText", SqlDbType.NVarChar)
            };
            cmdParam[0].Value = "%" + keyword + "%";
            return SqlHelper.ObjectToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql, cmdParam));
        }
    }
}