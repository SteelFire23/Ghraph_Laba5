using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ghraph_Laba5
{
    public partial class Form1 : Form
    {
        public struct Info
        {
            public string Name;
            public int Cost;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            Graphics g = pictureBox1.CreateGraphics();
            Graphics g1 = pictureBox2.CreateGraphics();

            g.Clear(BackColor);
            g1.Clear(BackColor);

            SolidBrush brush = new SolidBrush(colorDialog1.Color);
            HatchBrush hatch = new HatchBrush(HatchStyle.SolidDiamond, Color.Blue, Color.Green);
            Font font = new Font("Arial", 20, FontStyle.Regular);

            printMain(g1, pictureBox2.Width, pictureBox2.Height);
            g.FillPolygon(brush, createPointArray(pictureBox1.Width, pictureBox1.Height));
            if (colorDialog1.Color != Color.Black)
            {
                g.DrawString("Сost of funds", font, Brushes.Black, pictureBox1.Width / 2 - 100, pictureBox1.Height / 2);
            }
            else
            {
                g.DrawString("Сost of funds", font, Brushes.White, pictureBox1.Width / 2 - 100, pictureBox1.Height / 2);
            }
           
            g.Dispose();
            g1.Dispose();
        }
        public PointF[] createPointArray(float w,float h)
        {
            PointF[] point = new PointF[17];
            int count = 15;
            float setX = w / 4;
            float setY = h / 4;
            float offsetX = setX / 2;
            float offsetY = setY / 2;
            for (int i=0;i< 16; i++)
            {
                if (count == 16)
                {
                    point[i].X = setX;
                    point[i].Y = setY;
                }
                if (count == 15)
                {
                    point[i].X = setX;
                    point[i].Y = setY;
                }
                if (count == 14)
                {
                    point[i].X = setX + offsetX;
                    point[i].Y = setY + offsetY;
                }
                if (count == 13)
                {
                    point[i].X = setX;
                    point[i].Y = h / 2;
                }
                if (count == 12)
                {
                    point[i].X = setX + offsetX;
                    point[i].Y = h - setY - offsetY;
                }
                if (count == 11)
                {
                    point[i].X = setX;
                    point[i].Y = h - setY;
                }
                if (count == 10)
                {
                    point[i].X = (w / 2) - offsetX;
                    point[i].Y = h - setY;
                }
                if (count == 9)
                {
                    point[i].X = w / 2;
                    point[i].Y = h - setY + offsetY;
                }
                if (count == 8)
                {
                    point[i].X = (w / 2) + offsetX;
                    point[i].Y = h - setY;
                }
                if (count == 7)
                {
                    point[i].X = w - setX;
                    point[i].Y = h - setY;
                }
                if (count == 6)
                {
                    point[i].X = w - setX - offsetX;
                    point[i].Y = h - setY - offsetY;
                }
                if (count == 5)
                {
                    point[i].X = w - setX;
                    point[i].Y = h / 2;
                }
                if (count == 4)
                {
                    point[i].X = w - setX - offsetX;
                    point[i].Y = setY + offsetY;
                }
                if (count == 3)
                {
                    point[i].X = w - setX;
                    point[i].Y = setY;
                }
                
                if (count == 2)
                {
                    point[i].X = (w / 2) + offsetX;
                    point[i].Y = setY;
                }
                if (count == 1)
                {
                    point[i].X = w / 2;
                    point[i].Y = setY - offsetY;
                }
                if (count == 0)
                {
                    point[i].X = (w / 2) - offsetX;
                    point[i].Y = setY;
                }
                count--;
            }
            return point;
        }
        public static void printMain(Graphics g, float Width, float Height)
        {
            Pen pen = new Pen(Color.Black, 1);
            Font font = new Font("Arial", 7, FontStyle.Regular);
  

            SolidBrush brush = new SolidBrush(Color.Blue);
            HatchBrush hatch = new HatchBrush(HatchStyle.SolidDiamond, Color.Blue, Color.Green);
            TextureBrush texture = new TextureBrush(Properties.Resources.dark_blue);

            float axisY = (Height - 50),
                  offsetY = ((Height - 1) / 3) / 4,
                  axisX = (Width - 1) / 12,
                  offsetX = (Width - 1) / 7;
            int cost = 100,
                number = 1;
            //Рисуем основу графика
            //
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            g.DrawLine(pen, axisX, 0, axisX, Height - 1);
            g.DrawLine(pen, 0, axisY, Width - 1, axisY);
            //
            //Рисуем информацию об оси Y 
            //
            g.DrawString("Thousands $", font, Brushes.Black, ((Width - 1) / 12) - 30, 0);
            for (float i = 0; i < (Height - 1) - offsetY; i += offsetY)
            {
                g.DrawLine(pen, ((Width - 1) / 12) - 5, i, ((Width - 1) / 12) + 5, i);
                if (i != 0)
                {
                    g.DrawString(cost.ToString(), font, Brushes.Black, ((Width - 1) / 12) - 30, i - 5);
                    cost -= 10;
                }
            }
            //
            //Рисуем информацию об оси X
            //
            g.DrawString("Firms", font, Brushes.Black, Width - 25, axisY);
            for (float i = axisX; i < Width - 1; i += offsetX)
            {
                if (number <= 6)
                {
                    g.DrawLine(pen, i, axisY - 5, i, axisY + 5);
                    if (i > axisX)
                    {
                        g.DrawString(number.ToString(), font, Brushes.Black, i - 5, axisY + 10);
                        number++;
                    }
                }
            }
            g.FillRectangle(brush, axisX+offsetX - 50, offsetY * 2, 100, (offsetY*9)-15);
            g.FillRectangle(hatch, axisX + (2 * offsetX) - 50, offsetY * 3, 100, (offsetY * 8) - 15);
            g.FillRectangle(texture, axisX + (3*offsetX)- 50, offsetY * 4, 100, (offsetY * 7) - 15);
            g.FillRectangle(hatch, axisX + (4 * offsetX) - 50, offsetY * 5, 100, (offsetY * 6) - 15);
            g.FillRectangle(texture, axisX + (5*offsetX) - 50, offsetY * 6, 100, (offsetY * 5) - 15);
            g.FillRectangle(brush, axisX + (6 * offsetX) - 50, offsetY * 7, 100, (offsetY * 4) - 15);
        }
            private void Form1_Load(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
