USE master
GO
CREATE DATABASE QLQuanCafe
--ON PRIMARY
--(NAME = 'qlycafe', FILENAME = 'd:\qlycafe.mdf')
--LOG ON
--(NAME = 'qlycafe_log', FILENAME = 'd:\qlycafe.ldf')
--GO
USE QLQuanCafe
GO
CREATE TABLE KhachHang
(
	MaKH CHAR(5) PRIMARY KEY,
	TenKH NVARCHAR(35) NOT NULL,
	DiaChi NVARCHAR(45) NOT NULL,
	SDT CHAR(11) NOT NULL
)
GO
CREATE TABLE NhanVien
(
	MaNV CHAR(5) PRIMARY KEY,
	TenNV NVARCHAR(35) NOT NULL,
	CMND CHAR(9) NOT NULL,
	SDT CHAR(11) NOT NULL,
	DiaChi NVARCHAR(50) NOT NULL,
	NgayVaoLam SMALLDATETIME NOT NULL,
	NgaySinh SMALLDATETIME NOT NULL,
	ChucVu NVARCHAR(15) NOT NULL,
	GioiTinh BIT NOT NULL,
	HinhAnh image
)
GO
CREATE TABLE BanAn
(
	MaBan INT IDENTITY PRIMARY KEY,
	TenBan NVARCHAR(35) NOT NULL,
	TrangThai NVARCHAR(10) NOT NULL
)
GO
CREATE TABLE HoaDon
(
	MaHD INT IDENTITY PRIMARY KEY,
	NgayLap SMALLDATETIME NOT NULL,
	MaBan INT NOT NULL,
	GiamGia INT,
	--MaNV CHAR(5) NOT NULL,
	--MaKH CHAR(5) NOT NULL,
	TinhTrang INT NOT NULL,
	FOREIGN KEY(MaBan) REFERENCES BanAn(MaBan),
	--FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH),
	--FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO
