USE QlCafe
GO

-- --- PHIEU XUAT ---

-- 1. Lấy danh sách phiếu xuất
CREATE PROCEDURE PR_GetDanhSachPhieuXuat
AS
BEGIN
    SELECT * FROM PhieuXuat
END
GO

-- 2. Thêm phiếu xuất
CREATE PROCEDURE PR_InsertPhieuXuat
    @MaPhieuXuat CHAR(5),
    @NgayXuat SMALLDATETIME,
    @MaNV CHAR(5),
    @LyDoXuat NVARCHAR(50)
AS
BEGIN
    INSERT INTO PhieuXuat (MaPhieuXuat, NgayXuat, MaNV, LyDoXuat)
    VALUES (@MaPhieuXuat, @NgayXuat, @MaNV, @LyDoXuat)
END
GO

-- 3. Sửa phiếu xuất
CREATE PROCEDURE PR_UpdatePhieuXuat
    @MaPhieuXuat CHAR(5),
    @NgayXuat SMALLDATETIME,
    @MaNV CHAR(5),
    @LyDoXuat NVARCHAR(50)
AS
BEGIN
    UPDATE PhieuXuat
    SET NgayXuat = @NgayXuat, MaNV = @MaNV, LyDoXuat = @LyDoXuat
    WHERE MaPhieuXuat = @MaPhieuXuat
END
GO

-- 4. Xóa phiếu xuất
CREATE PROCEDURE PR_DeletePhieuXuat
    @MaPhieuXuat CHAR(5)
AS
BEGIN
    DELETE FROM PhieuXuat WHERE MaPhieuXuat = @MaPhieuXuat
END
GO

-- 5. Lấy Mã Phiếu Xuất lớn nhất (để sinh mã)
CREATE PROCEDURE PR_GetMaxMaPhieuXuat
AS
BEGIN
    SELECT MAX(MaPhieuXuat) FROM PhieuXuat
END
GO

-- --- CHI TIET PHIEU XUAT ---

-- 6. Lấy danh sách chi tiết theo Mã phiếu xuất
CREATE PROCEDURE PR_GetDanhSachChiTietPhieuXuat
    @MaPhieuXuat CHAR(5)
AS
BEGIN
    SELECT * FROM ChiTietPhieuXuat WHERE MaPhieuXuat = @MaPhieuXuat
END
GO

-- 7. Thêm chi tiết phiếu xuất
CREATE PROCEDURE PR_InsertChiTietPhieuXuat
    @MaCTPX CHAR(7),
    @MaPhieuXuat CHAR(5),
    @MaMH CHAR(5),
    @SoLuongXuat TINYINT,
    @GhiChu NVARCHAR(50)
AS
BEGIN
    INSERT INTO ChiTietPhieuXuat (MaCTPX, MaPhieuXuat, MaMH, SoLuongXuat, GhiChu)
    VALUES (@MaCTPX, @MaPhieuXuat, @MaMH, @SoLuongXuat, @GhiChu)
END
GO

-- 8. Sửa chi tiết phiếu xuất
CREATE PROCEDURE PR_UpdateChiTietPhieuXuat
    @MaCTPX CHAR(7),
    @MaMH CHAR(5),
    @SoLuongXuat TINYINT,
    @GhiChu NVARCHAR(50)
AS
BEGIN
    UPDATE ChiTietPhieuXuat
    SET MaMH = @MaMH, SoLuongXuat = @SoLuongXuat, GhiChu = @GhiChu
    WHERE MaCTPX = @MaCTPX
END
GO

-- 9. Xóa chi tiết phiếu xuất
CREATE PROCEDURE PR_DeleteChiTietPhieuXuat
    @MaCTPX CHAR(7)
AS
BEGIN
    DELETE FROM ChiTietPhieuXuat WHERE MaCTPX = @MaCTPX
END
GO

-- 10. Lấy Mã CTPX lớn nhất
CREATE PROCEDURE PR_GetMaxMaCTPX
AS
BEGIN
    SELECT MAX(MaCTPX) FROM ChiTietPhieuXuat
END
GO

-- --- MAT HANG & NHAN VIEN ---

-- 11. Cập nhật số lượng mặt hàng
CREATE PROCEDURE PR_UpdateSoLuongMatHang
    @MaMH CHAR(5),
    @SoLuong INT
AS
BEGIN
    UPDATE MatHang SET SoLuong = @SoLuong WHERE MaMH = @MaMH
END
GO

-- 12. Lấy thông tin mặt hàng
CREATE PROCEDURE PR_GetMatHangByMaMH
    @MaMH CHAR(5)
AS
BEGIN
    SELECT * FROM MatHang WHERE MaMH = @MaMH
END
GO

-- 13. Lấy danh sách nhân viên (đã có thể có, nhưng viết lại cho chắc chắn hoặc dùng PR_GETNhanVien nếu có)
CREATE PROCEDURE PR_GetDanhSachNhanVien
AS
BEGIN
    SELECT MaNV, TenNV FROM NhanVien
END
GO
