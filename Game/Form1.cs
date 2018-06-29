using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simpleOpenGlControl1.InitializeContexts();
           
            bool _fullscreen = false;
            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState= FormWindowState.Maximized;
            }
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);

            //第一象限，0点左下角


        }


        Graphics gsc;
        private float bias;
        private bool i = true;
        private void timer1_Tick(object sender, EventArgs e)
        {

            //bias += 0.0009f;
            //if (bias > 0.8)
            //{
            //    bias = 0;
            //}

            //Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);


            //Gl.glBegin(Gl.GL_POLYGON);           //绘制开始前必须调用glBegin以通知绘制图形的类型,比如还可以绘制点，线等。
            ////Gl.glVertex3f(0.1f+bias, 0f, 0f);
            ////Gl.glVertex3f(0.1f+bias, 1f, 0f);
            ////Gl.glVertex3f(0.2f+bias, 1f, 0f);
            ////Gl.glVertex3f(0.2f+bias, 0f, 0f);


            //Gl.glEnd();
            //Gl.glFinish();

            gsc.Clear(Color.Black);
            //simpleOpenGlControl2.Refresh();
            sinBiasPic += 2;
            if (sinBiasPic > 800)
            {
                sinBiasPic = 0;
            }
            gsc.FillRectangle(new SolidBrush(Color.White), sinBiasPic, 0, 50, gscHeight);
            
            //simpleOpenGlControl1.Refresh();

        }
        private int gscHeight;
        private void button1_Click(object sender, EventArgs e)
        {
            gsc = this.simpleOpenGlControl1.CreateGraphics();
            gscHeight = this.simpleOpenGlControl1.Height;
            this.timer1.Interval = 5;
            timer1.Start();
        }
       
        Graphics gPictureBox;
        private RandomPoint rp;
        private Bitmap[] BM;
        private void button2_Click(object sender, EventArgs e)
        {
            gPictureBox = this.pictureBox1.CreateGraphics();
            heightP = this.pictureBox1.Height;
            rp = new RandomPoint(this.pictureBox1.Width, this.pictureBox1.Height);
            rp.setBarSize(10);
            rp.setPointSize(6);

            //BM = rp.getBitmapMatrix();

            //if (BM[0] == BM[1])
            //{
            //    MessageBox.Show("hh");
            //}
            this.timer3.Interval = 10;
            timer3.Start();
        }

        int height;
        int sinBias = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {

           
            
        }
        int heightP = 0;
        int sinBiasPic = 0;
        System.Diagnostics.Stopwatch sw;
        private void timer3_Tick(object sender, EventArgs e)
        {

            //gPictureBox.Clear(Color.Black);
            //simpleOpenGlControl2.Refresh();
            //sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            sinBiasPic += 1;
            if (sinBiasPic > 800)
            {
                sinBiasPic = 0;
            }
            //gPictureBox.FillRectangle(new SolidBrush(Color.White), sinBiasPic+40, 0, 50, heightP);


            Bitmap b = (Bitmap)rp.getBitmap(sinBiasPic).Clone();

            //gPictureBox.DrawImage(BM[sinBiasPic], 0, 0);
            gPictureBox.DrawImage(b, 0, 0);
            //gPictureBox.FillRectangle(new SolidBrush(Color.Red), sinBiasPic+40, 0, 10, height);

            

            //sw.Stop();
            //TimeSpan ts = sw.Elapsed;
            //this.label3.Text = ts.Milliseconds.ToString();
            // pictureBox1.Refresh();
            simpleOpenGlControl1.Refresh();
        }
    }
}
