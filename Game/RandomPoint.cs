using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RandomPoint
    {
        private int pointSize;
        private int barSize;

        private int width;
        private int height;

        private int pointWidth;
        private int pointHeight;
        private int[,] pointM;
        private int[,] barM;
        private Graphics g;
        private Bitmap bm;

        private Bitmap[] bmMatrix;

        public RandomPoint(int width, int height)
        {
            this.width = width;
            this.height = height;
            bm = new Bitmap(width,height);
            g = Graphics.FromImage(bm);

            bmMatrix = new Bitmap[height];

        }




        public void setPointSize(int size)
        {
            this.pointSize = size;
            pointWidth = width / size + 1;
            pointHeight = height / size + 1;

            pointM = new int[pointHeight, pointWidth];
            

        }
        public void setBarSize(int size)
        {
            this.barSize = size;
            barM = new int[pointHeight, barSize];

        }


        private void DrawBackGround()
        {
            Random rd = new Random(0);
            for (int i = 0; i != pointHeight; i++)
            {
                for (int j = 0; j != pointWidth; j++)
                {
                    int value = rd.Next(0, 100);
                    if (value < 40)
                    {
                        //pointM[i, j] = 1;
                        g.FillRectangle(new SolidBrush(Color.White), j * pointSize, i * pointSize, pointSize, pointSize);

                    }
                    else
                    {
                        //pointM[i, j] = 0;
                        g.FillRectangle(new SolidBrush(Color.Black), j * pointSize, i * pointSize, pointSize, pointSize);
                    }
                }
            }

        }
        public Bitmap getBitmap(int position)
        {


            g.Clear(Color.White);
            DrawBackGround();
            Random rdForBar = new Random(1);

            g.FillRectangle(new SolidBrush(Color.White), position,0,barSize*pointSize,height);
            for (int i = 0; i != pointHeight; i++)
            {
                for (int j = 0; j != barSize; j++)
                {
                    int value = rdForBar.Next(0, 100);
                    if (value < 40)
                    {
                        //barM[i, j] = 1;
                        g.FillRectangle(new SolidBrush(Color.White), position + j * pointSize, i * pointSize, pointSize, pointSize);
                    }
                    else
                    {
                        //barM[i, j] = 0;
                        g.FillRectangle(new SolidBrush(Color.Black), position+j*pointSize, i * pointSize, pointSize, pointSize);

                    }

                }
            }


            return bm;




        }

        public Bitmap[] getBitmapMatrix()
        {
            

            Bitmap[] bM = new Bitmap[width];
            for (int i = 0; i != width; i++)
            {
                Bitmap b = (Bitmap)getBitmap(i).Clone();
                bM[i] = b;
            }

            return bM;
        }
    }
}
