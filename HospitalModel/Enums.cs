//**********************************************
//
//文件名：Enums.cs
//
//描  述：系统枚举类型设置
//
//作  者：罗家辉
//
//创建时间：2014-7-14
//
//修改历史：2014-7-14  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    //性别
    public enum ESex
    {
        None = -1,
        Male = Const.MALE,
        Famale = Const.FAMALE
    }

    public enum EManage
    { 
        None = -1,
        Freeze = Const.FREEZE_USER,
        Admin = Const.ADMIN_USER,
        Common = Const.COMMON_USER
    }
}
