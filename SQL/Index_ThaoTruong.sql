SELECT so.name as TableName
      ,si.name as IndexName
	  ,si.type_desc as IndexType
	FROM SYS.indexes si join sys.objects so on si.[object_id]=so.[object_id]
	where so.type='U' and si.name is not null
	order by so.name,si.type




create nonclustered index IX_SanPham_TenSanPham on SANPHAM(MASP ASC,TENSP)
--INCLUDE (TENSP)

CREATE  NONCLUSTERED INDEX IX_CT_DONDAT_MASP ON CT_DONDATHANG(MASP,MADH)
INCLUDE (DONGIA)


CREATE NONCLUSTERED INDEX IX_DONDAT_NGAYDAT ON DONDATHANG( NGAYDAT desc, tongtienthuc)
CREATE NONCLUSTERED INDEX IX_LUONGTHUONG_SONGAYLAM ON LUONGTHUONG(manv,thang,nam,songaylam)
CREATE NONCLUSTERED INDEX IX_DONDAT_TONGTIEN ON DONDATHANG( tongtienthuc)



DROP INDEX IX_SanPham_TenSanPham ON SANPHAM
DROP INDEX IX_CT_DONDAT_MASP ON CT_DONDATHANG
DROP INDEX IX_DONDAT_TONGTIEN ON DONDATHANG
DROP INDEX IX_LUONGTHUONG_SONGAYLAM ON LUONGTHUONG

-----PARTITION---
--CHECK PARTITION----
SELECT * FROM SYS.partition_range_values
SELECT * FROM SYS.dm_db_partition_stats WHERE object_id('DONDATHANG')=object_id

alter partition function [DonDatHang_NgayLapFunc]() SPLIT RANGE ('01-01-2018')
