using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ball
{
    public partial class Form1 : Form
    {
        Vector v, a, r, g;
        Vector r0, r2, v2, a2;
        double t = 0;
        double m=1, m2=1;
        double p=1, k;
        Point start;

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelX.Text = Convert.ToString(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            labelY.Text = Convert.ToString(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            labelG.Text = "g="+Convert.ToString(trackBar3.Value)+"м/с^2";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            labelM.Text = "m=" + Convert.ToString(trackBar4.Value) + "кг";
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            labelp.Text = "p=" + Convert.ToString(trackBar5.Value) + "кг/м^3";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            double dt = timer1.Interval / 1000.0;
            
            g = new Vector(0, trackBar3.Value*10);
            Vector F = m * g - v*p/10;

            a = F / m;
            v += a*dt;
            r +=  v * dt;

            Vector F2 = 50*(r0-r2);

            a2 = F2 / m2;
            v2 += a2 * dt;
            r2 += v2 * dt;

            Ball.Location = new Point ((int)r.X, (int)r.Y);
            Ball2.Location = new Point((int)r2.X, (int)r2.Y);
            Spring.Height = Ball2.Top - Spring.Top;
            if (Ball.Top + Ball.Height > pictureBox1.Top)
            {
                
                v = v.Mirror(new Vector(1, 0)) * 0.8;
                
                if(v.SqAbs<0.001)
                {
                    timer1.Stop();
                }
                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = new Point(Ball.Location.X,Ball.Location.Y);
            r = new Vector(Ball.Left, Ball.Top);
            r2 = new Vector(Ball2.Left, Ball2.Top);
            r0 = new Vector(Ball2.Left, Ball2.Top+20);
            g = new Vector(0, trackBar3.Value*10);
            t = 0;
            m = trackBar4.Value;
            m2 = 1;
            p = trackBar5.Value;
            v = new Vector(trackBar1.Value,-trackBar2.Value);
            v2 = new Vector(0, 0);
            k = 10;
            timer1.Start();
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            
        }
    }
}
