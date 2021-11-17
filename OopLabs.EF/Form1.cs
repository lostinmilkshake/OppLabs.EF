using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OopLabs.EF
{
    public partial class Form1 : Form
    {
        private readonly AdventureWorksEntities _entities = new AdventureWorksEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CategoryComboBox.DataSource = _entities.ProductSubcategories.Where(ps => ps.Products.Any()).ToList();
            CategoryComboBox.ValueMember = "Name";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void UpdateProductList(object sender, EventArgs e)
        {
            var category = (ProductSubcategory)CategoryComboBox.SelectedItem;
            var products = category.Products;

            ProductGridView.DataSource = products.ToList();
        }
    }
}
