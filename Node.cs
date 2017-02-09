using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Shapes;

namespace VignetteCreator1._0
{
    public class Node
    {
        private string name;
        private string type;
        private Point position;
        private System.Drawing.Rectangle container;
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

        public Point Center
        {
            get{ return new Point(position.X + container.Width / 2, position.Y + container.Height / 2); }
        }

        public System.Drawing.Rectangle Container
        {
            get{return container;}
            set{container = value;}
        }

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public List<Edge> Incoming
        {
            get{return incoming;}
            set{incoming = value;}
        }

        public List<Edge> Outgoing
        {
            get{return outgoing;}
            set{outgoing = value;}
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public Node(Point _position, string _name, string _type, string _description)
        {
            Position = _position;
            Name = _name;
            Type = _type;
            Description = _description;

            getShape();
        }



        public void getShape()
        {
            Container = new System.Drawing.Rectangle(Position.X, Position.Y, 100, 100);
            if (type == "teacher_action")
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

                shape = new GraphicsPath();
                shape.AddLines(points);
            }
            else if (type == "student_action")
            {
                //Blue rectangle
                Color = Color.LightSkyBlue;

                Point[] points = new Point[5];
                points[0] = new Point(Container.Left, Container.Top);
                points[1] = new Point(Container.Right, Container.Top);
                points[2] = new Point(Container.Right, Container.Bottom);
                points[3] = new Point(Container.Left, Container.Bottom);
                points[4] = new Point(Container.Left, Container.Top);

                shape = new GraphicsPath();
                shape.AddLines(points);
            }
            else if (type == "decision")
            {
                //Yellow diamond
                color = Color.Yellow;
                Point[] points = new Point[5];
                int half_h = Container.Height / 2;
                int half_w = Container.Width / 2;
                points[0] = new Point(Container.Left + half_w, Container.Top);
                points[1] = new Point(Container.Right, Container.Top + half_h);
                points[2] = new Point(Container.Left + half_w, Container.Bottom);
                points[3] = new Point(Container.Left, Container.Top + half_h);
                points[4] = new Point(Container.Left + half_w, Container.Top);
                shape = new GraphicsPath();
                shape.AddLines(points);

            }
            else if (type == "final_node")
            {
                //Red rounded rectangle
                color = Color.Red;
                Point[] points = new Point[7];
                int half = Container.Height / 2;
                int quart = Container.Width / 4;
                points[0] = new Point(Container.Left, Container.Top);
                points[1] = new Point(Container.Right, Container.Top);
                points[2] = new Point(Container.Right + quart, Container.Top + half);
                points[3] = new Point(Container.Right, Container.Bottom);
                points[4] = new Point(Container.Left, Container.Bottom);
                points[5] = new Point(Container.Left - quart, Container.Top + half);
                points[6] = new Point(Container.Left, Container.Top);

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
                int quart = Container.Width / 4;
                points[0] = new Point(Container.Left + quart, Container.Top);
                points[1] = new Point(Container.Right + quart, Container.Top);
                points[2] = new Point(Container.Right, Container.Bottom);
                points[3] = new Point(Container.Left, Container.Bottom);
                points[4] = new Point(Container.Left + quart, Container.Top);

                shape = new GraphicsPath();
                shape.AddLines(points);

            }
        }
    }
}
