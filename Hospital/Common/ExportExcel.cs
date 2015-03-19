using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Hospital
{
     public class ExportExcel
    {
         public void exportExcel(DataGridView dataGridView)
         {
             SaveFileDialog saveFileDialog = new SaveFileDialog();
             saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
             saveFileDialog.FilterIndex = 0;
             saveFileDialog.RestoreDirectory = true;
             saveFileDialog.CreatePrompt = true;
             saveFileDialog.Title = "Export Excel File";
             saveFileDialog.ShowDialog();
             if (saveFileDialog.FileName == "")
                 return;
             Stream myStream;
             myStream = saveFileDialog.OpenFile();
             StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

             string str = "";
             try
             {
                 for (int i = 0; i < dataGridView.ColumnCount; i++)
                 {
                     if (dataGridView.Columns[i].Visible == false) { continue; }
                     if (i > 0)
                     {
                         str += "\t";
                     }                    
                     str += dataGridView.Columns[i].HeaderText;
                 }
                 sw.WriteLine(str);
                 for (int j = 0; j < dataGridView.Rows.Count; j++)
                 {
                     string tempStr = "";
                     for (int k = 0; k < dataGridView.Columns.Count; k++)
                     {
                         if (dataGridView.Columns[k].Visible == false) { continue; }
                         if (k > 0)
                         {
                             tempStr += "\t";
                         }
                         tempStr += dataGridView.Rows[j].Cells[k].Value.ToString();
                     }
                     sw.WriteLine(tempStr);
                 }
                 sw.Close();
                 myStream.Close();
             }

             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
             finally
             {
                 sw.Close();
                 myStream.Close();
             }
         }
    }
}
