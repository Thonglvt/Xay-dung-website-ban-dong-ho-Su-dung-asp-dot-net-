<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GioHang.aspx.cs" Inherits="GioHang"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="float:left;margin:500px 0px 0px 400px; text-align:center; position:absolute;top:0">
        <span style="font-size: 30px">GIỎ HÀNG</span><br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/TrangChu.aspx">Trang chủ</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" ForeColor="#CCCCCC">/Giỏ hàng</asp:HyperLink>
        <br /><br />
        <asp:GridView ID="gv_gioHang" runat="server" AutoGenerateColumns="False" style="margin-top: 0px" Width="628px">
            <Columns>
                <asp:BoundField DataField="Ma" HeaderText="Mã" />
                <asp:ImageField DataImageUrlField="hinh">
                    <ControlStyle Height="150px" Width="150px" />
                </asp:ImageField>
                <asp:BoundField HeaderText="SẢN PHẨM" DataField="tenSanPham" >
                <ControlStyle Width="500px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="GIÁ" DataField="gia" >
                
                </asp:BoundField>
                <asp:BoundField HeaderText="SỐ LƯỢNG" DataField="soLuong" />
            </Columns>
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnGiamSoLuong" runat="server" Text="-" OnClick="btnGiamSoLuong_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnTangSoLuong" runat="server" Text="+" OnClick="btnTangSoLuong_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnXoaSPGH" runat="server" Text="Xóa" OnClick="btnXoaSPGH_Click1" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
        <asp:Label ID="lb_tbXoa" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
        
    </div>
    <div style="float:right; width:300px;margin:200px 20px 0px 0px; text-align:center;">
        <table >
            <caption style="width: 265px"><h2>TỔNG THÀNH TIỀN</h2></caption>
            <tr>
                <td>
                    <asp:Label ID="lb_tongThanhTien" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <br /><asp:Button ID="btn_thanhToan" runat="server" Text="TIẾN HÀNH THANH TOÁN" Height="50px" Width="300px" BackColor="#800203" Font-Bold="True" Font-Size="Large" ForeColor="White" OnClick="btn_thanhToan_Click" /></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="lb_tbEmpty" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:HyperLink ID="hypl_trangChu" runat="server" NavigateUrl="~/TrangChu.aspx" >-> Đi xem sản phẩm</asp:HyperLink></td>
            </tr>
        </table>
    </div>
</asp:Content>

