using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OIB_4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const int a = 17;
        private const int b = 11;
        private const int c = 256;
        private const int maxVal = 255;
        private const int t0 = 172;

        public static int KSumm(string document, int MaxVal)
        {
            int symbolsSumm = 0;
            byte[] res = System.Text.Encoding.Default.GetBytes(document);

            foreach (var symbol in res)
            {
                symbolsSumm += Convert.ToInt32(symbol);
            }

            if (symbolsSumm > MaxVal)
                symbolsSumm %= (MaxVal + 1);

            return symbolsSumm;
        }

        public static int SummKodBukvOtkr(string password, int maxVal)
        {
            var X = password.Select(c => ToBinary(c)).ToArray();
            var T = GetRandomDigits(password.Length).Select(c => ToBinary(c)).ToArray();
            var Y = new string[X.Count()];

            for (int k = 0; k < X.Count(); k++)
            {
                var str = "";
                for (int j = 0; j < X[k].Length; j++)
                    str += (X[k][j] + T[k][j]) % 2;
                Y[k] = str;
            }

            var K = Y.Select(x => Convert.ToInt32(x, 2)).Sum();
            return (K <= maxVal) ? K % (maxVal + 1) : K;
        }

        private static int[] GetRandomDigits(int n)
        {
            var arr = new int[n];
            arr[0] = 0;
            for (int i = 0; i < n - 1; i++)
                arr[i + 1] = (a * arr[i] + b) % c;
            return arr;
        }

        private static char[] ToBinary(int digit)
        {
            var result = "";
            ToBinary(digit, ref result);
            while (result.Length != 8) result += '0';
            return result.Reverse().ToArray();
        }

        private static void ToBinary(int digit, ref string result)
        {
            if (digit == 0) return;
            result += digit % 2;
            ToBinary(digit / 2, ref result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            int K = KSumm(text, maxVal);
            int K2 = SummKodBukvOtkr(text, maxVal);

            textBox2.Text = Convert.ToString(K);
            textBox3.Text = Convert.ToString(K2);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
