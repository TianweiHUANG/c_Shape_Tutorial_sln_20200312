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
            this.btnOpenFaceDetect = new System.Windows.Forms.Button();
            this.btnTakePicture = new System.Windows.Forms.Button();
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
            this.btnOpenCamera.Location = new System.Drawing.Point(48, 384);
            this.btnOpenCamera.Name = "btnOpenCamera";
            this.btnOpenCamera.Size = new System.Drawing.Size(105, 50);
            this.btnOpenCamera.TabIndex = 1;
            this.btnOpenCamera.Text = "OpenCamera";
            this.btnOpenCamera.UseVisualStyleBackColor = true;
            this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
            // 
            // btnOpenFaceDetect
            // 
            this.btnOpenFaceDetect.Location = new System.Drawing.Point(333, 384);
            this.btnOpenFaceDetect.Name = "btnOpenFaceDetect";
            this.btnOpenFaceDetect.Size = new System.Drawing.Size(105, 50);
            this.btnOpenFaceDetect.TabIndex = 2;
            this.btnOpenFaceDetect.Text = "OpenFaceDetect";
            this.btnOpenFaceDetect.UseVisualStyleBackColor = true;
            this.btnOpenFaceDetect.Click += new System.EventHandler(this.btnOpenFaceDetect_Click);
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(191, 384);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(105, 50);
            this.btnTakePicture.TabIndex = 3;
            this.btnTakePicture.Text = "TakePicture";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.btnTakePicture);
            this.Controls.Add(this.btnOpenFaceDetect);
            this.Controls.Add(this.btnOpenCamera);
            this.Controls.Add(this.pictureBox_PlayCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PlayCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_PlayCamera;
        private System.Windows.Forms.Button btnOpenCamera;
        private System.Windows.Forms.Button btnOpenFaceDetect;
        private System.Windows.Forms.Button btnTakePicture;
    }
}

