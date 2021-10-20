using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace FILEWATCHER
{
    public class ToBatch
    {
        private static string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static DateTime todayDateTime = DateTime.Now;
        private static string todayMonth = todayDateTime.ToString("yyyyMM");
        private static string today = todayDateTime.ToString("yyyyMMdd");

        public static void MAKE(StringBuilder sb)
        {
            if (sb == null || sb.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("無任何內容可供匯出");
            }
            else
            {
                //如果此路徑沒有資料夾
                if (!Directory.Exists(Path.Combine(exePath, todayMonth)))
                {
                    //新增資料夾
                    Directory.CreateDirectory(Path.Combine(exePath, todayMonth));
                }

                //File.AppendAllText(Path.Combine(exePath, todayMonth, today + ".bat"), sb.ToString());

                using (FileStream fs = new FileStream(Path.Combine(exePath, todayMonth, today + ".bat"), FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter srOutFile = new StreamWriter(fs, Encoding.Unicode))
                    {
                        if (!"::".Equals(sb.ToString().Substring(0, 2)))
                            sb.Insert(0, "::Watch THE PATH!!記得路徑不同就得修改\r\n");

                        string batCmd = sb.ToString().Replace("del", "del /f").Replace("rmdir", "rmdir /s /q");
                        srOutFile.Write(batCmd);
                        srOutFile.Flush();
                        srOutFile.Close();

                        System.Windows.Forms.MessageBox.Show("匯出成功!!注意路徑名稱");
                    }
                }
            }
        }
    }
}