<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Nu.aspx.cs" Inherits="Nu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 320px;
            text-align: center;
            height: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-top:100px;margin-left:200px;;">
        <asp:DataList ID="dl_Nu" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <table class="tb_sanPham">
                    <tr>
                        <td class="auto-style5">
                            <asp:HyperLink ID="HyperLink1" runat="server" ImageHeight="300px" ImageUrl='<%# Eval("IMAGE_SP") %>' ImageWidth="320px" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH")  %>' ForeColor="Black" Target="_parent">HyperLink</asp:HyperLink>
                            <br />
                                        
                            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Medium" Text='<%# Eval("NAME_SP") %>'  Font-Underline="False" ForeColor="Maroon" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH")%>' Target="_parent"></asp:HyperLink>     
                            <br />
                                        
                            <asp:HyperLink ID="HyperLink3" runat="server" Text='<%# Eval("RETAIL_PRICE","{0:0,0} đ") %>' NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH") %>'></asp:HyperLink>
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
</asp:Content>

