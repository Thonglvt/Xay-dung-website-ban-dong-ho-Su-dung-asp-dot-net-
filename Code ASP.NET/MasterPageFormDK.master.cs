using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
public partial class MasterPageFormDK : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hyp_user.Visible = false;
        btn_dangXuat.Visible = false;
        txt_search.Attributes.Add("placeholder", "Tìm kiếm sản phẩm");
        HamXuLy hxl = (HamXuLy)Session["login"];

        if (hxl != null && hxl.KtraDangNhap == true)
        {
            hyp_user.Visible = true;
            hyp_user.Text = hxl.Username;
            btn_dangXuat.Visible = true;
            btn_dangNhap.Visible = false;
            btn_dangKy.Visible = false;
        }
        if (Session["cart"] == null)
        {
            XayDungDH cart = new XayDungDH();
            cart.createItem();
            Session["cart"] = cart;
        }
        
    }
    
    protected void imgb_search_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Search.aspx?search=" + txt_search.Text.ToString());
    }
    protected void btn_dangNhap_Click(object sender, EventArgs e)
    {
        Response.Redirect("DangNhap.aspx");
    }
    protected void btn_dangKy_Click(object sender, EventArgs e)
    {
        Response.Redirect("DangKi.aspx");
    }
    protected void btn_dangXuat_Click(object sender, EventArgs e)
    {
        hyp_user.Text = "";
        hyp_user.Visible = false;
        btn_dangXuat.Visible = false;
        btn_dangNhap.Visible = true;
        btn_dangKy.Visible = true;

        
        Session["login"] = null;
        Response.Redirect("TrangChu.aspx");
        
    }
}
