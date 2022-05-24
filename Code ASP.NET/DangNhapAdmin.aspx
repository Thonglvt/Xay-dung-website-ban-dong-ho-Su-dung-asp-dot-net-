<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="DangNhapAdmin.aspx.cs" Inherits="DangNhapAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form_dangNhapAdmin">
       
        <asp:Label ID="Label1" runat="server" Text="Đăng Nhập Dành Cho Admin" Font-Size="X-Large"></asp:Label><br /><br />
        <asp:TextBox ID="txt_user" runat="server" Width="300px" Height="33px"></asp:TextBox><br /><br />
        <asp:TextBox ID="txt_password" runat="server" Width="300px" Height="33px" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Button CssClass="button" ID="Button1" runat="server" Text="ĐĂNG NHẬP" OnClick="Button1_Click" />
        <br /><asp:Label ID="lb_tbadmin" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

