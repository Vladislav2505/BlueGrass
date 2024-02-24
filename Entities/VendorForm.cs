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
    public partial class VendorForm : Form
    {
        public VendorForm()
        {
            InitializeComponent();
        }

        public static int n = 0;
        public static int count = Convert.ToInt32(MainForm.ds.Tables["Места"].Rows[MainForm.ds.Tables["Места"].Rows.Count - 1]["id"]) + 1;

        private void FieldsFormFill()
        {
            textBox1.Text = MainForm.ds.Tables["Места"].Rows[n]["id"].ToString();
            textBox2.Text = MainForm.ds.Tables["Места"].Rows[n]["city"].ToString();
            textBox3.Text = MainForm.ds.Tables["Места"].Rows[n]["district"].ToString();
            textBox4.Text = MainForm.ds.Tables["Места"].Rows[n]["street"].ToString();
            textBox5.Text = MainForm.ds.Tables["Места"].Rows[n]["house"].ToString();
        }

        private void FieldsFormClear()
        {
            textBox1.Text = count.ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (MainForm.ds.Tables["Места"].Rows.Count > n)
            {
                FieldsFormFill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < MainForm.ds.Tables["Места"].Rows.Count) n++;

            if (MainForm.ds.Tables["Места"].Rows.Count > n)
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
            n = MainForm.ds.Tables["Места"].Rows.Count;
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
            if (MainForm.ds.Tables["Места"].Rows.Count > 0)
            {
                n = 0;
                FieldsFormFill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;

            if (n < MainForm.ds.Tables["Места"].Rows.Count)
            {
                sql = "UPDATE event_locations SET city='" + textBox2.Text + "', district='" + textBox3.Text + "', " +
                    "street='" + textBox4.Text + "', house='" + textBox5.Text + "' WHERE id='" + textBox1.Text + "'";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Места"].Rows[n].ItemArray = new object[]
                {
                    textBox1.Text, textBox2.Text, textBox3.Text,
                    textBox4.Text, textBox5.Text,
                };
            }
            else
            {
                sql = $"INSERT INTO event_locations (id, city, district, street, house) " +
                    $"VALUES (" + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "', " +
                "'" + textBox4.Text + "', '" + textBox5.Text + "')";

                if (!MainForm.ModificationExecute(sql))
                {
                    return;
                }

                MainForm.ds.Tables["Места"].Rows.Add(new object[] {
                    textBox1.Text, textBox2.Text, textBox3.Text,
                    textBox4.Text, textBox5.Text,
                });
                count++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника место проведения с кодом " + textBox1.Text + "?";
            string caption = "Удаление места проведения";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            MainForm.TableFill("МестаК", "SELECT * FROM events WHERE location_id=" + textBox1.Text);

            if (MainForm.ds.Tables["МестаК"].Rows.Count > 0)
            {
                MessageBox.Show("Место проведения из справочника может быть удален только после удаления связанных с ним мероприятий", "Внимание");
                return;
            }

            string sql = "DELETE FROM event_locations WHERE id=" + textBox1.Text;
            MainForm.ModificationExecute(sql);

            MainForm.ds.Tables["Места"].Rows.RemoveAt(n);

            if (MainForm.ds.Tables["Места"].Rows.Count > n)
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
