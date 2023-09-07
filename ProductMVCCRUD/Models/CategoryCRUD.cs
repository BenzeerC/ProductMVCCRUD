using System.Data.SqlClient;
namespace ProductMVCCRUD.Models
{
    public class CategoryCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CategoryCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            string qry = "select * from CategoryMVC";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.cId = Convert.ToInt32(dr["cid"]);
                    c.cName= dr["cname"].ToString();

                    list.Add(c);


                }
            }
            con.Close();
            return list;
        }

        public Category GetCategoryById(int id)
        {
            Category c = new Category();
            string qry = "select * from CategoryMVC where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    c.cId = Convert.ToInt32(dr["cid"]);
                    c.cName = dr["cname"].ToString();

                }
            }
            con.Close();
            return c;
        }

        public int AddCategory(Category category)
        {

            int result = 0;
            string qry = "insert into CategoryMVC values(@cname)";
            cmd = new SqlCommand(qry, con);
            //cmd.Parameters.AddWithValue("@depid", department.DepId);
            cmd.Parameters.AddWithValue("@cname", category.cName);

            con.Open();

            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }

        public int UpdateCategory(Category category)
        {

            int result = 0;
            string qry = "update CategoryMVC set cname=@name where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cname",category.cName);

            cmd.Parameters.AddWithValue("@cid", category.cId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        // soft delete --> record should be present in DB , but should not visible on the form
        public int DeleteCategory(int id)
        {
            int result = 0;
            string qry = "Delete from CategoryMVC where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
