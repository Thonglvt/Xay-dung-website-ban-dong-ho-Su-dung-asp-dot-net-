<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Loc.aspx.cs" Inherits="Loc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-top:100px;margin-left:200px;">
        <asp:DataList ID="dl_Loc" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <table class="tb_sanPham">
                    <tr>
                        <td class="row_sanPham">
                            <asp:HyperLink ID="hl_img" runat="server" ImageHeight="300px" ImageUrl='<%# Eval("IMAGE_SP") %>' ImageWidth="320px" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH") %>' ForeColor="Black" Target="_blank">HyperLink</asp:HyperLink>
                            <br />
                                        
                            <asp:HyperLink ID="hl_name" runat="server" Font-Size="Medium" Text='<%# Eval("NAME_SP") %>'  Font-Underline="False" ForeColor="Maroon" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH")+"&thuongHieu="+Eval("tenTH") %>' Target="_blank"></asp:HyperLink>     
                            <br /><br />
                                        
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("RETAIL_PRICE","{0:0,0} đ") %>'></asp:Label>
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
</asp:Content>

