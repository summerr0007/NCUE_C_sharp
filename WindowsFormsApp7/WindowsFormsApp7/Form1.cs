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

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] board = new Button[7, 7];

        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = button1;
            board[1, 0] = button2;
            board[2, 0] = button3;
            board[3, 0] = button4;
            board[4, 0] = button5;
            board[5, 0] = button6;
            board[6, 0] = button7;

            board[0, 1] = button8;
            board[1, 1] = button9;
            board[2, 1] = button10;
            board[3, 1] = button11;
            board[4, 1] = button12;
            board[5, 1] = button13;
            board[6, 1] = button14;

            board[0, 2] = button15;
            board[1, 2] = button16;
            board[2, 2] = button17;
            board[3, 2] = button18;
            board[4, 2] = button19;
            board[5, 2] = button20;
            board[6, 2] = button21;

            board[0, 3] = button22;
            board[1, 3] = button23;
            board[2, 3] = button24;
            board[3, 3] = button25;
            board[4, 3] = button26;
            board[5, 3] = button27;
            board[6, 3] = button28;

            board[0, 4] = button29;
            board[1, 4] = button30;
            board[2, 4] = button31;
            board[3, 4] = button32;
            board[4, 4] = button33;
            board[5, 4] = button34;
            board[6, 4] = button35;

            board[0, 5] = button36;
            board[1, 5] = button37;
            board[2, 5] = button38;
            board[3, 5] = button39;
            board[4, 5] = button40;
            board[5, 5] = button41;
            board[6, 5] = button42;

            board[0, 6] = button43;
            board[1, 6] = button44;
            board[2, 6] = button45;
            board[3, 6] = button46;
            board[4, 6] = button47;
            board[5, 6] = button48;
            board[6, 6] = button49;
        }

        private void button50_Click(object sender, EventArgs e)
        {

            
        }

        private void button51_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(f);
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        board[i, j].Text = br.ReadString();
                        board[i, j].ForeColor = Color.Black;
                    }
                }
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Stack<int[]> vs = new Stack<int[]>();
            int[] cue = new int[2] { 0,0};
            vs.Push(cue.ToArray());
            board[cue[0], cue[1]].Text = (Convert.ToInt32(board[cue[0], cue[1]].Text) + 1).ToString();
            board[cue[0], cue[1]].ForeColor = Color.Red;
            while (cue[0] != 6 || cue[1] != 6)
            {
                if(cue[0]+1 <7 )
                {
                    if(board[cue[0]+1,cue[1]].Text == "0")
                    {
                        cue[0]++;
                        vs.Push(cue.ToArray());

                        board[cue[0], cue[1]].Text = (Convert.ToInt32(board[cue[0], cue[1]].Text) + 1).ToString();
                        board[cue[0], cue[1]].ForeColor = Color.Red;
                        continue;
                    }

                                     
                }
                if (cue[1] + 1 < 7)
                {
                    if (board[cue[0], cue[1] + 1].Text == "0")
                    {
                        cue[1]++;
                        vs.Push(cue.ToArray());
                        board[cue[0], cue[1]].Text = (Convert.ToInt32(board[cue[0], cue[1]].Text) + 1).ToString();
                        board[cue[0], cue[1]].ForeColor = Color.Red;
                        continue;
                    }
                }
                if( cue[0] - 1 >= 0 )
                {
                    if (board[cue[0] - 1, cue[1]].Text == "0")
                    {
                        cue[0]--;
                        vs.Push(cue.ToArray());
                        board[cue[0], cue[1]].Text = (Convert.ToInt32(board[cue[0], cue[1]].Text) + 1).ToString();
                        board[cue[0], cue[1]].ForeColor = Color.Red;
                        continue;
                    }                    
                }
                if(cue[1] - 1 >= 0)
                {
                    if (board[cue[0], cue[1] - 1].Text == "0")
                    {
                        cue[1]--;
                        vs.Push(cue.ToArray());
                        board[cue[0], cue[1]].Text = (Convert.ToInt32(board[cue[0], cue[1]].Text) + 1).ToString();
                        board[cue[0], cue[1]].ForeColor = Color.Red;
                        continue;
                    }
                }
                board[cue[0], cue[1]].ForeColor = Color.Black;
                vs.Pop();
                cue = vs.Peek().ToArray();
            }
        }
    }
}
