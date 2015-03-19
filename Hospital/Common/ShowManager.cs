//**********************************************
//
//文件名：ShowManager.cs
//
//描  述：窗体控制
//
//作  者：罗家辉
//
//创建时间：2014-1-15
//
//修改历史：2014-7-6  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital
{

    class ShowManager
    {
        IndexFrm indexFrm;
        Form form;
        public ShowManager(IndexFrm indexFrms, Form forms)
        {
            indexFrm = indexFrms;
            form = forms;
        }

        private bool ExistsMdiChildrenInstance(Form MdiChildrenClassName)
        {
            //遍历每一个MDI子窗体实例
            foreach (Form childFrm in indexFrm.MdiChildren)
            {
                //若子窗体的类型与实参相同，则存在该类的实例
                if (childFrm.Name == MdiChildrenClassName.Name)
                {
                    //若该窗体实例被最小化了
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        //最大化这个实例
                        childFrm.WindowState = FormWindowState.Maximized;
                    }
                    //激活该窗体实例
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        public void ShowForm()
        {
            if (indexFrm.ActiveMdiChild != null)
            {
                indexFrm.ActiveMdiChild.Close();
            }
            if (!ExistsMdiChildrenInstance(form))
            {
                form.MdiParent = indexFrm;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Focus();
            }
        }
    }
}
