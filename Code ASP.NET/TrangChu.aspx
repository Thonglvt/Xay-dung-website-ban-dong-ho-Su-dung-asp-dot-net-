<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="TrangChu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-top:100px;margin-left:200px;">
        <asp:DataList ID="dl_chinh" runat="server" RepeatColumns="3">
            <ItemStyle ForeColor="Red" />
            <ItemTemplate>
                <table class="tb_sanPham">
                    <tr>
                        <td class="auto-style5">
                            <asp:HyperLink ID="hl_img" runat="server" ImageHeight="300px" ImageUrl='<%# Eval("IMAGE_SP") %>' ImageWidth="320px" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH") %>' ForeColor="Black" Target="_parent">HyperLink</asp:HyperLink>
                            <br />
                                        
                            <asp:HyperLink ID="hl_name" runat="server" Font-Size="Medium" Text='<%# Eval("NAME_SP") %>'  Font-Underline="False" ForeColor="Maroon" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH")%>' Target="_parent"></asp:HyperLink>     
                            <br />
                            <br />
                                        
                            <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="Red" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH") %>' Text='<%# Eval("RETAIL_PRICE","{0:0,0} đ") %>'></asp:HyperLink>
                            <br />
                            </td>
                        <caption>
                            <br />
                            <br />
                            <br />
                        </caption>
                    </tr>
                </table>
            </ItemTemplate>
       </asp:DataList>
    </div>
    <div style="text-align:center;margin:30px 0px 30px 630px;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_dau" runat="server" Text="Trang Đầu" OnClick="btn_dau_Click" /></td>
                <td>
                    <asp:Button ID="btn_truoc" runat="server" Text="Trước" OnClick="btn_truoc_Click" /></td>
                <td>
                    <asp:Label ID="lb_trangHienTai" runat="server" Width="70px"></asp:Label></td>
                <td>
                    <asp:Button ID="btn_sau" runat="server" Text="Sau" OnClick="btn_sau_Click" /></td>
                <td>
                    <asp:Button ID="btn_cuoi" runat="server" Text="Trang cuối" OnClick="btn_cuoi_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

