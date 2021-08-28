using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OIB_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generationMethod(int amount, List<string>symbols, ref string password)
        {
            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                password += symbols[rand.Next(symbols.Count)];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Tag = checkBox2.Tag = 26;
            checkBox3.Tag = checkBox4.Tag = 33;
            checkBox5.Tag = checkBox6.Tag = 10;

            double P = Convert.ToDouble(textBox1.Text);
            double V = Convert.ToDouble(textBox2.Text);
            double T = Convert.ToDouble(textBox3.Text);
            double minS = Math.Ceiling((V * T) / P);

            double A = 0;

            List<string> allSymbols = new List<string>();

            if (checkBox5.Checked)
            {
                A += Convert.ToDouble(checkBox5.Tag);
                for (char i = '!'; i <= '*'; i++)
                {
                    allSymbols.Add(Convert.ToString(i));
                }
            }

            if (checkBox6.Checked)
            {
                A += Convert.ToDouble(checkBox6.Tag);
                for (char i = '0'; i <= '9'; i++)
                {
                    allSymbols.Add(Convert.ToString(i));
                }
            }

            if (checkBox1.Checked) {
                A += Convert.ToDouble(checkBox1.Tag);
                for (char i = 'A'; i <= 'Z'; i++)
                {
                    allSymbols.Add(Convert.ToString(i));
                }
            }
                
            if (checkBox2.Checked)
            {
                A += Convert.ToDouble(checkBox2.Tag);
                for (char i = 'a'; i <= 'z'; i++)
                {
                    allSymbols.Add(Convert.ToString(i));
                }
            }
                
            if (checkBox3.Checked)
            {
                A += Convert.ToDouble(checkBox3.Tag);
                for (char i = 'А'; i <= 'Я'; i++)
                {
                    allSymbols.Add(Convert.ToString(i));
                }
            }
                
            if (checkBox4.Checked)
            {
                A += Convert.ToDouble(checkBox4.Tag);
                for (char i = 'а'; i <= 'я'; i++)
                {
                    allSymbols.Add(Convert.ToString(i));
                }
            }

            int L = Convert.ToInt32(Math.Ceiling(Math.Log(minS, A)));

            textBox4.Text = Convert.ToString(minS);
            textBox5.Text = Convert.ToString(A);
            textBox6.Text = Convert.ToString(L);

            string password = "";

            generationMethod(L, allSymbols, ref password);

            textBox7.Text = password;
        }
    }
}
