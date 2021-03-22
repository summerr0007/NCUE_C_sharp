// BlackJack.Form1
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _0322
{
    public partial class Form1 : Form
	{
		private bool start = false;

		private bool[] card = new bool[52];

		private int[] dealer = new int[5];

		private int[] player = new int[5];

		private Random ran = new Random();

		private int N1;

		private int N2;

		private int d;

		private int p;

		private int dn;

		private int pn;

		//private IContainer components = null;

		private Label label1;

		private Label label2;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button8;

		private Button button9;

		private Button button10;

		private Label label3;

		private TextBox textBox1;

		private Label label4;

		private TextBox textBox2;

		private Button button11;

		private Button button12;

		private Button button13;

		private string GenerateColor(int a)
		{
			string text = ((a <= 12) ? "♠\r\n" : ((a <= 25) ? "♥\r\n" : ((a > 38) ? "♣\r\n" : "♦\r\n")));
			if (a % 13 == 0)
			{
				return text + "A";
			}
			if (a % 13 == 12)
			{
				return text + "K";
			}
			if (a % 13 == 11)
			{
				return text + "Q";
			}
			if (a % 13 == 10)
			{
				return text + "J";
			}
			return text + (a % 13 + 1);
		}

		private void button13_Click(object sender, EventArgs e)
		{
			if (!start)
			{
				return;
			}
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
					dealer[d] = ran.Next(52);
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
					textBox1.Text = string.Concat(N1 + N2);
					MessageBox.Show("莊家爆掉，你贏了" + N2 + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					start = false;
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
				textBox1.Text = string.Concat(N1 + N2);
				MessageBox.Show("玩家點數較高，你贏了" + N2 + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			if (dn > pn)
			{
				textBox1.Text = string.Concat(N1 - N2);
				MessageBox.Show("莊家點數較高，你輸了" + N2 + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			start = false;
			textBox2.ReadOnly = false;
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			try
			{
				if (start)
				{
					return;
				}
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
				N1 = Convert.ToInt32(textBox1.Text);
				N2 = Convert.ToInt32(textBox2.Text);
				if (N2 > N1)
				{
					throw new Exception("籌碼不足");
				}
				if (N2 == 0)
				{
					throw new Exception("下注籌碼不可為0");
				}
				textBox2.ReadOnly = true;
				for (int i = 0; i < 52; i++)
				{
					card[i] = false;
				}
				for (int i = 0; i < 5; i++)
				{
					dealer[i] = -1;
					player[i] = -1;
				}
				dealer[0] = ran.Next(52);
				card[dealer[0]] = true;
				button1.Text = "";
				if (dealer[0] >= 13 && dealer[0] <= 38)
				{
					button1.ForeColor = Color.Red;
				}
				do
				{
					dealer[1] = ran.Next(52);
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
					player[0] = ran.Next(52);
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
					player[1] = ran.Next(52);
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
					}
					else
					{
						button1.Text = GenerateColor(dealer[0]);
						textBox1.Text = string.Concat(N1 - N2);
						MessageBox.Show("莊家 Black Jack，你輸了" + N2 + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						textBox2.ReadOnly = false;
					}
					return;
				}
				if ((player[0] % 13 == 0 && player[1] % 13 >= 9) || (player[0] % 13 >= 9 && player[1] % 13 == 0))
				{
					button1.Text = GenerateColor(dealer[0]);
					textBox1.Text = string.Concat(N1 + N2);
					MessageBox.Show("玩家 Black Jack，你贏了" + N2 + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					textBox2.ReadOnly = false;
					return;
				}
				start = true;
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (!start || p > 4)
			{
				return;
			}
			do
			{
				player[p] = ran.Next(52);
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
				textBox1.Text = string.Concat(N1 - N2);
				MessageBox.Show("玩家爆掉，你輸了" + N2 + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				start = false;
				textBox2.ReadOnly = false;
			}
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}*/

        /*private void InitializeComponent()
		{
			
		}*/
    }

}