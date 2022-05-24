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

public partial class ThanhToan : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = null;
    SqlDataAdapter da = new SqlDataAdapter();
    public static string maHD="";
    public static string maKH = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        hyp_QuayLaiMuaHang.Visible = false;
    }
    protected void btn_DatHang_Click(object sender, EventArgs e)
    {
        if (Session["cart"] == null)
        {
            lb_tbGioHang.Text = "Giỏ hàng trống";
            hyp_QuayLaiMuaHang.Visible = true;
        }
        else
        {
                themKhachHang();
                themHoaDon();
                Session["completeCart"] = Session["cart"];
                Session["cart"] = null;
                XayDungDH cart = new XayDungDH();
                cart.createItem();
                Session["cart"] = cart;
                MultiView1.ActiveViewIndex = 1;
                layDonHang();
        }
    }
    public void layDonHang() 
    {
        string sql = "select HOADON.MAHD,KHACHHANG.ID,NAME_SP,CT_HOADON.soLuong,donGia,HOTEN,PHONE,DIACHI,IMAGE_SP from HOADON,CT_HOADON,KHACHHANG,SANPHAM"
                           +" where HOADON.MAHD=CT_HOADON.MAHD AND HOADON.MAKH=KHACHHANG.ID "
                           +" AND CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_HOADON.MAHD = @ma";
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ThanhToan.maHD);
        da.SelectCommand = lenh;
        DataTable dt2 = new DataTable();
        da.Fill(dt2);
        gv_donDaDat.DataSource = dt2;
        gv_donDaDat.DataBind();
    }
    void themKhachHang()
    {
        cn.Open();
        ThanhToan.maKH = taoMaKhachHangTuDong();
        string user="",pass="";
        string hoTen = txt_HoTenKHDH.Text;
        string email = txt_EmailDatHang.Text;
        string sdt = txt_sdtDH.Text;
        string diaChi = txt_DiaChi.Text + ", " + txt_TinhTp.Text;
        string gioiTinh = rbl_GioiTinhDH.SelectedValue;
        if (gioiTinh.Equals("Anh"))
            gioiTinh = "Nam";
        else
            gioiTinh = "Nữ";
        HamXuLy kh = new HamXuLy(maKH,hoTen, user, pass, gioiTinh, email, sdt, diaChi);
        Session["khachHang"] = kh;
        //if (Session["login"] != null)//Nếu khách hàng đã đăng nhập
        //{
        //    HamXuLy login = (HamXuLy)Session["login"];
        //    user = login.Username;
        //    pass = login.PassWord;
            
        //    string dh = "UPDATE KHACHHANG set ID=@ID, HOTEN=@HT,GIOITINH=@GT,EMAIL=@EM,PHONE=@P,DIACHI=@DC where USERNAME=@UN";
        //    lenh = new SqlCommand(dh, cn);
        //    lenh.Parameters.Clear();
        //    lenh.Parameters.AddWithValue("@ID", maKH);
        //    lenh.Parameters.AddWithValue("@HT", hoTen);
        //    lenh.Parameters.AddWithValue("@GT", gioiTinh);
        //    lenh.Parameters.AddWithValue("@EM", email);
        //    lenh.Parameters.AddWithValue("@P", sdt);
        //    lenh.Parameters.AddWithValue("@DC", diaChi);
        //    lenh.Parameters.AddWithValue("@UN", user);

        //    lenh.ExecuteNonQuery();
            
        //}
        //else//nếu khách hàng chưa login
        //{
            
        //    string dh = "INSERT INTO KHACHHANG(ID,HOTEN,GIOITINH,EMAIL,PHONE,DIACHI) VALUES(@ID,@HT,@GT,@EM,@P,@DC)";
        //    lenh = new SqlCommand(dh, cn);
        //    lenh.Parameters.Clear();
        //    lenh.Parameters.AddWithValue("@ID", maKH);
        //    lenh.Parameters.AddWithValue("@HT", hoTen);
        //    //lenh.Parameters.AddWithValue("@UN", user);
        //    //lenh.Parameters.AddWithValue("@PW", pass);
        //    lenh.Parameters.AddWithValue("@GT", gioiTinh);
        //    lenh.Parameters.AddWithValue("@EM", email);
        //    lenh.Parameters.AddWithValue("@P", sdt);
        //    lenh.Parameters.AddWithValue("@DC", diaChi);

        //    lenh.ExecuteNonQuery();
           
        //}
        if (Session["login"] != null)//Nếu khách hàng đã đăng nhập
        {
            HamXuLy login = (HamXuLy)Session["login"];
            user = login.Username;
            pass = login.PassWord;
            string dh = "INSERT INTO KHACHHANG(ID,HOTEN,USERNAME,PASSWORD_,GIOITINH,EMAIL,PHONE,DIACHI) VALUES(@ID,@HT,@UN,@PW,@GT,@EM,@P,@DC)";
            lenh = new SqlCommand(dh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ID", maKH);
            lenh.Parameters.AddWithValue("@HT", hoTen);
            lenh.Parameters.AddWithValue("@UN", user);
            lenh.Parameters.AddWithValue("@PW", pass);
            lenh.Parameters.AddWithValue("@GT", gioiTinh);
            lenh.Parameters.AddWithValue("@EM", email);
            lenh.Parameters.AddWithValue("@P", sdt);
            lenh.Parameters.AddWithValue("@DC", diaChi);

            lenh.ExecuteNonQuery();

        }
        else
        {
            string dh = "INSERT INTO KHACHHANG(ID,HOTEN,USERNAME,PASSWORD_,GIOITINH,EMAIL,PHONE,DIACHI) VALUES(@ID,@HT,@UN,@PW,@GT,@EM,@P,@DC)";
            lenh = new SqlCommand(dh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ID", maKH);
            lenh.Parameters.AddWithValue("@HT", hoTen);
            lenh.Parameters.AddWithValue("@UN", user);
            lenh.Parameters.AddWithValue("@PW", pass);
            lenh.Parameters.AddWithValue("@GT", gioiTinh);
            lenh.Parameters.AddWithValue("@EM", email);
            lenh.Parameters.AddWithValue("@P", sdt);
            lenh.Parameters.AddWithValue("@DC", diaChi);

            lenh.ExecuteNonQuery();
        }
        cn.Close();
    }

    public void themHoaDon()//insert vào bảng hóa đơn
    {
        cn.Open();
        ThanhToan.maHD = taoMaHoaDonTuDong();
        //if (Session["khachHang"] != null)
        //{
        //    HamXuLy kh = (HamXuLy)Session["khachHang"];
        //    maKH = kh.MaKH;
        //}
        string dh = "INSERT INTO HOADON(MAHD,MAKH) VALUES(@hd,@kh)";
        lenh = new SqlCommand(dh, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@hd", maHD);
        lenh.Parameters.AddWithValue("@kh", maKH);
        lenh.ExecuteNonQuery();
        //insert CT_HOADON
        XayDungDH cart = (XayDungDH)Session["cart"];
        foreach (DataRow d in cart.gioHang.Rows)
        {
            string id_sp = d[0].ToString();
            int soLuong = int.Parse(d[4].ToString());
            int donGia = int.Parse(d[3].ToString());
            string cthd = "INSERT INTO CT_HOADON(MAHD,ID_SP,soLuong,donGia) VALUES(@ma,@idsp,@sl,@dg)";
            lenh = new SqlCommand(cthd, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ma", maHD);
            lenh.Parameters.AddWithValue("@idsp", id_sp);
            lenh.Parameters.AddWithValue("@sl", soLuong);
            lenh.Parameters.AddWithValue("@dg", donGia);
            lenh.ExecuteNonQuery();
            //giam so luong san pham theo ID_SP
            giamSoLuongSP(d[0].ToString(), soLuong);
        }
        cn.Close();

    }
   
    public string taoMaHoaDonTuDong()//Tạo mã hóa dơn tự động từ 'HD000000' -> 'HD999999'
    {
        string maDH = "";
        lenh.CommandText = "select MAX(right(MAHD,6)) from HOADON";
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        if (ktraHoaDonIsEmpty() == true)
            maDH = "HD000000";
        else
        {
            int ma = int.Parse(dt.Rows[0][0].ToString());
            int ma2 = ma + 1;
            if (ma >= 0 && ma < 9)
                maDH = "HD00000" + ma2.ToString();
            else if (ma >= 9 && ma < 99)
                maDH = "HD0000" + ma2.ToString();
            else if (ma >= 99 && ma < 999)
                maDH = "HD000" + ma2.ToString();
            else if (ma >= 999 && ma < 9999)
                maDH = "HD00" + ma2.ToString();
            else if (ma >= 9999 && ma < 99999)
                maDH = "HD0" + ma2.ToString();
            else
                maDH = "HD" + ma2.ToString();
        }

        return maDH;
    }
    public Boolean ktraHoaDonIsEmpty()
    {
        string ad = "SELECT * from HOADON";

        lenh = new SqlCommand(ad, cn);
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập, password và ngược lại)
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    public string taoMaKhachHangTuDong()//Tạo mã Khach hàng tự động từ 'KH000000' -> 'KH999999'
    {
        string maKH = "";
        if (ktraKhachHangIsEmpty() == true)
            maKH = "KH000000";
        else
        {
            lenh.CommandText = "select MAX(right(ID,6)) from KHACHHANG";
            lenh.Parameters.Clear();
            DataTable dt = new DataTable();
            da.SelectCommand = lenh;
            da.Fill(dt);
            int ma = int.Parse(dt.Rows[0][0].ToString());
            int ma2 = ma + 1;
            if (ma >= 0 && ma < 9)
                maKH = "KH00000" + ma2.ToString();
            else if (ma >= 9 && ma < 99)
                maKH = "KH0000" + ma2.ToString();
            else if (ma >= 99 && ma < 999)
                maKH = "KH000" + ma2.ToString();
            else if (ma >= 999 && ma < 9999)
                maKH = "KH00" + ma2.ToString();
            else if (ma >= 9999 && ma < 99999)
                maKH = "KH0" + ma2.ToString();
            else
                maKH = "KH" + ma2.ToString();
        }

        return maKH;
    }
    public Boolean ktraKhachHangIsEmpty()
    {
        string ad = "SELECT * from KHACHHANG";

        lenh = new SqlCommand(ad, cn);
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập, password và ngược lại)
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    public void giamSoLuongSP(string ma, int soLuongGiam)
    {
        string ad = "Update SANPHAM set SOLUONG = SOLUONG - @sl where ID_SP=@ma";

        lenh = new SqlCommand(ad, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@sl", soLuongGiam);
        lenh.Parameters.AddWithValue("@ma", ma);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
    }
    //public int layMaKH(string hoten, string user, string email, string sdt, string diachi, string gioitinh)
    //{
    //    int maKH = 0;
    //    if (Session["login"] != null)
    //    {
    //        lenh.CommandText = "select ID  from KHACHHANG where USERNAME=@user";
    //        lenh.Parameters.Clear();
    //        lenh.Parameters.AddWithValue("@user", user);
    //        DataTable dt = new DataTable();
    //        da.SelectCommand = lenh;
    //        da.Fill(dt);

    //        maKH = int.Parse(dt.Rows[0][0].ToString());

    //    }
    //    else
    //    {
    //        lenh.CommandText = "select ID from KHACHHANG where  GIOITINH=@gt"; //HOTEN=N'@ht' and EMAIL=@em and PHONE=@p and DIACHI=N'@dc' and
    //        lenh.Parameters.Clear();
    //        lenh.Parameters.AddWithValue("@ht", hoten);
    //        lenh.Parameters.AddWithValue("@gt", gioitinh);
    //        lenh.Parameters.AddWithValue("@em", email);
    //        lenh.Parameters.AddWithValue("@p", sdt);
    //        lenh.Parameters.AddWithValue("@dc", diachi);
    //        DataTable dt = new DataTable();
    //        da.SelectCommand = lenh;
    //        da.Fill(dt);
    //        maKH = int.Parse(dt.Rows[0][0].ToString());
    //    }
    //    return maKH;
    //}
    //string layMaKHTheoTaiKhoan()
    //{
    //    HamXuLy login = (HamXuLy)Session["login"];
    //    cn.Open();

    //    lenh.CommandText = "select ID from KHACHHANG where USERNAME = @id";
    //    lenh.Parameters.Clear();
    //    lenh.Parameters.AddWithValue("@id", );
    //    DataTable dt = new DataTable();
    //    da.SelectCommand = lenh;
    //    da.Fill(dt);
    //    cn.Close();

    //    return dt.Rows[0][1].ToString();
    //}
}