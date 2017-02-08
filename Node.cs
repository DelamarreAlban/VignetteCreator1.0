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
            switch(Type)
            {
                case "teacher_action":
                    //Orange hexagon
                    Color = Color.Orange;
                    
                    System.Drawing.Rectangle container = new System.Drawing.Rectangle(Position.X, Position.Y, 100, 100);
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
                    break;
            }
            
        }
    }
}
