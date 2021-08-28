using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace OIB_2
{
    public class globalName
    {
        public static string username;
    }

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var path = @"..\usersDb.accdb";

            if (!File.Exists(path))
            {
                var db = new ADOX.Catalog();

                try
                {
                    db.Create(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='..\usersDb.accdb';");
                }
                catch (System.Runtime.InteropServices.COMException sit)
                {
                    MessageBox.Show(sit.Message);
                }
                finally
                {
                    db = null;
                }

                var connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='..\usersDb.accdb';");
                connection.Open();

                var table = new OleDbCommand("CREATE TABLE [USERS]([Номер] counter, [Логин] char(200), [Пароль] char(200), [Фамилия] char(200), [Имя] char(200), [Отчество] char(200), [Дата-рождения] char(200), [Место-рождения] char(200), [Телефон] char(200))", connection);

                try
                {
                    table.ExecuteNonQuery();
                }
                catch (Exception situation)
                {
                    MessageBox.Show(situation.Message);
                }

                connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            globalName.username = textBox1.Text;
            var password = textBox2.Text;

            var connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='..\usersDb.accdb';");
            connection.Open();

            var findUser = new OleDbCommand("SELECT * FROM USERS WHERE Логин = '" + globalName.username + "' AND Пароль = '" + password + "'", connection);
            var auth = Convert.ToString(findUser.ExecuteScalar());

            connection.Close();

            if (password == "" || globalName.username == "")
            {
                MessageBox.Show("Заполните поля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (auth != "")
            {
                MessageBox.Show("Вход выполнен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Change f = new Change();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Данные введены неверно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reg f = new Reg();
            this.Hide();
            f.ShowDialog();
        }
    }
}
