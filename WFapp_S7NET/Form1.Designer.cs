namespace WFapp_S7NET
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.cboxCputype = new System.Windows.Forms.ComboBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.txtMAddress = new System.Windows.Forms.TextBox();
            this.txtSV = new System.Windows.Forms.TextBox();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.Read_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "------------------ Connection ------------------";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPUType";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "IPAdress";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rack";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Slot";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(391, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "--------------Read/Write M Menory --------------";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Address";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "SV";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 468);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "PV";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(145, 257);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(125, 50);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(290, 257);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(125, 50);
            this.btnDisconnect.TabIndex = 10;
            this.btnDisconnect.Text = "Disconnection";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(145, 521);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(125, 50);
            this.btnRead.TabIndex = 11;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(290, 521);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(125, 50);
            this.btnWrite.TabIndex = 12;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // cboxCputype
            // 
            this.cboxCputype.FormattingEnabled = true;
            this.cboxCputype.Location = new System.Drawing.Point(145, 69);
            this.cboxCputype.Name = "cboxCputype";
            this.cboxCputype.Size = new System.Drawing.Size(270, 23);
            this.cboxCputype.TabIndex = 13;
            this.cboxCputype.SelectedIndexChanged += new System.EventHandler(this.cboxCputype_SelectedIndexChanged);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(145, 113);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(270, 25);
            this.txtIPAddress.TabIndex = 14;
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_TextChanged);
            // 
            // txtRack
            // 
            this.txtRack.Location = new System.Drawing.Point(145, 157);
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(270, 25);
            this.txtRack.TabIndex = 15;
            this.txtRack.TextChanged += new System.EventHandler(this.txtRack_TextChanged);
            // 
            // txtSlot
            // 
            this.txtSlot.Location = new System.Drawing.Point(145, 201);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(270, 25);
            this.txtSlot.TabIndex = 16;
            this.txtSlot.TextChanged += new System.EventHandler(this.txtSlot_TextChanged);
            // 
            // txtMAddress
            // 
            this.txtMAddress.Location = new System.Drawing.Point(145, 377);
            this.txtMAddress.Name = "txtMAddress";
            this.txtMAddress.Size = new System.Drawing.Size(270, 25);
            this.txtMAddress.TabIndex = 17;
            this.txtMAddress.TextChanged += new System.EventHandler(this.txtMAddress_TextChanged);
            // 
            // txtSV
            // 
            this.txtSV.Location = new System.Drawing.Point(145, 421);
            this.txtSV.Name = "txtSV";
            this.txtSV.Size = new System.Drawing.Size(270, 25);
            this.txtSV.TabIndex = 18;
            this.txtSV.TextChanged += new System.EventHandler(this.txtSV_TextChanged);
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(145, 465);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(270, 25);
            this.txtPV.TabIndex = 19;
            this.txtPV.TextChanged += new System.EventHandler(this.txtPV_TextChanged);
            // 
            // Read_Timer
            // 
            this.Read_Timer.Enabled = true;
            this.Read_Timer.Interval = 200;
            this.Read_Timer.Tick += new System.EventHandler(this.Read_Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 593);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.txtSV);
            this.Controls.Add(this.txtMAddress);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.txtRack);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.cboxCputype);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "S7net_WinForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.ComboBox cboxCputype;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtRack;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.TextBox txtMAddress;
        private System.Windows.Forms.TextBox txtSV;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Timer Read_Timer;
    }
}

