using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class KhachHang : System.Web.UI.Page
{
    public static string id;
    public static string maHD;
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = null;
    SqlDataAdapter da = new SqlDataAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack )
        {
            txt_pass.Visible = false;
            txt_confirm.Visible = false;
            lb_confirm.Visible = false;
            lb_pass.Visible = false;
            btn_capNhat.Visible = true;
            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
            btn_OkPass.Visible = false;
            txt_tenKH.Enabled = false;
            rbl_gioiTinh.Enabled = false;
            txt_Email.Enabled = false;
            txt_DienThoai.Enabled = false;
            txt_DiaChi.Enabled = false;
            layThongTinKH();
        }
        
    }
    void layThongTinKH()
    {
        if ( Session["login"] != null)
        {
            
            HamXuLy hxl = (HamXuLy)Session["login"];
            KhachHang.id = hxl.MaKH;
            lb_ID.Text = hxl.MaKH;
            txt_tenKH.Text = hxl.TenKH;
            lb_UsernameKH.Text = hxl.Username;
            txt_pass.Text = hxl.PassWord;
            if (hxl.GioiTinh.Equals("Nam"))
                rbl_gioiTinh.SelectedIndex = 0;
            else
                rbl_gioiTinh.SelectedIndex = 1;
            txt_Email.Text = hxl.Email;
            txt_DienThoai.Text = hxl.DienThoai;
            txt_DiaChi.Text = hxl.DiaChi;
        }
    }
    protected void btn_capNhat_Click(object sender, EventArgs e)
    {
        btn_Luu.Visible = true;
        btn_Huy.Visible = true;
        btn_capNhat.Visible = false;
        btn_doiPass.Visible = false;
        //lb_confirm.Visible = true;
        //txt_confirm.Visible = true;

        txt_tenKH.Enabled = true;
        lb_pass.Visible = false;
        txt_pass.Visible = false;
        rbl_gioiTinh.Enabled = true;
        txt_Email.Enabled = true;
        txt_DienThoai.Enabled = true;
        txt_DiaChi.Enabled = true;


    }
    protected void btn_Luu_Click(object sender, EventArgs e)
    {
        if(txt_tenKH.Text.ToString().Equals(""))
        {
            txt_tenKH.Attributes.Add("placeholder", "Không được để trống");
            txt_tenKH.Focus();
        }
        //else if (txt_pass.Text.ToString().Equals(""))
        //{
        //    lb_tb.Text = "password không được để trống";
        //    txt_pass.Focus();
        //}
        else if (txt_Email.Text.ToString().Equals(""))
        {
            txt_Email.Attributes.Add("placeholder", "Không được để trống");
            txt_Email.Focus();
        }
        else if (txt_DienThoai.Text.ToString().Equals(""))
        {
            txt_DienThoai.Attributes.Add("placeholder", "Không được để trống");
            txt_DienThoai.Focus();
        }
        else if (txt_DiaChi.Text.ToString().Equals(""))
        {
            txt_DiaChi.Attributes.Add("placeholder", "Không được để trống");
            txt_DiaChi.Focus();
        }
        //else if (txt_confirm.Text.ToString() != txt_pass.Text.ToString())
        //{
        //    lb_tb.Text = "Nhập lại mật khẩu không đúng";
        //    txt_confirm.Focus();
        //}
        else
        {

            string gioiTinh = "";
            if (rbl_gioiTinh.SelectedIndex == 0)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";
            HamXuLy hxl = new HamXuLy(KhachHang.id, txt_tenKH.Text, lb_UsernameKH.Text, txt_pass.Text, gioiTinh, txt_Email.Text, txt_DienThoai.Text, txt_DiaChi.Text);
            hxl.KtraDangNhap = true;
            Session["login"] = hxl;
            cn.Open();
            string kh = "UPDATE KHACHHANG set HOTEN = @HT,GIOITINH= @GT,EMAIL= @EM,PHONE= @P,DIACHI= @DC where ID = @ID";
            lenh = new SqlCommand(kh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@HT", txt_tenKH.Text);
            //.Parameters.AddWithValue("@PW", txt_pass.Text);
            lenh.Parameters.AddWithValue("@GT", gioiTinh);
            lenh.Parameters.AddWithValue("@EM", txt_Email.Text);
            lenh.Parameters.AddWithValue("@P", txt_DienThoai.Text);
            lenh.Parameters.AddWithValue("@DC", txt_DiaChi.Text);
            lenh.Parameters.AddWithValue("@ID", lb_ID.Text);
            

            lenh.ExecuteNonQuery();
            cn.Close();


            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
            btn_capNhat.Visible = true;
            txt_tenKH.Enabled = false;
            btn_doiPass.Visible = true;

            rbl_gioiTinh.Enabled = false;
            txt_Email.Enabled = false;
            txt_DienThoai.Enabled = false;
            txt_DiaChi.Enabled = false;
            txt_confirm.Visible = false;
            lb_confirm.Visible = false;
            lb_tb.Text = "Cập nhật thông tin thành công.";
            
        }
        
        
    }
    protected void btn_Huy_Click(object sender, EventArgs e)
    {
        btn_Luu.Visible = false;
        btn_capNhat.Visible = true;
        btn_Huy.Visible = false;
        btn_doiPass.Visible = true;
        btn_OkPass.Visible = false;
        txt_tenKH.Enabled = false;
        txt_pass.Visible = false;
        rbl_gioiTinh.Enabled = false;
        txt_Email.Enabled = false;
        txt_DienThoai.Enabled = false;
        txt_DiaChi.Enabled = false;
        txt_confirm.Visible = false;
        lb_confirm.Visible = false;
        lb_pass.Visible = false;
        lb_tb.Text = "";

    }
    protected void btn_doiPass_Click(object sender, EventArgs e)
    {
        //if (txt_pass.Text.Equals(""))
        //{
        //    txt_pass.Attributes.Add("placeholer", "Không được để trống");
        //    txt_pass.Focus();
        //}
        //else if (txt_confirm.Text.Equals(""))
        //{
        //    txt_confirm.Attributes.Add("placeholer", "Không được để trống");
        //    txt_confirm.Focus();
        //}
        txt_pass.Visible = true;
        txt_confirm.Visible = true;
        lb_confirm.Visible = true;
        lb_pass.Visible = true;
        btn_OkPass.Visible = true;
        btn_doiPass.Visible = false;
        btn_Huy.Visible = true;
        //btn_doiPass.Text = "OK";
    }
    protected void btn_OkPass_Click(object sender, EventArgs e)
    {
        string ma = KhachHang.id;
        if (txt_pass.Text.ToString().Equals(""))
        {
            lb_tb.Attributes.Add("placeholder", "Bạn chưa nhập pass mới");
            lb_tb.Text = "Pass mới không đươc để trống";
            txt_pass.Focus();
        }
        else if (txt_confirm.Text.ToString().Equals(""))
        {
            txt_confirm.Attributes.Add("placeholder", "Bạn chưa nhập pass mới");
            lb_tb.Text = "Pass mới không đươc để trống";
            txt_confirm.Focus();
        }
        else if (txt_confirm.Text.ToString() != txt_pass.Text.ToString())
        {
            lb_tb.Text = "Nhập lại mật khẩu không đúng";
            txt_confirm.Focus();
        }
        else
        {
            string gioiTinh = "";
            if (rbl_gioiTinh.SelectedIndex == 0)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";
            HamXuLy hxl = new HamXuLy(KhachHang.id, txt_tenKH.Text, lb_UsernameKH.Text, txt_pass.Text, gioiTinh, txt_Email.Text, txt_DienThoai.Text, txt_DiaChi.Text);
            hxl.KtraDangNhap = true;
            Session["login"] = hxl;
            cn.Open();
            string kh = "UPDATE KHACHHANG set PASSWORD_=@PW  where ID = @ID";
            lenh = new SqlCommand(kh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ID", lb_ID.Text);
            lenh.Parameters.AddWithValue("@PW", txt_pass.Text);


            lenh.ExecuteNonQuery();
            cn.Close();


            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
            btn_capNhat.Visible = true;
            txt_tenKH.Enabled = false;
            btn_doiPass.Visible = true;
            txt_pass.Enabled = false;
            btn_OkPass.Visible = false;
            rbl_gioiTinh.Enabled = false;
            txt_Email.Enabled = false;
            txt_DienThoai.Enabled = false;
            txt_DiaChi.Enabled = false;
            txt_confirm.Visible = false;

            lb_confirm.Visible = false;
            lb_tb.Text = "Đổi mật khẩu thành công.";
        }
        

    }
    protected void btn_intoDonDat_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        gv_CTHDTheoMa.Visible = false;
        layDonHang();
    }
    public void layDonHang()
    {
        string sql = "SELECT * from HOADON,KHACHHANG where KHACHHANG.ID = HOADON.MAKH and USERNAME = @un and TINHTRANG!=N'Đã hủy' or PHONE = @un  ";
        //string sql = "select HOADON.MAHD,KHACHHANG.ID,NAME_SP,CT_HOADON.soLuong,donGia,HOTEN,PHONE,DIACHI,IMAGE_SP,NgayXuat,THANHTIEN "
        //            +" from HOADON,CT_HOADON,KHACHHANG,SANPHAM "
        //            +" where HOADON.MAHD=CT_HOADON.MAHD AND HOADON.MAKH=KHACHHANG.ID "
        //            +" AND CT_HOADON.ID_SP=SANPHAM.ID_SP and MAKH = @ma";
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@un", lb_UsernameKH.Text);
        da.SelectCommand = lenh;
        DataTable dt2 = new DataTable();
        da.Fill(dt2);
        gv_HoaDon.DataSource = dt2;
        gv_HoaDon.DataBind();
    }
    public void layCTHDTheoMa(string ma)
    {
        cn.Open();
        string tv = "SELECT * from CT_HOADON,SANPHAM where CT_HOADON.ID_SP=SANPHAM.ID_SP and MAHD = @ma";

        lenh = new SqlCommand(tv, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        cn.Close();
        gv_CTHDTheoMa.Visible = true;
        gv_CTHDTheoMa.DataSource = dt;
        gv_CTHDTheoMa.DataBind();
        cn.Close();
    }
    protected void btn_infoChung_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void gv_HoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_HoaDon.PageIndex = e.NewPageIndex;
        this.layDonHang();
    }
    protected void gv_CTHDTheoMa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_CTHDTheoMa.PageIndex = e.NewPageIndex;
        this.layCTHDTheoMa(KhachHang.maHD);
    }
    //protected void gv_CTHDTheoMa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gv_.PageIndex = e.NewPageIndex;
    //    this.layDonHang();
   

    protected void btn_chonHD_KH_Click(object sender, EventArgs e)
    {
        int row_chonHD = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

        KhachHang.maHD = gv_HoaDon.Rows[row_chonHD].Cells[0].Text.ToString();
        layCTHDTheoMa(maHD);
    }
    protected void btn_XoaHD_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string maHD = gv_HoaDon.Rows[row_chon].Cells[0].Text.ToString();

        //Hủy trên HoaDon 
        cn.Open();

        string sql = "Update HOADON set TINHTRANG =N'Đã hủy' where MAHD=@ma ";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", maHD);
        lenh.ExecuteNonQuery();
        ////Xoa tren bang HOADON
        //string sql2 = "delete from HOADON where MAHD=@ma";

        //lenh = new SqlCommand(sql2, cn);
        //lenh.Parameters.Clear();
        //lenh.Parameters.AddWithValue("@ma", maHD);
        //lenh.ExecuteNonQuery();
        cn.Close();

        gv_CTHDTheoMa.Visible = false;
        layDonHang();
    }
}