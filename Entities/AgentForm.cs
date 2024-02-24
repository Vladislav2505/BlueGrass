using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RealEstateAgency.Entities
{
    public partial class AgentForm : Form
    {
        public AgentForm()
        {
            InitializeComponent();
        }

        public static int n = 0;
        public static int count = Convert.ToInt32(MainForm.ds.Tables["Организаторы"].Rows[MainForm.ds.Tables["Организаторы"].Rows.Count - 1]["id"]) + 1;
        private void FieldsFormFill()
        {
            textBox1.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["id"].ToString();
            textBox4.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["last_name"].ToString();
            textBox5.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["first_name"].ToString();
            textBox6.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["middle_name"].ToString();
            maskedTextBox1.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["phone"].ToString();
            textBox2.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["email"].ToString();
            textBox7.Text = MainForm.ds.Tables["Организаторы"].Rows[n]["experience"].ToString();
        }

        private void FieldsFormClear()
        {
            textBox1.Text = count.ToString();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
            maskedTextBox1.Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (MainForm.ds.Tables["Организаторы"].Rows.Count > n)
            {
                FieldsFormFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < MainForm.ds.Tables["Организаторы"].Rows.Count) n++;

            if (MainForm.ds.Tables["Организаторы"].Rows.Count > n)
            {
                FieldsFormFill();
            } else
            {
                FieldsFormClear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FieldsFormClear();
            n = MainForm.ds.Tables["Организаторы"].Rows.Count;
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
            if (MainForm.ds.Tables["Организаторы"].Rows.Count > 0)
            {
                n = 0;
                FieldsFormFill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;

            if (n < MainForm.ds.Tables["Организаторы"].Rows.Count)
            {
                sql = "UPDATE organizers SET last_name = '" + textBox4.Text + "', first_name = '" + textBox5.Text + "', middle_name = '" + textBox6.Text + "', " +
                    "phone = '" + maskedTextBox1.Text + "', email = '" + textBox2.Text + "', experience = '" + textBox7.Text + "' WHERE id=" + textBox1.Text;

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Организаторы"].Rows[n].ItemArray = new object[]
                {
                    textBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text,
                    maskedTextBox1.Text, textBox2.Text, textBox7.Text,
                };
            }
            else
            {
                sql = "INSERT INTO organizers (id, last_name, first_name, middle_name, phone, email, experience) " +
                    "VALUES (" + textBox1.Text + ", '" + textBox4.Text + "', '" + textBox5.Text + "', " +
                    "'" + textBox6.Text + "', '" + maskedTextBox1.Text + "', '" + textBox2.Text + "', " + textBox7.Text + ")";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Организаторы"].Rows.Add(new object[] {
                    textBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text,
                    maskedTextBox1.Text, textBox2.Text, textBox7.Text,
                });
                count++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника организатора с кодом " + textBox1.Text + "?";
            string caption = "Удаление организатора";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            MainForm.TableFill("ОрганизаторП", "SELECT * FROM events WHERE organizer_id=" + textBox1.Text);

            if (MainForm.ds.Tables["ОрганизаторП"].Rows.Count > 0)
            {
                MessageBox.Show("Организатор из справочника может быть удален только после удаления связанных с ним мероприятий", "Внимание");
                return;
            }

            string sql = "DELETE FROM organizers WHERE id=" + textBox1.Text;
            MainForm.ModificationExecute(sql);

            MainForm.ds.Tables["Организаторы"].Rows.RemoveAt(n);

            if (MainForm.ds.Tables["Организаторы"].Rows.Count > n)
            {
                FieldsFormFill();
            } else
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
