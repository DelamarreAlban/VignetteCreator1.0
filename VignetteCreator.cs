using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace VignetteCreator1._0
{
    public partial class VignetteCreator : Form
    {
        List<Node> nodes = new List<Node>();
        List<Edge> edges = new List<Edge>();
        ContextMenuAddNode addNodeContextMenu;

        public VignetteCreator()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            myVignette.Size = Screen.PrimaryScreen.Bounds.Size;
            Console.WriteLine(("Resolution: " + Screen.PrimaryScreen.Bounds.Size.ToString()));

            Bitmap bmp = new Bitmap(myVignette.Width, myVignette.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            myVignette.Image = bmp;

        }

        private void myVignette_Paint(object sender, PaintEventArgs e)
        {
            //drawShape(e, "teacher_action");
            //drawShape(e, "student_action");
            //drawShape(e, "class_action");
            //drawShape(e, "final_node");
            //drawShape(e, "decision");
        }

        private void drawShape(PaintEventArgs e, string type)
        {
            if (type == "teacher_action")
            {
                //Orange hexagon
                System.Drawing.Rectangle container = new System.Drawing.Rectangle(100, 100, 100, 100);
                Point[] points = new Point[7];

                int half = container.Height / 2;
                int quart = container.Width / 4;
                points[0] = new Point(container.Left + quart, container.Top);
                points[1] = new Point(container.Right - quart, container.Top);
                points[2] = new Point(container.Right, container.Top + half);
                points[3] = new Point(container.Right - quart, container.Bottom);
                points[4] = new Point(container.Left + quart, container.Bottom);
                points[5] = new Point(container.Left, container.Top + half);
                points[6] = new Point(container.Left + quart, container.Top);

                GraphicsPath shapePath = new GraphicsPath();
                shapePath.AddLines(points);

                using (Pen pen = new Pen(Color.Black, 2))
                using (SolidBrush brush = new SolidBrush(Color.Orange))
                {
                    e.Graphics.FillPath(brush, shapePath);
                    e.Graphics.DrawPath(pen, shapePath);
                }
            }
            else if(type == "student_action")
            {
                //Blue rectangle
                System.Drawing.Rectangle container = new System.Drawing.Rectangle(300, 100, 100, 100);
                Point[] points = new Point[5];
                points[0] = new Point(container.Left, container.Top);
                points[1] = new Point(container.Right, container.Top);
                points[2] = new Point(container.Right, container.Bottom);
                points[3] = new Point(container.Left, container.Bottom);
                points[4] = new Point(container.Left, container.Top);

                GraphicsPath shapePath = new GraphicsPath();
                shapePath.AddLines(points);

                using (Pen pen = new Pen(Color.Black, 2))
                using (SolidBrush brush = new SolidBrush(Color.LightSkyBlue))
                {
                    e.Graphics.FillPath(brush, shapePath);
                    e.Graphics.DrawPath(pen, shapePath);
                }
            }
            else if (type == "class_action")
            {
                //White parallelogram
                System.Drawing.Rectangle container = new System.Drawing.Rectangle(100, 300, 100, 100);
                Point[] points = new Point[5];
                int quart = container.Width / 4;
                points[0] = new Point(container.Left + quart, container.Top);
                points[1] = new Point(container.Right + quart, container.Top);
                points[2] = new Point(container.Right, container.Bottom);
                points[3] = new Point(container.Left, container.Bottom);
                points[4] = new Point(container.Left + quart, container.Top);

                GraphicsPath shapePath = new GraphicsPath();
                shapePath.AddLines(points);

                using (Pen pen = new Pen(Color.Black, 2))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, shapePath);
                    e.Graphics.DrawPath(pen, shapePath);
                }
            }
            else if (type == "final_node")
            {
                //Red rounded rectangle
                System.Drawing.Rectangle container = new System.Drawing.Rectangle(300, 300, 100, 100);
                Point[] points = new Point[7];
                int half = container.Height / 2;
                int quart = container.Width / 4;
                points[0] = new Point(container.Left, container.Top);
                points[1] = new Point(container.Right, container.Top);
                points[2] = new Point(container.Right + quart, container.Top + half);
                points[3] = new Point(container.Right, container.Bottom);
                points[4] = new Point(container.Left, container.Bottom);
                points[5] = new Point(container.Left - quart, container.Top + half);
                points[6] = new Point(container.Left, container.Top);

                GraphicsPath shapePath = new GraphicsPath();
                shapePath.AddLine(points[0],points[1]);
                shapePath.AddCurve(new Point[] { points[1], points[2], points[3]});
                shapePath.AddLine(points[3], points[4]);
                shapePath.AddCurve(new Point[] { points[4], points[5], points[6] });

                using (Pen pen = new Pen(Color.Black, 2))
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    e.Graphics.FillPath(brush, shapePath);
                    e.Graphics.DrawPath(pen, shapePath);
                }
            }
            else if (type == "decision")
            {
                //Yellow diamind
                System.Drawing.Rectangle container = new System.Drawing.Rectangle(500, 100, 100, 100);
                Point[] points = new Point[5];
                int half_h = container.Height / 2;
                int half_w = container.Width / 2;
                points[0] = new Point(container.Left + half_w, container.Top);
                points[1] = new Point(container.Right, container.Top + half_h);
                points[2] = new Point(container.Left + half_w, container.Bottom);
                points[3] = new Point(container.Left, container.Top + half_h);
                points[4] = new Point(container.Left + half_w, container.Top);

                GraphicsPath shapePath = new GraphicsPath();
                shapePath.AddLines(points);

                using (Pen pen = new Pen(Color.Black, 2))
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    e.Graphics.FillPath(brush, shapePath);
                    e.Graphics.DrawPath(pen, shapePath);
                }
            }
        }

        private void myVignette_MouseDown(object sender, MouseEventArgs e)
        {
            if(addNodeContextMenu != null)
                addNodeContextMenu.Close();
            addNodeContextMenu = null;
            if (e.Button == MouseButtons.Right)
            {
                //NEED AUTOSCROLL DE L'IMAGE!!!
                //IMAGE A L'INFINIE CONCEPTUELLEMENT
                Console.WriteLine("CLICK at " + new Point(MousePosition.X, MousePosition.Y).ToString());
                addNodeContextMenu = new ContextMenuAddNode(this, new Point(MousePosition.X,MousePosition.Y));
                addNodeContextMenu.Show();
            }
        }

        public void addNode(string type, Point position)
        {
            Graphics graphics = Graphics.FromImage(myVignette.Image);
            if (type == "teacher_action")
            {
                //Console.WriteLine("ADD TEACHER ACTION at " + position.ToString());
                Console.WriteLine("Vignette size : " + myVignette.Size.ToString());
                //Orange hexagon
                System.Drawing.Rectangle container = new System.Drawing.Rectangle(position.X, position.Y, 100, 100);
                if (myVignette.Width < position.X + 2 * 100)
                {
                    graphics.Clear(Color.Turquoise);
                    myVignette.Size = new Size(myVignette.Width + 5 * 100, 722);
                    myVignette.Location = new Point(0, 0);
                }

                Console.WriteLine("Vignette size : " + myVignette.Size.ToString());

                Point[] points = new Point[7];

                int half = container.Height / 2;
                int quart = container.Width / 4;
                points[0] = new Point(container.Left + quart, container.Top);
                points[1] = new Point(container.Right - quart, container.Top);
                points[2] = new Point(container.Right, container.Top + half);
                points[3] = new Point(container.Right - quart, container.Bottom);
                points[4] = new Point(container.Left + quart, container.Bottom);
                points[5] = new Point(container.Left, container.Top + half);
                points[6] = new Point(container.Left + quart, container.Top);

                GraphicsPath shapePath = new GraphicsPath();
                shapePath.AddLines(points);

                using (Pen pen = new Pen(Color.Black, 2))
                using (SolidBrush brush = new SolidBrush(Color.Orange))
                {
                    graphics.FillPath(brush, shapePath);
                    graphics.DrawPath(pen, shapePath);
                    graphics.Dispose();
                }
            }
            myVignette.Refresh();
            myVignette.Invalidate();
            
        }
    }
}
