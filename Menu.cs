using RealEstateAgency.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateAgency
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void участникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }

        private void организаторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgentForm form = new AgentForm();
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }

        private void мероприятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApartmentForm form = new ApartmentForm();
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }

        private void темыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemesForm form = new ThemesForm();
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }

        private void местаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorForm form = new VendorForm();
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (MainForm.tabControl1.TabCount > 0)
            {
                MainForm.tabControl1.TabPages.RemoveAt(MainForm.tabControl1.TabCount - 1);
            }
            Authorization authorization = new Authorization();
            MainForm.tabControl1.Controls.Add(authorization.tabControl1.TabPages[0]);
        }

        private void журналЗаявокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersList form = new OrdersList();
            MainForm.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            MainForm.tabControl1.SelectedIndex = MainForm.tabControl1.TabCount - 1;
        }
    }
}
