using System;
using System.Windows.Forms;

namespace FILEWATCHER
{
    public partial class Form1 : Form
    {
        private Watcher _watcher = new Watcher();

        public Form1()
        {
            InitializeComponent();
        }

        private void M_BTN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.M_TEXTBOX.Text = path.SelectedPath;
        }

        private void WATCH_BTN_Click(object sender, EventArgs e)
        {
            bool watch = false;

            if (!string.IsNullOrEmpty(M_TEXTBOX.Text))
            {
                if ("START".Equals(WATCH_BTN.Text))
                {
                    watch = true;
                    WATCH_BTN.Text = "STOP";
                }
                else if ("STOP".Equals(WATCH_BTN.Text))
                {
                    watch = false;
                    WATCH_BTN.Text = "START";
                }

                if (watch)
                {
                    _watcher.StartWatch(M_TEXTBOX.Text.Trim());
                    _watcher.WatchChanged().WatchCreated().WatchDeleted().WatchRenamed();
                }
                else
                { _watcher.StopWatch(); }
            }
            else
                MessageBox.Show("請檢查路徑");
        }

        private void EXPORT_BTN_Click(object sender, EventArgs e)
        {
            var arr = this.S_TEXTBOX.Text.Trim().Split(new char[] { ',' } , StringSplitOptions.RemoveEmptyEntries);
            _watcher.Export(arr,M_TEXTBOX.Text.Trim());
        }

        private void REPLICATE_BTN_Click(object sender, EventArgs e)
        {
            var arr = this.S_TEXTBOX.Text.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            TB_RESULT.Text = _watcher.Replicate(arr, M_TEXTBOX.Text.Trim());
        }
    }
}