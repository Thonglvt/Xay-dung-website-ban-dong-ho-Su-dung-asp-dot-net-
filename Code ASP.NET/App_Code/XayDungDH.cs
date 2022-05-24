using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for XayDungDH
/// </summary>
/// 
namespace App_Code
{
    public class XayDungDH
    {
        public DataTable gioHang = new DataTable();
        public XayDungDH()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public void createItem()
        {
            gioHang.Columns.Add("Ma");
            gioHang.Columns.Add("hinh");
            gioHang.Columns.Add("tenSanPham");
            gioHang.Columns.Add("gia");
            gioHang.Columns.Add("soLuong");
        }
        //Them sp vao gio hang
        public Boolean insertSP(string ma, string hinh, string ten, int gia, int soLuong)
        {

            Boolean flag = false;
            foreach (DataRow d in gioHang.Rows)
            {
                if (d[0].ToString() == ma)
                {
                    d[4] = int.Parse(d[4].ToString()) + soLuong;
                    flag = true;
                }
            }
            if (flag == false)
            {
                DataRow d = gioHang.NewRow();
                d[0] = ma;
                d[1] = hinh;
                d[2] = ten;
                d[3] = gia;
                d[4] = soLuong;
                gioHang.Rows.Add(d);
                return true;
            }
            return false;
        }
        public Boolean delete(string ma)
        {
            foreach (DataRow dr in gioHang.Rows)
            {
                if (dr[0].Equals(ma))
                {
                    gioHang.Rows.Remove(dr);
                   
                    return true;
                }
            }
            
            return false;
        }
        public int tinhTongTien()
        {
            int a = 0;
            foreach (DataRow d in gioHang.Rows)
            {
                a += int.Parse(d[3].ToString()) * int.Parse(d[4].ToString());
            }

            return a;
        }
    }

    //for (int i = gioHang.Rows.Count - 1; i >= 0; i--)
    //{
    //    DataRow dr = gioHang.Rows[i];
    //    if (dr[0].ToString().Equals(ma))
    //        dr.Delete();
    //}
    //gioHang.AcceptChanges();
}
