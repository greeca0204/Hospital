//**********************************************
//
//文件名：PatientDetailManager.cs
//
//描  述：病历信息管理操作-BLL
//
//作  者：罗家辉
//
//创建时间：2014-2-17
//
//修改历史：2014-7-6  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Hospital
{
    public class PatientDetailManager
    {
        
        IPatientDetailService db = AbstractDALFactory.CreateDALService().GetIPatientDetailService();
        //ITestService db_test = AbstractDALFactory.CreateDALService().GetITestService();
        IQuestionService db_question = AbstractDALFactory.CreateDALService().GetIQuestionService();
        IOptionService db_option = AbstractDALFactory.CreateDALService().GetIOptionService();
        AcountManager acountManager = new AcountManager();
        public PatientDetailManager()
        {
        }

        public int InsertPatientDetail(PatientDetail patientDetail)
        {
            return db.InsertPatientDetail(patientDetail);
        }

        public List<PatientItem> GetPatientItemByUid(int uid)
        {
            return db.GetPatientItemByUid(uid);
        }

        public PatientItem GetPatientItemByUdid(int udid)
        {
            return db.GetPatientItemByUdid(udid);
        }

        public int DeletePatientDetail(int udid)
        {
            return db.DeletePatientDetail(udid);
        }

        public List<ExtendStatistics> GetStatisticsInfo(int fsex, int fgroup, int fage)
        {
            List<ExtendStatistics> list = db.GetStatisticsInfo(fsex, fgroup, fage);
            return list;
        }

        public List<Statistics> GetStatisticsInfoByUid(int uid)
        {
            return db.GetStatisticsInfoByUid(uid);
        }

        public int UpdateAdvice(int udid, string advice)
        {
            return db.UpdateAdvice(udid, advice);
        }

        //获取一条题目的得分
        public double GetScore(int tid, int nid, string option) 
        {
            return db.GetScore(tid, nid, option);
        }

        //计算量测试总分算法
        public void TotalPoints(int uid, int tid, int cnt, Dictionary<int, string> adic)//uid:用户id tid：量表id cnt：量表题目数 adic：key为题号，值为题目内容
        {
            /*插入答案*/
            string str = "";//答题者所选的所有答案
            double sum = 0;//总分
            List<double> list_score = new List<double>();//将有多个分数的量表放在这个链表里
            List<string> list_str = new List<string>();//将测试者选择的答案放在这里
            AcountManager acountManager = new AcountManager();
            List<string> list_name = acountManager.GetName(tid);//将相应的量表的量表名及因子名放进这里
            int ItemNum = 0;
            switch (tid)
            {
                case 2://青少年生活事件量表（ASLEC）【余琦】
                    {
                        //人际关系
                        double sum_renji = 0;
                        //学习压力
                        double sum_xuexi = 0;
                        //受惩罚
                        double sum_chengfa = 0;
                        //丧失
                        double sum_sangshi = 0;
                        //健康适应
                        double sum_jiankang = 0;
                        //其他
                        double sum_qita = 0;

                        double num = 0;
                        string str_renji = "";
                        string str_xuexi = "";
                        string str_chengfa = "";
                        string str_sangshi = "";
                        string str_jiankang = "";
                        string str_qita = "";

                        ItemNum = 7;


                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (num == 1 || num == 2 || num == 4 || num == 15 || num == 25)
                            {
                                sum_renji += GetScore(tid, i, adic[i]);
                                str_renji += adic[i];
                            }
                            if (num == 3 || num == 9 || num == 16 || num == 18 || num == 22)
                            {
                                sum_xuexi += GetScore(tid, i, adic[i]);
                                str_xuexi += adic[i];
                            }
                            if (num == 17 || num == 18 || num == 19 || num == 20 || num == 21 || num == 23 || num == 24)
                            {
                                sum_chengfa += GetScore(tid, i, adic[i]);
                                str_chengfa += adic[i];
                            }
                            if (num == 12 || num == 13 || num == 14)
                            {
                                sum_sangshi += GetScore(tid, i, adic[i]);
                                str_sangshi += adic[i];
                            }
                            if (num == 5 || num == 8 || num == 11 || num == 27)
                            {
                                sum_jiankang += GetScore(tid, i, adic[i]);
                                str_jiankang += adic[i];
                            }
                            if (num == 6 || num == 7 || num == 23 || num == 24)
                            {
                                sum_qita += GetScore(tid, i, adic[i]);
                                str_qita += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }



                        //将分数放进一个链表里
                        list_score.Add(sum_jiankang);
                        list_score.Add(sum_qita);
                        list_score.Add(sum);
                        list_score.Add(sum_renji);
                        list_score.Add(sum_sangshi);
                        list_score.Add(sum_chengfa);
                        list_score.Add(sum_xuexi);


                        //将各自的选项集放进一个集合里
                        list_str.Add(str_jiankang);
                        list_str.Add(str_qita);
                        list_str.Add(str);
                        list_str.Add(str_renji);
                        list_str.Add(str_sangshi);
                        list_str.Add(str_chengfa);
                        list_str.Add(str_xuexi);



                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 3://儿童孤独症评定量表cars edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 4://孤独量表CLS edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 5://容纳他人量表（AO） edit by 【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 6://儿童行为问卷(Conners)父母用量表 edit by 【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 7://儿童行为问卷(Conners)教师用量表 edit by 【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 8://-----------------------艾森克人格个性问卷EPQC  edit by 【王瑞】
                    break;
                case 9://-----------------------缺陷感量表(FIS)  --暂无资料
                    break;
                case 10://-----------------------康奈尔健康问卷(CMI)男性用表  --暂无资料
                    break;
                case 11://-----------------------康奈尔健康问卷(CMI)女性用表  --暂无资料
                    break;
                case 12://惧怕否定评价量表FNE edit by 【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 13://-----------------------人格诊断问卷(PDQ)  --暂无资料
                    break;
                case 14://交流恐惧自陈量表(PRCA) edit by 【张源峰】
                    {
                        double sum_erren = 18;
                        double sum_erren1 = 0;
                        double sum_erren2 = 0;
                        double sum_gongzong = 18;
                        double sum_gongzong1 = 0;
                        double sum_gongzong2 = 0;
                        double sum_huiyi = 18;
                        double sum_huiyi1 = 0;
                        double sum_huiyi2 = 0;
                        double sum_xiaozu = 18;
                        double sum_xiaozu1 = 0;
                        double sum_xiaozu2 = 0;

                        string str_erren = "";
                        string str_gongzong = "";
                        string str_huiyi = "";
                        string str_xiaozu = "";

                        

                        for (int i = 1; i <= cnt; i++)
                        {
                            if( i == 14 || i == 16 || i == 17)
                            {
                                sum_erren1 += GetScore(tid, i, adic[i]);
                                str_erren += adic[i];
                            }
                            else if (i == 13 || i == 15 || i == 18)
                            {
                                sum_erren2 -= GetScore(tid, i, adic[i]);
                                str_erren += adic[i];
                                
                            }
                            else if (i == 19 || i == 21 || i == 23)
                            {
                                sum_gongzong1 += GetScore(tid, i, adic[i]);
                                str_gongzong += adic[i];
                            }
                            else if (i == 20 || i == 22 || i == 24)
                            {
                                sum_gongzong2 -= GetScore(tid, i, adic[i]);
                                str_gongzong += adic[i]; 
                            }
                            else if (i == 8 || i == 9 || i == 12)
                            {
                                sum_huiyi1 += GetScore(tid, i, adic[i]);
                                str_huiyi += adic[i];
                            }
                            else if (i == 7 || i == 10 || i == 11)
                            {
                                sum_huiyi2 -= GetScore(tid, i, adic[i]);
                                str_huiyi += adic[i];  
                            }
                            else if (i == 2 || i == 4 || i == 6)
                            {
                                sum_xiaozu1 += GetScore(tid, i, adic[i]);
                                str_xiaozu += adic[i];
                            }
                            else if (i == 1 || i == 3 || i == 5)
                            {
                                sum_xiaozu2 -= GetScore(tid, i, adic[i]);
                                str_xiaozu += adic[i];
                            }
                                str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        //计算各因子总分
                        sum_erren += sum_erren1 + sum_erren2;
                        sum_gongzong += sum_gongzong1 + sum_gongzong2;
                        sum_huiyi += sum_huiyi1 + sum_huiyi2;
                        sum_xiaozu += sum_xiaozu1 + sum_xiaozu2;

                        //将分数放进一个链表里
                        list_score.Add(sum_erren);
                        list_score.Add(sum_gongzong);
                        list_score.Add(sum_huiyi);
                        list_score.Add(sum);
                        list_score.Add(sum_xiaozu);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_erren);
                        list_str.Add(str_gongzong);
                        list_str.Add(str_huiyi);
                        list_str.Add(str);
                        list_str.Add(str_xiaozu);

                        ItemNum = acountManager.GetNum(tid);


                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 15://社交回避及苦恼量表 zhz
                    {
                        double[] sums = new double[3];//0苦恼 1社会回避 3sum
                        string[] strs = new string[3];

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 2 || i == 4 || i == 8 || i == 9 || i == 13 || i == 17 || i == 18 || i == 19 || i == 21 || i == 22 || i == 24 || i == 25 || i == 26 || i == 27)
                            {
                                strs[0] += adic[i];
                                sums[0] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 1 || i == 3 || i == 5 || i == 6 || i == 7 || i == 10 || i == 11 || i == 12 || i == 14 || i == 15 || i == 16 || i == 20 || i == 23 || i == 28)
                            {
                                strs[1] += adic[i];
                                sums[1] += GetScore(tid, i, adic[i]);
                            }

                            strs[2] += adic[i];
                            sums[2] += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sums[0]);
                        list_score.Add(sums[1]);
                        list_score.Add(sums[2]);

                        //将各自的选项集放进一个集合里
                        list_str.Add(strs[0]);
                        list_str.Add(strs[1]);
                        list_str.Add(strs[2]);

                        for (int i = 0; i < sums.Length; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, strs[i], sums[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 16://-----------------------酒精依赖诊断量表(SCID-AD)  --暂无资料
                    break;
                case 17://自我描述问卷(SDQ) edit by 【wgs】
					{
                        double sum_yanyu = 0;//言语
                        double sum_shuxue = 0;//数学
                        double sum_xuexiao = 0;//一般学校情况
                        double sum_tineng = 0;//体能
                        double sum_waimao = 0;//外貌
                        double sum_yixing= 0;//与异性关系
                        double sum_tongxing = 0;//与同性关系
                        double sum_fumu = 0;//与父母关系
                        double sum_chengxin = 0;//诚实—可信懒
                        double sum_qingxu = 0;//情绪稳定性
                        double sum_ziwo = 0;//一般自我概念
                      
                        string str_yanyu = "";
                        string str_shuxue = "";
                        string str_xuexiao = "";
                        string str_tineng = "";
                        string str_waimao = "";
                        string str_yixing= "";
                        string str_tongxing = "";
                        string str_fumu = "";
                        string str_chengxin = "";
                        string str_qingxu = "";
                        string str_ziwo = "";
                        

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 6 || i == 17 || i == 28 || i == 39 || i == 50 || i == 61 || i == 72 || i == 83 || i == 92 || i == 99 )
                            {
                                sum_yanyu += GetScore(tid, i, adic[i]);
                                str_yanyu += adic[i];
                            }
                            else if (i == 1 || i == 12 || i == 23 || i == 34 || i == 45 || i == 56 || i == 67 || i == 78 || i == 89 || i == 96 )
                            {
                                sum_shuxue -= GetScore(tid, i, adic[i]);
                                str_shuxue += adic[i];
                                
                            }
                            else if (i == 9 || i == 20 || i == 31 || i == 42 || i == 53 || i == 64 || i == 75 || i == 86 || i == 94 || i == 101)
                            {
                                sum_xuexiao += GetScore(tid, i, adic[i]);
                                str_xuexiao += adic[i];
                            }
                            else if (i == 5 || i == 16 || i == 27 || i == 38 || i == 49 || i == 60 || i == 71 || i == 82 )
                            {
                                sum_tineng -= GetScore(tid, i, adic[i]);
                                str_tineng += adic[i]; 
                            }
                            else if (i == 2 || i == 13 || i == 24 || i == 35 || i == 46 || i == 57 || i == 68 || i == 79)
                            {
                                sum_waimao += GetScore(tid, i, adic[i]);
                                str_waimao += adic[i];
                            }
                            else if (i == 7 || i == 10 || i == 11)
                            {//与异性关系
                                sum_yixing-= GetScore(tid, i, adic[i]);
                                str_yixing += adic[i];  
                            }
                            else if (i == 2 || i == 4 || i == 6)
                            {//与同性关系
                                sum_tongxing += GetScore(tid, i, adic[i]);
                                str_tongxing += adic[i];
                            }
                            else if (i == 8 || i == 19 || i == 30 || i == 41 || i == 52 || i == 63 || i == 74 || i == 85 )
                            {//与父母关系
                                sum_fumu -= GetScore(tid, i, adic[i]);
                                str_fumu += adic[i];
                            }
                            else if (i == 4 || i == 15 || i == 26 || i == 37 || i == 48 || i == 59 || i == 70 || i == 81 || i == 91 || i == 98 )
                            {//诚实可信懒
                                sum_chengxin += GetScore(tid, i, adic[i]);
                                str_chengxin += adic[i];
                            }
                            else if (i == 7 || i == 18 || i == 29 || i == 40 || i == 51 || i == 62 || i == 73 || i == 84 || i == 93 || i == 100)
                            {//情绪稳定性
                                sum_qingxu += GetScore(tid, i, adic[i]);
                                str_qingxu += adic[i];
                            }
                            else if (i == 3 || i == 14 || i == 25 || i == 36 || i == 47 || i == 58 || i == 69 || i == 80 || i == 90 || i == 97)
                            {//一般自我概念
                                sum_ziwo += GetScore(tid, i, adic[i]);
                                str_ziwo += adic[i];
                            }

                                str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        //计算各因子总分
                        sum_yanyu= sum_yanyu/10;
                        sum_shuxue =sum_shuxue/10;
                        sum_xuexiao = sum_xuexiao / 10;
                        sum_tineng = sum_tineng / 8;
                        sum_waimao = sum_waimao / 8;
                        sum_yixing = sum_yixing / 8;
                        sum_tongxing = sum_tongxing / 10;
                        sum_fumu = sum_fumu / 8;
                        sum_chengxin = sum_chengxin / 10;
                        sum_qingxu = sum_qingxu / 10;
                        sum_ziwo = sum_ziwo / 10;
                      
                        //将分数放进一个链表里
                        list_score.Add(sum_yanyu);
                        list_score.Add(sum_shuxue);
                        list_score.Add(sum_xuexiao);
                        list_score.Add(sum_tineng);
                        list_score.Add(sum_waimao);
                        list_score.Add(sum_yixing);
                        list_score.Add(sum_tongxing);
                        list_score.Add(sum_fumu);
                        list_score.Add(sum_chengxin);
                        list_score.Add(sum_qingxu);
                        list_score.Add(sum_ziwo);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_yanyu);
                        list_str.Add(str_shuxue);
                        list_str.Add(str_xuexiao);
                        list_str.Add(str_tineng);
                        list_str.Add(str_waimao);
                        list_str.Add(str_yixing);
                        list_str.Add(str_tongxing);
                        list_str.Add(str_fumu);
                        list_str.Add(str_chengxin);
                        list_str.Add(str_qingxu);
                        list_str.Add(str_ziwo);

                        ItemNum = acountManager.GetNum(tid);


                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 18://-----------------------瑞文标准推理测试【王瑞】
                    break;
                case 19://自尊调查表（SEI）【王瑞】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 20://多伦多述情障碍量表 by zhz
                    {
                        double sum_option1 = 0;//描述情感的能力
                        double sum_option2 = 0;//认识和区分情感与躯体感受的能力
                        double sum_option3 = 0;//缺乏幻想
                        double sum_option4 = 0;//外向性思维

                        string str_option1 = "";
                        string str_option2 = "";
                        string str_option3 = "";
                        string str_option4 = "";


                        ItemNum = 5;//表N个分类

                        // 1 5 6 9 11 12 13 15 16 21 24 反向
                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 4 || i == 8 || i == 12 || i == 22 || i == 23 || i == 26)
                            {
                                sum_option1 += GetScore(tid, i, adic[i]);
                                str_option1 += adic[i];
                            }
                            else if (i == 1 || i == 3 || i == 10 || i == 14 || i == 17 || i == 20 || i == 25)
                            {
                                sum_option2 += GetScore(tid, i, adic[i]);
                                str_option2 += adic[i];
                            }
                            else if (i == 2 || i == 5 || i == 15 || i == 16 || i == 18)
                            {
                                sum_option3 += GetScore(tid, i, adic[i]);
                                str_option3 += adic[i];
                            }
                            // 1 5 6 9 11 12 13 15 16 21 24 反向
                            else if (i == 6 || i == 7 || i == 9 || i == 11 || i == 13 || i == 19 || i == 21 || i == 24)
                            {
                               
                               sum_option4 += GetScore(tid, i, adic[i]);
                               str_option4 += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_option2);
                        list_score.Add(sum_option1);
                        list_score.Add(sum_option3);
                        list_score.Add(sum_option4);


                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_option2);
                        list_str.Add(str_option1);
                        list_str.Add(str_option3);
                        list_str.Add(str_option4);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 21://内-外在心理控制源量表（IELCS）edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 22://婚姻调适测定 edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 23://阳性与阴性症状量表(PANSS) by gqy                   
                    {
                        double sum_yangxing = 0;//阳性量表总分（P1-P7）
                        double sum_yinxing = 0;//阴性量表总分（N1-N7）
                        double sum_ybjsbl = 0;//一般精神病理量表总分（G0-G16）

                        string str_yangxing ="";
                        string str_yinxing = "";
                        string str_ybjsbl ="";
                         
                        ItemNum = 4;
                        for (int i = 1; i <= cnt; i++)
                        {
                            if ( i< 8 )
                            {
                                sum_yangxing += GetScore(tid, i, adic[i]);
                                str_yangxing += adic[i];
                            }
                            else if (i >= 8 && i < 15)
                            {
                                sum_yinxing += GetScore(tid, i, adic[i]);
                                str_yinxing += adic[i];
                            }
                            else if (i >= 15 && i < 34)
                            {
                                sum_ybjsbl += GetScore(tid, i, adic[i]);
                                str_ybjsbl += adic[i];
                            }
                           sum += GetScore(tid, i, adic[i]);
                           str += adic[i];
                        }
                        list_score.Add(sum_yangxing);
                        list_score.Add(sum);
                        list_score.Add(sum_ybjsbl);
                        list_score.Add(sum_yinxing);

                        list_str.Add(str_yangxing);
                        list_str.Add(str);
                        list_str.Add(str_ybjsbl);
                        list_str.Add(str_yinxing);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 24://羞怯量表 edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 25://儿童感觉统合能力发展评定量表
                    {
                        double sum_bentigan = 0;
                        double sum_chujue = 0;
                        double sum_daning = 0;
                        double sum_qianting = 0;
                        double sum_xuexi = 0;
                        string str_bentigan = "";
                        string str_chujue = "";
                        string str_daning = "";
                        string str_qianting = "";
                        string str_xuexi = "";
                        ItemNum = 6;
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        sum_bentigan = sum;
                        sum_chujue = sum;
                        sum_daning = sum;
                        sum_qianting = sum;
                        sum_xuexi = sum;
                        str_bentigan = str;
                        str_chujue = str;
                        str_daning = str;
                        str_qianting = str;
                        str_xuexi = str;
                        //将分数放进一个链表里
                        list_score.Add(sum_bentigan);
                        list_score.Add(sum_chujue);
                        list_score.Add(sum_daning);
                        list_score.Add(sum);
                        list_score.Add(sum_qianting);
                        list_score.Add(sum_xuexi);
                        //将各自的选项集放进一个集合里
                        list_str.Add(str_bentigan);
                        list_str.Add(str_chujue);
                        list_str.Add(str_daning);
                        list_str.Add(str);
                        list_str.Add(str_qianting);
                        list_str.Add(str_xuexi);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 26://-----------------------个人评价问卷(PEI)  --暂无资料
                    break;
                case 27://-----------------------治疗副反应量表(TESS)  --暂无资料
                    break;
                case 28://生活质量综合评定问卷(GQLI) edit by 【wgs】
                    {
                        double sum_zhufang = 0;
                        double sum_shequ = 0;
                        double sum_huanjing = 0;
                        double sum_jingji = 0;
                        double sum_shuimian = 0;
                        double sum_quti = 0;
                        double sum_jinshi = 0;
                        double sum_sex = 0;
                        double sum_yundong = 0;
                        double sum_jingshen = 0;
                        double sum_fuxingqing = 0;
                        double sum_zhengxingqing = 0;
                        double sum_renzhi = 0;
                        double sum_zizun = 0;
                        double sum_zhichi = 0;
                        double sum_renji = 0;
                        double sum_workstudy = 0;
                        double sum_yule = 0;
                        double sum_merry = 0;
                        double sum_lifequantity = 0;
                        //定义四个维度
                        double sum_qtfun = 0;
                        double sum_xlfun = 0;
                        double sum_socity = 0;
                        double sum_wuzhi = 0;


                        string str_zhufang = "";
                        string str_shequ = "";
                        string str_huanjing = "";
                        string str_jingji = "";
                        string str_shuimian = "";
                        string str_quti = "";
                        string str_jinshi = "";
                        string str_sex = "";
                        string str_yundong = "";
                        string str_jingshen = "";
                        string str_fuxingqing = "";
                        string str_zhengxingqing = "";
                        string str_renzhi = "";
                        string str_zizun = "";
                        string str_zhichi = "";
                        string str_renji = "";
                        string str_workstudy = "";
                        string str_yule = "";
                        string str_merry = "";
                        string str_lifequantity = "";
                        //定义维度

                        string str_qtfun = "";
                        string str_xlfun = "";
                        string str_socity = "";
                        string str_wuzhi = "";



                        ItemNum = 20;
                        for (int i = 1; i <= 20; i++)
                        {
                            int num = 1;
                            double temp_sum = 0;
                            if (num == 1 || num == 2 || num == 3)
                            {
                                temp_sum = GetScore(tid, 28, adic[1]) + GetScore(tid, 28, adic[2]) + GetScore(tid, 28, adic[3]) * 3;
                                sum_zhufang = (temp_sum - 4) * 100 / 16;
                                str_zhufang += adic[i];
                            }
                            else if (num == 4 || num == 5)
                            {
                                temp_sum = (GetScore(tid, 28, adic[4]) + GetScore(tid, 28, adic[5])) * 2;
                                sum_shequ = (temp_sum - 4) * 100 / 16;
                                str_shequ += adic[i];

                            }
                            else if (num == 6 || num == 7)
                            {
                                temp_sum = (GetScore(tid, 28, adic[6]) + GetScore(tid, 28, adic[7])) * 2;
                                sum_huanjing = (temp_sum - 4) * 100 / 16;
                                str_huanjing += adic[i];

                            }
                            else if (num == 8 || num == 9 || num == 10)
                            {
                                temp_sum = GetScore(tid, 28, adic[8]) * 1.4 + GetScore(tid, 28, adic[9]) * 0.6 + GetScore(tid, 28, adic[10]) * 2;
                                sum_jingji = (temp_sum - 4) * 100 / 16;
                                str_jingji += adic[i];

                            }

                            else if (num == 11 || num == 12 || num == 13 || num == 14 || num == 15)
                            {
                                //(F11+F12)／2+F13+F14+F15
                                temp_sum = (GetScore(tid, 28, adic[11]) + GetScore(tid, 28, adic[12])) * 2 + GetScore(tid, 28, adic[13]) + GetScore(tid, 28, adic[14]) + GetScore(tid, 28, adic[15]);

                                sum_shuimian = (temp_sum - 4) * 100 / 16;
                                str_shuimian += adic[i];

                            }
                            else if (num == 16 || num == 17 || num == 18 || num == 19)
                            {
                                //(F16+17+18)／1．5+F19×2
                                temp_sum = (GetScore(tid, 28, adic[16]) + GetScore(tid, 28, adic[17]) + GetScore(tid, 28, adic[18])) * 1.5 + GetScore(tid, 28, adic[13]) * 2;

                                sum_quti = (temp_sum - 4) * 100 / 16;
                                str_quti += adic[i];
                            }

                            else if (num == 20 || num == 21 || num == 22)
                            {//F20+F21+F22×2
                                temp_sum = GetScore(tid, 28, adic[20]) + GetScore(tid, 28, adic[21]) + GetScore(tid, 28, adic[22]) * 2;
                                sum_jinshi = (temp_sum - 4) * 100 / 16;
                                str_jinshi += adic[i];

                            }
                            else if (num == 23 || num == 23 || num == 25)
                            {//F23+F24+F25×2
                                temp_sum = GetScore(tid, 28, adic[21]) + GetScore(tid, 28, adic[22]) + GetScore(tid, 28, adic[23]) * 2;
                                sum_sex = (temp_sum - 4) * 100 / 6;
                                str_sex += adic[i];

                            }
                            else if (num == 26 || num == 27 || num == 28 || num == 29 || num == 30)
                            {//F26+(F27+F28)*2+F29+F30
                                temp_sum = GetScore(tid, 28, adic[26]) + (GetScore(tid, 28, adic[27]) + GetScore(tid, 28, adic[28])) * 2 + GetScore(tid, 28, adic[29]) + GetScore(tid, 28, adic[30]);
                                sum_yundong = (temp_sum - 4) * 100 / 16;
                                str_yundong += adic[i];

                            }

                            else if (num == 31 || num == 32 || num == 33 || num == 50)
                            {//(F31+F32+F50)／1．5+F33×2
                                temp_sum = (GetScore(tid, 28, adic[31]) + GetScore(tid, 28, adic[32]) + GetScore(tid, 28, adic[50])) * 1.5 + GetScore(tid, 28, adic[33]) * 2;
                                sum_jingshen = (temp_sum - 4) * 100 / 16;
                                str_jingshen += adic[i];

                            }
                            else if (num == 34 || num == 35 || num == 36 || num == 37)
                            {//F34+F35+F36+F37
                                temp_sum = GetScore(tid, 28, adic[34]) + GetScore(tid, 28, adic[35]) + GetScore(tid, 28, adic[36]) + GetScore(tid, 28, adic[37]);
                                sum_fuxingqing = (temp_sum - 4) * 100 / 16;
                                str_fuxingqing += adic[i];

                            }
                            else if (num == 38 || num == 39 || num == 40)
                            {//F38+F39+F40×2
                                temp_sum = GetScore(tid, 28, adic[38]) + GetScore(tid, 28, adic[39]) + GetScore(tid, 28, adic[40]) * 2;
                                sum_zhengxingqing = (temp_sum - 4) * 100 / 16;
                                str_zhengxingqing += adic[i];
                            }
                            else if (num == 41 || num == 42 || num == 43 || num == 44 || num == 45)
                            {//(F41+F42+F43+F44)／2+F45×2
                                temp_sum = (GetScore(tid, 28, adic[41]) + GetScore(tid, 28, adic[42]) + GetScore(tid, 28, adic[43]) + GetScore(tid, 28, adic[44])) / 2 + GetScore(tid, 28, adic[45]) * 2;
                                sum_renzhi = (temp_sum - 4) * 100 / 16;
                                str_renzhi += adic[i];
                            }
                            else if (num == 46 || num == 47 || num == 48 || num == 49)
                            {//F46+F47+F48+F49
                                temp_sum = GetScore(tid, 28, adic[46]) + GetScore(tid, 28, adic[47]) + GetScore(tid, 28, adic[48]) + GetScore(tid, 28, adic[49]);
                                sum_zizun = (temp_sum - 4) * 100 / 16;
                                str_zizun += adic[i];
                            }
                            else if (num == 51 || num == 52 || num == 53 || num == 54)
                            {//F51+F52+F53+F54
                                temp_sum = GetScore(tid, 28, adic[51]) + GetScore(tid, 28, adic[52]) + GetScore(tid, 28, adic[53]) + GetScore(tid, 28, adic[54]);
                                sum_zhichi = (temp_sum - 4) * 100 / 16;
                                str_zhichi += adic[i];
                            }
                            else if (num == 55 || num == 56 || num == 57)
                            {//F55+F56+F57×2
                                temp_sum = GetScore(tid, 28, adic[55]) + GetScore(tid, 28, adic[56]) + GetScore(tid, 28, adic[57]) * 2;
                                sum_renji = (temp_sum - 4) * 100 / 16;
                                str_renji += adic[i];
                            }
                            else if (num == 58 || num == 59 || num == 63 || num == 64 || num == 65)
                            {//(F58+F59)／2+(F63+F64)，2+F65×2
                                temp_sum = (GetScore(tid, 28, adic[58]) + GetScore(tid, 28, adic[59])) / 2 + (GetScore(tid, 28, adic[63]) + GetScore(tid, 28, adic[64]) + GetScore(tid, 28, adic[65])) * 2;
                                sum_workstudy = (temp_sum - 4) * 100 / 16;
                                str_workstudy += adic[i];
                            }
                            else if (num == 60 || num == 61 || num == 62)
                            {//F60+F61+F62×2
                                temp_sum = GetScore(tid, 28, adic[60]) + GetScore(tid, 28, adic[61]) + GetScore(tid, 28, adic[62]) * 2;
                                sum_yule = (temp_sum - 4) * 100 / 16;
                                str_yule += adic[i];
                            }
                            else if (num == 66 || num == 67 || num == 68 || num == 69 || num == 70)
                            {//(F66+F67)／2+F68+F69+F70
                                temp_sum = (GetScore(tid, 28, adic[66]) + GetScore(tid, 28, adic[67])) / 2 + GetScore(tid, 28, adic[68]) + GetScore(tid, 28, adic[69]) + GetScore(tid, 28, adic[70]);
                                sum_merry = (temp_sum - 4) * 100 / 16;
                                str_merry += adic[i];
                            }
                            else if (num == 71 || num == 72 || num == 73 || num == 74)
                            {//Gl+G2+G3+G4
                                temp_sum = GetScore(tid, 28, adic[71]) + GetScore(tid, 28, adic[72]) + GetScore(tid, 28, adic[73]) + GetScore(tid, 28, adic[74]);
                                sum_lifequantity = (temp_sum - 4) * 100 / 16;
                                str_lifequantity += adic[i];
                            }

                        }


                        sum_qtfun = (sum_shuimian + sum_quti + sum_jingji + sum_sex + sum_yundong - 20) * 100 / 80;
                        sum_xlfun = (sum_jingshen + sum_fuxingqing + sum_zhengxingqing + sum_renzhi - 20) * 100 / 80;
                        sum_socity = (sum_zizun + sum_zhichi + sum_renji + sum_workstudy + sum_yule + sum_merry - 20) * 100 / 80;
                        sum_wuzhi = (sum_zhufang + sum_shequ + sum_huanjing + sum_jingji - 16) * 100 / 64;
                        sum = (sum_zhufang + sum_shequ + sum_huanjing + sum_jingji + sum_shuimian + sum_quti + sum_jingji + sum_sex + sum_yundong + sum_jingshen + sum_fuxingqing + sum_zhengxingqing + sum_renzhi + sum_zizun + sum_zhichi + sum_renji + sum_workstudy + sum_yule + sum_merry - 80) * 100 / 32;


                        //将分数放进一个链表里
                        list_score.Add(sum_qtfun);
                        list_score.Add(sum_xlfun);
                        list_score.Add(sum_socity);
                        list_score.Add(sum_wuzhi);
                        list_score.Add(sum);


                        //将各自的选项集放进一个集合里
                        list_str.Add(str_qtfun);
                        list_str.Add(str_xlfun);
                        list_str.Add(str_socity);
                        list_str.Add(str_wuzhi);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 1; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }

                    }
                    break;
                case 29://人际信任量表edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 30://-----------------------爱德华个性偏好量表 edit by【王瑞】
                    break;
                case 31://-----------------------职业兴趣问卷  --暂无资料
                    break;
                case 32://小学生心理健康综合测量 edit by 【wgs】
					{
                        //成就动机
                        double sum_chengjiu = 0;
                        //学习兴趣
                        double sum_xingqu = 0;
                        //意志力
                        double sum_yizhi = 0;
                        //学习习惯
                        double sum_xiguan = 0;
                        //自信心
                        double sum_zixin = 0;
                        double num = 0;

                        string str_chengjiu = "";
                        string str_xingqu = "";
                        string str_yizhi = "";
                        string str_xiguan = "";
                        string str_zixin = "";

                        ItemNum = 6;

                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (1<= num && num<= 20)
                            {
                                sum_chengjiu += GetScore(tid, i, adic[i]);
                                str_chengjiu += adic[i];
                            }
                            if (21 <= num && num <= 43)
                            {
                                sum_xingqu += GetScore(tid, i, adic[i]);
                                str_xingqu += adic[i];
                            }
                            if (44 <= num && num <= 69)
                            {
                                sum_yizhi += GetScore(tid, i, adic[i]);
                                str_yizhi += adic[i];
                            }
                            if (70 <= num && num <= 89)
                            {
                                sum_xiguan += GetScore(tid, i, adic[i]);
                                str_xiguan += adic[i];
                            }
                            if (90 <= num && num <= 109)
                            {
                                sum_zixin += GetScore(tid, i, adic[i]);
                                str_zixin += adic[i];
                            }
                            
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        //将分数放进一个链表里
                        list_score.Add(sum);//总分
                        list_score.Add(sum_chengjiu);
                        list_score.Add(sum_xingqu);
                        list_score.Add(sum_yizhi);
                        list_score.Add(sum_xiguan);
                        list_score.Add(sum_zixin);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_chengjiu);
                        list_str.Add(str_xingqu);
                        list_str.Add(str_yizhi);
                        list_str.Add(str_xiguan);
                        list_str.Add(str_zixin);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 33://考试焦虑量表 edit by【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
				case 34://阴性症状量表 by zhz
                    {
                        /*
						double sum_option1 = 0;//情感平淡或迟钝
                        double sum_option2 = 0;//思维贫乏
                        double sum_option3 = 0;//意志缺乏
                        double sum_option4 = 0;//兴趣社交缺乏
                        double sum_option5 = 0;//注意障碍

                        string str_option1 = "";
                        string str_option2 = "";
                        string str_option3 = "";
                        string str_option4 = "";
                        string str_option5 = "";

                        ItemNum = 5;//表N个分类

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i < 8)
                            {
                                sum_option1 += GetScore(tid, i, adic[i]);
                                str_option1 += adic[i];
                            }
                            else if (i > 7 || i < 13)
                            {
                                sum_option2 += GetScore(tid, i, adic[i]);
                                str_option2 += adic[i];
                            }
                            else if (i > 12 || i < 17)
                            {
                                sum_option3 += GetScore(tid, i, adic[i]);
                                str_option3 += adic[i];
                            }
                            else if (i > 16 || i < 22)
                            {
                                sum_option4 += GetScore(tid, i, adic[i]);
                                str_option4 += adic[i];
                            }
                            else if (i > 21)
                            {
                                sum_option5 += GetScore(tid, i, adic[i]);
                                str_option5 += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_option1);
                        list_score.Add(sum_option2);
                        list_score.Add(sum_option3);
                        list_score.Add(sum_option4);
                        list_score.Add(sum_option5);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_option1);
                        list_str.Add(str_option2);
                        list_str.Add(str_option3);
                        list_str.Add(str_option4);
                        list_str.Add(str_option5);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
						*/
						
						
						
						
						
						
						
			
						
						for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 35://SCL-90项症状清单edit by 【wgs】
                    {
                        double sum_somatization = 0;//躯体化
                        double sum_obsessive = 0;//强迫症状
                        double sum_interpersonal = 0;//人际关系敏感
                        double sum_depression = 0;//抑郁
                        double sum_anxiety = 0;//焦虑
                        double sum_hostility = 0;//敌对
                        double sum_photic = 0;//恐怖
                        double sum_paranoid = 0;//偏执
                        double sum_psychoticism = 0;//精神病
                        double sum_ext = 0;//其他

                        double num = 0;
                        string str_somatization = "";
                        string str_obsessive = "";
                        string str_interpersonal = "";
                        string str_depression = "";
                        string str_anxiety = "";
                        string str_hostility = "";
                        string str_photic = "";
                        string str_paranoid = "";
                        string str_psychoticism = "";
                        string str_ext = "";


                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (num == 1 || num == 4 || num == 12 || num == 27 || num == 40 || num == 42 || num == 48 || num == 49 || num == 52 || num == 53 || num == 56 || num == 58)
                            {
                                sum_somatization += GetScore(tid, i, adic[i]);
                                str_somatization += adic[i];
                            }
                            else if (num == 3 || num == 9 || num == 10 || num == 28 || num == 38 || num == 45 || num == 46 || num == 51 || num == 55 || num == 65)
                            {
                                sum_obsessive += GetScore(tid, i, adic[i]);
                                str_obsessive += adic[i];
                            }
                            else if (num == 6 || num == 21 || num == 34 || num == 36 || num == 37 || num == 41 || num == 61 || num == 69 || num == 73)
                            {

                                sum_interpersonal += GetScore(tid, i, adic[i]);
                                str_interpersonal += adic[i];

                            }
                            else if (num == 5 || num == 14 || num == 15 || num == 20 || num == 22 || num == 26 || num == 29 || num == 30 || num == 31 || num == 32 || num == 54 || num == 71 || num == 79)
                            {

                                sum_depression += GetScore(tid, i, adic[i]);
                                str_depression += adic[i];

                            }
                            else if (num == 2 || num == 17 || num == 23 || num == 33 || num == 39 || num == 57 || num == 72 || num == 78 || num == 80 || num == 86)
                            {

                                sum_anxiety += GetScore(tid, i, adic[i]);
                                str_anxiety += adic[i];

                            }
                            else if (num == 11 || num == 24 || num == 63 || num == 67 || num == 74 || num == 81)
                            {

                                sum_hostility += GetScore(tid, i, adic[i]);
                                str_hostility += adic[i];

                            }
                            else if (num == 13 || num == 25 || num == 47 || num == 50 || num == 70 || num == 75 || num == 82)
                            {

                                sum_photic += GetScore(tid, i, adic[i]);
                                str_photic += adic[i];

                            }
                            else if (num == 8 || num == 18 || num == 43 || num == 68 || num == 76 || num == 83)
                            {

                                sum_paranoid += GetScore(tid, i, adic[i]);
                                str_paranoid += adic[i];

                            }
                            else if (num == 7 || num == 16 || num == 35 || num == 62 || num == 77 || num == 84 || num == 85 || num == 87 || num == 88 || num == 90)
                            {

                                sum_psychoticism += GetScore(tid, i, adic[i]);
                                str_psychoticism += adic[i];

                            }
                            else if (num == 19 || num == 44 || num == 59 || num == 60 || num == 64 || num == 66 || num == 89)
                            {

                                sum_ext += GetScore(tid, i, adic[i]);
                                str_ext += adic[i];

                            }
                        }
                            //将分数放进一个链表里
                            list_score.Add(sum);
                            list_score.Add(sum_hostility);
                            list_score.Add(sum_anxiety);
                            list_score.Add(sum_psychoticism);
                            list_score.Add(sum_photic);
                            list_score.Add(sum_ext);
                            list_score.Add(sum_obsessive);
                            list_score.Add(sum_photic);
                            list_score.Add(sum_somatization);
                            list_score.Add(sum_interpersonal);
                            list_score.Add(sum_depression);
                   
                            //将各自的选项集放进一个集合里
                            list_str.Add(str);
                            list_str.Add(str_hostility);
                            list_str.Add(str_anxiety);
                            list_str.Add(str_psychoticism);
                            list_str.Add(str_photic);
                            list_str.Add(str_ext);
                            list_str.Add(str_obsessive);
                            list_str.Add(str_photic);
                            list_str.Add(str_somatization);
                            list_str.Add(str_interpersonal);
                            list_str.Add(str_depression);

                            ItemNum = acountManager.GetNum(tid);
                            for (int i =0; i < ItemNum; i++)
                            {
                                PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                                InsertPatientDetail(patientDetail);
                            }
                    }
                    break;
                case 36://-----------------------2-3岁儿童行为检查表(CBCL)  --暂无资料
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
                case 44://44.焦虑自评量表(SAS)【余琦】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        sum = Math.Truncate(sum *= 1.25);
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 45: //45.抑郁自评量表（SDS）【余琦】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        sum = Math.Truncate(sum *= 1.25);
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 46://卡特尔16种人格因素测验（16PF）zhz
                    {
                        double[] sums = new double[17];//包括sum
                        string[] strs = new string[17] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 3 || i == 26 || i == 27 || i == 51 || i == 52 || i == 76 || i == 101 || i == 126 || i == 151 || i == 176)
                            {//a乐群性
                                sums[0] += GetScore(tid, i, adic[i]);
                                strs[0] += adic[i];
                            }
                            else if (i == 28 || i == 53 || i == 54 || i == 77 || i == 78 || i == 102 || i == 103 || i == 127 || i == 128 || i == 152 || i == 153 || i == 177 || i == 178 || i == 180)
                            {//b聪慧性
                                sums[1] += GetScore(tid, i, adic[i]);
                                strs[1] += adic[i];
                            }
                            else if (i == 4 || i == 5 || i == 29 || i == 30 || i == 55 || i == 79 || i == 80 || i == 104 || i == 105 || i == 129 || i == 130 || i == 154 || i == 179)
                            {//c稳定性
                                sums[2] += GetScore(tid, i, adic[i]);
                                strs[2] += adic[i];
                            }
                            else if (i == 6 || i == 7 || i == 31 || i == 32 || i == 56 || i == 57 || i == 81 || i == 106 || i == 131 || i == 155 || i == 156 || i == 180 || i == 181)
                            {//e恃强性
                                sums[3] += GetScore(tid, i, adic[i]);
                                strs[3] += adic[i];
                            }
                            else if (i == 8 || i == 33 || i == 58 || i == 82 || i == 83 || i == 107 || i == 108 || i == 132 || i == 133 || i == 157 || i == 158 || i == 182 || i == 183)
                            {//f兴奋性
                                sums[4] += GetScore(tid, i, adic[i]);
                                strs[4] += adic[i];
                            }
                            else if (i == 9 || i == 34 || i == 59 || i == 84 || i == 109 || i == 134 || i == 159 || i == 160 || i == 184 || i == 185)
                            {//g有恒性
                                sums[5] += GetScore(tid, i, adic[i]);
                                strs[5] += adic[i];
                            }
                            else if (i == 10 || i == 35 || i == 36 || i == 60 || i == 61 || i == 85 || i == 86 || i == 110 || i == 111 || i == 135 || i == 136 || i == 161 || i == 186)
                            {//h敢为性
                                sums[6] += GetScore(tid, i, adic[i]);
                                strs[6] += adic[i];
                            }
                            else if (i == 11 || i == 12 || i == 37 || i == 62 || i == 87 || i == 112 || i == 137 || i == 138 || i == 162 || i == 163)
                            {//i敏感性
                                sums[7] += GetScore(tid, i, adic[i]);
                                strs[7] += adic[i];
                            }
                            else if (i == 13 || i == 38 || i == 63 || i == 64 || i == 88 || i == 89 || i == 113 || i == 114 || i == 139 || i == 164)
                            {//l怀疑性
                                sums[8] += GetScore(tid, i, adic[i]);
                                strs[8] += adic[i];
                            }
                            else if (i == 14 || i == 15 || i == 39 || i == 40 || i == 65 || i == 90 || i == 91 || i == 115 || i == 116 || i == 140 || i == 141 || i == 165 || i == 166)
                            {//m幻想性
                                sums[9] += GetScore(tid, i, adic[i]);
                                strs[9] += adic[i];
                            }
                            else if (i == 16 || i == 17 || i == 41 || i == 42 || i == 66 || i == 67 || i == 92 || i == 117 || i == 142 || i == 167)
                            {//n世故性
                                sums[10] += GetScore(tid, i, adic[i]);
                                strs[10] += adic[i];
                            }
                            else if (i == 18 || i == 19 || i == 43 || i == 44 || i == 68 || i == 69 || i == 93 || i == 94 || i == 118 || i == 119 || i == 143 || i == 144 || i == 168)
                            {//o忧虑性
                                sums[11] += GetScore(tid, i, adic[i]);
                                strs[11] += adic[i];
                            }
                            else if (i == 20 || i == 21 || i == 45 || i == 46 || i == 70 || i == 95 || i == 120 || i == 145 || i == 169 || i == 170)
                            {//q1实验性
                                sums[12] += GetScore(tid, i, adic[i]);
                                strs[12] += adic[i];
                            }
                            else if (i == 22 || i == 47 || i == 71 || i == 72 || i == 96 || i == 97 || i == 121 || i == 122 || i == 146 || i == 171)
                            {//q2独立性
                                sums[13] += GetScore(tid, i, adic[i]);
                                strs[13] += adic[i];
                            }
                            else if (i == 23 || i == 24 || i == 48 || i == 73 || i == 98 || i == 123 || i == 147 || i == 148 || i == 172 || i == 173)
                            {//q3自律性
                                sums[14] += GetScore(tid, i, adic[i]);
                                strs[14] += adic[i];
                            }
                            else if (i == 25 || i == 49 || i == 50 || i == 74 || i == 75 || i == 99 || i == 100 || i == 124 || i == 125 || i == 149 || i == 150 || i == 174 || i == 175)
                            {//q4紧张性
                                sums[15] += GetScore(tid, i, adic[i]);
                                strs[15] += adic[i];
                            }                            
                            sums[16] += GetScore(tid, i, adic[i]);
                            strs[16] += adic[i];
                        }
                        /*
                        sums[0] /= 2;
                        sums[1] /= 2;
                        sums[2] /= 2;
                        sums[3] /= 2;
                        sums[4] /= 2;
                        sums[5] /= 2;
                        sums[6] /= 2;
                        sums[7] /= 2;
                        sums[8] /= 2;
                        sums[9] /= 2;
                        sums[10] /= 2;
                        sums[11] /= 2;
                        sums[12] /= 2;
                        sums[13] /= 2;
                        sums[14] /= 2;
                        sums[15] /= 2;
                        */
                        //将分数放进一个链表里                        
                        list_score.Add(sums[1]);
                        list_score.Add(sums[13]);
                        list_score.Add(sums[6]);
                        list_score.Add(sums[8]);
                        list_score.Add(sums[9]);
                        list_score.Add(sums[15]);                        
                        list_score.Add(sums[0]);
                        list_score.Add(sums[7]);
                        list_score.Add(sums[12]);
                        list_score.Add(sums[10]);
                        list_score.Add(sums[3]);
                        list_score.Add(sums[2]);
                        list_score.Add(sums[4]);
                        list_score.Add(sums[11]);
                        list_score.Add(sums[5]);
                        list_score.Add(sums[14]);
                        list_score.Add(sums[16]);


                        //将各自的选项集放进一个集合里
                        list_str.Add(strs[1]);
                        list_str.Add(strs[13]);
                        list_str.Add(strs[6]);
                        list_str.Add(strs[8]);
                        list_str.Add(strs[9]);
                        list_str.Add(strs[15]);                        
                        list_str.Add(strs[0]);
                        list_str.Add(strs[7]);
                        list_str.Add(strs[12]);
                        list_str.Add(strs[10]);
                        list_str.Add(strs[3]);
                        list_str.Add(strs[2]);
                        list_str.Add(strs[4]);
                        list_str.Add(strs[11]);
                        list_str.Add(strs[5]);
                        list_str.Add(strs[14]);
                        list_str.Add(strs[16]);


                        for (int i = 0; i < sums.Length; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, strs[i], sums[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 47://简明精神病评定量表（BPRS）
                    {
                        double sum_diduicy = 0;
                        double sum_jihuox = 0;
                        double sum_jiaolvyy = 0;
                        double sum_quefahl = 0;
                        double sum_siweiza = 0;

                        string str_diduicy = "";
                        string str_jihuox = "";
                        string str_jiaolvyy = "";
                        string str_quefahl = "";
                        string str_siweiza = "";

                        for (int i = 1; i <= cnt; i++)
                        {
                            
                            if(i == 1 || i == 2 || i == 5 || i == 9)
                            {
                                sum_jiaolvyy += GetScore(tid, i, adic[i]);
                                str_jiaolvyy += adic[i];
                            }
                            else if(i == 3 || i == 13 || i == 16 || i == 18)
                            {
                                sum_quefahl += GetScore(tid, i, adic[i]);
                                str_quefahl += adic[i];
                            }
                            else if(i ==  4 || i == 8 || i == 12 || i == 15)
                            {
                                sum_siweiza += GetScore(tid, i, adic[i]);
                                str_siweiza += adic[i];
                            }
                            else if (i == 6 || i == 7 || i == 17 )
                            {
                                sum_jihuox += GetScore(tid, i, adic[i]);
                                str_jihuox += adic[i];
                            }
                            else if (i == 10 || i == 11 || i == 14)
                            {
                                sum_diduicy += GetScore(tid, i, adic[i]);
                                str_diduicy += adic[i];
                            }
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }

                        //将分数放进一个链表里

                        list_score.Add(sum_diduicy);
                        list_score.Add(sum_jihuox);
                        list_score.Add(sum);
                        list_score.Add(sum_jiaolvyy);
                        list_score.Add(sum_quefahl);
                        list_score.Add(sum_siweiza);


                        //将各自的选项集放进一个集合里

                        list_str.Add(str_diduicy);
                        list_str.Add(str_jihuox);
                        list_str.Add(str);
                        list_str.Add(str_jiaolvyy);
                        list_str.Add(str_quefahl);
                        list_str.Add(str_siweiza);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 48:
                    break;
                case 49://躁狂量表 zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 50://抑郁状态问卷
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        sum /= 80.0; 
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 51:
                    
                    break;
                case 52:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()),list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 53://53.汉密顿抑郁量表（HRSD）【余琦】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 54://54.匹茨堡睡眠质量指数量表(PSQI)【余琦】
                    {
                        //Ⅰ 睡眠质量
                        double sum_quality = 0;
                        //Ⅱ入睡时间
                        double sum_latency = 0;
                        //Ⅲ睡眠时间
                        double sum_duration = 0;
                        //Ⅳ睡眠效率
                        double sum_efficiency = 0;
                        //Ⅴ睡眠障碍
                        double sum_disturbance = 0;
                        double sum_disturbance0 = 0;
                        //Ⅵ催眠药物
                        double sum_medication = 0;
                        //Ⅶ日间功能障碍
                        double sum_dysfunction = 0;


                        sum_quality = GetScore(tid, 1, adic[1]);
                        sum_latency = Math.Ceiling((GetScore(tid, 2, adic[2]) + GetScore(tid, 5, adic[5])) / 2);
                        sum_duration = GetScore(tid, 4, adic[4]);
                        sum_efficiency = GetScore(tid, 5, adic[5]);
                        for (int j = 6; j <= 14; j++)
                        {
                            sum_disturbance0 += GetScore(tid, j, adic[j]);
                        }
                        sum_disturbance = Math.Ceiling(sum_disturbance0 / 9);
                        sum_medication = GetScore(tid, 7, adic[7]);
                        sum_dysfunction = Math.Ceiling((GetScore(tid, 8, adic[8]) + GetScore(tid, 9, adic[9])) / 2);


                        for (int i = 1; i <= cnt; i++)
                        {
                            str += adic[i];
                        }
                        sum = sum_quality + sum_latency + sum_duration + sum_efficiency + sum_disturbance + sum_medication + sum_dysfunction;
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 55:
                    break;
                 case 56://56.多维度健康状况心理控制源量表(MHLC)【余琦】
                    {
                        double sum_ihlc = 0;//内控性
                        double sum_phlc = 0;//有势力的他人
                        double sum_chlc = 0;//机遇

                        string str_ihlc = "";
                        string str_phlc = "";
                        string str_chlc = "";

                        ItemNum = 4;

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 1 || i == 6 || i == 8 || i == 12 || i == 13 || i == 17)
                            {
                                sum_ihlc += GetScore(tid, i, adic[i]);
                                str_ihlc += adic[i];
                            }
                            if (i == 3 || i == 5 || i == 7 || i == 10 || i == 14 || i == 18)
                            {
                                sum_phlc += GetScore(tid, i, adic[i]);
                                str_phlc += adic[i];
                            }

                            if (i == 2 || i == 4 || i == 9 || i == 11 || i == 15 || i == 16)
                            {
                                sum_chlc += GetScore(tid, i, adic[i]);
                                str_chlc += adic[i];
                            }

                            str += adic[i];
                            sum = sum_ihlc + sum_phlc + sum_chlc;
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_ihlc);
                        list_score.Add(sum_phlc);
                        list_score.Add(sum_chlc);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_ihlc);
                        list_str.Add(str_phlc);
                        list_str.Add(str_chlc);


                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 57:
                    {
                        double sum_qingxuzt = 0;
                        double sum_qingxuty = 0;
                        double sum_shejiaozt = 0;
                        double sum_shejiaoty = 0;

                        string str_qingxuzt = "";
                        string str_qingxuty = "";
                        string str_shejiaozt = "";
                        string str_shejiaoty = "";
                         for (int i = 1; i <= cnt; i++)
                        {
                            if (1 <= i && i <= 8)
                            {
                                sum_qingxuzt += GetScore(tid, i, adic[i]);
                                str_qingxuzt += adic[i];
                            }
                            else if (9 <= i && i <= 16)
                            {
                                sum_qingxuty += GetScore(tid, i, adic[i]);
                                str_qingxuty += adic[i];
                            }
                            else if (17 <= i && i <= 23)
                            {
                                sum_shejiaozt += GetScore(tid, i, adic[i]);
                                str_shejiaozt += adic[i];
                            }
                            else if (24 <= i && i <= 30)
                            {
                                sum_shejiaoty += GetScore(tid, i, adic[i]);
                                str_shejiaoty += adic[i];
                            }
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                         }

                         //将分数放进一个链表里
                         list_score.Add(sum);
                         list_score.Add(sum_qingxuty);
                         list_score.Add(sum_qingxuzt);
                         list_score.Add(sum_shejiaoty);
                         list_score.Add(sum_shejiaozt);
        

                         //将各自的选项集放进一个集合里
                         list_str.Add(str);
                         list_str.Add(str_qingxuty);
                         list_str.Add(str_qingxuzt);
                         list_str.Add(str_shejiaoty);
                         list_str.Add(str_shejiaozt);
                    
                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 58://流调中心用抑郁量表 zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {

                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 59://老年抑郁量表
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 60://家庭功能评定(FAD)【余琦】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                           
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }


                    break;
                case 61://痴呆简易筛查量表 zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 62:
                    break;
                case 63://缺血指数量表(HIS) by zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 64:
                    break;
                case 65:
                    break;
                case 66://护士用住院病人观察量表 zhz
                    {
                        double sum_option1 = 0;//社会能力[20-(13，14，21，24，25项组分和)]×2
                        double sum_option2 = 0;//社会兴趣(4，9，15，17，19项组分和)×2
                        double sum_option3 = 0;//个人整洁[8+(8，30项组分和)-(1，16项组分和)]×2
                        double sum_option4 = 0;//激惹(2，6，10，11，12，29项组分和)×2
                        double sum_option5 = 0;//精神病表现(7，20，26，28项组分和)×2。
                        double sum_option6 = 0;//迟缓(5，22，27项组分和)×2。
                        double sum_option7 = 0;//抑郁(3，18，23项组分和)×2。
                        double sum_option8 = 0;//总积极因素：1，2，3项因子分和
                        double sum_option9 = 0;//总消极因素：4，5，6，7项因子分和
                        double sum_option10 = 0;//病情总估计：(128+总积极因素-总消极因素)。

                        double option3tmp1 = 0;
                        double option3tmp2 = 0;

                        string str_option1 = "";
                        string str_option2 = "";
                        string str_option3 = "";
                        string str_option4 = "";
                        string str_option5 = "";
                        string str_option6 = "";
                        string str_option7 = "";
                        string str_option8 = "";
                        string str_option9 = "";
                        string str_option10 = "";

                        ItemNum = 10;//表N个分类

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 13 || i == 14 || i == 21 || i == 24 || i == 25)
                            {
                                sum_option1 += GetScore(tid, i, adic[i]);
                                str_option1 += adic[i];
                            }
                            else if (i == 4 || i == 9 || i == 15 || i == 17 || i == 19)
                            {
                                sum_option2 += GetScore(tid, i, adic[i]);
                                str_option2 += adic[i];
                            }
                            else if (i == 1 || i == 8 || i == 16 || i == 30)
                            {
                                if (i == 1 || i == 8)
                                {
                                    option3tmp1 += GetScore(tid, i, adic[i]);
                                }
                                else
                                {
                                    option3tmp2 += GetScore(tid, i, adic[i]);
                                }
                                str_option3 += adic[i];
                            }
                            else if (i == 2 || i == 6 || i == 10 || i == 11 || i == 12 || i == 29)
                            {
                                sum_option4 += GetScore(tid, i, adic[i]);
                                str_option4 += adic[i];
                            }
                            else if (i == 7 || i == 20 || i == 26 || i == 28)
                            {
                                sum_option5 += GetScore(tid, i, adic[i]);
                                str_option5 += adic[i];
                            }
                            else if (i == 5 || i == 22 || i == 27)
                            {
                                sum_option6 += GetScore(tid, i, adic[i]);
                                str_option6 += adic[i];
                            }
                            else if (i == 3 || i == 18 || i == 23)
                            {
                                sum_option7 += GetScore(tid, i, adic[i]);
                                str_option7 += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        sum_option1 = (20 - sum_option1) * 2;
                        sum_option2 *= 2;
                        sum_option3 = (8 + option3tmp1 - option3tmp2) * 2;
                        sum_option4 *= 2;
                        sum_option5 *= 2;
                        sum_option6 *= 2;
                        sum_option7 *= 2;
                        sum_option8 = sum_option1 + sum_option2 + sum_option3;
                        sum_option9 = sum_option4 + sum_option5 + sum_option6 + sum_option7;
                        sum_option10 = 128 + sum_option8 - sum_option9;

                        //将分数放进一个链表里
                        list_score.Add(sum_option10);
                        list_score.Add(sum_option6);
                        list_score.Add(sum_option3);
                        list_score.Add(sum_option4);
                        list_score.Add(sum_option5);
                        list_score.Add(sum_option1);
                        list_score.Add(sum_option2);
                        list_score.Add(sum_option7);
                        list_score.Add(sum_option8);
                        list_score.Add(sum_option9);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_option10);
                        list_str.Add(str_option6);
                        list_str.Add(str_option3);
                        list_str.Add(str_option4);
                        list_str.Add(str_option5);
                        list_str.Add(str_option1);
                        list_str.Add(str_option2);
                        list_str.Add(str_option7);
                        list_str.Add(str_option8);//没用
                        list_str.Add(str_option9);
                       

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 67:
                    break;
                case 68:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 69://简易智力状态检查 zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 70:
                    break;
                case 71://生活满意度指数B(LSIB) by zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 72://婚姻质量问卷(ENRICH)【余琦】
                    {
                        double sum_lixiang = 0;//过份理想化
                        double sum_manyi = 0;//婚姻满意度
                        double sum_xingge = 0;//性格相容性
                        double sum_fuqi = 0; //夫妻交流
                        double sum_jiejue = 0;//解决冲突的方式
                        double sum_jingji = 0;//经济安排
                        double sum_yeyu = 0;//业余活动
                        double sum_sex = 0;//性生活
                        double sum_zinv = 0;//子女和婚姻
                        double sum_qinyou = 0;//与亲友的关系
                        double sum_juese = 0;//角色平等性
                        double sum_xinyang = 0;//信仰一致性


                        double num = 0;
                        double score = 0;
                        string str_lixiang = "";
                        string str_manyi = "";
                        string str_xingge = "";
                        string str_fuqi = "";
                        string str_jiejue = "";
                        string str_jingji = "";
                        string str_yeyu = "";
                        string str_sex = "";
                        string str_zinv = "";
                        string str_qinyou = "";
                        string str_juese = "";
                        string str_xinyang = "";

                      //  bool zhengxing = false;

                        ItemNum = 12;


                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            score = GetScore(tid, i, adic[i]);
                            //“负性”条目有：3， 4， 5， 6， 7， 8， 10， 12， 13， 14， 16， 17， 18， 24， 25， 26， 28，29、30、37、40、43、44、47一49、52一57、59、61、 63、64、66、69一75、77一79、81、84一88、90、92一100、101、105、106、110-112、115、117、118、123。

                           // zhengxing = (num == 1 || num == 2 || num == 9 || num == 11 || num == 15 || num == 19 || num == 20 || num == 21 || num == 22 || num == 23 || num == 27 || num == 31 || num == 32 || num == 33 || num == 34 || num == 35 || num == 36 || num == 38 || num == 39 || num == 41 || num == 42 || num == 45 || num == 46 || num == 50 || num == 51 || num == 58 || num == 60 || num == 62 || num == 65 || num == 67 || num == 68 || num == 76 || num == 80 || num == 82 || num == 83 || num == 89 || num == 91 || num == 102 || num == 103 || num == 104 || num == 107 || num == 108 || num == 109 || num == 113 || num == 114 || num == 116 || num == 119 || num == 120 || num == 121 || num == 122 || num == 124);

                         //   if (zhengxing)
                         //       score = 6 - GetScore(tid, i, adic[i]);
                         //   else
                         //       score = GetScore(tid, i, adic[i]);

                            if (num == 34 || num == 42 || num == 64 || num == 70 || num == 101 || num == 116 || num == 117 || num == 118 || num == 119 || num == 120 || num == 121 || num == 122 || num == 123 || num == 124)//①过份理想化：该因子包括34，42，64， 70， 101，116-124共14条。
                            {
                                sum_lixiang += score;
                                str_lixiang += adic[i];
                            }
                            if (num == 14 || num == 19 || num == 32 || num == 36 || num == 52 || num == 53 || num == 82 || num == 88 || num == 99 || num == 113)//②婚姻满意度：包括14，19，32，36，52，53，82，88，99，113共10条。
                            {
                                sum_manyi += score;
                                str_manyi += adic[i];
                            }
                            if (num == 8 || num == 13 || num == 24 || num == 30 || num == 37 || num == 44 || num == 63 || num == 78 || num == 95 || num == 115)//③性格相容性：包括8，13，24，30，37，44，63，78，95，115共10条。
                            {
                                sum_xingge += score;
                                str_xingge += adic[i];
                            }
                            if (num == 2 || num == 6 || num == 40 || num == 54 || num == 66 || num == 73 || num == 81 || num == 91 || num == 98 || num == 109)//④夫妻交流：包括2，6，40， 54，66，73，81，91，98，109共10条。
                            {
                                sum_fuqi += score;
                                str_fuqi += adic[i];
                            }
                            if (num == 4 || num == 10 || num == 39 || num == 58 || num == 71 || num == 74 || num == 79 || num == 83 || num == 96 || num == 112)//⑤解决冲突的方式：包括4，10，39，58，71，74， 79，83，96，112共10条。
                            {
                                sum_jiejue += score;
                                str_jiejue += adic[i];
                            }
                            if (num == 16 || num == 20 || num == 26 || num == 38 || num == 45 || num == 51 || num == 77 || num == 85 || num == 93 || num == 110)//⑥经济安排：包括16，20，26，38，45，51，77，85，93，110共10条。
                            {
                                sum_jingji += score;
                                str_jingji += adic[i];
                            }
                            if (num == 1 || num == 17 || num == 18 || num == 28 || num == 31 || num == 33 || num == 60 || num == 72 || num == 84 || num == 114)//⑦业余活动：包括1，17，18，28， 31，33，60， 72，84，114条。
                            {
                                sum_yeyu += score;
                                str_yeyu += adic[i];
                            }
                            if (num == 9 || num == 15 || num == 25 || num == 41 || num == 47 || num == 62 || num == 69 || num == 106 || num == 107 || num == 111)//⑧性生活：包括9，15，25，41，47，62，69，106，107，111共10条。
                            {
                                sum_sex += score;
                                str_sex += adic[i];
                            }
                            if (num == 5 || num == 21 || num == 35 || num == 49 || num == 50 || num == 59 || num == 67 || num == 87 || num == 94 || num == 102)//⑨子女和婚姻：包括5，21，35，49，50，59，67，87，94，102共10条。
                            {
                                sum_zinv += score;
                                str_zinv += adic[i];
                            }
                            if (num == 7 || num == 27 || num == 48 || num == 57 || num == 58 || num == 86 || num == 90 || num == 92 || num == 103 || num == 108)//⑩与亲友的关系：包括7，27，48， 57，68， 86，90， 92，103，108条。
                            {
                                sum_qinyou += score;
                                str_qinyou += adic[i];
                            }
                            if (num == 12 || num == 23 || num == 29 || num == 43 || num == 55 || num == 61 || num == 75 || num == 80 || num == 97 || num == 105)//（11）角色平等性：包括12， 23，29，43，55，61，75，80， 97， 105共10条。
                            {
                                sum_juese += score;
                                str_juese += adic[i];
                            }
                            if (num == 3 || num == 11 || num == 22 || num == 46 || num == 56 || num == 65 || num == 76 || num == 89 || num == 100 || num == 104)//（12）信仰一致性：包括3，11，22，46，56，65，76，89，100，104共10条。
                            {
                                sum_xinyang += score;
                                str_xinyang += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }



                        //将分数放进一个链表里
                        list_score.Add(sum_fuqi);
                        list_score.Add(sum_lixiang);
                        list_score.Add(sum_manyi);
                        list_score.Add(sum);
                        list_score.Add(sum_juese);
                        list_score.Add(sum_jiejue);
                        list_score.Add(sum_jingji);
                        list_score.Add(sum_xinyang);
                        list_score.Add(sum_xingge);
                        list_score.Add(sum_sex);
                        list_score.Add(sum_yeyu);
                        list_score.Add(sum_qinyou);
                        list_score.Add(sum_zinv);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_fuqi);
                        list_str.Add(str_lixiang);
                        list_str.Add(str_manyi);
                        list_str.Add(str);
                        list_str.Add(str_juese);
                        list_str.Add(str_jiejue);
                        list_str.Add(str_jingji);
                        list_str.Add(str_xinyang);
                        list_str.Add(str_xingge);
                        list_str.Add(str_sex);
                        list_str.Add(str_yeyu);
                        list_str.Add(str_qinyou);
                        list_str.Add(str_zinv);


                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 73://孤独量表（UCLA）【余琦】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 74:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 75://75.防御方式问卷(DSQ)【余琦】
                    {
                        //不成熟防御机制
                        double sum_buchengshu = 0;
                        //成熟防御机制
                        double sum_chengshu = 0;
                        //中间型防御机制
                        double sum_zhongjian = 0;
                        //掩饰因子
                        double sum_yanshi = 0;

                        double num = 0;
                        //因子1 不成熟防御机制
                        bool toushe = false;//投射：4，12，25，36，55，60，66，72，87
                        bool beidong = false;//被动攻击：2，22，39，45，54
                        bool qianyi = false;//潜意显现：7，21，27，33，46
                        bool baoyuan = false;//抱怨：69，75，82
                        bool huanxiang = false;//幻想：40
                        bool fenlie = false;//分裂：43，53，64
                        bool tuisuo = false;//退缩：9，67
                        bool qutihua = false;//躯体化：28，62
                        //因子2 成熟防御机制
                        bool shenghua = false;//升华：5，74，84
                        bool yayi = false;//压抑：3，59
                        bool youmo = false;//幽默：8，61，34
                        //因子3 中间型防御机制
                        bool fanzuoyong = false;//反作用形成：13，47，56，63，65
                        bool jiechu = false;//解除：71；78，88
                        bool zhizhi = false;//制止：10，17，29，41，50
                        bool huibi = false;//回避：32，35，49
                        bool lixianghua = false;//理想化：51，58
                        bool jiaxing = false;//假性利他：1
                        bool banwuneng = false;//伴无能之全能：11，18，23，24，30，37
                        bool geli = false;//隔离：70，76，77，83
                        bool tongyihua = false;//同一化：19
                        bool fouren = false;//否认：16，42，52
                        bool jiaowang = false;//交往倾向：80，86
                        bool xiaohao = false;//消耗倾向：73，79，85
                        bool qiwang = false;//期望：68，81
                        //因子4 掩饰因子

                        string str_buchengshu = "";
                        string str_chengshu = "";
                        string str_zhongjian = "";
                        string str_yanshi = "";

                        ItemNum = 4;


                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            //因子1 不成熟防御机制
                            toushe = (num == 4 || num == 12 || num == 25 || num == 36 || num == 55 || num == 60 || num == 66 || num == 72 || num == 87);
                            beidong = (num == 2 || num == 22 || num == 39 || num == 45 || num == 54);
                            qianyi = (num == 7 || num == 21 || num == 27 || num == 33 || num == 46);
                            baoyuan = (num == 69 || num == 75 || num == 82);
                            huanxiang = (num == 40);
                            fenlie = (num == 43 || num == 53 || num == 64);
                            tuisuo = (num == 9 || num == 67);
                            qutihua = (num == 28 || num == 62);
                            //因子2 成熟防御机制
                            shenghua = (num == 5 || num == 74 || num == 84);
                            yayi = (num == 3 || num == 59);
                            youmo = (num == 8 || num == 61 || num == 34);
                            //因子3 中间型防御机制
                            fanzuoyong = (num == 13 || num == 47 || num == 56 || num == 63 || num == 65);//反作用形成：13，47，56，63，65
                            jiechu = (num == 71 || num == 78 || num == 88);//解除：71；78，88
                            zhizhi = (num == 10 || num == 17 || num == 29 || num == 41 || num == 50);//制止：10，17，29，41，50
                            huibi = (num == 32 || num == 35 || num == 49);//回避：32，35，49
                            lixianghua = (num == 51 || num == 58);//理想化：51，58
                            jiaxing = (num == 1);//假性利他：1
                            banwuneng = (num == 11 || num == 18 || num == 23 || num == 24 || num == 30 || num == 37);//伴无能之全能：11，18，23，24，30，37
                            geli = (num == 70 || num == 76 || num == 77 || num == 83);//隔离：70，76，77，83
                            tongyihua = (num == 19);//同一化：19
                            fouren = (num == 16 || num == 42 || num == 52);//否认：16，42，52
                            jiaowang = (num == 80 || num == 86);//交往倾向：80，86
                            xiaohao = (num == 73 || num == 79 || num == 85);//消耗倾向：73，79，85
                            qiwang = (num == 68 || num == 81);//期望：68，81
                            //因子4 掩饰因子
                            if (toushe || beidong || qianyi || baoyuan || huanxiang || fenlie || tuisuo || qutihua)
                            {
                                sum_buchengshu += GetScore(tid, i, adic[i]);
                                str_buchengshu += adic[i];
                            }
                            if (shenghua || yayi || youmo)
                            {
                                sum_chengshu += GetScore(tid, i, adic[i]);
                                str_chengshu += adic[i];
                            }
                            if (fanzuoyong || jiechu || zhizhi || huibi || lixianghua || jiaxing || banwuneng || geli || tongyihua || fouren || jiaowang || xiaohao || qiwang)
                            {
                                sum_zhongjian += GetScore(tid, i, adic[i]);
                                str_zhongjian += adic[i];
                            }
                            if (num == 6 || num == 14 || num == 15 || num == 20 || num == 26 || num == 31 || num == 44 || num == 48 || num == 57)
                            {
                                sum_yanshi += GetScore(tid, i, adic[i]);
                                str_yanshi += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }



                        //将分数放进一个链表里
                        list_score.Add(sum_buchengshu);
                        list_score.Add(sum_chengshu);
                        list_score.Add(sum);
                        list_score.Add(sum_yanshi);
                        list_score.Add(sum_zhongjian);



                        //将各自的选项集放进一个集合里
                        list_str.Add(str_buchengshu);
                        list_str.Add(str_chengshu);
                        list_str.Add(str);
                        list_str.Add(str_yanshi);
                        list_str.Add(str_zhongjian);



                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 76://76.A型行为量表(TABP)★【余琦】
                    {
                        double sum_th = 0;
                        double sum_th1 = 0;
                        double sum_th2 = 0;
                        double sum_ch = 0;
                        double sum_ch1 = 0;
                        double sum_ch2 = 0;
                        double sum_l = 0;
                        double sum_l1 = 0;
                        double sum_l2 = 0;
                        string str_th = "";
                        string str_ch = "";
                        string str_l = "";

                        ItemNum = 4;
                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 2 || i == 3 || i == 6 || i == 7 || i == 10 || i == 11 || i == 19 || i == 21 || i == 22 || i == 26 || i == 29 || i == 34 || i == 38 || i == 40 || i == 42 || i == 44 || i == 46 || i == 50 || i == 53 || i == 55 || i == 58)
                            {
                                sum_th1 += GetScore(tid, i, adic[i]);
                                str_th += adic[i];
                            }
                            if (i == 14 || i == 16 || i == 30 || i == 54)
                            {
                                sum_th2 += GetScore(tid, i, adic[i]);
                                str_th += adic[i];
                            }

                            if (i == 1 || i == 4 || i == 5 || i == 9 || i == 12 || i == 15 || i == 17 || i == 23 || i == 25 || i == 27 || i == 28 || i == 31 || i == 32 || i == 35 || i == 39 || i == 41 || i == 47 || i == 57 || i == 59 || i == 60)
                            {
                                sum_ch1 += GetScore(tid, i, adic[i]);
                                str_ch += adic[i];
                            }
                            if (i == 18 || i == 36 || i == 45 || i == 49 || i == 51)
                            {
                                sum_ch2 += GetScore(tid, i, adic[i]);
                                str_ch += adic[i];
                            }

                            if (i == 8 || i == 20 || i == 24 || i == 43 || i == 56)
                            {
                                sum_l1 += GetScore(tid, i, adic[i]);
                                str_l += adic[i];
                            }
                            if (i == 13 || i == 33 || i == 37 || i == 48 || i == 52)
                            {
                                sum_l2 += GetScore(tid, i, adic[i]);
                                str_l += adic[i];
                            }

                            sum_th = sum_th1 + sum_th2;
                            sum_l = sum_l1 + sum_l2;
                            sum_ch = sum_ch1 + sum_ch2;

                            str += adic[i];
                            sum = sum_th + sum_ch + sum_l;
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_th);
                        list_score.Add(sum_l);
                        list_score.Add(sum_ch);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_th);
                        list_str.Add(str_l);
                        list_str.Add(str_ch);


                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
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
                case 83://儿童行为量表 zhz
                    {
                        //第二部分 公共项 1-26 
                        double[] sum_both = new double[3];
                        string[] strs_both = new string[3];

                        // 第三部分 27-148 不成熟 残忍 敌意性 多动 分裂强迫 分裂样 攻击性 活动能力 交往不良 焦虑强迫 强迫性 社交能力 社交退缩 体诉 违纪 行为能力总分 行为问题总分 性问题 学校情况 抑郁 抑郁退缩 
                        double[] sums = new double[10]; //++sum
                        string[] strs = new string[10] { "", "", "", "", "", "", "", "", "", "" };

                        //总分
                        double sum_all = 0;
                        string strs_all = "";

                        double[] sums_girl = new double[10];
                        string[] strs_girl = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        bool mark = false;

                        for (int i = 1; i <= cnt; i++)//cnt 共148
                        {
                            strs_all += adic[i];
                            sum_all += GetScore(tid, i, adic[i]);

                            if (i < 27)
                            {
                                if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 9 || i == 10)
                                {//活动能力
                                    strs_both[0] += adic[i];
                                    sum_both[0] += GetScore(tid, i, adic[i]);
                                }
                                else if (i == 7 || i == 8 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16)
                                {//社交能力
                                    strs_both[1] += adic[i];
                                    sum_both[1] += GetScore(tid, i, adic[i]);
                                }
                                else if (i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24 || i == 25 || i == 26)
                                {//学校情况
                                    strs_both[2] += adic[i];
                                    sum_both[2] += GetScore(tid, i, adic[i]);
                                }
                            }
                            else //男生
                            {
                                i -= 27;
                                if (i > 56)
                                {
                                    if (i > (56 + 8))
                                    {
                                        i -= 8;
                                        mark = true;
                                    }
                                    else //单独处理56 abc
                                    {//体诉 

                                        int a = i - 56;
                                        if (a != 5 || a != 6 || a != 8) //男
                                        {
                                            strs[4] += adic[i + 27];
                                            sums[4] += GetScore(tid, i, adic[i + 27]);
                                        }
                                        if (a != 8) //女
                                        {
                                            strs_girl[0] += adic[i + 27];
                                            sums_girl[0] += GetScore(tid, i, adic[i + 27]);
                                        }

                                    }
                                }
                                ////////////////
                                bool fenlie_m = (i == 11 || i == 29 || i == 30 || i == 40 || i == 47 || i == 50 || i == 59 || i == 70 || i == 75);
                                bool yiyu_m = (i == 12 || i == 14 || i == 18 || i == 31 || i == 32 || i == 33 || i == 34 || i == 31 || i == 45 || i == 50 || i == 52 || i == 71 || i == 88 || i == 89 || i == 31 || i == 103 || i == 112);
                                bool jiaowangbuliang_m = (i == 13 || i == 65 || i == 69 || i == 71 || i == 75 || i == 80 || i == 86 || i == 103);
                                bool qiangpoxing_m = (i == 9 || i == 13 || i == 17 || i == 46 || i == 47 || i == 50 || i == 54 || i == 66 || i == 76 || i == 80 || i == 88 || i == 84 || i == 85 || i == 92 || i == 93 || i == 100);
                                bool tisu_m = (i == 49 || i == 51 || i == 54 || i == 77);
                                bool shejiaotuisuo_m = (i == 25 || i == 34 || i == 38 || i == 42 || i == 48 || i == 64 || i == 109 || i == 111);
                                bool duodong_m = (i == 1 || i == 8 || i == 10 || i == 13 || i == 17 || i == 20 || i == 41 || i == 61 || i == 62 || i == 64 || i == 79);
                                bool gongji_m = (i == 17 || i == 16 || i == 19 || i == 22 || i == 23 || i == 25 || i == 27 || i == 37 || i == 43 || i == 48 || i == 57 || i == 68 || i == 74 || i == 86 || i == 87 || i == 88 || i == 90 || i == 93 || i == 94 || i == 95 || i == 97 || i == 104);
                                bool weiji_m = (i == 20 || i == 21 || i == 23 || i == 39 || i == 43 || i == 67 || i == 72 || i == 81 || i == 82 || i == 90 || i == 101 || i == 106);
                                int index = 0;
                                if (fenlie_m)
                                {//分裂样                                    
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (yiyu_m)
                                {//抑郁
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (jiaowangbuliang_m)
                                {//交往不良 
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (qiangpoxing_m)
                                {//强迫性
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (tisu_m)
                                {//体诉 
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (shejiaotuisuo_m)
                                {//社交退缩 
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (duodong_m)
                                {//多动 
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (gongji_m)
                                {//攻击性
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (weiji_m)
                                {//违纪 
                                    strs[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                ///////////

                                bool yiyu_f = (i == 11 || i == 12 || i == 30 || i == 31 || i == 32 || i == 33 || i == 34 || i == 35 || i == 38 || i == 45 || i == 50 || i == 52 || i == 71 || i == 75 || i == 88 || i == 103 || i == 111 || i == 112);
                                bool shejiaotuisuo_f = (i == 13 || i == 42 || i == 65 || i == 69 || i == 75 || i == 80 || i == 87 || i == 88 || i == 102 || i == 103 || i == 111);
                                bool tisu_f = (i == 2 || i == 4 || i == 7 || i == 51 || i == 54 || i == 77 || i == 92);
                                bool fenlieqiangpo_f = (i == 9 || i == 18 || i == 40 || i == 66 || i == 67 || i == 10 || i == 76 || i == 84 || i == 85 || i == 91 || i == 100);
                                bool duodong_f = (i == 1 || i == 8 || i == 10 || i == 13 || i == 17 || i == 23 || i == 38 || i == 41 || i == 48 || i == 61 || i == 62 || i == 64 || i == 79 || i == 80);
                                bool xingwenti_f = (i == 52 || i == 60 || i == 63 || i == 73 || i == 93 || i == 96);
                                bool weiji_f = (i == 39 || i == 43 || i == 67 || i == 81 || i == 83 || i == 90);
                                bool gongjixing_f = (i == 3 || i == 7 || i == 14 || i == 16 || i == 19 || i == 21 || i == 22 || i == 23 || i == 25 || i == 27 || i == 33 || i == 37 || i == 41 || i == 48 || i == 68 || i == 74 || i == 86 || i == 87 || i == 88 || i == 93 || i == 94 || i == 95 || i == 97 || i == 104 || i == 109);
                                bool canren_f = (i == 5 || i == 15 || i == 16 || i == 20 || i == 21 || i == 37 || i == 57);

                                index = 0;
                                if (yiyu_f)
                                {//抑郁                                    
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (shejiaotuisuo_f)
                                {//社交退缩 
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (tisu_f)
                                {//体诉  
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (fenlieqiangpo_f)
                                {//分裂强迫 
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (duodong_f)
                                {//多动  
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (xingwenti_f)
                                {//性问题
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (weiji_f)
                                {//违纪
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (gongjixing_f)
                                {//攻击性
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                else if (canren_f)
                                {//残忍 
                                    strs_girl[index] += (i > 56 ? adic[i + 27 + 8] : adic[i + 27]);
                                    sums_girl[index] += GetScore(tid, i, (i > 56 ? adic[i + 27 + 8] : adic[i + 27]));
                                    index++;
                                }
                                /////////////
                                if (mark == true)
                                {
                                    i += 8;
                                    mark = false;
                                }
                                i += 27;
                            }
                        }
                        //残忍女8多动男6多动女4分裂强迫女3分裂样男0攻击性男7攻击性女7活动能力男0活动能力女0交往不良男2强迫性男3社交能力男1社交能力女1社交退缩男5社交退缩女1体诉男4体诉女2违纪男8违纪女6行为能力总分行为问题总分男9行为问题总分女9性问题女学校情况男1学校情况女1抑郁男1抑郁女0

                        list_score.Add(sums_girl[8]);
                        list_score.Add(sums[6]);
                        list_score.Add(sums_girl[4]);
                        list_score.Add(sums_girl[3]);
                        list_score.Add(sums[0]);
                        list_score.Add(sums[7]);
                        list_score.Add(sums_girl[7]);
                        list_score.Add(sum_both[0]);
                        list_score.Add(sum_both[0]);
                        list_score.Add(sums[2]);
                        list_score.Add(sums[3]);
                        list_score.Add(sum_both[1]);
                        list_score.Add(sum_both[1]);
                        list_score.Add(sums[5]);
                        list_score.Add(sums_girl[1]);
                        list_score.Add(sums[4]);
                        list_score.Add(sums_girl[2]);
                        list_score.Add(sums[8]);
                        list_score.Add(sums_girl[6]);
                        list_score.Add(sum_all);
                        list_score.Add(sums[9]);
                        list_score.Add(sums_girl[9]);
                        list_score.Add(sums_girl[5]);
                        list_score.Add(sum_both[2]);
                        list_score.Add(sum_both[2]);
                        list_score.Add(sums[1]);
                        list_score.Add(sums_girl[0]);

                        //将各自的选项集放进一个集合里 自己改顺序   


                        list_str.Add(strs_girl[8]);
                        list_str.Add(strs[6]);
                        list_str.Add(strs_girl[4]);
                        list_str.Add(strs_girl[3]);
                        list_str.Add(strs[0]);
                        list_str.Add(strs[7]);
                        list_str.Add(strs_girl[7]);
                        list_str.Add(strs_both[0]);
                        list_str.Add(strs_both[0]);
                        list_str.Add(strs[2]);
                        list_str.Add(strs[3]);
                        list_str.Add(strs_both[1]);
                        list_str.Add(strs_both[1]);
                        list_str.Add(strs[5]);
                        list_str.Add(strs_girl[1]);
                        list_str.Add(strs[4]);
                        list_str.Add(strs_girl[2]);
                        list_str.Add(strs[8]);
                        list_str.Add(strs_girl[6]);
                        list_str.Add(strs_all);
                        list_str.Add(strs[9]);
                        list_str.Add(strs_girl[9]);
                        list_str.Add(strs_girl[5]);
                        list_str.Add(strs_both[2]);
                        list_str.Add(strs_both[2]);
                        list_str.Add(strs[1]);
                        list_str.Add(strs_girl[0]);

                        for (int i = 0; i < sums.Length; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, strs[i], sums[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 84:
                    break;
                case 85:
                    {
                        double sum_chenggong = 0;
                        double sum_chenggong1 = 0;
                        double sum_chenggong2 = 0;
                        double sum_daode = 0;
                        double sum_daode1 = 0;
                        double sum_daode2 = 0;
                        double sum_duli = 0;
                        double sum_duli1 = 0;
                        double sum_duli2 = 0;
                        double sum_kongzhi = 0;
                        double sum_kongzhi1 = 0;
                        double sum_kongzhi2 = 0;
                        double sum_maodun = 0;
                        double sum_maodun1 = 0;
                        double sum_maodun2 = 0;
                        double sum_qinmi = 0;
                        double sum_qinmi1 = 0;//亲密度：将需要-1的放在这里
                        double sum_qinmi2 = 0;//亲密度：将需要-2的放在这里
                        double sum_biaoda = 0;
                        double sum_biaoda1 = 0;
                        double sum_biaoda2 = 0;
                        double sum_yule = 0;
                        double sum_yule1 = 0;
                        double sum_yule2 = 0;
                        double sum_zuzhi = 0;
                        double sum_zuzhi1 = 0;
                        double sum_zuzhi2 = 0;
                        double sum_wenhua = 0;
                        double sum_wenhua1 = 0;
                        double sum_wenhua2 = 0;

                        double num = 0;
                        string str_qinmi ="";
                        string str_biaoda = "";
                        string str_maodun = "";
                        string str_duli = "";
                        string str_chenggong = "";
                        string str_wenhua = "";
                        string str_yule = "";
                        string str_daode = "";
                        string str_zuzhi = "";
                        string str_kongzhi = "";

                        ItemNum = 11;


                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (num % 10 == 1)
                            {

                                if (num == 1 || num == 41 || num == 61)
                                {
                                    sum_qinmi1 += GetScore(tid, i, adic[i]) -1;
                                }
                                else 
                                {
                                    sum_qinmi2 += GetScore(tid, i, adic[i]) -2;
                                }
                                
                                str_qinmi += adic[i];
                            }
                            else if (num % 10 == 2)
                            {
                                if (num == 2 || num == 22 || num == 52 || num == 72)
                                {
                                    sum_biaoda1 += GetScore(tid, i, adic[i]) -1;
                                }
                                else
                                {
                                    sum_biaoda2 += GetScore(tid, i, adic[i]) -2;
                                }
                                
                                str_biaoda += adic[i];
                            }
                            else if (num % 10 == 3)
                            {
                                if (num == 13 || num == 33 || num == 63)
                                {
                                    sum_maodun1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_maodun2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                
                                str_maodun += adic[i];
                            }
                            else if (num % 10 == 4)
                            {
                                if (num == 4 || num == 54 )
                                {
                                    sum_duli1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_duli2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                
                                str_duli += adic[i];
                            }
                            else if (num % 10 == 5)
                            {
                                if (num == 55 || num == 65)
                                {
                                    sum_chenggong1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    if (num == 15) {
                                        sum_chenggong2 -= (GetScore(tid, i, adic[i]) - 2); 
                                    }else
                                        sum_chenggong2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                
                                str_chenggong += adic[i];
                            }
                            else if (num % 10 == 6)
                            {
                                if (num == 16 || num == 36 || num == 46 || num == 76)
                                {
                                    sum_wenhua1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_wenhua2 += GetScore(tid, i, adic[i]) - 2;
                                }
                               
                                str_wenhua += adic[i];
                            }
                            else if (num % 10 == 7)
                            {
                                if (num == 7 || num == 27 || num == 57 || num == 87)
                                {
                                    sum_yule1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_yule2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                sum_yule = sum_yule1 - sum_yule2;
                                str_yule += adic[i];
                            }
                            else if (num % 10 == 8)
                            {
                                if (num == 18 || num == 38 || num == 88)
                                {
                                    sum_daode1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_daode2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                
                                str_daode += adic[i];
                            }
                            else if (num % 10 == 9)
                            {
                                if (num == 29 || num == 49 || num == 79)
                                {
                                    sum_zuzhi1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_zuzhi2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                
                                str_zuzhi += adic[i];
                            }
                            else if (num % 10 == 0)
                            {
                                if (num == 10 || num == 20 || num == 60 || num == 70)
                                {
                                    sum_kongzhi1 += GetScore(tid, i, adic[i]) - 1;
                                }
                                else
                                {
                                    sum_kongzhi2 += GetScore(tid, i, adic[i]) - 2;
                                }
                                
                                str_kongzhi += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        //计算各因子总分
                        sum_qinmi = sum_qinmi1 - sum_qinmi2;
                        sum_biaoda = sum_biaoda1 - sum_biaoda2;
                        sum_maodun = sum_maodun1 - sum_maodun2;
                        sum_duli = sum_duli1 - sum_duli2;
                        sum_chenggong = sum_chenggong1 - sum_chenggong2;
                        sum_wenhua = sum_wenhua1 - sum_wenhua2;
                        sum_yule = sum_yule1 - sum_yule2;
                        sum_daode = sum_daode1 - sum_daode2;
                        sum_zuzhi = sum_zuzhi1 - sum_zuzhi2;
                        sum_kongzhi = sum_kongzhi1 - sum_kongzhi2;

                        //将分数放进一个链表里
                        list_score.Add(sum_chenggong);
                        list_score.Add(sum_daode);
                        list_score.Add(sum_duli);
                        list_score.Add(sum);
                        list_score.Add(sum_kongzhi);
                        list_score.Add(sum_maodun);
                        list_score.Add(sum_qinmi);
                        list_score.Add(sum_biaoda);
                        list_score.Add(sum_yule);
                        list_score.Add(sum_zuzhi);
                        list_score.Add(sum_wenhua);
                        //将各自的选项集放进一个集合里
                        list_str.Add(str_chenggong);
                        list_str.Add(str_daode);
                        list_str.Add(str_duli);
                        list_str.Add(str);
                        list_str.Add(str_kongzhi);
                        list_str.Add(str_maodun);
                        list_str.Add(str_qinmi);
                        list_str.Add(str_biaoda);
                        list_str.Add(str_yule);
                        list_str.Add(str_zuzhi);
                        list_str.Add(str_wenhua);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 86:
                    {
                        double sum_qinmi = 36;
                        double sum_shiying = 12;
                        string str_qinmi = "";
                        string str_shiying = "";
                        ItemNum = 3;
                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 1 || i == 5 || i == 7 || i == 11 || i == 13 || i == 15 || i == 17 || i == 21 || i == 23 || i == 25 || i == 27 || i == 30)
                            {
                                str_qinmi += adic[i];
                                sum_qinmi += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 3 || i == 9 || i == 19 || i == 29)
                            {
                                str_qinmi += adic[i];
                                sum_qinmi -= GetScore(tid, i, adic[i]);
                            }
                            else if (i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 12 || i == 14 || i == 16 || i == 20 || i == 22 || i == 26)
                            {
                                str_shiying += adic[i];
                                sum_shiying += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 24 || i == 28)
                            {
                                str_shiying += adic[i];
                                sum_shiying -= GetScore(tid, i, adic[i]);
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_shiying);
                        list_score.Add(sum_qinmi);
                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_shiying);
                        list_str.Add(str_qinmi);

                        


                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 87:
                    break;
                case 88:
                    break;
                case 89://Rutter 儿童行为问卷
                    {
                        double sum_shengji = 0;
                        double sum_weiji = 0;

                        string str_shengji = "";
                        string str_weiji = "";
                        ItemNum = 3;

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 11 || i == 21 || i == 25 || i == 26 || i == 29)
                            {
                                sum_shengji += GetScore(tid, i, adic[i]);
                                str_shengji += adic[i];
                            }
                            else if (i == 2 || i == 7 || i == 14 || i == 23 || i == 31)
                            {
                                sum_weiji += GetScore(tid, i, adic[i]);
                                str_weiji += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_shengji);
                        list_score.Add(sum_weiji);
                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_shengji);
                        list_str.Add(str_weiji);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 90://儿童行为问卷-教师 zhz 1208改
                    {
                        double[] sums = new double[4] { 0, 0, 0, 0 };//A M N 总
                        string[] strs = new string[4] { "", "", "", "" };

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 1 || i == 6 || i == 14 || i == 17 || i == 23)
                            {
                                strs[0] += adic[i];//A
                                sums[0] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 11 || i == 21 || i == 22 || i == 25 || i == 26)
                            {
                                strs[2] += adic[i];//N
                                sums[2] += GetScore(tid, i, adic[i]);
                            }
                            strs[3] += adic[i];//总 
                            sums[3] += GetScore(tid, i, adic[i]);
                        }

                        if (sums[0] == sums[2])
                        {
                            sums[1] = 0;//M
                            sums[0] = 2;
                            sums[2] = 2;
                        }
                        else
                        {
                            double a = sums[0] - sums[2];
                            if (a > 0)
                            {
                                sums[0] = 0;
                                sums[2] = 2;
                            }
                            else
                            {
                                sums[0] = 2;
                                sums[2] = 0;
                            }
                        }


                        //将分数放进一个链表里
                        //list_score.AddRange(sums);
                        list_score.Add(sums[0]);//A
                        list_score.Add(sums[1]);//M                        
                        list_score.Add(sums[2]);//N
                        list_score.Add(sums[3]);//总

                        //将各自的选项集放进一个集合里
                        list_str.Add(strs[0]);
                        list_str.Add(strs[1]);
                        list_str.Add(strs[2]);
                        list_str.Add(strs[3]);

                        for (int i = 0; i < sums.Length; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 91://交往焦虑量表
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 92:
                    {
                        double sum_haipa = 0;
                        double sum_shejiao = 0;
                        string str_haipa = "";
                        string str_shejiao = "";
                        ItemNum = 3;
                         for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 1 || i == 2 || i == 5 || i == 6 || i == 8 || i == 10)
                            {
                                sum_haipa += GetScore(tid, i, adic[i]);
                                str_haipa += adic[i];
                            }
                            else if (i == 3 || i == 4 || i == 7 || i == 9)
                            {
                                sum_shejiao += GetScore(tid, i, adic[i]);
                                str_shejiao += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                         }
                         //将分数放进一个链表里
                         list_score.Add(sum);
                         list_score.Add(sum_haipa);
                         list_score.Add(sum_shejiao);
                         //将各自的选项集放进一个集合里
                         list_str.Add(str);
                         list_str.Add(str_haipa);
                         list_str.Add(str_shejiao);

                         ItemNum = acountManager.GetNum(tid);
                         for (int i = 0; i < ItemNum; i++)
                         {
                             PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                             InsertPatientDetail(patientDetail);
                         }
                    }
                    break;
                case 93:
                    break;
                case 94://儿童社会期望量表（CSD）
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 95://父母教养方式评价量表(EMBU) zhz
                    {
                        double[] sums_ba = new double[6];
                        string[] strs_ba = new string[6] { "", "", "", "", "", ""};
                        

                        double[] sums_ma = new double[5];
                        string[] strs_ma = new string[5] { "", "", "", "", ""};
                     
                        for (int i = 1; i <= cnt; i++)
                        {
                            //父
                            if (i == 2 || i == 4 || i == 6 || i == 7 || i == 9 || i == 15 || i == 20 || i == 25 || i == 29 || i == 30 || i == 31 || i == 32 || i == 33 || i == 37 || i == 42 || i == 54 || i == 60 || i == 61 || i == 66)
                            {
                                strs_ba[0] += adic[i];
                                sums_ba[0] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 5 || i == 13 || i == 17 || i == 18 || i == 43 || i == 49 || i == 51 || i == 52 || i == 53 || i == 55 || i == 58 || i == 62)
                            {
                                strs_ba[1] += adic[i];
                                sums_ba[1] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 1 || i == 10 || i == 11 || i == 14 || i == 27 || i == 36 || i == 48 || i == 5 || i == 56 || i == 57)
                            {
                                strs_ba[2] += adic[i];
                                sums_ba[2] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 3 || i == 8 || i == 22 || i == 64 || i == 65)
                            {
                                strs_ba[3] += adic[i];
                                sums_ba[3] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 21 || i == 23 || i == 28 || i == 34 || i == 35 || i == 45)
                            {
                                strs_ba[4] += adic[i];
                                sums_ba[4] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 12 || i == 16 || i == 39 || i == 40 || i == 59)
                            {
                                strs_ba[5] += adic[i];
                                sums_ba[5] += GetScore(tid, i, adic[i]);
                            }

                            //母
                            if (i == 2 || i == 4 || i == 6 || i == 7 || i == 9 || i == 15 || i == 20 || i == 25 || i == 29 || i == 30 || i == 31 || i == 32 || i == 33 || i == 37 || i == 42 || i == 54 || i == 60 || i == 61 || i == 66)
                            {
                                strs_ma[0] += adic[i];
                                sums_ma[0] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 1 || i == 11 || i == 12 || i == 14 || i == 16 || i == 19 || i == 24 || i == 27 || i == 35 || i == 36 || i == 41 || i == 48 || i == 50 || i == 56 || i == 57 || i == 59)
                            {
                                strs_ma[1] += adic[i];
                                sums_ma[1] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 23 || i == 26 || i == 28 || i == 34 || i == 38 || i == 39 || i == 45 || i == 47)
                            {
                                strs_ma[2] += adic[i];
                                sums_ma[2] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 13 || i == 17 || i == 43 || i == 51 || i == 52 || i == 53 || i == 55 || i == 58 || i == 62)
                            {
                                strs_ma[3] += adic[i];
                                sums_ma[3] += GetScore(tid, i, adic[i]);
                            }
                            else if (i == 3 || i == 8 || i == 22 || i == 64 || i == 65)
                            {
                                strs_ma[4] += adic[i];
                                sums_ma[4] += GetScore(tid, i, adic[i]);
                            }

                            str += adic[i];//总 
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sums_ba[1]);
                        list_score.Add(sums_ma[3]);
                        list_score.Add(sum);
                        list_score.Add(sums_ba[5]);
                        list_score.Add(sums_ba[2]);
                        list_score.Add(sums_ma[1]);
                        list_score.Add(sums_ba[4]);
                        list_score.Add(sums_ma[2]);
                        list_score.Add(sums_ba[3]);
                        list_score.Add(sums_ma[4]);
                        list_score.Add(sums_ba[0]);
                        list_score.Add(sums_ma[0]);

                        //将各自的选项集放进一个集合里
                        list_str.Add(strs_ba[1]);
                        list_str.Add(strs_ma[3]);
                        list_str.Add(str);
                        list_str.Add(strs_ba[5]);
                        list_str.Add(strs_ba[2]);
                        list_str.Add(strs_ma[1]);
                        list_str.Add(strs_ba[4]);
                        list_str.Add(strs_ma[2]);
                        list_str.Add(strs_ba[3]);
                        list_str.Add(strs_ma[4]);
                        list_str.Add(strs_ba[0]);
                        list_str.Add(strs_ma[0]);

                        for (int i = 0; i < list_score.Count; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 96://【郭秋叶--儿童自我意识量表】
                    {
                        double sum_xingwei = 0;
                        double sum_zhili = 0;
                        double sum_quti = 0;
                        double sum_jiaolv = 0;
                        double sum_hequn = 0;
                        double sum_xingfu = 0;
                        //double sum_tltal = 0;

                        ItemNum = 7;
                        string str_xingwei = "";
                        string str_zhili = "";
                        string str_quti = "";
                        string str_jiaolv = "";
                        string str_hequn = "";
                        string str_xingfu = "";
                        //string str_total = "";
                        double num = 0;
                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;

                            if (num == 12 || num == 13 || num == 14 || num == 21 || num == 22 || num == 25 || num == 34 || num == 35 || num == 38 || num == 45 || num == 48 || num == 56 || num == 59 || num == 62 || num == 78 || num == 80)
                            {
                                sum_xingwei += GetScore(tid, i, adic[i]);
                                str_xingwei += adic[i];
                            }
                            if (num == 5 || num == 7 || num == 9 || num == 12 || num == 16 || num == 17 || num == 21 || num == 26 || num == 27 || num == 30 || num == 31 || num == 33 || num == 42 || num == 49 || num == 53 || num == 66 || num == 73)
                            {
                                sum_zhili += GetScore(tid, i, adic[i]);
                                str_zhili += adic[i];
                            }
                            if (num == 5 || num == 8 || num == 15 || num == 29 || num == 33 || num == 41 || num == 49 || num == 54 || num == 57 || num == 60 || num == 63 || num == 69 || num == 73)
                            {
                                sum_quti += GetScore(tid, i, adic[i]);
                                str_quti += adic[i];
                            }
                            if (num == 4 || num == 6 || num == 7 || num == 8 || num == 10 || num == 20 || num == 28 || num == 37 || num == 39 || num == 40 || num == 43 || num == 50 || num == 74 || num == 79)
                            {
                                sum_jiaolv += GetScore(tid, i, adic[i]);
                                str_jiaolv += adic[i];
                            }
                            if (num == 1 || num == 3 || num == 6 || num == 11 || num == 40 || num == 46 || num == 49 || num == 51 || num == 58 || num == 65 || num == 69 || num == 77)
                            {
                                sum_hequn += GetScore(tid, i, adic[i]);
                                str_hequn += adic[i];
                            }
                            if (num == 2 || num == 8 || num == 36 || num == 39 || num == 43 || num == 50 || num == 52 || num == 60 || num == 67 || num == 80)
                            {
                                sum_xingfu += GetScore(tid, i, adic[i]);
                                str_xingfu += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);

                        }
                        //将分数放进一个链表里
                        list_score.Add(sum);
                        list_score.Add(sum_hequn);
                        list_score.Add(sum_jiaolv);
                        list_score.Add(sum_quti);
                        list_score.Add(sum_xingwei);
                        list_score.Add(sum_xingfu);
                        list_score.Add(sum_zhili);
                        
                        //将各自的选项集放进一个集合里
                        list_str.Add(str);
                        list_str.Add(str_hequn);
                        list_str.Add(str_jiaolv);
                        list_str.Add(str_quti);
                        list_str.Add(str_xingwei);
                        list_str.Add(str_xingfu);
                        list_str.Add(str_zhili);
                        
                        for (int i = 0; i < ItemNum; i++)
                        {

                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 97:
                    break;
                case 98:
                    break;
                case 99:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
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
                case 105://105【郭秋叶】:大学生心理适应性测量问卷
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 106:
                    break;
                case 107:
                    break;
                case 108:// 【郭秋叶--日常生活能力评定量表(ADL量表)】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 109:
                    break;
                case 110:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 111://综合性医院焦虑抑郁量表(HAD) by zhz
                    {

                        double sum_jiaolv = 0;
                        double sum_yiyu = 0;
                        string str_jiaolv = "";
                        string str_yiyu = "";

                        ItemNum = 3;//表有两个分类

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i % 2 > 0)
                            {
                                sum_jiaolv += GetScore(tid, i, adic[i]);
                                str_jiaolv += adic[i];
                            }
                            else
                            {
                                sum_yiyu += GetScore(tid, i, adic[i]);
                                str_yiyu += adic[i];
                            }
                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        
                        list_score.Add(sum_jiaolv);
                        list_score.Add(sum_yiyu);
                        list_score.Add(sum);
                        //将各自的选项集放进一个集合里
                       
                        list_str.Add(str_jiaolv);
                        list_str.Add(str_yiyu);
                        list_str.Add(str);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }

                    }
                    break;
                case 112:
                    break;
                case 113://AIS by zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 114://健康状况调查问卷 SF-36 edit by 【wgs】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 115:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 116:
                    break;
                case 117://状态一特质焦虑问卷
                    {
                        double sum_tezhijl = 0;
                        double sum_zhuangtaijl = 0;

                        string str_tezhijl = "";
                        string str_zhuangtaijl = "";

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (1 <= i && i <= 20)
                            {
                                sum_tezhijl += GetScore(tid, i, adic[i]);
                                str_tezhijl += adic[i];
                            }
                            else if (21 <= i && i <= 40)
                            {
                                sum_zhuangtaijl += GetScore(tid, i, adic[i]);
                                str_zhuangtaijl += adic[i];
                            }

                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }

                        //将分数放进一个链表里

                        list_score.Add(sum_tezhijl);
                        list_score.Add(sum_zhuangtaijl);
                        list_score.Add(sum);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_tezhijl);
                        list_str.Add(str_zhuangtaijl);
                        list_str.Add(str);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 118:// [郭秋叶 -- 生活满意度评定量表]
                    {
						for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 119://[郭秋叶 -- 生活满意度指数A]
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 120: // 【总体幸福感量表GWB 郭秋叶】
                    {
                        /*
						double sum_jiankang = 0;
                        double sum_jingli = 0;
                        double sum_shenghuo = 0;
                        double sum_youyu = 0;
                        double sum_qinggan = 0;
                        double sum_jiaolv = 0;

                        int num = 0;
                        string str_jiankang = "";
                        string str_jingli = "";
                        string str_shenghuo = "";
                        string str_youyu = "";
                        string str_qinggan = "";
                        string str_jiaolv = "";

                        ItemNum = 7;

                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (num == 10 || num == 15)
                            {
                                
                                sum_jiankang += GetScore(tid, i, adic[i]);
                                str_jiankang += adic[i];
                            }
                            else if (num == 9 || num == 14 || num == 17 || num == 11)
                            {
                                
                                sum_jingli += GetScore(tid, i, adic[i]);
                                str_jingli += adic[i];
                            }
                            else if (num == 6)
                            {
                                //sum_shenghuo = 6 - GetScore(tid, i, adic[i]);
                                sum_shenghuo += GetScore(tid, i, adic[i]);
                                str_shenghuo += adic[i];
                            }
                            else if (num == 4 || num == 1 || num == 12 || num == 18)
                            {

                                sum_youyu += GetScore(tid, i, adic[i]);
                                str_youyu += adic[i];
                            }
                            else if (num == 3 || num == 7 || num == 13)
                            {

                                sum_qinggan += GetScore(tid, i, adic[i]);
                                str_qinggan += adic[i];
                            }
                            else if (num == 2 || num == 5 || num == 8 || num == 16)
                            {

                                sum_jiaolv += GetScore(tid, i, adic[i]);
                                str_jiaolv += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }


                        //将分数放进一个链表里
                        
                        list_score.Add(sum_jiankang);
                        list_score.Add(sum_qinggan);
                        list_score.Add(sum_shenghuo);
                        list_score.Add(sum_jingli);
                        list_score.Add(sum_jiaolv);
                        list_score.Add(sum_youyu);
                        list_score.Add(sum);


                        //将各自的选项集放进一个集合里
                        
                        list_str.Add(str_jiankang);
                        list_str.Add(str_qinggan);
                        list_str.Add(str_shenghuo);
                        list_str.Add(str_jingli);
                        list_str.Add(str_jiaolv);
                        list_str.Add(str_youyu);
                        list_str.Add(str);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
						*/
						
						
						
						
						
						
						
						for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 121://121【郭秋叶】纽芬兰幸福度量表
                    {
                        double sum_PA = 0;
                        double sum_NA = 0;
                        double sum_PE = 0;
                        double sum_NE = 0;
                        string str_PA = "";
                        string str_NA = "";
                        string str_PE = "";
                        string str_NE = "";

                        ItemNum = 5;
                        for (int i = 1; i <= cnt;i++ )
                        {
                            if (i == 1 || i == 2 || i == 3 || i == 4 || i == 10) //正性情感
                            {
                                sum_PA += GetScore(tid, i, adic[i]);
                                str_PA += adic[i];
                            }
                            if (i == 5 || i == 6 || i == 7 || i == 8 || i == 9) //负性情感
                            {
                                sum_NA += GetScore(tid, i, adic[i]);
                                str_NA += adic[i];
                            }
                            if (i == 12 || i == 14 || i == 15 || i == 19 || i == 21 || i == 23 || i == 24) //正性体验
                            {
                                sum_PE += GetScore(tid, i, adic[i]);
                                str_PE += adic[i];
                            }
                            if (i == 11 || i == 13 || i == 16 || i == 17 || i == 18 || i == 20 || i == 22) //负性体验
                            {
                                sum_NE += GetScore(tid, i, adic[i]);
                                str_NE += adic[i];
                            } 
                            sum = sum_PA - sum_NA + sum_PE - sum_NE;
                            str += adic[i];
                        }
                       

                        //将分数放进一个链表里

                        list_score.Add(sum_NA);
                        list_score.Add(sum_NE);
                        list_score.Add(sum);
                        list_score.Add(sum_PA);
                        list_score.Add(sum_PE);
                        //将各自的选项集放进一个集合里
                        list_str.Add(str_NA);
                        list_str.Add(str_NE);
                        list_str.Add(str);
                        list_str.Add(str_PA);
                        list_str.Add(str_PE);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 122://疲劳评定量表 --郭秋叶
                    {
                        double sum_factor1 = 0;
                        double sum_factor2 = 0;
                        double sum_factor3 = 0;
                        double sum_factor4 = 0;

                        int num = 0;
                        string str_factor1 = "";
                        string str_factor2 = "";
                        string str_factor3 = "";
                        string str_factor4 = "";

                        ItemNum = 5;

                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (num == 5 || num == 18 || num == 19 || num == 20 || num == 21 || num == 22 || num == 24 || num == 25 || num == 26 || num == 27 || num == 28)
                            {//严重程度
                                sum_factor1 += GetScore(tid, i, adic[i]);
                                str_factor1 += adic[i];
                            }
                            else if (num == 6 || num == 7 || num == 8 || num == 9 || num == 16 || num == 17)
                            {//特异性环境敏感性
                                sum_factor2 += GetScore(tid, i, adic[i]);
                                str_factor2 += adic[i];
                            }
                            else if (num == 2 || num == 3 || num == 4)
                            {//可能导致的心理后果
                                sum_factor3 += GetScore(tid, i, adic[i]);
                                str_factor3 += adic[i];
                            }
                            else if (num == 14 || num == 15)
                            {//对休息或睡眠有反应
                                sum_factor4 += GetScore(tid, i, adic[i]);
                                str_factor4 += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }


                        //将分数放进一个链表里
                        
                        list_score.Add(sum_factor4);
                        list_score.Add(sum_factor2);
                        list_score.Add(sum_factor3);
                        list_score.Add(sum);
                        list_score.Add(sum_factor1);
                       
                        //将各自的选项集放进一个集合里
                        list_str.Add(str_factor4);
                        list_str.Add(str_factor2);
                        list_str.Add(str_factor3);
                        list_str.Add(str);
                        list_str.Add(str_factor1);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
               case 123://社会焦虑量表【郭秋叶】-新增1225
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 124://124【郭秋叶】简易应对量表
                    {
                        double sum_jiji = 0;
                        // double average_jiji[];
                        //double variance_jiji = 0;
                        double sum_xiaoji = 0;
                        //double average_xiaoji[7] = 0;
                        //  double variance_xiaoji = 0;

                        int num = 0;
                        //double j = 0;
                        string str_jiji = "";
                        string str_xiaoji = "";
                        ItemNum = 3;

                        for (int i = 1; i <= cnt; i++)
                        {
                            num = i;
                            if (num <= 12)
                            {
                                double[] average_jiji = new double[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                                double[] variance_jiji = new double[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                              //  average_jiji[num - 1] = sum_jiji / num;
                               // j += (GetScore(tid, i, adic[i]) - average_jiji[num - 1]) * (GetScore(tid, i, adic[i]) - average_jiji[num - 1]);
                               // variance_jiji[num - 1] = Math.Sqrt(j / num);
                               // sum_jiji += (GetScore(tid, i, adic[i]) - average_jiji[num - 1]) / variance_jiji[num - 1];
                               // str_jiji += adic[i];
                                str_jiji += adic[i];
                                sum_jiji += GetScore(tid, i, adic[i]);
                            }


                            else if (num >= 13 && num <= 20)
                            {
                                int m = num - 13;
                                double[] average_xiaoji = new double[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
                                double[] variance_xiaoji = new double[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

                                //average_xiaoji[m] = sum_xiaoji / (m + 1);
                               //j += (GetScore(tid, i, adic[i]) - average_xiaoji[m]) * (GetScore(tid, i, adic[i]) - average_xiaoji[m]);
                                //variance_xiaoji[m] = Math.Sqrt(j / (m + 1));
                                //sum_xiaoji += (GetScore(tid, i, adic[i]) - average_xiaoji[m]) / variance_xiaoji[m];
                                //str_xiaoji += adic[i];
                                str_xiaoji += adic[i];
                                sum_xiaoji += GetScore(tid, i, adic[i]);
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        //将分数放进一个链表里
                       
                        list_score.Add(sum_jiji);
                        list_score.Add(sum);
                        list_score.Add(sum_xiaoji);

                        //将各自的选项集放进一个集合里
                        
                        list_str.Add(str_jiji);
                        list_str.Add(str);
                        list_str.Add(str_xiaoji);


                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 125:
				
                    break;
                case 126://社会支持评定量表
                    {
                        double sum_keguan = 0;
                        string str_keguan = "";
                        double sum_liyongdu = 0;
                        string str_liyongdu = "";
                        double sum_zhuguan = 0;
                        string str_zhuguan = "";
                        
                        ItemNum = 4;
                        for (int i = 1; i <= cnt; i++)
                            {
                           if(i == 2 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24 || i == 25)
                            {
                                sum_keguan += GetScore(tid, i, adic[i]);
                                str_keguan += adic[i]; 
                            }
                            else if(i == 1 || i == 3 || i == 4 || i == 5 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9)
                            {
                                sum_zhuguan += GetScore(tid, i, adic[i]);
                                str_zhuguan += adic[i]; 
                            }
                           else if (i == 26 || i == 27 || i == 28)
                           {
                               sum_liyongdu += GetScore(tid, i, adic[i]);
                               str_liyongdu += adic[i]; 
                           }
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum_keguan);
                        list_score.Add(sum_liyongdu);
                        list_score.Add(sum);
                        list_score.Add(sum_zhuguan);

                        list_str.Add(str_keguan);
                        list_str.Add(str_liyongdu);
                        list_str.Add(str);
                        list_str.Add(str_zhuguan);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 127:
                    break;
                case 128:
                    break;
                case 129:
                    break;
                case 130://中学生学习方法测验问卷【王瑞】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 131://中学生学习动机测验问卷
                    {
                        double sum_xueximb = 0;
                        double sum_xuexirsd = 0;
                        double sum_xuexixq = 0;
                        double sum_xuexizdx = 0;

                        string str_xueximb = "";
                        string str_xuexirsd = "";
                        string str_xuexixq = "";
                        string str_xuexizdx = "";

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (1 <= i && i <= 5)
                            {
                                sum_xuexizdx += GetScore(tid, i, adic[i]);
                                str_xuexizdx += adic[i];
                            }
                            else if (6 <= i && i <= 10)
                            {
                                sum_xuexirsd += GetScore(tid, i, adic[i]);
                                str_xuexirsd += adic[i];
                            }
                            else if (11 <= i && i <= 15)
                            {
                                sum_xuexixq += GetScore(tid, i, adic[i]);
                                str_xuexixq += adic[i];
                            }
                            else if (16 <= i && i <= 20)
                            {
                                sum_xueximb += GetScore(tid, i, adic[i]);
                                str_xueximb += adic[i];
                            }
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }

                        //将分数放进一个链表里
                        list_score.Add(sum_xueximb);
                        list_score.Add(sum_xuexirsd);
                        list_score.Add(sum_xuexixq);
                        list_score.Add(sum_xuexizdx);
                        list_score.Add(sum);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_xueximb);
                        list_str.Add(str_xuexirsd);
                        list_str.Add(str_xuexixq);
                        list_str.Add(str_xuexizdx);
                        list_str.Add(str);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 132://耶鲁—布朗强迫症状量表(Y-BOCS) zhz
                    {
                        double sum_siwei = 0;
                        double sum_xingwei = 0;

                        string str_siwei = "";
                        string str_xingwei = "";

                        ItemNum = 3;//表N个分类

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i >= 1 && i <= 5)
                            {
                                sum_siwei += GetScore(tid, i, adic[i]);
                                str_siwei += adic[i];
                            }
                            else if (i >= 6 && i <= 10)
                            {
                                sum_xingwei += GetScore(tid, i, adic[i]);
                                str_xingwei += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum_siwei);
                        list_score.Add(sum_xingwei);
                        list_score.Add(sum);
                       

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_siwei);
                        list_str.Add(str_xingwei);
                        list_str.Add(str);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
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
                case 139://进取性水平测验【王瑞】
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];//答题者所选的所有答案
                        }
                        //将答题后所需要的信息放进一个对象里
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        //把信息插入tbl_patientDetail数据库表中
                        InsertPatientDetail(patientDetail);
                    }
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
                case 147: //郭秋叶 --认知偏差问卷
                    {
                        char[] D_D = new char[] { 'A', 'C', 'B', 'C', 'B', 'D', 'D', 'C', 'B', 'D', 'D', 'D', 'B', 'A', 'D', 'A', 'C', 'D', 'C', 'D', 'C', 'A', 'C' };
                        char[] ND_D = new char[] { 'B', 'B', 'A', 'A', 'C', 'A', 'C', 'D', 'D', 'A', 'B', 'A', 'A', 'B', 'B', 'D', 'A', 'B', 'A', 'A', 'D', 'B', 'B' };
                        char[] D_ND = new char[] { 'C', 'A', 'C', 'D', 'D', 'C', 'A', 'B', 'A', 'B', 'C', 'B', 'C', 'D', 'C', 'B', 'B', 'C', 'D', 'C', 'B', 'C', 'A' };
                        char[] ND_ND = new char[] { 'D', 'D', 'D', 'B', 'A', 'B', 'B', 'A', 'C', 'C', 'A', 'C', 'D', 'C', 'A', 'C', 'D', 'A', 'B', 'B', 'A', 'D', 'D' };

                        double sum_DD = 0;
                        double sum_NDD = 0;
                        double sum_DND = 0;
                        double sum_NDND = 0;
                        // double[] SUM = new double[4];

                        string str_DD = "";
                        string str_NDD = "";
                        string str_DND = "";
                        string str_NDND = "";
                        ItemNum = 5;
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                            //抑郁-歪曲
                            if ((str[i - 1].Equals(D_D[i - 1])))
                            {
                                sum_DD += GetScore(tid, i, adic[i]);
                                str_DD += adic[i];

                            }
                            //非抑郁-歪曲的
                            else if (str[i - 1].Equals(ND_D[i - 1]))
                            {
                                sum_NDD += GetScore(tid, i, adic[i]);
                                str_NDD += adic[i];
                            }
                            //抑郁的-非歪曲的
                            else if (str[i - 1].Equals(D_ND[i - 1]))
                            {
                                sum_DND += GetScore(tid, i, adic[i]);
                                str_DND += adic[i];
                            }
                            //非抑郁的-非歪曲的
                            else if (str[i - 1].Equals(ND_ND[i - 1]))
                            {
                                sum_NDND += GetScore(tid, i, adic[i]);
                                str_NDND += adic[i];

                            }
                        }
                        list_score.Add(sum_NDND);
                        list_score.Add(sum_NDD);
                        list_score.Add(sum);
                        list_score.Add(sum_DD);
                        list_score.Add(sum_DND);

                        list_str.Add(str_NDND);
                        list_str.Add(str_NDD);
                        list_str.Add(str);
                        list_str.Add(str_DD);
                        list_str.Add(str_DND);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }

                    }
                    break;
                case 148://患病行为问卷
                    {
                        double sum_option1 = 0;//GH
                        double sum_option2 = 0;//DC
                        double sum_option3 = 0;//PS
                        double sum_option4 = 0;//AI
                        double sum_option5 = 0;//AD
                        double sum_option6 = 0;//D
                        double sum_option7 = 0;//A
                        double sum_option8 = 0;//WI
                        double sum_option9 = 0;//AS (affection state)＝GH+AD+I
                        double sum_option10 = 0;//DA（disease affirmation）=DC+5-P/S (reference value 7-11）

                        string str_option1 = "";
                        string str_option2 = "";
                        string str_option3 = "";
                        string str_option4 = "";
                        string str_option5 = "";
                        string str_option6 = "";
                        string str_option7 = "";
                        string str_option8 = "";
                        string str_option9 = "";
                        string str_option10 = "";
                        ItemNum = 11;//表N个分类

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 9 || i == 20 || i == 21 || i == 24 || i == 29 || i == 30 || i == 32 || i == 37 || i == 38)//GH                                                        
                            {
                                sum_option1 += GetScore(tid, i, adic[i]);
                                str_option1 += adic[i];
                            }

                            else if (i == 2 || i == 3 || i == 10 || i == 41 || i == 7 || i == 35)//DC
                            {
                                sum_option2 += GetScore(tid, i, adic[i]);
                                str_option2 += adic[i];
                            }
                            else if (i == 11 || i == 44 || i == 57 || i == 16 || i == 46)//PS
                            {
                                sum_option3 += GetScore(tid, i, adic[i]);
                                str_option3 += adic[i];
                            }

                            else if (i == 36 || i == 53 || i == 62 || i == 22 || i == 58)//AI
                            {
                                sum_option4 += GetScore(tid, i, adic[i]);
                                str_option4 += adic[i];
                            }
                            else if (i == 12 || i == 18 || i == 47 || i == 54 || i == 59)//AD
                            {
                                sum_option5 += GetScore(tid, i, adic[i]);
                                str_option5 += adic[i];
                            }

                            else if (i == 55 || i == 27 || i == 31 || i == 43 || i == 60)//D
                            {
                                sum_option6 += GetScore(tid, i, adic[i]);
                                str_option6 += adic[i];
                            }

                            else if (i == 17 || i == 51 || i == 56 || i == 61 || i == 4)//I
                            {
                                sum_option7 += GetScore(tid, i, adic[i]);
                                str_option7 += adic[i];
                            }

                            else if (i == 1 || i == 2 || i == 8 || i == 9 || i == 10 || i == 16 || i == 21 || i == 24 || i == 33 || i == 38 || i == 39 || i == 41 || i == 50)//WI
                            {
                                sum_option8 += GetScore(tid, i, adic[i]);
                                str_option8 += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }

                        //AS (affection state)＝GH+AD+I
                        //DA（disease affirmation）=DC+5-P/S (reference value 7-11）

                        sum_option9 = sum_option1 + sum_option5 + sum_option7;
                        sum_option10 = sum_option2 + 5 - sum_option3;

                        //将分数放进一个链表里
                        list_score.Add(sum_option9);
                        list_score.Add(sum_option6);
                        list_score.Add(sum);
                        list_score.Add(sum_option10);
                        list_score.Add(sum_option2);
                        list_score.Add(sum_option4);
                        list_score.Add(sum_option5);
                        list_score.Add(sum_option7);
                        list_score.Add(sum_option3);
                        list_score.Add(sum_option1);
                        list_score.Add(sum_option8);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_option9);
                        list_str.Add(str_option6);
                        list_str.Add(str);
                        list_str.Add(str_option10);
                        list_str.Add(str_option2);
                        list_str.Add(str_option4);
                        list_str.Add(str_option5);
                        list_str.Add(str_option7);
                        list_str.Add(str_option3);
                        list_str.Add(str_option1);
                        list_str.Add(str_option8);








                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 149://网络成瘾诊断量表 by zhz
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 150:
                    break;
                case 151:
                    break;
                case 152:
                    break;
                case 153:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 154:
                    break;
                case 155://恐怖强迫量表
                    {
                        double sum_m1 = 0;
                        double sum_m2 = 0;
                        double sum_m3 = 0;
                        double sum_m4 = 0;

                        string str_m1 = "";
                        string str_m2 = "";
                        string str_m3 = "";
                        string str_m4 = "";


                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i <= 29)
                            {
                                sum_m1 += GetScore(tid, i, adic[i]);
                                str_m1 += adic[i];
                            }
                            else if (i >= 30 && i <= 39)
                            {
                                sum_m2 += GetScore(tid, i, adic[i]);
                                str_m2 += adic[i];
                            }
                            else if (i >= 40 && i <= 41)
                            {
                                sum_m3 += GetScore(tid, i, adic[i]);
                                str_m3 += adic[i];
                            }
                            else if (i >= 42 && i <= 43)
                            {
                                sum_m4 += GetScore(tid, i, adic[i]);
                                str_m4 += adic[i];
                            }
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        //将分数放进一个链表里 
                        list_score.Add(sum_m1);
                        list_score.Add(sum_m2);
                        list_score.Add(sum_m3);
                        list_score.Add(sum_m4);
                        list_score.Add(sum);

                        list_str.Add(str_m1);
                        list_str.Add(str_m2);
                        list_str.Add(str_m3);
                        list_str.Add(str_m4);
                        list_str.Add(str);

                        ItemNum = acountManager.GetNum(tid);
                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 156://密西根酒精依赖调查表 by zhz
                    {
                        double sum_option1 = 0;//自我或他人所认识到的饮酒问题
                        double sum_option2 = 0;//工作、社会问题
                        double sum_option3 = 0;//因饮酒问题寻求帮助
                        double sum_option4 = 0;//婚姻、家庭问题
                        double sum_option5 = 0;//肝脏疾患

                        string str_option1 = "";
                        string str_option2 = "";
                        string str_option3 = "";
                        string str_option4 = "";
                        string str_option5 = "";

                        ItemNum = 5;//表N个分类

                        for (int i = 1; i <= cnt; i++)
                        {
                            if (i == 3 || i == 5 || i == 15 || i == 1 || i == 4 || i == 6 || i == 7)
                            {
                                if (i == 1 || i == 4 || i == 6 || i == 7)//取反
                                {
                                    if (GetScore(tid, i, adic[i]) > 0)
                                    {
                                        sum_option1 += 0;
                                    }
                                    else
                                    {
                                        sum_option1 += 1;
                                    }
                                }
                                else
                                {
                                    sum_option1 += GetScore(tid, i, adic[i]);
                                }
                                str_option1 += adic[i];
                            }
                            else if (i == 9 || i == 12 || i == 13 || i == 14 || i == 18 || i == 23 || i == 24)
                            {
                                sum_option2 += GetScore(tid, i, adic[i]);
                                str_option2 += adic[i];
                            }
                            else if (i == 8 || i == 19 || i == 20 || i == 21 || i == 22)
                            {
                                sum_option3 += GetScore(tid, i, adic[i]);
                                str_option3 += adic[i];
                            }
                            else if (i == 3 || i == 10 || i == 11)
                            {
                                sum_option4 += GetScore(tid, i, adic[i]);
                                str_option4 += adic[i];
                            }
                            else if (i == 17)
                            {
                                sum_option5 += GetScore(tid, i, adic[i]);
                                str_option5 += adic[i];
                            }

                            str += adic[i];
                            sum += GetScore(tid, i, adic[i]);
                        }
                        //将分数放进一个链表里
                        list_score.Add(sum_option5);
                        list_score.Add(sum_option2);
                        list_score.Add(sum_option4);
                        list_score.Add(sum);
                        list_score.Add(sum_option3);
                        list_score.Add(sum_option1);

                        //将各自的选项集放进一个集合里
                        list_str.Add(str_option5);
                        list_str.Add(str_option2);
                        list_str.Add(str_option4);
                        list_str.Add(str);
                        list_str.Add(str_option3);
                        list_str.Add(str_option1);

                        for (int i = 0; i < ItemNum; i++)
                        {
                            PatientDetail patientDetail = new PatientDetail(uid, tid, 1, list_str[i], list_score[i], "", DateTime.Parse(DateTime.Now.ToString()), list_name[i]);
                            InsertPatientDetail(patientDetail);
                        }
                    }
                    break;
                case 157:
                    {
                        for (int i = 1; i <= cnt; i++)
                        {
                            sum += GetScore(tid, i, adic[i]);
                            str += adic[i];
                        }
                        PatientDetail patientDetail = new PatientDetail(uid, tid, 1, str, sum, "", DateTime.Parse(DateTime.Now.ToString()), list_name[0]);
                        InsertPatientDetail(patientDetail);
                    }
                    break;
                case 158:
                    break;
                case 159:
                    break;
                case 160:
                    break;
            }

        }
    }

}
