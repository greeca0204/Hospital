//**********************************************
//
//文件名：AcountManager.cs
//
//描  述：量表结果信息管理操作-BLL
//
//作  者：罗家辉
//
//创建时间：2014-2-17
//
//修改历史：2014-7-7  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{ 
    public class AcountManager
    {
        IAcountService db = AbstractDALFactory.CreateDALService().GetIAcountService();
        public AcountManager()
        {
        }

        public List<Acount> GetAccount(int tid, double score)
        {
            return db.GetAccount(tid, score);
        }

        public List<Acount> GetAccountAddSex(int tid, double score, string xb,string nameItem) 
        {
            return db.GetAccountAddSex(tid, score, xb, nameItem);
        }
        /*
        public List<Acount> GetAccountAddSexButName(int tid, double score, string xb)
        {
            return db.GetAccountAddSexButName(tid, score, xb);
        }
         */
        public List<Acount> GetAccountAddName(int tid, double score, string name)
        {
            return db.GetAccountAddName(tid, score, name);
        }
        public List<Acount> GetAccountAddAge(int tid, double score, int age, string nameItem)
        {
            return db.GetAccountAddAge(tid, score, age, nameItem);
        }
        public List<string> GetName(int tid)
        {
            return db.GetName(tid);
        }
        //获取对应量表在tbl_account的量表项目数量，只有量表id和分数score作为条件
        public int GetNum(int tid)
        {
            return db.GetNum(tid);
        }
        /*
        //获取对应量表在tbl_account的量表项目数量，量表tid、分数score和量表项目name作为条件
        public int GetNum(int tid, double score, string nameItem)
        {
            return db.GetNum(tid, score,nameItem);
        }
        //获取对应量表在tbl_account的量表项目数量，量表tid、分数score、量表项目name和性别xb作为条件
        public int GetNum(int tid, double score, string xb, string nameItem)
        {
            return db.GetNum(tid, score,xb, nameItem);
        }
        */
        //获取对应量表测试结果，不同的量表的获取方法可能需要自己在AccessAcountServer.cs文件中写一个方法
        public List<Acount> ChoiceAccount(int tid, double score, string sex,string name)
        { 
            List<Acount> list = null;
            switch (tid)
            {
                case 2:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 3:
                    list = GetAccount(tid, score);
                    break;
                case 4:
                    list = GetAccount(tid, score);
                    break;
                case 5:
                    list = GetAccount(tid, score);
                    break;
                case 6:
                    list = GetAccount(tid, score);
                    break;
                case 7:
                    list = GetAccount(tid, score);
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    list = GetAccount(tid, score);
                    break;
                case 13:
                    break;
                case 14:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 15:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 16:
                    break;
                case 17: 
					list = GetAccountAddName(tid, score, name);
                    break;
                case 18:
                    break;
                case 19:
                    list = GetAccount(tid, score);
                    break;
                case 20:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 21:
                     list = GetAccount(tid, score);
                    break;
                case 22:
                    list = GetAccount(tid, score);
                    break;
                case 23:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 24:
                    list = GetAccount(tid, score);
                    break;
                case 25:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 26:
                    break;
                case 27:
                    break;
                case 28:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 29:
                    list = GetAccount(tid, score);
                    break;
                case 30:
                    break;
                case 31:
                    break;
                case 32:
					list = GetAccountAddName(tid, score, name);
                    break;
                case 33:
                    list = GetAccount(tid, score);
                    break;
                case 34:
                    //list = GetAccountAddName(tid, score, name);
                    list = GetAccount(tid, score);
                    break;
                case 35:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 36:
                    break;
                case 37:
                    break;
                case 38:
                    break;
                case 39:
                    break;
                case 40:
                    break;
                case 41:
                    break;
                case 42:
                    break;
                case 43:
                    break;
                case 44:
                    list = GetAccount(tid, score);
                    break;
                case 45:
                    list = GetAccount(tid, score);
                    break;
                case 46:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 47:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 48:
                    break;
                case 49:
                    list = GetAccount(tid, score);
                    break;
                case 50:
                    list = GetAccount(tid, score);
                    break;
                case 51:
                    break;
                case 52:
                     list = GetAccount(tid,score);
                    break;
                case 53:
                    list = GetAccount(tid, score);
                    break;
                case 54:
					list = GetAccount(tid, score);
                    break;
                case 55:
                    break;
                case 56:
					list = GetAccountAddName(tid, score, name);//【余琦】
                    break;
                case 57:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 58:
                    list = GetAccount(tid, score);
                    break;
                case 59:
                    list = GetAccount(tid, score);
                    break;
                case 60:
                    list = GetAccount(tid, score);
                    break;
                case 61:
                    list = GetAccount(tid, score);
                    break;
                case 62:
                    break;
                case 63:
                    list = GetAccount(tid, score);
                    break;
                case 64:
                    break;
                case 65:
                    break;
                case 66:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 67:
                    break;
                case 68:
                    list = GetAccount(tid, score);
                    break;
                case 69:
                    list = GetAccount(tid, score);
                    break;
                case 70:
                    break;
                case 71:
                    list = GetAccount(tid, score);
                    break;
                case 72:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 73:
                    list = GetAccount(tid, score);
                    break;
                case 74:
                    list = GetAccount(tid, score);
                    break;
                case 75:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 76:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 77:
                    break;
                case 78:
                    break;
                case 79:
                    break;
                case 80:
                    break;
                case 81:
                    break;
                case 82:
                    break;
                case 83:
                    list = GetAccountAddSex(tid, score, sex, name);
                    break;
                case 84:
                    break;
                case 85:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 86:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 87:
                    break;
                case 88:
                    break;
                case 89:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 90:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 91:
                    list = GetAccount(tid, score);
                    break;
                case 92:
                    list = GetAccountAddSex(tid, score, sex, name);
                    break;
                case 93:
                    break;
                case 94:
                    list = GetAccount(tid, score);
                    break;
                case 95:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 96:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 97:
                    break;
                case 98:
                    break;
                case 99:
                    list = GetAccount(tid, score);
                    break;
                case 100:
                    break;
                case 101:
                    break;
                case 102:
                    break;
                case 103:
                    break;
                case 104:
                    break;
                case 105:
                    list = GetAccount(tid, score);
                    break;
                case 106:
                    break;
                case 107:
                    break;
                case 108:
                    list = GetAccount(tid, score);
                    break;
                case 109:
                    break;
                case 110:
                    list = GetAccount(tid,score);
                    break;
                case 111:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 112:
                    break;
                case 113:
                    list = GetAccount(tid, score);
                    break;
                case 114:
                    list = GetAccount(tid, score);
                    break;
                case 115:
                    list = GetAccount(tid, score);
                    break;
                case 116:
                    break;
                case 117:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 118:
                    list = GetAccount(tid, score);
                    break;
                case 119:
                    list = GetAccount(tid, score);
                    break;
                case 120:
                    list = GetAccountAddSex(tid, score, sex, name);
                    break;
                case 121:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 122:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 123:
                    list = GetAccount(tid, score);
                    break;
                case 124:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 125:
                    break;
                case 126:
                    {
                        list = GetAccountAddName(tid, score, name);
                    }
                    break;
                case 127:
                    break;
                case 128:
                    break;
                case 129:
                    break;
                case 130:
                    list = GetAccount(tid, score);
                    break;
                case 131:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 132:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 133:
                    break;
                case 134:
                    break;
                case 135:
                    break;
                case 136:
                    break;
                case 137:
                    break;
                case 138:
                    break;
                case 139:
                    list = GetAccount(tid, score);
                    break;
                case 140:
                    break;
                case 141:
                    break;
                case 142:
                    break;
                case 143:
                    break;
                case 144:
                    break;
                case 145:
                    break;
                case 146:
                    break;
                case 147:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 148:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 149:
                    list = GetAccount(tid, score);
                    break;
                case 150:
                    break;
                case 151:
                    break;
                case 152:
                    break;
                case 153:
                    list = GetAccountAddSex(tid, score, sex, name);
                    break;
                case 154:
                    break;
                case 155:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 156:
                    list = GetAccountAddName(tid, score, name);
                    break;
                case 157:
                    list = GetAccount(tid, score);
                    break;
                case 158:
                    break;
                case 159:
                    break;
                case 160:
                    break;
            }
            return list;
        }
    }
}
