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
            this.M_LABEL = new System.Windows.Forms.Label();
            this.M_BTN = new System.Windows.Forms.Button();
            this.WATCH_BTN = new System.Windows.Forms.Button();
            this.EXPORT_BTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.S_TEXTBOX = new System.Windows.Forms.TextBox();
            this.REPLICATE_BTN = new System.Windows.Forms.Button();
            this.TB_RESULT = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // M_TEXTBOX
            // 
            this.M_TEXTBOX.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.M_TEXTBOX.Location = new System.Drawing.Point(128, 18);
            this.M_TEXTBOX.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.M_TEXTBOX.Name = "M_TEXTBOX";
            this.M_TEXTBOX.Size = new System.Drawing.Size(327, 31);
            this.M_TEXTBOX.TabIndex = 0;
            // 
            // M_LABEL
            // 
            this.M_LABEL.AutoSize = true;
            this.M_LABEL.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.M_LABEL.Location = new System.Drawing.Point(3, 22);
            this.M_LABEL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.M_LABEL.Name = "M_LABEL";
            this.M_LABEL.Size = new System.Drawing.Size(106, 20);
            this.M_LABEL.TabIndex = 1;
            this.M_LABEL.Text = "Monitor Path";
            // 
            // M_BTN
            // 
            this.M_BTN.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.M_BTN.Location = new System.Drawing.Point(473, 18);
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
            this.WATCH_BTN.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WATCH_BTN.Location = new System.Drawing.Point(5, 68);
            this.WATCH_BTN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.WATCH_BTN.Name = "WATCH_BTN";
            this.WATCH_BTN.Size = new System.Drawing.Size(100, 35);
            this.WATCH_BTN.TabIndex = 3;
            this.WATCH_BTN.Text = "START";
            this.WATCH_BTN.UseVisualStyleBackColor = true;
            this.WATCH_BTN.Click += new System.EventHandler(this.WATCH_BTN_Click);
            // 
            // EXPORT_BTN
            // 
            this.EXPORT_BTN.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EXPORT_BTN.Location = new System.Drawing.Point(473, 68);
            this.EXPORT_BTN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.EXPORT_BTN.Name = "EXPORT_BTN";
            this.EXPORT_BTN.Size = new System.Drawing.Size(117, 35);
            this.EXPORT_BTN.TabIndex = 5;
            this.EXPORT_BTN.Text = "EXPORT";
            this.EXPORT_BTN.UseVisualStyleBackColor = true;
            this.EXPORT_BTN.Click += new System.EventHandler(this.EXPORT_BTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "ScriptPath(\",\"toSplit)";
            // 
            // S_TEXTBOX
            // 
            this.S_TEXTBOX.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.S_TEXTBOX.Location = new System.Drawing.Point(128, 112);
            this.S_TEXTBOX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.S_TEXTBOX.Name = "S_TEXTBOX";
            this.S_TEXTBOX.Size = new System.Drawing.Size(327, 31);
            this.S_TEXTBOX.TabIndex = 7;
            // 
            // REPLICATE_BTN
            // 
            this.REPLICATE_BTN.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.REPLICATE_BTN.Location = new System.Drawing.Point(473, 109);
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
            this.TB_RESULT.Location = new System.Drawing.Point(12, 168);
            this.TB_RESULT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_RESULT.Name = "TB_RESULT";
            this.TB_RESULT.ReadOnly = true;
            this.TB_RESULT.Size = new System.Drawing.Size(579, 220);
            this.TB_RESULT.TabIndex = 9;
            this.TB_RESULT.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 400);
            this.Controls.Add(this.TB_RESULT);
            this.Controls.Add(this.REPLICATE_BTN);
            this.Controls.Add(this.S_TEXTBOX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EXPORT_BTN);
            this.Controls.Add(this.WATCH_BTN);
            this.Controls.Add(this.M_BTN);
            this.Controls.Add(this.M_LABEL);
            this.Controls.Add(this.M_TEXTBOX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "File Watcher 20210606";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label M_LABEL;
        private System.Windows.Forms.Button M_BTN;
        private System.Windows.Forms.Button WATCH_BTN;
        private System.Windows.Forms.Button EXPORT_BTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox S_TEXTBOX;
        private System.Windows.Forms.Button REPLICATE_BTN;
        public System.Windows.Forms.TextBox M_TEXTBOX;
        public System.Windows.Forms.RichTextBox TB_RESULT;
    }
}

