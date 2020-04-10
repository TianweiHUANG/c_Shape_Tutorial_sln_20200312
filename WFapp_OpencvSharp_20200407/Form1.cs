using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
//using System.Threading.Tasks;
using OpenCvSharp;
//using OpenCvSharp.Blob;
using OpenCvSharp.Extensions;
//using OpenCvSharp.UserInterface;

namespace WFapp_OpencvSharp_20200407
{
    public partial class Form1 : Form
    {
        private bool isOpenCamera;
        private bool isFaceDetect;
        private bool isTakePicture;
        private Thread myThread;
        private VideoCapture myVideoCapture;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isOpenCamera = false;
            isFaceDetect = false;
            isTakePicture = false;

            myThread.Abort();
            myVideoCapture.Release();
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            if (!isOpenCamera)
            {
                myVideoCapture = new VideoCapture(CaptureDevice.Any);                
                if (!myVideoCapture.IsOpened())
                {
                    MessageBox.Show("摄像头开启失败", "摄像头故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                myVideoCapture.Set(CaptureProperty.FrameWidth, 450);//宽度
                myVideoCapture.Set(CaptureProperty.FrameHeight, 360);//高度
                isOpenCamera = true;
                myThread = new Thread(PlayCamera);
                myThread.Start();

                pictureBox_PlayCamera.Image = null;
                btnOpenCamera.Text = "CloseCamera";
            }
            else
            {
                isOpenCamera = false;
                myThread.Abort();
                myVideoCapture.Release();
                btnOpenCamera.Text = "OpenCamera";
            }           
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            isTakePicture = true;         
        }

        private void btnOpenFaceDetect_Click(object sender, EventArgs e)
        {
            if (!isFaceDetect)
            {
                isFaceDetect = true;
                btnOpenFaceDetect.Text = "CloseFaceDetect";
            }
            else
            {
                isFaceDetect = false;
                btnOpenFaceDetect.Text = "OpenFaceDetect";
            }
        }

        private void PlayCamera()
        {
            while (isOpenCamera)
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
                Mat myNewFrame = new Mat(myFrame, myRect);
                if (isTakePicture)
                {
                    Cv2.ImWrite(@"TakePicture_Hub\Pic_"+@DateTime.Now.ToString("yyyyMMddHHmmss")+@".jpg", myNewFrame);
                    isTakePicture=false;
                }
                if (isFaceDetect)
                {
                    FaceDetect(myNewFrame);
                }
                else
                {
                    pictureBox_PlayCamera.Image = myNewFrame.ToBitmap();
                }
                myFrame.Release();
            }
        }

        private void FaceDetect(Mat src)
        {
            Mat grayImage = new Mat();
            Cv2.CvtColor(src, grayImage, ColorConversionCodes.BGR2GRAY);
            Cv2.EqualizeHist(grayImage, grayImage);

            //"haarcascades\haarcascade_frontalface_alt.xml"not found
            //github：https://github.com/opencv/opencv/tree/master/data/haarcascades
            CascadeClassifier cascade = new CascadeClassifier(@"haarcascades\haarcascade_frontalface_alt.xml");
            Rect[] faces = cascade.DetectMultiScale(
                image: grayImage,
                scaleFactor: 1.1,
                minNeighbors: 1,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: new OpenCvSharp.Size(30, 30)
            );
            if (faces.Length <= 0) //未识别到人脸
            {
                pictureBox_PlayCamera.Image = src.ToBitmap();                
            }
            else
            {
                Bitmap myBitmap = src.ToBitmap();
                Graphics g = Graphics.FromImage(myBitmap);
                Font font = new Font("宋体", 16, GraphicsUnit.Pixel);
                SolidBrush fontLine = new SolidBrush(Color.Yellow);                
                foreach (Rect face in faces)
                {
                    g.DrawRectangle(new Pen(Color.YellowGreen, 2), face.X, face.Y, face.Width, face.Height);                   
                }
                g.Save();
                pictureBox_PlayCamera.Image = myBitmap;                            
            }
        }
    }
}
