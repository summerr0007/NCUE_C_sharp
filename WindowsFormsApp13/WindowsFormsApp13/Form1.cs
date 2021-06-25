using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string>[] table = new List<string>[13];
        TextBox[] textBox = new TextBox[13];
        private void Form1_Load(object sender, EventArgs e)
        {
            
            for(int i = 0; i < 13; i++)
            {
                table[i] = new List<string>();
            }

            textBox[0] = textBox4;
            textBox[1] = textBox5;
            textBox[2] = textBox6;
            textBox[3] = textBox7;
            textBox[4] = textBox8;
            textBox[5] = textBox9;
            textBox[6] = textBox10;
            textBox[7] = textBox11;
            textBox[8] = textBox12;
            textBox[9] = textBox13;
            textBox[10] = textBox14;
            textBox[11] = textBox15;
            textBox[12] = textBox16;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string fold;
                int total;
                bool found;
                searchHash(str,out fold, out total, out found);
                textBox2.Text = fold;
                textBox3.Text = total.ToString() + "% 13 = " + (total % 13).ToString();
                if (found)
                {
                    MessageBox.Show("授權碼重複");
                }
                else
                {
                    table[total % 13].Add(str);
                }
                printHash();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void searchHash(string str, out string fold, out int total, out bool found)
        {
            fold = "";
            total = 0;
            found = false;
            bool ww = true;
            for(int i =0;i< str.Length; i += 3)
            {
                string s = str.Substring(i);
                if(s.Length > 3)
                {
                    s = str.Substring(i, 3);
                }

                if (ww)
                {           
                    fold += s;
                    total += Convert.ToInt32(s);
                }
                else
                {
                    char[] arr = s.ToCharArray();
                    Array.Reverse(arr);
                    string t = new string(arr);

                    fold += t;
                    total += Convert.ToInt32(t);
                }
                ww = !ww;                
            }

            if(table[total % 13].FindIndex(x => x == str) >= 0)
            {
                found = true;
            }
            
        }

        void printHash()
        {
            for(int i =0;i<13; i++)
            {
                textBox[i].Text = "";
            }
            for(int i = 0; i < 13; i++)
            {
                for (int j=0; j < table[i].Count; j++)
                {
                    textBox[i].Text = textBox[i].Text + " -> " + table[i][j];
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string fold;
                int total;
                bool found;
                searchHash(str, out fold, out total, out found);
                textBox2.Text = fold;
                textBox3.Text = total.ToString() + "% 13 = " + (total % 13).ToString();
                if (found)
                {
                    MessageBox.Show("授權碼"+str+"存在");
                }
                else
                {
                    MessageBox.Show("授權碼" + str + "不存在");
                }
                printHash();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string fold;
                int total;
                bool found;
                removeHash(str, out fold, out total, out found);
                textBox2.Text = fold;
                textBox3.Text = total.ToString() + "% 13 = " + (total % 13).ToString();
                if (found)
                {
                    //MessageBox.Show("授權碼" + str + "存在");
                }
                else
                {
                    MessageBox.Show("授權碼" + str + "不存在");
                }
                printHash();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void removeHash(string str, out string fold, out int total, out bool found)
        {
            fold = "";
            total = 0;
            found = true;
            bool ww = true;
            for (int i = 0; i < str.Length; i += 3)
            {
                string s = str.Substring(i);
                if (s.Length > 3)
                {
                    s = str.Substring(i, 3);
                }

                if (ww)
                {
                    fold += s;
                    total += Convert.ToInt32(s);
                }
                else
                {
                    char[] arr = s.ToCharArray();
                    Array.Reverse(arr);
                    string t = new string(arr);

                    fold += t;
                    total += Convert.ToInt32(t);
                }
                ww = !ww;
            }

            if (table[total % 13].FindIndex(x => x == str) >= 0)
            {
               table[total % 13].RemoveAt(table[total % 13].FindIndex(x => x == str));
            }
            else
            {
                found = false;
            }
            
        }
    }
}
