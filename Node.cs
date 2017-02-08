using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Shapes;

namespace VignetteCreator1._0
{
    class Node
    {
        private string name;
        private string type;
        private Point position;
        private GraphicsPath shape;
        private Color color;
        private List<Edge> incoming = new List<Edge>();
        private List<Edge> outgoing = new List<Edge>();
        private string description;

        public Color Color
        {
            get {return color;}
            set{ color = value;}
        }

        public string Type
        {
            get{return type;}
            set {type = value;}
        }

        public GraphicsPath Shape
        {
            get{return shape;}
            set{shape = value;}
        }

        public Point Position
        {
            get{return position;}
            set{position = value;}
        }

        public Node(Point _position, string _name, string _type, string _description)
        {
            Position = _position;
            name = _name;
            Type = _type;
            description = _description;

            getShape();
        }



        public void getShape()
        {
            System.Drawing.Rectangle container = new System.Drawing.Rectangle(Position.X, Position.Y, 100, 100);
            if (type == "teacher_action")
            {
                //Orange hexagon
                Color = Color.Orange;
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

                shape = new GraphicsPath();
                shape.AddLines(points);
            }
            else if (type == "student_action")
            {
                //Blue rectangle
                Color = Color.LightSkyBlue;

                Point[] points = new Point[5];
                points[0] = new Point(container.Left, container.Top);
                points[1] = new Point(container.Right, container.Top);
                points[2] = new Point(container.Right, container.Bottom);
                points[3] = new Point(container.Left, container.Bottom);
                points[4] = new Point(container.Left, container.Top);

                shape = new GraphicsPath();
                shape.AddLines(points);
            }
            else if (type == "decision")
            {
                //Yellow diamond
                color = Color.Yellow;
                Point[] points = new Point[5];
                int half_h = container.Height / 2;
                int half_w = container.Width / 2;
                points[0] = new Point(container.Left + half_w, container.Top);
                points[1] = new Point(container.Right, container.Top + half_h);
                points[2] = new Point(container.Left + half_w, container.Bottom);
                points[3] = new Point(container.Left, container.Top + half_h);
                points[4] = new Point(container.Left + half_w, container.Top);
                shape = new GraphicsPath();
                shape.AddLines(points);

            }
            else if (type == "final_node")
            {
                //Red rounded rectangle
                color = Color.Red;
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

                shape = new GraphicsPath();
                shape.AddLine(points[0], points[1]);
                shape.AddCurve(new Point[] { points[1], points[2], points[3] });
                shape.AddLine(points[3], points[4]);
                shape.AddCurve(new Point[] { points[4], points[5], points[6] });
            }
            else if (type == "class_action")
            {
                //White parallelogram
                color = Color.White;
                Point[] points = new Point[5];
                int quart = container.Width / 4;
                points[0] = new Point(container.Left + quart, container.Top);
                points[1] = new Point(container.Right + quart, container.Top);
                points[2] = new Point(container.Right, container.Bottom);
                points[3] = new Point(container.Left, container.Bottom);
                points[4] = new Point(container.Left + quart, container.Top);

                shape = new GraphicsPath();
                shape.AddLines(points);

            }
        }
    }
}
