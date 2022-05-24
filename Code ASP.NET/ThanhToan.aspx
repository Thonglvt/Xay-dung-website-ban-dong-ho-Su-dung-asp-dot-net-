<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="ThanhToan.aspx.cs" Inherits="ThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style6 {
            height: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div style="text-align:center">
                    <span style="font-size: 30px;color:red;">THANH TOÁN</span><br />
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/TrangChu.aspx">Trang chủ</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" ForeColor="#6666FF">/Thanh toán</asp:HyperLink><br /><br />
            </div>
            <div class="div_thanhToan">
                <br />&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="ĐỊA CHỈ NHẬN HÀNG"></asp:Label><br /><br />
                <table  cellpadding="2" style="width: 700px">
                    <tr>
                        <td>Họ tên:<span class="dauSaoDo">*</span><br />
                            <asp:TextBox ID="txt_HoTenKHDH" runat="server" Width="400px" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập họ tên" ControlToValidate="txt_HoTenKHDH" ForeColor="Red" SetFocusOnError="True" Font-Size="Small"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Quốc gia/Khu vực:<span class="dauSaoDo">*</span><br />
                            <asp:Label ID="lbQuocGia" runat="server" Text="Việt Nam" Font-Bold="True" Height="25px"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rbl_GioiTinhDH" runat="server" RepeatDirection="Horizontal" TextAlign="Left">
                                <asp:ListItem Selected="True">Anh</asp:ListItem>
                                <asp:ListItem>Chị</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>Địa chỉ:<span class="dauSaoDo">*</span><br />
                            <asp:TextBox ID="txt_DiaChi" runat="server" Width="400px" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập địa chỉ nhận hàng" ControlToValidate="txt_DiaChi" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Tỉnh/Thành phố:<span class="dauSaoDo">*</span><br />
                            <asp:TextBox ID="txt_TinhTp" runat="server" Width="400px" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vui lòng nhập địa chỉ nhận hàng" ControlToValidate="txt_TinhTp" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">Số điện thoại:<span class="dauSaoDo">*</span><br />
                            <asp:TextBox ID="txt_sdtDH" runat="server" Width="400px" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txt_sdtDH" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Nhập sai định dạng sđt!" ControlToValidate="txt_sdtDH" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{10,11}" Font-Bold="True" Font-Size="X-Small"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Email:<span class="dauSaoDo">*</span><br />
                            <asp:TextBox ID="txt_EmailDatHang" runat="server" Width="400px" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txt_EmailDatHang" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Sai định dạng email!" ForeColor="Red" ControlToValidate="txt_EmailDatHang" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="True" Font-Size="X-Small"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                     <tr>
                        <td style="padding:0px 0px 0px 50px;">
                            <asp:Button ID="btn_DatHang" runat="server" Text="ĐẶT HÀNG" Height="40px" Width="300px" BackColor="#800203" Font-Bold="False" Font-Size="25px" ForeColor="White" OnClick="btn_DatHang_Click" />
                         <br /><asp:Label ID="lb_tbGioHang" runat="server" ></asp:Label><asp:HyperLink ID="hyp_QuayLaiMuaHang" runat="server" NavigateUrl="TrangChu.aspx">Quay lai mua hàng</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div>
                <h3 style="color:darkblue;"><asp:Label ID="lb_dhtc" runat="server" Text="Đặt hàng thành công"></asp:Label></h3>
                <asp:GridView ID="gv_donDaDat" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="800px">
                    <Columns>
                        <asp:BoundField DataField="MAHD" HeaderText="Mã đơn hàng" />
                        <asp:BoundField DataField="NAME_SP" HeaderText="Tên sản phẩm" />
                        <asp:ImageField DataImageUrlField="IMAGE_SP">
                            <ControlStyle Width="50px" Height="50px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="donGia" HeaderText="Đơn giá" />
                        <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

