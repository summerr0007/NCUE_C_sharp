using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form2 preform;
        int toto = 0;
        int fir = 0;
        int d = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.preform.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                toto += 69;
            }
            else
            {
                toto -= 69;
            }
            sh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                toto += 49;
            }
            else
            {
                toto -= 49;
            }
            sh();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                toto += 59;
            }
            else
            {
                toto -= 59;
            }
            sh();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked == true)
            {
                toto += 79;
            }
            else
            {
                toto -= 79;
            }
            sh();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            if (checkBox5.Checked ==true)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            if (checkBox6.Checked == true)
            {
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
            }
            else
            {
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if(radioButton1.Checked == true)
            {
                fir = 35;
            }
            else if (radioButton2.Checked == true)
            {
                fir = 25;
            }
            else
            {
                fir = 0;
            }
            sh();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton3.Checked == true)
            {
                d = 35;
            }
            else if (radioButton4.Checked == true)
            {
                d = 25;
            }
            else if (radioButton5.Checked == true)
            {
                d = 45;
            }
            else
            {
                d = 0;
            }
            sh();
        }

        public void sh()
        {
            textBox1.Text = (toto + d + fir).ToString();
        }

    }
}
