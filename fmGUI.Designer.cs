namespace InputSourceDDC
{
    partial class fmGUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Displays = new System.Windows.Forms.ComboBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Power = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DISPLAY:";
            // 
            // cb_Displays
            // 
            this.cb_Displays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Displays.FormattingEnabled = true;
            this.cb_Displays.Location = new System.Drawing.Point(85, 16);
            this.cb_Displays.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.cb_Displays.Name = "cb_Displays";
            this.cb_Displays.Size = new System.Drawing.Size(484, 25);
            this.cb_Displays.TabIndex = 1;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(109, 54);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(100, 10, 100, 3);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(166, 32);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(9, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(469, 26);
            this.button6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 58);
            this.button6.TabIndex = 5;
            this.button6.Tag = "DVI_1";
            this.button6.Text = "DVI_1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.SendMessage);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(377, 26);
            this.button5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 58);
            this.button5.TabIndex = 4;
            this.button5.Tag = "VGA_1";
            this.button5.Text = "VGA_1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.SendMessage);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(285, 26);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 58);
            this.button4.TabIndex = 3;
            this.button4.Tag = "DisplayPort_2";
            this.button4.Text = "DP_2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SendMessage);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(193, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 58);
            this.button3.TabIndex = 2;
            this.button3.Tag = "DisplayPort_1";
            this.button3.Text = "DP_1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SendMessage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(101, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 58);
            this.button2.TabIndex = 1;
            this.button2.Tag = "HDMI_2";
            this.button2.Text = "HDMI_2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SendMessage);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 58);
            this.button1.TabIndex = 0;
            this.button1.Tag = "HDMI_1";
            this.button1.Text = "HDMI_1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendMessage);
            // 
            // btn_Power
            // 
            this.btn_Power.Location = new System.Drawing.Point(309, 54);
            this.btn_Power.Margin = new System.Windows.Forms.Padding(100, 10, 100, 3);
            this.btn_Power.Name = "btn_Power";
            this.btn_Power.Size = new System.Drawing.Size(166, 32);
            this.btn_Power.TabIndex = 4;
            this.btn_Power.Tag = "PowerSwitch";
            this.btn_Power.Text = "Power On/Off";
            this.btn_Power.UseVisualStyleBackColor = true;
            this.btn_Power.Click += new System.EventHandler(this.SendMessage);
            // 
            // fmGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 201);
            this.Controls.Add(this.btn_Power);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.cb_Displays);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmGUI";
            this.Shown += new System.EventHandler(this.fmGUI_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Displays;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_Power;
    }
}

