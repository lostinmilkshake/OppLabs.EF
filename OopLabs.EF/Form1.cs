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
            CategoryComboBox.DataSource = _entities.ProductCategories.Where(pc => pc.ProductSubcategories.Any()).ToList();
            CategoryComboBox.ValueMember = "Name";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void UpdateProductList(object sender, EventArgs e)
        {
            var category = (ProductCategory)CategoryComboBox.SelectedItem;
            var products = category.ProductSubcategories.SelectMany(ps => ps.Products).Where(p => p.Name.Contains(textBox1.Text));

            ProductGridView.DataSource = products.ToList();
        }
    }
}
