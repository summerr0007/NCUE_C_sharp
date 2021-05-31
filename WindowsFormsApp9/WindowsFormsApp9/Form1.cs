using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        node head =null;
        private void Form1_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input = 0;
            try
            {
                input = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (head == null)
            {
                head = new node(input);
                show();
                return;
            }
            node x = new node(input);
            node ptr1 = head;
            node ptr2 = head.getnext();
            if (ptr1.getdata() == input)
            {
                MessageBox.Show("資料" + input.ToString() + "重複");
                return;
            }
            while (ptr2 != null)
            {
                if (ptr2.getdata() == input)
                {
                    MessageBox.Show("資料" + input.ToString() + "重複");
                    return;
                }
                if (ptr2.getdata() > input)
                {
                    if (ptr1.getdata() > input)
                    {
                        head = x;
                        head.setnext(ptr1);
                        show();
                        return;
                    }                   
                    ptr1.setnext(x);
                    x.setnext(ptr2);
                    show();
                    return;
                }
                ptr1 = ptr2;
                ptr2 = ptr2.getnext();
            }
            ptr1.setnext(x);
            show();
        }

        public void show()
        {
            textBox2.Text = "head";
            if (head == null)
            {
                textBox2.Text += "->null";
                return;
            }
            node ptr = head;
            do
            {
                textBox2.Text += "->" + ptr.getdata().ToString();
                if(ptr.getnext() != null){
                    ptr = ptr.getnext();
                }
                else
                {
                    break;
                }
            } while (true);
            textBox2.Text += "->null";
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            node ptr1 = head;
            node ptr2 = head.getnext();
            int input = 0;
            try
            {
                input = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                show();
                return;
            }
            while(ptr2 != null)
            {
                if(ptr2.getdata() == input)
                {
                    ptr1.setnext(ptr2.getnext());
                    return;
                }
                if(ptr2.getdata() > input)
                {
                    MessageBox.Show("沒有" +input.ToString() +"無法刪除");
                }
                ptr1 = ptr2;
                ptr2 = ptr2.getnext();
            }
            MessageBox.Show("沒有" + input.ToString() + "無法刪除");
            show();
        }
    }

    class node
    {
        int data;
        node next;
        public node(int n)
        {
            data = n;
            next = null;
        }

        public int getdata()
        {
            return data;
        } 

        public node getnext()
        {
            return next;
        }

        public void setdata(int n)
        {
            data = n;
        }

        public void setnext(node n)
        {
            next = n;
        }


    }
}
