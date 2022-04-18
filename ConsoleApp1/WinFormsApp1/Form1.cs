using Interface;
using System.Drawing.Drawing2D;
using Class1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cnt;
        //Bitmap bmp;
        Context context = new Context(new Line());

        PointF Cpoint;

        List<PointF> curvePoints = new List<PointF>();
        
        //Pen AntiPen = new Pen(Color.Black);
        Pen MyPen = new Pen(Color.Black);
        Brush MyBrush = new SolidBrush(Color.Black);

        //History history = new History();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            Cpoint.X = e.X;
            Cpoint.Y = e.Y;
            curvePoints.Add(Cpoint);
            cnt = curvePoints.Count();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            curvePoints.Clear();
            context = new Context(new Line());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            curvePoints.Clear();
            context = new Context(new Recctangle());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curvePoints.Clear();
            context = new Context(new Ellipse());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            curvePoints.Clear();
            context = new Context(new Polygon());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            curvePoints.Clear();
            context = new Context(new Curve());
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                MyPen.Color = colorDialog1.Color;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyPen.Width = comboBox1.SelectedIndex;
            MyPen.Alignment = PenAlignment.Center;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyPen.DashStyle = (DashStyle)(int)comboBox2.SelectedIndex;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            if ((e.KeyCode == Keys.Escape))
            {
                int cnt = curvePoints.Count();
                if (cnt <= 2)
                {
                    curvePoints.Clear();
                    return;
                }
                context.EndPaint(g, MyPen, curvePoints);
                context.Fill(g, MyBrush, curvePoints);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                MyBrush = new SolidBrush(colorDialog1.Color);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            float x1 = Convert.ToInt32(textBox1.Text);
            float y1 = Convert.ToInt32(textBox2.Text);
            float x2 = Convert.ToInt32(textBox3.Text);
            float y2 = Convert.ToInt32(textBox4.Text);
            Graphics g = this.panel1.CreateGraphics();
            List<PointF> curvePoints = new List<PointF>();
            curvePoints.Add(new PointF(x1,y1));
            curvePoints.Add(new PointF(x2,y2));
            context.Paint(g, MyPen, curvePoints);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            cnt = curvePoints.Count;
            if (cnt>=2)
            {
                context.Paint(g, MyPen, curvePoints);
                /*DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
                history.Add(bmp);*/
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //history.Undo();
            //panel1.BackgroundImage = history.u;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //history.Redo();
            //panel1.BackgroundImage = history.u;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //bmp = new Bitmap(panel1.Width, panel1.Height);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
        }
    }
}