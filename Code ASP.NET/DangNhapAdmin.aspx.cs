using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class DangNhapAdmin : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = null;
    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    int ktraTenDangNhap(string tenDangNhap,string pass)
    {
        cn.Open();
        string ad = "SELECT TenDangNhap,password_ from NHANVIEN where TenDangNhap = @tenDangNhap and password_= @pass";

        lenh = new SqlCommand(ad, cn);
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        lenh.Parameters.AddWithValue("@pass", pass);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ktraTenDangNhap(txt_user.Text, txt_password.Text) == 1)
        {
            lb_tbadmin.Text = "Bạn không phải Admin";
            txt_password.Text = "";
            txt_password.Focus();
        }
        else
        {
            Session["userNV"] = txt_user.Text;
            Session["passwordNV"] = txt_password.Text;
            Response.Redirect("Admin.aspx");
        }
    }
}