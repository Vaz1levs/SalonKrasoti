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
    public partial class Form2Edit : Form
    {
        public Model1 db { get; set; }
        public Form2Edit()
        {
            InitializeComponent();
        }
        private void Form2Edit_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show("Нужно ввести все требуемые данные!");
                return;
            }
            int id;
            bool b = int.TryParse(textBox1.Text, out id);
            if (b == false)
            {
                MessageBox.Show("Неверный формат ID - " + textBox1.Text);
                return;
            }
            decimal eg;
            bool x = decimal.TryParse(textBox5.Text, out eg);
            if (x == false)
            {
                MessageBox.Show("Неверно введена цена - " + textBox5.Text);
                return;
            }
            Product prod = new Product();
            prod.ID = id;
            prod.Title = textBox2.Text;
            prod.Cost = eg;
            db.Product.Add(prod);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
