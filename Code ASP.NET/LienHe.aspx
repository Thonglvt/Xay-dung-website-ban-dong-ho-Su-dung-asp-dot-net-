<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="LienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center; font-size:35px; color:#ec0808;position:absolute;top:509px; left:629px; height: 36px;">HỆ THỐNG CỬA HÀNG </div><br />
    <div style="margin-top:150px;margin-left:200px;margin-right:300px">
        <div class="row">
            <div class="col-md-4" style="float:left">
                <img src="img/Cuahang.jpg" style="height:200px; width:300px; top:700px;" />
             </div>
            <div class="col-md-8" style="float:right" >
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold  >Chi Nhánh: </asp:Label>
                <a>48 Bùi Thị Xuân , Tân Bình , Thành Phố Hồ Chí Minh </a><br />
                <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold>Điện Thoại: </asp:Label>
                <a>1900.6666</a><br />
                <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold>Mail: </asp:Label>
                <a>shopdonghotnt@gmail.com</a>
            </div>
        </div>
    </div>
</asp:Content>