CREATE TABLE LoaiMon
(
	MaLoaiMon INT IDENTITY PRIMARY KEY,
	TenLoaiMon NVARCHAR(35) NOT NULL,
	HinhAnh image
)
GO
CREATE TABLE MonAn
(
	MaMonAn INT IDENTITY PRIMARY KEY,
	TenMonAn NVARCHAR(35) NOT NULL,
	MaLoaiMon INT NOT NULL,
	Gia SMALLMONEY NOT NULL,
	HinhAnh image,
	FOREIGN KEY(MaLoaiMon) REFERENCES LoaiMon(MaLoaiMon)
)
GO
CREATE TABLE ChiTietHD
(
	MaCTHD INT IDENTITY PRIMARY KEY,
	MaHD INT NOT NULL,
	MaMonAn INT NOT NULL,
	SoLuong TINYINT NOT NULL,
	ThanhTien SMALLMONEY NOT NULL,
	FOREIGN KEY(MaMonAn) REFERENCES MonAn(MaMonAn),
	FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD)
)
GO
CREATE TABLE TaiKhoan
(
	MaTK CHAR(5) PRIMARY KEY,
	TenDangNhap CHAR(25) NOT NULL,
	MK CHAR(25) NOT NULL,
	LoaiTk TINYINT NOT NULL,
	MaNV CHAR(5) NOT NULL,
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO
CREATE TABLE ChamCong
(
	MaChamCong CHAR(5) PRIMARY KEY,
	MaNV CHAR(5) NOT NULL,
	NgayLam SMALLDATETIME NOT NULL,
	SoCaLam TINYINT NOT NULL,
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO

CREATE TABLE PhieuXuat
(
	MaPhieuXuat CHAR(5) PRIMARY KEY,
	NgayXuat SMALLDATETIME NOT NULL,
	MaNV CHAR(5) NOT NULL,
	LyDoXuat NVARCHAR(50),
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO
CREATE TABLE NhaCungCap
(
	MaNhaCC CHAR(5) PRIMARY KEY,
	TenNhaCC NVARCHAR(35) NOT NULL,
	DiaChi NVARCHAR(50) NOT NULL,
	SDT CHAR(11) NOT NULL
)
GO
CREATE TABLE PhieuNhap
(
	MaPhieNhap CHAR(5) PRIMARY KEY,
	NgayNhap SMALLDATETIME NOT NULL,
	MaNV CHAR(5) NOT NULL,
	MaNhaCC CHAR(5) NOT NULL,
	LyDoNhap NVARCHAR(50),
	TongTien SMALLMONEY NOT NULL,
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
	FOREIGN KEY(MaNhaCC) REFERENCES NhaCungCap(MaNhaCC)
)
GO
CREATE TABLE LoaiHang
(
	MaLoaiHang CHAR(5) PRIMARY KEY,
	TenLoaiHang NVARCHAR(35) NOT NULL
)
GO
CREATE TABLE MatHang
(
	MaMH CHAR(5) PRIMARY KEY,
	TenMH NVARCHAR(35) NOT NULL,
	MaLoaiHang CHAR(5) NOT NULL,
	SoLuong TINYINT NOT NULL
	FOREIGN KEY(MaLoaiHang) REFERENCES LoaiHang(MaLoaiHang)
)
GO
CREATE TABLE ChiTietPhieuNhap
(
	MaCTPN CHAR(7) PRIMARY KEY,
	MaPhieuNhap CHAR(5) NOT NULL,
	MaMH CHAR(5) NOT NULL,
	SoLuongNhap TINYINT NOT NULL,
	DonGia SMALLMONEY NOT NULL,
	GhiChu NVARCHAR(50),
	FOREIGN KEY(MaMH) REFERENCES MatHang(MaMH),
	FOREIGN KEY(MaPhieuNhap) REFERENCES PhieuNhap(MaPhieNhap)
)
GO
CREATE TABLE ChiTietPhieuXuat
(
	MaCTPX CHAR(7) PRIMARY KEY,
	MaPhieuXuat CHAR(5) NOT NULL,
	MaMH CHAR(5) NOT NULL,
	SoLuongXuat TINYINT NOT NULL,	
	GhiChu NVARCHAR(50),
	FOREIGN KEY(MaMH) REFERENCES dbo.MatHang(MaMH),
	FOREIGN KEY(MaPhieuXuat) REFERENCES dbo.PhieuXuat(MaPhieuXuat)
)
GO
--insert Khach hang--
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH01', N'Đỗ Thanh Thiên',N'Gò Vấp','0987417482')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH02', N'Phan Thành Đạt',N'Tân Bình','0988109023')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH03', N'Phạm Lê Long Tài',N'Quận 3','01624567879')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH04', N'Lê Công Danh',N'Quận 1','0987448529')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH05', N'Nguyễn Như Trãi',N'Bình Tân','0987417434')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH06', N'Nguyễn Văn Trung',N'Bình Chánh','0987478963')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH07', N'Trịnh Công Tý',N'Củ Chi','0987654752')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH08', N'Lê Văn Cường',N'Thủ Đức','0987414567')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH09', N'Lê Nhựt An',N'Quận 5','0983543656')
INSERT INTO dbo.KhachHang ( MaKH, TenKH, DiaChi, SDT ) VALUES  ('KH10', N'Vũ Đình Cần',N'Gò Vấp','0987417482')

