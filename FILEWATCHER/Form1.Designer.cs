namespace FILEWATCHER
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.M_TEXTBOX = new System.Windows.Forms.TextBox();
            this.M_BTN = new System.Windows.Forms.Button();
            this.WATCH_BTN = new System.Windows.Forms.Button();
            this.S_TEXTBOX = new System.Windows.Forms.TextBox();
            this.REPLICATE_BTN = new System.Windows.Forms.Button();
            this.TB_RESULT = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Watching_PictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Watching_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // M_TEXTBOX
            // 
            this.M_TEXTBOX.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_TEXTBOX.Location = new System.Drawing.Point(8, 25);
            this.M_TEXTBOX.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.M_TEXTBOX.Name = "M_TEXTBOX";
            this.M_TEXTBOX.Size = new System.Drawing.Size(439, 31);
            this.M_TEXTBOX.TabIndex = 0;
            // 
            // M_BTN
            // 
            this.M_BTN.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_BTN.Location = new System.Drawing.Point(456, 22);
            this.M_BTN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.M_BTN.Name = "M_BTN";
            this.M_BTN.Size = new System.Drawing.Size(117, 35);
            this.M_BTN.TabIndex = 2;
            this.M_BTN.Text = "Browse";
            this.M_BTN.UseVisualStyleBackColor = true;
            this.M_BTN.Click += new System.EventHandler(this.M_BTN_Click);
            // 
            // WATCH_BTN
            // 
            this.WATCH_BTN.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WATCH_BTN.Location = new System.Drawing.Point(16, 184);
            this.WATCH_BTN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.WATCH_BTN.Name = "WATCH_BTN";
            this.WATCH_BTN.Size = new System.Drawing.Size(100, 35);
            this.WATCH_BTN.TabIndex = 3;
            this.WATCH_BTN.Text = "START";
            this.WATCH_BTN.UseVisualStyleBackColor = true;
            this.WATCH_BTN.Click += new System.EventHandler(this.WATCH_BTN_Click);
            // 
            // S_TEXTBOX
            // 
            this.S_TEXTBOX.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S_TEXTBOX.Location = new System.Drawing.Point(8, 25);
            this.S_TEXTBOX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.S_TEXTBOX.Name = "S_TEXTBOX";
            this.S_TEXTBOX.Size = new System.Drawing.Size(565, 31);
            this.S_TEXTBOX.TabIndex = 7;
            // 
            // REPLICATE_BTN
            // 
            this.REPLICATE_BTN.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REPLICATE_BTN.Location = new System.Drawing.Point(384, 184);
            this.REPLICATE_BTN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.REPLICATE_BTN.Name = "REPLICATE_BTN";
            this.REPLICATE_BTN.Size = new System.Drawing.Size(117, 35);
            this.REPLICATE_BTN.TabIndex = 8;
            this.REPLICATE_BTN.Text = "REPLICATE";
            this.REPLICATE_BTN.UseVisualStyleBackColor = true;
            this.REPLICATE_BTN.Click += new System.EventHandler(this.REPLICATE_BTN_Click);
            // 
            // TB_RESULT
            // 
            this.TB_RESULT.Location = new System.Drawing.Point(16, 240);
            this.TB_RESULT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_RESULT.Name = "TB_RESULT";
            this.TB_RESULT.ReadOnly = true;
            this.TB_RESULT.Size = new System.Drawing.Size(580, 210);
            this.TB_RESULT.TabIndex = 9;
            this.TB_RESULT.Text = "";
            this.TB_RESULT.TextChanged += new System.EventHandler(this.TB_RESULT_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.M_TEXTBOX);
            this.groupBox1.Controls.Add(this.M_BTN);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(581, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitor Path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.S_TEXTBOX);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 109);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(581, 69);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination Path(\",\" toSplit)";
            // 
            // Watching_PictureBox
            // 
            this.Watching_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Watching_PictureBox.Image")));
            this.Watching_PictureBox.Location = new System.Drawing.Point(509, 184);
            this.Watching_PictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.Watching_PictureBox.Name = "Watching_PictureBox";
            this.Watching_PictureBox.Size = new System.Drawing.Size(81, 46);
            this.Watching_PictureBox.TabIndex = 14;
            this.Watching_PictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 464);
            this.Controls.Add(this.Watching_PictureBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TB_RESULT);
            this.Controls.Add(this.REPLICATE_BTN);
            this.Controls.Add(this.WATCH_BTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "File Watcher 20230409";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Watching_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button M_BTN;
        private System.Windows.Forms.Button WATCH_BTN;
        private System.Windows.Forms.TextBox S_TEXTBOX;
        private System.Windows.Forms.Button REPLICATE_BTN;
        public System.Windows.Forms.TextBox M_TEXTBOX;
        public System.Windows.Forms.RichTextBox TB_RESULT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox Watching_PictureBox;
    }
}

