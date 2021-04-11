using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        TextBox[,] board = new TextBox[6, 6];
        int[,] arr = new int[6, 6];
        int[,] max = new int[6, 6];
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board[0,0] = textBox1;
            board[0,1] = textBox2;
            board[0,2] = textBox3;
            board[0,3] = textBox4;
            board[0,4] = textBox5;
            board[0,5] = textBox6;
            board[1,0] = textBox7;
            board[1,1] = textBox8;
            board[1,2] = textBox9;
            board[1,3] = textBox10;
            board[1,4] = textBox11;
            board[1,5] = textBox12;
            board[2,0] = textBox13;
            board[2,1] = textBox14;
            board[2,2] = textBox15;
            board[2,3] = textBox16;
            board[2,4] = textBox17;
            board[2,5] = textBox18;
            board[3,0] = textBox19;
            board[3,1] = textBox20;
            board[3, 2] = textBox21;
            board[3,3] = textBox22;
            board[3,4] = textBox23;
            board[3,5] = textBox24;
            board[4,0] = textBox25;
            board[4,1] = textBox26;
            board[4,2] = textBox27;
            board[4,3] = textBox28;
            board[4,4] = textBox29;
            board[4,5] = textBox30;
            board[5,0] = textBox31;
            board[5,1] = textBox32;
            board[5,2] = textBox33;
            board[5,3] = textBox34;
            board[5,4] = textBox35;
            board[5,5] = textBox36;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文字檔案(*.txt)|*.txt";
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                FileInfo f = new FileInfo(saveFileDialog1.FileName);
                StreamWriter sw = f.CreateText();
                for(int i = 0; i < 6;i++)
                    for(int j = 0; j < 6; j++)
                    {
                        sw.WriteLine("" + board[i, j].Text);
                    }
                sw.Flush();
                sw.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文字檔案(*.txt)|*.txt";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                FileInfo f = new FileInfo(openFileDialog1.FileName);
                StreamReader sr = f.OpenText();
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 6; j++)
                    {
                        board[i, j].Text= sr.ReadLine();
                    }
                sr.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    arr[i, j] = Convert.ToInt32(board[i, j].Text);
                }
            int tmp = 0,tmp2=0;
            for(int i = 0; i < 6; i++)
                for(int j = 0; j < 6; j++)
                {
                    if (i == 0)
                    {
                        tmp += arr[i, j];
                        max[i, j] = tmp;
                    }
                    else if(j==0)
                    {
                        tmp = max[i - 1, j]+ arr[i, j];
                        max[i, j] = tmp;
                    }
                    else
                    {
                        tmp = max[i-1,j]+ arr[i, j];
                        tmp2 = max[i,j-1]+ arr[i, j];
                        if (tmp >= tmp2) max[i, j] = tmp;
                        else max[i, j] = tmp2;
                    }
                    for (int k = 0; k < 6; k++)
                        for (int z = 0; z < 6; z++)
                        {
                            board[k, z].Text = "" + max[k,z];
                        }
                }
            textBox37.Text = ""+max[5, 5];
            int g=5, h=5,num1,num2;
            do
            {
                board[g, h].ForeColor = Color.Red;
                if (g == 0) h--;
                else if (h == 0) g--;
                else
                {
                    num1 = Convert.ToInt32(board[g - 1, h].Text);
                    num2 = Convert.ToInt32(board[g, h - 1].Text);
                    if (num1 >= num2) g--;
                    else h--;
                }
            } while (g>0 || h >0);
            board[0, 0].ForeColor = Color.Red;
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
