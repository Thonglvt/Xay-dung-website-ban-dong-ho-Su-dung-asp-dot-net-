<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFormDK.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style6 {
            text-align: center;
            width: 300px;
            height: 26px;
        }
        .auto-style7 {
            width: 173px;
        }
        .auto-style8 {
            width: 248px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div style="text-align:center; font-size:35px; color:#ec0808;position:absolute;top:110px; left:500px;">TRANG QUẢN LÝ CỦA ADMIN</div>
    <div class="left_admin">
        <table>
            <tr>
                
                <td><asp:Button ID="btn_sanPham" runat="server" Text="Sản phẩm" OnClick="btn_sanPham_Click"/></td>
                <td><asp:Button ID="btn_chiTietSanPham" runat="server" Text="Chi tiết sản phẩm" OnClick="btn_chiTietSanPham_Click" /></td>
                <td><asp:Button ID="btn_NhanVien" runat="server" Text="Nhân viên" OnClick="btn_NhanVien_Click" /></td>
                <td><asp:Button ID="btn_PhieuNhap" runat="server" Text="Nhập hàng" OnClick="btn_PhieuNhap_Click" /></td>
                <td><asp:Button ID="btn_khachHang" runat="server" Text="Khách hàng" OnClick="btn_khachHang_Click" /></td>
                <td><asp:Button ID="btn_hoaDon" runat="server" Text="Hóa đơn" OnClick="btn_hoaDon_Click" /></td>
                <td><asp:Button ID="btn_Image" runat="server" Text="Hình ảnh" OnClick="btn_Image_Click" /></td>
                <td><asp:Button ID="btn_thongKe" runat="server" Text="Thống kê" OnClick="btn_thongKe_Click" /></td>
                
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="v_sanPham" runat="server">
                <br />
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_searchSP" runat="server" Width="392px" Height="25px"></asp:TextBox>
                <asp:Button ID="btn_xoaSearchSP" runat="server" Text="X" OnClick="btn_xoaSearchSP_Click"/>
                <asp:Button ID="btn_searchSP" runat="server" Text="Tìm kiếm" OnClick="btn_searchSP_Click"/>
                <asp:GridView ID="gv_sanPham" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"  Width="850px"  Font-Size="Small" AllowPaging="True" OnPageIndexChanging="gv_sanPham_PageIndexChanging" Caption="SẢN PHẨM">
                    <Columns>
                        <asp:BoundField DataField="ID_SP" HeaderText="ID" />
                        <asp:BoundField DataField="NAME_SP" HeaderText="Tên sản phẩm" />
                        <asp:BoundField DataField="IMAGE_SP" HeaderText="Hình ảnh" />
                        <asp:BoundField DataField="RETAIL_PRICE" HeaderText="Đơn giá" />
                        
                        <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_select" runat="server" OnClick="btn_select_Click" Text="Chọn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" Mode="NumericFirstLast" NextPageImageUrl="Last" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                    
                </asp:GridView>
            
            </asp:View>
            <asp:View ID="v_CTSP" runat="server">
                <div style="position:absolute;z-index:2">
                    <asp:GridView ID="gv_chiTiet" runat="server" AutoGenerateColumns="False" CssClass="gv_ct" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" Font-Size="Small" ForeColor="Black" OnPageIndexChanging="gv_chiTiet_PageIndexChanging" EnablePaging="True" PageSize="5" AllowPaging="True" Caption="CHI TIẾT SẢN PHẨM" Width="1000px" >
                
                        <Columns>
                            <asp:BoundField DataField="ID_SP" HeaderText="Mã sản phẩm" />
                            <asp:BoundField DataField="tenNSX" HeaderText="Nhà sản xuất" />
                            <asp:BoundField DataField="tenTH" HeaderText="Thương hiệu" />
                            <asp:BoundField DataField="SoHieuSP" HeaderText="Số hiệu SP" />
                            <asp:BoundField DataField="XuatXu" HeaderText="Xuất xứ" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="Kinh" HeaderText="Kính" />
                            <asp:BoundField DataField="May" HeaderText="Máy" />
                            <asp:BoundField DataField="BHQT" HeaderText="Bảo hành quốc tế" />
                            <asp:BoundField DataField="BH_Shop" HeaderText="Bảo hành tại t&amp;tshop" />
                            <asp:BoundField DataField="DK_Mat" HeaderText="Đường kính mặt" />
                            <asp:BoundField DataField="DoDay_Mat" HeaderText="Độ dày mặt" />
                            <asp:BoundField DataField="Nieng" HeaderText="Niềng" />
                            <asp:BoundField DataField="DayDeo" HeaderText="Dây đeo" />
                            <asp:BoundField DataField="MauMatSo" HeaderText="Màu mặt" />
                            <asp:BoundField DataField="ChongNuoc" HeaderText="Chống nước" />
                            <asp:BoundField DataField="ChucNang" HeaderText="Chức năng" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btn_select_ctsp" runat="server" OnClick="btn_select_ctsp_Click" Text="Chọn" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerSettings LastPageText="Last" PageButtonCount="5" FirstPageText="First" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                   
                    </asp:GridView>
                </div>
            </asp:View>

            <asp:View ID="v_thanhVien" runat="server">
                <br />
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_searchNV" runat="server" Width="392px" Height="25px"></asp:TextBox>
                <asp:Button ID="btn_xoaSearch" runat="server" Text="X" OnClick="btn_xoaSearch_Click" />
                <asp:Button ID="btn_searchNhanVien" runat="server" Text="Tìm kiếm" OnClick="btn_searchNhanVien_Click" />
                
                <br /><br />
                <asp:Label ID="lb_tbNV_NV" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                <asp:GridView ID="gv_thanhVien" runat="server" AutoGenerateColumns="False" Caption="NHÂN VIÊN" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" OnPageIndexChanging="gv_thanhVien_PageIndexChanging" PageSize="7">
                    <Columns>
                        <asp:BoundField DataField="MANV" HeaderText="Mã nhân viên">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HOTEN" HeaderText="Tên nhân viên" />
                        <asp:BoundField DataField="TenDangNhap" HeaderText="Tên đăng nhập" />
                        <asp:BoundField DataField="password_" HeaderText="Mật khẩu" />
                        <asp:BoundField DataField="GIOITINH" HeaderText="Giới tính" />
                        <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                        <asp:BoundField DataField="DIENTHOAI" HeaderText="Điện thoại" />
                        <asp:BoundField DataField="DIACHI" HeaderText="Địa Chỉ" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_chonTV" runat="server" OnClick="btn_chonTV_Click" Text="Chọn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_XoaNV_NV" runat="server" Text="X" OnClick="btn_XoaNV_NV_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerSettings PageButtonCount="30" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="v_khachHang" runat="server">
                
                <div style="position:relative;z-index:2; width:1000px;">
                    <br />
                    
                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_searchKH" runat="server" Width="392px" Height="25px"></asp:TextBox>
                    <asp:Button ID="btn_xoaSearchKH" runat="server" Text="X" OnClick="btn_xoaSearchKH_Click"  />
                    <asp:Button ID="btn_searchKH" runat="server" Text="Tìm kiếm" OnClick="btn_searchKH_Click" />
                    <p style="text-align:center;"><asp:Label ID="lb_tbXoaKH" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></p>
                    <asp:GridView ID="gv_khachHang" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" OnPageIndexChanging="gv_khachHang_PageIndexChanging" PageSize="5" Width="1000px">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Mã KH" />
                            <asp:BoundField DataField="HOTEN" HeaderText="Tên khách hàng" />
                            <asp:BoundField DataField="USERNAME" HeaderText="User" />
                            <asp:BoundField DataField="PASSWORD_" HeaderText="Password" />
                            <asp:BoundField DataField="GIOITINH" HeaderText="Giới tính" />
                            <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                            <asp:BoundField DataField="PHONE" HeaderText="Điện thoại" />
                            <asp:BoundField DataField="DIACHI" HeaderText="Đia chỉ" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btn_XoaKH" runat="server" Text="Xóa" OnClick="btn_XoaKH_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnChonKH" runat="server" Text="Chọn" OnClick="btnChonKH_Click1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                        </Columns>
                    
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="50" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    
                    </asp:GridView>
                </div>
                
            </asp:View>
           
            <asp:View ID="v_HoaDon" runat="server">
                <br />
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_searchHD" runat="server" Width="392px" Height="25px"></asp:TextBox>
                <asp:Button ID="btn_XoaSearchHD" runat="server" Text="X" OnClick="btn_XoaSearchHD_Click"/>
                <asp:Button ID="btn_searchHD" runat="server" Text="Tìm kiếm" OnClick="btn_searchHD_Click" />
                <asp:DropDownList ID="dl_ngayHD" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="dl_thangHD" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="dl_namHD" runat="server"></asp:DropDownList>
                <asp:Label ID="lb_slhd" runat="server" Font-Bold="True"></asp:Label><br /><br />
                <asp:GridView ID="gv_HoaDon" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gv_HoaDon_PageIndexChanging" PageSize="5" Width="1000px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="MAHD" HeaderText="Mã hóa đơn" />
                        <asp:BoundField DataField="MAKH" HeaderText="Mã khách hàng" />
                        <asp:BoundField DataField="HOTEN" HeaderText="Tên khách hàng" />
                        <asp:BoundField DataField="PHONE" HeaderText="SĐT" />
                        <asp:BoundField DataField="MANV" HeaderText="Nhân viên" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NgayXuat" HeaderText="Ngày tạo hóa đơn" />
                        <asp:BoundField HeaderText="Tổng tiền" DataField="THANHTIEN" DataFormatString="{0:0,0}đ" >
                        
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="TINHTRANG" HeaderText="Status">
                        <ControlStyle Font-Size="Small" />
                        </asp:BoundField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_chonHD" runat="server" OnClick="btn_chonHD_Click" Text="Chọn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_XoaHD" runat="server" Text="(X) Hủy đơn" OnClick="btn_XoaHD_Click" ForeColor="Red" />
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
                <asp:GridView ID="gv_CTHDTheoMa" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="3" Width="900px" Caption="CHI TIẾT ĐƠN HÀNG" OnPageIndexChanging="gv_CTHDTheoMa_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="MAHD" HeaderText="Mã hóa đơn" />
                        <asp:BoundField DataField="ID_SP" HeaderText="Mã sản phẩm" />
                        <asp:BoundField DataField="NAME_SP" HeaderText="Tên sản phẩm">
                        <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="IMAGE_SP" HeaderText="Hình">
                            <ControlStyle Height="35px" Width="35px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="DonGia" DataFormatString="{0:0,0}đ" HeaderText="Đơn giá">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_themSLCTSP" runat="server" OnClick="btn_themSLCTSP_Click" Text="+" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_giamSLCTSP" runat="server" OnClick="btn_giamSLCTSP_Click" Text="-" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_capNhatSLCTHD" runat="server" OnClick="btn_CapNhatSLCTHD_Click" Text="Cập nhật" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_HuySP" runat="server" ForeColor="Red" OnClick="btn_HuySP_Click" Text="Bỏ(X)" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
            </asp:View>
           
            <asp:View ID="v_thongKe" runat="server">
                <br />

                <div style="clear:both;width:1400px; position:relative; background-color:#f3f3f3; height:600px;">
                    <div style="float:left;width:45%;">
                        <div class="tksoLuongSP">
                            <h2>Tổng số lượng sản phẩm</h2>
                            <p>Số lượng tồn: <asp:Label ID="lb_SLTon" runat="server" Font-Bold="True"></asp:Label></p>
                            <p>Số lượng đá bán: <asp:Label ID="lb_slDaBan" runat="server" Font-Bold="True" ForeColor="#3333CC"></asp:Label></p>
                            <asp:Button ID="btn_all" runat="server" Text="All" OnClick="btn_all_Click" />
                            
                        </div>
                        
                        <div class="tkDonDat">
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Số lượng đơn đặt: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            <asp:Label ID="lb_tbSlDonDatTK" runat="server" Font-Bold="False" Font-Size="X-Large" ForeColor="Blue"></asp:Label>
                        </div>

                        <div style="clear:both; background-color:#f3f991; border-radius:10px;text-align:center; width:80%;" >
                            <table cellspacing="10"  >
                                <tr>
                                    <th colspan="2" style="font-size:24px">Thao tác</th>
                                    <tr>
                                        <td class="auto-style7">
                                            <asp:Button ID="btn_DonDatDMY" runat="server" OnClick="btn_DonDatDMY_Click" Text="Ngày/tháng/năm" />
                                        </td>
                                        <td class="auto-style8">
                                            <asp:TextBox ID="txt_ngayThangNam" runat="server" Height="23px"></asp:TextBox>
                                            <asp:Button ID="btn_xoaNgayDatDon" runat="server" OnClick="btn_xoaNgayDatDon_Click" Text="X" />
                                            <br />
                                            <asp:Calendar ID="c_ntn" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style7">
                                            <asp:Button ID="btn_DonDatMY" runat="server" OnClick="btn_DonDatMY_Click" Text="Tháng/năm" />
                                        </td>
                                        <td class="auto-style8">
                                            <asp:DropDownList ID="dl_thangTK" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="dl_namTK" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style7">
                                            <asp:Button ID="btn_DonDatY" runat="server" OnClick="btn_DonDatY_Click" Text="Năm" />
                                        </td>
                                        <td class="auto-style8">
                                            <asp:DropDownList ID="dl_namTK2" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="tkDoanhThu">
                        <h2>Tổng doanh thu</h2>
                        <asp:Label ID="lb_tbTongDoanhThu" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#3333CC"></asp:Label>
                        <br /><br />
                        <asp:DropDownList ID="dl_DDT" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="dl_MDT" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="dl_YDT" runat="server"></asp:DropDownList>
                        <asp:Button ID="btn_OkDT" runat="server" Text="OK" OnClick="btn_OkDT_Click" />
                    </div>
                    
                </div>
            </asp:View>
            <asp:View ID="v_Image" runat="server">
                <asp:GridView ID="gv_hinhAnh" runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gv_hinhAnh_PageIndexChanging" PageSize="4" Width="734px">
                    <Columns>
                        <asp:BoundField DataField="ID_SP" HeaderText="Mã sản phẩm" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ImageUrl" HeaderText="Image Url" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="ImageUrl" HeaderText="Hình">
                            <ControlStyle Height="100px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_chonImg" runat="server" OnClick="btn_chonImg_Click" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_XoaImg" runat="server" OnClick="btn_XoaImg_Click" Text="Xóa" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerSettings PageButtonCount="50" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="v_NhapHang" runat="server">
                <br />
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="392px" Height="25px"></asp:TextBox>
                <asp:Button ID="btn_xoaSearch_PN" runat="server" Text="X" />
                <asp:Button ID="btn_search_PN" runat="server" Text="Tìm kiếm" OnClick="btn_search_PN_Click" />
                <br />
                <asp:GridView ID="gv_PhieuNhap" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gv_PhieuNhap_PageIndexChanging" Width="700px">

                    <AlternatingRowStyle BackColor="White" />

                    <Columns>
                        <asp:BoundField DataField="MAPN" HeaderText="Mã phiếu nhập" />
                        <asp:BoundField DataField="MANV" HeaderText="Mã nhân viên" />
                        <asp:BoundField DataField="NgayNhap" HeaderText="Ngày nhập" />
                        <asp:BoundField DataField="ID_SP" HeaderText="Mã sản phẩm" />
                        <asp:BoundField DataField="soLuong" HeaderText="Số lượng" />
                        <asp:BoundField DataField="donGia" HeaderText="Đơn giá" />
                    </Columns>

                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerSettings PageButtonCount="40" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />

                </asp:GridView>
            </asp:View>
        </asp:MultiView>
        
        
    </div>
    <div class="right_admin">      
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="v_detail_sp" runat="server">
                <div style="margin:80px 20px 0px 0px; background-color:lavender;border-radius:5px;">
                    <table border="0" cellpadding="3" style="color:black;">
                        <caption style="font-size: xx-large; color: #FF3399">Thông tin</caption>
                        <tr class="row_tail">
                            <td class="td_2">Mã sản phẩm:<br />
                                <asp:TextBox ID="txt_maSP" runat="server" Width="110px"></asp:TextBox><br />
                                <asp:Button ID="btn_maNam" runat="server" Text="Nam" OnClick="btn_maNam_Click" />&nbsp;
                                <asp:Button ID="btn_maNu" runat="server" Text="Nữ" OnClick="btn_maNu_Click" />
                            </td>
                            <td class="td_2">Tên sản phẩm:<br />
                                <asp:TextBox ID="txt_tenSP" runat="server" TextMode="MultiLine" Width="210px" Height="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="td_2">Hình ảnh:<br /><asp:Image ID="img_sp" runat="server" Height="100px" Width="100px" /></td>
                            <td class="td_2">Giá:<br /><asp:TextBox ID="txt_gia" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td   class="td_2">URL:<br />
                                <asp:TextBox ID="txt_ImgUrl" runat="server" Width="135px"></asp:TextBox>
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />

                            </td>
                            <td class="td_2">Số lượng: <asp:TextBox ID="txt_SoLuong" runat="server" Width="37px"></asp:TextBox>
                                <br />Tình trạng: 
                                <asp:DropDownList ID="dl_TinhTrang" runat="server">
                                    <asp:ListItem>Còn</asp:ListItem>
                                    <asp:ListItem>Hết</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        
                        </tr>
                        <tr>
                            <td colspan="2" class="td_2"><br />
                                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td_2"><asp:Label ID="lb_tongSoLuong" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="margin-left:30px;margin-bottom:50px;">
                <tr>
                    <td>
                        <asp:Button ID="btnThem2" runat="server" Text="Thêm" OnClick="btnThem2_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_Them" runat="server" Text="Lưu" OnClick="btn_Them_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="btn_Sua" runat="server" Text="Cập nhật" OnClick="btn_Sua_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="btn_Xoa" runat="server" Text="Xóa" OnClick="btn_Xoa_Click"   />
                    </td>
                    <td>
                        <asp:Button ID="btn_XoaTrang" runat="server" Text="Xóa trắng" OnClick="btn_XoaTrang_Click"  />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" colspan="4">
                        <asp:Label ID="lb_tbthem" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </td>     
                </tr>
             </table> 
            </div>
            </asp:View>

            <asp:View ID="v_detail_ctsp" runat="server">
                <div style="margin:10px 0px 0px 60px;background-color:lavender;border:1px solid #808080;border-radius:10px">
                    <table cellpadding="4">
                        <tr>
                            <td>Mã sản phẩm:</td>
                            <td><asp:DropDownList ID="ddl_maSP_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Nhà sản xuất:</td>
                            <td><asp:DropDownList ID="ddl_NSX_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Thuong hiệu:</td>
                            <td><asp:DropDownList ID="ddl_TH_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Số hiệu:</td>
                            <td><asp:TextBox ID="txt_soHieu" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Xuất xứ:</td>
                            <td><asp:DropDownList ID="ddl_XX_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Gender:</td>
                            <td>
                                <asp:RadioButtonList ID="rbtnl_GT_CTSP" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Nam</asp:ListItem>
                                    <asp:ListItem>Nữ</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>Kính:</td>
                            <td><asp:DropDownList ID="ddl_Kinh_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Bảo hành quốc tế:</td>
                            <td><asp:TextBox ID="txt_BHQT" runat="server" Width="50px"></asp:TextBox> năm</td>
                        </tr>
                        <tr>
                            <td>Bảo hành Tại shop:</td>
                            <td><asp:TextBox ID="txt_BHTS" runat="server" Width="50px"></asp:TextBox> năm</td>
                        </tr>
                         <tr>
                            <td>Đường kính mặt DH:</td>
                            <td><asp:TextBox ID="txt_DuongKinh" runat="server" Width="50px"></asp:TextBox> mm</td>
                        </tr>
                         <tr>
                            <td>Độ dày mặt DH:</td>
                            <td><asp:TextBox ID="txt_DoDay" runat="server" Width="50px"></asp:TextBox> mm</td>
                        </tr>
                        <tr>
                            <td>Bộ máy:</td>
                            <td><asp:DropDownList ID="ddl_BoMay_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Niềng:</td>
                            <td><asp:DropDownList ID="ddl_Nieng_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Dây đeo:</td>
                            <td><asp:DropDownList ID="ddl_DayDeo_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Màu mặt DH:</td>
                            <td><asp:DropDownList ID="ddl_MauMatDH_CTSP" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Mức chống nước:</td>
                            <td><asp:DropDownList ID="ddl_MucChongNuoc_CTSP" runat="server"></asp:DropDownList> ATM</td>
                        </tr>
                        <tr>
                            <td>Chức năng:</td>
                            <td><asp:TextBox ID="txt_ChucNang" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:right">
                                <asp:Button ID="btn_LuuCTSP" runat="server" Text="Lưu" OnClick="btn_LuuCTSP_Click" />
                                <asp:Button ID="btn_xoaTrangCTSP" runat="server" Text="Xóa trắng" OnClick="btn_xoaTrangCTSP_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:Label ID="lb_tbCTSP" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:View>
            <asp:View ID="v_detail_tv" runat="server"><br />
                <div style="width:400px; background-color:#f4f0f0; margin:100px 0px 0px 0px; border-radius:10px;">
                    <table cellpadding="10" >
                        <caption>THÔNG TIN:</caption>
                        <tr>
                            <td>
                                <asp:Label ID="lb_ten" runat="server" Text="Tên thành viên:"></asp:Label></td>
                            <td>
                                <asp:TextBox  CssClass="css_txt" ID="txt_ten" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Tên đăng nhập:"></asp:Label></td>
                            <td>
                                <asp:TextBox CssClass="css_txt" ID="txt_tenDangNhap" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Mật khẩu:"></asp:Label></td>
                            <td>
                                <asp:TextBox CssClass="css_txt" ID="txt_matKhau" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Giới tính:"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbl_gioiTinh" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Nam</asp:ListItem>
                                    <asp:ListItem>Nữ</asp:ListItem>
                                </asp:RadioButtonList>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label></td>
                            <td>
                                <asp:TextBox CssClass="css_txt" ID="txt_Email" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Điện thoại:"></asp:Label></td>
                            <td>
                                <asp:TextBox CssClass="css_txt" ID="txt_dienThoai" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Địa chỉ:"></asp:Label></td>
                            <td>
                                <asp:TextBox CssClass="css_txt" ID="txt_diaChi" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:Button ID="btnThem2TV" runat="server" Text="Thêm" OnClick="btnThem2TV_Click"/>
                                <asp:Button ID="btnLuuTV" runat="server" Text="Lưu" OnClick="btnLuuTV_Click"  />
                                <asp:Button ID="btnCapNhatTV" runat="server" Text="Cập nhật" OnClick="btnCapNhatTV_Click"  />
                                <br />
                                <asp:Label ID="lb_tbNV" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:View>
            <asp:View ID="v_detail_kh" runat="server">
                <br /><br /><br /><br /><br /><br /><br />
                <div style="background-color:#f4f0f0; width:350px;margin-left:90px;">
                    <table cellpadding="6">
                        <tr>
                            <td><asp:Label ID="Label4" runat="server" Text="Mã khách hàng"></asp:Label></td>
                            <td><asp:TextBox ID="txt_MaKH_KH" runat="server" Width="205px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label12" runat="server" Text="Tên khách hàng"></asp:Label></td>
                            <td><asp:TextBox ID="txt_tenKH_KH" runat="server" Width="205px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label13" runat="server" Text="Username"></asp:Label></td>
                            <td><asp:TextBox ID="txt_username_KH" runat="server" Width="205px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label14" runat="server" Text="Password"></asp:Label></td>
                            <td><asp:TextBox ID="txt_pass_KH" runat="server" Width="205px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label15" runat="server" Text="Giới tính:"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbl_gioiTinhKH" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Nam"></asp:ListItem>
                                    <asp:ListItem Value="Nữ"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label16" runat="server" Text="Email:"></asp:Label></td>
                            <td><asp:TextBox ID="txt_EmailKH_KH" runat="server" Width="205px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label17" runat="server" Text="Điện thoại:"></asp:Label></td>
                            <td><asp:TextBox ID="txt_DTKH_KH" runat="server" Width="205px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label18" runat="server" Text="Địa chỉ:"></asp:Label></td>
                            <td><asp:TextBox ID="txt_DCKH_KH" runat="server" Height="60px" Width="205px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center;padding-left:20px">
                                <asp:Button ID="btn_LuuKH" runat="server" Text="Lưu" OnClick="btn_LuuKH_Click" />
                                <asp:Button ID="btn_CapNhatKH" runat="server" Text="Cập nhật" OnClick="btn_CapNhatKH_Click" />
                                <asp:Button ID="btn_XoaTrangKH" runat="server" Text="Thêm" OnClick="btn_XoaTrangKH_Click" /><br />
                                <asp:Label ID="lb_tbKH_KH" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </asp:View>
            <asp:View ID="v_detail_HoaDon" runat="server">
                <br /><br /><br />
                <table style="margin:50px 5px 0px 60px; background-color:#f0f0f0; width: 386px;" cellpadding="5" >
                    <caption>SỬA THÔNG TIN</caption>
                    <tr>
                        <td>Mã khách hàng:</td>
                        <td>
                            <asp:TextBox ID="txt_maKHHD" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_xoaTrangtxtMaKH" runat="server" Text="x" OnClick="btn_xoaTrangtxtMaKH_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>Tên khách hàng:</td>
                        <td>
                            <asp:TextBox ID="txt_tenKHHD" runat="server" Width="213px" ></asp:TextBox>
                            <asp:Button ID="btn_XoaTenKH" runat="server" Text="x" OnClick="btn_XoaTenKH_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>Nhân viên:</td>
                        <td>
                            <asp:DropDownList ID="dl_nhanVienHD" runat="server" DataSourceID="SqlDataSource1" DataTextField="TenDangNhap" DataValueField="TenDangNhap"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QL_DONGHOConnectionString %>" SelectCommand="SELECT [TenDangNhap] FROM [NHANVIEN]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center;"><asp:Button ID="btn_CapNhatLaiNhanVien" runat="server" Text="Cập nhật" OnClick="btn_CapNhatLaiNhanVien_Click" /></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="v_detail_thongKe" runat="server">

            </asp:View>
            <asp:View ID="v_detail_Image" runat="server">
                <div style="background-color:lavender; border-radius:7px; margin:100px 20px 0px 0px;">
                    <h3 style="color:blue;text-align:center;">HÌNH ẢNH</h3>
                <table cellpadding="3">
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Mã sản phẩm:"></asp:Label></td>
                        <td><asp:TextBox ID="txt_maSP_img" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label10" runat="server" Text="Hình Ảnh:"></asp:Label></td>
                        <td><asp:Image ID="img_detail" runat="server" Height="150px" Width="150px" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label11" runat="server" Text="Image Url:"></asp:Label></td>
                        <td><asp:TextBox ID="txt_detailUrl_img" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:FileUpload ID="fu_detail_Image" runat="server" /></td>
                        <td><asp:Button ID="btn_uploadImage" runat="server" Text="Upload" OnClick="btn_uploadImage_Click" /></td>
                    </tr>
                    
                </table>
                <table style="margin-left:30px;margin-bottom:50px;">
                <tr>
                    <td>
                        <asp:Button ID="btn_themImage" runat="server" Text="Thêm" OnClick="btn_themImage_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btn_luuImage" runat="server" Text="Lưu" OnClick="btn_luuImage_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btn_CapNhatImage" runat="server" Text="Cập nhật" OnClick="btn_CapNhatImage_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btn_XoaImage" runat="server" Text="Xóa" OnClick="btn_XoaImage_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_XoaTrangImage" runat="server" Text="Xóa trắng" OnClick="btn_XoaTrangImage_Click"/>
                    </td>
                    </tr>
                    <tr>
                        <td class="td_2" colspan="4">
                            <asp:Label ID="lb_tbHinhAnh" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        </td>     
                    </tr>
                </table>
                </div>
            </asp:View>
            <asp:View ID="v_detail_NhapHang" runat="server">
                <div style="width:400px; background-color:#f4f0f0;margin:90px 0px 0px 40px;">
                    <table cellpadding="10">
                        <tr>
                            <td>Mã phiếu nhập:</td>
                            <td><asp:TextBox ID="txt_maPN_PN" runat="server" Width="230px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Mã nhân viên:</td>
                            <td><asp:TextBox ID="txt_maNV_PN" runat="server" Width="230px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Ngày nhập:</td>
                            <td><asp:TextBox ID="txt_ngayNhap_PN" runat="server" Width="230px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center;">
                                <asp:Button ID="btn_LuuPN1_PN" runat="server" Text="Tạo phiếu nhập" OnClick="btn_LuuPN1_PN_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center"><asp:Label ID="lb_tbPN_PN" runat="server" ForeColor="Blue"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                ------------------Chi tiết nhập------------------
                            </td>
                        </tr>
                        <tr>
                            <td>Mã sản phẩm:</td>
                            <td><asp:TextBox ID="txt_maSP_PN" runat="server" Width="230px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Số lượng:</td>
                            <td><asp:TextBox ID="txt_soLuong_PN" runat="server" Width="230px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Đơn giá:</td>
                            <td><asp:TextBox ID="txt_donGia_PN" runat="server" Width="230px" Height="20px"></asp:TextBox></td>
                        </tr>
                         <tr>

                            <td colspan="2" style="text-align:center;"><asp:Label ID="lb_tbThemCTPN" runat="server" ForeColor="Red" ></asp:Label><br /></td>
                        </tr>
                        <tr>

                            <td colspan="2" style="text-align:center;padding-left:70px">
                                <asp:Button ID="btn_luu_PN" runat="server" Text="Lưu" OnClick="btn_luu_PN_Click"  />
                                <asp:Button ID="btn_xoaTrang_PN" runat="server" Text="Xóa trắng" OnClick="btn_xoaTrang_PN_Click" />
                                <asp:Button ID="btn_xong1PN" runat="server" Text="Kết thúc" OnClick="btn_xong1PN_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:View>
        </asp:MultiView>
        
    </div>
    
</asp:Content>

