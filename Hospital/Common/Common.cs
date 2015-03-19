//**********************************************
//
//�ļ�����Common.cs
//
//��  �������泣����
//
//��  �ߣ��޼һ�
//
//����ʱ�䣺2014-1-15
//
//�޸���ʷ��2014-7-6  �޼һ� �޸�
//**********************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Common
    {
        public static Doctor CurrentDoctor=null;
        
        //�����Ա�
        public static Item<ESex>[] FillSexCgy()
        {
            Item<ESex>[] sexCry = new Item<ESex>[3];
            sexCry[0] = new Item<ESex>(ESex.None, "");
            sexCry[1] = new Item<ESex>(ESex.Male, "��");
            sexCry[2] = new Item<ESex>(ESex.Famale, "Ů");
            return sexCry;
        }
        
        //��̬�������ݿ�Ĳ��˷�����Ϣ
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

        //���طּ�Ȩ��
        public static Item<EManage>[] FillManageCgy()
        {
            
            Item<EManage>[] manageCry = new Item<EManage>[4];
            manageCry[0] = new Item<EManage>(EManage.None, "");
            manageCry[1] = new Item<EManage>(EManage.Freeze, "����");
            manageCry[2] = new Item<EManage>(EManage.Admin, "����Ա");
            manageCry[3] = new Item<EManage>(EManage.Common, "��ͨҽʦ");
            return manageCry;
        }

        //��̬�������ݿ�Ŀ�����Ϣ
        public static Item<int>[] FillOfficeCgy()
        {
            int rs = 0;
            OfficeManager officeManager = new OfficeManager();
            rs = officeManager.GetOfficeCnt();
            Item<int>[] officeCry = new Item<int>[rs + 2];
            List<Office> list = officeManager.GetAllOffice();
            officeCry[0] = new Item<int>(-1, "");
            officeCry[1] = new Item<int>(0,"����Ա");
            for (int i = 0; i < list.Count; i++)
            {
                officeCry[i + 2] = new Item<int>(list[i].OId, list[i].OName);
            }
            return officeCry;
        }
    }
}
