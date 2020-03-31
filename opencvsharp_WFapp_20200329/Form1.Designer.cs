namespace opencvsharp_WFapp_20200329
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
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.btnOpenCamera = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(20, 20);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(450, 360);
            this.picCamera.TabIndex = 0;
            this.picCamera.TabStop = false;
            // 
            // btnOpenCamera
            // 
            this.btnOpenCamera.Location = new System.Drawing.Point(80, 400);
            this.btnOpenCamera.Name = "btnOpenCamera";
            this.btnOpenCamera.Size = new System.Drawing.Size(80, 40);
            this.btnOpenCamera.TabIndex = 1;
            this.btnOpenCamera.Text = "打开摄像头";
            this.btnOpenCamera.UseVisualStyleBackColor = true;
            this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 40);
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
            this.Controls.Add(this.picCamera);
            this.Name = "Form1";
            this.Text = "OpenCvSharp_WFapp";
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.Button btnOpenCamera;
        private System.Windows.Forms.Button button2;
    }
}

