using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.Extensions;
using OpenCvSharp.UserInterface;

namespace WFapp_OpencvSharp_20200407
{
    public partial class Form1 : Form
    {
        private bool isOpenCamera;
        private bool isFaceDetect;
        private Thread myThread;
        private VideoCapture myVideoCapture;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            myVideoCapture = new VideoCapture(CaptureDevice.Any);                
            if (!myVideoCapture.IsOpened())
              {
                MessageBox.Show("摄像头开启失败", "故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              }
            myVideoCapture.Set(CaptureProperty.FrameWidth, 450);//宽度
            myVideoCapture.Set(CaptureProperty.FrameHeight, 360);//高度
            isOpenCamera = true;
            myThread = new Thread(PlayCamera);
            myThread.Start();
            btnOpenCamera.Text = "CloseCamera";
        }
        private void PlayCamera()
        {
            while (true)
            {
                Mat myFrame = new Mat();
                myVideoCapture.Read(myFrame);

                int sleepTime = (int)Math.Round(1000 / myVideoCapture.Fps);
                Cv2.WaitKey(sleepTime);
                if (myFrame.Empty())
                {
                    continue;
                }
                Cv2.Flip(myFrame, myFrame, OpenCvSharp.FlipMode.Y);
                Rect myRect = new Rect(0, 0, 450, 360);
                Mat newFrame = new Mat(myFrame, myRect);
                if (isFaceDetect)
                {
                    //FaceDetect(newFrame);
                }
                else
                {
                    pictureBox_PlayCamera.Image = newFrame.ToBitmap();
                }
                myFrame.Release();
            }
        }
    }
}
