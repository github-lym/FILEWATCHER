using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FILEWATCHER
{
    public class Watcher
    {
        public static FileSystemWatcher _fileWatcher = null;
        public static FileSystemWatcher _dirWatcher = null;
        public static StringBuilder _sb = null;
        public static Dictionary<string, string> dic_cmd = new Dictionary<string, string>();
        //public static Logger logger = new Logger();
        public static Logger logger;
        public static string _watchFolder = string.Empty;
        public static string[] _destination;
        //private string _msg = string.Empty;

        //public string Msg
        //{
        //    get { return _msg; }
        //    set { _msg = value; }
        //}

        //public Watcher(string watchFolder)
        //{
        //    _watch = new FileSystemWatcher
        //    {
        //        // 設定要監看的資料夾
        //        Path = watchFolder,
        //        // 設定要監看的變更類型
        //        NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
        //        // 設定要監看的檔案類型
        //        Filter = "*.*",
        //        // 設定是否監看子資料夾
        //        IncludeSubdirectories = true,
        //        // 設定是否啟動元件，必須要設定為 true，否則事件是不會被觸發
        //        EnableRaisingEvents = true
        //    };
        //}


        /// <summary>
        /// 初始化log
        /// </summary>
        private static void CreateLogger()
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget
            {
                FileName = "${basedir}/${date:format=yyyyMM}/${shortdate}.log",
                Layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} [${uppercase:${level}}] ${message}",
                Encoding = Encoding.UTF8,
            };
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget);
            LogManager.Configuration = config;
        }

        /// <summary>
        /// 啟動
        /// </summary>
        public static void StartApp()
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.Arguments = $"/c chcp 65001";
                p.Start();

                CreateLogger();
                logger = LogManager.GetCurrentClassLogger();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
                throw;
            }
        }

        /// <summary>
        /// 監看開始
        /// </summary>
        public void StartWatch(string watchFolder, string[] destination)
        {
            try
            {
                if (string.Empty.Equals(watchFolder) || !Directory.Exists(watchFolder.Trim()))
                {
                    System.Windows.Forms.MessageBox.Show("請檢查路徑");
                }
                else
                {
                    _watchFolder = watchFolder;
                    _destination = destination;
                    //logger.ExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    _sb = new StringBuilder();
                    //_sb.AppendLine("::Watch the path");

                    _fileWatcher = new FileSystemWatcher();
                    _dirWatcher = new FileSystemWatcher();

                    //設定要監看的資料夾
                    _fileWatcher.Path = watchFolder;
                    _dirWatcher.Path = watchFolder;

                    // 設定要監看的變更類型
                    //fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    _fileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
                    _dirWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.DirectoryName;

                    // 設定要監看的檔案類型
                    _fileWatcher.Filter = "*.*";
                    _dirWatcher.Filter = "*.*";

                    // 設定是否監看子資料夾
                    _fileWatcher.IncludeSubdirectories = true;
                    _dirWatcher.IncludeSubdirectories = true;

                    // 設定是否啟動元件，必須要設定為 true，否則事件是不會被觸發
                    _fileWatcher.EnableRaisingEvents = true;
                    _dirWatcher.EnableRaisingEvents = true;

                    //_sb.AppendLine("chcp 65001");
                    _sb.AppendLine($"cd /d  {watchFolder}");
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// 監看取消
        /// </summary>
        public void StopWatch()
        {
            _fileWatcher.EnableRaisingEvents = false;
            _fileWatcher.Created -= new FileSystemEventHandler(_Watch_Created);
            _fileWatcher.Deleted -= new FileSystemEventHandler(_Watch_Deleted);
            _fileWatcher.Changed -= new FileSystemEventHandler(_Watch_Changed);
            _fileWatcher.Renamed -= new RenamedEventHandler(_Watch_Renamed);
            _fileWatcher.Dispose();

            _dirWatcher.EnableRaisingEvents = false;
            _dirWatcher.Created -= new FileSystemEventHandler(_Watch_Created);
            _dirWatcher.Deleted -= new FileSystemEventHandler(_Watch_Deleted);
            _dirWatcher.Changed -= new FileSystemEventHandler(_Watch_Changed);
            _dirWatcher.Renamed -= new RenamedEventHandler(_Watch_Renamed);
            _dirWatcher.Dispose();
        }

        /// <summary>
        /// 模仿動作
        /// </summary>
        public void Replicate()
        {
            string back = string.Empty;

            try
            {
                //Export(arr, watchPath);
                StringBuilder _nsb = new StringBuilder();

                if (_destination == null || _destination.Length == 0)
                    _nsb = _sb;
                else
                {
                    //string _bsb = _sb.ToString();
                    string[] _bsbArr = _sb.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                    for (int i = 0; i < _destination.Length; i++)
                    {
                        for (int a = 0; a < _bsbArr.Length; a++)
                        {
                            if (_bsbArr[a].StartsWith("robocopy"))
                                _nsb.AppendLine(_bsbArr[a].Replace("[TargetPath]", _destination[i].Trim()));
                            else
                                _nsb.AppendLine(_bsbArr[a].Replace(_watchFolder, _destination[i].Trim()));
                        }
                        //_nsb.Append(_bsb.Replace(watchPath, arr[i]));
                    }
                }

                using (StringReader SR = new StringReader(_nsb.ToString()))
                {
                    string errMsg = string.Empty;
                    string line = string.Empty;
                    int rowNum = 0;
                    //var objj = (Form1)Application.OpenForms["Form1"];
                    RichTextBox t = Application.OpenForms["Form1"].Controls["TB_RESULT"] as RichTextBox;

                    while ((line = SR.ReadLine()) != null)
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.CreateNoWindow = true;

                        //TB_RESULT.Text += line + Environment.NewLine;
                        //Application.DoEvents();
                        if (line.StartsWith("del"))
                        {
                            string file = line.Replace("del", "").Replace(@"""", "").Trim();
                            if (!File.Exists(file))
                            {
                                t.Text += file + " 已不存在!" + Environment.NewLine;
                                //back += file + " 已不存在!" + Environment.NewLine;
                                continue;
                            }
                        }
                        //if (line.StartsWith("rmdir /S"))
                        //{
                        //    string folder = line.Replace("rmdir /S", "").Replace(@"""", "").Trim();
                        //    if (!Directory.Exists(folder))
                        //    {
                        //        back += folder + " 已不存在!" + Environment.NewLine;
                        //        continue;
                        //    }
                        //}

                        t.Text += line + Environment.NewLine;
                        //back += line + Environment.NewLine;

                        rowNum++;
                        p.StartInfo.Arguments = $"/c {line}";
                        p.Start();
                        errMsg = p.StandardError.ReadToEnd();
                        //returnCode = p.ExitCode;
                        Form1.ActiveForm.Refresh();
                        Thread.Sleep(100);
                        p.WaitForExit();

                        if (!string.IsNullOrWhiteSpace(errMsg))
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"ERR LINE : {rowNum}");
                            sb.AppendLine(errMsg);

                            //back += errMsg + Environment.NewLine;
                            t.Text += errMsg + Environment.NewLine;
                            //MessageBox.Show(sb.ToString());
                            MessageBox.Show(sb.ToString());
                            break;
                        }

                        //objj.TB_RESULT.Refresh();
                    }
                }
                _sb.Clear();
                //var objj = (Form1)Application.OpenForms["Form1"];
                //objj.TB_RESULT.Text = back;
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.ToString());
                MessageBox.Show(ex.ToString());
                throw;
            }

            //return back;
        }

        /// <summary>
        /// 設定監看新增檔案的觸發事件
        /// </summary>
        public Watcher WatchCreated()
        {
            _fileWatcher.Created += new FileSystemEventHandler(_Watch_Created);
            _dirWatcher.Created += new FileSystemEventHandler(_Watch_Created);
            return this;
        }

        /// <summary>
        /// 設定監看修改檔案的觸發事件
        /// </summary>
        public Watcher WatchChanged()
        {
            _fileWatcher.Changed += new FileSystemEventHandler(_Watch_Changed);
            _dirWatcher.Changed += new FileSystemEventHandler(_Watch_Changed);
            return this;
        }

        /// <summary>
        /// 設定監看重新命名的觸發事件
        /// </summary>
        public Watcher WatchRenamed()
        {
            _fileWatcher.Renamed += new RenamedEventHandler(_Watch_Renamed);
            _dirWatcher.Renamed += new RenamedEventHandler(_Watch_Renamed);
            return this;
        }

        /// <summary>
        /// 設定監看刪除檔案的觸發事件
        /// </summary>
        public Watcher WatchDeleted()
        {
            _fileWatcher.Deleted += new FileSystemEventHandler(_Watch_Deleted);
            _dirWatcher.Deleted += new FileSystemEventHandler(_Watch_Deleted);
            return this;
        }

        /// <summary>
        /// 當所監看的資料夾有建立文字檔時觸發
        /// </summary>
        private void _Watch_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                //_fileWatcher.EnableRaisingEvents = false;
                //_dirWatcher.EnableRaisingEvents = false;
                /* do my stuff once asynchronously */

                var sb = new StringBuilder();
                var dirInfo = new DirectoryInfo(e.FullPath);


                sb.AppendLine($"新建檔案於：{dirInfo.FullName.Replace(dirInfo.Name, string.Empty)}");
                sb.AppendLine($"新建檔案名稱：{dirInfo.Name}");
                sb.AppendLine($"建立時間：{dirInfo.CreationTime}");
                //sb.AppendLine($"存取時間：{dirInfo.LastAccessTime}");
                //sb.AppendLine($"目錄下共有：{dirInfo.Parent?.GetFiles().Length} 檔案");
                //sb.AppendLine($"目錄下共有：{dirInfo.Parent?.GetDirectories().Length} 資料夾");
                //Console.WriteLine(sb.ToString());
                logger.Info(sb.ToString());

                if (sender == _dirWatcher)
                {
                    if (dic_cmd.ContainsKey(dirInfo.Name))
                    {
                        string cmd = dic_cmd[dirInfo.Name].Replace("rmdir", "move") + " " + "\"" + dirInfo.FullName + "\"";
                        _sb.Replace(dic_cmd[dirInfo.Name], cmd);
                        dic_cmd.Remove(dirInfo.Name);
                    }
                    else
                        _sb.AppendLine($"mkdir \"{dirInfo.FullName}\"");
                }
                else if (sender == _fileWatcher)
                {
                    string s = $"{dirInfo.FullName.Replace('\\' + dirInfo.Name, string.Empty)}";
                    //var objj = (Form1)Application.OpenForms["Form1"];
                    //string watchPath = objj.M_TEXTBOX.Text.Trim();
                    string t = s.Replace(_watchFolder, "[TargetPath]");
                    if (dic_cmd.ContainsKey(dirInfo.Name))
                    {
                        string cmd = dic_cmd[dirInfo.Name].Replace("del", "move") + " " + "\"" + dirInfo.FullName + "\"";
                        _sb.Replace(dic_cmd[dirInfo.Name], cmd);
                        dic_cmd.Remove(dirInfo.Name);
                    }
                    else
                    {
                        string add = $"robocopy \"{s}\" \"{t}\" \"{dirInfo.Name}\" /NP /NFL /MT:32";

                        //var _sbNow = _sb.ToString().Split('\n');
                        //var last = _sbNow.LastOrDefault();
                        //var secondLast = _sbNow.Skip(_sbNow.Length - 2).FirstOrDefault();
                        //if (string.Compare(secondLast, add) != 0)
                        _sb.AppendLine(add);
                    }
                }
            }
            finally
            {
                //_fileWatcher.EnableRaisingEvents = true;
                //_dirWatcher.EnableRaisingEvents = true;
            }
        }

        /// <summary>
        /// 當所監看的資料夾有文字檔檔案內容有異動時觸發
        /// </summary>
        private void _Watch_Changed(object sender, FileSystemEventArgs e)
        {
            //var sb = new StringBuilder();
            var dirInfo = new DirectoryInfo(e.FullPath);

            //sb.AppendLine($"被異動的檔名為：{e.Name}");
            //sb.AppendLine($"檔案路徑為：{e.FullPath.Replace(e.Name, "")}");
            //sb.AppendLine($"異動內容時間為：{dirInfo.LastWriteTime}");
            //sb.AppendLine($"最後一筆內容：{File.ReadLines(e.FullPath).Last()}");
            //Console.WriteLine(sb.ToString());
            //ToLog.LOGGER(sb.ToString());

            //if (sender == _dirWatcher)
            //{

            //}
            if (sender == _fileWatcher)
            {
                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    string s = $"{dirInfo.FullName.Replace('\\' + dirInfo.Name, string.Empty)}";
                    var objj = (Form1)Application.OpenForms["Form1"];
                    string watchPath = objj.M_TEXTBOX.Text.Trim();
                    string t = s.Replace(watchPath, "[TargetPath]");
                    string add = $"robocopy \"{s}\" \"{t}\" \"{dirInfo.Name}\" /NP /NFL /MT:32";

                    //var _sbNow = _sb.ToString().Split('\n');
                    //var last = _sbNow.LastOrDefault();
                    //var secondLast = _sbNow.Skip(_sbNow.Length - 2).FirstOrDefault();
                    //if (string.Compare(secondLast, add) != 0)
                    _sb.AppendLine(add);
                }
            }
        }
        /// <summary>
        /// 當所監看的資料夾有文字檔檔案重新命名時觸發
        /// </summary>
        private void _Watch_Renamed(object sender, RenamedEventArgs e)
        {
            var sb = new StringBuilder();
            var fileInfo = new FileInfo(e.FullPath);

            sb.AppendLine($"檔名更新前路徑：{e.OldFullPath}");
            sb.AppendLine($"檔名更新後路徑：{e.FullPath}");
            sb.AppendLine($"建立時間：{fileInfo.LastAccessTime}");
            //Console.WriteLine(sb.ToString());
            logger.Info(sb.ToString());

            if (sender == _dirWatcher)
            {
                _sb.AppendLine($"rename \"{e.OldFullPath}\" \"{((e.FullPath).Replace(System.IO.Path.GetDirectoryName(e.FullPath), "")).Replace("\\", "")}\"");
            }
            else if (sender == _fileWatcher)
            {
                _sb.AppendLine($"rename \"{e.OldFullPath}\" \"{System.IO.Path.GetFileName(e.FullPath)}\"");
            }
        }

        /// <summary>
        /// 當所監看的資料夾有文字檔檔案有被刪除時觸發
        /// </summary>
        private void _Watch_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                var sb = new StringBuilder();
                var dirInfo = new DirectoryInfo(e.FullPath);

                sb.AppendLine($"被刪除的檔名為：{dirInfo.Name}");
                sb.AppendLine($"檔案路徑為：{dirInfo.FullName.Replace(dirInfo.Name, string.Empty)}");
                //sb.AppendLine($"被刪除的檔案為：{e.FullPath}");
                sb.AppendLine($"刪除時間：{DateTime.Now}");
                //Console.WriteLine(sb.ToString());
                logger.Info(sb.ToString());

                if (sender == _fileWatcher)
                {
                    if (!dic_cmd.ContainsKey(System.IO.Path.GetFileName(e.FullPath)))
                    {
                        _sb.AppendLine($"del \"{e.FullPath}\"");
                        dic_cmd.Add(System.IO.Path.GetFileName(e.FullPath), $"del \"{e.FullPath}\"");
                    }
                }
                else if (sender == _dirWatcher)
                {
                    _sb.AppendLine($"rmdir /S /Q \"{e.FullPath}\"");
                    dic_cmd.Add(((e.FullPath).Replace(System.IO.Path.GetDirectoryName(e.FullPath), "")).Replace("\\", ""), $"rmdir /S \"{e.FullPath}\"");
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.ToString());
                MessageBox.Show(ex.ToString());
                throw;
            }

        }
    }
}