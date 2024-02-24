using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateAgency.Entities
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        public static int n = 0;
        public static int count = Convert.ToInt32(MainForm.ds.Tables["Участники"].Rows[MainForm.ds.Tables["Участники"].Rows.Count - 1]["id"]) + 1;

        private void FieldsFormFill()
        {
            textBox1.Text = MainForm.ds.Tables["Участники"].Rows[n]["id"].ToString();
            textBox2.Text = MainForm.ds.Tables["Участники"].Rows[n]["login"].ToString();
            textBox3.Text = MainForm.ds.Tables["Участники"].Rows[n]["password"].ToString();
            textBox4.Text = MainForm.ds.Tables["Участники"].Rows[n]["last_name"].ToString();
            textBox5.Text = MainForm.ds.Tables["Участники"].Rows[n]["first_name"].ToString();
            textBox6.Text = MainForm.ds.Tables["Участники"].Rows[n]["middle_name"].ToString();
            textBox7.Text = MainForm.ds.Tables["Участники"].Rows[n]["email"].ToString();
            textBox8.Text = MainForm.ds.Tables["Участники"].Rows[n]["city"].ToString();
            dateTimePicker1.Text = MainForm.ds.Tables["Участники"].Rows[n]["data_of_birth"].ToString();
            maskedTextBox1.Text = MainForm.ds.Tables["Участники"].Rows[n]["phone"].ToString();
        }

        private void FieldsFormClear()
        {
            textBox1.Text = count.ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Text = "";
            maskedTextBox1.Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (MainForm.ds.Tables["Участники"].Rows.Count > n)
            {
                FieldsFormFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < MainForm.ds.Tables["Участники"].Rows.Count) n++;

            if (MainForm.ds.Tables["Участники"].Rows.Count > n)
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
            n = MainForm.ds.Tables["Участники"].Rows.Count;
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
            if (MainForm.ds.Tables["Участники"].Rows.Count > 0)
            {
                n = 0;
                FieldsFormFill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;

            if (n < MainForm.ds.Tables["Участники"].Rows.Count)
            {
                sql = "UPDATE participants SET login='" + textBox2.Text + "', password='" + textBox3.Text +
                    "', last_name='" + textBox4.Text + "', first_name='" + textBox5.Text + "', middle_name='" + textBox6.Text + "', " +
                    $"data_of_birth='{dateTimePicker1.Value:dd.MM.yyyy}', phone='" + maskedTextBox1.Text + "', email='" + textBox7.Text + "', city='" + textBox8.Text + "' WHERE id='" + textBox1.Text + "'";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Участники"].Rows[n].ItemArray = new object[]
                {
                    textBox1.Text, textBox2.Text, textBox3.Text,
                    textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Value, maskedTextBox1.Text, textBox7.Text, textBox8.Text,
                };
            }
            else
            {
                sql = $"INSERT INTO participants (id, login, password, last_name, first_name, middle_name, data_of_birth, phone, email, city) " +
                    $"VALUES (" + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "', " +
                    $"'" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + $"', '{dateTimePicker1.Value:dd.MM.yyyy}', '" + maskedTextBox1.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "')";

                if (!MainForm.ModificationExecute(sql)) 
                {
                    return;
                }

                MainForm.ds.Tables["Участники"].Rows.Add(new object[] {
                    textBox1.Text, textBox2.Text, textBox3.Text,
                    textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Value, maskedTextBox1.Text, textBox7.Text, textBox8.Text,
                });
                count++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника участника с кодом " + textBox1.Text + "?";
            string caption = "Удаление участника";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            MainForm.TableFill("УчастникП", "SELECT * FROM applications WHERE participant_id=" + textBox1.Text);

            if (MainForm.ds.Tables["УчастникП"].Rows.Count > 0)
            {
                MessageBox.Show("Участник из справочника может быть удален только после удаления связанных с ним заявок", "Внимание");
                return;
            }

            string sql = "DELETE FROM participants WHERE id=" + textBox1.Text;
            MainForm.ModificationExecute(sql);

            MainForm.ds.Tables["Участники"].Rows.RemoveAt(n);

            if (MainForm.ds.Tables["Участники"].Rows.Count > n)
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
