USE DuAnMau_FluentAPI
GO
INSERT INTO dbo.NhanVien
(
    MaNV,
    Id,
    Email,
    TenNv,
    DiaChi,
    VaiTro,
    TinhTrang,
    flag,
    MatKhau
)
VALUES
( N'NV1',  -- MaNV - nvarchar(20)
    1,    -- Id - int
    N'vankieu0409@gmail.com',  -- Email - nvarchar(50)
    N'Nguyễn Văn Kiều',  -- TenNv - nvarchar(50)
    N'Xã Tuân Chính',  -- DiaChi - nvarchar(100)
    1,    -- VaiTro - int
    1, -- TinhTrang - bit
	1,
    N'0409'   -- MatKhau - nvarchar(50)
    )
INSERT INTO dbo.KHACHHANG
	(
	    DienThoai,
	    TenKhach,
	    DiaChi,
	    GioiTinh,
	    flag,
	    MaNV
	)
	VALUES
	(   N'0382802345',  -- DienThoai - nvarchar(15)
	    N'Nguyễn Bậu',  -- TenKhach - nvarchar(50)
	    N'Xã Tuân Chính',  -- DiaChi - nvarchar(100)
	    1,    -- GioiTinh - int
	    1, -- trangthai - bit
	    N'NV1'   -- MaNV - nvarchar(20)
	    )

INSERT INTO dbo.HANG
(
    TenHang,
    SoLuong,
    DonGiaBan,
    DonGiaNhap,
    GhiChu,
    trangthai,
    MaNV
)
VALUES
(   N'Ví Da',  -- TenHang - nvarchar(50)
    20,    -- SoLuong - int
    100,  -- DonGiaBan - float
    250,  -- DonGiaNhap - float
    N'no note',  -- GhiChu - nvarchar(20)
    1, -- trangthai - bit
    N'NV1'   -- MaNV - nvarchar(20)
    )

DELETE FROM dbo.NhanVien WHERE MaNV LIKE 'NV'

SELECT* FROM dbo.NhanVien JOIN dbo.KHACHHANG ON KHACHHANG.MaNV = NhanVien.MaNV
SELECT* FROM dbo.HANG

insert into dbo.NhanVien
(
    MaNV,
    Id,
    Email,
    TenNv,
    DiaChi,
    VaiTro,
    TinhTrang,
    flag,
    MatKhau
)
VALUES
(   N'NV2',  -- MaNV - nvarchar(20)
    2,    -- Id - int
    N'kieunvph14806@fpt.edu.vn',  -- Email - nvarchar(50)
    N'Nguyễn Bậu',  -- TenNv - nvarchar(50)
    N'Xã Tuân Chính',  -- DiaChi - nvarchar(100)
    0,    -- VaiTro - int
    1, -- TinhTrang - bit
    1, -- flag - bit
    N'0409'   -- MatKhau - nvarchar(50)
    )
