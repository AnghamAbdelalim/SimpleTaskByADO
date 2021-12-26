using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    public class DataHelper
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
       
        public DataHelper()
        {
            sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks;Integrated Security=True");
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }
        public DataTable getData()
        {
            sqlCommand.CommandText = "select* from Production.ProductCategory";
            SqlDataAdapter SqlDataAdapter= new SqlDataAdapter(sqlCommand);
            DataTable dataTable= new DataTable();
            SqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable getProduct(int id)
        {
            sqlCommand.CommandText = "select*from Production.Product where ProductSubcategoryID="+id;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            SqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable getProductbyID(int id)
        {
            sqlCommand.CommandText = "select*from Production.Product where ProductID=" + id;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            SqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void DeleteProductByID(int id)
        {
            sqlCommand.CommandText = "delete from Production.Product where ProductID=" + id;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(sqlCommand);
           
            
        }
        public void UpdateProductDetailesbyID(int id,DataTable dataTable)
        {
            sqlCommand.CommandText = "update Production.Product where ProductID="+id;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(sqlCommand);
            SqlDataAdapter.TableMappings.Add(dataTable);


        }
    }
}
