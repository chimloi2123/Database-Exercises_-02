use HoaYeuThuong

go

create proc sp_XemSLTonSP
	@MACH int
as
begin tran
	Select * from SANPHAM_CUAHANG where MACH = @MACH
commit tran

go

create proc sp_XemCTNhapHang
	@MADNH int
as
begin tran
	Select * from CT_DONNHAP where MADNH = @MADNH
commit tran

go

create proc sp_XemCTGiaoHang
	@MADGH int
as
begin tran
	Select * from CT_GIAOHANG where MADGH = @MADGH
commit tran

go

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


create proc sp_XemTongSoLuongHang
as
begin tran
	Select sp.MASP, sp.TENSP, SUM(sc.SLTON)
	From SANPHAM sp, SANPHAM_CUAHANG sc
	Where sp.MASP = sc.MASP
	Group by sp.MASP, sp.TENSP
commit

go
