﻿namespace WFapp_OpencvSharp_20200407
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
            this.pictureBox_PlayCamera = new System.Windows.Forms.PictureBox();
            this.btnOpenCamera = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PlayCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_PlayCamera
            // 
            this.pictureBox_PlayCamera.Location = new System.Drawing.Point(18, 18);
            this.pictureBox_PlayCamera.Name = "pictureBox_PlayCamera";
            this.pictureBox_PlayCamera.Size = new System.Drawing.Size(450, 360);
            this.pictureBox_PlayCamera.TabIndex = 0;
            this.pictureBox_PlayCamera.TabStop = false;
            // 
            // btnOpenCamera
            // 
            this.btnOpenCamera.Location = new System.Drawing.Point(18, 384);
            this.btnOpenCamera.Name = "btnOpenCamera";
            this.btnOpenCamera.Size = new System.Drawing.Size(85, 40);
            this.btnOpenCamera.TabIndex = 1;
            this.btnOpenCamera.Text = "button1";
            this.btnOpenCamera.UseVisualStyleBackColor = true;
            this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(383, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOpenCamera);
            this.Controls.Add(this.pictureBox_PlayCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PlayCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_PlayCamera;
        private System.Windows.Forms.Button btnOpenCamera;
        private System.Windows.Forms.Button button2;
    }
}

