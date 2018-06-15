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

        

        private float bias;
        private bool i = true;
        private void timer1_Tick(object sender, EventArgs e)
        {

            bias += 0.005f;
            if (bias > 0.8)
            {
                bias = 0;
            }

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);


            Gl.glBegin(Gl.GL_POLYGON);           //绘制开始前必须调用glBegin以通知绘制图形的类型,比如还可以绘制点，线等。
            Gl.glVertex3f(0.1f+bias, 0f, 0f);
            Gl.glVertex3f(0.1f+bias, 1f, 0f);
            Gl.glVertex3f(0.2f+bias, 1f, 0f);
            Gl.glVertex3f(0.2f+bias, 0f, 0f);

            Gl.glEnd();
            Gl.glEnd();
            Gl.glFinish();
            simpleOpenGlControl1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 5;
            timer1.Start();
        }

        


    }
}
