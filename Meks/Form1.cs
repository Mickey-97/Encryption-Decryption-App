using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Playfair p = new Playfair();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Saes s = new Saes();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sdes s = new sdes();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rc4 r = new Rc4();
            r.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
