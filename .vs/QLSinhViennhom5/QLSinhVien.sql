USE [QlSinhVien]
GO
/****** Object:  Table [dbo].[chinhsach]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chinhsach](
	[macs] [nchar](10) NOT NULL,
	[tencs] [nvarchar](50) NULL,
	[chedo] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[macs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[diem]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diem](
	[id] [int] NOT NULL,
	[masv] [nchar](10) NULL,
	[mamh] [nchar](10) NULL,
	[diem] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giaovien]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giaovien](
	[magv] [nchar](10) NOT NULL,
	[tengv] [nvarchar](30) NULL,
	[gioitinh] [nvarchar](5) NULL,
	[ngaysinh] [date] NULL,
	[sdt] [nvarchar](11) NULL,
	[diachi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[magv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khoa]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khoa](
	[makhoa] [nchar](10) NOT NULL,
	[tenkhoa] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[makhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[tk] [nvarchar](50) NOT NULL,
	[mk] [nvarchar](max) NOT NULL,
	[fullname] [nvarchar](30) NOT NULL,
	[mod] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[tk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lop]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lop](
	[malop] [nchar](10) NOT NULL,
	[tenlop] [nvarchar](50) NULL,
	[makhoa] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[monhoc]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[monhoc](
	[mamh] [nchar](10) NOT NULL,
	[tenmh] [nvarchar](50) NULL,
	[magv] [nchar](10) NULL,
	[sotiet] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mamh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sinhvien]    Script Date: 8/22/2024 9:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sinhvien](
	[masv] [nchar](10) NOT NULL,
	[tensv] [nvarchar](30) NULL,
	[gioitinh] [nvarchar](5) NULL,
	[ngaysinh] [date] NULL,
	[sdt] [nvarchar](11) NULL,
	[diachi] [nvarchar](50) NULL,
	[macs] [nchar](10) NULL,
	[malop] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[masv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[chinhsach] ([macs], [tencs], [chedo]) VALUES (N' CS001    ', N'Chính sách học phí', N'Học phí')
INSERT [dbo].[chinhsach] ([macs], [tencs], [chedo]) VALUES (N' CS002    ', N'Ưu Đãi học Bổng', N'Ưu tiên')
GO
INSERT [dbo].[diem] ([id], [masv], [mamh], [diem]) VALUES (1, N'sv1       ', N'mh1       ', 7)
GO
INSERT [dbo].[giaovien] ([magv], [tengv], [gioitinh], [ngaysinh], [sdt], [diachi]) VALUES (N'gv1       ', N'Mai Mạnh Trừng', N'Nam', CAST(N'1995-02-02' AS Date), N'0948484885', N'Hà Nội')
INSERT [dbo].[giaovien] ([magv], [tengv], [gioitinh], [ngaysinh], [sdt], [diachi]) VALUES (N'gv2       ', N'Phạm Thị Thùy', N'Nữ', CAST(N'1995-02-02' AS Date), N'0948848805', N'Hà Nội')
INSERT [dbo].[giaovien] ([magv], [tengv], [gioitinh], [ngaysinh], [sdt], [diachi]) VALUES (N'gv3       ', N'Phạm Chí Hướng', N'Nam', CAST(N'1995-02-15' AS Date), N'0948848805', N'Ninh Bình')
INSERT [dbo].[giaovien] ([magv], [tengv], [gioitinh], [ngaysinh], [sdt], [diachi]) VALUES (N'gv4       ', N'Nguyễn Phi Hùng', N'Nam', CAST(N'1995-02-02' AS Date), N'0948815151', N'Hà Nội')
INSERT [dbo].[giaovien] ([magv], [tengv], [gioitinh], [ngaysinh], [sdt], [diachi]) VALUES (N'gv5       ', N'Phạm Anh Dũng', N'Nam', CAST(N'1995-02-07' AS Date), N'0515151552', N'Thái Bình')
GO
INSERT [dbo].[khoa] ([makhoa], [tenkhoa]) VALUES (N'K001      ', N'Công Nghệ Thông Tin')
INSERT [dbo].[khoa] ([makhoa], [tenkhoa]) VALUES (N'K002      ', N'Tài Chính Ngân Hàng')
INSERT [dbo].[khoa] ([makhoa], [tenkhoa]) VALUES (N'K003      ', N'Khoa May')
INSERT [dbo].[khoa] ([makhoa], [tenkhoa]) VALUES (N'K004      ', N'Khoa Kinh tế')
GO
INSERT [dbo].[Login] ([tk], [mk], [fullname], [mod], [state]) VALUES (N'anhdung', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Phạm anh Dũng', 4, 1)
INSERT [dbo].[Login] ([tk], [mk], [fullname], [mod], [state]) VALUES (N'anhdung123', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Phạm Anh Dũng', 3, 1)
INSERT [dbo].[Login] ([tk], [mk], [fullname], [mod], [state]) VALUES (N'hungnguyen123', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Nguyễn Phi Hùng', 3, 1)
INSERT [dbo].[Login] ([tk], [mk], [fullname], [mod], [state]) VALUES (N'nguyenhungkkk', N'bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a', N'Nguyễn Phi Hùng', 4, 1)
INSERT [dbo].[Login] ([tk], [mk], [fullname], [mod], [state]) VALUES (N'trangdam123', N'bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a', N'Đàm Thị Kiều Trang', 2, 1)
INSERT [dbo].[Login] ([tk], [mk], [fullname], [mod], [state]) VALUES (N'tung123', N'bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a', N'Hà Thành Tùng', 1, 1)
GO
INSERT [dbo].[lop] ([malop], [tenlop], [makhoa]) VALUES (N'DHTI14A2CL', N'Tin A2 CL', N'K001      ')
INSERT [dbo].[lop] ([malop], [tenlop], [makhoa]) VALUES (N'DTM14A2HN ', N'May 14A2 HN', N'K003      ')
GO
INSERT [dbo].[monhoc] ([mamh], [tenmh], [magv], [sotiet]) VALUES (N'mh1       ', N'CSDL', N'gv1       ', 50)
INSERT [dbo].[monhoc] ([mamh], [tenmh], [magv], [sotiet]) VALUES (N'mh2       ', N'Trí tuệ nhân tạo', N'gv2       ', 50)
GO
INSERT [dbo].[sinhvien] ([masv], [tensv], [gioitinh], [ngaysinh], [sdt], [diachi], [macs], [malop]) VALUES (N'sv1       ', N'Nguyễn Phi Hùng', N'Nam', CAST(N'2002-01-27' AS Date), N'0515151552', N'Nghệ An', N' CS002    ', N'DTM14A2HN ')
INSERT [dbo].[sinhvien] ([masv], [tensv], [gioitinh], [ngaysinh], [sdt], [diachi], [macs], [malop]) VALUES (N'sv2       ', N'Đàm Thị Kiều Trang', N'Nữ', CAST(N'2002-02-13' AS Date), N'0155151500', N'Hà Nội', N' CS002    ', N'DHTI14A2CL')
INSERT [dbo].[sinhvien] ([masv], [tensv], [gioitinh], [ngaysinh], [sdt], [diachi], [macs], [malop]) VALUES (N'sv3       ', N'Lê Thị Quỳnh', N'Nam', CAST(N'2002-02-04' AS Date), N'0945968013', N'Hà Nội', N' CS001    ', N'DHTI14A2CL')
INSERT [dbo].[sinhvien] ([masv], [tensv], [gioitinh], [ngaysinh], [sdt], [diachi], [macs], [malop]) VALUES (N'sv4       ', N'Phạm Anh Dũng', N'Nam', CAST(N'2002-02-13' AS Date), N'0255151556', N'Hà Nội', N' CS001    ', N'DHTI14A2CL')
GO
ALTER TABLE [dbo].[diem]  WITH CHECK ADD FOREIGN KEY([mamh])
REFERENCES [dbo].[monhoc] ([mamh])
GO
ALTER TABLE [dbo].[diem]  WITH CHECK ADD FOREIGN KEY([mamh])
REFERENCES [dbo].[monhoc] ([mamh])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[diem]  WITH CHECK ADD FOREIGN KEY([masv])
REFERENCES [dbo].[sinhvien] ([masv])
GO
ALTER TABLE [dbo].[diem]  WITH CHECK ADD FOREIGN KEY([masv])
REFERENCES [dbo].[sinhvien] ([masv])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[lop]  WITH CHECK ADD FOREIGN KEY([makhoa])
REFERENCES [dbo].[khoa] ([makhoa])
GO
ALTER TABLE [dbo].[lop]  WITH CHECK ADD FOREIGN KEY([makhoa])
REFERENCES [dbo].[khoa] ([makhoa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[monhoc]  WITH CHECK ADD FOREIGN KEY([magv])
REFERENCES [dbo].[giaovien] ([magv])
GO
ALTER TABLE [dbo].[monhoc]  WITH CHECK ADD FOREIGN KEY([magv])
REFERENCES [dbo].[giaovien] ([magv])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD FOREIGN KEY([macs])
REFERENCES [dbo].[chinhsach] ([macs])
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD FOREIGN KEY([macs])
REFERENCES [dbo].[chinhsach] ([macs])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD FOREIGN KEY([malop])
REFERENCES [dbo].[lop] ([malop])
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD FOREIGN KEY([malop])
REFERENCES [dbo].[lop] ([malop])
ON DELETE CASCADE
GO
