using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RealEstateAgency.Entities
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        public static int n = 0;
        public static int count;
        private void FieldsFormFill()
        {
            textBox1.Text = MainForm.ds.Tables["Заявки"].Rows[n]["Номер заявки"].ToString();
            comboBox4.Text = MainForm.ds.Tables["Заявки"].Rows[n]["Участник"].ToString();
            comboBox2.Text = MainForm.ds.Tables["Заявки"].Rows[n]["Название мероприятия"].ToString();
            dateTimePicker1.Text = MainForm.ds.Tables["Заявки"].Rows[n]["Дата отправки"].ToString();
            textBox2.Text = MainForm.ds.Tables["Заявки"].Rows[n]["Статус заявки"].ToString();
        }

        private void FieldsFormClear()
        {
            textBox1.Text = count.ToString();
            comboBox4.Text = ""; 
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            MainForm.TableFill("Список Участников", "SELECT CONCAT(id, ': ', first_name, ' ', last_name) as \"Участник\" FROM participants");
            MainForm.TableFill("Список Мероприятий", "SELECT CONCAT(id, ': ', name) as \"Мероприятие\" FROM events");

            for (int i = 0; i < MainForm.ds.Tables["Список Участников"]?.Rows.Count; i++)
            {
                comboBox4.Items.Add(MainForm.ds.Tables["Список Участников"]?.Rows[i]["Участник"]);
            }

            for (int i = 0; i < MainForm.ds.Tables["Список Мероприятий"]?.Rows.Count; i++)
            {
                comboBox2.Items.Add(MainForm.ds.Tables["Список Мероприятий"]?.Rows[i]["Мероприятие"]);
            }

            if (MainForm.ds.Tables["Заявки"].Rows.Count > 0)
            {
                count = Convert.ToInt32(MainForm.ds.Tables["Заявки"].Rows[MainForm.ds.Tables["Заявки"].Rows.Count - 1]["Номер заявки"]) + 1;

            } else
            {
                textBox1.Text = "1";
            }

            if (MainForm.ds.Tables["Заявки"].Rows.Count > n)
            {
                FieldsFormFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < MainForm.ds.Tables["Заявки"].Rows.Count) n++;

            if (MainForm.ds.Tables["Заявки"].Rows.Count > n)
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
            n = MainForm.ds.Tables["Заявки"].Rows.Count;
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
            if (MainForm.ds.Tables["Заявки"].Rows.Count > 0)
            {
                n = 0;
                FieldsFormFill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            string pattern = @"\w+";

            Match pCode = Regex.Match(comboBox2.Text, pattern, RegexOptions.IgnoreCase);
            Match eCode = Regex.Match(comboBox4.Text, pattern, RegexOptions.IgnoreCase);

            if (n < MainForm.ds.Tables["Заявки"].Rows.Count)
            {
                sql = "UPDATE applications SET participant_id='" + pCode.Value + "', event_id='" + eCode.Value +
                "', " + $"date_submitted='{dateTimePicker1.Value:dd.MM.yyyy}'" + ", status='" + textBox2.Text + "' WHERE id='" + textBox1.Text + "'";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Заявки"].Rows[n].ItemArray = new object[]
                {
                    textBox1.Text, comboBox4.Text, comboBox2.Text, dateTimePicker1.Value, textBox2.Text,
                };
            }
            else
            {
                sql = "INSERT INTO events (id, participant_id, event_id, date_submitted, status) " +
                "VALUES (" + textBox1.Text + ", '" + pCode.Value + "', '" + eCode.Value + "', " + $"'{dateTimePicker1.Value:dd.MM.yyyy}', status='" + textBox2 + "')";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Заявки"].Rows.Add(new object[] {
                    textBox1.Text, comboBox4.Text, comboBox2.Text, dateTimePicker1.Value, textBox2.Text,
                });
                count++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника заявку с кодом " + textBox1.Text + "?";
            string caption = "Удаление заявки";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            string sql = "DELETE FROM applications WHERE id=" + textBox1.Text;
            MainForm.ModificationExecute(sql);

            MainForm.ds.Tables["Заявки"].Rows.RemoveAt(n);

            if (MainForm.ds.Tables["Заявки"].Rows.Count > n)
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
