﻿namespace WFapp_TCPsocket_20200810
{
    partial class Form1
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
            this.text_RcvMsg = new System.Windows.Forms.TextBox();
            this.text_SendMsg = new System.Windows.Forms.TextBox();
            this.text_IPAdress = new System.Windows.Forms.TextBox();
            this.text_PORT = new System.Windows.Forms.TextBox();
            this.list_OneLine = new System.Windows.Forms.ListBox();
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.btn_WFapp_TCPsocket_Client = new System.Windows.Forms.Button();
            this.lab_IPAdress = new System.Windows.Forms.Label();
            this.lab_PORT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_RcvMsg
            // 
            this.text_RcvMsg.Location = new System.Drawing.Point(24, 24);
            this.text_RcvMsg.Multiline = true;
            this.text_RcvMsg.Name = "text_RcvMsg";
            this.text_RcvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_RcvMsg.Size = new System.Drawing.Size(280, 288);
            this.text_RcvMsg.TabIndex = 0;
            this.text_RcvMsg.TextChanged += new System.EventHandler(this.text_RcvMsg_TextChanged);
            // 
            // text_SendMsg
            // 
            this.text_SendMsg.Location = new System.Drawing.Point(24, 328);
            this.text_SendMsg.Multiline = true;
            this.text_SendMsg.Name = "text_SendMsg";
            this.text_SendMsg.Size = new System.Drawing.Size(280, 88);
            this.text_SendMsg.TabIndex = 1;
            this.text_SendMsg.TextChanged += new System.EventHandler(this.text_SendMsg_TextChanged);
            // 
            // text_IPAdress
            // 
            this.text_IPAdress.Location = new System.Drawing.Point(392, 32);
            this.text_IPAdress.Name = "text_IPAdress";
            this.text_IPAdress.Size = new System.Drawing.Size(208, 21);
            this.text_IPAdress.TabIndex = 2;
            this.text_IPAdress.TextChanged += new System.EventHandler(this.text_IPAdress_TextChanged);
            // 
            // text_PORT
            // 
            this.text_PORT.Location = new System.Drawing.Point(392, 72);
            this.text_PORT.Name = "text_PORT";
            this.text_PORT.Size = new System.Drawing.Size(208, 21);
            this.text_PORT.TabIndex = 3;
            this.text_PORT.TextChanged += new System.EventHandler(this.text_PORT_TextChanged);
            // 
            // list_OneLine
            // 
            this.list_OneLine.FormattingEnabled = true;
            this.list_OneLine.ItemHeight = 12;
            this.list_OneLine.Location = new System.Drawing.Point(336, 112);
            this.list_OneLine.Name = "list_OneLine";
            this.list_OneLine.Size = new System.Drawing.Size(264, 136);
            this.list_OneLine.TabIndex = 4;
            this.list_OneLine.SelectedIndexChanged += new System.EventHandler(this.list_OneLine_SelectedIndexChanged);
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(336, 272);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(264, 32);
            this.btn_StartServer.TabIndex = 5;
            this.btn_StartServer.Text = "StartServer";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(336, 328);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(264, 32);
            this.btn_SendMsg.TabIndex = 6;
            this.btn_SendMsg.Text = "SendMsg";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            this.btn_SendMsg.Click += new System.EventHandler(this.btn_SendMsg_Click);
            // 
            // btn_WFapp_TCPsocket_Client
            // 
            this.btn_WFapp_TCPsocket_Client.Location = new System.Drawing.Point(336, 384);
            this.btn_WFapp_TCPsocket_Client.Name = "btn_WFapp_TCPsocket_Client";
            this.btn_WFapp_TCPsocket_Client.Size = new System.Drawing.Size(264, 32);
            this.btn_WFapp_TCPsocket_Client.TabIndex = 7;
            this.btn_WFapp_TCPsocket_Client.Text = "WFapp_TCPsocket_Client";
            this.btn_WFapp_TCPsocket_Client.UseVisualStyleBackColor = true;
            this.btn_WFapp_TCPsocket_Client.Click += new System.EventHandler(this.btn_WFapp_TCPsocket_Client_Click);
            // 
            // lab_IPAdress
            // 
            this.lab_IPAdress.AutoSize = true;
            this.lab_IPAdress.Location = new System.Drawing.Point(336, 40);
            this.lab_IPAdress.Name = "lab_IPAdress";
            this.lab_IPAdress.Size = new System.Drawing.Size(53, 12);
            this.lab_IPAdress.TabIndex = 8;
            this.lab_IPAdress.Text = "IPAdress";
            this.lab_IPAdress.Click += new System.EventHandler(this.lab_IPAdress_Click);
            // 
            // lab_PORT
            // 
            this.lab_PORT.AutoSize = true;
            this.lab_PORT.Location = new System.Drawing.Point(352, 80);
            this.lab_PORT.Name = "lab_PORT";
            this.lab_PORT.Size = new System.Drawing.Size(29, 12);
            this.lab_PORT.TabIndex = 9;
            this.lab_PORT.Text = "PORT";
            this.lab_PORT.Click += new System.EventHandler(this.lab_PORT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.lab_PORT);
            this.Controls.Add(this.lab_IPAdress);
            this.Controls.Add(this.btn_WFapp_TCPsocket_Client);
            this.Controls.Add(this.btn_SendMsg);
            this.Controls.Add(this.btn_StartServer);
            this.Controls.Add(this.list_OneLine);
            this.Controls.Add(this.text_PORT);
            this.Controls.Add(this.text_IPAdress);
            this.Controls.Add(this.text_SendMsg);
            this.Controls.Add(this.text_RcvMsg);
            this.Name = "Form1";
            this.Text = "WFapp_TCPsocket_Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_RcvMsg;
        private System.Windows.Forms.TextBox text_SendMsg;
        private System.Windows.Forms.TextBox text_IPAdress;
        private System.Windows.Forms.TextBox text_PORT;
        private System.Windows.Forms.ListBox list_OneLine;
        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.Button btn_WFapp_TCPsocket_Client;
        private System.Windows.Forms.Label lab_IPAdress;
        private System.Windows.Forms.Label lab_PORT;
    }
}

