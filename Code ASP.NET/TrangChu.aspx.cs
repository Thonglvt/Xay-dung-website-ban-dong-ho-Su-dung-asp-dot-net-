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

public partial class TrangChu : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    static PagedDataSource p = new PagedDataSource();
    public static int trangThu = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        cn.Open();
        lenh.Connection = cn;
        lenh.CommandType = CommandType.Text;
        if (!IsPostBack)
        {
            napDuLieu();
        }
        
        cn.Close();
        //if (Session["cart"] == null)
        //{
        //    XayDungDH cart = new XayDungDH();
        //    cart.createItem();
        //    Session["cart"] = cart;
        //}
    }
    void napDuLieu()
    {
        //string sql = "Select* from SANPHAM";

        lenh.CommandText = "select SANPHAM.ID_SP,NAME_SP,IMAGE_SP,RETAIL_PRICE,tenTH  from SANPHAM,CT_SANPHAM,THUONGHIEU where SANPHAM.ID_SP=CT_SANPHAM.ID_SP and CT_SANPHAM.maTH=THUONGHIEU.maTH order by RETAIL_PRICE DESC";
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        p.DataSource = dt.DefaultView;
        p.PageSize = 12;//sản phẩm tối đa trên 1 trang
        p.CurrentPageIndex = trangThu;//Trang hiện tại
        p.AllowPaging = true;

        btn_dau.Enabled = true;
        btn_truoc.Enabled = true;
        btn_sau.Enabled = true;
        btn_cuoi.Enabled = true;


        if (p.IsFirstPage == true)//neu la dau.
        {

            btn_dau.Enabled = false;//neu la trang dau thi hai nut mo di.
            btn_truoc.Enabled = false;
            btn_sau.Enabled = true;//Hai nut sau sang len.
            btn_cuoi.Enabled = true;
        }
        if (p.IsLastPage == true)//neu la cuoi
        {
            btn_dau.Enabled = true;
            btn_truoc.Enabled = true;
            btn_sau.Enabled = false;
            btn_cuoi.Enabled = false;
        }

        lb_trangHienTai.Text = (trangThu + 1) + " / " + p.PageCount;
        dl_chinh.DataSource = p;
        dl_chinh.DataBind();

        //lenh.CommandText = "Select* from SANPHAM";
        //lenh.Parameters.Clear();
        //DataTable dt = new DataTable();
        //da.SelectCommand = lenh;
        //da.Fill(dt);
        dl_chinh.DataSource = p;
        dl_chinh.DataBind();
    }

    protected void btn_dau_Click(object sender, EventArgs e)
    {
        trangThu = 0;
        napDuLieu();
    }
    protected void btn_truoc_Click(object sender, EventArgs e)
    {
        trangThu--;
        napDuLieu();
    }
    protected void btn_sau_Click(object sender, EventArgs e)
    {
        trangThu++;
        napDuLieu();
    }
    protected void btn_cuoi_Click(object sender, EventArgs e)
    {
        trangThu = p.PageCount - 1;
        napDuLieu();
    }
}