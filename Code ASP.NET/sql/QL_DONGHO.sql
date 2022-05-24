CREATE DATABASE QL_DONGHO
use QL_DONGHO 
go


--go
--CREATE TABLE LoaiTaiKhoan
--(
--	MaLoaiTK nvarCHAR(15),
--	TenLoaiTK nvarchar(200),
--	CONSTRAINT PK_LTK PRIMARY KEY (MaLoaiTK),
	
--)
--go
--CREATE TABLE TaiKhoan
--(
--	MaNV nvarCHAR(15),
--	Username NVARCHAR(50),
--	Password NVARCHAR(100),
--	MaLoaiTK nvarchar(20),
--	CONSTRAINT PK_TK PRIMARY KEY (username),
--	CONSTRAINT FK_TK_LTK FOREIGN KEY (MaLoaiTK) REFERENCES LoaiTaiKhoan(MaLoaiTK),
--)
go
CREATE TABLE THUONGHIEU
(
	maTH int identity(1,1),
	tenTH NVARCHAR(30),
	CONSTRAINT PK_TH PRIMARY KEY (maTH)
)

go
CREATE TABLE SANPHAM
(
	ID_SP NVARCHAR(15),
	NAME_SP NVARCHAR(200),
	IMAGE_SP NVARCHAR(100),
	RETAIL_PRICE int,
	SOLUONG int,
	STATUS_SP NVARCHAR(10), 
	CONSTRAINT PK_SP PRIMARY KEY (ID_SP)
)
go
CREATE TABLE detailImage
(
	idImage int identity(1,1),
	ID_SP NVARCHAR(15),
	ImageUrl NVARCHAR(200), 
	CONSTRAINT PK_Image PRIMARY KEY (idImage),
	CONSTRAINT FK_detailImage_SP FOREIGN KEY (ID_SP) REFERENCES SANPHAM(ID_SP),
)
go
CREATE TABLE NSX
(
	maNSX NVARCHAR(15),
	tenNSX NVARCHAR(50),
	CONSTRAINT PK_NSX PRIMARY KEY (maNSX)
)
go
CREATE TABLE CT_SANPHAM
(
	ID_SP NVARCHAR(15),
	maNSX NVARCHAR(15),
	maTH int,
	SoHieuSP char(18),
	XuatXu NVARCHAR(100),
	Gender nchar(3),
	Kinh NVARCHAR(50),-- Mặt kính
	May NVARCHAR(50),--Bộ máy
	BHQT int,--Bảo hành quốc tế
	BH_Shop int,--Bảo hành tại shop
	DK_Mat float,--đường kính mặt
	DoDay_Mat float,--độ dày mặt
	Nieng nvarchar(200),--Niềng bằng gì
	DayDeo nvarchar(200),--dây đeo bằng gì
	MauMatSo nvarchar(200),--Màu mặt số
	ChongNuoc nvarchar(200),--Khả năng chống nước
	ChucNang nvarchar(250),--Chức năng của đồng hồ	
	CONSTRAINT PK_CTSP PRIMARY KEY (ID_SP),
	CONSTRAINT FK_CTSP_SP FOREIGN KEY (ID_SP) REFERENCES SANPHAM(ID_SP),
	CONSTRAINT FK_CTSP_NSX FOREIGN KEY (maNSX) REFERENCES NSX(maNSX),
	CONSTRAINT FK_CTSP_TH FOREIGN KEY (maTH) REFERENCES THUONGHIEU(maTH),
)
go
CREATE TABLE KHACHHANG
(
	ID nvarchar(15),
	HOTEN nvarchar(100),
	USERNAME nvarchar(100),
	PASSWORD_ nvarchar(100),
	GIOITINH nvarchar(3),
	EMAIL nvarchar(100),
	PHONE nvarchar(100),
	DIACHI nvarchar(300),
	CONSTRAINT PK_KH PRIMARY KEY (ID)
)
go
CREATE TABLE NHANVIEN
(
	MANV nvarchar(20),
	HOTEN NVARCHAR(100),
	TenDangNhap char(20),
	password_ char(20),
	GIOITINH NVARCHAR(3),
	EMAIL CHAR(100),
	DIENTHOAI CHAR(11),
	DIACHI NVARCHAR(250),
	CONSTRAINT PK_TV PRIMARY KEY (MANV)
)
go
CREATE TABLE PHIEUNHAP
(
	MAPN NVARCHAR(15),
	MANV NVARCHAR(20),
	NgayNhap date,
	CONSTRAINT PK_PN PRIMARY KEY (MAPN),
	CONSTRAINT FK_PN_NV FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
)
go
CREATE TABLE CT_PHIEUNHAP
(
	MAPN NVARCHAR(15),
	ID_SP NVARCHAR(15),
	soLuong INT,
	donGia int,
	CONSTRAINT PK_CTPN PRIMARY KEY (MAPN,ID_SP),
	CONSTRAINT FK_CTPN_PN FOREIGN KEY (MAPN) REFERENCES PHIEUNHAP(MAPN),
	CONSTRAINT FK_CTPN_SP FOREIGN KEY (ID_SP) REFERENCES SANPHAM(ID_SP)
)
go
CREATE TABLE HOADON
(
	MAHD NVARCHAR(15),
	MAKH nvarchar(15),
	MANV nvarchar(20),
	NgayXuat date default(getdate()),
	THANHTIEN int,
	TINHTRANG nvarchar(30) default(''),
	CONSTRAINT PK_HD PRIMARY KEY (MAHD),
	CONSTRAINT FK_HD_KH FOREIGN KEY (MAKH) REFERENCES KHACHHANG(ID),
	CONSTRAINT FK_HD_NV FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
)

