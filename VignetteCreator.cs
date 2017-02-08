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



        private void paint()
        {
            
            if (movingNode == null)
            {
                Graphics graphics = Graphics.FromImage(myVignette.Image);
                graphics.Clear(Color.White);

                foreach (Node n in nodes)
                {
                    //Console.WriteLine(n.Position);
                    drawNode(graphics, n);
                }
                
            }
            else
            {
                Bitmap bitmap = new Bitmap(myVignette.Image.Width, myVignette.Image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                bitmap.MakeTransparent();
                using (Graphics graph = Graphics.FromImage(bitmap))
                {
                    drawNode(graph, movingNode);
                }
                myVignette.Image = bitmap;   
            }
            Invalidate();
            myVignette.Refresh();
        }

        private void drawNode(Graphics g, Node n)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            using (SolidBrush brush = new SolidBrush(n.Color))
            {
                g.FillPath(brush, n.Shape);
                g.DrawPath(pen, n.Shape);
            }
        }

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
                addNodeContextMenu = new ContextMenuAddNode(this, clickCoordinates);
                addNodeContextMenu.Show();
            }
            else if(e.Button == MouseButtons.Left)
            {
                if (movingNode == null)
                {
                    foreach (Node n in nodes)
                    {
                        if (n.Container.Contains(clickCoordinates))
                        {
                            movingNode = n;
                            myVignette.BackgroundImage = myVignette.Image;
                        }
                    }
                }
                else
                {

                }
            }
        }

        private void myVignette_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingNode != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point clickCoordinates = me.Location;
                movingNode.Position = clickCoordinates;
                movingNode.getShape();
                Console.WriteLine(movingNode.Position);
                paint();
            }
        }

        private void myVignette_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point clickCoordinates = me.Location;
                if(movingNode != null)
                {
                    movingNode.Position = clickCoordinates;
                    movingNode = null;
                    paint();
                }
                
            }
        }

        public void addNode(string type, Point position)
        {
            //Name and description
            Node newNode = new Node(position, "aaaa", type, "lelelelelele");
            nodes.Add(newNode);

            resizeImage(position);

            paint();
        }

        public void resizeImage(Point position)
        {
            if (myVignette.Image.Width < position.X + 2 * 100)
            {
                Bitmap bmp = new Bitmap(myVignette.Image.Width + 5 * 100, myVignette.Image.Height);
                myVignette.Image = bmp;
                Console.WriteLine(myVignette.Image.Width);
            }
            if (myVignette.Image.Height < position.Y + 2 * 100)
            {
                Bitmap bmp = new Bitmap(myVignette.Image.Width, myVignette.Image.Height + 5 * 100);
                myVignette.Image = bmp;
            }
        }

        private void moveNode(Node n)
        {

        }

        
    }
}
