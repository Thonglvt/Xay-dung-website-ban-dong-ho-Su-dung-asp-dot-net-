using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Loc : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    SqlCommand lenh = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (cn.State == ConnectionState.Open)
        //    Response.Write("Connected Successfully");
        cn.Open();
        lenh.Connection = cn;
        lenh.CommandType = CommandType.Text;

        if (!IsPostBack)
        {
            string th = "", mk = "", bm = "", mms = "", mcn = "";
            int min_gia = 0, max_gia = 0, min_kt = 0, max_kt = 0;
            if (Session["thuonghieu"] != null)
            {
                th = Session["thuonghieu"].ToString();
            }
            if (Session["matkinh"] != null)
            {
                mk = Session["matkinh"].ToString();
            }
            if (Session["bomay"] != null)
            {
                bm = Session["bomay"].ToString();
            }
            if (Session["maumatso"] != null)
            {
                mms = Session["maumatso"].ToString();
            }
            if (Session["chongnuoc"] != null)
            {
                mcn = Session["chongnuoc"].ToString();
            }
            if (Session["startgia"] != null)
            {
                min_gia = int.Parse(Session["startgia"].ToString());
            }
            if (Session["endgia"] != null)
            {
                max_gia = int.Parse(Session["endgia"].ToString());
            }
            if (Session["startKT"] != null)
            {
                min_kt = int.Parse(Session["startKT"].ToString());
            }
            if (Session["endKT"] != null)
            {
                max_kt = int.Parse(Session["endKT"].ToString());
            }
            napDuLieuLoc(th, mk, bm, mms, mcn, min_gia, max_gia, min_kt, max_kt);
        }
        cn.Close();
    }
    void napDuLieuLoc(string th, string mk,string bm,string mms,string mcn,int min_gia,int max_gia,int minkt,int maxkt)
    {
        string w_th;
        string w_mk;
        string w_bm;
        string w_mms;
        string w_mcn;
        string w_mg;
        string w_kt;
        if (th.Equals(""))
            w_th = "";
        else
            w_th = " and tenTH = @th ";
        if (mk.Equals(""))
            w_mk = "";
        else
            w_mk = " and Kinh = @kinh ";
        if (bm.Equals(""))
            w_bm = "";
        else
            w_bm = " and May = @may ";
        if (mms.Equals(""))
            w_mms = "";
        else
            w_mms = " and MauMatSo = @mau ";
        if (mcn.Equals(""))
            w_mcn = "";
        else
            w_mcn = " and ChongNuoc = @mcn ";
        if (max_gia == 0)
            w_mg = "";
        else
            w_mg = " and CAST(RETAIL_PRICE AS int) between @sg and @eg ";
        if (maxkt == 0)
            w_kt = "";
        else
            w_kt = " and DK_Mat between @skt and @ekt ";


        //lenh.CommandText = "Select SANPHAM.* from SANPHAM,CT_SANPHAM where SANPHAM.ID_SP=CT_SANPHAM.ID_SP " + w_th + w_mg + w_mk + w_bm + w_mms;
        lenh.CommandText = "Select * from SANPHAM,CT_SANPHAM,THUONGHIEU where SANPHAM.ID_SP=CT_SANPHAM.ID_SP and " 
                        +"THUONGHIEU.maTH=CT_SANPHAM.maTH " + w_th + w_mk + w_bm + w_mms + w_mcn + w_mg + w_kt;
        lenh.Parameters.Clear();
        lenh.Parameters.AddWithValue("@th", th);
        lenh.Parameters.AddWithValue("@kinh", mk);
        lenh.Parameters.AddWithValue("@may", bm);
        lenh.Parameters.AddWithValue("@mau", mms);
        lenh.Parameters.AddWithValue("@mcn", mcn);
        lenh.Parameters.AddWithValue("@sg", min_gia);
        lenh.Parameters.AddWithValue("@eg", max_gia);
        lenh.Parameters.AddWithValue("@skt", minkt);
        lenh.Parameters.AddWithValue("@ekt", maxkt);
        DataTable dt = new DataTable();
        da.SelectCommand = lenh;
        da.Fill(dt);
        dl_Loc.DataSource = dt;
        dl_Loc.DataBind();
    }
}