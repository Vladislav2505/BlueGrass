using RealEstateAgency.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RealEstateAgency
{
    public partial class OrdersList : Form
    {
        public OrdersList()
        {
            InitializeComponent();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MainForm.ds.Tables["Заявки"].DefaultView;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int code;

            try
            {
                code = dataGridView1.CurrentCell.RowIndex;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не указан удаляемый экземпляр!!!", "Ошибка"); return;
            }

            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            worksheet.Cells[1, 1].Value = "Заявка";
            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]].Merge();
            worksheet.Cells[1, 1].HorizontalAlignment = 3;

            worksheet.Cells[2, 1].Value = dataGridView1.Columns["Номер заявки"].HeaderText;
            worksheet.Cells[2, 2].Value = dataGridView1.Columns["Участник"].HeaderText;
            worksheet.Cells[2, 3].Value = dataGridView1.Columns["Название мероприятия"].HeaderText;
            worksheet.Cells[2, 4].Value = dataGridView1.Columns["Дата отправки"].HeaderText;
            worksheet.Cells[2, 5].Value = dataGridView1.Columns["Статус заявки"].HeaderText;

            worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 6]].HorizontalAlignment = 3;

            worksheet.Cells[3, 1].Value = dataGridView1.Rows[code].Cells["Номер заявки"].Value;
            worksheet.Cells[3, 2].Value = dataGridView1.Rows[code].Cells["Участник"].Value;
            worksheet.Cells[3, 3].Value = dataGridView1.Rows[code].Cells["Название мероприятия"].Value;
            worksheet.Cells[3, 4].Value = dataGridView1.Rows[code].Cells["Дата отправки"].Value;
            worksheet.Cells[3, 5].Value = dataGridView1.Rows[code].Cells["Статус заявки"].Value;

            worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[3, 5]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Cells.Columns.EntireColumn.AutoFit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string code;

            try
            {
                code = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Номер заявки"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не указан удаляемый экземпляр!!!", "Ошибка"); return;
            }

            string message = "Вы точно хотите удалить заявку № " + code + "?";
            string caption = "Удаление заявки";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                return;
            }

            string sql = "DELETE FROM applications WHERE id=" + code;
            MainForm.ModificationExecute(sql);

            for (int i = MainForm.ds.Tables["Заявки"].Rows.Count - 1; i >= 0; i--)
            {
                if (MainForm.ds.Tables["Заявки"].Rows[i]["Номер заявки"].ToString() == code)
                {
                    MainForm.ds.Tables["Заявки"].Rows.RemoveAt(i);
                    dataGridView1.CurrentCell = null;
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить информацию обо всех заявках?";
            string caption = "Очистка журнала";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                return;
            }

            string sql = "DELETE FROM applications";
            MainForm.ModificationExecute(sql);
            MainForm.ds.Tables["Заявки"].Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.tabControl1.Controls.Remove(MainForm.tabControl1.SelectedTab);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderForm.n = dataGridView1.CurrentRow.Index;
            OrderForm form = new OrderForm();

            if (MainForm.tabControl1.TabCount > 2)
            {
                MainForm.tabControl1.TabPages.RemoveAt(MainForm.tabControl1.TabCount - 1);
            }
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }
    }
}
