namespace WFapp_TCPsocket_20200810
{
    partial class Form2
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
            this.text_SendMsg = new System.Windows.Forms.TextBox();
            this.text_RcvMsg = new System.Windows.Forms.TextBox();
            this.lab_PORT = new System.Windows.Forms.Label();
            this.lab_IPAddress = new System.Windows.Forms.Label();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.text_PORT = new System.Windows.Forms.TextBox();
            this.text_IPAddress = new System.Windows.Forms.TextBox();
            this.lab_name = new System.Windows.Forms.Label();
            this.text_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // text_SendMsg
            // 
            this.text_SendMsg.Location = new System.Drawing.Point(24, 328);
            this.text_SendMsg.Multiline = true;
            this.text_SendMsg.Name = "text_SendMsg";
            this.text_SendMsg.Size = new System.Drawing.Size(280, 88);
            this.text_SendMsg.TabIndex = 3;
            this.text_SendMsg.TextChanged += new System.EventHandler(this.text_SendMsg_TextChanged);
            // 
            // text_RcvMsg
            // 
            this.text_RcvMsg.Location = new System.Drawing.Point(24, 24);
            this.text_RcvMsg.Multiline = true;
            this.text_RcvMsg.Name = "text_RcvMsg";
            this.text_RcvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_RcvMsg.Size = new System.Drawing.Size(280, 288);
            this.text_RcvMsg.TabIndex = 2;
            this.text_RcvMsg.TextChanged += new System.EventHandler(this.text_RcvMsg_TextChanged);
            // 
            // lab_PORT
            // 
            this.lab_PORT.AutoSize = true;
            this.lab_PORT.Location = new System.Drawing.Point(352, 80);
            this.lab_PORT.Name = "lab_PORT";
            this.lab_PORT.Size = new System.Drawing.Size(29, 12);
            this.lab_PORT.TabIndex = 15;
            this.lab_PORT.Text = "PORT";
            this.lab_PORT.Click += new System.EventHandler(this.lab_PORT_Click);
            // 
            // lab_IPAddress
            // 
            this.lab_IPAddress.AutoSize = true;
            this.lab_IPAddress.Location = new System.Drawing.Point(336, 40);
            this.lab_IPAddress.Name = "lab_IPAddress";
            this.lab_IPAddress.Size = new System.Drawing.Size(53, 12);
            this.lab_IPAddress.TabIndex = 14;
            this.lab_IPAddress.Text = "IPAdress";
            this.lab_IPAddress.Click += new System.EventHandler(this.lab_IPAddress_Click);
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(336, 328);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(264, 32);
            this.btn_SendMsg.TabIndex = 13;
            this.btn_SendMsg.Text = "SendMsg";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            this.btn_SendMsg.Click += new System.EventHandler(this.btn_SendMsg_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(336, 160);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(264, 32);
            this.btn_Connect.TabIndex = 12;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // text_PORT
            // 
            this.text_PORT.Location = new System.Drawing.Point(392, 72);
            this.text_PORT.Name = "text_PORT";
            this.text_PORT.Size = new System.Drawing.Size(208, 21);
            this.text_PORT.TabIndex = 11;
            this.text_PORT.TextChanged += new System.EventHandler(this.text_PORT_TextChanged);
            // 
            // text_IPAddress
            // 
            this.text_IPAddress.Location = new System.Drawing.Point(392, 32);
            this.text_IPAddress.Name = "text_IPAddress";
            this.text_IPAddress.Size = new System.Drawing.Size(208, 21);
            this.text_IPAddress.TabIndex = 10;
            this.text_IPAddress.TextChanged += new System.EventHandler(this.text_IPAddress_TextChanged);
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(352, 120);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(29, 12);
            this.lab_name.TabIndex = 17;
            this.lab_name.Text = "Name";
            this.lab_name.Click += new System.EventHandler(this.lab_name_Click);
            // 
            // text_Name
            // 
            this.text_Name.Location = new System.Drawing.Point(392, 112);
            this.text_Name.Name = "text_Name";
            this.text_Name.Size = new System.Drawing.Size(208, 21);
            this.text_Name.TabIndex = 16;
            this.text_Name.TextChanged += new System.EventHandler(this.text_Name_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.text_Name);
            this.Controls.Add(this.lab_PORT);
            this.Controls.Add(this.lab_IPAddress);
            this.Controls.Add(this.btn_SendMsg);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.text_PORT);
            this.Controls.Add(this.text_IPAddress);
            this.Controls.Add(this.text_SendMsg);
            this.Controls.Add(this.text_RcvMsg);
            this.Name = "Form2";
            this.Text = "WFapp_TCPsocket_Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_SendMsg;
        private System.Windows.Forms.TextBox text_RcvMsg;
        private System.Windows.Forms.Label lab_PORT;
        private System.Windows.Forms.Label lab_IPAddress;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox text_PORT;
        private System.Windows.Forms.TextBox text_IPAddress;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.TextBox text_Name;
    }
}