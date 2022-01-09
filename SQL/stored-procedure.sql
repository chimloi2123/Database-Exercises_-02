use HoaYeuThuong

go
alter proc sp_LichSuXuat
	@Ma int,
	@Tu datetime,
	@Den datetime
as
begin tran
	begin try
		select c.SOLUONG, c.DONGIA, c.MADH, d.NGAYDAT 'NGAYXUAT', d.MACH 
		from CT_DONDATHANG c, DONDATHANG d
		where c.MADH = d.MADH and c.MASP = @Ma and d.NGAYDAT between @Tu and @Den
	end try
	begin catch
		rollback tran
		return 0
	end catch
commit tran
return 1

go
alter proc sp_LichSuNhap
	@Ma int,
	@Tu datetime,
	@Den datetime
as
begin tran
	begin try
		select g.MADGH, g.NGAYGIAO, g.SLGIAO, d.MANCC, d.MACH 
		from CT_GIAOHANG g, DONNHAPHANG d 
		where g.MASP = @Ma and g.MADGH = d.MADNH and g.NGAYGIAO between @Tu and @Den
	end try
	begin catch
		rollback tran
		return 0
	end catch
commit tran
return 1

go
alter proc sp_CapNhatSanPham
	@Ma int,
	@Ten nvarchar(30),
	@ChuDe nvarchar(30),
	@GiaBan money,
	@Loai int
as
begin tran
	begin try
		update SANPHAM set TENSP = @Ten, CHUDE = @ChuDe, GIABAN = @GiaBan, MALOAI = @Loai where MASP = @Ma
	end try
	begin catch
		rollback tran
		return 0
	end catch
commit tran
return 1

go
alter proc sp_ThemSanPham
	@Ten nvarchar(30),
	@ChuDe nvarchar(30),
	@GiaBan money,
	@Loai int
as
begin tran
	begin try
		insert into SANPHAM values(@Ten, @ChuDe, @GiaBan, @Loai)
	end try
	begin catch
		rollback tran
		return 0
	end catch
commit tran
return 1

go
alter proc sp_DanhSachSanPham
as
begin tran
	begin try
		select s.*, l.TENLOAI from SANPHAM s, LOAISP l where l.MALOAI = s.MALOAI
	end try
	begin catch
		rollback tran
		return 0
	end catch
commit tran
return 1

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