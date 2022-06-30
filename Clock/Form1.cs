using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clockk
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();            
            Size = new Size(500, 500);
            clock1.Size = this.Size;
            clock1.Top = 0;
            clock1.Left = 0;
        }       
    }
}
