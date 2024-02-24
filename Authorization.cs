using System;
using System.Drawing;
using System.Windows.Forms;

namespace RealEstateAgency
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        public static string user = "";

        private void Authorization_Load(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT * FROM userse ORDER BY login";

            MainForm.TableFill("Пользователь", sql);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == MainForm.ds
                .Tables["Пользователь"]?.Rows[1]["password"].ToString())
            {
                if (textBox1.Text == "Главный руководитель")
                    user = "Администратор";
                else if (textBox1.Text == "Сотрудник")
                    user = "Сотрудник";

                Hide();
                new MainForm().ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильный пароль");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
           string sql = "SELECT e.id as \"Код\", e.name AS \"Название\", e.event_datetime AS \"Дата проведения\", e.description AS \"Описание\", CONCAT(t.id, ': ', t.name) AS \"Тема\", e.status AS \"Статус\"," +
                "CONCAT(o.id, ': ', o.first_name, ' ', o.last_name) AS \"Организатор\", " +
                "CONCAT(el.id, ': ', el.city, ', ', el.district, ', ', el.street, ' ', el.house) AS \"Адрес\" FROM " +
                "events e JOIN themes t ON e.theme_id = t.id " +
                "JOIN organizers o ON e.organizer_id = o.id " +
                "JOIN event_locations el ON e.location_id = el.id ORDER BY \"Код\"";


            MainForm.TableFill("Мероприятия", sql);
            MainForm.ds.Tables["Мероприятия"].DefaultView.Sort = "Код";

            dataGridView1.DataSource = MainForm.ds.Tables["Мероприятия"].DefaultView;
            dataGridView1.Columns["Код"].Visible = false;
            dataGridView1.Columns["Описание"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Enabled = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }

        private void buttonEnter_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBoxPassword.Text == "123123")
                {
                    MainForm.TableFill("Участники", "SELECT * FROM participants ORDER BY id");

                    MainForm.TableFill("Организаторы", "SELECT * FROM organizers ORDER BY id");

                    MainForm.TableFill("Темы", "SELECT * FROM themes ORDER BY id");

                    MainForm.TableFill("Места", "SELECT * FROM event_locations ORDER BY id");

                    MainForm.TableFill("Заявки", "SELECT a.id AS \"Номер заявки\", CONCAT(p.id, ': ', p.first_name, ' ', p.last_name) AS \"Участник\", " +
                        "CONCAT(e.id, ': ', e.name) AS \"Название мероприятия\", a.date_submitted AS \"Дата отправки\", a.status AS \"Статус заявки\" " +
                        "FROM applications a JOIN participants p ON a.participant_id = p.id JOIN events e ON a.event_id = e.id ORDER BY \"Номер заявки\"");

                    Menu menu = new Menu();
                    this.Size = new Size(908, 900);
                    MainForm.tabControl1.TabPages.RemoveAt(0);
                    MainForm.tabControl1.Controls.Add(menu.tabControl1.TabPages[0]);
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
        }
    }
}
