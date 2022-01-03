CREATE DATABASE WEBBANHANG
GO
USE WEBBANHANG
GO

 TABLE  DIEMDANH(
	MANV INT, 
	NGAY DATE NOT NULL,
	PRIMARY KEY(MANV,NGAY)
)

CREATE TABLE NHANVIEN (
	MANV INT, 
	HOTEN NVARCHAR (20) NOT NULL,
	MATKHAU VARCHAR(50) NOT NULL,
	LOAINV NVARCHAR(20) NOT NULL,
	MACH INT NOT NULL

	PRIMARY KEY(MANV)
)


CREATE TABLE LUONGTHUONG(
	MANV INT,
	THANG INT DEFAULT 1,
	NAM	  INT NOT NULL,
	SONGAYLAM INT DEFAULT 0,
	STLUONG MONEY,
	STTHUONG MONEY,
	PRIMARY KEY(MANV,THANG,NAM)
)


CREATE TABLE PHIEUTHUHO(
	MAPHIEUTHUHO INT,
	TENNGUOINOP NVARCHAR(30),
	SOTIEN	  MONEY NOT	NULL,
	NGAYNOP DATETIME NOT NULL ,
	SOTIENTHUC MONEY NOT NULL,
	MADONDH INT NOT NULL,
	PRIMARY KEY(MAPHIEUTHUHO)
)




ALTER TABLE DIEMDANH
ADD CONSTRAINT FK_DIEMDANH_NHANVIEN
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE LUONGTHUONG
ADD CONSTRAINT FK_LUONGTHUONG_NHANVIEN
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE PHIEUTHUHO
ADD CONSTRAINT FK_PHIEUTHUHO_DONDATHANG
FOREIGN KEY (MAHD) REFERENCES DONDATHANG(MAHD)




 