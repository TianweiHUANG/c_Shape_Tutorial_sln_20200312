namespace WFapp_TcpSocket_20200718
{
    partial class Form_TcpClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.text_Rcv = new System.Windows.Forms.TextBox();
            this.text_Send = new System.Windows.Forms.TextBox();
            this.text_IP = new System.Windows.Forms.TextBox();
            this.text_Port = new System.Windows.Forms.TextBox();
            this.text_Name = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.lab_IP = new System.Windows.Forms.Label();
            this.lab_Port = new System.Windows.Forms.Label();
            this.lab_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_Rcv
            // 
            this.text_Rcv.Location = new System.Drawing.Point(16, 16);
            this.text_Rcv.Multiline = true;
            this.text_Rcv.Name = "text_Rcv";
            this.text_Rcv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_Rcv.Size = new System.Drawing.Size(216, 184);
            this.text_Rcv.TabIndex = 0;
            this.text_Rcv.TextChanged += new System.EventHandler(this.text_Rcv_TextChanged);
            // 
            // text_Send
            // 
            this.text_Send.Location = new System.Drawing.Point(16, 216);
            this.text_Send.Multiline = true;
            this.text_Send.Name = "text_Send";
            this.text_Send.Size = new System.Drawing.Size(216, 208);
            this.text_Send.TabIndex = 1;
            this.text_Send.TextChanged += new System.EventHandler(this.text_Send_TextChanged);
            // 
            // text_IP
            // 
            this.text_IP.Location = new System.Drawing.Point(312, 40);
            this.text_IP.Name = "text_IP";
            this.text_IP.Size = new System.Drawing.Size(160, 21);
            this.text_IP.TabIndex = 2;
            this.text_IP.TextChanged += new System.EventHandler(this.text_IP_TextChanged);
            // 
            // text_Port
            // 
            this.text_Port.Location = new System.Drawing.Point(312, 88);
            this.text_Port.Name = "text_Port";
            this.text_Port.Size = new System.Drawing.Size(160, 21);
            this.text_Port.TabIndex = 3;
            this.text_Port.TextChanged += new System.EventHandler(this.text_Port_TextChanged);
            // 
            // text_Name
            // 
            this.text_Name.Location = new System.Drawing.Point(312, 136);
            this.text_Name.Name = "text_Name";
            this.text_Name.Size = new System.Drawing.Size(160, 21);
            this.text_Name.TabIndex = 4;
            this.text_Name.TextChanged += new System.EventHandler(this.text_Name_TextChanged);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(248, 240);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(224, 40);
            this.btn_Connect.TabIndex = 5;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(248, 304);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(224, 40);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // lab_IP
            // 
            this.lab_IP.AutoSize = true;
            this.lab_IP.Location = new System.Drawing.Point(248, 40);
            this.lab_IP.Name = "lab_IP";
            this.lab_IP.Size = new System.Drawing.Size(35, 12);
            this.lab_IP.TabIndex = 7;
            this.lab_IP.Text = "TcpIP";
            this.lab_IP.Click += new System.EventHandler(this.lab_IP_Click);
            // 
            // lab_Port
            // 
            this.lab_Port.AutoSize = true;
            this.lab_Port.Location = new System.Drawing.Point(248, 88);
            this.lab_Port.Name = "lab_Port";
            this.lab_Port.Size = new System.Drawing.Size(47, 12);
            this.lab_Port.TabIndex = 8;
            this.lab_Port.Text = "TcpPort";
            this.lab_Port.Click += new System.EventHandler(this.lab_Port_Click);
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(248, 136);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(65, 12);
            this.lab_Name.TabIndex = 9;
            this.lab_Name.Text = "MasterName";
            this.lab_Name.Click += new System.EventHandler(this.lab_Name_Click);
            // 
            // Form_TcpClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 442);
            this.Controls.Add(this.lab_Name);
            this.Controls.Add(this.lab_Port);
            this.Controls.Add(this.lab_IP);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.text_Name);
            this.Controls.Add(this.text_Port);
            this.Controls.Add(this.text_IP);
            this.Controls.Add(this.text_Send);
            this.Controls.Add(this.text_Rcv);
            this.Name = "Form_TcpClient";
            this.Text = "Form_TcpClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_Rcv;
        private System.Windows.Forms.TextBox text_Send;
        private System.Windows.Forms.TextBox text_IP;
        private System.Windows.Forms.TextBox text_Port;
        private System.Windows.Forms.TextBox text_Name;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label lab_IP;
        private System.Windows.Forms.Label lab_Port;
        private System.Windows.Forms.Label lab_Name;
    }
}