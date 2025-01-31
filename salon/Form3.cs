﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using salon.ModelEF;

namespace salon
{
    public partial class Form3 : Form
    {
        Model1 db = new Model1();
        private Form1 _form1;
        public Form3(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3Edit form = new Form3Edit();
            form.db = db;
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                manufacturerBindingSource.DataSource = db.Manufacturer.ToList();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Manufacturer mnf = (Manufacturer)manufacturerBindingSource.Current;
            DialogResult dr = MessageBox.Show(
                "Вы действительно хотите удалить номер - " + mnf.ID.ToString(),
                "Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Manufacturer.Remove(mnf);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                manufacturerBindingSource.DataSource = db.Manufacturer.ToList();
            }
        }
    }
}
