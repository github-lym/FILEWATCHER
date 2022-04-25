using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILEWATCHER
{
    public partial class Form1 : Form
    {
        private Watcher _watcher = new Watcher();

        public Form1()
        {
            InitializeComponent();
            Watcher.StartApp();
            Watching_PictureBox.Visible = false;
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

            if (!string.IsNullOrWhiteSpace(M_TEXTBOX.Text) && Directory.Exists(M_TEXTBOX.Text.Trim()))
            {
                if ("START".Equals(WATCH_BTN.Text))
                {
                    watch = true;
                    M_TEXTBOX.ReadOnly = true;
                    M_BTN.Enabled = false;
                    S_TEXTBOX.ReadOnly = true;
                    Watching_PictureBox.Visible = true;
                    WATCH_BTN.Text = "STOP";
                }
                else if ("STOP".Equals(WATCH_BTN.Text))
                {
                    watch = false;
                    M_TEXTBOX.ReadOnly = false;
                    M_BTN.Enabled = true;
                    S_TEXTBOX.ReadOnly = false;
                    Watching_PictureBox.Visible = false;
                    REPLICATE_BTN.Enabled = true;
                    WATCH_BTN.Text = "START";
                }

                var arr = this.S_TEXTBOX.Text.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (watch)
                {
                    _watcher.StartWatch(M_TEXTBOX.Text.Trim(), arr);
                    _watcher.WatchChanged().WatchCreated().WatchDeleted().WatchRenamed();
                }
                else
                { _watcher.StopWatch(); }
            }
            else
                MessageBox.Show("請檢查路徑");
        }

        private void REPLICATE_BTN_Click(object sender, EventArgs e)
        {
            TB_RESULT.Text = _watcher.Replicate();
        }
    }
}