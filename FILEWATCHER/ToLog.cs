using System;
using System.IO;
using System.Reflection;

namespace FILEWATCHER
{
    public class ToLog
    {
        private static string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static DateTime todayDateTime = DateTime.Now;
        private static string todayMonth = todayDateTime.ToString("yyyyMM");
        private static string today = todayDateTime.ToString("yyyyMMdd");

        /// <summary>
        /// 寫log
        /// </summary>
        public static void LOGGER(string arg = null)
        {
            DateTime logNow = DateTime.Now;
            string todayMillisecond = logNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff");

            //如果此路徑沒有資料夾
            if (!Directory.Exists(Path.Combine(exePath, todayMonth)))
            {
                //新增資料夾
                Directory.CreateDirectory(Path.Combine(exePath, todayMonth));
            }

            //把內容寫到目的檔案，若檔案存在則附加在原本內容之後(換行)
            if ("newline".Equals(arg))
                File.AppendAllText(Path.Combine(exePath, todayMonth, today + ".txt"), Environment.NewLine);
            else
                File.AppendAllText(Path.Combine(exePath, todayMonth, today + ".txt"), Environment.NewLine + todayMillisecond + " -- " + arg);
        }
    }
}