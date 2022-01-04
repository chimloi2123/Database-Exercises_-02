

CREATE DATABASE HoaYeuThuong
GO
USE HoaYeuThuong
GO

CREATE TABLE CUAHANG(
	MACH int primary key identity(1,1),
	TENCH nvarchar(20) unique not null,
)
CREATE TABLE TT_CUAHANG(
	MACH int primary key,
	DIACHI_CH nvarchar(80) unique not null,
	SDT_CH char(10) unique not null,
	EMAIL_CH nvarchar(50) unique not null
)
CREATE TABLE SANPHAM_CUAHANG(
	ID int primary key identity(1,1),
	MASP int not null,
	MACH int not null,
	SLTON int not null,
	SLBANHANG int not null, 

	CONSTRAINT AK_SPCH UNIQUE (MACH, MASP),
	CONSTRAINT CHK_SLTON CHECK (SLTON >= 0),
	CONSTRAINT CHK_SLBANHANG CHECK (SLBANHANG > 0)
)
CREATE TABLE SANPHAM(
	MASP int primary key identity(1,1),
	TENSP nvarchar(30) not null,
	CHUDE nvarchar(50),
	GIABAN money not null,
	MALOAI int not null,

	CONSTRAINT CHK_GIABAN CHECK (GIABAN > 0)
)
CREATE TABLE LOAISP(
	MALOAI int primary key identity(1,1),
	TENLOAI nvarchar(20) unique not null
)
CREATE TABLE NHACUNGCAP
(
	MANCC INT PRIMARY KEY IDENTITY(1,1),
	TENNCC NVARCHAR(50) NOT NULL,
	SDT CHAR(11) NOT NULL,
	DIACHI NVARCHAR(80) NOT NULL,
	NGUOIDAIDIEN NVARCHAR(50) NOT NULL
)

CREATE TABLE CUNGCAP
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	MANCC INT NOT NULL,
	MASP INT NOT NULL,
	CHATLUONG INT,
	GIACC MONEY NOT NULL,

	CONSTRAINT AK_CUNGCAP UNIQUE (MANCC, MASP),
	CONSTRAINT CHK_CHATLUONG CHECK (CHATLUONG BETWEEN 0 AND 100),
	CONSTRAINT CHK_GIACC CHECK (GIACC > 0)
)

CREATE TABLE CUNGCAPTOTNHAT
(
	MANCC INT,
	MASP INT,
	GIACC MONEY NOT NULL,

	PRIMARY KEY(MANCC, MASP)
)

CREATE TABLE DONNHAPHANG
(
	MADNH INT PRIMARY KEY IDENTITY(1,1),
	MANCC INT NOT NULL,
	MACH INT NOT NULL,
	NGAYLAP DATETIME NOT NULL,
	TONGTIEN MONEY NOT NULL,
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
	GIANHAP MONEY NOT NULL,

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
CREATE TABLE NHANVIEN (
	MANV INT PRIMARY KEY IDENTITY(1,1), 
	HOTEN NVARCHAR (50) NOT NULL,
	MATKHAU VARCHAR(20) NOT NULL,
	LOAINV NVARCHAR(20) NOT NULL,
	MACH INT NOT NULL
)


CREATE TABLE TT_NHANVIEN (
	MANV INT, 
	EMAIL VARCHAR(50) NOT NULL UNIQUE,
	GIOITINH BIT NOT NULL,
	SDT CHAR(10) NOT NULL UNIQUE,
	DIACHI NVARCHAR(80) NOT NULL,
	NGAYSINH DATETIME NOT NULL

	PRIMARY KEY(MANV)
)

CREATE TABLE NVGIAOHANG(
	MANV INT,
	SODONDAGIAO INT DEFAULT 0,
	BIENSO VARCHAR(20)

	PRIMARY KEY(MANV)
)

CREATE TABLE KHACHHANG
(
	MAKH int PRIMARY KEY IDENTITY(1,1),
	PASS char(20) NOT NULL,
	EMAIL varchar(50) NOT NULL UNIQUE,
	HOTEN nvarchar(30) NOT NULL,
	SDT char(10) NOT NULL,
	DIACHI nvarchar(80) NOT NULL,
	
);

CREATE TABLE THE
(
	SOTHE char(20) NOT NULL,
	CHUTK nvarchar(20),
	NGANHANG nvarchar(50) NOT NULL,
	CONSTRAINT PK_THE PRIMARY KEY(SOTHE)
)

CREATE TABLE DONDATHANG
(
	MADH INT PRIMARY KEY IDENTITY(1,1),
	NGAYDAT datetime NOT NULL,
	NGAYGIAO datetime NOT NULL, 
	TONGTIENTHUC money NOT NULL DEFAULT 0, 
	TINHTRANG nvarchar(15) NOT NULL,
	PTTHANHTOAN nvarchar(10) NOT NULL,
	DIACHIGIAO nvarchar(80) NOT NULL, 
	SDTGIAO char(10) NOT NULL,
	MAKH int NOT NULL,
	MANVLAP int,
	MANVGIAO int,
	MACH int NOT NULL,
	THETHANHTOAN char(20),

	CONSTRAINT CHK_NGAYDAT_NGAYGIAO CHECK (NGAYDAT < NGAYGIAO)
)
CREATE TABLE CT_DONDATHANG
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	MADH int NOT NULL,
	MASP int NOT NULL,
	SOLUONG int NOT NULL, 
	DONGIA money NOT NULL,

	CONSTRAINT AK_CTDH UNIQUE (MADH, MASP)
)
CREATE TABLE  DIEMDANH(
	MANV INT, 
	NGAY DATE NOT NULL,
	PRIMARY KEY(MANV,NGAY)
)
CREATE TABLE LUONGTHUONG(
	ID INT PRIMARY KEY IDENTITY(1,1),
	MANV INT NOT NULL,
	THANG INT DEFAULT 1,
	NAM	  INT NOT NULL,
	SONGAYLAM INT DEFAULT 0,
	STLUONG MONEY DEFAULT 0,
	STTHUONG MONEY DEFAULT 0,
	CONSTRAINT AK_LUONGTHUONG UNIQUE (MANV, THANG,NAM),
	CONSTRAINT CHK_MINTHANG CHECK (1 <= THANG),
	CONSTRAINT CHK_MAXTHANG CHECK (THANG<=12),
)

