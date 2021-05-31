using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        node root = new node(0);
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            try
            {
                n = Convert.ToInt32(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            node ptr1 = root;
            node ptr2 = root.Left;
            node x = new node(n);
            if(ptr2 == null)
            {
                root.Left = x;
                textBox1.Text = "";
                button4_Click(this, null);
                return;
            }
            while(ptr2 != null)
            {
                if(ptr2.Data == n)
                {
                    MessageBox.Show("資料"+n.ToString()+"已存在，新增失敗");
                    
                    return;
                }
                ptr1 = ptr2;
                if(n < ptr2.Data)
                {
                    ptr2 = ptr2.Left;
                }
                else
                {
                    ptr2 = ptr2.Right;
                }
            }
            if(n < ptr1.Data)
            {
                ptr1.Left = x;
            }
            else
            {
                ptr1.Right = x;
            }
            textBox1.Text = "";
            button4_Click(this,null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //preorder
            textBox2.Text = "";
            PreOrder(root.Left);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //inorder
            textBox2.Text = "";
            InOrder(root.Left);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //postorder
            textBox2.Text = "";
            PostOrder(root.Left);
        }

        private void PreOrder(node ptr)
        {
            if (ptr != null)
            {
                textBox2.Text += " " + ptr.Data.ToString();
                PreOrder(ptr.Left);
                PreOrder(ptr.Right);
            }
        }

        private void InOrder(node ptr)
        {
            if(ptr != null)
            {
                InOrder(ptr.Left);
                textBox2.Text += " " + ptr.Data.ToString();
                InOrder(ptr.Right);
            }
        }

        private void PostOrder(node ptr)
        {
            if (ptr != null)
            {
                PostOrder(ptr.Left);
                PostOrder(ptr.Right);
                textBox2.Text += " " + ptr.Data.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            int n = 0;
            try
            {
                n = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            delete(n);
            button4_Click(this, null);
        }

         private node delete(int n)
        {
            node temp;
            node ptr1 = root;
            node ptr2 = ptr1.Left;
            
            while (ptr2 != null)
            {
                if (ptr2.Data == n)
                {
                    break;
                }
                ptr1 = ptr2;
                if (n < ptr2.Data)
                {
                    ptr2 = ptr2.Left;
                }
                else
                {
                    ptr2 = ptr2.Right;
                }
            }
            if (ptr2 == null)
            {
                MessageBox.Show("資料" + n.ToString() + "不存在");
                return null;
            }
            else
            {
                if (ptr2.Left != null && ptr2.Right != null)
                {
                    int ttq = 0;
                    temp = ptr2.Left;
                    while (temp.Right != null)
                    {
                        temp = temp.Right;
                    }
                    ttq = temp.Data;
                    delete(temp.Data);
                    ptr2.Data = ttq;
                   
                }else if (ptr2.Left != null || ptr2.Right != null)
                {
                    
                    if (ptr1.Left != null && ptr2.Data == ptr1.Left.Data)
                    {
                        if (ptr2.Left != null)
                        {
                            ptr1.Left = ptr2.Left;
                        }
                        else
                        {
                            ptr1.Left = ptr2.Right;
                        }
                    }
                    else
                    {
                        if (ptr2.Left != null)
                        {
                            ptr1.Right = ptr2.Left;
                        }
                        else
                        {
                            ptr1.Right = ptr2.Right;
                        }
                    }
                }
                else
                {
                    if(ptr1.Left != null && ptr2.Data == ptr1.Left.Data )
                    {
                        ptr1.Left = null;
                    }
                    else
                    {
                        ptr1.Right = null;
                    }
                    
                }
            }
            return null;
        }
    }

    class node
    {
        int data;
        node left { get; set; }
        node right { get; set; }
        public node(int n)
        {
            data = n;
            left = null;
            right = null;
        }

        public int Data
        {
            get {
                return data; 
            }
            set {
                data = value; 
            }
        }

        public node Left
        {
            get {
                return left; 
            }
            set {
                left = value; 
            }
        }
        public node Right
        {
            get { 
                return right; 
            }
            set
            {
                right = value;
            }

        }
    }

}
