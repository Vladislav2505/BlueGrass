using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RealEstateAgency
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection connection =
            new NpgsqlConnection("Server=127.0.0.1;User Id=postgres; Password=123123;Database=blue_grass");

        public static DataSet ds = new DataSet();
        public static TabControl tabControl1 = new TabControl();
        public static DataSet nextValue = new DataSet();

        public static void TableFill(string name, string sql)
        {
            if (ds.Tables[name] != null)
                ds.Tables[name]?.Clear();
            NpgsqlDataAdapter dat;
            dat = new NpgsqlDataAdapter(sql, connection);
            dat.Fill(ds, name);
            connection.Close();
        }

        public static bool ModificationExecute(string sql)
        {
            NpgsqlCommand com;
            com = new NpgsqlCommand(sql, connection);
            connection.Open();
            //try
            //{
                com.ExecuteNonQuery();
            //}
            //catch (NpgsqlException у)
            //{
            //    MessageBox.Show("Обновление базы данных не было выполнено из-за не указания обновляемых данных, " +
            //        "несоответствия их типов или невозможности их удаления!!!", "Ошибка");
            //    connection.Close();
            //    return false;
            //}
    connection.Close();
            return true;
        }

        public static string GetNextVal(string name, string sql)
        {
            if (nextValue.Tables[name] != null)
                nextValue.Tables[name]?.Clear();

            NpgsqlDataAdapter dat;
            dat = new NpgsqlDataAdapter(sql, connection);
            dat.Fill(nextValue, name);
            connection.Close();

            return nextValue.Tables[name].Rows[0][name].ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(866, 500);
            this.Controls.Add(tabControl1);

            Authorization authorization = new Authorization();
            tabControl1.Controls.Add(authorization.tabControl1.TabPages[0]);
        }
    }
}
