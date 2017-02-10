using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VignetteCreator1._0
{
    public partial class ContextMenuAddNode : Form
    {
        private VignetteCreator parent;
        private Point position;
        private int buttonSize = 100;

        private List<CustomButton> buttons = new List<CustomButton>();

        public ContextMenuAddNode()
        {
            InitializeComponent();
            //Transparent background
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

            Bitmap bmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
            }
            buttonPanel.Image = bmp;
            buttonPanel.Dock = DockStyle.Fill;

            //List of buttons
            Point[] centers = new Point[5];
            centers = CalculateVertices(5, 120, 90, new Point(position.X + this.Width/2, position.Y + this.Height / 2));

            string[] types = new string[5];
            types[0] = "teacher_action";
            types[1] = "student_action";
            types[2] = "class_action";
            types[3] = "decision";
            types[4] = "final_node";

            for (int i = 0;i < centers.Length;i++)
            {
                CustomButton newButton = new CustomButton(types[i], new Point(centers[i].X-buttonSize/2, centers[i].Y - buttonSize / 2), Color.Orange);
                buttons.Add(newButton);
            }
            

            drawButtons();
        }
        
        public ContextMenuAddNode(VignetteCreator _parent, Point _position) : this()
        {
            parent = _parent;
            position = _position;

            Load += new EventHandler(ContextMenuAddNode_Load);
        }

        private void ContextMenuAddNode_Load(object sender, System.EventArgs e)
        {
            this.SetDesktopLocation(position.X - this.Width/2, position.Y - this.Height / 2);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation
            e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
        }

        private void drawButtons()
        {
            Bitmap bitmap = new Bitmap(buttonPanel.Image.Width, buttonPanel.Image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmap.MakeTransparent();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                foreach (CustomButton b in buttons)
                {
                    drawButton(graphics, b);
                }
            }
            buttonPanel.Image = bitmap;
            Invalidate();
            buttonPanel.Refresh();
        }

        private void drawButton(Graphics g, CustomButton b)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            using (SolidBrush brush = new SolidBrush(b.Color))
            {
                g.FillPath(brush, b.Shape);
                g.DrawPath(pen, b.Shape);
            }
        }

        private void buttonPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point clickCoordinates = me.Location;
            if (e.Button == MouseButtons.Left)
            {
                foreach(CustomButton b in buttons)
                {
                    if(b.Container.Contains(clickCoordinates))
                    {
                        clicked(b.Type);
                    }
                }                
            }
        }

        public class CustomButton
        {
            public string Type;
            public Point Position;
            public Rectangle Container;
            public GraphicsPath Shape;
            public Color Color;

            public CustomButton(string _type, Point _position, Color _color)
            {
                Type = _type;
                Position = _position;
                Color = _color;
                getShape();
            }

            public void getShape()
            {
                Container = new System.Drawing.Rectangle(Position.X, Position.Y, 100, 100);
                if (Type == "teacher_action")
                {
                    //Orange hexagon
                    Color = Color.Orange;
                    Point[] points = new Point[7];

                    int half = Container.Height / 2;
                    int quart = Container.Width / 4;
                    points[0] = new Point(Container.Left + quart, Container.Top);
                    points[1] = new Point(Container.Right - quart, Container.Top);
                    points[2] = new Point(Container.Right, Container.Top + half);
                    points[3] = new Point(Container.Right - quart, Container.Bottom);
                    points[4] = new Point(Container.Left + quart, Container.Bottom);
                    points[5] = new Point(Container.Left, Container.Top + half);
                    points[6] = new Point(Container.Left + quart, Container.Top);

                    Shape = new GraphicsPath();
                    Shape.AddLines(points);
                }
                else if (Type == "student_action")
                {
                    //Blue rectangle
                    Color = Color.LightSkyBlue;

                    Point[] points = new Point[5];
                    Shape = new GraphicsPath();
                    Shape.AddRectangle(Container);
                }
                else if (Type == "decision")
                {
                    //Yellow diamond
                    Color = Color.Yellow;
                    Point[] points = new Point[5];
                    int half_h = Container.Height / 2;
                    int half_w = Container.Width / 2;
                    points[0] = new Point(Container.Left + half_w, Container.Top);
                    points[1] = new Point(Container.Right, Container.Top + half_h);
                    points[2] = new Point(Container.Left + half_w, Container.Bottom);
                    points[3] = new Point(Container.Left, Container.Top + half_h);
                    points[4] = new Point(Container.Left + half_w, Container.Top);
                    Shape = new GraphicsPath();
                    Shape.AddLines(points);

                }
                else if (Type == "final_node")
                {
                    //Red rounded rectangle
                    Color = Color.Red;

                    Shape = new GraphicsPath();
                    Shape = MakeRoundedRect(Container, 30, 30, true, true, true, true);
                }
                else if (Type == "class_action")
                {
                    //White parallelogram
                    Color = Color.White;
                    Point[] points = new Point[5];
                    int quart = Container.Width / 4;
                    points[0] = new Point(Container.Left + quart, Container.Top);
                    points[1] = new Point(Container.Right + quart, Container.Top);
                    points[2] = new Point(Container.Right, Container.Bottom);
                    points[3] = new Point(Container.Left, Container.Bottom);
                    points[4] = new Point(Container.Left + quart, Container.Top);

                    Shape = new GraphicsPath();
                    Shape.AddLines(points);

                }
            }

            
            private GraphicsPath MakeRoundedRect(RectangleF rect, float xradius, float yradius,bool round_ul, bool round_ur, bool round_lr, bool round_ll)
            {
                // Draw a rectangle in the indicated Rectangle
                // rounding the indicated corners.
                // Make a GraphicsPath to draw the rectangle.
                PointF point1, point2;
                GraphicsPath path = new GraphicsPath();

                // Upper left corner.
                if (round_ul)
                {
                    RectangleF corner = new RectangleF(
                        rect.X, rect.Y,
                        2 * xradius, 2 * yradius);
                    path.AddArc(corner, 180, 90);
                    point1 = new PointF(rect.X + xradius, rect.Y);
                }
                else point1 = new PointF(rect.X, rect.Y);

                // Top side.
                if (round_ur)
                    point2 = new PointF(rect.Right - xradius, rect.Y);
                else
                    point2 = new PointF(rect.Right, rect.Y);
                path.AddLine(point1, point2);

                // Upper right corner.
                if (round_ur)
                {
                    RectangleF corner = new RectangleF(
                        rect.Right - 2 * xradius, rect.Y,
                        2 * xradius, 2 * yradius);
                    path.AddArc(corner, 270, 90);
                    point1 = new PointF(rect.Right, rect.Y + yradius);
                }
                else point1 = new PointF(rect.Right, rect.Y);

                // Right side.
                if (round_lr)
                    point2 = new PointF(rect.Right, rect.Bottom - yradius);
                else
                    point2 = new PointF(rect.Right, rect.Bottom);
                path.AddLine(point1, point2);

                // Lower right corner.
                if (round_lr)
                {
                    RectangleF corner = new RectangleF(
                        rect.Right - 2 * xradius,
                        rect.Bottom - 2 * yradius,
                        2 * xradius, 2 * yradius);
                    path.AddArc(corner, 0, 90);
                    point1 = new PointF(rect.Right - xradius, rect.Bottom);
                }
                else point1 = new PointF(rect.Right, rect.Bottom);

                // Bottom side.
                if (round_ll)
                    point2 = new PointF(rect.X + xradius, rect.Bottom);
                else
                    point2 = new PointF(rect.X, rect.Bottom);
                path.AddLine(point1, point2);

                // Lower left corner.
                if (round_ll)
                {
                    RectangleF corner = new RectangleF(
                        rect.X, rect.Bottom - 2 * yradius,
                        2 * xradius, 2 * yradius);
                    path.AddArc(corner, 90, 90);
                    point1 = new PointF(rect.X, rect.Bottom - yradius);
                }
                else point1 = new PointF(rect.X, rect.Bottom);

                // Left side.
                if (round_ul)
                    point2 = new PointF(rect.X, rect.Y + yradius);
                else
                    point2 = new PointF(rect.X, rect.Y);
                path.AddLine(point1, point2);

                // Join with the start point.
                path.CloseFigure();

                return path;
            }
        }

        private void clicked(string type)
        {
            parent.addNode(type, position);
            this.Close();
        }

        private Point[] CalculateVertices(int sides, int radius, int startingAngle, Point center)
        {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a full circle
            {
                points.Add(Point.Round(DegreesToXY(angle, radius, center))); //code snippet from above
                angle += step;
            }

            return points.ToArray();
        }

        private PointF DegreesToXY(float degrees, float radius, Point origin)
        {
            PointF xy = new PointF();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (float)Math.Cos(radians) * radius + origin.X;
            xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;

            return xy;
        }
    }
}


