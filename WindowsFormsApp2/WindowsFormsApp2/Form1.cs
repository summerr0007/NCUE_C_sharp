using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double m1, sum;
        string pre;
        bool eq;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = 0.ToString();
            m1 = 0;
            sum = 0;
            eq = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            Button bottom = (Button)sender;
            textBox1.Text += bottom.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            Button bottom = (Button)sender;
            pre = bottom.Text;
            if (sum == 0)
            {
                sum += Convert.ToDouble(textBox1.Text);
            }
            else
            {
                switch (bottom.Text)
                {
                    case "+":
                        pre = "+";
                        sum += Convert.ToDouble(textBox1.Text);
                        break;
                    case "-":
                        pre = "-";
                        sum -= Convert.ToDouble(textBox1.Text);
                        break;
                    case "*":
                        pre = "*";
                        sum *= Convert.ToDouble(textBox1.Text);
                        break;
                    case "/":
                        pre = "/";
                        try
                        {
                            sum /= Convert.ToDouble(textBox1.Text);
                        }
                        catch
                        {
                            textBox1.Text = "error ";
                        }

                        break;
                    default:
                        break;
                }
            }
            
            
            textBox1.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.IndexOf(".") == -1)
            {
                textBox1.Text += ".";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!eq)
            {
                m1 = Convert.ToDouble(textBox1.Text);
            }     
            
            switch (pre)
            {
                case "+":
                    pre = "+";
                    sum += Convert.ToDouble(m1);
                    break;
                case "-":
                    pre = "-";
                    sum -= Convert.ToDouble(m1);
                    break;
                case "*":
                    pre = "*";
                    sum *= Convert.ToDouble(m1);
                    break;
                case "/":
                    pre = "/";
                    try
                    {
                        sum /= Convert.ToDouble(m1);
                    }
                    catch
                    {
                        textBox1.Text = "error ";
                    }

                    break;
                default:
                    break;
            }
            textBox1.Text = sum.ToString();
            eq = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m1 = 0;
            sum = 0;
            textBox1.Text = 0.ToString();
            eq = false;
        }
    }
}
