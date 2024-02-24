namespace RealEstateAgency
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.объектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.участникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мероприятияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходныеДокументыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаявокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(866, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Linen;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(858, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Работа с базой данных";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(706, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(640, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Здравствуйте, Администратор";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.объектыToolStripMenuItem,
            this.выходныеДокументыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // объектыToolStripMenuItem
            // 
            this.объектыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.участникиToolStripMenuItem,
            this.организаторыToolStripMenuItem,
            this.мероприятияToolStripMenuItem,
            this.темыToolStripMenuItem,
            this.местаToolStripMenuItem});
            this.объектыToolStripMenuItem.Name = "объектыToolStripMenuItem";
            this.объектыToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.объектыToolStripMenuItem.Text = "Объекты";
            // 
            // участникиToolStripMenuItem
            // 
            this.участникиToolStripMenuItem.Name = "участникиToolStripMenuItem";
            this.участникиToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.участникиToolStripMenuItem.Text = "Участники";
            this.участникиToolStripMenuItem.Click += new System.EventHandler(this.участникиToolStripMenuItem_Click);
            // 
            // организаторыToolStripMenuItem
            // 
            this.организаторыToolStripMenuItem.Name = "организаторыToolStripMenuItem";
            this.организаторыToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.организаторыToolStripMenuItem.Text = "Организаторы";
            this.организаторыToolStripMenuItem.Click += new System.EventHandler(this.организаторыToolStripMenuItem_Click);
            // 
            // мероприятияToolStripMenuItem
            // 
            this.мероприятияToolStripMenuItem.Name = "мероприятияToolStripMenuItem";
            this.мероприятияToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.мероприятияToolStripMenuItem.Text = "Мероприятия";
            this.мероприятияToolStripMenuItem.Click += new System.EventHandler(this.мероприятияToolStripMenuItem_Click);
            // 
            // темыToolStripMenuItem
            // 
            this.темыToolStripMenuItem.Name = "темыToolStripMenuItem";
            this.темыToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.темыToolStripMenuItem.Text = "Темы";
            this.темыToolStripMenuItem.Click += new System.EventHandler(this.темыToolStripMenuItem_Click);
            // 
            // местаToolStripMenuItem
            // 
            this.местаToolStripMenuItem.Name = "местаToolStripMenuItem";
            this.местаToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.местаToolStripMenuItem.Text = "Места проведения";
            this.местаToolStripMenuItem.Click += new System.EventHandler(this.местаToolStripMenuItem_Click);
            // 
            // выходныеДокументыToolStripMenuItem
            // 
            this.выходныеДокументыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокЗаявокToolStripMenuItem});
            this.выходныеДокументыToolStripMenuItem.Name = "выходныеДокументыToolStripMenuItem";
            this.выходныеДокументыToolStripMenuItem.Size = new System.Drawing.Size(148, 21);
            this.выходныеДокументыToolStripMenuItem.Text = "Выходные документы";
            // 
            // списокЗаявокToolStripMenuItem
            // 
            this.списокЗаявокToolStripMenuItem.Name = "списокЗаявокToolStripMenuItem";
            this.списокЗаявокToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.списокЗаявокToolStripMenuItem.Text = "Журнал заявок";
            this.списокЗаявокToolStripMenuItem.Click += new System.EventHandler(this.журналЗаявокToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 517);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "Меню";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem объектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem участникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мероприятияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходныеДокументыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаявокToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}