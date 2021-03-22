using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool[] card = new bool[52];
        int[] dealer = new int[5];
        int[] player = new int[5];
        Random random = new Random();
        int n1, n2, d, p, dn, pn;

        private void button13_Click(object sender, EventArgs e)
        {
            button11.Enabled = true;
            button12.Enabled = false;
            button13.Enabled = false;
            button1.Text = GenerateColor(dealer[0]);
            if (pn <= 11 && (player[0] % 13 == 0 || player[1] % 13 == 0 || player[2] % 13 == 0 || player[3] % 13 == 0 || player[4] % 13 == 0))
            {
                pn += 10;
            }
            if ((dealer[0] % 13 == 0 || dealer[1] % 13 == 0) && dn >= 7 && dn + 10 >= pn)
            {
                dn += 10;
            }
            while ((dn < 17 || dn < pn) && d <= 4)
            {
                do
                {
                    dealer[d] = random.Next(52);
                }
                while (card[dealer[d]]);
                card[dealer[d]] = true;
                if (d == 2)
                {
                    button3.Visible = true;
                    button3.Text = GenerateColor(dealer[d]);
                    if (dealer[2] >= 13 && dealer[2] <= 38)
                    {
                        button3.ForeColor = Color.Red;
                    }
                }
                if (d == 3)
                {
                    button4.Visible = true;
                    button4.Text = GenerateColor(dealer[d]);
                    if (dealer[3] >= 13 && dealer[3] <= 38)
                    {
                        button4.ForeColor = Color.Red;
                    }
                }
                if (d == 4)
                {
                    button5.Visible = true;
                    button5.Text = GenerateColor(dealer[d]);
                    if (dealer[4] >= 13 && dealer[4] <= 38)
                    {
                        button5.ForeColor = Color.Red;
                    }
                }
                if (dealer[d] % 13 < 9)
                {
                    dn += dealer[d] % 13 + 1;
                }
                else
                {
                    dn += 10;
                }
                if ((dealer[0] % 13 == 0 || dealer[1] % 13 == 0 || dealer[2] % 13 == 0 || dealer[3] % 13 == 0 || dealer[4] % 13 == 0) && dn <= 11 && dn >= 7 && dn + 10 >= pn)
                {
                    dn += 10;
                }
                d++;
                if (dn > 21)
                {
                    textBox1.Text = string.Concat(n1 + n2);
                    MessageBox.Show("莊家爆掉，你贏了" + n2 + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    textBox2.ReadOnly = false;
                    return;
                }
            }
            if (dn == pn)
            {
                MessageBox.Show("雙方點數相等，平手!!", "和局", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (dn < pn)
            {
                textBox1.Text = string.Concat(n1 + n2);
                MessageBox.Show("玩家點數較高，你贏了" + n2 + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (dn > pn)
            {
                textBox1.Text = string.Concat(n1 - n2);
                MessageBox.Show("莊家點數較高，你輸了" + n2 + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            textBox2.ReadOnly = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (p > 4)
            {
                return;
            }
            do
            {
                player[p] = random.Next(52);
            }
            while (card[player[p]]);
            card[player[p]] = true;
            if (p == 2)
            {
                button8.Visible = true;
                button8.Text = GenerateColor(player[p]);
                if (player[2] >= 13 && player[2] <= 38)
                {
                    button8.ForeColor = Color.Red;
                }
            }
            if (p == 3)
            {
                button9.Visible = true;
                button9.Text = GenerateColor(player[p]);
                if (player[3] >= 13 && player[3] <= 38)
                {
                    button9.ForeColor = Color.Red;
                }
            }
            if (p == 4)
            {
                button10.Visible = true;
                button10.Text = GenerateColor(player[p]);
                if (player[4] >= 13 && player[4] <= 38)
                {
                    button10.ForeColor = Color.Red;
                }
            }
            if (player[p] % 13 < 9)
            {
                pn += player[p] % 13 + 1;
            }
            else
            {
                pn += 10;
            }
            p++;
            if (pn > 21)
            {
                button1.Text = GenerateColor(dealer[0]);
                textBox1.Text = string.Concat(n1 - n2);
                MessageBox.Show("玩家爆掉，你輸了" + n2 + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button11.Enabled = true;
                button12.Enabled = false;
                button13.Enabled = false;
                textBox2.ReadOnly = false;
            }
        }

        public String GenerateColor(int a)
        {
            string color="";
            if(a <=12)
            {
                color = "\u2660\r\n";
            }
            else if(a<=25)
            {
                color = "\u2665\r\n";
            }else if (a <= 38)
            {
                color = "\u2666\r\n";
            }
            else
            {
                color = "\u2663\r\n";
            }
            if (a % 13 ==0)
            {
                color += "A";
            }
            else if(a%13 == 12)
            {
                color += "k";
            }
            else if(a%13==11)
            {
                color += "Q";
            }
            else if(a%13 == 10 ){
                color += "J";
            }
            else
            {
                color += (a % 13 + 1);
            }
            
            return color;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button11.Enabled = true;
            button12.Enabled = false;
            button13.Enabled = false;
            textBox1.Text = "1000";
            textBox1.ReadOnly = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                button11.Enabled = false;
                button12.Enabled = true;
                button13.Enabled = true;
                d = 2;
                p = 2;
                dn = 0;
                pn = 0;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;
                button5.ForeColor = Color.Black;
                button6.ForeColor = Color.Black;
                button7.ForeColor = Color.Black;
                button8.ForeColor = Color.Black;
                button9.ForeColor = Color.Black;
                button10.ForeColor = Color.Black;
                n1 = Convert.ToInt32(textBox1.Text);
                n2 = Convert.ToInt32(textBox2.Text);
                if(n2 > n1)
                {
                    throw new Exception("籌碼不足");
                }
                if(n2 <= 0)
                {
                    throw new Exception("下注籌碼不可為0或小於0");
                }
                textBox2.ReadOnly = true;
                int i=0;
                for(i = 0; i < 52; i++)
                {
                    card[i] = false;
                }
                for (i = 0; i < 5; i++)
                {
                    dealer[i] = -1;
                    player[i] = -1;

                }
                dealer[0] = random.Next(52);
                card[dealer[0]] = true;

                button1.Text = "";
                if (dealer[0] >= 13 && dealer[0] <= 38)
                {
                    button1.ForeColor = Color.Red;
                }
                do
                {
                    dealer[1] = random.Next(52);
                }
                while (card[dealer[1]]);
                card[dealer[1]] = true;
                button2.Text = GenerateColor(dealer[1]);
                if (dealer[1] >= 13 && dealer[1] <= 38)
                {
                    button2.ForeColor = Color.Red;
                }
                do
                {
                    player[0] = random.Next(52);
                }
                while (card[player[0]]);
                card[player[0]] = true;
                button6.Text = GenerateColor(player[0]);
                if (player[0] >= 13 && player[0] <= 38)
                {
                    button6.ForeColor = Color.Red;
                }
                do
                {
                    player[1] = random.Next(52);
                }
                while (card[player[1]]);
                card[player[1]] = true;
                button7.Text = GenerateColor(player[1]);
                if (player[1] >= 13 && player[1] <= 38)
                {
                    button7.ForeColor = Color.Red;
                }
                if ((dealer[0] % 13 == 0 && dealer[1] % 13 >= 9) || (dealer[0] % 13 >= 9 && dealer[1] % 13 == 0))
                {
                    if ((player[0] % 13 == 0 && player[1] % 13 >= 9) || (player[0] % 13 >= 9 && player[1] % 13 == 0))
                    {
                        button1.Text = GenerateColor(dealer[0]);
                        MessageBox.Show("雙方都是 Black Jack，平手!!", "和局", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox2.ReadOnly = false;
                        button11.Enabled = true;
                        button12.Enabled = false;
                        button13.Enabled = false;
                    }
                    else
                    {
                        button1.Text = GenerateColor(dealer[0]);
                        textBox1.Text = string.Concat(n1 - n2);
                        MessageBox.Show("莊家 Black Jack，你輸了" + n2 + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.ReadOnly = false;
                        button11.Enabled = true;
                        button12.Enabled = false;
                        button13.Enabled = false;
                    }
                    return;
                }
                if ((player[0] % 13 == 0 && player[1] % 13 >= 9) || (player[0] % 13 >= 9 && player[1] % 13 == 0))
                {
                    button1.Text = GenerateColor(dealer[0]);
                    textBox1.Text = string.Concat(n1 + n2);
                    MessageBox.Show("玩家 Black Jack，你贏了" + n2 + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox2.ReadOnly = false;
                    button11.Enabled = true;
                    button12.Enabled = false;
                    button13.Enabled = false;
                    return;
                }

                if (dealer[0] % 13 < 9)
                {
                    dn += dealer[0] % 13 + 1;
                }
                else
                {
                    dn += 10;
                }
                if (dealer[1] % 13 < 9)
                {
                    dn += dealer[1] % 13 + 1;
                }
                else
                {
                    dn += 10;
                }
                if (player[0] % 13 < 9)
                {
                    pn += player[0] % 13 + 1;
                }
                else
                {
                    pn += 10;
                }
                if (player[1] % 13 < 9)
                {
                    pn += player[1] % 13 + 1;
                }
                else
                {
                    pn += 10;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                button11.Enabled = true;
                button12.Enabled = false;
                button13.Enabled = false;
            }
        }
    }
}
