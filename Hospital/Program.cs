//**********************************************
//
//文件名：Program.cs
//
//描  述：程序入口
//
//作  者：罗家辉
//
//创建时间：2014-1-15
//
//修改历史：2014-1-15 罗家辉 创建
//**********************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginFrm());
        }
    }
}