CREATE TABLE PHIEUTHUHO(
	MAPHIEUTHUHO INT PRIMARY KEY IDENTITY(1,1),
	TENNGUOINOP NVARCHAR(30),
	SOTIEN	  MONEY NOT	NULL,
	NGAYNOP DATETIME NOT NULL ,
	SOTIENTHUC MONEY NOT NULL,
	MADH INT NOT NULL,
	
	--CONSTRAINT CHK_SOTIEN_SOTIENTHUC CHECK (SOTIEN =SOTIENTHUC)

)
-- FK CONSTRAINT
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_LOAI_SANPHAM
FOREIGN KEY (MALOAI) REFERENCES LOAISP(MALOAI)

ALTER TABLE SANPHAM_CUAHANG
ADD CONSTRAINT FK_SPCH_SP
FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

ALTER TABLE SANPHAM_CUAHANG
ADD CONSTRAINT FK_SPCH_CH
FOREIGN KEY (MACH) REFERENCES CUAHANG(MACH)

ALTER TABLE TT_CUAHANG
ADD CONSTRAINT FK_TTCH_CH
FOREIGN KEY (MACH) REFERENCES CUAHANG(MACH)

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

ALTER TABLE NHANVIEN
ADD CONSTRAINT FK_NHANVIEN_CUAHANG
FOREIGN KEY (MACH) REFERENCES CUAHANG(MACH)

ALTER TABLE TT_NHANVIEN
ADD CONSTRAINT FK_NHANVIEN_TT_NHANVIEN
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE NVGIAOHANG
ADD CONSTRAINT FK_NVGIAOHANG_NHANVIEN
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
--
ALTER TABLE DIEMDANH
ADD CONSTRAINT FK_DIEMDANH_NHANVIEN
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE LUONGTHUONG
ADD CONSTRAINT FK_LUONGTHUONG_NHANVIEN
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE PHIEUTHUHO
ADD CONSTRAINT FK_PHIEUTHUHO_DONDATHANG
FOREIGN KEY (MADH) REFERENCES DONDATHANG(MADH)
--
ALTER TABLE DONDATHANG
ADD	
	CONSTRAINT FK_DONDATHANG_KHACHHANG FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH) ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT FK_DONDATHANG_TT_NHANVIEN FOREIGN KEY(MANVLAP) REFERENCES TT_NHANVIEN(MANV) ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT FK_DONDATHANG_NVGIAOHANG FOREIGN KEY(MANVGIAO) REFERENCES NVGIAOHANG(MANV) ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT FK_DONDATHANG_MACH FOREIGN KEY(MACH) REFERENCES CUAHANG(MACH) ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT FK_DONDATHANG_THE FOREIGN KEY(THETHANHTOAN) REFERENCES THE(SOTHE) ON DELETE NO ACTION ON UPDATE CASCADE

ALTER TABLE CT_DONDATHANG
ADD	
	CONSTRAINT FK_CT_DONDATHANG_DONDATHANG FOREIGN KEY(MADH) REFERENCES DONDATHANG(MADH) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_CT_DONDATHANG_SANPHAM FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP) ON DELETE CASCADE ON UPDATE CASCADE