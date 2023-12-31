create database QLStoreSach
go

USE [QLStoreSach]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 1/1/2022 4:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [nvarchar](10) NOT NULL,
	[MaSach] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/1/2022 4:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [nvarchar](10) NOT NULL,
	[MaKhachHang] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[TongTien] [int] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/1/2022 4:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 1/1/2022 4:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaSach] [nvarchar](10) NOT NULL,
	[NhaCungCap] [nvarchar](50) NOT NULL,
	[GiaGoc] [int] NOT NULL,
	[Soluong] [int] NULL,
	[NgayNhapKho] [date] NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 1/1/2022 4:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nvarchar](10) NOT NULL,
	[TenSach] [nvarchar](255) NOT NULL,
	[UrlImage] [varchar](max) NULL,
	[UrlImageSau] [varchar](max) NULL,
	[TacGia] [nvarchar](255) NOT NULL,
	[TheLoai] [nvarchar](255) NULL,
	[NamXB] [int] NOT NULL,
	[NXB] [nvarchar](255) NOT NULL,
	[GiaBan] [int] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[NhanXet1] [nvarchar](max) NULL,
	[NhanXet2] [nvarchar](max) NULL,
	[NhanXet3] [nvarchar](max) NULL,
	[NhanXet4] [nvarchar](max) NULL,
 CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/1/2022 4:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD268803', N'MS024', 1, 180000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD268803', N'MS030', 1, 20000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD381136', N'MS018', 1, 92000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD381136', N'MS025', 1, 29000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD381136', N'MS030', 1, 20000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD3929', N'MS002', 8, 58300)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD439733', N'MS018', 1, 92000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD439733', N'MS019', 1, 38000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD448721', N'MS008', 1, 650000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD448721', N'MS011', 1, 75000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD507554', N'MS018', 1, 92000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD507554', N'MS025', 1, 29000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD6870', N'MS019', 1, 38000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD6870', N'MS024', 3, 180000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD6870', N'MS029', 1, 43000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD7063', N'MS001', 11, 49500)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD872927', N'MS009', 1, 150000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD872927', N'MS013', 1, 42000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD9312', N'MS003', 499, 63000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD977243', N'MS019', 1, 38000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSach], [SoLuong], [DonGia]) VALUES (N'HD977243', N'MS029', 1, 43000)
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD002', N'KH006', CAST(N'2021-05-20' AS Date), 110000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD268803', N'KH002', CAST(N'2022-01-01' AS Date), 200000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD381136', N'KH002', CAST(N'2022-01-01' AS Date), 141000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD3929', N'KH001', CAST(N'2021-12-26' AS Date), 466400)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD439733', N'KH002', CAST(N'2022-01-01' AS Date), 130000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD448721', N'KH001', CAST(N'2021-12-31' AS Date), 725000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD507554', N'KH002', CAST(N'2022-01-01' AS Date), 121000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD6870', N'KH017', CAST(N'2021-12-27' AS Date), 621000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD7063', N'KH002', CAST(N'2021-12-26' AS Date), 544500)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD872927', N'KH002', CAST(N'2022-01-01' AS Date), 192000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD9312', N'KH001', CAST(N'2021-12-26' AS Date), 31437000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayLap], [TongTien]) VALUES (N'HD977243', N'KH002', CAST(N'2022-01-01' AS Date), 81000)
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH001', N'Mạc Đỉnh Thy', N'Tiền Giang', N'0987987123', N'mdthy18@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH002', N'Thanh Truong', N'192 Lê Trọng Tấn, Tân Phú', N'0974482653', N'ttruong04@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH004', N'Trang Thanh', N'23 Song Hành, Quận 12', N'0923544556', N'trthanh20@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH005', N'Manh Manh', N'23 Hà Bá Tường, Tân Bình', N'0911265698', N'manh1025@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH006', N'Thanh Binh', N'326J Nguyễn Trọng Tuyển, Tân Bình', N'0986554233', N'binhgold199@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH007', N'Thuy Anh', N'224 Bùi Thị Xuân, Tân Bình', N'0142005574', N'thuyanh01@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH008', N'Xuan Huong', N'1012 Lạc Long Quân, Tân Bình', N'0145896665', N'huong02@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH009', N'Nhan Tan', N'15 Bùi Thế Mỹ, Tân Bình', N'0126654445', N'nhattan12@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH010', N'Thanh Phương', N'348 Trần Phú, Quận 5', N'0589626364', N'fuong66@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH012', N'Nguyễn Tô Thụy Anh', N'Vũng Tàu', N'0123456789', N'nguyentothuyanh@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [DiaChi], [DienThoai], [Email]) VALUES (N'KH017', N'huong', N'quan11', N'0399245450', N'xuanhuong@gmail.com')
GO
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS000', N'hcm', 12000, 100, CAST(N'2021-12-27' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS001', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 45000, 489, CAST(N'2021-12-26' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS002', N'Nhà cung cấp sách FAHASA', 53000, 200, CAST(N'2021-12-27' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS003', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 52000, 500, CAST(N'2021-12-27' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS004', N'Công Ty Cổ Phần Văn Hóa Nhân Văn', 80000, 500, CAST(N'2021-12-12' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS005', N'Nhà Sách Đất Việt', 120000, 500, CAST(N'2021-12-12' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS006', N'Nhà cung cấp sách DANABOOK', 10000, 500, CAST(N'2021-12-12' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS007', N'Công Ty Cổ Phần Văn Hóa Nhân Văn', 30000, 500, CAST(N'2021-12-13' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS008', N'Nhà cung cấp sách DANABOOK', 600000, 499, CAST(N'2021-12-13' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS009', N'Nhà cung cấp sách FAHASA', 100000, 499, CAST(N'2021-12-13' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS010', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 100000, 500, CAST(N'2021-12-13' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS011', N'Công Ty Cổ Phần Văn Hóa Nhân Văn', 50000, 499, CAST(N'2021-12-13' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS012', N'Nhà cung cấp sách FAHASA', 70000, 500, CAST(N'2021-12-13' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS013', N'Công Ty Cổ Phần Văn Hóa Nhân Văn', 20000, 499, CAST(N'2021-12-14' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS014', N'Nhà Sách Đất Việt', 50000, 500, CAST(N'2021-12-14' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS015', N'Nhà cung cấp sách FAHASA', 300000, 500, CAST(N'2021-12-15' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS016', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 360000, 500, CAST(N'2021-12-15' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS017', N'Công Ty Cổ Phần Văn Hóa Nhân Văn', 25000, 500, CAST(N'2021-12-15' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS018', N'Nhà cung cấp sách DANABOOK', 50000, 497, CAST(N'2021-12-15' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS019', N'Nhà Sách Đất Việt', 96000, 497, CAST(N'2021-12-15' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS020', N'Nhà cung cấp sách FAHASA', 22000, 500, CAST(N'2021-12-15' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS021', N'Nhà cung cấp sách DANABOOK', 11000, 500, CAST(N'2021-12-16' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS022', N'Nhà cung cấp sách DANABOOK', 32000, 500, CAST(N'2021-12-16' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS023', N'Nhà Sách Đất Việt', 11000, 500, CAST(N'2021-12-16' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS024', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 33000, 496, CAST(N'2021-12-16' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS025', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 33000, 498, CAST(N'2021-12-16' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS026', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 33000, 500, CAST(N'2021-12-17' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS027', N'Nhà cung cấp sách DANABOOK', 20000, 500, CAST(N'2021-12-17' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS028', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 12000, 500, CAST(N'2021-12-17' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS029', N'Nhà cung cấp sách FAHASA', 13000, 498, CAST(N'2021-12-17' AS Date))
INSERT [dbo].[Kho] ([MaSach], [NhaCungCap], [GiaGoc], [Soluong], [NgayNhapKho]) VALUES (N'MS030', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', 10000, 498, CAST(N'2021-12-17' AS Date))
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS000', N'hcm', NULL, NULL, N'huong', N'hoat hình', 2021, N'nhi đồng', 13200, N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS001', N'Kính Vạn Hoa - Trọn bộ', N'https://cf.shopee.vn/file/1f56c5d468ac6b1d9ff68524dad1d778', N'https://media3.scdn.vn/img3/2019/8_9/R3GkYa.jpg', N'Nguyễn Nhật Ánh', N'Học Trò, Thiếu Nhi, Sách Văn học', 2020, N'Văn Học', 49500, N'Kính Vạn Hoa là một bộ bách khoa toàn thư về đời sống học trò được tác giả nhìn qua lăng kính vạn hoa nhiều màu sắc biến ảo sinh động vô cùng thú vị. Là học trò, luôn yêu tuổi học trò, luôn nhớ về tuổi học trò thì không thể không đọc Kính Vạn Hoa.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS002', N'Thiên thần và ác quỷ', N'https://www.khaitam.com/Data/Sites/1/Product/1407/thien-than-va-ac-quy.png', N'https://salt.tikicdn.com/cache/w1200/ts/product/2d/50/82/73c9e6ee73e053a38c303251e220dd4a.jpg', N'Dan Brown', N'Huyền Huyễn, Tu Tiên, Ngôn Tình, Sách Văn Học, Ngược', 2000, N'Lao Động', 58300, N'Tiểu thuyết giới thiệu nhân vật Robert Langdon, cũng là nhân vật chính trong tiểu thuyết tiếp theo vào năm 2003 - Mật mã Da Vinci. Quyển sách cũng chứa đựng nhiều yếu tố văn học giống như quyển tiếp theo, như là những thông đồng của các cộng đồng bí mật, khung thời gian theo từng ngày, và Giáo hội Công giáo. Những mặt như lịch sử cổ đại, kiến trúc và ký tượng học cũng là chủ đề chính xuyên suốt câu chuyện. Bộ phim cùng tên dựng từ quyển sách đã được khởi chiếu vào ngày 15 tháng 5 năm 2009, sau bộ phim Mật mã Da Vinci đã được chiếu vào năm 2006.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS003', N'Pháo đài số', N'https://cf.shopee.vn/file/56240fea1493ddb0a05394401aec53d3_tn', N'https://salt.tikicdn.com/cache/w1200/ts/product/4d/c0/05/fe4dc78859d996df67dca119b473b3ef.jpg', N'Dan Brown', N'Thiếu Nhi, Kỳ Ảo, Sử Thi, Tiểu Thuyết', 2006, N'Lao Động', 57200, N'Câu chuyện giả tưởng xoay quanh một cuộc hành trình đi tìm lời giải cho bí ẩn "Pháo đài số" và cỗ máy giải mã TRANSLTR. Susan Fletcher được sếp của cô là Trevor Strathmore thông báo về một mật mã dựa trên thuật toán văn bản gốc luân hồi. Có thể nói ông ta tin rằng đây là một loại mật mã không thể giải mã nổi mà một máy giải mã gồm 3 triệu bộ xử lý như TRANSLTR cũng không thể giải nổi và chính vì thế ông để cho TRANSLTR tìm cách giải mã "Pháo đài số". Đồng thời Strathmore còn nhờ David Becker tới Tây Ban Nha để lấy lại đồ đạc của Ensei Tankando - người đã tạo ra "Pháo đài số" đã đột ngột chết trong một cơn đau tim tại Sevilla, Tây Ban Nha. Ensei đã công bố về mật mã "Pháo đài số" và yêu cầu NSA phải công bố cho thế giới biết sự thực về TRANSLTR, công cụ bẻ khóa mà NSA đã sử dụng. Anh ta cáo buộc TRANSLTR cũng như NSA đã luôn vi phạm bản quyền con người và việc tất cả bí mật riêng tư qua mạng đều có thể được đọc bởi NSA là một việc làm cần ngăn chặn.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS004', N'Sword Art Online: Aincrad - Tập 1', N'http://img.websosanh.vn/v2/users/root_product/images/sword-art-online-sao-tap/m5P_0ptjSTpX.jpg', N'https://cdn.discordapp.com/attachments/900723602389868566/922033699783077888/unknown.png', N'Reki Kawahara', N'Thơ, Sách Văn Học', 2017, N'Hồng Đức', 92000, N'Năm 2022, thế hệ game chạy trên NERvGear tiếp theo đã được công bố, người dùng có thể kết nối với thế giới ảo thông qua chức năng FullDive. S.A.O (Sword Art Online) - dòng game VRMMORPG chính thống đầu tiên trên nền NERvGear đã gây xôn xao trên toàn thế giới. Một trong số rất nhiều người chơi, Kirito, quyết tâm chinh phục trò chơi này. Thế nhưng, người sáng tạo ra SAO, Akihiko Kayaba lại thông báo rằng: Một khi đã tham gia thì không người chơi nào có thể thoát ra ngoài cho đến khi phá đảo. Game Over tương đương với cái chết thực sự ngoài đời.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS005', N'Không Gia Đình', N'https://cdn0.fahasa.com/media/flashmagazine/images/page_images/khong_gia_dinh_tri_viet_2018/2020_05_19_09_50_19_1-390x510.JPG', N'https://salt.tikicdn.com/ts/review/0d/5c/14/e4d7bb0ed1480cf4f680920d92b4c5da.jpg', N'Hector Malot', N'Tiểu thuyết', 1878, N'NXB Văn học', 150000, N'Không gia đình (tiếng Pháp: Sans famille), còn được dịch là Vô gia đình, có thể được xem là tiểu thuyết nổi tiếng nhất của nhà văn Pháp Hector Malot, được xuất bản năm 1878. Tác phẩm đã được giải thưởng của Viện Hàn lâm Văn học Pháp. Nhiều nước trên thế giới đã dịch lại tác phẩm và xuất bản nhiều lần. Từ một trăm năm nay, Không gia đình đã trở thành quen thuộc đối với thiếu nhi Pháp và thế giới. Kiệt tác này đã được xuất hiện nhiều lần trên phim ảnh và truyền hình.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS006', N'Anh Chính Là Thanh Xuân Của Em', N'https://sach86.com/wp-content/uploads/2019/04/Anh-chinh-la-thanh-xuan-cua-em.jpg', N'https://salt.tikicdn.com/cache/w1200/ts/product/9d/6c/ba/3780b9f08a8353273150e5624b40f9bf.JPG', N'Hạ Vũ', N'Lãng Mạn, Tiểu Thuyêt', 2019, N'Phụ Nữ', 25000, N'Thanh xuân, hai chữ giản dị nhất, nhưng cũng chứa đựng nhiều điều khó nói nhất của một đời người. Không có khoảng thời gian nào mà người ta lại khao khát quay trở lại như thời điểm ấy. Khoảng thời gian mà dẫu có buồn nhiều hơn vui, đau lòng nhiều hơn hạnh phúc, tiếc nuối nhiều hơn hài lòng, người ta vẫn muốn quay trở lại, chỉ để được sống trong cảm giác tươi đẹp, gặp được người mình thương năm ấy một lần nữa…', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS007', N'Sherlock Holmes - Trọn bộ', N'https://cf.shopee.vn/file/d8b0f26899f6931da1f0861b46aba03e', N'https://salt.tikicdn.com/cache/w1200/media/catalog/product/s/h/sherlock-holme-1.u4939.d20170630.t113348.643376.jpg', N'Sir Arthur Conan Doyle', N'Trinh Thám, Hư Cấu, Giả Tưởng, Kỳ Ảo, Tiểu Thuyết', 1887, N'Văn Học', 46000, N'Sherlock Holmes (/ˈʃɜːrlɒk ˈhoʊmz/ hoặc /-ˈhoʊlmz/) là một nhân vật thám tử tư hư cấu, do nhà văn người Anh Arthur Conan Doyle sáng tạo nên. Tự coi mình là "thám tử tư vấn" trong các câu chuyện, Holmes nổi danh với khả năng quan sát, diễn dịch, khoa học pháp y điêu luyện và suy luận logic tuyệt vời, những yếu tố mà anh áp dụng khi điều tra các vụ án của nhiều dạng khách hàng, bao gồm cả Scotland Yard.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS008', N'Harry Potter Combo', N'https://cf.shopee.vn/file/00b4bf6e82b6ee08904d8d44120b8a3d', N'https://salt.tikicdn.com/cache/w1200/ts/product/0b/6c/75/c3fa989449f2afaf2dccea7daa0e8311.jpg', N'J.K. Rowling', N'Hư cấu kỳ ảo', 1997, N'NXB Bloomsbury', 650000, N'Harry Potter là tên của series tiểu thuyết huyền bí gồm bảy phần của nữ nhà văn Anh Quốc J. K. Rowling. Bộ truyện viết về những cuộc phiêu lưu phù thủy của cậu bé Harry Potter cùng hai người bạn thân là Ronald Weasley và Hermione Granger, lấy bối cảnh tại Trường Phù thủy và Pháp sư Hogwarts nước Anh. Những cuộc phiêu lưu tập trung vào cuộc chiến của Harry Potter trong việc chống lại tên Chúa tể hắc ám Voldemort – người có tham vọng muốn trở nên bất tử, thống trị thế giới phù thủy, nô dịch hóa những người phi pháp thuật và tiêu diệt những ai cản đường hắn, đặc biệt là Harry Potter.', N'Lưu Sơn Minh: Tôi tâm phục khẩu phục bà Rowling khi từ tên nhân vật, tình huống câu chuyện đều phát triển rất logic thậm chí gửi gắm, ám chỉ một sự kiện nào đó', N'Nhà văn Bùi Chí Vinh: Tôi ngược lại không đánh giá cao lắm Harry Potter đứng từ góc độ tâm lý bạn đọc nhỏ tuổi Việt Nam. Nó có vẻ hợp với phương Tây hơn là phương Đông trong cách suy nghĩ, phép thuật cũng như hành động.', N'Nguyễn Nhật Ánh: Harry Potter không chỉ tạo cảm hứng, còn là một gợi ý cho tôi. Cùng với các tác phẩm khác như Chúa tể những chiếc nhẫn, Người hóa thú, Sabrina - cô phù thủy nhỏ, Harry Potter đã đánh thức trong tôi ước muốn sáng tác một bộ sách thể loại như thế cho trẻ em Việt Nam.', N'Nhà văn Nguyễn Quang Thiều: Trước hết, Harry Potter hấp dẫn tôi ở phương diện một cuốn sách mang nhiều yếu tố hoang đường và phù thủy nhưng được các em say mê, sau đó là sức tưởng tượng vô cùng phong phú của nhà văn.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS009', N'Giải Tích 1', N'https://vnuhcmpress.edu.vn/wp-content/uploads/2019/04/2013-09-09-12-49-53_GIAI-TICH-1-large.jpg', N'https://salt.tikicdn.com/cache/w1200/ts/product/c4/3a/2f/a531a42a00855fcf267f76b97fc526c4.jpg', N'Nguyễn Trường Thanh', N'Sách Giáo Khoa', 2016, N'Nguyễn Trường Thanh', 150000, N'Để phù hợp với chương trình đào tạo đại học ở Việt Nam nói chung và các trường Đại học Duy Tân nói riêng, nhóm biên dịch đã chủ động chia cuốn sách làm hai tập. Tập một dành cho giải tích hàm một biến, bao gồm lý thuyết phương trình vi phân và lý thuyết chuỗi.

Tập hai chứa các nội dung còn lại của toán cao cấp bao gồm giải cấp hàm nhiều biến và giải tích vector. Theo đó cuốn tập một này sẽ chứa 11 chương đầu của cuốn nguyên bản, bao gồm: Hàm số và giới hạn; đạo hàm; ứng dụng của đạo hàm; tích phân; phương trình vi phân; phương trình tham số và hệ tọa độ cực; dãy vô hạn và chuỗi. Cuốn hai sẽ chứa 6 chương còn lại của cuốn nguyên bản.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS010', N'Truyện cổ Andersen', N'https://salt.tikicdn.com/cache/w1200/ts/product/a1/17/0a/b8dc47b87cd5eb150c88d73418cd8de2.jpg', N'https://cdn.shopify.com/s/files/1/0553/5934/0742/products/642696cbaca46839f5ac29b0ba7b8804_1024x1024.jpg?v=1617998224', N'Hans Christian Andersen', N'Thiếu Nhi', 2019, N'Kim Đồng', 155000, N'Hans Christian Andersen (1805-1875) là một nhà văn người Đan Mạch, ông cũng là một người có tài kể chuyện cổ tích hay nhất thế giới. Khi lớn lên, Andersen bắt đầu chuyến chu du khắp châu Âu của mình. Ông đã đưa những điều mắt thấy tai nghe trong chuyến đi vào các câu chuyện nhỏ đầy thú vị và bắt đầu sự nghiệp viết truyện cổ tích. Truyện cổ Andersen ra đời từ đó. Các câu chuyện của ông đã được đông đảo các em thiếu nhi yêu thích.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS011', N'Hoa Thiên Cốt - Trọn bộ', N'https://static.hotdeal.vn/images/898/898339/500x500/217247-combo-hoa-thien-cot-bo-3-tap-tai-ban-2015.jpg', N'https://cdn0.fahasa.com/media/catalog/product/c/o/combo0216032016.jpg', N'Fresh Quả Quả', N'Trinh Thám, Khoa Học, Giả Tưởng, Tiểu Thuyết', 2018, N'Lao Động', 75000, N'“Tình yêu cao thượng? Đó đơn giản chỉ là một từ? Hay là một thứ phải hiến dâng hạnh phúc của đời mình,hy sinh tất cả mọi thứ mới có được? Đời này ta sống vì Trường Lưu, sống vì tiên giới, sống vì chúng sinh, nhưng chưa từng làm gì được cho nàng ấy. Ta không phụ Trường Lưu, không phụ Lục giới, không phụ trời đất, nhưng cuối cùng lại phụ nàng ấy, phụ cả bản thân ta.”', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS012', N'Xứ Cát', N'https://isach.info/images/story/cover/xu_cat__frank_herbert.jpg', N'https://image.thanhnien.vn/w1024/Uploaded/2021/ygtmjz/2021_07_24/poster_mece.jpg', N'Franklin Patrick Herbert', N'Lãng Mạn, Game, Khoa Học Giả Tưởng, Tiểu Thuyết', 2018, N'NXB Văn học', 120000, N'Dune là một tiểu thuyết khoa học viễn tưởng năm 1965của tác giả người Mỹ Frank Herbert , ban đầu được xuất bản thành hai kỳ riêng biệt trêntạp chí Analog . Nó gắn liền với This Immortal của Roger Zelazny cho giải thưởng Hugo năm 1966 và nó đã giành được giải thưởng Nebula đầu tiên cho Tiểu thuyết hay nhất . Đây là phần đầu tiên của Dune saga . Năm 2003, nó được mô tả là cuốn tiểu thuyết khoa học viễn tưởng bán chạy nhất thế giới.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS013', N'Doraemon: Chú khủng long của Nobita', N'https://product.hstatic.net/200000343865/product/1_163_0dd7221a44014a2488f7606fce6ad7e7.jpg', N'https://salt.tikicdn.com/cache/w1200/ts/product/d1/0e/14/664f18f0f2b51aad5258b4dc3f24018c.jpg', N'Fujiko Fujio', N'Hư cấu kỳ ảo', 2019, N'Kim Đồng', 42000, N'Một câu chuyện cảm động về tình bạn giữa con người với thế giới tự nhiên. Phiên bản màu đặc biệt với phần bên lề cung cấp những hiểu biết về các loài khủng long và các bảo bối xuất hiện trong truyện.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS014', N'Doraemon: Vương quốc trên mây', N'https://product.hstatic.net/200000343865/product/12_75_ddba79b9c1ec4e7aaa42996aec29baab_master.jpg', N'https://salt.tikicdn.com/cache/w1200/ts/product/bb/e0/a5/36a1dd55daba968ac58e0b32dae6752c.jpg', N'Fujiko Fujio', N'Thiếu Nhi, Kỳ Ảo, Tiểu Thuyết ', 2017, N'Kim Đồng', 55000, N'Doraemon - Phiên Bản Điện Ảnh Màu (Tập 13): Nobita Và Vương Quốc Trên Mây. Nobita và vương quốc trên mây là tác phẩm thứ 13 trong loạt phim hoạt hình Doraemon rất được yêu thích, chuyển thể từ nguyên tác truyện tranh cùng tên của tác giả FUJIKO F FUJIO. (bộ phim được công chiếu vào mùa xuân năm 1992).', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS015', N'Narnia - Trọn bộ', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTAYWCrz8fle6BYbeN_k8kMEe2kRJCyezDfGJAP6pBLWRPltQI0yc0iB7xupou02IgPG0&usqp=CAU', N'https://photo-cms-vovworld.zadn.vn/w500/Uploaded/vovworld/znaeng/2015_12_28/Bien%20nien%20su%20Narnia.PNG', N'C.S.Lewis', N'Trinh Thám, Tiểu Thuyết ', 2015, N'Kim Đồng', 36000, N'Biên niên sử Narnia - bộ truyện có tên trong danh sách 21 cuốn sách được độc giả Anh yêu thích nhất (trong danh sách 100 tiểu thuyết thế giới) vừa được tái bản với diện mạo hoàn toàn mới. Câu chuyện bắt đầu với bốn anh em nhà Pevensie: Peter, Susan, Edmund, và Lucy, những đứa trẻ bình thường cũng đang đến trường như bao đứa trẻ cùng trang lứa khác. Mọi thứ chỉ thực sự thay đổi khi cả bọn tình cờ phát hiện ra bí mật lớn trong tủ áo nhà giáo sư Digory Kirke: một thế giới hoàn toàn xa lạ, đầy ma thuật và những sinh vật huyền thoại, có tển là Narnia. Và các bạn nhỏ đã dấn thân vào những cuộc phiêu lưu bất ngờ.

 ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS016', N'Oliver Tiwst', N'https://revelogue.com/wp-content/uploads/2020/05/Poster-phim-Oliver-Twist-e1588771113123.jpg', N'https://salt.tikicdn.com/cache/w1200/ts/product/92/23/ef/d9064330350219952a033f082404683a.jpg', N'Charles Dickens', N'Tiểu thuyết', 2012, N'NXB Văn học', 250000, N'Oliver Twist là một trong những tác phẩm thành công nhất của Charles Dickens. Cuộc đấu tranh giữa thiện và ác cùng những tấm lòng lương thiện sáng lên trên từng trang sách đã lôi cuốn nhiều thế hệ độc giả từ trẻ em đến người lớn. Cuốn sách cũng rất nhiều lần được chuyển thể thành phim điện ảnh, truyền hình, anime, kịch và nhạc kịch, trong đó bộ phim ca nhạc năm 1968 đã đoạt giải Oscar.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS017', N'Sword Art Online: Aincrad - Tập 2', N'https://salt.tikicdn.com/media/catalog/product/c/o/cover_1_sao_2.jpg', N'https://cdn.discordapp.com/attachments/900723602389868566/922046088612040714/unknown.png', N'Reki Kawahara', N'Huyền Huyễn, Xuyên Không, Tiểu Thuyết', 2016, N'Hống Đức', 48000, N'Sword Art Online 002 - Aincrad Đây vẫn là game, nhưng vẫn không phải trò chơi.Tập 2 xoay quanh nhân vật chính Kirito và các cuộc gặp gỡ nhiều dấu ấn của cậu.Tuy cương quyết làm game thủ solo trong trò chơi tử thần Sword Art Online, nhưng bằng tính cách thu hút và tài năng đặc biệt của mình, Kirito vẫn gặp được những con người thú vị hoặc tuyệt vời suốt hành trình phá đảo.Trong SAO, ngoài Kirito và nhóm tấn công ra, còn có rất nhiều người chơi khác nữa. Họ tham gia hoạt động ở các ngành nghề đa dạng, và hỗ trợ đội ngũ chiến binh nơi tiền tuyến bằng chuyên môn và sở trường của mình. Tuy không thể đăng xuất, bắt buộc phải tồn tại trong thế giới trò chơi tàn khốc này, nhưng họ vẫn sống một cách sôi nổi, hăng hái và chấp nhận thách thức, có rơi nước mắt nhưng cũng có nụ cười. Chẳng hạn như Silica giỏi thuần hóa thú, Lisbeth chuyên rèn binh khí, hay Sachi một thiếu nữ mà Kirito không thể nào quên...Câu chuyện này mở ra cuộc gặp gỡ của Kirito với họ, cùng những kỉ niệm đẹp đẽ mà họ để lại khi hai bên đi ngang qua đời nhau...', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS018', N'Bộ sách giáo khoa lớp 9', N'https://nhasachhaihau.com/wp-content/uploads/2021/04/sgkl9bd4.jpg', N'https://img.websosanh.vn/v10/users/review/images/1fdor7e4e2xyz/sach-giao-khoa-lop-9.jpg?compress=85', N'Bộ giáo dục và đào tạo', N'Sách Giáo Khoa', 2019, N'Bộ Giáo Dục và Đào Tạo', 92000, N'Bộ sách giáo khoa lớp 9 của Nhà xuất bản Giáo dục Việt Nam năm học 2020 – 2021 về nội dung không có gì thay đổi so với năm học 2019 - 2020. Được nhà xuất bản Giáo dục tái bản lại (lần thứ mười bốn). Bộ sách gồm 13 quyển sách giáo khoa và 7 quyển sách bài tập.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS019', N'Bộ vở bài tập lớp 9', N'https://product.hstatic.net/200000343833/product/bt9_ca887d2cdfc449c89460c224a5f1fef4_master.png', N'https://nhasachhaihau.com/wp-content/uploads/2021/04/sgkl9bd2.jpg', N'Bộ giáo dục và đào tạo', N'Sách Giáo Khoa', 2020, N'Bộ Giáo Dục và Đào Tạo', 38000, N'Bộ sách giáo khoa sách bổ trợ đại trà theo chương trình học phổ thông.
Bộ Sách Bài Tập (Bộ 6 Cuốn) do Bộ Giáo dục quy định bao gồm những đầu sách được sử dụng trong giảng dạy và học tập trong toàn quốc.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS020', N'Truyện Kiều', N'https://palda.vn/wp-content/uploads/2021/04/truyen-kieu.jpg', N'https://salt.tikicdn.com/cache/400x400/ts/product/41/fd/59/9a433ce8dd07a44e61567efaff0088b0.jpg', N'Nguyễn Du', N'Tiểu Thuyết ', 2015, N'Văn Học', 75000, N'Tác phẩm Truyện Kiều, nguyên tên là Đoạn trường tân thanh, từ khi ra đời đến nay, khoảng 200 năm, trong lịch sử Văn học Việt Nam, chưa có tác phẩm nào được các nhà khảo cứu, phê bình, xuất bản quan tâm đến nó, từ nội dung, hình thức, lẫn văn bản và thời điểm sáng tác đặc biệt đến như vậy. Một trong nguyên nhân chính là vì bản gốc của Nguyễn Du sáng tác không còn nữa.', N'Nhà văn Phạm Quỳnh: ca ngợi Truyện Kiều “vừa là kinh, vừa là truyện, vừa là Thánh thư Phúc âm của cả một dân tộc”, là “một thiên văn khế tuyệt bút”, là quốc hoa, quốc túy, quốc hồn của nước ta, để ta có thể “ngạo nghễ với non sông mà tự phụ với người đời', N'Nhà văn Pháp Joocjo Budaren nói: Truyện Kiều của Nguyễn Du  "quả là một bản trường ca kỳ lạ, nghịch đời, hấp dẫn và hiếm có".', N'Nhà nghiên cứu Georges Coocdier ca ngợi ngọn bút tả cảnh tài tình của Nguyễn Du, chỉ phác mấy nét bút mà vẽ nên phong cảnh đầy khí sắc và cảm tình "giống như thơ hai-ku của Nhật Bản, mà còn có phần tinh tế hơn".', N'Nhà thơ Lại Tây Dương: Truyện Kiều là một truyện thơ dài với hơn ba nghìn câu nhưng không câu nào "đuối". Cách nhà thơ sử dụng ngôn ngữ thực sự mang tính phát hiện, sáng tạo, tài tình. Đọc, ngẫm và nghiên cứu Truyện Kiều, tôi đã học được cách dùng từ, sử dụng biện pháp tu từ đạt hiệu quả cao, từ đó vận dụng trong các sáng tác của mình.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS021', N'Nấu ăn bằng cả trái tim', N'https://www.nxbtre.com.vn/Images/Book/NXBTreStoryFull_27572015_085741.jpg', N'https://static.hotdeal.vn/images/898/898293/500x500/217242-nau-an-bang-ca-trai-tim-bia-mem.jpg', N'CHRISTINE HÀ', N'Đời Thường', 2020, N'Trẻ', 86000, N'Trong bếp, Christine Hà sở hữu một kỹ năng hiếm hoi mà hầu hết các siêu đầu bếp được đào tạo chuyên nghiệp khó lòng học cách sử dụng, đó là khả năng nấu ăn bằng cảm giác. Sau biến cố mất thị lực khi vừa hơn hai mươi tuổi, vị quán quân phi thường của MasterChef mùa thứ 3 đã phải học lại cách nấu ăn dựa vào những giác quan trội hơn như nếm, sờ, ngửi và nghe. Là thí sinh khiếm thị duy nhất từ trước đến nay trong một cuộc thi nấu ăn, Hà đã tạo ra hết bất ngờ này đến bất ngờ khác để rồi giành được giải thưởng cao nhất.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS022', N'Ông Già Và Biển Cả', N'https://bizweb.dktcdn.net/thumb/1024x1024/100/370/339/products/ong-gia-dinh-ti.jpg?v=1590076218870', N'https://cdn.discordapp.com/attachments/900723602389868566/922059010910326834/Ong_gia_va_bien_ca_-_bia_sau.jpg', N'Ernest Hemingway', N'Tiểu Thuyết, Viên Tưởng', 2014, N'Văn Học', 77000, N'Ông già và Biển cả (tên tiếng Anh: The Old Man and the Sea) là một tiểu thuyết ngắn được Ernest Hemingway viết ở Cuba năm 1951 và xuất bản năm 1952. Nó là truyện ngắn dạng viễn tưởng cuối cùng được viết bởi Hemingway. Đây cũng là tác phẩm nổi tiếng và là một trong những đỉnh cao trong sự nghiệp sáng tác của nhà văn. Tác phẩm này đoạt giải Pulitzer cho tác phẩm hư cấu năm 1953. Nó cũng góp phần quan trọng để nhà văn được nhận Giải Nobel văn học năm 1954.
', N'Nhà văn Huy Phương cũng đưa ra ý kiến: “Với một nội dung tưởng chừng như đơn giản, thiên tiểu thuyết đã nên lên được những nét rất sâu sắc và cảm động về sức mạnh và khát vọng của con người”.', N'PGS.TS Đặng Anh Đào: Tác giả đề cập đến mối quan hệ giữa biển cả và ông già, biển cả - khung cảnh kì vĩ tương ứng với môi trường hoạt động sáng tạo của con người.', N'Lê Nguyên Cẩn có lời bình: “Ông già bé nhỏ ấy được đặt vào biển cả mênh mông. Nhưng cái mênh mông này lại mang cái đơn điệu bởi sự trống vắng của nó...”, đó là vấn đề mối liên hệ giữa ông già và biển cả.', N'Nhà nghiên cứu Lê Đình Cúc đã đưa ra lời bình: “Ông già và biển cả làm cho người đọc liên hệ nhiều đến con người với số phận của nó trong vũ trụ và lịch sử. Từ cái mõm nhọn, đầy răng nhọn của lũ cá mập đến biển hài hòa xanh ngát với những con chim én nhỏ nhắn có giọng hót buồn buồn và thanh. ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS023', N'Hôm Nay Tôi Thất Tình', N'https://salt.tikicdn.com/media/catalog/product/a/n/anh-bia-1-01.u2487.d20161230.t145254.885105.jpg', N'https://cf.shopee.vn/file/6fe8fbde454e66a1d03d109e99a72859', N'Hạ Vũ', N'Ngôn Tình', 2016, N'Hà Nội', 50000, N'Hôm nay tôi thất tình, là cuốn nhật kí ghi lại những dấu ấn của tình yêu tuổi trẻ. Nơi cất lại những bức họa buồn được người tô vẽ trong vội vàng. Người muốn vượt qua nỗi buồn hãy cứ bình tĩnh, Xa người đó rồi, nhất định sẽ gặp được một kẻ tốt hơn. Ông trời sắp đặt cả rồi, không cần gấp. Người hãy như Hạ Vũ, cứ im lặng, đi xem phim, đi shopping, đi ăn, đi chơi với bạn bè, chăm chỉ lên lớp, chăm chỉ đi làm... Từng bị tổn thương một lần rồi, đừng dùng những hành vi ngây thơ trẻ con làm tổn thương chính mình để trả thù hay trút hết cảm xúc. Có thù hận nặng nề tới mấy kẻ đã bỏ buông cũng chẳng quay lại.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS024', N'Chúa tể những chiếc nhẫn: Đoàn hộ nhẫn', N'https://salt.tikicdn.com/ts/product/ab/72/01/40e8e5cd4437d4df9bb35810e638eae7.jpg', N'https://cdn0.fahasa.com/media/flashmagazine/images/page_images/chua_te_nhung_chiec_nhan___doan_ho_nhan_tai_ban_2019/2020_03_19_15_36_08_10-390x510.jpg', N'J.R.R. Tolkien', N'Thiếu Nhi, Truyện Tranh', 2019, N'Văn Học', 180000, N'Kỷ Đệ Nhất, các Valar kết liễu Morgoth. Kỷ Đệ Nhị, Tiên và Người đánh bại Sauron. Và nay, giữa Kỷ Đệ Tam tưởng đã hòa bình, báu vật của Sauron lại ngóc đầu trong lòng núi. Và thêm một anh chàng Hobbit bỗng thấy mình từ biệt tổ ấm yên bình, dấn vào cuộc phiêu lưu mỗi bước lại thêm xa, thêm gian nan, thêm hệ trọng. Bên cậu sát cánh Đoàn Hộ Nhẫn, Con Người cùng Phù Thủy, Tiên với Người Lùn, vượt đèo cả đầm sâu, qua rừng vàng mỏ tối, vào sinh ra tử hòng lần nữa cứu Trung Địa khỏi rơi vào tay CHÚA TỂ NHỮNG CHIẾC NHẪN.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS025', N'Chúa tể những chiếc nhẫn: Hai tòa tháp', N'https://cdn0.fahasa.com/media/flashmagazine/images/page_images/chua_te_nhung_chiec_nhan___hai_toa_thap_tai_ban_2019/2021_07_29_11_51_22_1-390x510.jpg', N'https://cdn0.fahasa.com/media/flashmagazine/images/page_images/chua_te_nhung_chiec_nhan___hai_toa_thap_tai_ban_2019/2021_07_29_11_51_22_7-390x510.jpg', N'J.R.R. Tolkien', N'Thiếu Nhi, Truyện Tranh', 2019, N'Văn Học', 29000, N'Trong Chúa Tể Những Chiếc Nhẫn - Tập 2: Hai Tòa Tháp, chín bộ hành còn bảy. Một con đường chia hai. Người mang nhẫn dấn thân vào vùng Đất Đen cùng bạn đường trung nghĩa và kẻ dẫn đường bất trắc.

Hai Hobbit bị cướp đi giữa ba phe Orc, để Ba Thợ Săn làm nên kỳ tích đuổi theo. Và một giống dân cổ xưa bừng tỉnh, hai tòa tháp xuất quân, một đất nước Con Người tập hợp binh mã đương đầu với ngoại xâm.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS026', N'Chúa tể những chiếc nhẫn: Nhà vua trở về', N'https://cf.shopee.vn/file/00c54c52642c143835d0ccb313b416e4', N'https://www.netabooks.vn/Data/Sites/1/Product/17379/chua-te-nhung-chiec-nhan-nha-vua-tro-ve-tai-ban-2.jpg', N'J.R.R. Tolkien', N'Thiếu Nhi, Truyện Tranh', 2019, N'Văn Học', 26000, N'Phần Thứ Ba - Tập đại thành Tiểu thuyết kỳ ảo - của J.R.R. Tolkien
Mọi ngả đường dồn dập về một đích.
Những thề xưa lần lượt được làm tròn.
Các chàng Hobbit thấy mình làm nên truyền thuyết.
Và khi cổng Kinh Thành đổ sụp trước quân thù, cũng là lúc Nhà Vua trở về trên chiến địa.
Giữa bùi ngùi và hân hoan, giữa tái ngộ và ly biệt, cùng hoa nở sân Thượng Triều và buồm giong từ Cảng Xám, Kỷ Đệ Tam khép lại cho thời Con Người Thống Trị bắt đầu.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS027', N'Anh Chàng Hobbit (Tái Bản 2014)', N'https://salt.tikicdn.com/cache/280x280/media/catalog/product/a/n/anh_chang_hobbit_2.jpg', N'https://cf.shopee.vn/file/77d69cb2a0990bc5e6f8e51e10e77529', N'J.R.R. Tolkien', N'Thiếu Nhi, Huyền Ảo, Kì Ảo, Sử Thi', 2014, N'Hội Nhà Văn', 19000, N'Khởi đầu, Anh Chàng Hobbit là một tác phẩm dành cho thiếu nhi nhưng đến nay, dường như không nhiều người còn nhớ đến điều đó nữa, và tác phẩm thì đã được xếp vào nhóm những tiểu thuyết thần thoại kỳ ảo kinh điển. 
Câu chuyện của Anh Chàng Hobbit là một chuyến phiêu lưu, khi Bilbo Baggins bị cuốn vào chuyến phiêu lưu giành lại xứ sở của những người lùn. Chuyến đi ấy vốn chẳng bao giờ được cho là thích hợp với một Hobbit chỉ thích ăn thức ngon, ở chỗ đẹp. Nhưng rồi Bilbo đã tham gia, đã bị cuốn vào rồi có thể trở về. Chuyến phiêu lưu trở thành bài học về cuộc sống, về con người.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS028', N'Khu Vườn Ngôn Từ', N'https://upload.wikimedia.org/wikipedia/vi/thumb/f/f6/Kotono_no_Niwa_poster.jpg/200px-Kotono_no_Niwa_poster.jpg', N'https://cf.shopee.vn/file/13bc005df191655ed13aff9f57f81ca9', N'Shinkai Makoto', N'Lãng Mạn', 2020, N'Văn Học', 26000, N'Sword Art Online 002 - Aincrad Đây vẫn là game, nhưng vẫn không phải trò chơi.Tập 2 xoay quanh nhân vật chính Kirito và các cuộc gặp gỡ nhiều dấu ấn của cậu.Tuy cương quyết làm game thủ solo trong trò chơi tử thần Sword Art Online, nhưng bằng tính cách thu hút và tài năng đặc biệt của mình, Kirito vẫn gặp được những con người thú vị hoặc tuyệt vời suốt hành trình phá đảo.Trong SAO, ngoài Kirito và nhóm tấn công ra, còn có rất nhiều người chơi khác nữa. Họ tham gia hoạt động ở các ngành nghề đa dạng, và hỗ trợ đội ngũ chiến binh nơi tiền tuyến bằng chuyên môn và sở trường của mình. Tuy không thể đăng xuất, bắt buộc phải tồn tại trong thế giới trò chơi tàn khốc này, nhưng họ vẫn sống một cách sôi nổi, hăng hái và chấp nhận thách thức, có rơi nước mắt nhưng cũng có nụ cười. Chẳng hạn như Silica giỏi thuần hóa thú, Lisbeth chuyên rèn binh khí, hay Sachi một thiếu nữ mà Kirito không thể nào quên...Câu chuyện này mở ra cuộc gặp gỡ của Kirito với họ, cùng những kỉ niệm đẹp đẽ mà họ để lại khi hai bên đi ngang qua đời nhau.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS029', N'Another - Trọn bộ 2 tập', N'https://adcbook.net.vn/web/image/product.template/11889/image_1024?unique=b99053f', N'https://meobietbay.com/wp-content/uploads/2019/04/another-tron-bo-2-tap.jpg', N'Yukito Ayatsuji', N'Kinh Dị, Siêu Năng Lực', 2015, N'Hồng Đức', 43000, N'Another là câu chuyện 3 trong 1: ma, kinh dị, học đường.

Hai mươi sáu năm về trước có một học sinh hoàn thiện hoàn mĩ. Rất đẹp, rất giỏi, rất hòa đồng, ai cũng yêu quý, những lời tán tụng người ấy được truyền mãi qua các thế hệ học sinh của trường. Nhưng tên đầy đủ là gì, chết đi thế nào, thậm chí giới tính ra sao lại không một ai hay biết. Người ta chỉ rỉ tai nhau, bỗng nhiên giữa năm bạn ấy chết, trường lớp không sao thoát được nỗi buồn nhớ thương, họ bèn cư xử như thể học sinh này còn tồn tại. Bàn ghế để nguyên, bạn cùng lớp vẫn giả vờ nói chuyện với người đã khuất.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [UrlImage], [UrlImageSau], [TacGia], [TheLoai], [NamXB], [NXB], [GiaBan], [MoTa], [NhanXet1], [NhanXet2], [NhanXet3], [NhanXet4]) VALUES (N'MS030', N'Doraemon: Nobita và chuyến phiêu lưu vào xứ quỷ', N'https://product.hstatic.net/200000343865/product/1_163_0dd7221a44014a2488f7606fce6ad7e7.jpg', N'https://salt.tikicdn.com/ts/review/11/37/c4/91d5d15b8322fb5419bba4df02ce1aa3.jpg', N'Fujiko Fujio', N'Thiếu Nhi, Truyện Tranh', 2019, N'Kim Đồng', 20000, N'Doraemon: Nobita và chuyến phiêu lưu vào xứ quỷ là một phim điện ảnh anime thể loại khoa học viễn tưởng sản xuất năm 1984 của đạo diễn Shibayama Tsutomu, nằm trong loạt manga và anime Doraemon. Đây là phim chỉ đề thứ năm của anime Doraemon. Trước khi chính thức khởi chiếu vào tháng 3 năm 1984, Fujiko F. Fujio đã đăng tiếp toàn bộ nội dung truyện trên tạp chí CoroCoro Comic do Shogakukan ấn hành, sau đó được xuất bản dưới dạng tankōbon vào năm 1984 và trở thành tập manga thứ năm thuộc xê-ri truyện dài Doraemon. Truyện phim bắt nguồn từ giấc mơ trở thành phù thủy sống ở thế giới phép của Nobita cho đến khi nó được biến thành hiện nhờ vào Tủ điện thoại yêu cầu và tại đây Nobita đã chiến đấu chống lại quỷ vương Demaon đem lại yên bình cho Trái Đất.', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TaiKhoan] ([Username], [Password], [Email], [HoTen]) VALUES (N'1', N'1', N'1@admin.com', N'1')
INSERT [dbo].[TaiKhoan] ([Username], [Password], [Email], [HoTen]) VALUES (N'thyyy', N'thy', N'mdthy@gmail.com', N'Mac Dinh Thy')
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  CONSTRAINT [DF_ChiTietHoaDon_SoLuong]  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  CONSTRAINT [DF_ChiTietHoaDon_DonGia]  DEFAULT ((0)) FOR [DonGia]
GO
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF_HoaDon_TongTien]  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [DF_KhachHang_HoTen]  DEFAULT (N'<Tên khách hàng>') FOR [HoTen]
GO
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [DF_KhachHang_DiaChi]  DEFAULT (N'<Địa chỉ>') FOR [DiaChi]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_SACH_TenSach]  DEFAULT (N'<Tên sách>') FOR [TenSach]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Sach]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [FK_Kho_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [FK_Kho_Sach]
GO
