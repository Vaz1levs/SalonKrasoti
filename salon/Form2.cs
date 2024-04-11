using System;
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
    public partial class Form2 : Form
    {
        Model1 db = new Model1();
        private Form1 _form1;
        public Form2(Form1 form1)
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
            Form2Edit form = new Form2Edit();
            form.db = db;
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                productBindingSource.DataSource = db.Product.ToList();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Product prod = (Product)productBindingSource.Current;
            DialogResult dr = MessageBox.Show(
                "Вы действительно хотите удалить номер - " + prod.ID.ToString(),
                "Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Product.Remove(prod);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                productBindingSource.DataSource = db.Product.ToList();
            }
        }
    }
}
