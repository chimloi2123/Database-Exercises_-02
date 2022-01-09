use HoaYeuThuong

select * from SANPHAM_CUAHANG



go
alter proc sp_TaoDonNhap
	@MANCC int,
	@MACH int,
	@NgayLap datetime,
	@NgayNhan datetime,
	@NVLAP int
as
begin tran
	begin try
		if not exists (select * from NHACUNGCAP where MANCC = @MANCC)
			return N'Mã nhà cung cấp không tồn tại'
		if not exists (select * from NHANVIEN where MANV = @NVLAP)
			return N'Mã nhân viên không tồn tại'
		if @NgayLap < GETDATE() - 1
			return N'Ngày lập không hợp lệ'
		if @NgayNhan < GETDATE()
			return N'Ngày nhận không hợp lệ'
		insert into DONNHAPHANG values (@MANCC, @MACH, @NgayLap, 0, @NgayNhan, @NVLAP)
	end try
	begin catch
		rollback tran
		return N'LỖI HỆ THỐNG'
	end catch
commit tran
return ''

go
alter proc sp_CapNhatDonNhap
	@ID int,
	@MANCC int,
	@NgayLap datetime,
	@NgayNhan datetime,
	@NVLAP int
as
begin tran
	begin try
		if not exists (select * from NHACUNGCAP where MANCC = @MANCC)
			return N'Mã nhà cung cấp không tồn tại'
		if not exists (select * from NHANVIEN where MANV = @NVLAP)
			return N'Mã nhân viên không tồn tại'
		update DONNHAPHANG set MANCC = @MANCC, NGAYLAP = @NgayLap, NGAYNHANDUKIEN = @NgayNhan, NVLAP = @NVLAP where MADNH = @ID
	end try
	begin catch
		rollback tran
		return N'LỖI HỆ THỐNG'
	end catch
commit tran
return ''