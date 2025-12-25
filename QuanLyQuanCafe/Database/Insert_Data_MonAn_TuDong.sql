USE [QuanLyQuanCafe]
GO

-- Khai báo biến để lưu ID của các Loại Món
DECLARE @IdCafe INT, @IdSinhTo INT, @IdNuocEp INT, @IdTra INT, @IdAnVat INT, @IdDaXay INT, @IdSuaChua INT, @IdSoda INT, @IdDiemTam INT

-- =============================================
-- 1. XỬ LÝ LOẠI MÓN (CATEGORY)
-- =============================================

-- Cà phê
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Cà phê')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Cà phê')
SELECT @IdCafe = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Cà phê'

-- Sinh tố
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Sinh tố')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Sinh tố')
SELECT @IdSinhTo = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Sinh tố'

-- Nước ép
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Nước ép')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Nước ép')
SELECT @IdNuocEp = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Nước ép'

-- Trà & Trà sữa
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Trà - Trà sữa')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Trà - Trà sữa')
SELECT @IdTra = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Trà - Trà sữa'

-- Đá xay
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Đá xay')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Đá xay')
SELECT @IdDaXay = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Đá xay'

-- Sữa chua
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Sữa chua')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Sữa chua')
SELECT @IdSuaChua = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Sữa chua'

-- Soda - Mojito
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Soda - Mojito')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Soda - Mojito')
SELECT @IdSoda = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Soda - Mojito'

-- Ăn vặt
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Ăn vặt')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Ăn vặt')
SELECT @IdAnVat = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Ăn vặt'

-- Điểm tâm (Ăn sáng/Trưa)
IF NOT EXISTS (SELECT * FROM dbo.LoaiMon WHERE TenLoaiMon = N'Điểm tâm')
    INSERT INTO dbo.LoaiMon (TenLoaiMon) VALUES (N'Điểm tâm')
SELECT @IdDiemTam = MaLoaiMon FROM dbo.LoaiMon WHERE TenLoaiMon = N'Điểm tâm'

-- =============================================
-- 2. THÊM MÓN ĂN (DISHES)
-- Chỉ insert nếu tên món chưa tồn tại trong bảng MonAn
-- =============================================

-- --- NHÓM CÀ PHÊ ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cà phê đen đá')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cà phê đen đá', @IdCafe, 20000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cà phê đen nóng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cà phê đen nóng', @IdCafe, 20000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cà phê sữa đá')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cà phê sữa đá', @IdCafe, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cà phê sữa nóng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cà phê sữa nóng', @IdCafe, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Bạc xỉu')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Bạc xỉu', @IdCafe, 28000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cacao nóng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cacao nóng', @IdCafe, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cà phê cốt dừa')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cà phê cốt dừa', @IdCafe, 40000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cà phê trứng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cà phê trứng', @IdCafe, 45000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Capuchino')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Capuchino', @IdCafe, 40000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Latte')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Latte', @IdCafe, 40000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Mocha')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Mocha', @IdCafe, 42000)

-- --- NHÓM SINH TỐ ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sinh tố bơ')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sinh tố bơ', @IdSinhTo, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sinh tố xoài')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sinh tố xoài', @IdSinhTo, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sinh tố dâu')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sinh tố dâu', @IdSinhTo, 38000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sinh tố mãng cầu')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sinh tố mãng cầu', @IdSinhTo, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sinh tố sapoche')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sinh tố sapoche', @IdSinhTo, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sinh tố cà chua')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sinh tố cà chua', @IdSinhTo, 30000)

-- --- NHÓM NƯỚC ÉP ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Nước ép cam')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Nước ép cam', @IdNuocEp, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Nước ép dưa hấu')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Nước ép dưa hấu', @IdNuocEp, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Nước ép táo')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Nước ép táo', @IdNuocEp, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Nước chanh tươi')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Nước chanh tươi', @IdNuocEp, 20000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Nước ép ổi')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Nước ép ổi', @IdNuocEp, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Nước ép cà rốt')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Nước ép cà rốt', @IdNuocEp, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Chanh dây')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Chanh dây', @IdNuocEp, 25000)

-- --- NHÓM TRÀ & TRÀ SỮA ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà đào cam sả')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà đào cam sả', @IdTra, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà vải')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà vải', @IdTra, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Hồng trà sữa')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Hồng trà sữa', @IdTra, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà sữa thái xanh')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà sữa thái xanh', @IdTra, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà gừng mật ong')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà gừng mật ong', @IdTra, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà sen vàng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà sen vàng', @IdTra, 45000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà lài hạt chia')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà lài hạt chia', @IdTra, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Trà Oolong nướng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Trà Oolong nướng', @IdTra, 35000)

-- --- NHÓM ĐÁ XAY ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Matcha đá xay')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Matcha đá xay', @IdDaXay, 40000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Chocolate đá xay')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Chocolate đá xay', @IdDaXay, 40000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cookie đá xay')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cookie đá xay', @IdDaXay, 42000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Chanh tuyết')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Chanh tuyết', @IdDaXay, 35000)

-- --- NHÓM SỮA CHUA ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sữa chua đá')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sữa chua đá', @IdSuaChua, 20000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sữa chua nếp cẩm')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sữa chua nếp cẩm', @IdSuaChua, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sữa chua mít')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sữa chua mít', @IdSuaChua, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Sữa chua trái cây')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Sữa chua trái cây', @IdSuaChua, 35000)

-- --- NHÓM SODA - MOJITO ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Soda Blue Ocean')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Soda Blue Ocean', @IdSoda, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Soda Bạc hà')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Soda Bạc hà', @IdSoda, 32000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Soda Việt quất')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Soda Việt quất', @IdSoda, 35000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Mojito Chanh dây')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Mojito Chanh dây', @IdSoda, 38000)

-- --- NHÓM ĐIỂM TÂM ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Bánh mì ốp la')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Bánh mì ốp la', @IdDiemTam, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Bò kho bánh mì')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Bò kho bánh mì', @IdDiemTam, 45000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Mì xào bò')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Mì xào bò', @IdDiemTam, 40000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cơm chiên dương châu')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cơm chiên dương châu', @IdDiemTam, 40000)

-- --- NHÓM ĂN VẶT ---
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Hạt hướng dương')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Hạt hướng dương', @IdAnVat, 15000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Khô gà lá chanh')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Khô gà lá chanh', @IdAnVat, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Khoai tây chiên')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Khoai tây chiên', @IdAnVat, 30000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Mì tôm trứng')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Mì tôm trứng', @IdAnVat, 25000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Xúc xích chiên')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Xúc xích chiên', @IdAnVat, 15000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Cá viên chiên')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Cá viên chiên', @IdAnVat, 20000)
IF NOT EXISTS (SELECT * FROM dbo.MonAn WHERE TenMonAn = N'Phô mai que')
    INSERT INTO dbo.MonAn (TenMonAn, MaLoaiMon, Gia) VALUES (N'Phô mai que', @IdAnVat, 30000)

PRINT N'Đã hoàn tất thêm dữ liệu món ăn mở rộng!'
GO