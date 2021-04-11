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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TextBox[,] board = new TextBox[6, 6];
        int[,] arr = new int[6, 6];
        int[,] max = new int[6, 6];
        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = textBox1;
            board[0, 1] = textBox2;
            board[0, 2] = textBox3;
            board[0, 3] = textBox4;
            board[0, 4] = textBox5;
            board[0, 5] = textBox6;
            board[1, 0] = textBox7;
            board[1, 1] = textBox8;
            board[1, 2] = textBox9;
            board[1, 3] = textBox10;
            board[1, 4] = textBox11;
            board[1, 5] = textBox12;
            board[2, 0] = textBox13;
            board[2, 1] = textBox14;
            board[2, 2] = textBox15;
            board[2, 3] = textBox16;
            board[2, 4] = textBox17;
            board[2, 5] = textBox18;
            board[3, 0] = textBox19;
            board[3, 1] = textBox20;
            board[3, 2] = textBox21;
            board[3, 3] = textBox22;
            board[3, 4] = textBox23;
            board[3, 5] = textBox24;
            board[4, 0] = textBox25;
            board[4, 1] = textBox26;
            board[4, 2] = textBox27;
            board[4, 3] = textBox28;
            board[4, 4] = textBox29;
            board[4, 5] = textBox30;
            board[5, 0] = textBox31;
            board[5, 1] = textBox32;
            board[5, 2] = textBox33;
            board[5, 3] = textBox34;
            board[5, 4] = textBox35;
            board[5, 5] = textBox36;
            mysetcolor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mysetcolor();
            saveFileDialog1.Filter = ".txt|*.txt";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        writer.WriteLine(board[i, j]);
                    }
                }
                writer.Flush();
                writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mysetcolor();
            openFileDialog1.Filter = ".txt|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        board[i, j].Text = reader.ReadLine();
                    }
                }
                reader.Close();
            }
            for(int i = 0;i<6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    arr[i, j] = Convert.ToInt32(board[i, j].Text);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    arr[i, j] = Convert.ToInt32(board[i, j].Text);
                }
            }
            int maxsc = 0;
            mysetcolor();
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    if (i - 1 < 0 && j-1>=0)
                    {
                        max[i, j] = arr[i, j] + max[i, j - 1];
                    }
                    else if (j - 1 <0 && i-1>=0)
                    {
                        max[i, j] = max[i - 1, j] + arr[i,j];
                    }
                    else if (i - 1 < 0 && j - 1 < 0)
                    {
                        max[i, j] = arr[i, j];
                    }
                    else
                    {
                        max[i, j] = arr[i,j] +Math.Max(max[i - 1, j] , max[i, j - 1]);
                    }
                    
                }
            }

            //for (int i = 0; i < 6; i++)
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        board[i, j].Text = max[i, j].ToString();
            //    }
            //}

            int y = 5, u = 5;
            for(int q = 0; q < 11; q++)
            {
                board[y, u].ForeColor = Color.Red;
                maxsc += Convert.ToInt32(board[y,u].Text);
                if (y <= 0)
                {
                    u--;
                    continue;
                }
                if(u <= 0 )
                {
                    y--;
                    continue;
                }
                if (max[y - 1, u] > max[y, u - 1])
                {
                    y--;
                }
                else
                {
                    u--;
                }
            }
            textBox37.Text = maxsc.ToString();
        } 
        
        public void mysetcolor()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    board[i, j].ForeColor = Color.Black;
                }
            }            
        }
    }
}
