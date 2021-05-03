using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Picture Graph = new Picture("Graph");
        List<Picture> allPictures = new List<Picture>();
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text= Graph.show();
            allPictures.Add(Graph);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.preform = this;
            form2.ShowDialog();
            //string name, where;
            if(form2.DialogResult == DialogResult.OK)
            {
                form2.getdata(out string name, out string where);
                Picture Tpicture = new Picture(name);
                allPictures.Find(x => x.getName() == where).addComponent(Tpicture);
                allPictures.Add(Tpicture);
                label1.Text= Graph.show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.preform = this;
            form3.ShowDialog();
            if(form3.DialogResult == DialogResult.OK)
            {
                form3.getdata(out string name, out string where, out double h, out double w);
                Rectangle Trectangle = new Rectangle(name, h, w);
                allPictures.Find(x => x.getName() == where).addComponent(Trectangle);
                label1.Text = Graph.show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.preform = this;
            form4.ShowDialog();
            if(form4.DialogResult == DialogResult.OK)
            {
                form4.getdata(out string name, out string where, out double l, out double w);
                Triangle TTriangle = new Triangle(name, l, w);
                allPictures.Find(x => x.getName() == where).addComponent(TTriangle);
                label1.Text = Graph.show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.preform = this;
            form5.ShowDialog();
            if(form5.DialogResult == DialogResult.OK)
            {
                form5.getdata(out string name, out string where, out double w);
                Circle Tcircle = new Circle(name, w);
                allPictures.Find(x => x.getName() == where).addComponent(Tcircle);
                label1.Text = Graph.show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text= Graph.area().ToString();
        }
    }

    abstract class Component
    {
        protected string name;
        public abstract double area();
        public abstract string show();
        public string getName()
        {
            return name;
        }
    }

    abstract class Shape : Component { }

    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(string n ,double l,double w)
        {
            name = n;
            width = w;
            length = l;
        }

        public override double area()
        {
            return length * width;
        }

        public override string show()
        {
            return "Rectangle " + name + "{" + length + "," + width + "}";
        }
    }

    class Picture: Component
    {
        private List<Component> coms = new List<Component>();
        public Picture(string n)
        {
            name = n;
        }

        public void addComponent(Component c)
        {
            coms.Add(c);
        }

        public override double area()
        {
            double total = 0.0;
            for (int i = 0; i < coms.Count; i++)
            {
                total += coms[i].area();
            }
            return total;
        }

        public override string show()
        {
            string str = "{picture " + name + ":";
            for (int i = 0; i < coms.Count; i++)
            {
                str += " "+coms[i].show();
            }
            str += "}";
            return str;
        }
    }

    class Triangle : Shape
    {
        private double length;
        private double width;

        public Triangle(string n, double l, double w)
        {
            name = n;
            width = w;
            length = l;
        }

        public override double area()
        {
            return length * width/2;
        }

        public override string show()
        {
            return "Triangle " + name + "{" + length + "," + width + "}";
        }
    }

    class Circle : Shape
    {
        private double width;

        public Circle(string n, double w)
        {
            name = n;
            width = w;

        }

        public override double area()
        {
            return Math.PI * width ;
        }

        public override string show()
        {
            return "Clrcle " + name + "{"  + width + "}";
        }
    }
}
