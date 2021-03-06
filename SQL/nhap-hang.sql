----------------------------- DATABASE -----------------------------
CREATE DATABASE HOAYEUTHUONG
GO
USE HOAYEUTHUONG
GO

------------------------------ TABLE ------------------------------
CREATE TABLE NHACUNGCAP
(
	MANCC INT PRIMARY KEY IDENTITY(1,1),
	TENNCC VARCHAR(50) NOT NULL,
	SDT CHAR(11) NOT NULL,
	DIACHI VARCHAR(50) NOT NULL,
	NGUOIDAIDIEN VARCHAR(50) NOT NULL
)

CREATE TABLE CUNGCAP
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	MANCC INT NOT NULL,
	MASP INT NOT NULL,
	CHATLUONG INT,
	GIACC INT NOT NULL,

	CONSTRAINT AK_CUNGCAP UNIQUE (MANCC, MASP),
	CONSTRAINT CHK_CHATLUONG CHECK (CHATLUONG BETWEEN 0 AND 100),
	CONSTRAINT CHK_GIACC CHECK (GIACC > 0)
)

CREATE TABLE CUNGCAPTOTNHAT
(
	MANCC INT,
	MASP INT,
	GIACC INT NOT NULL,

	PRIMARY KEY(MANCC, MASP)
)

CREATE TABLE DONNHAPHANG
(
	MADNH INT PRIMARY KEY IDENTITY(1,1),
	MANCC INT NOT NULL,
	MACH INT NOT NULL,
	NGAYLAP DATETIME NOT NULL,
	TONGTIEN INT NOT NULL,
	NGAYNHANDUKIEN DATETIME NOT NULL,
	NVLAP INT NOT NULL,

	CONSTRAINT CHK_NGAYLAP_NGAYNHAN CHECK (NGAYNHANDUKIEN < NGAYLAP)
)

CREATE TABLE CT_DONNHAP
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	MADNH INT NOT NULL,
	MASP INT NOT NULL,
	SLNHAP INT NOT NULL,
	GIANHAP INT NOT NULL,

	CONSTRAINT AK_CTDONNHAP UNIQUE (MADNH, MASP),
	CONSTRAINT CHK_SLNHAP CHECK (SLNHAP > 0)
)

CREATE TABLE DONGIAOHANG
(
	MADGH INT PRIMARY KEY IDENTITY(1,1),
	MADNH INT NOT NULL,
	MANCC INT NOT NULL,
	NGAYHOANTHANH DATETIME, 
	THANHTOAN DATETIME
)

CREATE TABLE CT_GIAOHANG
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	MADGH INT NOT NULL,
	MADNH INT NOT NULL,
	MASP INT NOT NULL,
	NGAYGIAO DATETIME NOT NULL,
	SLGIAO INT NOT NULL

	CONSTRAINT AK_CTGIAOHANG UNIQUE (MADGH, MADNH, MASP, NGAYGIAO),
	CONSTRAINT CHK_SLGIAO CHECK (SLGIAO > 0)
)

------------------------------ INDEX ------------------------------
--CUNGCAP
CREATE INDEX IDX_CUNGCAP_MASP ON CUNGCAP(MASP)
--CT_DONNHAP
CREATE INDEX IDX_CTDONNHAP ON CT_DONNHAP(MADNH)
--CT_GIAOHANG
CREATE INDEX IDX_CTGIAOHANG ON CT_GIAOHANG(MADGH)

---------------------------- PARTITION ----------------------------
--CT_GIAOHANG


--------------------------- FOREIGN KEY ---------------------------
--CUNGCAP
ALTER TABLE CUNGCAP
ADD CONSTRAINT FK_CUNGCAP_NHACUNGCAP
FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC)

ALTER TABLE CUNGCAP
ADD CONSTRAINT FK_CUNGCAP_SANPHAM
FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

--CUNGCAPTOTNHAT
ALTER TABLE CUNGCAPTOTNHAT
ADD CONSTRAINT FK_CCTN_CUNGCAP
FOREIGN KEY (MANCC, MASP) REFERENCES CUNGCAP(MANCC, MASP)

--CT_DONNHAP
ALTER TABLE CT_DONNHAP
ADD CONSTRAINT FK_CTDN_SANPHAM
FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

ALTER TABLE CT_DONNHAP
ADD CONSTRAINT FK_CTDN_DONNHAPHANG
FOREIGN KEY (MADNH) REFERENCES DONNHAPHANG(MADNH)

--DONNHAPHANG
ALTER TABLE DONNHAPHANG
ADD CONSTRAINT FK_DONNHAPHANG_NHACUNGCAP
FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC)

ALTER TABLE DONNHAPHANG
ADD CONSTRAINT FK_DONNHAPHANG_CUAHANG
FOREIGN KEY (MACH) REFERENCES CUAHANG(MACH)

ALTER TABLE DONNHAPHANG
ADD CONSTRAINT FK_DONNHAPHANG_NHANVIEN
FOREIGN KEY (NVLAP) REFERENCES NHANVIEN(MANV)

--DONGIAOHANG
ALTER TABLE DONGIAOHANG
ADD CONSTRAINT FK_DONGIAOHANG_NHACUNGCAP
FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC)

ALTER TABLE DONGIAOHANG
ADD CONSTRAINT FK_DONGIAOHANG_DONNHAPHANG
FOREIGN KEY (MADNH) REFERENCES DONNHAPHANG(MADNH)

--CT_GIAOHANG

ALTER TABLE CT_GIAOHANG
ADD CONSTRAINT FK_CTGH_DONGIAOHANG
FOREIGN KEY (MADGH) REFERENCES DONGIAOHANG(MADGH)

ALTER TABLE CT_GIAOHANG
ADD CONSTRAINT FK_CTGH_CTDN
FOREIGN KEY (MADNH, MASP) REFERENCES CT_DONNHAP(MADNH,MASP)