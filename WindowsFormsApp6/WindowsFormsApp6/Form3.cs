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
    public partial class Form3 : Form
    {
        public Form1 preform;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void getdata(out string name,out string where,out double h,out double w)
        {
            name = textBox1.Text;
            where = textBox2.Text;
            h = Convert.ToDouble(textBox3.Text);
            w = Convert.ToDouble(textBox4.Text);
        }
    }
}
