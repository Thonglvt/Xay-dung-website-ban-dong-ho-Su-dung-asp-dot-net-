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

public partial class DangNhap : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = null;
    SqlDataAdapter da = new SqlDataAdapter();
    HamXuLy hxl = new HamXuLy();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_user.Attributes.Add("placeholder", "Tài khoản");
        txt_password.Attributes.Add("placeholder", "Mật khẩu");
        if (hxl.KtraDangNhap == true)
        {
            btn_dangNhap.Visible = false;
            lb_tbDangNhap.Text = "Chào: " + hxl.Username;
        }
    }

    protected void btn_dangNhap_Click(object sender, EventArgs e)
    {
        string user = txt_user.Text.ToString();
        string pass = txt_password.Text.ToString();
        if (user.Equals(""))
        {
            txt_user.Text = "";
            txt_user.Attributes.Add("placeholder", "Không được để trống");
            txt_user.Focus();
        }
        if (pass.Equals(""))
        {
            txt_password.Text = "";
            txt_password.Attributes.Add("placeholder", "Không được để trống");
            txt_password.Focus();
        }
        
        if (ktraTenDangNhap(user, pass) == 0)
        {
            hxl.KtraDangNhap = true;

            Session["login"] = (HamXuLy)hxl;

            Response.Redirect("TrangChu.aspx");
            //Page.Response.Redirect("TrangChu.aspx", true);
            
        }
        else
        {
            lb_tbDangNhap.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
            txt_password.Text = "";
            txt_password.Focus();
        }

    }
    int ktraTenDangNhap(string tenDangNhap, string pass)
    {
        cn.Open();
        string ad = "SELECT top(1)* from KHACHHANG where USERNAME = @tenDangNhap and PASSWORD_= @pass";

        lenh = new SqlCommand(ad, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        lenh.Parameters.AddWithValue("@pass", pass);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);

        //Kiểm tra bảng trả về có dữ liệu hay ko (nếu có: thì đã tồn tại tên đăng nhập, password và ngược lại)
        if (dt.Rows.Count > 0)
        {
            cn.Close();
            foreach (DataRow d in dt.Rows)
            {
                hxl.MaKH = d[0].ToString();
                hxl.TenKH = d[1].ToString();
                hxl.Username = tenDangNhap;
                hxl.PassWord = pass;
                hxl.GioiTinh = d[4].ToString();
                hxl.Email = d[5].ToString();
                hxl.DienThoai = d[6].ToString();
                hxl.DiaChi = d[7].ToString();
            }
            return 0;
        }

        cn.Close();
        return 1;
    }
}