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

public partial class Search : System.Web.UI.Page
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
            if (Request.QueryString["search"] != null)
            {
                string tim = Request.QueryString["search"].ToString();
                napDuLieu(tim);
            }
        }
        if (Session["cart"] == null)
        {
            XayDungDH cart = new XayDungDH();
            cart.createItem();
            Session["cart"] = cart;
        }
        cn.Close();
    }
    void napDuLieu(string tim)
    {
        lenh.CommandText = "Select* from SANPHAM,CT_SANPHAM,THUONGHIEU where SANPHAM.ID_SP=CT_SANPHAM.ID_SP and THUONGHIEU.maTH=CT_SANPHAM.maTH and NAME_SP like '%'+@tim+'%'";
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tim", tim);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        dl_Search.DataSource = dt;
        dl_Search.DataBind();
    }       
}