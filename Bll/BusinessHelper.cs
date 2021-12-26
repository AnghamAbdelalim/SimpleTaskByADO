using Dll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class BusinessHelper
    {
        DataHelper DataHelper;
        public BusinessHelper()
        {
            DataHelper = new DataHelper();
        }
        public List<Category>GetCategory
        {
            get
            {
                DataTable dataTable = DataHelper.getData();
                List<Category>categories = new List<Category>();
                foreach (DataRow item in dataTable.Rows)
                {
                    categories.Add(new Category
                    {
                        catID = (int)item["ProductCategoryID"],
                        catName = item["Name"].ToString(),
                    });
                }
                return categories;
            }
        }
        public List<Product>GetProduct(int id)
        {
            DataTable dataTable = DataHelper.getProduct(id);
            List<Product> products = new List<Product>();
            foreach (DataRow item in dataTable.Rows)
            {

                products.Add(new Product
                {
                    ID = (int)item["ProductID"],
                    Name = item["Name"].ToString(),
                });
                
            }
            return products;
        }
        public Product GetProductDetailes(int id)
        {
            DataTable dataTable = DataHelper.getProductbyID(id);
            Product products = new Product();
            foreach (DataRow item in dataTable.Rows)
            {

                products.ID = (int)item["ProductID"];
                products.Name = item["Name"].ToString();
                products.ReorderPoint = (Int16)item["ReorderPoint"];
                products.Class = item["Class"].ToString();
            }
            return products;
        }
        public void DeleteProduct(int id)
        {
            DataHelper.DeleteProductByID(id);
        }
       public void UpdateProductDetailes(int id,Product product)
        {
            DataTable dataTable =new DataTable();
            foreach (DataRow item in dataTable.Rows)
            {
                 item["Name"]= product.Name;
                 item["ReorderPoint"]= product.ReorderPoint;
                item["Class"]= product.Class;
            }
           DataHelper.UpdateProductDetailesbyID(id,dataTable);
        }
    }
}
