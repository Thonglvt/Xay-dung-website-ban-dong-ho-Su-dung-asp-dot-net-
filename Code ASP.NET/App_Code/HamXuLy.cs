using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HamXuLy
/// </summary>
public class HamXuLy
{
    protected string username, passWord, maKH, tenKH, gioiTinh, email, dienThoai, diaChi;

    public string DienThoai
    {
        get { return dienThoai; }
        set { dienThoai = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string GioiTinh
    {
        get { return gioiTinh; }
        set { gioiTinh = value; }
    }

    public string DiaChi
    {
        get { return diaChi; }
        set { diaChi = value; }
    }

    public string TenKH
    {
        get { return tenKH; }
        set { tenKH = value; }
    }

    public string MaKH
    {
        get { return maKH; }
        set { maKH = value; }
    }
    

    public string PassWord
    {
        get { return passWord; }
        set { passWord = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    protected bool ktraDangNhap = false;

    public bool KtraDangNhap
    {
        get { return ktraDangNhap; }
        set { ktraDangNhap = value; }
    }

	public HamXuLy()
	{
        this.TenKH = "";
        this.Username = "";
        this.PassWord = "";
        this.GioiTinh = "";
        this.Email = "";
        this.DienThoai = "";
        this.DiaChi = "";
        
	}
    public HamXuLy(string us,string pw)
    {
        this.Username = us;
        this.PassWord = pw;
    }
    public HamXuLy(string maKH,string hoten, string user, string pass, string gt, string email, string dt, string diachi)
    {
        this.MaKH = maKH;
        this.TenKH = hoten;
        this.Username = user;
        this.PassWord = pass;
        this.GioiTinh = gt;
        this.Email = email;
        this.DienThoai = dt;
        this.DiaChi = diachi;
    }

    public bool kTraNamNhuan(int nYear)
    {
        if ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0)
        {
            return true;
        }
        return false;

        // <=> return ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0);
    }

    // Hàm trả về số ngày trong tháng thuộc năm cho trước
    public int tinhSoNgayTrongThang(int nMonth, int nYear)
    {
        int nNumOfDays = 0;
        switch (nMonth)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                nNumOfDays = 31;
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                nNumOfDays = 30;
                break;
            case 2:
                if (kTraNamNhuan(nYear))
                {
                    nNumOfDays = 29;
                }
                else
                {
                    nNumOfDays = 28;
                }
                break;
        }

        return nNumOfDays;
    }

    // Hàm kiểm tra ngày dd/mm/yyyy cho trước có phải là ngày hợp lệ
    public bool kTraNgayHopLe(int nDay, int nMonth, int nYear)
    {
        // Kiểm tra năm
        if (nYear < 0)
        {
            return false; // Ngày không còn hợp lệ nữa!
        }

        // Kiểm tra tháng
        if (nMonth < 1 || nMonth > 12)
        {
            return false; // Ngày không còn hợp lệ nữa!
        }

        // Kiểm tra ngày
        if (nDay < 1 || nDay > tinhSoNgayTrongThang(nMonth, nYear))
        {
            return false; // Ngày không còn hợp lệ nữa!
        }

        return true; // Trả về trạng thái cuối cùng...
    }
}