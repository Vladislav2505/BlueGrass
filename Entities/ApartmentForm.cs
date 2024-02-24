using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RealEstateAgency.Entities
{
    public partial class ApartmentForm : Form
    {
        public ApartmentForm()
        {
            InitializeComponent();
        }

        public static int n = 0;
        public static int count = Convert.ToInt32(MainForm.ds.Tables["Мероприятия"].Rows[MainForm.ds.Tables["Мероприятия"].Rows.Count - 1]["Код"]) + 1;
        private void FieldsFormFill()
        {
            textBox1.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Код"].ToString();
            textBox2.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Название"].ToString();
            dateTimePicker1.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Дата проведения"].ToString();
            comboBox1.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Тема"].ToString();
            textBox4.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Статус"].ToString();
            comboBox2.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Адрес"].ToString();
            comboBox3.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Организатор"].ToString();
            textBox7.Text = MainForm.ds.Tables["Мероприятия"].Rows[n]["Описание"].ToString();
        }

        private void FieldsFormClear()
        {
            textBox1.Text = count.ToString();
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox7.Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            MainForm.TableFill("Список тем", "SELECT CONCAT(id, ': ', name) AS \"Тема\" FROM themes");

            for (int i = 0; i < MainForm.ds.Tables["Список тем"]?.Rows.Count; i++)
            {
                comboBox1.Items.Add(MainForm.ds.Tables["Список тем"]?.Rows[i]["Тема"]);
            }

            if (MainForm.ds.Tables["Список тем"].Rows.Count > n)
            {
                FieldsFormFill();
            }

            MainForm.TableFill("Список мест", "SELECT CONCAT(id, ': ', CONCAT(city, ', ', district, ', ', street, ' ', house)) AS \"Место\" FROM event_locations");

            for (int i = 0; i < MainForm.ds.Tables["Список мест"]?.Rows.Count; i++)
            {
                comboBox2.Items.Add(MainForm.ds.Tables["Список мест"]?.Rows[i]["Место"]);
            }

            if (MainForm.ds.Tables["Список мест"].Rows.Count > n)
            {
                FieldsFormFill();
            }

            MainForm.TableFill("Список организаторов", "SELECT CONCAT(id, ': ', CONCAT(first_name, ' ',last_name)) AS \"Организатор\" FROM organizers");

            for (int i = 0; i < MainForm.ds.Tables["Список организаторов"]?.Rows.Count; i++)
            {
                comboBox3.Items.Add(MainForm.ds.Tables["Список организаторов"]?.Rows[i]["Организатор"]);
            }

            if (MainForm.ds.Tables["Список организаторов"].Rows.Count > n)
            {
                FieldsFormFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < MainForm.ds.Tables["Мероприятия"].Rows.Count) n++;

            if (MainForm.ds.Tables["Мероприятия"].Rows.Count > n)
            {
                FieldsFormFill();
            }
            else
            {
                FieldsFormClear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FieldsFormClear();
            n = MainForm.ds.Tables["Мероприятия"].Rows.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--;
                FieldsFormFill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.ds.Tables["Мероприятия"].Rows.Count > 0)
            {
                n = 0;
                FieldsFormFill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            string pattern = @"\w+";

            Match codeTheme = Regex.Match(comboBox1.Text, pattern, RegexOptions.IgnoreCase);
            Match codeLocation = Regex.Match(comboBox2.Text, pattern, RegexOptions.IgnoreCase);
            Match codeOrg = Regex.Match(comboBox3.Text, pattern, RegexOptions.IgnoreCase);

            if (n < MainForm.ds.Tables["Мероприятия"].Rows.Count)
            {
                sql = "UPDATE events SET name='" + textBox2.Text + $"', event_datetime='{dateTimePicker1.Value:dd.MM.yyyy}', " +
                    $"theme_id=" + codeTheme.Value + ", status='" + textBox4.Text + "', location_id=" + codeLocation.Value + ", " +
                    "organizer_id=" + codeOrg.Value + ", description='" + textBox7.Text + "' WHERE id='" + textBox1.Text + "'";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Мероприятия"].Rows[n].ItemArray = new object[]
                {
                    textBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox7.Text, comboBox1.Text,
                    textBox4.Text, comboBox3.Text, comboBox2.Text
                };
            }
            else
            {
                sql = "INSERT INTO events (id, name, event_datetime, description, theme_id, status, location_id, organizer_id) " +
                    "VALUES (" + textBox1.Text + ", '" + textBox2.Text + $"', '{dateTimePicker1.Value:dd.MM.yyyy}', " +
                    "'" + textBox7.Text + "', " + codeTheme.Value + ", '" + textBox4.Text + "', " + codeLocation.Value + ", " + codeOrg.Value + ")";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Мероприятия"].Rows.Add(new object[] {
                    textBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox7.Text, comboBox1.Text,
                    textBox4.Text, comboBox3.Text, comboBox2.Text
                });
                count++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника мероприятие с кодом " + textBox1.Text + "?";
            string caption = "Удаление мероприятия";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            MainForm.TableFill("МероприятиеП", "SELECT * FROM applications WHERE event_id=" + textBox1.Text);

            if (MainForm.ds.Tables["МероприятиеП"].Rows.Count > 0)
            {
                MessageBox.Show("Мероприятие из справочника может быть удален только после удаления связанных с ним заявок", "Внимание");
                return;
            }

            string sql = "DELETE FROM events WHERE id=" + textBox1.Text;
            MainForm.ModificationExecute(sql);

            MainForm.ds.Tables["Мероприятия"].Rows.RemoveAt(n);

            if (MainForm.ds.Tables["Мероприятия"].Rows.Count > n)
            {
                FieldsFormFill();
            }
            else
            {
                FieldsFormClear();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainForm.tabControl1.Controls.Remove(MainForm.tabControl1.SelectedTab);
        }
    }
}
