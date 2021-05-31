using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        MyQueue myQueue = new MyQueue();
        TextBox[] mt = new TextBox[8];
        private void Form1_Load(object sender, EventArgs e)
        {
            mt[0] = textBox1;
            mt[1] = textBox2;
            mt[2] = textBox3;
            mt[3] = textBox4;
            mt[4] = textBox5;
            mt[5] = textBox6;
            mt[6] = textBox7;
            mt[7] = textBox8;

            flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //enqueue

            try
            {
                myQueue.enqueue(Convert.ToInt32(textBox9.Text));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dequene
            textBox10.Text = myQueue.dequeue();
            flush();
        }

        private void flush()
        {
            for (int i = 0; i < 8; i++)
            {
                mt[i].Text = myQueue.getdata(i);
            }

            textBox11.Text = myQueue.getfront();
            textBox12.Text = myQueue.getrear();
        }
    }

    class MyQueue
    {
        const int max = 8;
        int?[] queue = new int?[max] { null, null, null, null, null, null, null, null };
        int front = -1;
        int rear = -1;


        public void enqueue(int item )
        {
            if (queue[(rear + 1) % 8] == null)
            {
                rear = (rear + 1) % 8;
                queue[rear] = item;
            }
            else
            {
                MessageBox.Show("沒有空間");
            }  
            
        }

        public string dequeue()
        {
            string a = "";
            if(queue[(front + 1) % 8] != null)
            {
                front = (front + 1) % 8;
                a = queue[front].ToString();
                queue[front] = null;
            }
            else
            {
                MessageBox.Show("沒有資料");
            }
            return a;
        }

        public string getdata(int i)
        {
            if (queue[i].HasValue)
            {
                return queue[i].ToString();
            }
            else
            {
                return "";
            }
            
        }

        public string getrear()
        {
            return rear.ToString();
        }

        public string getfront()
        {
            return front.ToString();
        }
    }
}