go
CREATE TABLE CT_HOADON
(
	MAHD NVARCHAR(15),
	ID_SP NVARCHAR(15),
	soLuong INT,
	donGia int,
	CONSTRAINT PK_CTHD PRIMARY KEY (MAHD,ID_SP),
	CONSTRAINT FK_CTHD_HD FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_CTHD_SP FOREIGN KEY (ID_SP) REFERENCES SANPHAM(ID_SP)
)

INSERT INTO NHANVIEN(MANV,HOTEN,TenDangNhap,password_,GIOITINH,EMAIL,DIENTHOAI,DIACHI) VALUES
('NV000000',N'Lê Văn Thông','admin','admin',N'Nam','levanthongqn35@gmail.com','0396210106',N'Quảng Ngãi')
INSERT INTO NHANVIEN(MANV,HOTEN,TenDangNhap,password_,GIOITINH,EMAIL,DIENTHOAI,DIACHI) VALUES
('NV000001',N'Đặng Quốc Anh Thái','thaidqa','admin',N'Nam','kaidang84@gmail.com','0000000000',N'Dak Lak')
select*from NHANVIEN
INSERT INTO NSX VALUES
('NSX1',N'Trung Quốc'),
('NSX2',N'Thụy Sỹ')
GO
---Thuong hieu
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Calvin Klein')--1
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Casio')--2
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Citizen')--3
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Daniel Wellington')--4
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Fossil')--5
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Longines')--6
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Orient')--7
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Saga')--8
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Seiko')--9
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Skagen')--10
INSERT INTO THUONGHIEU(tenTH) VALUES
(N'Tissot')--11
go
---Sản Phẩm Nam
INSERT INTO SANPHAM VALUES
('DH_NAM000001',N'Orient RA-AB0E08L19B – Nam – Automatic (Tự động) - Dây Kim Loại','~/img/DH1.jpg','3600000',40,N'Còn'),
('DH_NAM000002',N'Orient SUNE5004W0 – Nam – ORIENT SUNE5004W0 – Quartz (Pin) – Dây kim loại','~/img/DH2.jpg','2400000',30,N'Còn'),
('DH_NAM000003',N'Tissot-T006-407-11-033-00-Nam - Kinh - Sapphire - Automatic - Tự Động - Dây kim loại','~/img/DH3.jpg','17420000',10,N'Còn'),
('DH_NAM000004',N'Orient FKU00004B0 – Nam – Quartz (Pin) – Dây da','~/img/DH4.jpg','3720000',34,N'Còn'),
('DH_NAM000005',N'Citizen Nam – Eco - Drive (Năng lượng anh sang) – Dây da (BM8475-26E)','~/img/DH5.jpg','5990000',12,N'Còn'),
('DH_NAM000006',N'Orient FKU00006W0 – Nam – Quartz (Pin) – Dây da','~/img/DH6.jpg','3720000',11,N'Còn'),
('DH_NAM000007',N'Tissot T97.1.483.51 – Nam – Kinh Sapphire – Automatic (Tự động) – Dây kim loại','~/img/DH7.jpg','18140000',9,N'Còn'),
('DH_NAM000008',N'Citizen NP1020-15A – Nam – Kinh Sapphire – Automatic (Tự động) – Dây da','~/img/DH8.jpg','8450000',17,N'Còn'),
('DH_NAM000009',N'Longines L4.759.4.12.2 – Nam – Kinh Sapphire – Quartz (Pin) – Dây da','~/img/DH9.jpg','20900000',7,N'Còn'),
('DH_NAM000010',N'Citizen NH8350-59L – Nam - Automatic (Tự động) – Dây kim loại','~/img/DH10.jpg','5520000',19,N'Còn')

