

SELECT SP.MASP,SP.TENSP, CTDH.DONGIA,DATEADD(dd, 0, DATEDIFF(dd, 0,DH.NGAYDAT))
	    FROM  SANPHAM SP JOIN  CT_DONDATHANG CTDH  ON SP.MASP=CTDH.MASP JOIN DONDATHANG DH ON DH.MADH=CTDH.MADH
	    WHERE   dh.NGAYDAT<'2019-11-30 00:00:00.000' and sp.masp<100
		GROUP BY SP.MASP,SP.TENSP,ctdh.dongia, DATEADD(dd, 0, DATEDIFF(dd, 0,DH.NGAYDAT))
		ORDER BY  DATEADD(dd, 0, DATEDIFF(dd, 0,DH.NGAYDAT)) DESC, SP.MASP ASC
		-------------TRUY VAN GIA SAN PHAM---------------------
		set statistics io on 
SELECT SP.MASP, SP.TENSP, CTDH.DONGIA,DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT)) as NGAY 
FROM SANPHAM SP,  CT_DONDATHANG CTDH, DONDATHANG DH 
WHERE    SP.MASP = CTDH.MASP AND DH.MADH = CTDH.MADH AND dh.NGAYDAT > '11-30-2017' and sp.masp=123
GROUP BY SP.MASP,SP.TENSP,ctdh.dongia, DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT))   
ORDER BY  DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT)) DESC, SP.MASP ASC
		------------THEO DOI SO LUONG TON
		SELECT CH.MACH,  CH.TENCH ,SPCH.MASP, SP.TENSP, SPCH.SLTON
		FROM CUAHANG CH, SANPHAM_CUAHANG SPCH, SANPHAM SP
		WHERE CH.MACH = SPCH.MACH  and SPCH.MASP = SP.MASP and ch.TENCH like N'Shop%' and sp.TENSP like N'Bên%'
		GROUP BY CH.MACH,CH.TENCH, SPCH.MASP, SP.TENSP,SPCH.SLTON
		--and CH.TENCH like 'a%'
		------------ HIEU SUAT LAM VIEC THEO MANV-------------
		select  nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam)+'-'+trim(str(thang)+'-01'))) as songaytrongthang
		from nhanvien nv , luongthuong lt
		where nv.MANV=lt.MANV and lt.THANG=3 and lt.nam=2021
		--AND nv.manv=1
		group by nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam)+'-'+trim(str(thang)+'-01')))
		order by lt.nam desc, lt.thang desc

	
		-----------SO SANH DOANH THU
	SET STATISTICS IO ON
		 SELECT  CH.MACH, CH.TENCH,MONTH(DH.NGAYDAT) THANG,YEAR(DH.NGAYDAT) NAM, SUM(TONGTIENTHUC) AS DOANHTHU 
		FROM DONDATHANG DH, CUAHANG CH,SANPHAM_CUAHANG SPCH, CT_DONDATHANG CTDH
		WHERE SPCH.MACH = CH.MACH  and CTDH.MASP = SPCH.MASP and DH.MADH = CTDH.MADH AND DH.NGAYDAT BETWEEN '03-01-2017' AND '03-30-2017'
		GROUP BY MONTH(DH.NGAYDAT), YEAR(DH.NGAYDAT), CH.MACH, CH.TENCH
		ORDER BY   YEAR(DH.NGAYDAT)DESC, MONTH(DH.NGAYDAT)DESC, CH.MACH, SUM(TONGTIENTHUC) DESC
		


		-----------CREATE PARTITION-----------
		BEGIN TRANSACTION
		create partition function [NgayLap_DonDat] as range left for
		values (N'2019-12-01', N'2019-11-01', N'2019-10-01',  N'2019-09-01'

		select year(ngaydat), count(*) from dondathang
		group by year(ngaydat)
		order by  year(ngaydat) desc

		SELECT YEAR(DONDATHANG.NGAYDAT) FROM DONDATHANG
		GROUP BY YEAR(DONDATHANG.NGAYDAT)
		ORDER BY YEAR(DONDATHANG.NGAYDAT) DESC







