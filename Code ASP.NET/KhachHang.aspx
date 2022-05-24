<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="KhachHang.aspx.cs" Inherits="KhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            width: 232px;
            text-align:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:460px;margin:0px 0px 0px 200px">
        <asp:Button ID="btn_infoChung" runat="server" Text="Chung" OnClick="btn_infoChung_Click" />
        <asp:Button ID="btn_intoDonDat" runat="server" Text="Đơn đặt" OnClick="btn_intoDonDat_Click" />
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <div style="width:450px; height:540px;background-color:#f0f0f0;border-radius:10px">
            <br /><h2 style="text-align:center">Thông tin khách hàng</h2><br />
            <table style="text-align:right; margin:0px 0px 0px 0px; width: 414px;" cellpadding="4" cellspacing="2">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label></td>
                    <td class="auto-style7"><asp:Label ID="lb_ID" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Tên:"></asp:Label></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txt_tenKH" runat="server" Height="25px" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label></td>
                    <td class="auto-style7"><asp:Label ID="lb_UsernameKH" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lb_pass" runat="server" Text="Password:"></asp:Label></td>
                    <td class="auto-style7"><asp:TextBox ID="txt_pass" runat="server" Height="25px" Width="200px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lb_confirm" runat="server" Text="Confirm Password:"></asp:Label></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txt_confirm" runat="server" Height="25px" Width="200px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Giới tính:"></asp:Label></td>
                    <td class="auto-style7">
                        <asp:RadioButtonList ID="rbl_gioiTinh" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Nam</asp:ListItem>
                            <asp:ListItem>Nữ</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label></td>
                    <td class="auto-style7"><asp:TextBox ID="txt_Email" runat="server" Height="25px" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="Điện thoại:"></asp:Label></td>
                    <td class="auto-style7"><asp:TextBox ID="txt_DienThoai" runat="server" Height="25px" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label8" runat="server" Text="Địa chỉ:"></asp:Label></td>
                    <td class="auto-style7"><asp:TextBox ID="txt_DiaChi" runat="server" TextMode="MultiLine" Width="200px" Height="60px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lb_tb" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td colspan="2">
                        <asp:Button ID="btn_doiPass" runat="server" Text="Đổi mật khẩu" OnClick="btn_doiPass_Click" />
                        <asp:Button ID="btn_OkPass" runat="server" Text="OK" OnClick="btn_OkPass_Click" />
                        <asp:Button ID="btn_capNhat" runat="server" Text="Cập nhật thông tin" OnClick="btn_capNhat_Click" />
                        <asp:Button ID="btn_Luu" runat="server" Text="Lưu" OnClick="btn_Luu_Click"  />
                        <asp:Button ID="btn_Huy" runat="server" Text="Hủy" OnClick="btn_Huy_Click"  />
                    </td>
                
                </tr>
            
            </table>
             </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:GridView ID="gv_HoaDon" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gv_HoaDon_PageIndexChanging" PageSize="5" Width="600px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="MAHD" HeaderText="Mã hóa đơn" />
                        <asp:BoundField DataField="NgayXuat" HeaderText="Ngày tạo hóa đơn" />
                        <asp:BoundField HeaderText="Tổng tiền" DataField="THANHTIEN" DataFormatString="{0:0,0}đ" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_chonHD_KH" runat="server" Text="Chọn" OnClick="btn_chonHD_KH_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_XoaHD" runat="server" Text="(X) Hủy" OnClick="btn_XoaHD_Click" ForeColor="Red" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="5" Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView><br />
                <asp:GridView ID="gv_CTHDTheoMa" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="3" Width="700px" Caption="CHI TIẾT ĐƠN HÀNG" OnPageIndexChanging="gv_CTHDTheoMa_PageIndexChanging" AllowPaging="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NAME_SP" HeaderText="Tên sản phẩm">
                        <ItemStyle HorizontalAlign="Justify" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="IMAGE_SP" HeaderText="Hình">
                            <ControlStyle Height="35px" Width="35px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="DonGia" DataFormatString="{0:0,0}đ" HeaderText="Đơn giá">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="soLuong" HeaderText="Số lượng" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerSettings PageButtonCount="50" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <div>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    
</asp:Content>

