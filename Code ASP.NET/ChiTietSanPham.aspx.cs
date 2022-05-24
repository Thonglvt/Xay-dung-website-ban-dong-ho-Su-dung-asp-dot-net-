using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using App_Code;

public partial class ChiTietSanPham : System.Web.UI.Page
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
            if (Request.QueryString["ID_SP"] != null)
            {
                string bMaLoai = Request.QueryString["ID_SP"].ToString();
                napChiTietSanPham(bMaLoai);
                napHinhAnh(bMaLoai);
                string thuongHieu = Request.QueryString["thuongHieu"].ToString();
                napSPLienQuan(bMaLoai,thuongHieu);     
            }
        }
        
        cn.Close();

        
    }

    void napChiTietSanPham(string maLoai)
    {
        lenh.CommandText = "select* from SANPHAM,CT_SANPHAM,NSX,THUONGHIEU where SANPHAM.ID_SP=CT_SANPHAM.ID_SP and CT_SANPHAM.maNSX=NSX.maNSX and CT_SANPHAM.maTH=THUONGHIEU.maTH and  SANPHAM.ID_SP = @maLoai";
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@maLoai", maLoai);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        dl_ChiTiet.DataSource = dt;
        dl_ChiTiet.DataBind();

        dl_DatHang.DataSource = dt;
        dl_DatHang.DataBind();
    }
    void napHinhAnh(string ma)
    {
        lenh.CommandText = "select* from detailImage where ID_SP = @ma";
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        dl_HinhAnh.DataSource = dt;
        dl_HinhAnh.DataBind();

        //dgv_Img.DataSource = dt;
        //dgv_Img.DataBind();

    }
    void napSPLienQuan(string ma, string thuongHieu)
    {
        lenh.CommandText = "select* from SANPHAM,CT_SANPHAM,THUONGHIEU where SANPHAM.ID_SP=CT_SANPHAM.ID_SP and CT_SANPHAM.maTH=THUONGHIEU.maTH and tenTH = @th and SANPHAM.ID_SP != @ma";
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@th", thuongHieu);
        lenh.Parameters.AddWithValue("@ma", ma);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        dl_sanPhamLienQuan.DataSource = dt;
        dl_sanPhamLienQuan.DataBind();
    }

    protected void btn_themVaoGio_Click(object sender, EventArgs e)
    {
        Response.Redirect("GioHang.aspx?id=" + Request.QueryString["ID_SP"].ToString());
    }
    
    protected void imgBtn_Image_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
}