--insert NhanVien--
INSERT INTO dbo.NhanVien VALUES('NV01',N'Thiều Sỹ Tùng','174689956','0963002862',N'Gò Vấp','2013-12-13','1995-12-03',N'Quản lý','true','')
INSERT INTO dbo.NhanVien VALUES('NV02',N'Lê Thị Trà My','174998876','01647887884',N'Bình Thạnh','2014-11-05','1996-12-14',N'Kế toán','false','')
INSERT INTO dbo.NhanVien VALUES('NV03',N'Đỗ Văn Liêm','173987678','0163456434',N'Gò Vấp','2014-12-03','1997-01-03',N'Kế toán','false','')
INSERT INTO dbo.NhanVien VALUES('NV04',N'Đỗ Hải Yến','154567890','0163954355',N'Tân Bình','2015-11-10','1992-03-08',N'Kế toán','true','')
INSERT INTO dbo.NhanVien VALUES('NV05',N'Trần Minh Tâm','152125588','01639550425',N'Phú Nhuận','2014-11-03','1995-04-08',N'Kế toán','true','')
INSERT INTO dbo.NhanVien VALUES('NV06',N'Nguyễn Lê Quang','152556678','01642949275',N'Gò Vấp','2016-12-04','1992-08-21',N'Phục vụ','true','')
INSERT INTO dbo.NhanVien VALUES('NV07',N'Trần Hải Quang','152123465','0965383988',N'Gò Vấp','2016-01-03','1989-09-28',N'Phục vụ','true','')
INSERT INTO dbo.NhanVien VALUES('NV08',N'Trần Hải Long','175346687','01646556454',N'Phú Nhuận','2017-01-03','1989-09-28',N'Phục vụ','true','')
INSERT INTO dbo.NhanVien VALUES('NV09',N'Lê Hải Bình','156786544','01645354455',N'Gò Vấp','2016-05-03','1999-01-17',N'Phục vụ','true','')
INSERT INTO dbo.NhanVien VALUES('NV10',N'Lê Duy Hồng','173987634','01634354345',N'Tân Bình','2016-08-09','1999-08-17',N'Phục vụ','true','')
--insert Ban an--
INSERT INTO dbo.BanAn VALUES(N'Bàn 1',N'Có người')
INSERT INTO dbo.BanAn VALUES(N'Bàn 2',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 3',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 4',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 5',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 6',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 7',N'Có người')
INSERT INTO dbo.BanAn VALUES(N'Bàn 8',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 9',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 10',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 11',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 12',N'Có người')
INSERT INTO dbo.BanAn VALUES(N'Bàn 13',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 14',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 15',N'Trống')
INSERT INTO dbo.BanAn VALUES(N'Bàn 16',N'Trống')

--insert HoaDon
INSERT INTO HOaDon VALUES('2017-12-11',2,10,0)
INSERT INTO HOaDon VALUES('2017-03-11',3,20,0)
INSERT INTO HOaDon VALUES('2017-12-11',4,10,0)
INSERT INTO HOaDon VALUES('2017-12-11',5,0,0)
INSERT INTO HOaDon VALUES('2017-12-11',1,10,0)
INSERT INTO HOaDon VALUES('2017-12-11',6,15,0)
INSERT INTO HOaDon VALUES('2017-12-11',7,0,0)
INSERT INTO HOaDon VALUES('2017-12-11',8,0,0)
INSERT INTO HOaDon VALUES('2017-12-11',9,0,0)
INSERT INTO HOaDon VALUES('2017-12-11',10,10,0)

--insert Loai mon--
INSERT INTO LoaiMon VALUES (N'Đồ uống','')
INSERT INTO LoaiMon VALUES (N'Bánh Ngọt','')
INSERT INTO LoaiMon VALUES (N'Đồ ăn','')

--insert Mon an
INSERT INTO MonAn VALUES(N'Cafe Sữa',1,'15000','')
INSERT INTO MonAn VALUES(N'Cafe đá',1,'15000','')
INSERT INTO MonAn VALUES(N'Sting',1,'10000','')
INSERT INTO MonAn VALUES(N'Trà xanh',1,'11000','')
INSERT INTO MonAn VALUES(N'CoCaCoLa',1,'8000','')
INSERT INTO MonAn VALUES(N'Bánh Bông Lan',2,'15000','')

--insert ChiTietHD
INSERT INTO ChiTietHD VALUES (1,1,1,'15000')
INSERT INTO ChiTietHD VALUES (2,2,1,'15000')
INSERT INTO ChiTietHD VALUES (3,3,1 ,'15000')
INSERT INTO ChiTietHD VALUES (4,4,1,'15000')
INSERT INTO ChiTietHD VALUES (5,1,1,'15000')
INSERT INTO ChiTietHD VALUES (6,6,1,'15000')
INSERT INTO ChiTietHD VALUES (7,3,2,'20000')
INSERT INTO ChiTietHD VALUES (8,4,3,'33000')
INSERT INTO ChiTietHD VALUES (9,1,4,'32000')
INSERT INTO ChiTietHD VALUES (6,6,5,'75000')

--INSERT Tai khoan--
INSERT INTO TaiKhoan VALUES('TK01','sytungnow','123456',1,'NV01')
INSERT INTO TaiKhoan VALUES('TK02','tramy96','123456',1,'NV02')
INSERT INTO TaiKhoan VALUES('TK03','liemdo96','123456',2,'NV03')
INSERT INTO TaiKhoan VALUES('TK04','haiyen01','123456',1,'NV04')
INSERT INTO TaiKhoan VALUES('TK05','minhtam01','123456',2,'NV05')
INSERT INTO TaiKhoan VALUES('TK06','quangle97','123456',2,'NV06')

--Insert tinh cong--
INSERT INTO ChamCong VALUES('CC01','NV01','2017-01-23',2)
INSERT INTO ChamCong VALUES('CC02','NV02','2017-01-23',3)
INSERT INTO ChamCong VALUES('CC03','NV03','2017-01-23',2)
INSERT INTO ChamCong VALUES('CC04','NV04','2017-01-23',1)
INSERT INTO ChamCong VALUES('CC05','NV05','2017-01-23',2)
INSERT INTO ChamCong VALUES('CC06','NV06','2017-01-23',1)
INSERT INTO ChamCong VALUES('CC07','NV07','2017-01-23',2)
INSERT INTO ChamCong VALUES('CC08','NV07','2017-01-23',2)
INSERT INTO ChamCong VALUES('CC09','NV09','2017-01-23',3)
INSERT INTO ChamCong VALUES('CC10','NV10','2017-01-23',2)

--insert PhieuXuat--
INSERT INTO PhieuXuat VALUES('PX01','2017/10/11','NV01','')
INSERT INTO PhieuXuat VALUES('PX02','2017/10/11','NV02','')
INSERT INTO PhieuXuat VALUES('PX03','2017/10/11','NV03','')
INSERT INTO PhieuXuat VALUES('PX04','2017/10/11','NV04','')
INSERT INTO PhieuXuat VALUES('PX05','2017/10/11','NV05','')
INSERT INTO PhieuXuat VALUES('PX06','2017/10/11','NV06','')
INSERT INTO PhieuXuat VALUES('PX07','2017/10/11','NV07','')
INSERT INTO PhieuXuat VALUES('PX08','2017/10/11','NV08','')
INSERT INTO PhieuXuat VALUES('PX09','2017/10/11','NV09','')

--insert NhaCC--
INSERT INTO NhaCungCap VALUES('NCC01',N'Công ty cafe Trung Nguyên',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC02',N'Công ty đường',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC03',N'Công ty cafe bánh ngọt',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC04',N'Công ty nước giải khát',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC05',N'Công ty Sữa ViNaMilk',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC06',N'Công ty sữa Mộc Châu',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC07',N'Công ty nươc cam',N'Gò Vấp','0987417447')
INSERT INTO NhaCungCap VALUES('NCC08',N'Công ty cafe G7',N'Gò Vấp','0987417447')

--INSERT phieu nhap--
INSERT INTO PhieuNhap VALUES('PN01','2017-10-31','NV01','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN02','2017-10-31','NV02','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN03','2017-10-31','NV03','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN04','2017-10-31','NV04','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN05','2017-10-31','NV05','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN06','2017-10-31','NV06','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN07','2017-10-31','NV07','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN08','2017-10-31','NV08','NCC01','','25000')
INSERT INTO PhieuNhap VALUES('PN09','2017-10-31','NV09','NCC01','','25000')

--insert loai hang
INSERT INTO LoaiHang VALUES('MLH01',N'Làm Bánh')
INSERT INTO LoaiHang VALUES('MLH02',N'Làm đồ uống')
INSERT INTO LoaiHang VALUES('MLH03',N'Pha cafe')
INSERT INTO LoaiHang VALUES('MLH04',N'Pha sinh tố')


--insert MatHang--
INSERT INTO MatHang VALUES('MH01',N'Đường','MLH01',100)
INSERT INTO MatHang VALUES('MH02',N'Sữa','MLH02',100)
INSERT INTO MatHang VALUES('MH03',N'Cafe','MLH03',100)
INSERT INTO MatHang VALUES('MH04',N'Ca cao','MLH04',100)
INSERT INTO MatHang VALUES('MH05',N'Bột mì','MLH03',100)
INSERT INTO MatHang VALUES('MH06',N'Hương tổng hợp','MLH02',100)
INSERT INTO MatHang VALUES('MH07',N'Kem','MLH02',100)

--ChiTietPhieuNhap--
INSERT INTO ChiTietPhieuNhap VALUES('CTPN01','PN01','MH01',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN02','PN02','MH02',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN03','PN03','MH03',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN04','PN04','MH04',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN05','PN05','MH05',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN06','PN06','MH06',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN07','PN07','MH07',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN08','PN08','MH06',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN09','PN09','MH01',10,'15000','')
INSERT INTO ChiTietPhieuNhap VALUES('CTPN10','PN09','MH02',10,'15000','')

--ChiTietPhieuXuat--
INSERT INTO ChiTietPhieuXuat VALUES('CTPX01','PX01','MH01',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX02','PX02','MH02',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX03','PX03','MH03',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX04','PX04','MH04',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX05','PX05','MH05',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX06','PX06','MH06',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX07','PX07','MH07',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX08','PX08','MH01',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX09','PX09','MH02',10,'')
INSERT INTO ChiTietPhieuXuat VALUES('CTPX10','PX09','MH03',10,'')


CREATE VIEW ThucDon
AS
select MonAn.MaMonAn, MonAn.TenMonAn, LoaiMon.TenLoaiMon, MonAn.Gia, MonAn.HinhAnh
from MonAn, LoaiMon 
where LoaiMon.MaLoaiMon = MonAn.MaLoaiMon 
GO

CREATE VIEW LoadLoaiMon
AS
SELECT MaLoaiMon,TenLoaiMon
FROM dbo.LoaiMon
GO

CREATE VIEW LoadTK
AS
SELECT MaTK, TenDangNhap, ChucVu, MK, NhanVien.MaNV
FROM dbo.TaiKhoan, dbo.NhanVien
WHERE TaiKhoan.MaNV = NhanVien.MaNV
GO

--Drop view TKDoanhThu
CREATE VIEW TKDoanhThu
AS
SELECT ChiTietHD.MaHD,NgayLap, MonAn.MaMonAn, SoLuong,MonAn.Gia,ThanhTien
FROM dbo.HoaDon, dbo.ChiTietHD,dbo.MonAn
WHERE dbo.HoaDon.MaHD = dbo.ChiTietHD.MaHD AND dbo.MonAn.MaMonAn=dbo.ChiTietHD.MaMonAn
GO

--alter table dbo.ChiTietHD add DonGia smallmoney

CREATE VIEW TKPhieuNhap
AS
SELECT MaPhieuNhap, NgayNhap, MaNV, MaNhaCC, MaMH, SoLuongNhap, DonGia
FROM dbo.PhieuNhap, dbo.ChiTietPhieuNhap
WHERE dbo.PhieuNhap.MaPhieNhap = dbo.ChiTietPhieuNhap.MaPhieuNhap
GO

CREATE VIEW TKPhieuXuat
AS
SELECT PhieuXuat.MaPhieuXuat, NgayXuat, MaNV, MaMH, SoLuongXuat
FROM dbo.PhieuXuat, dbo.ChiTietPhieuXuat
WHERE dbo.PhieuXuat.MaPhieuXuat = dbo.ChiTietPhieuXuat.MaPhieuXuat
GO

Create Proc PR_GETMaNhanVien(@MaNV char(5) OUTPUT) 
AS 
BEGIN 
    SET @MaNV =( 
        Select Top(1) MaNV
        From NhanVien 
        order by MaNV desc); 
END 
GO 

Create Proc PR_GETMaMonAn(@MaMA int OUTPUT) 
AS 
BEGIN 
    SET @MaMA =( 
        Select Top(1) MaMonAn
        From MonAn 
        order by MaMonAn desc); 
END  
GO

Create Proc PR_GETMaLoaiMon(@MaLM int OUTPUT) 
AS 
BEGIN 
    SET @MaLM =( 
        Select Top(1) MaLoaiMon
        From LoaiMon 
        order by MaLoaiMon desc); 
END  
GO

Create Proc PR_GETMaChamCong(@MaCC char(5) OUTPUT) 
AS 
BEGIN 
    SET @MaCC =( 
        Select Top(1) MaChamCong
        From ChamCong 
        order by MaChamCong desc); 
END  
GO

Create Proc PR_GETMaKhachHang(@MaKH char(5) OUTPUT) 
AS 
BEGIN 
    SET @MaKH =( 
        Select Top(1) MaKH
        From KhachHang 
        order by MaKH desc); 
END  
GO

Create Proc PR_GETMaNCC(@MaNCC char(5) OUTPUT) 
AS 
BEGIN 
    SET @MaNCC =( 
        Select Top(1) MaNhaCC
        From NhaCungCap 
        order by MaNhaCC desc); 
END  
GO


Create Proc PR_GETMaTaiKhoan(@MaTK char(5) OUTPUT) 
AS 
BEGIN 
    SET @MaTK =( 
        Select Top(1) MaTK
        From TaiKhoan 
        order by MaTK desc); 
END  
GO
Create Proc PR_GETDanhSachBan
AS SELECT *FROM dbo.BanAn
GO

--exec PR_GETMaLoaiMon 1
--ALTER TABLE dbo.BanAn
--ALTER COLUMN TrangThai nvarchar(10) NOT NULL

--UPDATE dbo.BanAn
--SET TrangThai = N'Trống'
--WHERE MaBan = 'B15';

--drop proc PR_GETMaMonAn
--ALTER TABLE dbo.HoaDon ADD TinhTrang BIT NOT NULL CONSTRAINT DF_MyTable_MyColumn DEFAULT 'true'
--ALTER TABLE dbo.HoaDon
--DROP CONSTRAINT DF_MyTable_MyColumn

--UPDATE dbo.HoaDon
--SET TinhTrang = '0'
--WHERE MaHD = 'HD01';

--select * from dbo.HoaDon where MaBan=N'B01' and TinhTrang = 'false'
--select * from dbo.ChiTietHD where MaHD=N'HD04' 
--select * from  dbo.ChiTietHD as bi,dbo.HoaDon as b, dbo.MonAn as f 
--where bi.MaHD = b.MaHD and bi.MaMonAn = f.MaMonAn and b.MaBan = 1
--select f.TenMonAn, bi.SoLuong,f.Gia,f.Gia*bi.SoLuong as ThanhTien from  dbo.ChiTietHD as bi,dbo.HoaDon as b, dbo.MonAn as f 
--where bi.MaHD = b.MaHD and bi.MaMonAn = f.MaMonAn and b.TinhTrang=0 and b.MaBan = 1

--select MaMonAn, TenMonAn,MaLoaiMon,Gia from dbo.MonAn where MaLoaiMon =3
--select MaLoaiMon,TenLoaiMon from dbo.LoaiMon
--ALTER TABLE dbo.HoaDon
--ALTER COLUMN TinhTrang tinyint NOT NULL
--alter table dbo.ChiTietHD
--drop column ThanhTien

--select * from dbo.HoaDon where MaBan=N'B02' and TinhTrang = '0'

--ALTER TABLE dbo.ChiTietHD
--ALTER COLUMN MaHD int NOT NULL


--ALTER TABLE dbo.HoaDon
--ALTER COLUMN MaHD int 
--SELECT ChiTietHD.MaHD,NgayLap, MaMonAn, SoLuong,ThanhTien
--FROM dbo.HoaDon, dbo.ChiTietHD
--WHERE dbo.HoaDon.MaHD = dbo.ChiTietHD.MaHD
--select MaMonAn,TenMonAn,LoaiMon.MaLoaiMon,Gia 
--from dbo.MonAn,dbo.LoaiMon
-- where dbo.LoaiMon.MaLoaiMon=dbo.MonAn.MaLoaiMon and dbo.MonAn.MaLoaiMon =3
--Go

--DROP PROC PR_InsertHD
CREATE PROC PR_InsertHD
@MaBan INT
AS
BEGIN
	INSERT dbo.HoaDon
		  ( 
			NgayLap, 
			MaBan,
			TinhTrang,
			GiamGia
		   )
	VALUES(GETDATE(),@MaBan,0,0) 
END
GO
CREATE PROC PR_InsertCTHD
@MaHD INT, @MaMonAn INT, @SoLuong INT, @ThanhTien INT
AS
BEGIN
	DECLARE @isExitsCTHD INT ;
	DECLARE @SoLuongMA INT =1 ;
	SELECT @isExitsCTHD = MaCTHD ,@SoLuongMA= SoLuong FROM dbo.ChiTietHD WHERE MaHD= @MaHD and MaMonAn=@MaMonAn 
	IF(@isExitsCTHD>0)
	BEGIN
		DECLARE @newSL INT = @SoLuongMA +@SoLuong
		IF (@newSL>0)
			UPDATE dbo.ChiTietHD SET SoLuong = @SoLuongMA+ @SoLuong WHERE MaHD = @MaHD AND  MaMonAn= @MaMonAn
		ELSE 
			DELETE dbo.ChiTietHD WHERE MaHD= @MaHD AND MaMonAn= @MaMonAn
	END
	ELSE 
	BEGIN
		INSERT dbo.ChiTietHD
		  (
			MaHD, 
			MaMonAn,
			SoLuong,
			ThanhTien
		   )
		VALUES(@MaHD,@MaMonAn,@SoLuong,@ThanhTien)
	END 
END
GO

--ALTER TABLE dbo.ChiTietHD DROP COLUMN DonGia
--SELECT MAX(MaHD) FROM dbo.HoaDon

--DBCC CHECKIDENT ('dbo.HoaDon', RESEED, 0)
--UPDATE dbo.HoaDon SET TinhTrang =1 Where MaHD=1
--DELETE dbo.ChiTietHD
--DELETE dbo.HoaDon
CREATE TRIGGER TG_UpdateCTHD
ON dbo.ChiTietHD FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maHD INT
	SELECT @maHD= MaHD FROM inserted
	DECLARE @maBan INT
	SELECT @maBan= MaBan FROM dbo.HoaDon WHERE MaHD=@maHD AND TinhTrang =0
	DECLARE @count INT
	SELECT @count=COUNT(*) FROM dbo.ChiTietHD WHERE MaHD=@maHD
	IF(@count>0)
	BEGIN
		UPDATE dbo.BanAn SET TrangThai=N'Có người' WHERE MaBan= @maBan	
	END
	ELSE
	BEGIN
		UPDATE dbo.BanAn SET TrangThai=N'Trống' WHERE MaBan= @maBan
	END

END
GO


CREATE TRIGGER TG_UpdateHD
ON dbo.HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @maHD INT
	SELECT @maHD= MaHD FROM inserted
	DECLARE @maBan INT
	SELECT @maBan= MaBan FROM dbo.HoaDon WHERE MaHD=@maHD 
	DECLARE @soLuong INT=0
	SELECT @soLuong=COUNT(*) FROM dbo.HoaDon WHERE MaBan = @maBan AND TinhTrang=0
	IF(@soLuong=0)
		UPDATE dbo.BanAn SET TrangThai = N'Trống' WHERE MaBan= @maBan
END
GO

--ALTER TABLE dbo.HoaDon ADD GiamGia INT
--UPDATE dbo.HoaDon SET GiamGia =0

ALTER PROC PR_ChuyenBan
@MaBan1 INT, @MaBan2 INT 	
AS
BEGIN
	DECLARE @MaHD1 INT
	DECLARE @MaHD2 INT
	DECLARE @ISBan1Trong INT =1
	DECLARE @ISBan2Trong INT =1
	select @MaHD2= MaHD from dbo.HoaDon where MaBan= @MaBan2 and TinhTrang = 0
	select @MaHD1= MaHD from dbo.HoaDon where MaBan= @MaBan1 and TinhTrang = 0
	IF(@MaHD1 IS NULL)
	BEGIN
		INSERT dbo.HoaDon 
			( NgayLap,
			  MaBan,
			  TinhTrang,
			  GiamGia
			)
		VALUES (GETDATE(), @MaBan1,0,0)
		SELECT @MaHD1 = MAX(MaHD) FROM dbo.HoaDon WHERE MaBan= @MaBan1 AND TinhTrang = 0
	END
	SELECT @ISBan1Trong = COUNT(*) FROM dbo.ChiTietHD WHERE MaHD= @MaHD1
	IF(@MaHD2 IS NULL)
	BEGIN
		INSERT dbo.HoaDon 
			( NgayLap,
			  MaBan,
			  TinhTrang,
			  GiamGia
			)
		VALUES (GETDATE(), @MaBan2,0,0)
		SELECT @MaHD2 = MAX(MaHD) FROM dbo.HoaDon WHERE MaBan= @MaBan2 AND TinhTrang =0
	END
	SELECT @ISBan2Trong = COUNT(*) FROM dbo.ChiTietHD WHERE MaHD= @MaHD2
	SELECT MaCTHD INTO MaBanCTHD FROM dbo.ChiTietHD WHERE MaHD = @MaHD2
	UPDATE dbo.ChiTietHD SET MaHD= @MaHD2 WHERE MaHD=@MaHD1
	UPDATE dbo.ChiTietHD SET MaHD=@MaHD1 WHERE MaCTHD  IN (SELECT * FROM MaBanCTHD)
	DROP TABLE MaBanCTHD
	IF(@ISBan1Trong=0)
		UPDATE dbo.BanAn SET TrangThai=N'Trống' WHERE MaBan=@MaBan2
		--DELETE FROM dbo.HoaDon where MaBan=@MaBan2 and TinhTrang=0
	IF(@ISBan2Trong=0)
		UPDATE dbo.BanAn SET TrangThai=N'Trống' WHERE MaBan=@MaBan1
		--DELETE FROM dbo.HoaDon where MaBan=@MaBan1 and TinhTrang=0

END
GO

--ALTER VIEW ReportHoaDon
--AS
--SELECT HoaDon.MaHD,NgayLap,BanAn.TenBan,TinhTrang,GiamGia,MonAn.TenMonAn, SoLuong,MonAn.Gia,ThanhTien
--FROM dbo.HoaDon, dbo.ChiTietHD,dbo.MonAn,dbo.BanAn
--WHERE dbo.HoaDon.MaHD = dbo.ChiTietHD.MaHD AND dbo.MonAn.MaMonAn=dbo.ChiTietHD.MaMonAn AND dbo.BanAn.MaBan=dbo.HoaDon.MaBan
--GO

CREATE VIEW ReportHoaDon1
AS
SELECT HoaDon.MaHD,NgayLap,BanAn.TenBan,TinhTrang,GiamGia,MonAn.TenMonAn, SoLuong,MonAn.Gia,ThanhTien
FROM dbo.HoaDon, dbo.ChiTietHD,dbo.MonAn,dbo.BanAn
WHERE dbo.HoaDon.MaHD = dbo.ChiTietHD.MaHD AND dbo.MonAn.MaMonAn=dbo.ChiTietHD.MaMonAn AND dbo.BanAn.MaBan=dbo.HoaDon.MaBan
GO

EXEC dbo.PR_ChuyenBan @MaBan1 =5, @MaBan2 =6
select MaHD,NgayLap,TenBan,GiamGia,TenMonAn, SoLuong,Gia,ThanhTien from ReportHoaDon1 Where MaHD =19