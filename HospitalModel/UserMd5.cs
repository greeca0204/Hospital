using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Hospital
{
    public class UserMd5
    {
        public string md5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.Default.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                //如果每次生成的数只有一位，要在十位补0
                if (s[i].ToString("X") == "A" || s[i].ToString("X") == "B" || s[i].ToString("X") == "C" || s[i].ToString("X") == "D" || s[i].ToString("X") == "E" || s[i].ToString("X") == "F" || s[i].ToString("X") == "0" || s[i].ToString("X") == "1" || s[i].ToString("X") == "2" || s[i].ToString("X") == "3" || s[i].ToString("X") == "4" || s[i].ToString("X") == "5" || s[i].ToString("X") == "6" || s[i].ToString("X") == "7" || s[i].ToString("X") == "8" || s[i].ToString("X") == "9")
                {
                    pwd = pwd + "0";
                }
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }
    }
}
