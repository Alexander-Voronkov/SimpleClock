using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Clockk
{
    public partial class Clock : UserControl
    {
        Timer timer1 = new Timer();
        public Clock()
        {            
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                Graphics g = CreateGraphics();
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawEllipse(new Pen(Color.White, 5), 30, 30, 300, 300);
                g.DrawEllipse(new Pen(Color.White, 3), 170, 170, 20, 20);
                Point center = new Point(180, 180);
                Point curr = new Point(center.X + (int)(150 * Math.Sin(Math.PI * 6 / 180)), center.Y - (int)(150 * Math.Cos(Math.PI * 6 / 180)));
                int angle = 6;
                int count = 1;
                while (angle <= 360)
                {
                    if (count % 5 == 0)
                    {
                        if (angle == 360)
                            g.DrawString((count / 5).ToString(), new Font("Arial", 20), Brushes.Red, curr.X - 20, curr.Y - 30);
                        else if (angle <= 180 && angle > 90)
                            g.DrawString((count / 5).ToString(), new Font("Arial", 20), Brushes.Red, curr.X - 10, curr.Y - 10);
                        else if (angle > 0 && angle <= 90)
                            g.DrawString((count / 5).ToString(), new Font("Arial", 20), Brushes.Red, curr.X, curr.Y - 30);
                        else if (angle > 180 && angle <= 270)
                            g.DrawString((count / 5).ToString(), new Font("Arial", 20), Brushes.Red, curr.X - 15, curr.Y - 10);
                        else if (angle > 270 && angle < 360)
                            g.DrawString((count / 5).ToString(), new Font("Arial", 20), Brushes.Red, curr.X - 20, curr.Y - 30);
                    }
                    else
                    {
                        g.DrawEllipse(Pens.Black, curr.X - 5, curr.Y - 5, 10, 10);
                    }
                    angle += 6;
                    count++;
                    if (angle >= 0 && angle <= 180)
                    {
                        curr.X = center.X + (int)(150 * Math.Sin(Math.PI * angle / 180));
                        curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * angle / 180));
                    }
                    else
                    {
                        curr.X = center.X - (int)(150 * -Math.Sin(Math.PI * angle / 180));
                        curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * angle / 180));
                    }
                }
            }
            {
                DateTime t = DateTime.Now;
                double angleseconds = t.Second * 6;
                double angleminute = t.Minute * 6+t.Second*0.1;
                double anglehour = (t.Hour%12) * 30+t.Minute*0.6;
                Point center = new Point(180, 180);
                Point curr = new Point();
                Graphics g = CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if (angleseconds >= 0 && angleseconds <= 180)
                {
                    curr.X = center.X + (int)(150 * Math.Sin(Math.PI * angleseconds / 180));
                    curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * angleseconds / 180));
                }
                else
                {
                    curr.X = center.X - (int)(150 * -Math.Sin(Math.PI * angleseconds / 180));
                    curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * angleseconds / 180));
                }
                g.DrawLine(new Pen(Brushes.Yellow, 3), center, curr);
                if (angleminute >= 0 && angleminute <= 180)
                {
                    curr.X = center.X + (int)(150 * Math.Sin(Math.PI * angleminute / 180));
                    curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * angleminute / 180));
                }
                else
                {
                    curr.X = center.X - (int)(150 * -Math.Sin(Math.PI * angleminute / 180));
                    curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * angleminute / 180));
                }
                g.DrawLine(new Pen(Brushes.Green, 5), center, curr);
                if (anglehour >= 0 && anglehour <= 180)
                {
                    curr.X = center.X + (int)(150 * Math.Sin(Math.PI * anglehour / 180));
                    curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * anglehour / 180));
                }
                else
                {
                    curr.X = center.X - (int)(150 * -Math.Sin(Math.PI * anglehour / 180));
                    curr.Y = center.Y - (int)(150 * Math.Cos(Math.PI * anglehour / 180));
                }
                g.DrawLine(new Pen(Brushes.Red, 7), center, curr);
                g.Dispose();
            }
        }
    }
}
