using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public ContextMenuAddNode()
        {
            // 
            // Required for Windows Form Designer support. 
            //
            InitializeComponent();
            
            // Initialize the user-defined button, 
            // including defining handler for Click message, 
            // location and size.
            /*
            myButtonObject myButton = new myButtonObject();
            EventHandler myHandler = new EventHandler(myButton_Click);
            myButton.Click += myHandler;
            myButton.Location = new System.Drawing.Point(20, 20);
            myButton.Size = new System.Drawing.Size(101, 101);
            this.Controls.Add(myButton);
            */
        }

        // add this code after the class' default constructor

        public ContextMenuAddNode(VignetteCreator _parent, Point _position) : this()
        {
            parent = _parent;
            position = _position;

            Load += new EventHandler(ContextMenuAddNode_Load);
        }

        private void ContextMenuAddNode_Load(object sender, System.EventArgs e)
        {
            this.SetDesktopLocation(position.X, position.Y);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation
            
        }

        public class myButtonObject : UserControl
        {
            // Draw the new button. 
            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics graphics = e.Graphics;
                Pen myPen = new Pen(Color.Black);
                //var image = new Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height, PixelFormat.Format32bppArgb);
                //using (var g = Graphics.FromImage(image))
                //{
                graphics.Clear(Color.Transparent);
                graphics.DrawRectangle(myPen, 0, 0, 100, 100);
                graphics.FillRectangle(Brushes.Transparent,0,0,100,100);
                graphics.DrawEllipse(myPen, 0, 0, 100, 100);
                graphics.FillEllipse(Brushes.Orange, 0, 0, 100, 100);
                myPen.Dispose();
                //}

            }
        }

        // Handler for the click message. 
        void myButton_Click(Object sender, System.EventArgs e)
        {
            
        }

        private void teacherAction_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click");
            parent.addNode("teacher_action", position);
            this.Close();
        }
    }
}


