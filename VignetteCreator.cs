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

        Node movingNode = null;
        Edge movingEdge = null;

        #region Constructor

        public VignetteCreator()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            myVignette.Size = Screen.PrimaryScreen.Bounds.Size;

            Bitmap bmp = new Bitmap(myVignette.Width, myVignette.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            myVignette.Image = bmp;

        }

        #endregion

        #region painting
        public void onPaint()
        {
            if (movingNode == null && movingEdge == null)
            {
                Graphics graphics = Graphics.FromImage(myVignette.Image);
                graphics.Clear(Color.White);
                foreach (Node n in nodes)
                {
                    drawNode(graphics, n);
                }
                foreach (Edge e in edges)
                {
                    drawEdge(graphics, e);
                }
            }
            else 
            {
                Bitmap bitmap = new Bitmap(myVignette.Image.Width, myVignette.Image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                bitmap.MakeTransparent();
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    if (movingNode != null)
                    {
                        drawNode(graphics, movingNode);
                        foreach (Edge e in movingNode.Incoming)
                        {
                            e.End = movingNode.Center;
                            drawEdge(graphics, e);
                        }
                        foreach (Edge e in movingNode.Outgoing)
                        {
                            e.Start = movingNode.Center;
                            drawEdge(graphics, e);
                        }
                    }
                    else if (movingEdge != null)
                        drawEdge(graphics, movingEdge);
                }
                myVignette.Image = bitmap;   
            }
            Invalidate();
            myVignette.Refresh();
        }

        private void PaintExcept(Node exceptionNode)
        {
            Graphics graphics = Graphics.FromImage(myVignette.Image);
            graphics.Clear(Color.White);
            foreach (Node n in nodes)
            {
                if(n != exceptionNode)
                    drawNode(graphics, n);
            }
            foreach (Edge e in edges)
            {
                if(e.Source != exceptionNode && e.Target != exceptionNode)
                    drawEdge(graphics, e);
            }
        }

        private void drawNode(Graphics g, Node n)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            using (SolidBrush brush = new SolidBrush(n.Color))
            {
                Font font = new Font("Arial", 14);
                int textSize = TextRenderer.MeasureText(n.Description + " ", font).Width;
                Console.WriteLine(textSize);
                g.FillPath(brush, n.Shape);
                g.DrawPath(pen, n.Shape);
                drawDescription(g, font, n);
            }
        }

        private void drawEdge(Graphics g, Edge e)
        {
            using (Pen pen = new Pen(Color.Black, 5))
            {
                pen.EndCap = LineCap.ArrowAnchor;
                pen.StartCap = LineCap.RoundAnchor;
                g.DrawLine(pen, e.Start.X, e.Start.Y, e.End.X, e.End.Y);
            }
        }

        private void drawDescription(Graphics g, Font f, Node n)
        {
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.NoClip;
            sf.Alignment = StringAlignment.Center;        // horizontal alignment
            sf.LineAlignment = StringAlignment.Center;    // vertical alignment
            int h = TextRenderer.MeasureText(n.Description + " ", f).Width / n.Container.Width;
            g.DrawString(n.Description, f, Brushes.Black, 
                new System.Drawing.Rectangle(n.Container.X,
                n.Container.Y - n.Container.Height ,
                n.Container.Width,
                n.Container.Height + h*22), sf);
        }

        public void resizeImage(Point position)
        {
            if (myVignette.Image.Width < position.X + 2 * 100)
            {
                Bitmap bmp = new Bitmap(position.X + 5 * 100, myVignette.Image.Height);
                myVignette.Image = bmp;
                Console.WriteLine(myVignette.Image.Width);
            }
            if (myVignette.Image.Height < position.Y + 2 * 100)
            {
                Bitmap bmp = new Bitmap(myVignette.Image.Width, position.Y + 5 * 100);
                myVignette.Image = bmp;
            }
        }

        #endregion

        #region mouse_Action
        private void myVignette_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point clickCoordinates = me.Location;
            //When click on the side of the screen, add an offset to display all butons within the screen!!
            //When click on shape different menu appears!
            if (addNodeContextMenu != null)
                addNodeContextMenu.Close();
            addNodeContextMenu = null;
            if (e.Button == MouseButtons.Right)
            {
                bool clickOnShape = false;
                //Right click on node -> start arrow for connection
                foreach (Node n in nodes)
                {
                    if (n.Container.Contains(clickCoordinates))
                    {
                        clickOnShape = true;
                        movingEdge = new Edge(clickCoordinates, n);
                        myVignette.BackgroundImage = myVignette.Image;
                    }
                }
                //Right click on blank space -> menu add node
                if (!clickOnShape && movingEdge == null)
                {
                    addNodeContextMenu = new ContextMenuAddNode(this, clickCoordinates);
                    addNodeContextMenu.Show();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (movingNode == null)
                {
                    foreach (Node n in nodes)
                    {
                        if (n.Container.Contains(clickCoordinates))
                        {
                            movingNode = n;
                        }
                    }
                    if(movingNode != null)
                    {
                        PaintExcept(movingNode);
                        myVignette.BackgroundImage = myVignette.Image;
                    }
                }
                
            }
        }

        private void myVignette_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingNode != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point cursorPosition = me.Location;
                movingNode.Position = new Point(cursorPosition.X - movingNode.Container.Width / 2, cursorPosition.Y - movingNode.Container.Height / 2);
                movingNode.getShape();
                onPaint();
            }
            else if (movingEdge != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point cursorPosition = me.Location;
                movingEdge.End = cursorPosition;
                onPaint();
            }
                
        }

        private void myVignette_MouseUp(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point clickCoordinates = me.Location;
            if (e.Button == MouseButtons.Left)
            {
                if (movingNode != null)
                {
                    movingNode.Position = clickCoordinates;
                    resizeImage(movingNode.Position);
                    movingNode = null;
                    onPaint();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (movingEdge != null)
                {
                    movingEdge.End = clickCoordinates;
                    foreach (Node n in nodes)
                    {
                        if (n.Container.Contains(movingEdge.End))
                        {
                            movingEdge.Target = n;
                            addEdge(movingEdge);
                        }
                    }
                    movingEdge.Destroy();
                    movingEdge = null;
                    onPaint();
                }
            }
        }

        private void myVignette_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point clickCoordinates = me.Location;
            if (me.Button == MouseButtons.Left)
            {
                foreach(Node n in nodes)
                {
                    if(n.Container.Contains(clickCoordinates))
                    {
                        NodeOptions options = new NodeOptions(this, n);
                        options.Show();
                    }
                }
                
            }
        }

        #endregion


        #region graph_constructors

        public void addNode(string type, Point position)
        {
            //Name and description
            Node newNode = new Node(position, nodes.Count.ToString(), type, "");
            nodes.Add(newNode);

            resizeImage(position);

            onPaint();
        }

        public void addEdge(Edge e)
        {
            Edge newEdge = new Edge(e);
            if(newEdge.Target != null && newEdge.Source != null && newEdge.Target != newEdge.Source)
            {
                Console.WriteLine("Target and source not null");
                edges.Add(newEdge);
                newEdge.Source.Outgoing.Add(newEdge);
                newEdge.Target.Incoming.Add(newEdge);
            }
        }

        #endregion

        
    }
}
