using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BusinessHelper businessHelper;
        public Form1()
        {
            InitializeComponent();
            businessHelper = new BusinessHelper();
            loadData();
;        }
        private void loadData()
        {
            comboBox1.DataSource = businessHelper.GetCategory;
            comboBox1.ValueMember =nameof(Category.catID);
            comboBox1.DisplayMember =nameof(Category.catName);
            comboBox1.SelectedIndex = -1;
        }
        private void displayData(IEnumerable<Product>products)
        {
            listView1.Items.Clear();
            foreach(Product product in products)
            {
                ListViewItem item = new ListViewItem(product.ID.ToString());
                item.SubItems.Add(product.Name);
                listView1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                listView1.Items.Clear();
                return;
            }
            Category category =(Category)comboBox1.SelectedItem;
            //int id=(int)comboBox1.SelectedValue;
            List<Product> products = businessHelper.GetProduct(category.catID);
            //displayData(businessHelper.GetProduct(category.catID));
            displayData(products);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (listView1.SelectedItems.Count == 0)
                return;
            int id=listView1.SelectedIndices[0];
            Product products = businessHelper.GetProductDetailes(id);
            textBox1.Text =products.Name;
            textBox2.Text =products.ReorderPoint.ToString();
            textBox3.Text =products.Class;
            //DisplayDetails(products);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            int id = listView1.SelectedIndices[0];
            Product products = new Product();
            products.Name = textBox1.Text;
            products.ReorderPoint=Int16.Parse(textBox2.Text);
            products.Class= textBox3.Text;
            businessHelper.UpdateProductDetailes(id,products);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id = listView1.SelectedIndices[0];
            listView1.SelectedItems[0].Remove();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            businessHelper.DeleteProduct(id);
            
        }
       
    }
}
