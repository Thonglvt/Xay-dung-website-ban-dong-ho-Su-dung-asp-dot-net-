<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietSanPham.aspx.cs" Inherits="ChiTietSanPham" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-top:50px; float:left;width:550px;text-align:center;height:500px">
        <asp:DataList ID="dl_DatHang" runat="server" Width="470px" RepeatColumns="1">
            <ItemTemplate>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label31" runat="server" Text='<%# (Eval("NAME_SP")).ToString().ToUpper() %>' Width="500px"></asp:Label>
                <br /><br />
                <table >
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server" Height="400px" ImageUrl='<%# Eval("IMAGE_SP") %>' Width="371px" />
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label33" runat="server" Text="THÔNG TIN SẢN PHẨM"></asp:Label>
                            <br />
                            <br />
                            Mã Số Sản phẩm:
                            <asp:Label ID="Label34" runat="server" Text='<%# Eval("SoHieuSP") %>' Font-Size="Small"></asp:Label>
                            <br />

                            <asp:Label ID="Label35" runat="server" Text='<%# Eval("RETAIL_PRICE","{0:0,0} đ") %>' Font-Size="X-Large"></asp:Label>
                            <br />
                            <br />
                            <asp:Button CssClass="btnDatHang"  ID="btn_datHang" runat="server" Text="ĐẶT HÀNG 0396210106" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="50px" Width="280px" />
                            <br />
                            <br />
                            <asp:Button CssClass="btnthemGio" ID="btn_themVaoGio" runat="server" Text="THÊM VÀO GIỎ HÀNG" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="50px" Width="280px" Font-Overline="False" Font-Strikeout="False" OnClick="btn_themVaoGio_Click" />
                            <br />
                        </td>
                    </tr>
                    
                </table>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="dl_HinhAnh" runat="server" RepeatColumns="5" >
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Height="80px" Width="80px" />
                <%--<asp:Image ID="Image8" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Height="80px" Width="80px" />--%>
            </ItemTemplate>
        </asp:DataList>
        <br /><br /><br /><br />
        <asp:DataList ID="dl_ChiTiet" runat="server" CellPadding="4" ForeColor="#333333" Caption="MÔ TẢ" style="margin-right: 23px">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <ItemTemplate>
                <table style="width:500px;" border="1" cellpadding="7">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Thương Hiệu" Font-Bold="True"></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="Label16" runat="server" Text='<%# Eval("tenTH") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="Label2" runat="server" Text="Số Hiệu Sản Phẩm" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("SoHieuSP") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  >
                            <asp:Label ID="Label3" runat="server" Text="Xuất Xứ" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("XuatXu") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Giới Tính" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Kính" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("Kinh") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="Label6" runat="server" Text="Máy" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("May") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="Label7" runat="server" Text="Bảo Hành Quốc Tế" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("BHQT") %>'></asp:Label>&nbsp;Năm
                            </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="Label8" runat="server" Text="Bảo Hành Tại Shop" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("BH_Shop") %>'></asp:Label>&nbsp;Năm
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="Label9" runat="server" Text="Đường Kính Mặt Số" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label24" runat="server" Text='<%# Eval("DK_Mat") %>'></asp:Label>&nbsp;mm

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Bề Dày Mặt Số" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text='<%# Eval("DoDay_Mat") %>'></asp:Label>&nbsp;mm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Niềng" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("Nieng") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Dây Đeo" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("DayDeo") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Màu Mặt Số" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label28" runat="server" Text='<%# Eval("MauMatSo") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Chống Nước" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label29" runat="server" Text='<%# Eval("ChongNuoc") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Chức Năng" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label30" runat="server" Text='<%# Eval("ChucNang") %>'></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label38" runat="server" Text="Nhà Sản Xuất" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label37" runat="server" Text='<%# Eval("tenNSX") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    </div>
    <div style="float:right; width:330px; margin:160px 30px 0px 0px;height:500px">
        <table cellpadding="4">
            <caption>TẠI SAO NÊN CHỌN CHÚNG TÔI?</caption>
            
            <tr>
                <td><asp:Image ID="Image1" runat="server" ImageUrl="~/img/ctsp1.png" /></td>
                <td>Hoàn Lại Tiền Gấp 10 Lần Nếu Phát Hiện Hàng Giả - Hàng Nhái.</td>
            </tr>
            <tr>
                <td><asp:Image ID="Image3" runat="server" ImageUrl="~/img/ctsp2.png" /></td>
                <td>Tăng Thêm Thời Gian Bảo Hành Lên Đến 5 Năm</td>
            </tr>
            <tr>
                <td><asp:Image ID="Image4" runat="server" ImageUrl="~/img/ctsp3.png" /></td>
                <td>Sai Kích Cỡ? Không Ưng Ý? Đổi Hàng Trong 7 Ngày</td>
            </tr>
            <tr>
                <td><asp:Image ID="Image5" runat="server" ImageUrl="~/img/ctsp4.png" /></td>
                <td>Thay Pin Miễn Phí Suốt Đời - Không Còn Lo Hết Pin Nữa.</td>
            </tr>
            <tr>
                <td><asp:Image ID="Image6" runat="server" ImageUrl="~/img/ctsp5.png" /></td>
                <td>Giao Hàng SIÊU TỐC Trong 2h - SHIP COD Miễn Phí</td>
            </tr>
            <tr>
                <td><asp:Image ID="Image7" runat="server" ImageUrl="~/img/ctsp6.png" /></td>
                <td>Đến & Cảm Nhận Kinh Nghiệm Hơn 30 Năm Của Chúng Tôi.</td>
            </tr>
        </table>
    </div>
   <%-- <div style="width:430px;clear:both;float:left">
        
    </div>--%>
    <%--<div style="">
        
    </div>--%>
    <div style="clear:both; margin:60px 0px 30px 200px;">
        <br /><br /><br /><br />
        <span style="font-size:20px; margin:0px 0px 0px 100px; opacity:70%">-------------------------------------------------- SẢN PHẨM LIÊN QUAN --------------------------------------------------</span>
        <br /><br /><br /> 
        <asp:DataList ID="dl_sanPhamLienQuan" runat="server" RepeatColumns="3">
            <ItemStyle ForeColor="Red" />
            <ItemTemplate>
                <table class="tb_sanPham">
                    <tr>
                        <td class="auto-style5">
                            <asp:HyperLink ID="hl_img" runat="server" ImageHeight="300px" ImageUrl='<%# Eval("IMAGE_SP") %>' ImageWidth="320px" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH") %>' ForeColor="Black" Target="_parent">HyperLink</asp:HyperLink>
                            <br />
                                        
                            <asp:HyperLink ID="hl_name" runat="server" Font-Size="Medium" Text='<%# Eval("NAME_SP") %>'  Font-Underline="False" ForeColor="Maroon" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH") %>' Target="_parent"></asp:HyperLink>     
                            <br />
                            <br />
                                        
                            <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="Red" NavigateUrl='<%# "ChiTietSanPham.aspx?ID_SP="+Eval("ID_SP")+"&thuongHieu="+Eval("tenTH")%>' Text='<%# Eval("RETAIL_PRICE","{0:0,0} đ") %>'></asp:HyperLink>
                            <br />
                            </td>
                       
                    </tr>
                </table>
            </ItemTemplate>
       </asp:DataList>
    </div>
</asp:Content>

