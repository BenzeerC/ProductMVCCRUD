using System.Data.SqlClient;
namespace ProductMVCCRUD.Models
{
    public class ProductCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public ProductCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con= new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string qry = "select pro.*, cat.cname from ProductMVC pro inner join" +
                " CategoryMVC cat on cat.cid = pro.cid";

            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.Id= Convert.ToInt32(dr["pid"]);
                    pro.Name = dr["pname"].ToString();
                    pro.price = Convert.ToInt32(dr["price"]);
                    pro.Imageurl = dr["imageurl"].ToString();
                    pro.cId = Convert.ToInt32(dr["cid"]);
                    pro.cName = dr["cname"].ToString();
                    list.Add(pro);



                }
            }
            con.Close();
            return list;
        }

        public Product GetProductById(int id)
        {
            Product pro = new Product();
            string qry = "select pro.*, cat.cname from ProductMVC pro inner join" +
                " CategoryMVC cat on cat.cid = pro.cid where pro.pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pro.Id = Convert.ToInt32(dr["pid"]);
                    pro.Name = dr["pname"].ToString();
                    pro.price = Convert.ToInt32(dr["price"]);
                    pro.Imageurl = dr["imageurl"].ToString();
                    pro.cId = Convert.ToInt32(dr["cid"]);
                    pro.cName = dr["cname"].ToString();
                }
            }
            con.Close();
            return pro;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            string qry = "insert into ProductMVC values(@pname,@price,@imageurl,@cid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pname", product.Name);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@imageurl", product.Imageurl);
            cmd.Parameters.AddWithValue("@cid", product.cId);
            //cmd.Parameters.AddWithValue("@cname",product.cName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product product)
        {
            int result = 0;
            string qry = "update ProductMVC set pname=@pname,price=@price,imageurl=@imageurl," +
                "cid=@cid where pid=@pid";
            cmd.Parameters.AddWithValue("@pname", product.Name);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@imageurl", product.Imageurl);
            cmd.Parameters.AddWithValue("@cid", product.cId);
            cmd.Parameters.AddWithValue("@pid", product.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from ProductMVC where pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }







    }
}
