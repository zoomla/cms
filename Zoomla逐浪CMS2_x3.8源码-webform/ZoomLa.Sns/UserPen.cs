﻿/*---------------------------------------------------------------
// Copyright (C) 2008  
// 版权所有
//
// 文件名： Pen.cs
// 文件功能描述：定义数据表Pen的业务实体
//
// 创建标识：Owner(2008-10-14) 
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/
using System;


namespace BDUModel
{
    /// <summary>
    ///UserPen业务实体
    /// </summary>
    [Serializable]
    public class UserPen
    {
        #region 字段定义

        ///<summary>
        ///编号
        ///</summary>
        private Guid iD = Guid.Empty;
        ///<summary>
        ///用户ID
        ///</summary>
        private Guid userID = Guid.Empty;

        ///<summary>
        ///宠物ID
        ///</summary>
        private Guid penID = Guid.Empty;

        /// <summary>
        /// 宠物名称
        /// </summary>
        private string penName = String.Empty;

        ///<summary>
        ///购买时间
        ///</summary>
        private DateTime buyDate;

        ///<summary>
        ///等级
        ///</summary>
        private int penGrade;

        ///<summary>
        ///购买价格
        ///</summary>
        private decimal buyPrice;

        ///<summary>
        ///培养ID
        ///</summary>
        private Guid fosterID = Guid.Empty;

        ///<summary>
        ///培养开始时间
        ///</summary>
        private DateTime forsterStart;
        
        /// <summary>
        /// 宠物图片
        /// </summary>
        private string penImage = String.Empty;

        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public UserPen()
        {
        }

        ///<summary>
        ///
        ///</summary>
        public UserPen
        (
            Guid userID,
            Guid penID,
            string penName,
            DateTime buyDate,
            int penGrade,
            int buyPrice,
            Guid fosterID,
            DateTime forsterStart,
            string penImage
        )
        {
            this.userID = userID;
            this.penID = penID;
            this.penName = penName;
            this.buyDate = buyDate;
            this.penGrade = penGrade;
            this.buyPrice = buyPrice;
            this.fosterID = fosterID;
            this.forsterStart = forsterStart;
            this.penImage = penImage;

        }

        #endregion

        #region 属性定义

        ///<summary>
        ///编号
        ///</summary>
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }


        ///<summary>
        ///用户ID
        ///</summary>
        public Guid UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        ///<summary>
        ///宠物ID
        ///</summary>
        public Guid PenID
        {
            get { return penID; }
            set { penID = value; }
        }

        ///<summary>
        ///宠物名称
        ///</summary>
        public string PenName
        {
            get { return penName; }
            set { penName = value; }
        }

        ///<summary>
        ///购买时间
        ///</summary>
        public DateTime BuyDate
        {
            get { return buyDate; }
            set { buyDate = value; }
        }

        ///<summary>
        ///等级
        ///</summary>
        public int PenGrade
        {
            get { return penGrade; }
            set { penGrade = value; }
        }

        ///<summary>
        ///购买价格
        ///</summary>
        public decimal BuyPrice
        {
            get { return buyPrice; }
            set { buyPrice = value; }
        }

        ///<summary>
        ///培养ID
        ///</summary>
        public Guid FosterID
        {
            get { return fosterID; }
            set { fosterID = value; }
        }

        ///<summary>
        ///培养开始时间
        ///</summary>
        public DateTime ForsterStart
        {
            get { return forsterStart; }
            set { forsterStart = value; }
        }

        ///<summary>
        ///宠物图片
        ///</summary>
        public string  PenImage
        {
            get { return penImage; }
            set { penImage = value; }
        }
        #endregion

    }
}
