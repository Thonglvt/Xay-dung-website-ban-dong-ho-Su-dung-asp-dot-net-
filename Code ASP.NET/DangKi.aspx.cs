using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class DangKi : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = null;
    SqlDataAdapter da = new SqlDataAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (txt_hoten.Text.ToString().Equals("") )
        {
            txt_hoten.Attributes.Add("placeholder", "Không được để trống");
            txt_hoten.Focus();
        }
        else if (txt_tenDangNhap.Text.ToString().Equals("") )
        {
            txt_tenDangNhap.Focus();
            txt_tenDangNhap.Attributes.Add("placeholder", "Không được để trống");
        }

        else if (txt_pass.Text.ToString().Equals(""))
        {
            txt_pass.Focus();
            txt_pass.Attributes.Add("placeholder", "Không được để trống");
        }

        else if (txt_repass.Text.ToString().Equals(""))
        {
            txt_repass.Focus();
            txt_repass.Attributes.Add("placeholder", "Không được để trống");
        }

        else if (txt_sdt.Text.ToString().Equals(""))
        {
            txt_sdt.Focus();
            txt_sdt.Attributes.Add("placeholder", "Không được để trống");
        }
        else
        {
            string tenDangNhap = txt_tenDangNhap.Text.ToString();
            //if (ktraUserName(us) == 0)
            //{
            //    txt_tenDangNhap.Text = "";
            //    lb_tbao.Text = "Tên đăng nhập đã tồn tại";
            //    txt_tenDangNhap.Focus();
            //}
            //else
            //{
            //    MultiView1.ActiveViewIndex = 1;
            //    lb_hoten.Text = txt_hoten.Text;
            //    lb_TenDangNhap.Text = txt_tenDangNhap.Text;
            //    lb_pass.Text = txt_pass.Text;
            //    lb_gioiTinh.Text = rbl_gioiTinh.SelectedValue;
            //    lb_Email.Text = txt_email.Text;
            //    lb_dienThoai.Text = txt_sdt.Text;
            //    lb_diaChi.Text = txt_diaChi.Text;
            //}
            if(ktraTenDangNhap(tenDangNhap) == 0)
            {
                txt_tenDangNhap.Text = "";
                lb_tbao.Text = "Tên đăng nhập đã tồn tại";
                txt_tenDangNhap.Focus();
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
                lb_hoten.Text = txt_hoten.Text;
                lb_TenDangNhap.Text = txt_tenDangNhap.Text;
                lb_pass.Text = txt_pass.Text;
                lb_gioiTinh.Text = rbl_gioiTinh.SelectedValue;
                lb_Email.Text = txt_email.Text;
                lb_dienThoai.Text = txt_sdt.Text;
                lb_diaChi.Text = txt_diaChi.Text;
            }
        }
    }
    protected void btn_quayLai_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        themKhachHang();
        MultiView1.ActiveViewIndex = 2;
        //Response.Write("Thêm thành công");
    }
    void themKhachHang()
    {
        cn.Open();
        string maKH= taoMaKhachHangTuDong();
        string kh = "INSERT INTO KHACHHANG(ID,HOTEN,USERNAME,PASSWORD_,GIOITINH,EMAIL,PHONE,DIACHI) VALUES(@ID,@HT,@UN,@PW,@GT,@EM,@P,@DC)";
        lenh = new SqlCommand(kh,cn);
        lenh.Parameters.AddWithValue("@ID", maKH);
        lenh.Parameters.AddWithValue("@HT", lb_hoten.Text.ToString());
        lenh.Parameters.AddWithValue("@UN", txt_tenDangNhap.Text.ToString());
        lenh.Parameters.AddWithValue("@PW", lb_pass.Text.ToString());
        lenh.Parameters.AddWithValue("@GT", lb_gioiTinh.Text.ToString());
        lenh.Parameters.AddWithValue("@EM", lb_Email.Text.ToString());
        lenh.Parameters.AddWithValue("@P", lb_dienThoai.Text.ToString());
        lenh.Parameters.AddWithValue("@DC", lb_diaChi.Text.ToString());

        lenh.ExecuteNonQuery();
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
    //int ktraUserName(string us)
    //{
    //    foreach (ListItem li in ddl_username.Items)
    //    {
    //        if (txt_tenDangNhap.Text.Equals(li.Text.ToString()))
    //        {
    //            return 0;
    //        }
    //    }
    //    return 1;
    //}
    int ktraTenDangNhap(string tenDangNhap)
    {
        cn.Open();
        string kh = "SELECT USERNAME,PASSWORD_ from KHACHHANG where USERNAME = @tenDangNhap";
        
        lenh = new SqlCommand(kh, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        
        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập và ngược lại)
        if (dt.Rows.Count > 0)
        {
            cn.Close();
            return 0;
        }

        cn.Close();
        return 1;
    }
}