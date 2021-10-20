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
    MatKhau
)
VALUES
(   N'NV1',  -- MaNV - nvarchar(20)
    1,    -- Id - int
    N'vankieu0409@gmail.com',  -- Email - nvarchar(50)
    N'Nguyễn Văn Kiều',  -- TenNv - nvarchar(50)
    N'Xã Tuân Chính',  -- DiaChi - nvarchar(100)
    1,    -- VaiTro - int
    1, -- TinhTrang - bit
    N'0409'   -- MatKhau - nvarchar(50)
    )
	INSERT INTO dbo.KHACHHANG
	(
	    DienThoai,
	    TenKhach,
	    DiaChi,
	    GioiTinh,
	    trangthai,
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
    HinhAnh,
    GhiChu,
    trangthai,
    MaNV
)
VALUES
(   N'Trai đẹp chưa vợ',  -- TenHang - nvarchar(50)
    2,    -- SoLuong - int
    2000,  -- DonGiaBan - float
    500,  -- DonGiaNhap - float
    N'',  -- HinhAnh - nvarchar(400)
    N'aka',  -- GhiChu - nvarchar(20)
    1, -- trangthai - bit
    N'NV1'   -- MaNV - nvarchar(20)
    )

DELETE FROM dbo.NhanVien WHERE MaNV LIKE 'NV'

SELECT* FROM dbo.NhanVien JOIN dbo.KHACHHANG ON KHACHHANG.MaNV = NhanVien.MaNV

insert into NhanViens(id,MaNv,Email,TenNv,DiaChi,VaiTro,TinhTrang,MatKhau)
 values(2, N'NV2',  -- MaNV - nvarchar(20)
        -- Id - int
    N'kieunvph14806@fpt.edu.vn',  -- Email - nvarchar(50)
    N'Nguyễn Văn Kiều',  -- TenNv - nvarchar(50)
    N'Xã Tuân Chính',  -- DiaChi - nvarchar(100)
    1,    -- VaiTro - int
    1, -- TinhTrang - bit
    N'0409',   -- MatKhau - nvarchar(50)
	)