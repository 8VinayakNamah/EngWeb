using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DataAccessLayer;
using Database;
using ActiveDirectory;
using System.Data.SqlClient;
using System.Configuration;
using PhononicEngWeb.Lib;

namespace PhononicEngWeb
{
    public partial class _Default : CustomPage
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
           

            //AdService.IsInGroup("Administrator");

            SqlDatabase.ConnectionKey = "MSSql";

            //string connstring = ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString;
            //string env = ConfigurationManager.AppSettings.Get("environment").ToString();

            var dtbooks = SqlDatabase.ExecuteDataset("select * from dbo.books", QueryType.Text);
            GridView1.DataSource = dtbooks;
            GridView1.DataBind();

            //SqlDatabase.ConnectionKey = "MSSql";


            //List<SqlParameter> param= new List<SqlParameter>();
            //param.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) {
            //    Direction=System.Data.ParameterDirection.Input,
            //    Value=1
            //});

            //param.Add(new SqlParameter("@name", System.Data.SqlDbType.Int)
            //{
            //    Direction = System.Data.ParameterDirection.Input,
            //    Value = "asdasd"
            //});

            var dtProducts = SqlDatabase.ExecuteDataset("select * from RedProducts", QueryType.Text);
            GridView2.DataSource = dtProducts;
            GridView2.DataBind();
        }
    }
}