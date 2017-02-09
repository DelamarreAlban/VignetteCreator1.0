using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace VignetteCreator1._0
{
    public class Edge
    {
        private Point start;
        private Point end;
        private Node source;
        private Node target;
        private GraphicsPath arrow;

        public Edge(Point _start, Node _source)
        {
            start = _start;
            source = _source;
        }

        public Edge(Edge e)
        {
            start = new Point(e.Start.X,e.Start.Y);
            end = new Point(e.End.X, e.End.Y);
            source = e.Source;
            target = e.Target;
        }

        public void Destroy()
        {
            Source = null;
            Target = null;
        }

        public Node Source
        {
            get{return source;}
            set{source = value;}
        }

        public Node Target
        {
            get{return target;}
            set{target = value;}
        }

        public GraphicsPath Arrow
        {
            get{return arrow;}
            set{arrow = value;}
        }

        public Point Start
        {
            get{return start;}
            set{start = value;}
        }

        public Point End
        {
            get{return end;}
            set{end = value;}
        }
    }
}
