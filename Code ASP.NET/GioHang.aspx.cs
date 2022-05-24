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

public partial class GioHang : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();

    int donGia = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
            //int id = int.Parse(Session["id"].ToString());
        hypl_trangChu.Visible = false;
        if (!IsPostBack)
        {
            insertGioHang();
            hienThiGioHang();
        }

        
    }
   
    void insertGioHang()
    {
        cn.Open();
        if (Request.QueryString["id"] != null)
        {
            
            string id = Request.QueryString["id"].ToString();//Lấy id truyền từ trang SanPham.aspx qua
            string sql = "Select* from SANPHAM where ID_SP = '" + id + "'";
            da = new SqlDataAdapter(sql, cn);

            DataTable d = new DataTable();
            da.Fill(d);
            if (d.Rows.Count > 0)
            {
                string ten = d.Rows[0][1].ToString();
                string hinh = d.Rows[0][2].ToString();
                donGia = int.Parse(d.Rows[0][3].ToString());
                int soLuong = 1;
                XayDungDH cart = new XayDungDH();
                cart = (XayDungDH)Session["cart"];
                cart.insertSP(id, hinh, ten, donGia, soLuong);
                Session["cart"] = cart;
            }
        }
        cn.Close();
    }
    //Hien thi len grdwiew
    void hienThiGioHang()
    {
        if (Session["cart"] != null)
        {
            XayDungDH cart1 = new XayDungDH();
            cart1 = (XayDungDH)Session["cart"];
            DataTable d2 = cart1.gioHang;
            gv_gioHang.DataSource = d2;
            gv_gioHang.DataBind();
            lb_tongThanhTien.Text = string.Format("{0:0,0}", cart1.tinhTongTien());
            if (cart1.gioHang.Rows.Count <= 0)
            {
                lb_tbXoa.Text = "Giỏ hàng trống!";
            }
        }
           
    }
    protected void btnXoaSPGH_Click1(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string ma = gv_gioHang.Rows[row_chon].Cells[0].Text;

        lb_tbXoa.Text = "Đã xóa " + ma;
        XayDungDH cart = new XayDungDH();
        cart = (XayDungDH)Session["cart"];
        bool kt = cart.delete(ma);
        Session["cart"] = cart;
        if (kt == true)
            lb_tbXoa.Text = "Đã loại bỏ sản phẩm này ra khỏi giỏ hàng";
        else
            lb_tbXoa.Text = "No!!";
        hienThiGioHang();
    }
    protected void btnTangSoLuong_Click(object sender, EventArgs e)
    {
        lb_tbXoa.Text = "";
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;//lấy dòng số row_chon trong gridView

        string ma = gv_gioHang.Rows[row_chon].Cells[0].Text;
        XayDungDH cart = new XayDungDH();
        cart = (XayDungDH)Session["cart"];
        foreach (DataRow dr in cart.gioHang.Rows)
        {
            if (dr[0].ToString().Equals(ma))
            {
                dr[4] = int.Parse(dr[4].ToString()) + 1;
                break;
            }
        }
        Session["cart"] = cart;//lưu lại sesson m copy 2 cái này bỏ qua m đi roi t sửa
        hienThiGioHang();
        lb_tongThanhTien.Text = string.Format("{0:0,0}", cart.tinhTongTien());

    }
    protected void btnGiamSoLuong_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;//lấy dòng số row_chon trong gridView

        string ma = gv_gioHang.Rows[row_chon].Cells[0].Text;
        int sl0 = int.Parse(gv_gioHang.Rows[row_chon].Cells[4].Text);
        if (sl0 == 0)
        {
            lb_tbXoa.Text = "Số lượng bằng 0, không thể giảm";
        }
        else//Cập nhật lại giỏ hàng
        {
            XayDungDH cart = new XayDungDH();
            cart = (XayDungDH)Session["cart"];
            foreach (DataRow dr in cart.gioHang.Rows)
            {
                if (dr[0].ToString().Equals(ma))
                {
                    dr[4] = int.Parse(dr[4].ToString()) - 1;
                    break;
                }
            }
            Session["cart"] = cart;//lưu lại sesson
            hienThiGioHang();
            lb_tongThanhTien.Text = string.Format("{0:0,0}", cart.tinhTongTien());
        }
    }
    protected void btn_thanhToan_Click(object sender, EventArgs e)
    {
        if (lb_tbXoa.Text.Equals("Giỏ hàng trống!") || lb_tongThanhTien.Text.Equals("00"))
        {
            lb_tbEmpty.Text = "Bạn chưa có sản phẩm!";
            hypl_trangChu.Visible = true;
            hypl_trangChu.Focus();
        }
        else
            Response.Redirect("ThanhToan.aspx");
    }
}