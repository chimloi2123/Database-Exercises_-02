--Trigger kiểm tra NVLAP trong bảng DONNHAPHANG có phải là nhân viên thủ kho hay không 
DROP TRIGGER tg_NVLAP
CREATE TRIGGER tg_NVLAP
ON DONNHAPHANG
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @loaiNV NVARCHAR(20)

	SELECT @loaiNV = LOAINV
	FROM NHANVIEN, inserted
	WHERE MANV = inserted.NVLAP

	if(@loaiNV NOT LIKE N'Nhân viên thủ kho%')
		begin 
		ROLLBACK TRAN
		PRINT('Đơn nhập hàng được thêm không phải do nhân viên thủ kho lập')
		end
END

--Trigger kiểm tra MANVLAP trong bảng có phải là nhân viên bán hàng hay không 
DROP TRIGGER tg_MANVLAP
CREATE TRIGGER tg_MANVLAP
ON DONDATHANG
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @loaiNV NVARCHAR(20)

	SELECT @loaiNV = LOAINV
	FROM NHANVIEN, inserted
	WHERE MANV = inserted.MANVLAP


	if(@loaiNV NOT LIKE N'Nhân viên bán hàng%')
		begin 
		ROLLBACK TRAN
		PRINT('Đơn đặt hàng được thêm không phải do nhân bán hàng lập')
		end
END

--Trigger kiểm tra MANVGIAO trong bảng có phải là nhân viên giao hàng hay không 
DROP TRIGGER tg_MANVGIAO
CREATE TRIGGER tg_MANVGIAO
ON DONDATHANG
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @loaiNV NVARCHAR(20)

	SELECT @loaiNV = LOAINV
	FROM NHANVIEN, inserted
	WHERE MANV = inserted.MANVGIAO

	if(@loaiNV not like N'Nhân viên giao hàng%')
		begin 
		ROLLBACK TRAN
		PRINT('Đơn đặt hàng được thêm không phải nhân viên giao hàng')
		end
END

--Kiem tra gioi tinh
DROP PROC KiemTraGioiTinh
CREATE PROCEDURE KiemTraGioiTinh @maNV int
AS
BEGIN
	DECLARE @GioiTinh BIT
	SET @GioiTinh = (SELECT GIOITINH FROM TT_NHANVIEN WHERE MANV = @maNV)
	IF (@GioiTinh = 0 or @GioiTinh = 1)
		return 1
	ELSE
		return 0
END

--Kiem tra nhan vien 
DROP PROC KiemTraMaNVCoTonTai
CREATE PROCEDURE KiemTraMaNVCoTonTai @maNV int
AS
BEGIN
	DECLARE @maNVtemp int
	SET @maNVtemp = (SELECT MANV FROM NHANVIEN WHERE MANV = @maNV)
	IF (@maNV = @maNVtemp)
		return 1
	ELSE
		return 0
END
	
drop proc TinhDonDaGiao
--Proceduce tính số đơn đặt hàng nhân viên giao hàng đã giao
CREATE PROCEDURE TinhDonDaGiao
AS
BEGIN
	UPDATE NVGIAOHANG
	SET SODONDAGIAO = SODONDAGIAO + s.dem
	FROM NVGIAOHANG p JOIN (SELECT MANVGIAO, COUNT(*) AS dem FROM DONDATHANG WHERE TINHTRANG LIKE N'Đã giao%' GROUP BY MANVGIAO) s
	ON p.MANV = s.MANVGIAO
END

EXEC TinhDonDaGiao

--Proceduce tính số đơn đặt hàng nhân viên bán hàng đã lập
drop proc TinhDonNVBanHang
create proc TinhDonNVBanHang @maNV int, @error varchar(50) out
  as
  begin tran
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
		begin
			declare @ktNV int
			exec @ktNV = KiemTraMaNVCoTonTai @maNV
			if(@ktNV = 0)
				begin
					set @error=N'Nhân viên không tồn tại'
					raiserror(N'Nhân viên không tồn tại', 0, 0)		
					return
				end
			else
				begin
					SELECT MANV, SOLUONGDON
					FROM NHANVIEN nv JOIN (SELECT MANVLAP, COUNT(*) AS SOLUONGDON FROM  DONDATHANG WHERE MANVLAP = @maNV GROUP BY MANVLAP) s
					ON nv.MANV = s.MANVLAP
				end
		end
  commit tran
--
--declare @error varchar(500) 
--exec TinhDonNVBanHang @maNV = 2 ,@error = @error out

--Proceduce tính số đơn nhập hàng nhân viên thủ kho đã lập
drop proc TinhDonNVThuKho
create proc TinhDonNVThuKho @maNV int, @error varchar(50) out
  as
  begin tran
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
		begin
			declare @ktNV int
			exec @ktNV = KiemTraMaNVCoTonTai @maNV
			if(@ktNV = 0)
				begin
					set @error=N'Nhân viên không tồn tại'
					raiserror(N'Nhân viên không tồn tại', 0, 0)		
					return
				end
			else
				begin
					SELECT MANV, SOLUONGDON
					FROM NHANVIEN nv JOIN (SELECT NVLAP, COUNT(*) AS SOLUONGDON FROM  DONNHAPHANG WHERE NVLAP = @maNV GROUP BY NVLAP) s
					ON nv.MANV = s.NVLAP
				end
		end
  commit tran

--Proceduce tính doanh số theo mã nhân viên