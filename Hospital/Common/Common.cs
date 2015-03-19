//**********************************************
//
//文件名：Common.cs
//
//描  述：界面常用类
//
//作  者：罗家辉
//
//创建时间：2014-1-15
//
//修改历史：2014-7-6  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Common
    {
        public static Doctor CurrentDoctor=null;
        
        //加载性别
        public static Item<ESex>[] FillSexCgy()
        {
            Item<ESex>[] sexCry = new Item<ESex>[3];
            sexCry[0] = new Item<ESex>(ESex.None, "");
            sexCry[1] = new Item<ESex>(ESex.Male, "男");
            sexCry[2] = new Item<ESex>(ESex.Famale, "女");
            return sexCry;
        }
        
        //动态加载数据库的病人分组信息
        public static Item<int>[] FillTestGroupCgy()
        {
            int rs = 0;
            TestGroupManager testGroupManager = new TestGroupManager();
            rs = testGroupManager.GetAllTestGroupCnt();
            Item<int>[] testGroupCry = new Item<int>[rs+1];
            List<TestGroup> list = testGroupManager.GetTestGroup();
            testGroupCry[0] = new Item<int>(-1, "");
            for (int i = 0; i < list.Count; i++)
            {
                testGroupCry[i+1] = new Item<int>(list[i].Gid, list[i].GName);
            }
            return testGroupCry;
        }

        //加载分级权限
        public static Item<EManage>[] FillManageCgy()
        {
            
            Item<EManage>[] manageCry = new Item<EManage>[4];
            manageCry[0] = new Item<EManage>(EManage.None, "");
            manageCry[1] = new Item<EManage>(EManage.Freeze, "冻结");
            manageCry[2] = new Item<EManage>(EManage.Admin, "管理员");
            manageCry[3] = new Item<EManage>(EManage.Common, "普通医师");
            return manageCry;
        }

        //动态加载数据库的科室信息
        public static Item<int>[] FillOfficeCgy()
        {
            int rs = 0;
            OfficeManager officeManager = new OfficeManager();
            rs = officeManager.GetOfficeCnt();
            Item<int>[] officeCry = new Item<int>[rs + 2];
            List<Office> list = officeManager.GetAllOffice();
            officeCry[0] = new Item<int>(-1, "");
            officeCry[1] = new Item<int>(0,"管理员");
            for (int i = 0; i < list.Count; i++)
            {
                officeCry[i + 2] = new Item<int>(list[i].OId, list[i].OName);
            }
            return officeCry;
        }
    }
}
