using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Point s,a,b;
        Point end;
        bool isDrag = false;
        Point startPoint;
        List<aa> bb = new List<aa>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s = new Point(10, 10);
            end = new Point(100, 100);
            a = new Point(10, 100);
            b = new Point(100, 10);

            aa line1 = new aa(s, end);
            aa line2 = new aa(a, b);
            bb.Add(new WindowsFormsApplication8.aa(s, end));
            bb.Add(new aa(a, b));
            
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, s, end);
            g.DrawLine(Pens.Black, line2.s, line2.e);
            pictureBox1.Image = bmp;

            Form f = new Form();
            label1.Text = f.Location.X.ToString() + "\n" + f.Location.Y.ToString();
        }

        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
            }

            Control control = (Control)sender;
            Form f = new Form();
            // Calculate the startPoint by using the PointToScreen 
            // method.
            startPoint = control.PointToScreen(new Point(f.Location.X, f.Location.Y));
            label1.Text = startPoint.X.ToString() + "\n" + startPoint.Y.ToString();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)//鎖點範例
        {
            Control control = (Control)sender;
            Form f = new Form();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            foreach (aa cc in bb)
            {
                s = cc.s;
                if ((e.X - s.X < 10 && e.X - s.X > -10) && (e.Y - s.Y < 10 && e.Y - s.Y > -10))//滑鼠靠近s
                {
                    startPoint = control.PointToScreen(new Point(f.Location.X, f.Location.Y));
                    startPoint.X += s.X;
                    startPoint.Y += s.Y;
                    Cursor.Position = startPoint;
                    //Cursor.Clip = new Rectangle(this.Location, this.Size);
                }

                s = cc.e;
                if ((e.X - s.X < 10 && e.X - s.X > -10) && (e.Y - s.Y < 10 && e.Y - s.Y > -10))//滑鼠靠近s
                {
                    startPoint = control.PointToScreen(new Point(f.Location.X, f.Location.Y));
                    startPoint.X += s.X;
                    startPoint.Y += s.Y;
                    Cursor.Position = startPoint;
                    //Cursor.Clip = new Rectangle(this.Location, this.Size);
                }
            }
        }
    }
}