--INSERT INTO SANPHAM VALUES
--('DH_NAM13',N'Orient RA-AB0E08L19B – Nam – Automatic (Tự động) - Dây Kim Loại','~/img/DH1.jpg','3600000',100,N'Còn')

INSERT INTO SANPHAM VALUES
('DH_NAM000011',N'Seiko SEPF7K1 – Nam – Automatic (Tự động) – Dây vải – Mặt số 42.5mm – Limited Edition','~/img/DH11.jpg','13190000',15,N'Còn')
INSERT INTO SANPHAM VALUES
('DH_NAM000012',N'Casio DB-360G-9ADF – Nam – Kính Nhựa – Quartz (Pin) – Dây Kim Loại','~/img/DH12.jpg','1990000',37,N'Còn')
---------insert Hình ảnh----------
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES
('DH_NAM1','~/img/DH1_1.jpg')
select* from detailImage


GO
INSERT INTO CT_SANPHAM VALUES
('DH_NAM000001','NSX1',7,'RA-AB0E08L19B',N'Nhật Bản',N'Nam',N'Mineral Crystal (Kinh Cứng)',N'Automatic (Tự Động)',1,5,'39.4','11',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Xanh','3 ATM',N'Lịch Ngày – Lịch Thứ'),
('DH_NAM000002','NSX1',7,'SUNE5004W0',N'Nhật Bản',N'Nam',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',1,5,'40','12',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','10 ATM',N'Lịch Ngày – Dạ Quang'),
('DH_NAM000003','NSX2',11,'T006.407.11.033.00',N'Thụy Sỹ',N'Nam',N'Sapphire (Kinh Chống Trầy)',N'Automatic (Tự Động)',2,4,'39.3','9.8',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','3 ATM',N'Lịch Ngày – Hacking Second – Guilloché'),
('DH_NAM000004','NSX1',7,'FKU00004B0',N'Nhật Bản',N'Nam',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',1,5,'41','10',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Đen','5 ATM',N'Lịch Ngày – Chronograph – Đồng hồ 24h'),
('DH_NAM000005','NSX1',3,'BM8475-26E',N'Nhật Bản',N'Nam',N'Mineral Crystal (Kinh Cứng)',N'Eco-Drive (Năng Lượng anh sang)',1,5,'42','11',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Đen','5 ATM',N'Lịch Ngày – Lịch Thứ'),
('DH_NAM000006','NSX1',7,'FKU00006W0',N'Nhật Bản',N'Nam',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',1,5,'41','10',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng','5 ATM',N'Lịch Ngày – Chronograph – Đồng hồ 24h'),
('DH_NAM000007','NSX2',11,'T97.1.483.51',N'Thụy Sỹ',N'Nam',N'Sapphire (Kinh Chống Trầy)',N'Automatic (Tự Động)',2,4,'39.5','9.5',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Đen','3 ATM',N'Lịch Ngày'),
('DH_NAM000008','NSX1',3,'NP1020-15A',N'Nhật Bản',N'Nam',N'Sapphire (Kinh Chống Trầy)',N'Automatic (Tự Động)',1,5,'40','10.7',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng','5 ATM',N'Đồng Hồ 24 Giờ'),
('DH_NAM000009','NSX2',6,'L4.759.4.12.2',N'Thụy Sỹ',N'Nam',N'Sapphire (Kinh Chống Trầy)',N'Quartz (Pin)',2,4,'35','6',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng','3 ATM',N'Lịch Ngày'),
('DH_NAM000010','NSX1',3,'NH8350-59L',N'Nhật Bản',N'Nam',N'Mineral Crystal (Kinh Cứng)',N'Automatic (Tự Động)',1,5,'40','12',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Xanh','5 ATM',N'Lịch Ngày – Lịch Thứ')

INSERT INTO CT_SANPHAM VALUES
('DH_NAM000011','NSX1',9,'SRPF70K1',N'Nhật Bản',N'Nam',N'Hardlex Crystal (Kính Cứng)',N'Automatic (Tự Động)',1,5,'42.5','13.4',N'Thép Không Gỉ',N'Dây Vải',N'Cam','10 ATM',N'Lịch Ngày – Lịch Thứ – Dạ Quang')
INSERT INTO CT_SANPHAM VALUES
('DH_NAM000012','NSX1',2,'DB-360G-9ADF',N'Nhật Bản',N'Nam',N'Resin Glass (Kính Nhựa)',N'Quartz (Pin)',1,0,'43.1','10.4',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','3 ATM',N'Lịch – Bộ Bấm Giờ – Giờ Kép – Đèn Led')



GO
-----Sản phẩm Nữ
INSERT INTO SANPHAM VALUES
('DH_NU000001',N'Skagen Skw2699 – Nữ – Quartz (Pin) – Dây kim loại','~/img/DH_Nu_1.jpg','3280000',22,N'Còn'),
('DH_NU000002',N'Tissot T113.109.36.116.00 – Nữ – Kinh Sapphire – Quartz (Pin) – Dây Da','~/img/DH_Nu_2_1.jpg','9780000',8,N'Còn'),
('DH_NU000003',N'Longines l4.819.2.32.7 – Nữ – Kinh Sapphire – Quartz (Pin) – Dây Kim Loại','~/img/DH_Nu_3_1.jpg','23760000',12,N'Còn'),
('DH_NU000004',N'Casio LRW-200H-4E3VDF – Nữ – Kính Nhựa – Quartz (Pin) – Dây Cao Su','~/img/DH_Nu_4_1.jpg','815000',28,N'Còn'),
('DH_NU000005',N'Calvin Klein K5N2M526 – Nữ – Quartz (Pin) – Dây Kim Loại – Mặt Số 27mm','~/img/DH_Nu_5_1.jpg','9630000',9,N'Còn'),
('DH_NU000006',N'Longines l4.209.4.87.6 – Nữ – Kinh Sapphire – Quartz (pin) – Dây Kim Loại','~/img/DH_Nu_6_1.jpg','37180000',16,N'Còn'),
('DH_NU000007',N'Calvin Klein K5H231K6 – Nữ – Quartz (Pin) – Dây Da','~/img/DH_Nu_7_1.jpg','7040000',19,N'Còn'),
('DH_NU000008',N'Saga 53229 SVMWSV-6 – Nữ – Quartz (Pin) – Dây Kim Loại – Mặt Số 24mm','~/img/DH_Nu_8_1.jpg','6384000',20,N'Còn'),
('DH_NU000009',N'Daniel Wellington DW00100163 – Nữ – Quartz (Pin) – Dây Kim Loại – Mặt Số 32mm','~/img/DH_Nu_9_1.jpg','4100000',10,N'Còn'),
('DH_NU000010',N'Citizen EG7073-16Y – Nữ – Eco-Drive (Năng Lượng anh sang) – Dây Da – Mặt Số 31mm','~/img/DH_Nu_10_1.jpg','13860000',18,N'Còn')

INSERT INTO SANPHAM VALUES
('DH_NU000011',N'Fossil Es4813 – Nữ – Quartz (Pin) – Dây Da – Mặt Số 36mm','~/img/DH_Nu_11_1.jpg','3480000',23,N'Còn')
INSERT INTO SANPHAM VALUES
('DH_NU000012',N'Casio LRW-200H-4B2VDF – Nữ – Quartz (Pin) – Dây Cao Su','~/img/DH_Nu_12_1.jpg','815000',36,N'Còn')
GO
INSERT INTO CT_SANPHAM VALUES
('DH_NU000001','NSX1',10,'SKW2699',N'Đan Mạch',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',3,5,'26','7',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','5 ATM',N''),
('DH_NU000002','NSX2',11,'T113.109.36.116.00',N'Thụy Sỹ',N'Nữ',N'Sapphire (Kinh Chống Trầy)',N'Quartz (Pin)',2,4,'24.8','6.1',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng','3 ATM',N''),
('DH_NU000003','NSX2',6,'L4.819.2.32.7',N'Thụy Sỹ',N'Nữ',N'Sapphire (Kinh Chống Trầy)',N'Quartz (Pin)',2,4,'33','5',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','5 ATM',N'Lịch Ngày – Lịch Thứ'),
('DH_NU000004','NSX1',2,'LRW-200H-4E3VDF',N'Nhật Bản',N'Nữ',N'Resin Glass (Kinh Nhựa)',N'Quartz (Pin)',1,null,'34.2','11.5',N'',N'Dây cao su',N'Hồng','10 ATM',N'Lịch Ngày'),
('DH_NU000005','NSX1',1,'K5N2M526',N'Thụy Sỹ',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',2,4,'27','8',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','3 ATM',N''),
('DH_NU000006','NSX2',6,'L4.209.4.87.6',N'Thụy Sỹ',N'Nữ',N'Sapphire (Kinh Chống Trầy)',N'Quartz (Pin)',2,4,'24','4.5',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','3 ATM',N''),
('DH_NU000007','NSX2',1,'K5H231K6',N'Thụy Sỹ',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',2,4,'27.5','8.5',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng','3 ATM',N''),
('DH_NU000008','NSX1',8,'53229 SVMWSV-6',N'Mỹ',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',2,5,'24','',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng Xà Cừ','3 ATM',N'Đính Đá Swarovski'),
('DH_NU000009','NSX1',4,'DW00100163',N'Thụy Điển',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',2,5,'32','6',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','3 ATM',N''),
('DH_NU000010','NSX2',3,'EG7073-16Y',N'Nhật Bản',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Eco-Drive (Năng Lượng anh sang)',1,5,'31','6',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng Xà Cừ','5 ATM',N'')

INSERT INTO CT_SANPHAM VALUES
('DH_NU000011','NSX1',5,'ES4813',N'Mỹ',N'Nữ',N'Mineral Crystal (Kinh Cứng)',N'Quartz (Pin)',2,5,'36','8',N'Thép Không Gỉ',N'Dây Da Chính Hãng',N'Trắng Xà Cừ','3 ATM',N'')
INSERT INTO CT_SANPHAM VALUES
('DH_NU000012','NSX1',2,'LRW-200H-4B2VDF',N'Nhật Bản',N'Nữ',N'Hardlex Crystal (Kính Cứng)',N'Quartz (Pin)',1,0,'38.9','11.5',N'',N'Dây Cao Su',N'Trắng','10 ATM',N'Lịch Ngày')
GO

---sản phẩm nam hoặc nữ
INSERT INTO SANPHAM VALUES
('DH_NN1',N'G-Shock – Baby-G Đôi – Quartz (Pin) – Dây Cao Su (Ga-110DC-2ADR – BA-110DC-2A2DR)','~/img/DH_NN_1.jpg','9890000',N'Còn')
INSERT INTO CT_SANPHAM VALUES
('DH_NN1','Casio','GA-110DC-2ADR (Nam) – BA-110DC-2A2DR (Nữ)',N'Nhật Bản',N'Nam - Nữ',N'Mineral Crystal (Kính Cứng)',N'Quartz (Pin)',N'1 Năm',N' Năm','26','7',N'Thép Không Gỉ',N'Thép Không Gỉ',N'Trắng','5 ATM',N''),

----------------Hình---------------------------------
go
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000001','~/img/DH1_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000002','~/img/DH2_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000002','~/img/DH2_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000003','~/img/DH3_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000003','~/img/DH3_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000004','~/img/DH4_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000004','~/img/DH4_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000005','~/img/DH5_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000005','~/img/DH5_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000006','~/img/DH6_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000006','~/img/DH6_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000007','~/img/DH7_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000007','~/img/DH7_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000008','~/img/DH8_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000008','~/img/DH8_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000009','~/img/DH9_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000009','~/img/DH9_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000010','~/img/DH10_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000010','~/img/DH10_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000011','~/img/DH11_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000012','~/img/DH12_1.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000012','~/img/DH12_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000012','~/img/DH12_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NAM000012','~/img/DH12_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000001','~/img/DH_Nu_1_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000002','~/img/DH_Nu_2_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000003','~/img/DH_Nu_3_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000004','~/img/DH_Nu_4_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000004','~/img/DH_Nu_4_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000005','~/img/DH_Nu_5_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000006','~/img/DH_Nu_6_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000006','~/img/DH_Nu_6_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000006','~/img/DH_Nu_6_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000007','~/img/DH_Nu_7_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000007','~/img/DH_Nu_7_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000007','~/img/DH_Nu_7_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000008','~/img/DH_Nu_8_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000008','~/img/DH_Nu_8_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000008','~/img/DH_Nu_8_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000009','~/img/DH_Nu_9_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000009','~/img/DH_Nu_9_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000009','~/img/DH_Nu_9_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000010','~/img/DH_Nu_10_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000011','~/img/DH_Nu_11_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000011','~/img/DH_Nu_11_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000011','~/img/DH_Nu_11_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000011','~/img/DH_Nu_11_5.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000012','~/img/DH_Nu_11_2.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000012','~/img/DH_Nu_11_3.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000012','~/img/DH_Nu_11_4.jpg')
INSERT INTO detailImage(ID_SP,ImageUrl) VALUES('DH_NU000012','~/img/DH_Nu_11_5.jpg')



-------Phiếu nhập---------
go
set dateformat DMY
insert into PHIEUNHAP values('PN000001','NV000000','12/3/2021')

insert into CT_PHIEUNHAP values('PN000001','DH_NAM000001',50,2700000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000002',50,2000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000003',50,15000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000004',50,3000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000005',50,4900000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000006',50,2800000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000007',20,15700000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000008',50,6000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000009',50,18000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000010',40,4000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000011',30,11000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NAM000012',27,1200000)

insert into CT_PHIEUNHAP values('PN000001','DH_NU000001',50,2500000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000002',50,7000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000003',50,18000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000004',50,350000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000005',50,7000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000006',50,30000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000007',50,5700000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000008',50,5000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000009',50,3000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000010',50,12000000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000011',50,2800000)
insert into CT_PHIEUNHAP values('PN000001','DH_NU000012',50,400000)

--alter table detailImage
--Drop Constraint FK_detailImage_SP
--alter table detailImage
--add CONSTRAINT FK_detailImage_SP FOREIGN KEY (ID_SP) REFERENCES SANPHAM(ID_SP)

--alter table CT_SANPHAM
--Drop Constraint FK_CTSP_SP
--alter table detailImage
--add CONSTRAINT FK_CTSP_SP FOREIGN KEY (ID_SP) REFERENCES SANPHAM(ID_SP)


select*from SANPHAM
select*from CT_SANPHAM

GO
create proc DSSP
as
begin
	select* from SANPHAM
end
----LẤY TÊN THƯƠNG HIỆU
GO
create proc ten_thuongHieu
as
begin
	select tenTH from THUONGHIEU
end
exec ten_thuongHieu
----LẤY TÊN mặt Kính
GO
create proc pro_Kinh
as
begin
	select distinct(Kinh) from CT_SANPHAM
end
exec pro_Kinh
----LẤY Bộ máy
GO
create proc pro_BoMay
as
begin
	select distinct(May) from CT_SANPHAM
end
exec pro_BoMay
----LẤY Màu mặt đồng hồ
GO
create proc pro_MauMatDH
as
begin
	select distinct(MauMatSo) from CT_SANPHAM
end
exec pro_MauMatDH
----Lấy Kích thước mặt đồng hồ
GO
create proc pro_KTDONGHO
as
begin
	select distinct(MauMatSo) from CT_SANPHAM
end
exec pro_MauMatDH
----Lấy chong nuoc
GO
create proc pro_chongNuoc
as
begin
	select distinct(ChongNuoc) from CT_SANPHAM
end
exec pro_MauMatDH

-----------trigger cap nhat THANHTIEN của HOADON---------------
go
create trigger tg_CapNhatThanhTien_KhiThemCTHD on CT_HOADON
for insert,update,delete
as
	update HOADON
	set THANHTIEN = THANHTIEN - (select (donGia*soLuong) from deleted)
	where MAHD = (select MAHD from deleted)

	update HOADON
	set THANHTIEN = (select sum(donGia*soLuong) from CT_HOADON where MAHD = (select MAHD from inserted))
	where MAHD = (select MAHD from inserted)
go



-------------------------------END---------------------------------------------------------------
insert into CT_HOADON values('HD000007','DH_NAM1',3,3600000)
select sum(donGia*soLuong) from CT_HOADON where MAHD = 'HD000007'
----------------------------------------------------------test-----------------------------------------------------------------------------------
select* from CT_SANPHAM where DK_Mat between 44 and 999



select Max(right( ID_SP,3)) from SANPHAM --Lấy dòng cuối cùng
select MAX(right(MAHD,6)) from HOADON
select MAX(right(ID,6)) from KHACHHANG
select * from KHACHHANG
select ID from KHACHHANG where HOTEN=N'Lê Thị Quỳnh Giao' and GIOITINH=N'Nữ' and EMAIL='lequa1234@gmail.com' and PHONE='0384537080' and DIACHI=N'419,Phạm Xuân Hòa, Quảng Ngãi'

select sum(SOLUONG) from SANPHAM
select sum(donGia) from CT_HOADON where MAHD='HD000007'

UPDATE CT_HOADON SET soLuong = 2 where MAHD='HD000001' and ID_SP = 'DH_NAM9'
SELECT * from HOADON,KHACHHANG,NHANVIEN where KHACHHANG.ID = HOADON.MAKH and HOADON.MANV = NHANVIEN.MANV

SELECT count(HOADON.MAHD),sum(soLuong) from HOADON,CT_HOADON where HOADON.MAHD=CT_HOADON.MAHD and NgayXuat = '2021-08-07'



select* from CT_HOADON,CT_PHIEUNHAP,SANPHAM where CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_PHIEUNHAP.ID_SP=SANPHAM.ID_SP
select sum(CT_HOADON.soLuong*CT_HOADON.donGia - CT_PHIEUNHAP.donGia) from CT_HOADON,CT_PHIEUNHAP,SANPHAM,HOADON where CT_HOADON.ID_SP=SANPHAM.ID_SP and CT_PHIEUNHAP.ID_SP=SANPHAM.ID_SP and HOADON.MAHD=CT_HOADON.MAHD and month(NgayXuat) = 8

select* from HOADON
select* from KHACHHANG
select HOADON.MAHD,KHACHHANG.ID,NAME_SP,CT_HOADON.soLuong,donGia,HOTEN,PHONE,DIACHI,IMAGE_SP,NgayXuat,THANHTIEN
from HOADON,CT_HOADON,KHACHHANG,SANPHAM 
where HOADON.MAHD=CT_HOADON.MAHD AND HOADON.MAKH=KHACHHANG.ID AND CT_HOADON.ID_SP=SANPHAM.ID_SP and USERNAME = 'thong1234'

SELECT top(1)* from KHACHHANG where USERNAME = 'thong1234' and PASSWORD_= '123'

SELECT * from CT_HOADON,SANPHAM where CT_HOADON.ID_SP=SANPHAM.ID_SP and MAHD = 'HD000004'

delete from CT_HOADON where MAHD='HD000015'

declare @kq int
set @kq=( (select THANHTIEN from HOADON where MAHD='HD000001') - (select sum(donGia*soLuong) from CT_HOADON where MAHD = 'HD000001'))
select @kq as kq

select MAX(right(ID_SP,6)) from SANPHAM where ID_SP like 'DH_NAM%'
select MAX(right(ID_SP,6)) from SANPHAM where ID_SP like 'DH_NU%'