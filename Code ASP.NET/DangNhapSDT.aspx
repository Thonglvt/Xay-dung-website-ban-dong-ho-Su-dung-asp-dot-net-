<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="DangNhapSDT.aspx.cs" Inherits="DangNhapSDT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:300px;width:400px; background-color:#f8f8f8; margin-left:400px; text-align:center; padding-top:30px; border-radius:10px;">
       
        <asp:Label ID="Label1" runat="server" Text="Đăng Nhập" Font-Size="X-Large"></asp:Label><br /><br />
        <asp:TextBox ID="txt_user" runat="server" Width="300px" Height="33px"></asp:TextBox><br /><br />
        <asp:TextBox ID="txt_password" runat="server" Width="300px" Height="33px" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Button ID="btn_dangNhap" runat="server" Text="ĐĂNG NHẬP"  CssClass="button" OnClick="btn_dangNhap_Click"/><br />
        <asp:Label ID="lb_tbDangNhap" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

