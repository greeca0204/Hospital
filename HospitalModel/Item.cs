//**********************************************
//
//文件名：Item.cs
//
//描  述：活动扳手类，泛型规范
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
    public class Item<T>
    {
        private T id;

        public T Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Item(T _id, string _name)
        {
            id = _id;
            Name = _name;
        }
    }
}
