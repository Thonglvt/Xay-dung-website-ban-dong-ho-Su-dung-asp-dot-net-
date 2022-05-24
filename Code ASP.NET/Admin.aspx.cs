using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Text;

public partial class Admin : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    public static string maHD = "";
    public static string MANV = "";
    public int row_chonHD = 0;
    public int row_chonNV = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userNV"]!=null && Session["userNV"].ToString().Equals("admin") == false)
        {
            btn_NhanVien.Enabled = false;
        }
        FileUpload1.Enabled = false;
        btnUpload.Enabled = false;
        //dl_ngayTK.Visible = false;
        //dl_thangTK.Visible = false;
        //dl_namTK.Visible = false;
        txt_MaKH_KH.Enabled = false;
        txt_username_KH.Enabled = false;
        txt_maPN_PN.Enabled = false;
        txt_maNV_PN.Enabled = false;
        txt_ngayNhap_PN.Enabled = false;
        if (!IsPostBack)
        {
            btn_luu_PN.Enabled = false;
            //btn_capNhat_PN.Enabled = false;
            btn_xoaTrang_PN.Enabled = false;
            btn_xong1PN.Enabled = false;
        }

    }
    
    //protected void gv_sanPham_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridViewRow row = gv_sanPham.SelectedRow;
    //    txt_maSP.Text = row.Cells[0].Text;
    //    txt_tenSP.Text = row.Cells[1].Text;
        
    //    txt_gia.Text = row.Cells[3].Text;
        
    //}
    protected void btn_sanPham_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = 0;
        laySanPham();
    }
    protected void btn_chiTietSanPham_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        MultiView2.ActiveViewIndex = 1;
        layChiTietSanPham();
        layDropdownList();
    }
    protected void btn_NhanVien_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 2;
        rbl_gioiTinh.SelectedIndex = 0;
        layThanhVien();
    }

    protected void btn_khachHang_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 3;
        layKhachHang();
    }
    protected void btn_hoaDon_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
        MultiView2.ActiveViewIndex = 4;
        gv_CTHDTheoMa.Visible = false;
        layHoaDon();
        dl_ngayHD.Items.Clear();
        dl_thangHD.Items.Clear();
        dl_namHD.Items.Clear();
        for (int i = 1; i <= 31 ; i++)
        {
            if (i <= 9)
                dl_ngayHD.Items.Add("0"+i.ToString());
            else
                dl_ngayHD.Items.Add(i.ToString());
        }
        for (int i = 1; i <= 12; i++)
        {
            if (i <= 9)
                dl_thangHD.Items.Add("0" + i.ToString());
            else
            dl_thangHD.Items.Add(i.ToString());
        }
        for (int i = 2020; i <= DateTime.Now.Year; i++)
        {
            
            dl_namHD.Items.Add(i.ToString());
        }
        

    }
    protected void btn_PhieuNhap_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 7;
        MultiView2.ActiveViewIndex = 7;
        layPhieuNhap();
    }
    protected void btn_Image_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 6;
        MultiView2.ActiveViewIndex = 6;
        layImage();
    }
    protected void btn_thongKe_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
        MultiView2.ActiveViewIndex = 5;
        lb_SLTon.Text = tongSanPham().ToString() + " sản phẩm";
        lb_slDaBan.Text = tongDaBan().ToString();
        lb_tbTongDoanhThu.Text = string.Format("{0:0,0} đ", tongDoanhThu());
        //for (int i = 1; i <= 31; i++)
        //{
        //    if (i <= 9)
        //        dl_ngayTK.Items.Add("0" + i.ToString());
        //    else
        //        dl_ngayTK.Items.Add(i.ToString());
        //}
        dl_thangTK.Items.Clear();
        dl_namTK.Items.Clear();
        dl_namTK2.Items.Clear();
        dl_DDT.Items.Clear();
        dl_MDT.Items.Clear();
        dl_YDT.Items.Clear();
        for (int i = 1; i <= 12; i++)
        {
            if (i <= 9)
                dl_thangTK.Items.Add("0" + i.ToString());
            else
                dl_thangTK.Items.Add(i.ToString());
        }
        for (int i = 2015; i <= DateTime.Now.Year; i++)
        {

            dl_namTK.Items.Add(i.ToString());
        }
        for (int i = 2015; i <= DateTime.Now.Year; i++)
        {

            dl_namTK2.Items.Add(i.ToString());
        }
        dl_DDT.Items.Add("No set");
        dl_MDT.Items.Add("No set");
        //Doanh thu

        for (int i = 1; i <= 31; i++)
        {
            if (i <= 9)
                dl_DDT.Items.Add("0" + i.ToString());
            else
                dl_DDT.Items.Add(i.ToString());
        }
        for (int i = 1; i <= 12; i++)
        {
            if (i <= 9)
                dl_MDT.Items.Add("0" + i.ToString());
            else
                dl_MDT.Items.Add(i.ToString());
        }
        for (int i = 2015; i <= DateTime.Now.Year; i++)
        {

            dl_YDT.Items.Add(i.ToString());
        }
       
    }
    public int tongDoanhThu()
    {
        string sql = "select sum(CT_HOADON.soLuong*CT_HOADON.donGia - CT_PHIEUNHAP.donGia*CT_HOADON.soLuong) "
                    +"from CT_HOADON,CT_PHIEUNHAP,SANPHAM " 
                    +" where CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_PHIEUNHAP.ID_SP=SANPHAM.ID_SP";
        cn.Open();
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        DataTable dt2 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt2);
        int a;
        try
        {
            a=int.Parse(dt2.Rows[0][0].ToString());
        }
        catch (Exception)
        {
            return 0;
        }
        cn.Close();
        return a;

    }
    public int tongDaBan()
    {
        cn.Open();
        string sumSoLuong = "select sum(soLuong) from CT_HOADON";
        lenh = new SqlCommand(sumSoLuong, cn);
        lenh.Parameters.Clear();
        DataTable dt2 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt2);
        cn.Close();
        int a;
        try
        {
            a = int.Parse(dt2.Rows[0][0].ToString());
        }
        catch (Exception)
        {
            return 0;
        }
        return a;
    }
    
    protected void btn_select_Click(object sender, EventArgs e)
    {
        txt_maSP.Text = "";
        txt_tenSP.Text = "";
        txt_gia.Text = "";

        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

        //int gia = int.Parse( gv_sanPham.Rows[row_chon].Cells[3].Text);
        txt_maSP.Text = gv_sanPham.Rows[row_chon].Cells[0].Text;
        txt_tenSP.Text = gv_sanPham.Rows[row_chon].Cells[1].Text;
        txt_ImgUrl.Text = gv_sanPham.Rows[row_chon].Cells[2].Text;
        img_sp.ImageUrl = gv_sanPham.Rows[row_chon].Cells[2].Text;
        txt_gia.Text = gv_sanPham.Rows[row_chon].Cells[3].Text;
        txt_SoLuong.Text = gv_sanPham.Rows[row_chon].Cells[4].Text;

        if(int.Parse(txt_SoLuong.Text) == 0)
            dl_TinhTrang.SelectedIndex = 1;
        else
            dl_TinhTrang.SelectedIndex = 0;
        
    }
    //---------------------------------------------------------------------------------
    //Xử lý view sảm phẩm
    void laySanPham()
    {
        cn.Open();
        string sp = "SELECT * from SANPHAM";
        string sumSoLuong = "select sum(SOLUONG) from SANPHAM";

        lenh = new SqlCommand(sp, cn);
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);    
        gv_sanPham.DataSource = dt;
        gv_sanPham.DataBind();
        cn.Close();
        lb_tongSoLuong.Text = "Tổng số lượng: " + tongSanPham().ToString() + " sản phẩm.";

    }
    protected void btn_searchSP_Click(object sender, EventArgs e)
    {
        string maSP = txt_searchSP.Text;
        cn.Open();
        string sp = "SELECT * from SANPHAM where ID_SP like '%'+@ma+'%' or NAME_SP like '%'+@ma+'%'";

        lenh = new SqlCommand(sp, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", maSP);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_sanPham.DataSource = dt;
        gv_sanPham.DataBind();
        cn.Close();
    }
    protected void btn_xoaSearchSP_Click(object sender, EventArgs e)
    {
        txt_searchSP.Text = "";
        laySanPham();
    }
    public int tongSanPham()
    {
        cn.Open();
        string sumSoLuong = "select sum(SOLUONG) from SANPHAM";
        lenh = new SqlCommand(sumSoLuong, cn);
        lenh.Parameters.Clear();
        DataTable dt2 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt2);
        cn.Close();
        int a = 0;
        try
        {
            a = int.Parse(dt2.Rows[0][0].ToString());
        }
        catch (Exception)
        {
            return 0;
        }
        return a;
    }
    public string taoMaSanPhamNamTuDong()
    {
        string maSP = "";
        if (ktraMaSPIsEmpty() == true)
            maSP = "DH_NAM000000";
        else
        {
            lenh.CommandText = "select MAX(right(ID_SP,6)) from SANPHAM where ID_SP like 'DH_NAM%'";
            lenh.Parameters.Clear();
            DataTable dt = new DataTable();
            da.SelectCommand = lenh;
            da.Fill(dt);
            int ma = int.Parse(dt.Rows[0][0].ToString());
            int ma2 = ma + 1;
            if (ma >= 0 && ma < 9)
                maSP = "DH_NAM00000" + ma2.ToString();
            else if (ma >= 9 && ma < 99)
                maSP = "DH_NAM0000" + ma2.ToString();
            else if (ma >= 99 && ma < 999)
                maSP = "DH_NAM000" + ma2.ToString();
            else if (ma >= 999 && ma < 9999)
                maSP = "DH_NAM00" + ma2.ToString();
            else if (ma >= 9999 && ma < 99999)
                maSP = "DH_NAM0" + ma2.ToString();
            else
                maSP = "DH_NAM" + ma2.ToString();
        }

        return maSP;
    }

    public string taoMaSanPhamNuTuDong()
    {
        string maSP = "";
        if (ktraMaSPIsEmpty() == true)
            maSP = "DH_NU000000";
        else
        {
            lenh.CommandText = "select MAX(right(ID_SP,6)) from SANPHAM where ID_SP like 'DH_NU%'";
            lenh.Parameters.Clear();
            DataTable dt = new DataTable();
            da.SelectCommand = lenh;
            da.Fill(dt);
            int ma = int.Parse(dt.Rows[0][0].ToString());
            int ma2 = ma + 1;
            if (ma >= 0 && ma < 9)
                maSP = "DH_NU00000" + ma2.ToString();
            else if (ma >= 9 && ma < 99)
                maSP = "DH_NU0000" + ma2.ToString();
            else if (ma >= 99 && ma < 999)
                maSP = "DH_NU000" + ma2.ToString();
            else if (ma >= 999 && ma < 9999)
                maSP = "DH_NU00" + ma2.ToString();
            else if (ma >= 9999 && ma < 99999)
                maSP = "DH_NU0" + ma2.ToString();
            else
                maSP = "DH_NU" + ma2.ToString();
        }

        return maSP;
    }
    public Boolean ktraMaSPIsEmpty()
    {
        string ad = "SELECT * from SANPHAM";

        lenh = new SqlCommand(ad, cn);
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            return false;//ko rỗng
        }
        return true;//rỗng
    }
    protected void btn_maNam_Click(object sender, EventArgs e)
    {
        string ma = taoMaSanPhamNamTuDong();
        txt_maSP.Text = ma;
    }
    protected void btn_maNu_Click(object sender, EventArgs e)
    {
        string ma = taoMaSanPhamNuTuDong();
        txt_maSP.Text = ma;
    }
    //------------------------------------------------------------------------------------------------------------------------
    void layChiTietSanPham()
    {
        cn.Open();
        string ctsp = "SELECT * from CT_SANPHAM,NSX,THUONGHIEU where CT_SANPHAM.maNSX = NSX.maNSX and THUONGHIEU.maTH=CT_SANPHAM.maTH";

        lenh = new SqlCommand(ctsp, cn);
        lenh.Parameters.Clear();

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_chiTiet.DataSource = dt;
        gv_chiTiet.DataBind();
        cn.Close();
    }
    int ktraMaSP(string maSP)
    {
        cn.Open();
        string kh = "SELECT ID_SP from SANPHAM where ID_SP = @maSP";

        lenh = new SqlCommand(kh, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@maSP", maSP);

            DataTable dt = new DataTable();
            da.SelectCommand = lenh;
            da.Fill(dt);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập và ngược lại)
        if (dt.Rows.Count > 0)
        {
            cn.Close();
            return 1;//Tồn tại
        }

        cn.Close();

        return 0;//ko tồn tại
    }
    protected void btn_Them_Click(object sender, EventArgs e)
    {
        string maSP = txt_maSP.Text.Trim();
        int donGia = 0, soLuong = 0;
        try
        {
            donGia = int.Parse(txt_gia.Text.Trim());
        }
        catch (Exception)
        {
            lb_tbthem.Text = "Đơn giá không dúng định dạng, phải là số và lớn hơn 0";
            txt_gia.Focus();
            return;
        }
        try
        {
            soLuong = int.Parse(txt_SoLuong.Text.Trim());
        }
        catch (Exception)
        {
            lb_tbthem.Text = "Số lượng không dúng định dạng, phải là số và lớn hơn 0";
            txt_SoLuong.Focus();
            return;
        }
        if (maSP.Length == 0)
        {
            lb_tbthem.Text = "Mã sản phẩm không được để trống.Vui lòng lấy mã";
            txt_maSP.Focus();
        }
        else if (ktraMaSP(txt_maSP.Text) == 0)
        {

            cn.Open();
            string kh = "INSERT INTO SANPHAM(ID_SP,NAME_SP,IMAGE_SP,RETAIL_PRICE,SOLUONG) VALUES(@masp,@tensp,@img,@gia,@sl)";
            lenh = new SqlCommand(kh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@masp", txt_maSP.Text);
            lenh.Parameters.AddWithValue("@tensp", txt_tenSP.Text);
            lenh.Parameters.AddWithValue("@img", txt_ImgUrl.Text);
            lenh.Parameters.AddWithValue("@gia", donGia);
            lenh.Parameters.AddWithValue("@sl", soLuong);

            lenh.ExecuteNonQuery();
            cn.Close();

            lb_tbthem.Text = "Thêm Thành Công";
            laySanPham();

        }
        else
            lb_tbthem.Text = "Sản phẩm đã tồn tại";
    }
    protected void btn_Sua_Click(object sender, EventArgs e)
    {
        int gia = 0, soLuong = 0;
        try
        {
            gia = int.Parse(txt_gia.Text);
        }
        catch (Exception)
        {
            lb_tbthem.Text = "Nhập không hợp lệ";
            txt_gia.Focus();
            return;
        }
        try
        {
            soLuong = int.Parse(txt_SoLuong.Text);   
        }
        catch (Exception)
        {
            lb_tbthem.Text = "Nhập không hợp lệ";
            txt_SoLuong.Focus();
            return;
        }
        string maSP = txt_maSP.Text;
        int x = ktraMaSP(maSP);
        if (x == 0)
            lb_tbthem.Text = "Sản phẩm này không tồn tại để cập nhật";
        else
        {
            cn.Open();
            string kh = "Update SANPHAM set NAME_SP = @ten, IMAGE_SP = @imgUrl,SOLUONG=@sl, RETAIL_PRICE = @gia where ID_SP = @ma";

            lenh = new SqlCommand(kh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ma", txt_maSP.Text);
            lenh.Parameters.AddWithValue("@ten", txt_tenSP.Text);
            lenh.Parameters.AddWithValue("@imgUrl", txt_ImgUrl.Text);
            lenh.Parameters.AddWithValue("@sl", txt_SoLuong.Text);
            lenh.Parameters.AddWithValue("@gia", gia);

            lenh.ExecuteNonQuery();
            cn.Close();

            lb_tbthem.Text = "Cập nhật Thành Công.";
            laySanPham();
            btn_XoaTrang_Click(sender, e);
            btn_sanPham_Click(sender, e);
        }

    }
    void xoaCTSP(string maSP)
    {
        cn.Open();
        string kh = "delete CT_SANPHAM where ID_SP = @ma";

        lenh = new SqlCommand(kh, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", maSP);

        int rs = lenh.ExecuteNonQuery();
        cn.Close();
    }
    protected void btn_Xoa_Click(object sender, EventArgs e)
    {
        string maSP = txt_maSP.Text;
        int x = ktraMaSP(maSP);
        if (x == 0)
            lb_tbthem.Text = "Sản phẩm này không tồn tại để xóa";
        else
        {
            xoaCTSP(maSP);//Xóa CTSP trước
            cn.Open();
            string kh = "delete SANPHAM where ID_SP = @ma";

            lenh = new SqlCommand(kh, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ma", txt_maSP.Text);

            int rs = lenh.ExecuteNonQuery();
            cn.Close();

            if (rs == 1)
            {
                lb_tbthem.Text = "Xóa Thành Công.";
                laySanPham();
                btn_XoaTrang_Click(sender, e);
                btn_sanPham_Click(sender, e);
            }
            else
                lb_tbthem.Text = "Xóa thất bại (Có thể vi phạm khóa ngoại).";

        }
    }
    protected void btn_XoaTrang_Click(object sender, EventArgs e)
    {
        txt_maSP.Text = "";
        txt_tenSP.Text = "";
        txt_gia.Text = "";
        img_sp.ImageUrl = "";
        txt_ImgUrl.Text = "";
        txt_SoLuong.Text = "";
        dl_TinhTrang.SelectedIndex = 1;
        //lb_tbthem.Text = "";
    }
   
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        String tenfile;
        tenfile = "~/img/" + FileUpload1.FileName;
        txt_ImgUrl.Text = tenfile;
        img_sp.ImageUrl = tenfile;
    }
    //---------------------------------------------------------------------------------
    //Xử lý view nhân viên
    void layThanhVien()
    {
        cn.Open();
        string tv = "SELECT * from NHANVIEN";

        lenh = new SqlCommand(tv, cn);
        lenh.Parameters.Clear();

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_thanhVien.DataSource = dt;
        gv_thanhVien.DataBind();
        cn.Close();
    }
    protected void btn_chonTV_Click(object sender, EventArgs e)
    {
        this.row_chonNV = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        Admin.MANV = gv_thanhVien.Rows[row_chonNV].Cells[0].Text.ToString();

        txt_ten.Text = gv_thanhVien.Rows[row_chonNV].Cells[1].Text.ToString();
        txt_tenDangNhap.Text = gv_thanhVien.Rows[row_chonNV].Cells[2].Text;
        txt_matKhau.Text = gv_thanhVien.Rows[row_chonNV].Cells[3].Text;
        string gt = gv_thanhVien.Rows[row_chonNV].Cells[4].Text;
        if (gt.Equals("Nam"))
            rbl_gioiTinh.SelectedIndex = 0;
        else
            rbl_gioiTinh.SelectedIndex = 1;
        txt_Email.Text =  gv_thanhVien.Rows[row_chonNV].Cells[5].Text;
        txt_dienThoai.Text = gv_thanhVien.Rows[row_chonNV].Cells[6].Text;
        txt_diaChi.Text = gv_thanhVien.Rows[row_chonNV].Cells[7].Text;
    }
    protected void btnThem2_Click(object sender, EventArgs e)
    {
        FileUpload1.Enabled = true;
        btnUpload.Enabled = true;

        txt_ten.Text = "";
        txt_tenDangNhap.Text = "";
        txt_matKhau.Text = "";
        txt_Email.Text = "";
        txt_dienThoai.Text = "";
        txt_diaChi.Text = "";
    }

    protected void btnThem2TV_Click(object sender, EventArgs e)
    {
        txt_ten.Text = "";
        txt_tenDangNhap.Text = "";
        txt_matKhau.Text = "";
        txt_Email.Text = "";
        txt_dienThoai.Text = "";
        txt_diaChi.Text = "";
        lb_tbNV.Text = "";
    }
    protected void btnLuuTV_Click(object sender, EventArgs e)
    {

        string maNV = taoMaNhanVienTuDong();
        string gioiTinh = "";
        if (rbl_gioiTinh.SelectedIndex == 0)
            gioiTinh = "Nam";
        else
            gioiTinh = "Nữ";
        cn.Open();
        string nv = "INSERT INTO NHANVIEN(MANV,HOTEN,TenDangNhap,password_,GIOITINH,EMAIL,DIENTHOAI,DIACHI) VALUES(@manv,@ten,@tdn,@pass,@gt,@email,@dt,@dc)";
        string sql = "UPDATE NHANVIEN SET HOTEN=@ht,password_=@pw,GIOITINH=@gt,EMAIL=@em,DIENTHOAI=@dt,DIACHI=@dc  where MANV=@ma";
        lenh = new SqlCommand(nv, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@manv", maNV);
        lenh.Parameters.AddWithValue("@ten", txt_ten.Text);
        lenh.Parameters.AddWithValue("@tdn", txt_tenDangNhap.Text);
        lenh.Parameters.AddWithValue("@pass", txt_matKhau.Text);
        lenh.Parameters.AddWithValue("@gt", gioiTinh);
        lenh.Parameters.AddWithValue("@email", txt_Email.Text);
        lenh.Parameters.AddWithValue("@dt", txt_dienThoai.Text);
        lenh.Parameters.AddWithValue("@dc", txt_diaChi.Text);
        //lenh.Parameters.AddWithValue("@ten", txt_ten);@ten,@tdn,@pass,@gt,@email,@dt,@dc
        //lenh.Parameters.AddWithValue("@pw", txt_matKhau);
        //lenh.Parameters.AddWithValue("@gt", gioiTinh);
        //lenh.Parameters.AddWithValue("@em", txt_Email);
        //lenh.Parameters.AddWithValue("@dt", txt_dienThoai);
        //lenh.Parameters.AddWithValue("@dc", txt_diaChi);
        //lenh.Parameters.AddWithValue("@ma", maNV);
        lenh.ExecuteNonQuery();
        cn.Close();
        lb_tbNV.Text = "Thêm thành công";
        layThanhVien();
    }
    public string taoMaNhanVienTuDong()//Tạo mã hóa dơn tự động từ 'HD000000' -> 'HD999999'
    {
        cn.Open();
        string maNV = "";
        string sql = "select MAX(right(MANV,6)) from NHANVIEN";
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        if (ktraNhanVienIsEmpty() == true)
            maNV = "NV000000";
        else
        {
            int ma = int.Parse(dt.Rows[0][0].ToString());
            int ma2 = ma + 1;
            if (ma >= 0 && ma < 9)
                maNV = "NV00000" + ma2.ToString();
            else if (ma >= 9 && ma < 99)
                maNV = "NV0000" + ma2.ToString();
            else if (ma >= 99 && ma < 999)
                maNV = "NV000" + ma2.ToString();
            else if (ma >= 999 && ma < 9999)
                maNV = "NV00" + ma2.ToString();
            else if (ma >= 9999 && ma < 99999)
                maNV = "NV0" + ma2.ToString();
            else
                maNV = "NV" + ma2.ToString();
        }
        cn.Close();

        return maNV;
    }
    public Boolean ktraNhanVienIsEmpty()
    {
        string ad = "SELECT * from NHANVIEN";

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
    protected void btnCapNhatTV_Click(object sender, EventArgs e)
    {
       
    }

    protected void btn_XoaNV_NV_Click(object sender, EventArgs e)
    {
        int row_chonNV2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string maNV = gv_thanhVien.Rows[row_chonNV2].Cells[0].Text.ToString();
        if (ktraNhanVienTruocKhiXoa(maNV) == 1)
        {
            lb_tbNV_NV.Text = "Nhân viên này không thể xóa! (Do đã nhập hàng và xuất hóa đơn trên hệ thống)";
        }
        else
        {
            cn.Open();
            string sql = "delete NHANVIEN where MANV = @manv";
            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@manv", maNV);

            lenh.ExecuteNonQuery();
            cn.Close();
            lb_tbNV_NV.Text = "Xóa thành công";
            layThanhVien();
            
        }
    }
    public int ktraNhanVienTruocKhiXoa(string ma)
    {
        string sql1 = "SELECT * from PHIEUNHAP where MANV = @ma";
        string sql2 = "SELECT * from HOADON where MANV = @ma";
        lenh = new SqlCommand(sql1, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        lenh = new SqlCommand(sql2, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);
        DataTable dt2 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt2);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập, password và ngược lại)
        if (dt2.Rows.Count > 0 || dt.Rows.Count > 0)
        {
            return 1;
        }
        return 0;
    }
    public DataTable layNhanVienAccount(string tk)
    {
        cn.Open();
        string sql = "SELECT * from NHANVIEN where TenDangNhap=@tdn";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tdn", tk);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        cn.Close();
        return dt;
    }
    protected void btn_CapNhatLaiNhanVien_Click(object sender, EventArgs e)
    {
        string maKH = gv_HoaDon.Rows[row_chonHD].Cells[1].Text.ToString();
        string tenkh = txt_tenKHHD.Text;
        string nhanvien = dl_nhanVienHD.SelectedValue.ToString();

        //Lay mã nhân viên theo account
        DataTable dt1 = layNhanVienAccount(nhanvien);
        string maNV = dt1.Rows[0][0].ToString();
        cn.Open();
        string sqlkh = "Update KHACHHANG set HOTEN = @tenkh where ID = @makh";
        string sqlhd = "Update HOADON set MANV = @manv,TINHTRANG=N'Đã duyệt' where MAHD = @mahd";

        lenh = new SqlCommand(sqlkh, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tenkh", tenkh);
        lenh.Parameters.AddWithValue("@makh", maKH);
        lenh.ExecuteNonQuery();

        lenh = new SqlCommand(sqlhd, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@manv", maNV);
        lenh.Parameters.AddWithValue("@mahd", Admin.maHD);
        lenh.ExecuteNonQuery();

        cn.Close();

        layHoaDon();
        layCTHDTheoMa(Admin.maHD);
    }
    protected void btn_searchNhanVien_Click(object sender, EventArgs e)
    {
        cn.Open();
        string sql = "SELECT * from NHANVIEN where MANV = @ma or HOTEN like '%'+ @ma +'%' or DIENTHOAI like '%'+ @ma +'%' "
                    +"or GIOITINH like '%'+ @ma +'%' or EMAIL like '%'+ @ma +'%'";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", txt_searchNV.Text);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_thanhVien.DataSource = dt;
        gv_thanhVien.DataBind();
        cn.Close();
    }
    //---------------------------------------------------------------------------------
    //Xử lý view khách hàng
    void layKhachHang()
    {
        cn.Open();
        string tv = "SELECT * from KHACHHANG";

        lenh = new SqlCommand(tv, cn);
        lenh.Parameters.Clear();

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_khachHang.DataSource = dt;
        gv_khachHang.DataBind();
        cn.Close();
    }
    protected void btnChonKH_Click(object sender, EventArgs e)
    {

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
    protected void btn_chonHD_Click(object sender, EventArgs e)
    {
        this.row_chonHD = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

        Admin.maHD = gv_HoaDon.Rows[row_chonHD].Cells[0].Text.ToString();
        layCTHDTheoMa(maHD);

        txt_maKHHD.Text = gv_HoaDon.Rows[row_chonHD].Cells[1].Text.ToString();
        txt_tenKHHD.Text = gv_HoaDon.Rows[row_chonHD].Cells[2].Text.Trim().ToString();
        //txt_matKhau.Text = gv_thanhVien.Rows[row_chon].Cells[2].Text;
        //txt_gioiTinh.Text = gv_thanhVien.Rows[row_chon].Cells[3].Text;
        //txt_Email.Text = gv_thanhVien.Rows[row_chon].Cells[4].Text;
        //txt_dienThoai.Text = gv_thanhVien.Rows[row_chon].Cells[5].Text;
        //txt_diaChi.Text = gv_thanhVien.Rows[row_chon].Cells[6].Text;
    }
    protected void btn_xoaTrangtxtMaKH_Click(object sender, EventArgs e)
    {
        txt_maKHHD.Text = "";
    }
    protected void btn_XoaTenKH_Click(object sender, EventArgs e)
    {
        txt_tenKHHD.Text = "";
    }
    protected void btn_searchKH_Click(object sender, EventArgs e)
    {
        string search = txt_searchKH.Text;

        cn.Open();
        string sql = "SELECT * from KHACHHANG where ID like '%'+@search+'%' or HOTEN like '%'+@search+'%' or "
                    +" GIOITINH like '%'+@search+'%' or PHONE like '%'+@search+'%' or EMAIL like '%'+@search+'%' or DIACHI like '%'+@search+'%'";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@search", search);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_khachHang.DataSource = dt;
        gv_khachHang.DataBind();
        cn.Close();
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
    protected void btn_LuuKH_Click(object sender, EventArgs e)
    {
        string user = txt_username_KH.Text;
        if (ktraTenDangNhapKH(user) == 0)//đã tồn tại Username
        {
            lb_tbKH_KH.Text = "Tài khoản này đã bị trùng.";
            txt_username_KH.Enabled = true;
            txt_username_KH.Focus();
        }
        else
        {
            string maKH = taoMaKhachHangTuDong();
            cn.Open();
            string sql = "insert into KHACHHANG values (@ma,@ten,@us,@pw,@gt,@em,@dt,@dc)";

            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ma", maKH);
            lenh.Parameters.AddWithValue("@ten", txt_tenKH_KH.Text);
            lenh.Parameters.AddWithValue("@us", txt_username_KH.Text);
            lenh.Parameters.AddWithValue("@pw", txt_pass_KH.Text);
            lenh.Parameters.AddWithValue("@gt", rbl_gioiTinhKH.SelectedValue.ToString());
            lenh.Parameters.AddWithValue("@em", txt_EmailKH_KH.Text);
            lenh.Parameters.AddWithValue("@dt", txt_DTKH_KH.Text);
            lenh.Parameters.AddWithValue("@dc", txt_DCKH_KH.Text);

            lenh.ExecuteNonQuery();
            cn.Close();

            lb_tbKH_KH.Text = "Thêm thành công";
            btn_XoaTrangKH_Click(sender, e);
            txt_tenKH_KH.Focus();

            layKhachHang();

        }
    }
    protected void btn_CapNhatKH_Click(object sender, EventArgs e)
    {
        
    }
    protected void btn_XoaTrangKH_Click(object sender, EventArgs e)
    {
        txt_MaKH_KH.Text = "";
        txt_tenKH_KH.Text = "";
        txt_username_KH.Text = "";
        txt_pass_KH.Text = "";
        txt_EmailKH_KH.Text = "";
        txt_DTKH_KH.Text = "";
        txt_DCKH_KH.Text = "";

        rbl_gioiTinhKH.SelectedIndex = 0;
        txt_username_KH.Enabled = true;

    }
    int ktraTenDangNhapKH(string tenDN)
    {
        cn.Open();
        string tv = "SELECT * from KHACHHANG where USERNAME = @tdn";

        lenh = new SqlCommand(tv, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tdn", tenDN);

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập và ngược lại)
        if (dt.Rows.Count > 0)
        {
            cn.Close();
            return 0;//Tồn tại
        }

        cn.Close();

        return 1;//ko tồn tại
    }
   
    //---------------------------------------------------------------------------------
    //Xử lý view hóa đơn
    void layHoaDon()
    {
        cn.Open();
        string sql = "SELECT * from HOADON,KHACHHANG where KHACHHANG.ID = HOADON.MAKH ";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_HoaDon.DataSource = dt;
        gv_HoaDon.DataBind();
        cn.Close();
        //int i=0;
        //foreach (DataRow d in dt.Rows)//Tính tổng tiền của 1 hóa đơn
        //{
        //    string ma = d[0].ToString();
        //    int tongTien = tinhThanhTien1HD(ma);
        //    gv_HoaDon.Rows[i].Cells[4].Text = tongTien.ToString();
        //    i++;
        //}
        

    }
    protected void btn_searchHD_Click(object sender, EventArgs e)
    {
        string search = txt_searchHD.Text;
        gv_CTHDTheoMa.Visible = false;
        string ngay = dl_ngayHD.SelectedValue.ToString();
        string thang = dl_thangHD.SelectedValue.ToString();
        string nam = dl_namHD.SelectedValue.ToString();
        string searchNgay = nam + "-" + thang + "-" + ngay;
        txt_tenKHHD.Text = searchNgay;
        cn.Open();
        string sql = "SELECT * from HOADON,KHACHHANG where HOADON.MAKH = KHACHHANG.ID and ( MAHD like '%'+@search+'%' or HOADON.MAKH like '%'+@search+'%' or MANV like '%'+@search+'%' or THANHTIEN like '%'+@search+'%' or HOTEN like '%'+@search+'%') ";
        string sql2 = "SELECT * from HOADON,KHACHHANG where HOADON.MAKH = KHACHHANG.ID and NgayXuat like '%'+@search2+'%' ";
        DataTable dt = new DataTable();
        if (txt_searchHD.Text.Equals(""))//lọc theo DD MM YYYY
        {
            HamXuLy hxl = new HamXuLy();
            if (hxl.kTraNgayHopLe(int.Parse( ngay), int.Parse(thang), int.Parse(nam)) == false)
            {
                lb_slhd.Text = "Ngày: " + ngay + "-" + thang + "-" + nam + " không hợp lệ.";
            }
            else
            {
                lenh = new SqlCommand(sql2, cn);
                lenh.Parameters.Clear();
                lenh.Parameters.AddWithValue("@search2", searchNgay);
                da.SelectCommand = lenh;
                da.Fill(dt);
                gv_HoaDon.DataSource = dt;
                gv_HoaDon.DataBind();
                lb_slhd.Text = "Tổng: " + dt.Rows.Count.ToString() + " đơn.";
            }
        }
        else//lọc theo thanh tìm kiếm
        {
            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@search", search);
            da.SelectCommand = lenh;
            da.Fill(dt);
            gv_HoaDon.DataSource = dt;
            gv_HoaDon.DataBind();
            lb_slhd.Text = "Tổng: " + dt.Rows.Count.ToString() + " đơn.";
        }
        cn.Close();
        

    }
    void capNhatLaiHoaDon(string ma)
    {
        cn.Open();
        string sql = "Update HOADON set THANHTIEN=(select sum(donGia*soLuong) from CT_HOADON where MAHD = @ma)"
                    +"Where MAHD=@ma";
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);
        lenh.ExecuteNonQuery();
     
        cn.Close();
    }
    protected void btn_XoaHD_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string maHD = gv_HoaDon.Rows[row_chon].Cells[0].Text.ToString();

        //Xóa CT_HoaDon trước
        //cn.Open();
        //string sql = "delete from CT_HOADON where MAHD=@ma";

        //lenh = new SqlCommand(sql, cn);
        //lenh.Parameters.Clear();
        //lenh.Parameters.AddWithValue("@ma", maHD);
        //lenh.ExecuteNonQuery();

        ////Xoa tren bang HOADON
        //string sql2 = "delete from HOADON where MAHD=@ma";

        //lenh = new SqlCommand(sql2, cn);
        //lenh.Parameters.Clear();
        //lenh.Parameters.AddWithValue("@ma", maHD);
        //lenh.ExecuteNonQuery();
        //cn.Close();
        cn.Open();
        string sql = "Update HOADON set TINHTRANG=N'Đã hủy' where MAHD=@ma";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", maHD);
        lenh.ExecuteNonQuery();
        cn.Close();

        gv_CTHDTheoMa.Visible = false;
        layHoaDon();
    }
    protected void btn_HuySP_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string ma = gv_CTHDTheoMa.Rows[row_chon].Cells[0].Text.ToString();
        string maSP = gv_CTHDTheoMa.Rows[row_chon].Cells[1].Text.ToString();
        //Xóa CT_HoaDon trước
        cn.Open();
        string sql = "delete from CT_HOADON where MAHD = @ma and ID_SP = @maSP";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);
        lenh.Parameters.AddWithValue("@maSP", maSP);
        lenh.ExecuteNonQuery();
        cn.Close();

        layHoaDon();
        layCTHDTheoMa(Admin.maHD);

    }
    protected void btn_themSLCTSP_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        int slMoi = int.Parse(gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text) + 1;
        gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text = slMoi.ToString();
    }
    protected void btn_giamSLCTSP_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        if (gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text.Equals("0"))
        {
            gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text = "0";
        }
        else
        {
            int slMoi = int.Parse(gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text) - 1;
            gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text = slMoi.ToString();
        }

    }
    protected void btn_CapNhatSLCTHD_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        int slMoi = int.Parse(gv_CTHDTheoMa.Rows[row_chon].Cells[5].Text);
        string mahd1 = gv_CTHDTheoMa.Rows[row_chon].Cells[0].Text;
        string masp = gv_CTHDTheoMa.Rows[row_chon].Cells[1].Text;

        cn.Open();
        string sql = "UPDATE CT_HOADON SET soLuong = @sl where MAHD = @mahd and ID_SP = @masp";
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@sl", slMoi);
        lenh.Parameters.AddWithValue("@mahd", mahd1);
        lenh.Parameters.AddWithValue("@masp", masp);
        lenh.ExecuteNonQuery();
        cn.Close();

        layHoaDon();
        layCTHDTheoMa(Admin.maHD);
    }
    //Xử lý cho gridview hình ảnh
    protected void btn_themImage_Click(object sender, EventArgs e)
    {
        txt_maSP_img.Text = "";
        txt_detailUrl_img.Text = "";
        img_detail.ImageUrl = "";

    }
    protected void btn_luuImage_Click(object sender, EventArgs e)
    {
        if (txt_detailUrl_img.Text.Equals(""))
        {
            txt_detailUrl_img.Attributes.Add("placeholder", "Url Image trống");
            txt_detailUrl_img.Focus();
        }
        else
        {
            string maSP = txt_maSP_img.Text;
            if (ktraSnPhamKhiThemHinh(maSP) == 0)
            {
                txt_maSP_img.Focus();
                lb_tbHinhAnh.Text = "Sản phẩm không tồn tại trong kho!";
            }
            else
            {
                cn.Open();
                string kh = "INSERT INTO detailImage(ID_SP,ImageUrl) VALUES(@masp,@url)";


                lenh = new SqlCommand(kh, cn);
                lenh.Parameters.Clear();
                lenh.Parameters.AddWithValue("@masp", maSP);
                lenh.Parameters.AddWithValue("@url", txt_detailUrl_img.Text);
                //"~/img/" + fu_detail_Image.FileName
                lenh.ExecuteNonQuery();
                cn.Close();

                lb_tbHinhAnh.Text = "Thêm ảnh thành công";
                txt_detailUrl_img.Text = "";
                img_detail.ImageUrl = "";

                layImage();
            }
        }
    }
    public int ktraSnPhamKhiThemHinh(string ma)
    {
        cn.Open();
        string sql = "select * from SANPHAM where ID_SP=@ma";
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@ma", ma);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        cn.Close();
        if(dt.Rows.Count >0)
            return 1;
        return 0;
    }

    protected void btn_CapNhatImage_Click(object sender, EventArgs e)
    {

    }
    protected void btn_XoaImage_Click(object sender, EventArgs e)
    {

    }
    protected void btn_XoaTrangImage_Click(object sender, EventArgs e)
    {
        txt_maSP_img.Text = "";
        txt_detailUrl_img.Text = "";
        img_detail.ImageUrl = "";
    }
    protected void btn_uploadImage_Click(object sender, EventArgs e)
    {
        string tenFile = fu_detail_Image.FileName;
        img_detail.ImageUrl = "~/img/" + tenFile;
        txt_detailUrl_img.Text = "~/img/" + tenFile;
    }
    void layImage()
    {
        cn.Open();
        string sql = "SELECT * from detailImage";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_hinhAnh.DataSource = dt;
        gv_hinhAnh.DataBind();
        cn.Close();
    }

    protected void btn_chonImg_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

        txt_maSP_img.Text = gv_hinhAnh.Rows[row_chon].Cells[0].Text.ToString();
        txt_detailUrl_img.Text = gv_hinhAnh.Rows[row_chon].Cells[1].Text.ToString();
        img_detail.ImageUrl = gv_hinhAnh.Rows[row_chon].Cells[1].Text.ToString();
    }
    protected void btn_XoaImg_Click(object sender, EventArgs e)
    {

    }
    //ID_SP,tenNSX,ThuongHieu,SoHieuSP,XuatXu,Gender,Kinh,May,BHQT,BH_Shop,DK_Mat,DoDay_Mat,Nieng,DayDeo,MauMatSo,ChongNuoc,ChucNang

    public DataTable selectTheoDK(string cot, string table)
    {
        cn.Open();
        string sql = "select "+ cot+" from " +table;
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        cn.Close();
        return dt;
    }
    protected void btn_select_ctsp_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string maSP = gv_chiTiet.Rows[row_chon].Cells[0].Text.ToString();
        string NSX = gv_chiTiet.Rows[row_chon].Cells[1].Text.ToString();
        string TH = gv_chiTiet.Rows[row_chon].Cells[2].Text.ToString();
        string SH = gv_chiTiet.Rows[row_chon].Cells[3].Text.ToString();
        string XX = gv_chiTiet.Rows[row_chon].Cells[4].Text.ToString();
        string GT = gv_chiTiet.Rows[row_chon].Cells[5].Text.ToString();
        string kinh = gv_chiTiet.Rows[row_chon].Cells[6].Text.ToString();
        string May = gv_chiTiet.Rows[row_chon].Cells[7].Text.ToString();
        string BHQT = gv_chiTiet.Rows[row_chon].Cells[8].Text.ToString();
        string BHTS = gv_chiTiet.Rows[row_chon].Cells[9].Text.ToString();
        string DK = gv_chiTiet.Rows[row_chon].Cells[10].Text.ToString();
        string DD = gv_chiTiet.Rows[row_chon].Cells[11].Text.ToString();
        string nieng = gv_chiTiet.Rows[row_chon].Cells[12].Text.ToString();
        string dayDeo = gv_chiTiet.Rows[row_chon].Cells[13].Text.ToString();
        string mauMat = gv_chiTiet.Rows[row_chon].Cells[14].Text.ToString();
        string chongNuoc = gv_chiTiet.Rows[row_chon].Cells[15].Text.ToString();
        string chucNang = gv_chiTiet.Rows[row_chon].Cells[16].Text.ToString();
        
        int index = 0;
        DataTable dt = new DataTable();
        //set vị trí cho dropdownLisst mã sản phẩm
        dt= selectTheoDK("ID_SP", "SANPHAM");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow d in dt.Rows)
            {
                if (d[0].ToString().Equals(maSP))
                    break;
                else
                    index++;
            }
        }
        ddl_maSP_CTSP.SelectedIndex = index; 
        //gán lại i = 0, set vị trí cho dropdownLisst cho nhà sản xuất
        index = 0;
        dt = selectTheoDK("tenNSX", "NSX");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow d in dt.Rows)
            {
                if (d[0].Equals(NSX))   
                    break;
                else
                    index++;
            }
        }
        ddl_NSX_CTSP.SelectedIndex = index;
        //gán lại i = 0, set vị trí cho dropdownLisst cho thuong hieu
        index = 0;
        dt = selectTheoDK("tenTH", "THUONGHIEU");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow d in dt.Rows)
            {
                if (d[0].Equals(TH))
                    break;
                else
                    index++;
            }
        }
        ddl_TH_CTSP.SelectedIndex = index;
        //gán lại i = 0, set vị trí cho dropdownLisst cho xuất xứ
        index = 0;
        dt = selectTheoDK("Distinct(XuatXu)", "CT_SANPHAM");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow d in dt.Rows)
            {
                if (d[0].Equals(XX))
                    break;
                else
                    index++;
            }
        }
        ddl_XX_CTSP.SelectedIndex = index;
        index = 0;
        dt = selectTheoDK("Distinct(May)", "CT_SANPHAM");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow d in dt.Rows)
            {
                if (d[0].Equals(May))
                    break;
                else
                    index++;
            }
        }
        ddl_BoMay_CTSP.SelectedIndex = index;

        //
        txt_soHieu.Text = SH;
        txt_BHQT.Text = BHQT;
        txt_BHTS.Text = BHTS;
        txt_DuongKinh.Text = DK;
        txt_DoDay.Text = BHQT;
        txt_ChucNang.Text = chucNang;
        var utf8Text = Utf8Encoder.GetString(Utf8Encoder.GetBytes(kinh));
        if (GT.Equals("Nam"))
            rbtnl_GT_CTSP.SelectedIndex = 0;
        else
            rbtnl_GT_CTSP.SelectedIndex = 1;



    }
    //Mã hóa kí tự Unicode
    private static readonly Encoding Utf8Encoder = Encoding.GetEncoding(
    "UTF-8",
    new EncoderReplacementFallback(string.Empty),
    new DecoderExceptionFallback()
    );

    
    //------------------------------------------------------------------------------------
    //Xử lý phiếu nhập
    public void layPhieuNhap()
    {
        cn.Open();
        string sql = "SELECT * from PHIEUNHAP,CT_PHIEUNHAP where PHIEUNHAP.MAPN = CT_PHIEUNHAP.MAPN";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        gv_PhieuNhap.DataSource = dt;
        gv_PhieuNhap.DataBind();
        cn.Close();
    }
    protected void btn_LuuPN1_PN_Click(object sender, EventArgs e)
    {
        cn.Open();
        string maNV = "";
        string tenDangNhap = "";
        if (Session["userNV"] != null && Session["passwordNV"] != null)
        {
             tenDangNhap = Session["userNV"].ToString();
             maNV = layMaNVTheoTenDangNhap(tenDangNhap);
        }
        string maPN = taoMaPhieuNhapTuDong();
        string sql = "insert into PHIEUNHAP values(@mapn,@manv,@ngayN)";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@mapn", maPN);
        lenh.Parameters.AddWithValue("@manv", maNV);
        lenh.Parameters.AddWithValue("@ngayN", DateTime.Now);
        lenh.ExecuteNonQuery();
        cn.Close();

        txt_maPN_PN.Text = maPN;
        txt_maNV_PN.Text = maNV;
        txt_ngayNhap_PN.Text = DateTime.Now.ToString();
        lb_tbPN_PN.Text = "Thêm phiếu nhập thành công. Mời nhập hàng vào ô bên dưới";
        //Đóng Phiếu nhập
        btn_LuuPN1_PN.Enabled = false;
        //Mở khóa thêm CT_PHIEUNHAP
        btn_luu_PN.Enabled = true;
        //btn_capNhat_PN.Enabled = true;
        btn_xoaTrang_PN.Enabled = true;
        btn_xong1PN.Enabled = true;

        layPhieuNhap();
        txt_maSP_PN.Focus();

        
    }
    protected void btn_xong1PN_Click(object sender, EventArgs e)
    {
        //Mở Phiếu nhập
        btn_LuuPN1_PN.Enabled = true;
        //Mở khóa thêm CT_PHIEUNHAP
        btn_luu_PN.Enabled = false;
        //btn_capNhat_PN.Enabled = false;
        btn_xoaTrang_PN.Enabled = false;
        btn_xong1PN.Enabled = false;
        lb_tbPN_PN.Text = "";
        btn_xoaTrang_PN_Click(sender, e);

        lb_tbThemCTPN.Text = "";
        xoaTrangPN();   
    }
    public string layMaNVTheoTenDangNhap(string tdn)
    {
        string sql = "select* from NHANVIEN where TenDangNhap = @tdn";
        
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tdn", tdn);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        return dt.Rows[0][0].ToString();
    }
    public void xoaTrangPN() 
    {
        txt_maPN_PN.Text = "";
        txt_maNV_PN.Text = "";
        txt_ngayNhap_PN.Text = "";
    }

    protected void btn_xoaTrang_PN_Click(object sender, EventArgs e)
    {
       
        txt_maSP_PN.Text = "";
        txt_soLuong_PN.Text = "";
        txt_donGia_PN.Text = "";

    }
    
    protected void btn_luu_PN_Click(object sender, EventArgs e)
    {
        
        if(txt_maSP_PN.Text.Equals(""))
        {
            txt_maSP_PN.Attributes.Add("placeholder","Không được để trống!");
            txt_maSP_PN.Focus();
        }
        else if(txt_soLuong_PN.Text.Equals(""))
        {
            txt_soLuong_PN.Attributes.Add("placeholder","Không được để trống!");
            txt_soLuong_PN.Focus();
        }
        else if (txt_donGia_PN.Text.Equals(""))
        {
            txt_donGia_PN.Attributes.Add("placeholder", "Không được để trống!");
            txt_donGia_PN.Focus();
        }
        else
        {
            if (ktraMaSP(txt_maSP_PN.Text) == 0 && ktraCTPNKhiThemCTPN(txt_maPN_PN.Text, txt_maSP_PN.Text) == 0)
            {
                string sql = "insert into CT_PHIEUNHAP values(@mapn,@idsp,@sl,@dg)";
                cn.Open();
                lenh = new SqlCommand(sql, cn);
                lenh.Parameters.Clear();
                lenh.Parameters.AddWithValue("@mapn", txt_maPN_PN.Text);
                lenh.Parameters.AddWithValue("@idsp", txt_maSP_PN.Text);
                lenh.Parameters.AddWithValue("@sl", txt_soLuong_PN.Text);
                lenh.Parameters.AddWithValue("@dg", txt_donGia_PN.Text);

                lenh.ExecuteNonQuery();
                cn.Close();
                lb_tbThemCTPN.Text = "Nhập thành công 1 sản phẩm. Tiếp tục";

                layPhieuNhap();
                btn_xoaTrang_PN_Click(sender, e);
                txt_maSP_PN.Focus();
            }
            else
            {
                lb_tbThemCTPN.Text = "Không tồn tại sản phẩm này hoặc đã nhập trước đó";
                txt_maSP_PN.Focus();
            }
        }
        btn_luu_PN.Enabled = true;
        //  btn_capNhat_PN.Enabled = true;
        btn_xoaTrang_PN.Enabled = true;
        btn_xong1PN.Enabled = true;
        


    }
    public int ktraCTPNKhiThemCTPN(string mapn, string masp)
    {
        string sql = "select* from CT_PHIEUNHAP where MAPN = @mapn and ID_SP = @idsp";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@mapn", mapn);
        lenh.Parameters.AddWithValue("@idsp", masp);

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        if (dt.Rows.Count > 0)
            return 1;
        return 0;
    }
        
    public string taoMaPhieuNhapTuDong()//Tạo mã Khach hàng tự động từ 'KH000000' -> 'KH999999'
    {
        string maPN = "";
        if (ktraPhieuNhapIsEmpty() == true)
            maPN = "PN000000";
        else
        {
            lenh.CommandText = "select MAX(right(MAPN,6)) from PHIEUNHAP";
            lenh.Parameters.Clear();
            DataTable dt = new DataTable();
            da.SelectCommand = lenh;
            da.Fill(dt);
            int ma = int.Parse(dt.Rows[0][0].ToString());
            int ma2 = ma + 1;
            if (ma >= 0 && ma < 9)
                maPN = "PN00000" + ma2.ToString();
            else if (ma >= 9 && ma < 99)
                maPN = "PN0000" + ma2.ToString();
            else if (ma >= 99 && ma < 999)
                maPN = "PN000" + ma2.ToString();
            else if (ma >= 999 && ma < 9999)
                maPN = "PN00" + ma2.ToString();
            else if (ma >= 9999 && ma < 99999)
                maPN = "PN0" + ma2.ToString();
            else
                maPN = "PN" + ma2.ToString();
        }

        return maPN;
    }
    public Boolean ktraPhieuNhapIsEmpty()
    {
        string sql = "SELECT * from PHIEUNHAP";

        lenh = new SqlCommand(sql, cn);
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
    //phân trang gridview
    protected void gv_chiTiet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_chiTiet.PageIndex = e.NewPageIndex;
        this.layChiTietSanPham();
    }
    protected void gv_sanPham_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_sanPham.PageIndex = e.NewPageIndex;
        this.laySanPham();
    }
    protected void gv_khachHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_khachHang.PageIndex = e.NewPageIndex;
        this.layKhachHang();
    }
    protected void gv_HoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_HoaDon.PageIndex = e.NewPageIndex;
        this.layHoaDon();
    }
    protected void gv_CTHDTheoMa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_CTHDTheoMa.PageIndex = e.NewPageIndex;
        this.layCTHDTheoMa(Admin.maHD);
    }
    protected void gv_hinhAnh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_hinhAnh.PageIndex = e.NewPageIndex;
        this.layImage();
    }
    protected void gv_thanhVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_thanhVien.PageIndex = e.NewPageIndex;
        this.layThanhVien();
    }
    protected void gv_PhieuNhap_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_PhieuNhap.PageIndex = e.NewPageIndex;
        this.layPhieuNhap();
    }
    //---------------------------------------------------------------------------------------
    protected void btn_capNhatSLCTHD_Click(object sender, EventArgs e)
    {

    }
    protected void btn_xoaSearch_Click(object sender, EventArgs e)
    {
        txt_searchNV.Text = "";
        layThanhVien();
    }
    protected void btn_xoaSearchKH_Click(object sender, EventArgs e)
    {
        txt_searchKH.Text = "";
        layKhachHang();
    }
    protected void btn_XoaSearchHD_Click(object sender, EventArgs e)
    {
        txt_searchHD.Text = "";
        layHoaDon();
    }

   
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txt_ngayThangNam.Text = c_ntn.SelectedDate.ToString("yyyy-MM-dd");

    }
    
    protected void rbl_locNTN_TK_TextChanged1(object sender, EventArgs e)
    {

        //if (rbl_gioiTinh.SelectedIndex == 0)
        //{
        //    txt_ngayThangNam.Visible = true;
        //    c_ntn.Visible = true;

        //    dl_ngayTK.Visible = false;
        //    dl_thangTK.Visible = false;
        //    dl_namTK.Visible = false;
        //}
        //else
        //{
        //    txt_ngayThangNam.Visible = false;
        //    c_ntn.Visible = false;

        //    dl_ngayTK.Visible = true;
        //    dl_thangTK.Visible = true;
        //    dl_namTK.Visible = true;
        //}
    }
    protected void btn_DonDatDMY_Click(object sender, EventArgs e)
    {
        if (txt_ngayThangNam.Text.Equals(""))
        {
            txt_ngayThangNam.Attributes.Add("placeholder", "Chưa có dữ liệu lọc");
            txt_ngayThangNam.Focus();
        }
        else
        {
            string DMY = txt_ngayThangNam.Text;
            cn.Open();
            string sql = "SELECT count(HOADON.MAHD),sum(soLuong) from HOADON,CT_HOADON where HOADON.MAHD=CT_HOADON.MAHD and NgayXuat like '%'+@nx+'%' ";

            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@nx", DMY);
            DataTable dt = new DataTable();
            da.SelectCommand = lenh;
            da.Fill(dt);
            cn.Close();
            
            lb_tbSlDonDatTK.Text = dt.Rows[0][0].ToString() + " hóa đơn trong ngày: " + DMY;
            if (dt.Rows[0][1].ToString().Equals(""))
                lb_slDaBan.Text = " 0 sản phẩm trong ngày:\n"+ DMY ;
            else
                lb_slDaBan.Text = dt.Rows[0][1].ToString() + " sản phẩm trong ngày:\n" + DMY;

        }
    }
    protected void btn_DonDatMY_Click(object sender, EventArgs e)
    {
        //string MY = dl_namTK.SelectedValue.ToString() + "-" + dl_thangTK.SelectedValue.ToString() + "-" + dl_ngayTK.SelectedValue.ToString();
        int thang = int.Parse(dl_thangTK.SelectedValue.ToString());
        int nam = int.Parse(dl_namTK.SelectedValue.ToString());
        cn.Open();
        string sql = "SELECT count(HOADON.MAHD),sum(soLuong) from HOADON,CT_HOADON where HOADON.MAHD=CT_HOADON.MAHD and Month(NgayXuat)=@t and Year(NgayXuat)=@n ";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@t", thang);
        lenh.Parameters.AddWithValue("@n", nam);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        cn.Close();

        lb_tbSlDonDatTK.Text = dt.Rows[0][0].ToString() + " hóa đơn trong tháng: " + thang.ToString() + "-" + nam.ToString();
        if (dt.Rows[0][1].ToString().Equals(""))
            lb_slDaBan.Text = " 0 sản phẩm trong tháng:" + thang.ToString() + "-" + nam.ToString();
        else
            lb_slDaBan.Text = dt.Rows[0][1].ToString() + " sản phẩm trong tháng:" + thang.ToString() + "-" + nam.ToString(); 
    }
    protected void btn_DonDatY_Click(object sender, EventArgs e)
    {
        int nam = int.Parse(dl_namTK2.SelectedValue.ToString());
        cn.Open();
        string sql = "SELECT count(HOADON.MAHD),sum(soLuong) from HOADON,CT_HOADON where HOADON.MAHD=CT_HOADON.MAHD and  Year(NgayXuat)=@n ";

        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@n", nam);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        cn.Close();

        lb_tbSlDonDatTK.Text = dt.Rows[0][0].ToString() + " hóa đơn trong năm: " + nam.ToString();
        if (dt.Rows[0][1].ToString().Equals(""))
            lb_slDaBan.Text = " 0 sản phẩm trong năm: " +  nam.ToString(); 
        else
            lb_slDaBan.Text = dt.Rows[0][1].ToString() + " sản phẩm trong năm: " + nam.ToString(); 
    }
    protected void btn_xoaNgayDatDon_Click(object sender, EventArgs e)
    {
        txt_ngayThangNam.Text = "";
        lb_tbSlDonDatTK.Text = "0 đơn";
        lb_slDaBan.Text = "0 sản phẩm";
    }

    protected void btn_all_Click(object sender, EventArgs e)
    {
        lb_slDaBan.Text = tongDaBan().ToString();
    }
    protected void btn_OkDT_Click(object sender, EventArgs e)
    {
        int vtD = dl_DDT.SelectedIndex;
        int vtM = dl_MDT.SelectedIndex;
        int vtY = int.Parse(dl_YDT.SelectedValue.ToString());
        DataTable dt2 = new DataTable();
        if (vtM == 0)
        {
            string sql = "select sum(CT_HOADON.soLuong*CT_HOADON.donGia - CT_PHIEUNHAP.donGia) "
                    + "from CT_HOADON,CT_PHIEUNHAP,SANPHAM,HOADON "
                    + " where CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_PHIEUNHAP.ID_SP=SANPHAM.ID_SP "
                    + " and HOADON.MAHD=CT_HOADON.MAHD and year(NgayXuat)=@n";
            cn.Open();
            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@n", vtY);
            da.SelectCommand = lenh;
            da.Fill(dt2);
        }
        else if (vtD == 0)
        {
            int valueM = int.Parse(dl_MDT.SelectedValue.ToString());
            string sql = "select sum(CT_HOADON.soLuong*CT_HOADON.donGia - CT_PHIEUNHAP.donGia) "
                    + "from CT_HOADON,CT_PHIEUNHAP,SANPHAM,HOADON "
                    + " where CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_PHIEUNHAP.ID_SP=SANPHAM.ID_SP "
                    + " and HOADON.MAHD=CT_HOADON.MAHD and month(NgayXuat) = @t and year(NgayXuat)=@n";
            cn.Open();
            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@t", valueM);
            lenh.Parameters.AddWithValue("@n", vtY);
            
            da.SelectCommand = lenh;
            da.Fill(dt2);
        }
        else
        {
            string sql = "select sum(CT_HOADON.soLuong*CT_HOADON.donGia - CT_PHIEUNHAP.donGia) "
                    + "from CT_HOADON,CT_PHIEUNHAP,SANPHAM,HOADON "
                    + " where CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_PHIEUNHAP.ID_SP=SANPHAM.ID_SP "
                    + " and HOADON.MAHD=CT_HOADON.MAHD and day(NgayXuat)=@ng and  month(NgayXuat)=@t and year(NgayXuat)=@n";
            cn.Open();
            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ng", int.Parse(dl_DDT.SelectedValue.ToString()));
            lenh.Parameters.AddWithValue("@t", int.Parse(dl_MDT.SelectedValue.ToString()));
            lenh.Parameters.AddWithValue("@n", vtY);
            da.SelectCommand = lenh;
            da.Fill(dt2);
        }
        cn.Close();
        if (dt2.Rows[0][0].ToString().Equals(""))
            lb_tbTongDoanhThu.Text = "0 đ";
        else
            lb_tbTongDoanhThu.Text = string.Format("{0:0,0} đ", int.Parse(dt2.Rows[0][0].ToString()));
    }
    protected void btn_XoaKH_Click(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        string maKH = gv_khachHang.Rows[row_chon].Cells[0].Text.ToString();
        if (ktraKhachHangDaDatHangTruocKhiXoa(maKH) == 1 || ktraKhachHangDaCoTKTruocKhiXoa(maKH) == 1)
        {
            lb_tbXoaKH.Text = "Không thể xóa vì Khách hàng này đã đặt hàng hoặc đã đăng ký thành viên ";
            lb_tbXoaKH.Focus(); 
        }
        else
        {
            string sql = "delete KHACHHANG where ID = @ma ";
            cn.Open();
            lenh = new SqlCommand(sql, cn);
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@ma", maKH);
            lenh.ExecuteNonQuery();
            cn.Close();
            layKhachHang();
            lb_tbXoaKH.Text = "";
        }
    }
    int ktraKhachHangDaDatHangTruocKhiXoa(string ma)
    {
        string sql = "select * from HOADON where MAKH = @ma";
        cn.Open();
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        DataTable dt2 = new DataTable();
        lenh.Parameters.AddWithValue("@ma", ma);
        da.SelectCommand = lenh;
        da.Fill(dt2);
        cn.Close();
        if (dt2.Rows.Count > 0)
            return 1;
        return 0;
    }
    int ktraKhachHangDaCoTKTruocKhiXoa(string ma)
    {
        string sql = "select * from KHACHHANG where ID = @ma";
        cn.Open();
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        DataTable dt2 = new DataTable();
        lenh.Parameters.AddWithValue("@ma", ma);
        da.SelectCommand = lenh;
        da.Fill(dt2);
        cn.Close();
        if (dt2.Rows[0][2].ToString().Equals(""))
            return 0;
        return 1;
    }
    protected void btnChonKH_Click1(object sender, EventArgs e)
    {
        int row_chon = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;//Chọn vị trí dòng trên gridView

        txt_MaKH_KH.Text = gv_khachHang.Rows[row_chon].Cells[0].Text.ToString();
        txt_tenKH_KH.Text = gv_khachHang.Rows[row_chon].Cells[1].Text.ToString();
        txt_username_KH.Text = gv_khachHang.Rows[row_chon].Cells[2].Text.ToString();
        txt_pass_KH.Text = gv_khachHang.Rows[row_chon].Cells[3].Text.ToString();
        txt_EmailKH_KH.Text = gv_khachHang.Rows[row_chon].Cells[5].Text.ToString();
        txt_DTKH_KH.Text = gv_khachHang.Rows[row_chon].Cells[6].Text.ToString();
        txt_DCKH_KH.Text = gv_khachHang.Rows[row_chon].Cells[7].Text.ToString();
        if (gv_khachHang.Rows[row_chon].Cells[4].Text.ToString().Equals("Nam"))
            rbl_gioiTinhKH.SelectedIndex = 0;
        else
            rbl_gioiTinhKH.SelectedIndex = 1;
        txt_username_KH.Enabled = false;
    }






    protected void btn_search_PN_Click(object sender, EventArgs e)
    {

    }

    //--------------------------------------------------------------------------------------------------
    //Xử lý trên view CTSP
    public void layDropdownList()
    {
        ddl_maSP_CTSP.Items.Clear();
        ddl_NSX_CTSP.Items.Clear();
        ddl_TH_CTSP.Items.Clear();
        ddl_XX_CTSP.Items.Clear();
        ddl_Kinh_CTSP.Items.Clear();
        ddl_Nieng_CTSP.Items.Clear();
        ddl_DayDeo_CTSP.Items.Clear();
        ddl_MauMatDH_CTSP.Items.Clear();
        ddl_MucChongNuoc_CTSP.Items.Clear();
        ddl_BoMay_CTSP.Items.Clear();

        string sql = "select ID_SP from SANPHAM";
        string sqlNSX = "select tenNSX from NSX";
        string sqlTH = "select tenTH from ThuongHieu";
        string sqlXX = "select  distinct(XuatXu) from CT_SANPHAM";
        string sqlK = "select  distinct(Kinh) from CT_SANPHAM";
        string sqlN = "select  distinct(Nieng) from CT_SANPHAM";
        string sqlDD = "select  distinct(DayDeo) from CT_SANPHAM";
        string sqlMay = "select  distinct(May) from CT_SANPHAM";


        cn.Open();
        lenh = new SqlCommand(sql, cn);
        lenh.Parameters.Clear();
        DataTable dt1 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        //Thêm dữ liệu cho dropdowList Mã sp
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_maSP_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList nhà sản xuất 
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlNSX, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_NSX_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList thương hiệu
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlTH, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_TH_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList xuất xứ
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlXX, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_XX_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList Mặt kính
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlK, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_Kinh_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList Niềng
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlN, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                if (!dr[0].ToString().Trim().Equals(""))
                    ddl_Nieng_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList Dây đeo
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlDD, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_DayDeo_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList Bộ máy
        dt1 = new DataTable();
        lenh = new SqlCommand(sqlMay, cn);
        lenh.Parameters.Clear();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                ddl_BoMay_CTSP.Items.Add(dr[0].ToString().Trim());
            }
        }
        //Thêm dữ liệu cho dropdowList mau mat DH
        ddl_MauMatDH_CTSP.Items.Add("Xanh");
        ddl_MauMatDH_CTSP.Items.Add("Trắng");
        ddl_MauMatDH_CTSP.Items.Add("Đen");
        ddl_MauMatDH_CTSP.Items.Add("Cam");
        ddl_MauMatDH_CTSP.Items.Add("Trắng xà cừ");
        ddl_MauMatDH_CTSP.Items.Add("Hồng");
        ddl_MauMatDH_CTSP.Items.Add("Đỏ");
        //Thêm dữ liệu cho dropdowList mức chống nước
        ddl_MucChongNuoc_CTSP.Items.Add("5");
        ddl_MucChongNuoc_CTSP.Items.Add("10");
        ddl_MucChongNuoc_CTSP.Items.Add("15");
        ddl_MucChongNuoc_CTSP.Items.Add("20");

        cn.Close();

    }
    void xoaTrangCTSP()
    {
        txt_BHQT.Text = "";
        txt_BHTS.Text = "";
        txt_ChucNang.Text = "";
        txt_DuongKinh.Text = "";
        txt_DoDay.Text = "";
        txt_soHieu.Text = "";
    }
    int timMaTH(string ten)
    {
        string sqlTH = "select maTH from THUONGHIEU where tenTH=@tth";
        cn.Open();
        lenh = new SqlCommand(sqlTH, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tth", ten);
        DataTable dt1 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        cn.Close();
        try
        {
             return int.Parse(dt1.Rows[0][0].ToString().Trim());
        }
        catch (Exception)
        {

            return 1;
        }
        
    }
    string timMaNSX(string ten)
    {
        string sqlTH = "select maNSX from NSX where tenNSX=@t";
        cn.Open();
        lenh = new SqlCommand(sqlTH, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@t", ten);
        DataTable dt1 = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt1);
        cn.Close();

        if (dt1.Rows.Count > 0)
            return dt1.Rows[0][0].ToString().Trim();
        return "1";
    }
    int ktraMaSP_CTSP(string maSP)
    {
        cn.Open();
        string kh = "SELECT ID_SP from CT_SANPHAM where ID_SP = @maSP";

        lenh = new SqlCommand(kh, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@maSP", maSP);

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập và ngược lại)
        if (dt.Rows.Count > 0)
        {
            cn.Close();
            return 1;//Tồn tại
        }

        cn.Close();

        return 0;//ko tồn tại
    }
    protected void btn_LuuCTSP_Click(object sender, EventArgs e)
    {

        string maSP = ddl_maSP_CTSP.SelectedValue.ToString();
        string NSX = timMaNSX(ddl_NSX_CTSP.SelectedValue.ToString());
        int thuongHieu = timMaTH(ddl_TH_CTSP.SelectedValue.ToString());
        string xuatXu = ddl_XX_CTSP.SelectedValue.ToString();
        string kinh = ddl_Kinh_CTSP.SelectedValue.ToString();
        string Nieng = ddl_Nieng_CTSP.SelectedValue.ToString();
        string dayDeo = ddl_DayDeo_CTSP.SelectedValue.ToString();
        string mau = ddl_MauMatDH_CTSP.SelectedValue.ToString();
        string chongNuoc = ddl_MucChongNuoc_CTSP.SelectedValue.ToString();
        string boMay = ddl_BoMay_CTSP.SelectedValue.ToString();
        string soHieu = txt_soHieu.Text.Trim();
        int BHQT = 1, BHTS = 1;
        float DK = 0, doDay = 0;
        //Kiểm tra nhập số nguyên
        try
        {
            BHQT = int.Parse(txt_BHQT.Text.Trim());
        }
        catch (Exception)
        {
            lb_tbCTSP.Text = "Nhập không hợp lệ";
            txt_BHQT.Focus();
            return;
        }
        try
        {
            BHTS = int.Parse(txt_BHTS.Text.Trim());
        }
        catch (Exception)
        {
            lb_tbCTSP.Text = "Nhập không hợp lệ";
            txt_BHTS.Focus();
            return;
        }
        try
        {
            DK = float.Parse(txt_DuongKinh.Text.Trim());
        }
        catch (Exception)
        {
            lb_tbCTSP.Text = "Nhập không hợp lệ";
            txt_DuongKinh.Focus();
            return;
        }
        try
        {
            doDay = float.Parse(txt_DoDay.Text.Trim());
        }
        catch (Exception)
        {
            lb_tbCTSP.Text = "Nhập không hợp lệ";
            txt_DoDay.Focus();
            return;
        }
        string chucNang = txt_ChucNang.Text.Trim();
        string gioiTinh = rbtnl_GT_CTSP.SelectedValue.ToString();

        //txt_BHQT.Text = thuongHieu.ToString();

        if (ktraMaSP(maSP) == 1)
        {
            if (ktraMaSP_CTSP(maSP) == 1)
                lb_tbCTSP.Text = "Lỗi: Mã '" + maSP + "' đã có trong chi tiết sản phẩm.";
            else
            {
                cn.Open();
                string sql = "INSERT INTO CT_SANPHAM VALUES(@masp,@maNSX,@maTH,@soHieu,@xuatXu,@gioiTinh,@kinh,@may,@bhqt,@bhts,@dkm,@ddm,@nieng,@dayDeo,@mms,@cn,@cnang)";

                lenh = new SqlCommand(sql, cn);
                lenh.Parameters.Clear();
                lenh.Parameters.AddWithValue("@masp", maSP);
                lenh.Parameters.AddWithValue("@maNSX", NSX);
                lenh.Parameters.AddWithValue("@maTH", thuongHieu);
                lenh.Parameters.AddWithValue("@soHieu", soHieu);
                lenh.Parameters.AddWithValue("@xuatXu", xuatXu);
                lenh.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                lenh.Parameters.AddWithValue("@kinh", kinh);
                lenh.Parameters.AddWithValue("@may", xuatXu);
                lenh.Parameters.AddWithValue("@bhqt", BHQT);
                lenh.Parameters.AddWithValue("@bhts", BHTS);
                lenh.Parameters.AddWithValue("@dkm", DK);
                lenh.Parameters.AddWithValue("@ddm", doDay);
                lenh.Parameters.AddWithValue("@nieng", Nieng);
                lenh.Parameters.AddWithValue("@dayDeo", dayDeo);
                lenh.Parameters.AddWithValue("@mms", mau);
                lenh.Parameters.AddWithValue("@cn", chucNang);
                lenh.Parameters.AddWithValue("@cnang", chongNuoc);

                lenh.ExecuteNonQuery();
                cn.Close();
                layChiTietSanPham();
                lb_tbCTSP.Text = "Thêm Thành Công";
            }
        }
        else
            lb_tbCTSP.Text = "Sản phẩm không tồn tại";


    }
    protected void btn_xoaTrangCTSP_Click(object sender, EventArgs e)
    {
        xoaTrangCTSP();
    }
    
}