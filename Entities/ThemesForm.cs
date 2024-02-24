using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RealEstateAgency.Entities
{
    public partial class ThemesForm : Form
    {
        public ThemesForm()
        {
            InitializeComponent();
        }

        public static int n = 0;
        public static int count = Convert.ToInt32(MainForm.ds.Tables["Темы"].Rows[MainForm.ds.Tables["Темы"].Rows.Count - 1]["id"]) + 1;

        private void FieldsFormFill()
        {
            textBox1.Text = MainForm.ds.Tables["Темы"].Rows[n]["id"].ToString();
            textBox2.Text = MainForm.ds.Tables["Темы"].Rows[n]["name"].ToString();
            textBox3.Text = MainForm.ds.Tables["Темы"].Rows[n]["description"].ToString();
        }

        private void FieldsFormClear()
        {
            textBox1.Text = count.ToString();
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (MainForm.ds.Tables["Темы"].Rows.Count > n)
            {
                FieldsFormFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < MainForm.ds.Tables["Темы"].Rows.Count) n++;

            if (MainForm.ds.Tables["Темы"].Rows.Count > n)
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
            n = MainForm.ds.Tables["Темы"].Rows.Count;
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
            if (MainForm.ds.Tables["Темы"].Rows.Count > 0)
            {
                n = 0;
                FieldsFormFill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;

            if (n < MainForm.ds.Tables["Темы"].Rows.Count)
            {
                sql = "UPDATE themes SET name='" + textBox2.Text + "', description='" + textBox3.Text + "' WHERE id='" + textBox1.Text + "'";
                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Темы"].Rows[n].ItemArray = new object[]
                {
                    textBox1.Text, textBox2.Text, textBox3.Text,
                };
            }
            else
            {
                sql = "INSERT INTO themes (id, name, description) " +
                "VALUES (" + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "')";
                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }
                MainForm.ds.Tables["Темы"].Rows.Add(new object[] {
                    textBox1.Text, textBox2.Text, textBox3.Text,
                });
                count++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника тему с кодом " + textBox1.Text + "?";
            string caption = "Удаление темы";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            MainForm.TableFill("ТемыП", "SELECT * FROM events WHERE theme_id=" + textBox1.Text);

            if (MainForm.ds.Tables["ТемыП"].Rows.Count > 0)
            {
                MessageBox.Show("Тема из справочника может быть удален только после удаления связанных с ней мероприятий", "Внимание");
                return;
            }

            string sql = "DELETE FROM themes WHERE id=" + textBox1.Text;
            MainForm.ModificationExecute(sql);

            MainForm.ds.Tables["Темы"].Rows.RemoveAt(n);

            if (MainForm.ds.Tables["Темы"].Rows.Count > n)
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
