using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using App_Code;
public partial class Nu : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.Open();
        lenh.Connection = cn;
        lenh.CommandType = CommandType.Text;
        if (!IsPostBack)
        {
            if (Request.QueryString["gender"] != null)
            {
                string gt = Request.QueryString["gender"].ToString();
                napDuLieu(gt);
            }
        }

        cn.Close();
        
    }
    void napDuLieu(string gt)
    {
        lenh.CommandText = "Select* from SANPHAM,CT_SANPHAM,THUONGHIEU where SANPHAM.ID_SP=CT_SANPHAM.ID_SP and THUONGHIEU.maTH=CT_SANPHAM.maTH and Gender = @gender";
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@gender", gt);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        dl_Nu.DataSource = dt;
        dl_Nu.DataBind();
    }
}