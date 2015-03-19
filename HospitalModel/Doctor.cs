//**********************************************
//
//文件名：Doctor.cs
//
//描  述：医生信息管理-Model
//
//作  者：罗家辉
//
//创建时间：2014-7-14
//
//修改历史：2014-7-14  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Doctor
    {
        private int id;
        private string userName;
        private string passWord;
        private EManage rule;
        private int oid;

        public Doctor(int _id, string _userName, string _passWord, EManage _rule, int _oid)
        {
            this.id = _id;
            this.UserName = _userName;
            this.PassWord = _passWord;
            this.Rule = _rule;
            this.Oid = _oid;
        }

        public Doctor(string _userName, string _password, EManage _rule, int _oid)
            : this(0, _userName, _password, _rule, _oid) { }

        public int Id
        {
            get { return id; }
            
        }
        
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public EManage Rule
        {
            get { return rule; }
            set { rule = value; }
        }

        public int Oid
        {
            get { return oid; }
            set { oid = value; }
        }      
    }
}
