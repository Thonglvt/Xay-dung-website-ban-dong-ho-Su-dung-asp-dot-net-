using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
public partial class MasterPage : System.Web.UI.MasterPage
{
    HamXuLy hxl = new HamXuLy();
    
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
    protected void btn_loc_Click(object sender, EventArgs e)
    {
        //int vt_thuongHieu = ddl_thuongHieu.SelectedIndex;
        int vt_thuongHieu = cbl_ThuongHieu.SelectedIndex;
        int vt_matKinh = cbl_Kinh.SelectedIndex;
        int vt_boMay = cbl_May.SelectedIndex;
        int vt_mauMatSo = cbl_MauMatSo.SelectedIndex;     
        int vt_chongNuoc = cbl_MucChongNuoc.SelectedIndex;
        int vt_chucNang = cbl_TinhNang.SelectedIndex;
        int vtMucGia = cbl_MucGia.SelectedIndex;
        int startGia = 0, endGia = 0;
        int vt_kt = cbl_kichThuocMatSo.SelectedIndex;
        int startKT = 0, endKT = 0;

        string thuongHieu, matKinh, boMay, mauMatSo, chongNuoc, chucNang;
        if (vt_thuongHieu < 0)
            thuongHieu = "";
        else
            thuongHieu = cbl_ThuongHieu.SelectedValue.ToString();
        if (vt_matKinh < 0)
            matKinh = "";
        else
            matKinh = cbl_Kinh.SelectedValue.ToString();
        if (vt_boMay < 0)
            boMay = "";
        else
            boMay = cbl_May.SelectedValue.ToString();
        if (vt_mauMatSo < 0)
            mauMatSo = "";
        else
            mauMatSo = cbl_MauMatSo.SelectedValue.ToString();
        if (vt_chongNuoc< 0)
            chongNuoc = "";
        else
            chongNuoc = cbl_MucChongNuoc.SelectedValue.ToString();
        if (vt_chucNang < 0)
            chucNang = "";
        else
            chucNang = cbl_TinhNang.SelectedValue.ToString();
        //Mức giá
        if (vtMucGia < 0)
        {
            startGia = 0;
            endGia = 0;
        }
        else if (vtMucGia == 0)
            endGia = 2000000;
        else if (vtMucGia == 1)
        {
            startGia = 2000000;
            endGia = 4000000;
        }
        else if (vtMucGia == 2)
        {
            startGia = 4000000;
            endGia = 6000000;
        }
        else if (vtMucGia == 3)
        {
            startGia = 6000000;
            endGia = 8000000;
        }
        else if (vtMucGia == 4)
        {
            startGia = 8000000;
            endGia = 10000000;
        }
        else if (vtMucGia == 5)
        {
            startGia = 10000000;
            endGia = 20000000;
        }
        else if (vtMucGia == 6)
        {
            startGia = 20000000;
            endGia = 30000000;
        }
        else
        {
            startGia = 30000000;
            endGia = 40000000;
        }
        //kích thước
        if(vt_kt < 0)
        {
            startKT = 0;
            endKT = 0;
        }
        else if (vt_kt == 0)
        {
            endKT = 29;
        }
        else if (vt_kt == 1)
        {
            startKT = 30;
            endKT = 34;
        }
        else if (vt_kt == 2)
        {
            startKT = 35;
            endKT = 39;
        }
        else if (vt_kt == 3)
        {
            startKT = 40;
            endKT = 43;
        }
        else
        {
            startKT = 44;
            endKT = 999;
        }
        //string thuongHieu = cbl_ThuongHieu.SelectedValue.ToString();
        //int startGia = 0, endGia = 0;
        //string matKinh = cbl_Kinh.SelectedValue.ToString();
        //string boMay = cbl_May.SelectedValue.ToString();
        //string mauMatSo = cbl_MauMatSo.SelectedValue.ToString();
        //float startKT = 0, endKT = 0;
        //string chongNuoc = cbl_MucChongNuoc.SelectedValue.ToString();
        //string chucNang = cbl_TinhNang.SelectedValue.ToString();

        Session["thuonghieu"] = thuongHieu;
        Session["startgia"] = startGia;
        Session["endgia"] = endGia;
        Session["matkinh"] = matKinh;
        Session["bomay"] = boMay;
        Session["maumatso"] = mauMatSo;
        Session["startKT"] = startKT;
        Session["endKT"] = endKT;
        Session["chongnuoc"] = chongNuoc;
        //Session["chucnang"] = chucNang;

        Response.Redirect("Loc.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
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
    protected void imgb_search_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Search.aspx?search=" + txt_search.Text.ToString());
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
