using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Diffie_Hellman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtA.Text == "" || txtB.Text == "" || txtG.Text == "" || txtP.Text == "")
            {
                lblA.Text = "";
                lblB.Text = "";
                lblP.Text = "";
                lblG.Text = "";
                if (txtP.Text == "" || !PrimeNumber(BigInteger.Parse(txtP.Text)))
                {
                    lblP.Text = "*Plotesojeni kete fushe \n me numer te thjeshte!";
                }
           
                if (txtG.Text == "")
                {
                    lblG.Text = "*Plotesojeni kete fushe !";
                }
             
                if (txtA.Text == "")
                {
                    lblA.Text = "*Plotesojeni kete fushe !";
                }
              
                if (txtB.Text == "")
                {
                    lblB.Text = "*Plotesojeni kete fushe !";
                }

                richTextBox1.Text = "";
            }
            else
            {
                lblA.Text = "";
                lblB.Text = "";
                lblP.Text = "";
                lblG.Text = "";

                BigInteger g = BigInteger.Parse(txtG.Text);
                BigInteger p = BigInteger.Parse(txtP.Text);
                if (!PrimeNumber(p))
                {


                    lblP.Text = "*Nuk eshte numer i thjeshte!";


                    richTextBox1.Text = "";

                }
                else if (!Kontrollo(g, p))
                {
                    lblG.Text = "Numri nuk eshte \ngjernerator i p !";
                    richTextBox1.Text = "";
                }
                else
                {
                    lblG.Text = "";
                    BigInteger a = BigInteger.Parse(txtA.Text);
                    BigInteger b = BigInteger.Parse(txtB.Text);
                  
                 

                        BigInteger VleraA = BigInteger.ModPow(g, a, p);

                        BigInteger VleraB = BigInteger.ModPow(g, b, p);

                        BigInteger CelesiA = BigInteger.ModPow(VleraB, a, p);
                        BigInteger CelesiB = BigInteger.ModPow(VleraA, b, p);
                        string mesazhi = "Vlera e a =" + a + "\nVlera e b =" + b + "\nVlera e Celesi i Gjereneraur i A=" + CelesiA + "\nVlera e Celesi i Gjereneraur i B=" + CelesiB;

                        richTextBox1.Text = mesazhi;


                        lblGabimiP.Text = "";
                    
                }
            }
        }
        public bool Kontrollo(BigInteger num, BigInteger pja)
        {
            if (num >= pja)
            {
                return false;
            }
            else
            {
                BigInteger[] vargu = new BigInteger[(int)pja - 1];
                BigInteger[] vargu2 = new BigInteger[(int)pja - 1];

                for (int i = 1; i <= (pja - 1); i++)
                {
                    vargu2[i - 1] = i;

                }
                for (int i = 1; i <= (pja - 1); i++)
                {
                    vargu[i - 1] = BigInteger.ModPow(num, i, pja);

                }
                Array.Sort(vargu);

                return vargu.SequenceEqual(vargu2);
            }
        }
        public bool PrimeNumber(BigInteger number)
        {
            if (number > 1)
            {
                for (int i = 2; i <= number - 1; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }

                }
                return true;
            }
            else
            {
                return false;
            }
            
        }
     
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) )
            {
                e.Handled = true;
            }

        }
    }
}
