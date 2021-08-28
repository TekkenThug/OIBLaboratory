using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OIB_2
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oldPassword = textBox1.Text;
            var newPassword = textBox2.Text;
            var newPasswordRepeat = textBox3.Text;
            bool passIsWrong = false;

            var connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='..\usersDb.accdb';");
            connection.Open();

            var findUser = new OleDbCommand("SELECT * FROM USERS WHERE Логин = '" + globalName.username + "' AND Пароль = '" + oldPassword + "'", connection);
            var auth = Convert.ToString(findUser.ExecuteScalar());

            connection.Close();

            if (auth == "")
            {
                MessageBox.Show("Пароль неверен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (char symbol in newPassword)
            {
                if (Char.IsUpper(symbol) || !((int)symbol >= 97 && (int)symbol <= 122))
                {
                    passIsWrong = true;
                    continue;
                }
            }

            if (newPassword.Length != 6)
            {
                passIsWrong = true;
            }

            if (newPassword != newPasswordRepeat)
            {
                MessageBox.Show("Новые пароли не совпадают", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (newPassword.Length != newPassword.Distinct().Count())
            {
                MessageBox.Show("Пароль имеет повторяющиеся символы", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (passIsWrong)
            {
                MessageBox.Show("Пароль должен содержать строчные латинские буквы и быть длиной шесть символов!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                connection.Open();

                var updatePassword = new OleDbCommand("UPDATE USERS SET Пароль = '" + newPassword + "' WHERE Логин = '" + globalName.username + "'", connection);
                updatePassword.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Ваш пароль обновлен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
