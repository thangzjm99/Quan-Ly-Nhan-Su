USE [master]
GO
/****** Object:  Database [QLNhanSu]    Script Date: 6/22/2020 5:35:57 PM ******/
CREATE DATABASE [QLNhanSu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNhanSu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLNhanSu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLNhanSu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLNhanSu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLNhanSu] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNhanSu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNhanSu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNhanSu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNhanSu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNhanSu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNhanSu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNhanSu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNhanSu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNhanSu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNhanSu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNhanSu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNhanSu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNhanSu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNhanSu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNhanSu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNhanSu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNhanSu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNhanSu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNhanSu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNhanSu] SET RECOVERY FULL 
GO
ALTER DATABASE [QLNhanSu] SET  MULTI_USER 
GO
ALTER DATABASE [QLNhanSu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNhanSu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNhanSu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNhanSu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLNhanSu] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLNhanSu', N'ON'
GO
ALTER DATABASE [QLNhanSu] SET QUERY_STORE = OFF
GO
USE [QLNhanSu]
GO
/****** Object:  Table [dbo].[BANGCAP]    Script Date: 6/22/2020 5:35:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANGCAP](
	[MABC] [int] NOT NULL,
	[MANV] [int] NULL,
	[TENBC] [nvarchar](50) NULL,
	[LOAIBC] [nvarchar](50) NULL,
	[NGAYCAP] [date] NULL,
	[DVCAP] [nvarchar](max) NULL,
 CONSTRAINT [PK_BANGCAP] PRIMARY KEY CLUSTERED 
(
	[MABC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 6/22/2020 5:35:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [int] NOT NULL,
	[HOTEN] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](max) NULL,
	[SDT] [int] NULL,
	[NGAYSINH] [date] NULL,
	[CMND] [int] NULL,
	[GIOITINH] [nvarchar](50) NULL,
	[QUEQUAN] [nvarchar](max) NULL,
	[DANTOC] [nvarchar](50) NULL,
	[MAPB] [int] NULL,
	[SOSOBH] [int] NULL,
	[CHUCVU] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 6/22/2020 5:35:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MAPB] [int] NOT NULL,
	[TENPB] [nvarchar](max) NULL,
	[TRGPB] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHONGBAN] PRIMARY KEY CLUSTERED 
(
	[MAPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (1345, 3, N'Tài chính', N'Giỏi', CAST(N'2018-05-06' AS Date), N'Học VIện Tài Chính')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (1365, 2, N'Ngân hàng', N'Khá', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (1435, 1, N'CNTT', N'Giỏi', CAST(N'2016-01-01' AS Date), N'Học Viện Kỹ Thuật Quân Sự')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (1765, 4, N'Kế toán', N'Khá', CAST(N'2018-05-06' AS Date), N'Học VIện Tài Chính')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (3333, 12, N'Kế toán', N'Khá', CAST(N'2019-12-22' AS Date), N'Đại Học Thương Mại')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (3354, 8, N'Ngân hàng', N'Khá', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (3657, 16, N'Tài chính', N'Giỏi', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (4300, 17, N'Quản lý nhân sự', N'Khá', CAST(N'2019-12-22' AS Date), N'Đại Học Thương Mại')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (4455, 11, N'Ngân hàng', N'Giỏi', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (4566, 7, N'Tài chính', N'Khá', CAST(N'2019-12-22' AS Date), N'Đại Học Thương Mại')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (4598, 13, N'Kế toán', N'Giỏi', CAST(N'2018-05-06' AS Date), N'Học VIện Tài Chính')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (5445, 10, N'Kế toán', N'Khá', CAST(N'2018-05-06' AS Date), N'Học VIện Tài Chính')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (5678, 6, N'Tài chính', N'Giỏi', CAST(N'2018-05-06' AS Date), N'Học VIện Tài Chính')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (5683, 20, N'Tài chính', N'Giỏi', CAST(N'2019-12-22' AS Date), N'Đại Học Thương Mại')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (6456, 14, N'Kế toán', N'Giỏi', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (6789, 9, N'Tài chính', N'Giỏi', CAST(N'2019-12-22' AS Date), N'Đại Học Thương Mại')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (7654, 15, N'Kế toán', N'Khá', CAST(N'2019-12-22' AS Date), N'Đại Học Thương Mại')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (7905, 18, N'Tài chính', N'Giỏi', CAST(N'2018-05-06' AS Date), N'Học VIện Tài Chính')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (7942, 19, N'Ngân hàng', N'Khá', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[BANGCAP] ([MABC], [MANV], [TENBC], [LOAIBC], [NGAYCAP], [DVCAP]) VALUES (9876, 5, N'Kế toán', N'Khá', CAST(N'2017-03-04' AS Date), N'Học Viện Ngân Hàng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (1, N'Đỗ Việt Anh', N'Ninh Bình', 987654324, CAST(N'1999-11-06' AS Date), 123456789, N'nam', N'Thái Bình', N'Kinh', 1, 13453, N'Trưởng phòng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (2, N'Lê Thanh Độ', N'Bà Rịa - Vũng Tàu', 365515904, CAST(N'1998-11-12' AS Date), 157894657, N'nam', N'Bà Rịa - Vũng Tàu', N'Kinh', 2, 23464, N'Kế Toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (3, N'Bùi Bằng Dương', N'Khánh Hòa', 392263019, CAST(N'1999-04-05' AS Date), 146257895, N'nữ', N'Khánh Hòa', N'Kinh', 3, 25664, N'Trưởng phòng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (4, N'Nguyễn Việt Long', N'Kiên Giang', 354052920, CAST(N'1999-09-08' AS Date), 138573984, N'nam', N'Đà Nẵng', N'Kinh', 3, 24578, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (5, N'Phạm Văn Tùng', N'Sóc Trăng', 353581200, CAST(N'1999-11-16' AS Date), 198756378, N'nam', N'Quảng Nam', N'Kinh', 2, 98705, N'Trưởng phòng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (6, N'Trần Minh Duyệt', N'Bắc Giang', 387396264, CAST(N'1999-08-22' AS Date), 176590265, N'nam', N'Hà Nội', N'Kinh', 1, 55460, N'Phó phòng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (7, N'Nguyễn Thị Hồng Ánh', N'Quảng Nam', 364431104, CAST(N'2000-07-26' AS Date), 109875987, N'nữ', N'Quảng Nam', N'Kinh', 2, 43309, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (8, N'Nguyễn Xuân Dương', N'Hải Phòng', 375842540, CAST(N'2001-08-03' AS Date), 187649837, N'nam', N'Bắc Giang', N'Kinh', 2, 44321, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (9, N'Hoàng Gia Lâm', N'Hà Nội', 862884103, CAST(N'2000-02-29' AS Date), 176894638, N'nam', N'Kiên Giang', N'Kinh', 1, 45632, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (10, N'Nguyễn Duy Minh', N'Hà Nội', 392522587, CAST(N'2000-01-01' AS Date), 189750675, N'nam', N'Cao Bằng', N'Kinh', 4, 12323, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (11, N'Đỗ Tiến Thành', N'Đà Nẵng', 362304308, CAST(N'1999-11-22' AS Date), 176598465, N'nữ', N'Hậu Giang', N'Kinh', 5, 22332, N'Trưởng phòng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (12, N'Đỗ Hoàng Trung', N'Bắc Giang', 375842540, CAST(N'1999-12-30' AS Date), 176549870, N'nam', N'Hà Nội', N'Kinh', 2, 12309, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (13, N'Hoàng Hải Thành', N'Đà Nẵng', 392522587, CAST(N'1999-06-01' AS Date), 170077654, N'nam', N'Cần Thơ', N'Kinh', 5, 19090, N'Kĩ Thuật Viên')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (14, N'Chu Nhất Long', N'Cần Thơ', 362304308, CAST(N'1999-12-22' AS Date), 162277546, N'nam', N'Sóc Trăng', N'Kinh', 4, 12377, N'Kế toán')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (15, N'Vũ Đình Tuyên', N'Khánh Hòa', 972204001, CAST(N'2001-10-29' AS Date), 166327673, N'nữ', N'Khánh Hòa', N'Kinh', 4, 12567, N'Trưởng phòng')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (16, N'Nguyễn Tuấn Hưng', N'Thái Bình', 365515904, CAST(N'1999-11-07' AS Date), 176583475, N'nam', N'Cao Bằng', N'Kinh', 5, 67854, N'Kĩ Thuật Viên')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (17, N'Nguyễn Sơn Hải', N'Sóc Trăng', 387396264, CAST(N'1999-09-02' AS Date), 127659342, N'nam', N'Hậu Giang', N'Kinh', 1, 45678, N'Maketing')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (18, N'Lê Quang Đức', N'Khánh Hòa', 972204001, CAST(N'1999-07-07' AS Date), 187889503, N'nữ', N'Sóc Trăng', N'Kinh', 1, 45632, N'Thủ Quỹ')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (19, N'Trần Hào Phong', N'Hậu Giang', 354052920, CAST(N'1999-04-04' AS Date), 167593782, N'nam', N'Thái Bình', N'Kinh', 3, 47892, N'Maketing')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [DIACHI], [SDT], [NGAYSINH], [CMND], [GIOITINH], [QUEQUAN], [DANTOC], [MAPB], [SOSOBH], [CHUCVU]) VALUES (20, N'Bùi Trung Anh', N'Cao Bằng', 342586573, CAST(N'2000-11-17' AS Date), 198765987, N'nữ', N'Ninh Bình', N'Kinh', 2, 40935, N'Thủ Quỹ')
INSERT [dbo].[PHONGBAN] ([MAPB], [TENPB], [TRGPB]) VALUES (1, N'Phòng hành chính', N'Đỗ Việt Anh')
INSERT [dbo].[PHONGBAN] ([MAPB], [TENPB], [TRGPB]) VALUES (2, N'Phòng tài chính', N'Phạm Văn Tùng')
INSERT [dbo].[PHONGBAN] ([MAPB], [TENPB], [TRGPB]) VALUES (3, N'Phòng Maketing', N'Bùi Bằng Dương')
INSERT [dbo].[PHONGBAN] ([MAPB], [TENPB], [TRGPB]) VALUES (4, N'Phòng bán hàng', N'Vũ Đình Tuyên')
INSERT [dbo].[PHONGBAN] ([MAPB], [TENPB], [TRGPB]) VALUES (5, N'Phòng kỹ thuật', N'Đỗ Tiến Thành')
ALTER TABLE [dbo].[BANGCAP]  WITH CHECK ADD  CONSTRAINT [FK_BANGCAP_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[BANGCAP] CHECK CONSTRAINT [FK_BANGCAP_NHANVIEN]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_PHONGBAN] FOREIGN KEY([MAPB])
REFERENCES [dbo].[PHONGBAN] ([MAPB])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_PHONGBAN]
GO
USE [master]
GO
ALTER DATABASE [QLNhanSu] SET  READ_WRITE 
GO
