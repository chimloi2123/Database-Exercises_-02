﻿use HoaYeuThuong
go
--Xem danh sách sản phẩm của hàng
CREATE PROCEDURE XEM_DS_SP
(
	@TENCH NVARCHAR(50)
)
AS 
	BEGIN TRAN
		SELECT SP.TENSP,SP.GIABAN,SP.CHUDE FROM SANPHAM SP, SANPHAM_CUAHANG SPCH, CUAHANG CH WHERE SP.MASP = SPCH.MASP and SPCH.MACH = CH.MACH and CH.TENCH = @TENCH
	COMMIT TRAN
GO

--Tìm kiếm sản phẩm của cửa hàng
CREATE PROCEDURE TIM_SP
(
	@TENCH NVARCHAR(50),
	@TENSP NVARCHAR(50)
)
AS 
	BEGIN TRAN
		SELECT SP.TENSP,SP.GIABAN,SP.CHUDE FROM SANPHAM SP, SANPHAM_CUAHANG SPCH, CUAHANG CH WHERE SP.MASP = SPCH.MASP and SPCH.MACH = CH.MACH and CH.TENCH = @TENCH and SP.TENSP = @TENSP
	COMMIT TRAN
GO

--Thống kế doanh thu của cửa hàng
CREATE PROCEDURE DOANHTHU_CH
(
	@TENCH NVARCHAR(50),
	@THANG int
)
AS 
	BEGIN TRAN
		SELECT  SUM(TONGTIENTHUC) AS DOANHTHU 
		FROM DONDATHANG DH, CUAHANG CH,SANPHAM_CUAHANG SPCH, CT_DONDATHANG CTDH, SANPHAM SP
		WHERE SPCH.MACH = CH.MACH and SPCH.MASP = SP.MASP and CTDH.MASP = SP.MASP and DH.MADH = CTDH.MADH and CH.TENCH = @TENCH and MONTH(DH.NGAYDAT) = @THANG
	COMMIT TRAN
GO

--Thêm sản phẩm mới
CREATE PROCEDURE THEMSANPHAM
(
	@TENSP NVARCHAR(50),
	@CHUDE NVARCHAR(50),
	@GIABAN MONEY,
	@MALOAI int
)
AS 
	BEGIN TRAN
	IF EXISTS (SELECT * FROM SANPHAM WHERE TenSP = @TENSP)
	BEGIN
		PRINT N'Sản phẩm đã tồn tại'
		ROLLBACK TRAN
		RETURN
	END
	ELSE
	BEGIN
		INSERT INTO SANPHAM(TENSP, CHUDE, GIABAN, MALOAI) VALUES (@TENSP,@CHUDE,@GIABAN,@MALOAI)
	END
	COMMIT
GO
--Sửa sản phẩm
CREATE PROCEDURE SUASANPHAM
(
	@TENSP NVARCHAR(50),
	@CHUDE NVARCHAR(50),
	@GIABAN MONEY,
	@MALOAI int
)
AS 
	BEGIN TRAN
	IF EXISTS (SELECT * FROM SANPHAM WHERE TenSP != @TENSP)
	BEGIN
		PRINT N'Sản phẩm không tồn tại'
		ROLLBACK TRAN
		RETURN
	END
	ELSE
	BEGIN
		UPDATE SANPHAM SET CHUDE = @CHUDE, GIABAN = @GIABAN , MALOAI = @MALOAI WHERE TENSP = @TENSP
	END
	COMMIT
GO
--Xóa sản phẩm
CREATE PROCEDURE XOASANPHAM
(
	@TENSP NVARCHAR(50)
)
AS 
	BEGIN TRAN
	IF EXISTS (SELECT * FROM SANPHAM WHERE TenSP != @TENSP)
	BEGIN
		PRINT N'Sản phẩm không tồn tại'
		ROLLBACK TRAN
		RETURN
	END
	ELSE
	BEGIN
		DELETE FROM SANPHAM WHERE TENSP = @TENSP
	END
	COMMIT
GO

--Lưu vết giá sản phẩm
CREATE PROCEDURE LUUVETGIA
AS 
	BEGIN TRAN
		SELECT DISTINCT SP.TENSP, CTDH.DONGIA 
	    FROM SANPHAM SP, CT_DONDATHANG CTDH
	    WHERE SP.MASP = CTDH.MASP

	COMMIT TRAN
GO

--Lich su nhap hang
CREATE PROCEDURE LICHSUNHAP
(
	@TENCH NVARCHAR(50)
)
AS 
	BEGIN TRAN
		SELECT SP.TENSP, CTGH.NGAYGIAO, CTGH.SLGIAO
	     FROM CUAHANG CH, DONNHAPHANG DNH, DONGIAOHANG DGH, CT_GIAOHANG CTGH, CT_DONNHAP CTDN, SANPHAM SP
	     WHERE CTGH.MADGH = DGH.MADGH and DGH.MADNH = DNH.MADNH and CH.TENCH = @TENCH
	COMMIT
GO

--Lich su giao hang
CREATE PROCEDURE LICHSUGIAO
(
	@TENCH NVARCHAR(50)
)
AS 
	BEGIN TRAN
		SELECT SP.TENSP, CTDH.SOLUONG, DH.NGAYGIAO
	     FROM CUAHANG CH, SANPHAM_CUAHANG SPCH, SANPHAM SP, CT_DONDATHANG CTDH, DONDATHANG DH    
		 WHERE SPCH.MACH = CH.MACH and SPCH.MASP = SP.MASP and CTDH.MASP = SP.MASP and DH.MADH = CTDH.MADH and CH.TENCH = ‘A’
	COMMIT
GO
--DiemDanh
CREATE PROCEDURE DIEMDANH
(
	@MANV INT, @NGAY DATE
)
AS 
	BEGIN TRAN
		INSERT INTO DIEMDANH VALUES(@MANV, @NGAY)
	COMMIT
GO
---Xem lich su luong thuong cua nhan vien
CREATE PROCEDURE XEMLUONGTHUONG

AS 
	BEGIN TRAN
		SELECT * FROM LUONGTHUONG GROUP BY MANV
	COMMIT
GO

--Xem so luong ton
create proc sp_XemSLTonSP
	@MACH int
as
begin tran
	Select * from SANPHAM_CUAHANG where MACH = @MACH
commit tran

go

--Xem CT nhap hang
create proc sp_XemCTNhapHang
	@MADNH int
as
begin tran
	Select * from CT_DONNHAP where MADNH = @MADNH
commit tran

go

--Xem CT giao hang
create proc sp_XemCTGiaoHang
	@MADGH int
as
begin tran
	Select * from CT_GIAOHANG where MADGH = @MADGH
commit tran

go

--Xem san pham ban chay
create proc sp_XemSanPhamBanChay 
as
begin tran
	Select MASP, SUM(SOLUONG) as TONGSOBAN
	From CT_DONDATHANG
	Group by MASP
	Order by TONGSOBAN desc
	--LIMIT 20
commit

go

--Xem san pham ban cham
create proc sp_XemSanPhamBanCham
as
begin tran
	Select MASP, SUM(SOLUONG) as TONGSOBAN
	From CT_DONDATHANG
	Group by MASP
	Order by TONGSOBAN
	--LIMIT 20
commit

go

--Xem so luong hang
create proc sp_XemTongSoLuongHang
as
begin tran
	Select sp.MASP, sp.TENSP, SUM(sc.SLTON)
	From SANPHAM sp, SANPHAM_CUAHANG sc
	Where sp.MASP = sc.MASP
	Group by sp.MASP, sp.TENSP
commit

go



