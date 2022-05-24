<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="DangKi.aspx.cs" Inherits="DangKi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 32px;
        }
        .auto-style6 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form_dangKi">
                <table border="0" cellpadding="3px;">
                    <caption style="font-size: 30px">Đăng Kí</caption>
                    <tr>
                        <td>Họ Tên (<span class="dauSaoDo">*</span>)</td>
                        <td>
                            <asp:TextBox ID="txt_hoten" runat="server" Height="22px" Width="300px"></asp:TextBox>
                            <%--Ràng buộc ho ten không được để trống--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_hoten" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txt_hoten" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>Tên Đăng Nhập (<span class="dauSaoDo">*</span>)</td>
                        <td>
                            <asp:TextBox ID="txt_tenDangNhap" runat="server" Height="22px" Width="300px"></asp:TextBox>
                            <br /><asp:Label ID="lb_tbao" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                            <%--Ràng buộc ten đăng nhâpj không được để trống--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_tdn" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txt_tenDangNhap" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>Mật Khẩu (<span class="dauSaoDo">*</span>)</td>
                        <td>
                            <asp:TextBox ID="txt_pass" runat="server" Height="22px" Width="300px" TextMode="Password"></asp:TextBox>
                            <%--Ràng buộc password không được để trống--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_pass" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txt_pass" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>Xác nhận mật khẩu (<span class="dauSaoDo">*</span>)</td>
                        <td>
                            <asp:TextBox ID="txt_repass" runat="server" Height="22px" Width="300px" TextMode="Password"></asp:TextBox>
                            <%--Ràng buộc Repass (trùng với pass)--%><br />
                            <asp:CompareValidator ID="CompareValidator_rePass" runat="server" ErrorMessage="Không trùng với mật khẩu đã nhập !" ControlToValidate="txt_repass" ControlToCompare="txt_pass" Operator="Equal" ForeColor="Red"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Giới Tính</td>
                        <td class="auto-style2">
                            <asp:RadioButtonList ID="rbl_gioiTinh" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">Nam</asp:ListItem>
                                <asp:ListItem>Nữ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txt_email" runat="server" Height="22px" Width="300px" TextMode="Email"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Điện Thoại (<span class="dauSaoDo">*</span>)</td>
                        <td>
                            <asp:TextBox ID="txt_sdt" runat="server" Height="22px" Width="300px" TextMode="Phone"></asp:TextBox>
                            <%--Ràng buộc phone không được để trống--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_sdt" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txt_sdt" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>Địa Chỉ </td>
                        <td>
                            <asp:TextBox ID="txt_diaChi" runat="server" Height="50px" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Thông Tin Điều Khoản (<span class="dauSaoDo">*</span>)</td>
                        <td>
                            <asp:Button ID="btn_dieuKhoan" runat="server" Text="Đọc điều khoản"  /><br />
                            <asp:CheckBox ID="cb_dieuKhoan" runat="server" Text="Tôi đồng ý điều khoản" Checked="True" />
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2" Align="center" class="auto-style6" ><asp:Button ID="Button1" runat="server" Text="Tiếp" Height="36px" Width="88px" OnClick="Button1_Click" /></td>
                    </tr>
                    <tr >
                        <td colspan="2" Align="center" style="font-size: 17px" ><b>Lưu ý: </b>Những ô có dấu (<span class="dauSaoDo">*</span>) là bắt buộc!</td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="formDeltail">
                <table cellpadding="10px;" style="font-size: 20px;margin-left:30px; margin-right:10px;" border="0">
                    <caption style="font-size: 30px;text-align:center;margin-bottom:30px;">Kiểm Tra Lại Thông Tin</caption>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label1" runat="server" Text="Họ Tên:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_hoten" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label2" runat="server" Text="Tên Đăng Nhập:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_TenDangNhap" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label3" runat="server" Text="Mật Khẩu:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_pass" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label4" runat="server" Text="Giới Tính:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_gioiTinh" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_Email" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label6" runat="server" Text="Điện Thoại:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_dienThoai" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_">
                            <asp:Label ID="Label7" runat="server" Text="Địa Chỉ:"></asp:Label></td>
                        <td class="td_2">
                            <asp:Label ID="lb_diaChi" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_2">
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btn_quayLai" runat="server" Text="Quay lại"  Height="40px" Width="100px" OnClick="btn_quayLai_Click"/></td>
                        <td class="td_2">
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btn_submit" runat="server" Text="Đăng kí" Height="40px" Width="100px" OnClick="btn_submit_Click" /></td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <div class="ThanhCong">
                <table border="0" cellpadding="10px">
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Đăng Kí Thành Công!" Font-Bold="True" Font-Size="XX-Large" ForeColor="#33CC33"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/tickXanh.png" Height="300px" Width="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="DangNhap.aspx" runat="server">Quay lại đăng nhập</asp:HyperLink></td>
                        
                    </tr>
                </table>
            </div>
        </asp:View>
    </asp:MultiView>
    </asp:Content>

