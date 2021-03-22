using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool[] card = new bool[52];
        int[] dealer = new int[5];
        int[] player = new int[5];
        Random random = new Random();
        int n1, n2, d, p, dn, pn;
        public String GenerateColor(int a)
        {
            string color="";
            if(a <=12)
            {
                color = "\u2660\r\n";
            }
            else if(a<=25)
            {
                color = "\u2665\r\n";
            }else if (a <= 38)
            {
                color = "\u2666\r\n";
            }
            else
            {
                color = "\u2663\r\n";
            }
            if (a % 13 ==0)
            {
                color += "A";
            }
            else if(a%13 == 12)
            {
                color += "k";
            }
            else if(a%13==11)
            {
                color += "Q";
            }
            
            return color;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
