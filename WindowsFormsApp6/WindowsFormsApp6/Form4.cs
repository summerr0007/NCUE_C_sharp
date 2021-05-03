using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form4 : Form
    {
        public Form1 preform;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void getdata(out string name,out string where,out double l ,out double w)
        {
            name = textBox1.Text;
            where = textBox2.Text;
            l = Convert.ToDouble(textBox3.Text);
            w = Convert.ToDouble(textBox4.Text);
        }
    }
}
