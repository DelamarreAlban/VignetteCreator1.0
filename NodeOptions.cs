using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VignetteCreator1._0
{
    public partial class NodeOptions : Form
    {
        private Node node;
        private VignetteCreator parent;
        public NodeOptions()
        {
            InitializeComponent();
            
        }

        public NodeOptions(VignetteCreator _parent, Node n)
        {
            InitializeComponent();
            parent = _parent;
            node = n;
            NameTB.Text = n.Name;
            DescriptionTB.Text = n.Description;
            widthTB.Text = n.Width.ToString();
            heightTB.Text = n.Height.ToString();


            Load += new EventHandler(NodeOptions_Load);
        }


    private void NodeOptions_Load(object sender, System.EventArgs e)
    {
        this.SetDesktopLocation(node.Center.X - this.Width / 2, node.Center.Y - this.Height / 2);
    }

    private void confirmB_Click(object sender, EventArgs e)
        {
            node.Name = NameTB.Text;
            node.Description = DescriptionTB.Text;
            node.Width = Int32.Parse(widthTB.Text);
            node.Height = Int32.Parse(heightTB.Text);
            parent.onPaint();
            this.Close();
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
