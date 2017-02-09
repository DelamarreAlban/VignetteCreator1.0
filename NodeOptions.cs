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
        public NodeOptions()
        {
            InitializeComponent();
            
        }

        public NodeOptions(Node n)
        {
            InitializeComponent();
            NameTB.Text = n.Name;
            DescriptionTB.Text = n.Description;
        }
    }
}
