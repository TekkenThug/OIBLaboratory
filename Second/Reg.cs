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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;
            var lastName = textBox3.Text;
            var firstName = textBox4.Text;
            var fatherName = textBox5.Text;
            var birthday = textBox6.Text;
            var birthplace = textBox7.Text;
            var phone = textBox8.Text;
            bool passIsWrong = false;

            if (password.Length != 6)
            {
                passIsWrong = true;
            }

            foreach (char symbol in password)
            {
                if (Char.IsUpper(symbol) || !((int)symbol >= 97 && (int)symbol <= 122))
                {
                    passIsWrong = true;
                    continue;
                }
            }

            if (password == "" || login == "")
            {
                MessageBox.Show("Логин или пароль не заполнен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (passIsWrong)
            {
                MessageBox.Show("Пароль должен содержать строчные латинские буквы и быть длиной шесть символов!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='..\usersDb.accdb';");
                db.Open();

                var note = new OleDbCommand("INSERT INTO [USERS]([Логин], [Пароль], [Фамилия], [Имя], [Отчество], [Дата-рождения], [Место-рождения], [Телефон]) VALUES('" + login + "' , '" + password + "' , '" + lastName + "', '" + firstName + "' , '" + fatherName + "' , '" + birthday + "' , '" + birthplace + "' , '" + phone + "')");
                note.Connection = db;
                note.ExecuteNonQuery();
   
                db.Close();

                MessageBox.Show("Вы успешно зарегистрировались!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
            }
        }
    }
}
