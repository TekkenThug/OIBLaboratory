using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void generationMethod(int amount, int from, int to, ref string password)
        {
            Random rand = new Random();
            for (int i = 0; i < amount; i++) {
                password += (char)rand.Next(from, to + 1);       
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idLenght = textBox1.Text.Length;
            string password = "";
            generationMethod(2, 'A', 'Z', ref password);
            password += Math.Pow(idLenght, 2) % 10;
            generationMethod(1, '0', '9', ref password);
            generationMethod(1, '!', '*', ref password);
            generationMethod(1, 'a', 'z', ref password);
            textBox2.Text = password;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
