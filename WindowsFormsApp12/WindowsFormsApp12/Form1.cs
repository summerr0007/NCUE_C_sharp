using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] initial=new int[10,10];
        int[,] initialbak = new int[10, 10];
        TextBox[] stextBoxes = new TextBox[18];
        Queue<TextBox> textBoxes = new Queue<TextBox>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(Form1_paint);
            
        }
        void Form1_paint(object sender ,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen grayPen = new Pen(Color.Gray,1);
            g.DrawLine(grayPen, new Point(label1.Location.X,label1.Location.Y+15),new Point(label2.Location.X,label2.Location.Y));
            g.DrawLine(grayPen, new Point(label1.Location.X+17,label1.Location.Y),new Point(label3.Location.X,label3.Location.Y+15));
            g.DrawLine(grayPen, new Point(label1.Location.X + 17, label1.Location.Y + 15), new Point(label4.Location.X, label4.Location.Y));
            g.DrawLine(grayPen, new Point(label2.Location.X + 17, label2.Location.Y), new Point(label4.Location.X, label4.Location.Y + 15));
            g.DrawLine(grayPen, new Point(label2.Location.X + 17, label2.Location.Y + 15), new Point(label5.Location.X, label5.Location.Y + 15));
            g.DrawLine(grayPen, new Point(label3.Location.X + 17, label3.Location.Y), new Point(label6.Location.X, label6.Location.Y));
            g.DrawLine(grayPen, new Point(label3.Location.X , label3.Location.Y+15), new Point(label4.Location.X, label4.Location.Y));
            g.DrawLine(grayPen, new Point(label4.Location.X + 17, label4.Location.Y), new Point(label6.Location.X, label6.Location.Y+15));
            g.DrawLine(grayPen, new Point(label4.Location.X, label4.Location.Y+15), new Point(label5.Location.X, label5.Location.Y));
            g.DrawLine(grayPen, new Point(label4.Location.X + 17, label4.Location.Y + 15), new Point(label7.Location.X, label7.Location.Y));
            g.DrawLine(grayPen, new Point(label5.Location.X + 17, label5.Location.Y), new Point(label7.Location.X, label7.Location.Y+15));
            g.DrawLine(grayPen, new Point(label6.Location.X , label6.Location.Y+15), new Point(label7.Location.X, label7.Location.Y ));
            g.DrawLine(grayPen, new Point(label6.Location.X+17, label6.Location.Y), new Point(label8.Location.X, label8.Location.Y));
            g.DrawLine(grayPen, new Point(label6.Location.X + 17, label6.Location.Y+15), new Point(label9.Location.X, label9.Location.Y));
            g.DrawLine(grayPen, new Point(label7.Location.X, label7.Location.Y), new Point(label9.Location.X, label9.Location.Y+15));
            g.DrawLine(grayPen, new Point(label7.Location.X, label7.Location.Y+15), new Point(label10.Location.X, label10.Location.Y + 15));
            g.DrawLine(grayPen, new Point(label8.Location.X, label8.Location.Y + 15), new Point(label9.Location.X, label9.Location.Y));
            g.DrawLine(grayPen, new Point(label9.Location.X, label9.Location.Y + 15), new Point(label10.Location.X, label10.Location.Y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            renew();
            
            int start = (int)textBox19.Text[0] - (int)'A';
            int end = (int)textBox20.Text[0] - (int)'A';
            
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                                              
                        initial[i, j] = Math.Min(initial[i, j], initial[i, k] + initial[k, j]);
                    }
                }                
            }
            textBox21.Text = initial[start, end].ToString();
            textBox22.Text = textBox19.Text;
            PrintRoute(start, end);
        }


        void PrintRoute(int from,int to)
        {
            int n;
            if(initialbak[from,to] == initial[from, to])
            {
                textBox22.Text += "->" + (char)((int)'A'+to);
            }
            else
            {
                for(n = 0; n < 10; n++)
                {
                    if(initial[from,to] == initialbak[from, n] + initial[n, to])
                    {
                        textBox22.Text += "->" + (char)((int)'A' + n);
                        PrintRoute(n, to);
                        return;
                    }
                }
            }
        }

        void renew()
        {
            initial[0, 0] = int.MaxValue / 2;
            initial[0, 1] = Convert.ToInt32(textBox1.Text);
            initial[0, 2] = Convert.ToInt32(textBox2.Text);
            initial[0, 3] = Convert.ToInt32(textBox3.Text);
            initial[0, 4] = int.MaxValue/2;
            initial[0, 5] = int.MaxValue/2;
            initial[0, 6] = int.MaxValue/2;
            initial[0, 7] = int.MaxValue/2;
            initial[0, 8] = int.MaxValue/2;
            initial[0, 9] = int.MaxValue/2;


            initial[1, 0] = Convert.ToInt32(textBox1.Text);
            initial[1, 1] = int.MaxValue / 2;
            initial[1, 2] = int.MaxValue/2;
            initial[1, 3] = Convert.ToInt32(textBox4.Text);
            initial[1, 4] = Convert.ToInt32(textBox5.Text);
            initial[1, 5] = int.MaxValue/2;
            initial[1, 6] = int.MaxValue/2;
            initial[1, 7] = int.MaxValue/2;
            initial[1, 8] = int.MaxValue/2;
            initial[1, 9] = int.MaxValue/2;


            initial[2, 0] = Convert.ToInt32(textBox2.Text);
            initial[2, 1] = int.MaxValue/2;
            initial[2, 2] = int.MaxValue / 2;
            initial[2, 3] = Convert.ToInt32(textBox6.Text);
            initial[2, 4] = int.MaxValue/2;
            initial[2, 5] = Convert.ToInt32(textBox8.Text);
            initial[2, 6] = int.MaxValue/2;
            initial[2, 7] = int.MaxValue/2;
            initial[2, 8] = int.MaxValue/2;
            initial[2, 9] = int.MaxValue/2;


            initial[3, 0] = Convert.ToInt32(textBox3.Text);
            initial[3, 1] = Convert.ToInt32(textBox4.Text);
            initial[3, 2] = Convert.ToInt32(textBox6.Text);
            initial[3, 3] = int.MaxValue / 2;
            initial[3, 4] = Convert.ToInt32(textBox7.Text);
            initial[3, 5] = Convert.ToInt32(textBox9.Text);
            initial[3, 6] = Convert.ToInt32(textBox10.Text);
            initial[3, 7] = int.MaxValue/2;
            initial[3, 8] = int.MaxValue/2;
            initial[3, 9] = int.MaxValue/2;


            initial[4, 0] = int.MaxValue/2;
            initial[4, 1] = Convert.ToInt32(textBox5.Text);
            initial[4, 2] = int.MaxValue/2;
            initial[4, 3] = Convert.ToInt32(textBox7.Text);
            initial[4, 4] = int.MaxValue / 2;
            initial[4, 5] = int.MaxValue/2;
            initial[4, 6] = Convert.ToInt32(textBox11.Text);
            initial[4, 7] = int.MaxValue/2;
            initial[4, 8] = int.MaxValue/2;
            initial[4, 9] = int.MaxValue/2;


            initial[5, 0] = int.MaxValue/2;
            initial[5, 1] = int.MaxValue/2;
            initial[5, 2] = Convert.ToInt32(textBox8.Text);
            initial[5, 3] = Convert.ToInt32(textBox9.Text);
            initial[5, 4] = int.MaxValue/2;
            initial[5, 5] = int.MaxValue / 2;
            initial[5, 6] = Convert.ToInt32(textBox12.Text);
            initial[5, 7] = Convert.ToInt32(textBox13.Text);
            initial[5, 8] = Convert.ToInt32(textBox14.Text);
            initial[5, 9] = int.MaxValue/2;


            initial[6, 0] = int.MaxValue/2;
            initial[6, 1] = int.MaxValue/2;
            initial[6, 2] = int.MaxValue/2;
            initial[6, 3] = Convert.ToInt32(textBox10.Text);
            initial[6, 4] = Convert.ToInt32(textBox11.Text);
            initial[6, 5] = Convert.ToInt32(textBox12.Text);
            initial[6, 6] = int.MaxValue / 2;
            initial[6, 7] = int.MaxValue/2;
            initial[6, 8] = Convert.ToInt32(textBox15.Text);
            initial[6, 9] = Convert.ToInt32(textBox16.Text);


            initial[7, 0] = int.MaxValue/2;
            initial[7, 1] = int.MaxValue/2;
            initial[7, 2] = int.MaxValue/2;
            initial[7, 3] = int.MaxValue/2;
            initial[7, 4] = int.MaxValue/2;
            initial[7, 5] = Convert.ToInt32(textBox13.Text);
            initial[7, 6] = int.MaxValue/2;
            initial[7, 7] = int.MaxValue / 2;
            initial[7, 8] = Convert.ToInt32(textBox17.Text);
            initial[7, 9] = int.MaxValue/2;


            initial[8, 0] = int.MaxValue/2;
            initial[8, 1] = int.MaxValue/2;
            initial[8, 2] = int.MaxValue/2;
            initial[8, 3] = int.MaxValue/2;
            initial[8, 4] = int.MaxValue/2;
            initial[8, 5] = Convert.ToInt32(textBox14.Text);
            initial[8, 6] = Convert.ToInt32(textBox15.Text);
            initial[8, 7] = Convert.ToInt32(textBox17.Text);
            initial[8, 8] = int.MaxValue / 2;
            initial[8, 9] = Convert.ToInt32(textBox18.Text);


            initial[9, 0] = int.MaxValue/2;
            initial[9, 1] = int.MaxValue/2;
            initial[9, 2] = int.MaxValue/2;
            initial[9, 3] = int.MaxValue/2;
            initial[9, 4] = int.MaxValue/2;
            initial[9, 5] = int.MaxValue/2;
            initial[9, 6] = Convert.ToInt32(textBox16.Text);
            initial[9, 7] = int.MaxValue/2;
            initial[9, 8] = Convert.ToInt32(textBox18.Text);
            initial[9, 9] = int.MaxValue / 2;


            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    initialbak[i, j] = initial[i, j];
                }
            }
        }
    }
}
