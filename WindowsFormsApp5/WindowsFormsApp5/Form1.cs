using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int level, row, column;
        List<double> list = new List<double>();
        List<double[]> lists = new List<double[]>();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            lists.Clear();
            list.Clear();
            button6.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button3.Enabled = true;
            textBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double[,] m = new double[level, level];
            for(int i = 0; i < level; i++)
            {
                double[] n ;
                n = lists[i].ToArray();
                for (int j = 0; j < level; j++)
                {
                    m[i, j] = n[j];
                }
            }

            var matrix = MathNet.Numerics.LinearAlgebra.CreateMatrix.DenseOfArray(m);
            //var rowmatrix = matrix.RowSums();
            var sum = matrix.Determinant().ToString();
            textBox4.Text = sum;
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //button5_Click(sender,e);
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader Reader = new BinaryReader(file);
                int q = Reader.ReadInt32();
                level = q;
                for (int i = 0; i < q; i++)
                {
                    for(int j = 0; j < q; j++)
                    {
                        try
                        {
                            int t = Reader.ReadInt32();
                            list.Add(t);
                            textBox1.Text += t + " ";
                            if (list.Count >= q)
                            {
                                lists.Add(list.ToArray());
                                list.Clear();
                                textBox1.Text += "\r\n";
                            }
                            if (lists.Count >= q)
                            {
                                textBox3.Text = "";
                                textBox3.ReadOnly = true;
                                button2.Enabled = false;
                                button6.Enabled = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                button3.Enabled = false;
                file.Close();
                Reader.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                BinaryWriter writer = new BinaryWriter(file);
                writer.Write(Convert.ToInt32(level));
                foreach(var i in textBox1.Text)
                {
                    if(i != ' ' && i != '\r' && i != '\n')
                    {
                        try
                        {
                            writer.Write(Convert.ToInt32(i));
                        }
                        catch
                        {

                        }

                    }
                    
                }
                writer.Flush();
                writer.Close();
                file.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                level = Convert.ToInt32(textBox2.Text);
                if(level > 10)
                {
                    throw new Exception(" > 10");
                }
                button1.Enabled = false;
                textBox2.ReadOnly = true;
                row = level;
                column = level;
                button2.Enabled = true;
            }
            catch(Exception ex)
            {
                level = 0;
                button2.Enabled = false;
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                list.Add(Convert.ToInt32(textBox3.Text));
                textBox1.Text += textBox3.Text + " ";
                textBox3.Text = "";
                if (list.Count >= level)
                {
                    lists.Add( list.ToArray());
                    list.Clear();
                    textBox1.Text += "\r\n";
                }                
                if (lists.Count >= level)
                {
                    textBox3.Text = "";
                    textBox3.ReadOnly = true;
                    button2.Enabled = false;
                    button6.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
