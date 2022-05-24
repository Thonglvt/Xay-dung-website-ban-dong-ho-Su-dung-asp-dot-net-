<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form_dangNhap">
       
        <asp:Label ID="Label1" runat="server" Text="Đăng Nhập" Font-Size="X-Large"></asp:Label><br /><br />
        <asp:TextBox ID="txt_user" runat="server" Width="300px" Height="33px"></asp:TextBox><br /><br />
        <asp:TextBox ID="txt_password" runat="server" Width="300px" Height="33px" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Button ID="btn_dangNhap" runat="server" Text="ĐĂNG NHẬP"  CssClass="button" OnClick="btn_dangNhap_Click"/><br />
        <asp:Label ID="lb_tbDangNhap" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        <table class="table_dn">
            <tr>
                <td style="text-align:left;"><a href="#">Quên mật khẩu</a></td>
                <td ><a href="DangNhapSDT.aspx" style="padding-left:60px;">Đăng nhập với SĐT</a></td>
            </tr>
        </table>
        <p class="opa_">------------------------HOẶC------------------------</p>
        <table class="table_dn" cellpadding="7">
            <tr>
                <td class="fb">
                    <asp:ImageButton CssClass="imgb_1" ID="ImageButton1" runat="server" ImageUrl="~/img/fb.jpg" Width="90px" Height="40px" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" /></td>
                <td class="fb">
                    <asp:ImageButton CssClass="imgb_1" ID="ImageButton4" runat="server" ImageUrl="~/img/zalo.png" Width="90px" Height="40px" /></td>
                <td class="fb">
                    <asp:ImageButton CssClass="imgb_1" ID="ImageButton2" runat="server" ImageUrl="~/img/gg.jpg" Width="90px" Height="40px" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"  /></td>
            </tr>
        </table><br />
        <span class="opa_">Bạn chưa có tài khoản?</span> <a style="color:#ef3e19;" href="DangKi.aspx">Đăng ký</a>
    </div>
    
</asp:Content>

