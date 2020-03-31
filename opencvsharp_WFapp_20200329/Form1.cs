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

namespace opencvsharp_WFapp_20200329
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            bool isOpenCamera = false;
            if (!isOpenCamera)
            {
                VideoCapture myVideoCapture = new VideoCapture(CaptureDevice.Any);
                if (!myVideoCapture.IsOpened())
                {
                    MessageBox.Show("摄像头开启失败", "故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                myVideoCapture.Set(CaptureProperty.FrameWidth, 640);//宽度
                myVideoCapture.Set(CaptureProperty.FrameHeight, 480);//高度
                isOpenCamera = true;
                Thread myThread = new Thread(playVideo);
                myThread.Start();
                btnOpenCamera.Text = "关闭摄像头";
            }
            else
            {
                VideoCapture myVideoCapture = new VideoCapture(CaptureDevice.Any);
                Thread myThread = new Thread(playVideo);

                isOpenCamera = false;
                myThread.Abort();
                myVideoCapture.Release();
                btnOpenCamera.Text = "打开摄像头";
            }
          
        }

        private void playVideo()
        {
            while (true)
            {
                VideoCapture myVideoCapture = new VideoCapture(CaptureDevice.Any);
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

                bool isFaceDetect = false;
                if (isFaceDetect)
                {
                    //faceDetect(newFrame);
                }
                else
                {
                    picCamera.Image = newFrame.ToBitmap();
                }
                myFrame.Release();
            }
        }       
    }
}
