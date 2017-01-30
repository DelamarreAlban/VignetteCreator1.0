using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Polygon shape;
        private List<Edge> incoming = new List<Edge>();
        private List<Edge> outgoing = new List<Edge>();
        private string description;

        public Node(Point position, string _name, string _type, string _description)
        {
            name = _name;
            type = _type;
            shape = getShape(type);
            description = _description;
            
        }

        private Polygon getShape(string type)
        {
            Polygon _shape = new Polygon();

            return _shape;
        }
    }
}
