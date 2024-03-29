USE [master]
GO
/****** Object:  Database [BirdTradingPlatform]    Script Date: 6/7/2023 6:31:13 PM ******/
CREATE DATABASE [BirdTradingPlatform]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BirdTradingPlatform', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BirdTradingPlatform.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BirdTradingPlatform_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BirdTradingPlatform_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BirdTradingPlatform] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BirdTradingPlatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BirdTradingPlatform] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET ARITHABORT OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BirdTradingPlatform] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BirdTradingPlatform] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BirdTradingPlatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BirdTradingPlatform] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET RECOVERY FULL 
GO
ALTER DATABASE [BirdTradingPlatform] SET  MULTI_USER 
GO
ALTER DATABASE [BirdTradingPlatform] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BirdTradingPlatform] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BirdTradingPlatform] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BirdTradingPlatform] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BirdTradingPlatform] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BirdTradingPlatform] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BirdTradingPlatform', N'ON'
GO
ALTER DATABASE [BirdTradingPlatform] SET QUERY_STORE = OFF
GO
USE [BirdTradingPlatform]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [nvarchar](10) NULL,
	[Password] [nvarchar](255) NULL,
	[Role] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[CreateDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Total] [float] NULL,
	[PaymentStatus] [nvarchar](10) NULL,
	[Status] [nvarchar](10) NULL,
	[CreateDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
	[rating] [int] NULL,
	[Status] [nvarchar](10) NULL,
	[OrderShopId] [int] NULL,
	[CreateDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderShop]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderShop](
	[OrderShopId] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NULL,
	[OrderId] [int] NULL,
	[Total] [float] NULL,
	[CreateDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NULL,
	[CategoryId] [int] NULL,
	[ProductName] [nvarchar](255) NULL,
	[ProductImage] [nvarchar](255) NULL,
	[UnitPrice] [float] NULL,
	[Quantity] [int] NULL,
	[Rating] [int] NULL,
	[CreateDate] [date] NULL,
	[Species] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Size] [int] NULL,
	[Weight] [int] NULL,
	[Expiration] [date] NULL,
	[MadeIn] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Color] [nvarchar](20) NULL,
	[Material] [nvarchar](20) NULL,
	[Description] [nvarchar](500) NULL,
	[BrandName] [nvarchar](50) NULL,
	[Status] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ProductImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[Status] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[ShopId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[ShopName] [nvarchar](50) NULL,
	[Address] [nvarchar](300) NULL,
	[AvatarUrl] [nvarchar](255) NULL,
	[CreateDate] [date] NULL,
	[Status] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/7/2023 6:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[DOB] [date] NULL,
	[Gender] [nvarchar](10) NULL,
	[CreateDate] [date] NULL,
	[AvatarUrl] [nvarchar](255) NULL,
	[Status] [nvarchar](10) NULL,
	[Address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [PhoneNumber], [Password], [Role], [Status], [CreateDate]) VALUES (1, N'1234567890', N'1', N'USER', N'ACTIVE', CAST(N'2023-06-22' AS Date))
INSERT [dbo].[Account] ([AccountId], [PhoneNumber], [Password], [Role], [Status], [CreateDate]) VALUES (2, N'0238457574', N'1', N'USER', N'ACTIVE', CAST(N'2023-06-22' AS Date))
INSERT [dbo].[Account] ([AccountId], [PhoneNumber], [Password], [Role], [Status], [CreateDate]) VALUES (3, N'0123456789', N'1', N'SHOP', N'ACTIVE', CAST(N'2023-06-22' AS Date))
INSERT [dbo].[Account] ([AccountId], [PhoneNumber], [Password], [Role], [Status], [CreateDate]) VALUES (4, N'9876543210', N'admin', N'STAFF', N'ACTIVE', CAST(N'2023-06-22' AS Date))
INSERT [dbo].[Account] ([AccountId], [PhoneNumber], [Password], [Role], [Status], [CreateDate]) VALUES (5, N'0123222333', N'1', N'SHOP', N'ACTIVE', CAST(N'2023-07-04' AS Date))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Status]) VALUES (1, N'Birds', N'ACTIVE')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Status]) VALUES (2, N'Foods', N'ACTIVE')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Status]) VALUES (3, N'Accessories', N'ACTIVE')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Status]) VALUES (5, N'Birds', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (1, 1, 1, N'African Grey Parrot', N'https://res.cloudinary.com/dk-find-out/image/upload/q_80,w_960,f_auto/DCTM_Penguin_UK_DK_AL526630_wkmzns.jpg', 500, 10, 5, CAST(N'2023-01-02' AS Date), N'Parrot', 2, 30, 400, CAST(N'2024-01-01' AS Date), N'Africa', N'Male', N'Grey', N'Feathers', N'Intelligent and talkative parrot species', N'Feathered Friends', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (2, 1, 1, N'Macaw', N'https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Eopsaltria_australis_-_Mogo_Campground.jpg/640px-Eopsaltria_australis_-_Mogo_Campground.jpg', 800, 5, 4, CAST(N'2023-01-05' AS Date), N'Parrot', 1, 40, 500, CAST(N'2024-02-01' AS Date), N'South America', N'Female', N'Blue and Gold', N'Feathers', N'Colorful parrot species with a large beak', N'Tropical Aviaries', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (3, 2, 2, N'Yellow Canary', N'https://www.allaboutbirds.org/news/wp-content/uploads/2023/02/YRWarbler-Seitz-143912041-1280x668.jpg', 100, 20, 4, CAST(N'2023-02-05' AS Date), N'Canary', 1, 15, 20, CAST(N'2024-03-01' AS Date), N'Europe', N'Male', N'Yellow', N'Feathers', N'Popular small songbird with a melodious voice', N'Singing Birds Inc.', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (4, 2, 3, N'Zebra Finch', N'https://images.unsplash.com/photo-1606567595334-d39972c85dbe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmlyZHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80', 50, 30, 4, CAST(N'2023-02-10' AS Date), N'Finch', 1, 10, 15, CAST(N'2024-04-01' AS Date), N'Australia', N'Male', N'White and Black', N'Feathers', N'Small and sociable finch species', N'Tiny Tweets', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (5, 1, 3, N'Cockatiel', N'https://static.scientificamerican.com/sciam/cache/file/268F292B-5DDD-4DB1-B5ABC6541A70ECDF_source.jpg', 200, 8, 3, CAST(N'2023-01-10' AS Date), N'Cockatiel', 1, 25, 150, CAST(N'2024-05-01' AS Date), N'Australia', N'Female', N'Grey', N'Feathers', N'Friendly and playful parrot species', N'Cocka-Doodle Aviary', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (6, 1, 2, N'Peach-faced Lovebird', N'https://images.twinkl.co.uk/tw1n/image/private/t_630/u/ux/chafinch-flying-flight-bird-animal-ks1_ver_1.png', 150, 12, 4, CAST(N'2023-01-15' AS Date), N'Lovebird', 1, 20, 100, CAST(N'2024-06-01' AS Date), N'South America', N'Male', N'Peach-faced', N'Feathers', N'Colorful and affectionate small parrot species', N'Lovely Birds Ltd.', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (7, 1, 1, N'Amazon Parrot', N'https://media.newyorker.com/photos/5a95a5b13d9089123c9fdb7e/1:1/w_3289,h_3289,c_limit/Petrusich-Dont-Mess-with-the-Birds.jpg', 600, 7, 4, CAST(N'2023-01-08' AS Date), N'Parrot', 3, 35, 450, CAST(N'2024-08-01' AS Date), N'South America', N'Female', N'Green', N'Feathers', N'Medium-sized parrot known for its talking ability', N'Tropical Birds Inc.', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (8, 1, 1, N'Cockatoo', N'https://customsitesmedia.usc.edu/wp-content/uploads/sites/59/2019/11/16024710/Taiwan-Blue-Magpie-web-824x549.jpg', 1000, 3, 5, CAST(N'2023-01-12' AS Date), N'Parrot', 1, 45, 800, CAST(N'2024-09-01' AS Date), N'Australia', N'Male', N'White', N'Feathers', N'Large and intelligent parrot species with a crest', N'Exotic Aviaries', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (9, 2, 2, N'Red Factor Canary', N'https://birdnet.cornell.edu/files/2022/03/kingfisher.jpg', 120, 15, 3, CAST(N'2023-02-12' AS Date), N'Canary', 1, 16, 25, CAST(N'2024-10-01' AS Date), N'Europe', N'Female', N'Red', N'Feathers', N'Canary breed known for its red plumage coloration', N'Colorful Chirps', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (10, 2, 3, N'Gouldian Finch', N'https://static.scientificamerican.com/sciam/cache/file/7A715AD8-449D-4B5A-ABA2C5D92D9B5A21_source.png', 80, 25, 4, CAST(N'2023-02-15' AS Date), N'Finch', 1, 12, 18, CAST(N'2024-11-01' AS Date), N'Australia', N'Male', N'Multi-colored', N'Feathers', N'Small finch species with vibrant plumage colors', N'Rainbow Aviaries', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (11, 1, 1, N'White-faced Cockatiel', N'https://news.stanford.edu/wp-content/uploads/2020/10/Birds_Culture-1-copy.jpg', 180, 5, 4, CAST(N'2023-01-18' AS Date), N'Cockatiel', 1, 23, 140, CAST(N'2024-12-01' AS Date), N'Australia', N'Female', N'White', N'Feathers', N'Cockatiel mutation with a white face and crest', N'Feathery Companions', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (12, 1, 2, N'Masked Lovebird', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxSIiJCY_64k1ZMbrWS2FTqxYBHHZybN5BAw&usqp=CAU', 130, 8, 4, CAST(N'2023-01-25' AS Date), N'Lovebird', 1, 17, 95, CAST(N'2025-01-01' AS Date), N'Africa', N'Male', N'Yellow', N'Feathers', N'Lovebird species with a mask-like marking on its face', N'Sweet Tweets', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (13, 1, 2, N'Black-cheeked Lovebird', N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', 140, 6, 4, CAST(N'2023-01-30' AS Date), N'Lovebird', 1, 19, 110, CAST(N'2025-02-01' AS Date), N'Africa', N'Female', N'Green', N'Feathers', N'Lovebird species with black markings on its cheeks', N'Lovey Dovey Aviaries', N'ACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (14, 1, 1, N'Black-cheeked Lovebird', N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', 140, 6, 0, CAST(N'2023-01-30' AS Date), N'Lovebird', 1, 19, 110, CAST(N'2025-02-01' AS Date), N'Vietnam', N'Male', N'Red', N'Feathers', N'Lovebird species with black markings on its cheeks', N'Lovey Dovey Aviaries', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (15, 1, 1, N'Black-cheeked Lovebird', N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', 140, 6, 0, CAST(N'2023-01-30' AS Date), N'Lovebird', 1, 19, 110, CAST(N'2025-02-01' AS Date), N'Vietnam', N'Male', N'Red', N'Feathers', N'Lovebird species with black markings on its cheeks', N'Lovey Dovey Aviaries', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (18, 1, 1, N'White-faced Cockatiel', N'https://news.stanford.edu/wp-content/uploads/2020/10/Birds_Culture-1-copy.jpg', 180, 5, 0, CAST(N'2023-01-18' AS Date), N'Cockatiel', 1, 23, 140, CAST(N'2024-12-01' AS Date), N'Australia', N'Female', N'White', N'Feathers', N'Cockatiel mutation with a white face and crest', N'Feathery Companions', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (19, 1, 1, N'African Grey Parrot', N'https://res.cloudinary.com/dk-find-out/image/upload/q_80,w_960,f_auto/DCTM_Penguin_UK_DK_AL526630_wkmzns.jpg', 500, 10, 0, CAST(N'2023-01-02' AS Date), N'Parrot', 2, 30, 400, CAST(N'2024-01-01' AS Date), N'Africa', N'Male', N'Grey', N'Feathers', N'Intelligent and talkative parrot species', N'Feathered Friends', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (20, 1, 1, N'Macaw', N'https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Eopsaltria_australis_-_Mogo_Campground.jpg/640px-Eopsaltria_australis_-_Mogo_Campground.jpg', 800, 5, 0, CAST(N'2023-01-05' AS Date), N'Parrot', 1, 40, 500, CAST(N'2024-02-01' AS Date), N'South America', N'Female', N'Blue and Gold', N'Feathers', N'Colorful parrot species with a large beak', N'Tropical Aviaries', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (21, 2, 2, N'Yellow Canary', N'https://www.allaboutbirds.org/news/wp-content/uploads/2023/02/YRWarbler-Seitz-143912041-1280x668.jpg', 100, 20, 0, CAST(N'2023-02-05' AS Date), N'Canary', 1, 15, 20, CAST(N'2024-03-01' AS Date), N'Europe', N'Male', N'Yellow', N'Feathers', N'Popular small songbird with a melodious voice', N'Singing Birds Inc.', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (22, 2, 3, N'Zebra Finch', N'https://images.unsplash.com/photo-1606567595334-d39972c85dbe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmlyZHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80', 50, 30, 0, CAST(N'2023-02-10' AS Date), N'Finch', 1, 10, 15, CAST(N'2024-04-01' AS Date), N'Australia', N'Male', N'White and Black', N'Feathers', N'Small and sociable finch species', N'Tiny Tweets', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (23, 1, 3, N'Cockatiel', N'https://static.scientificamerican.com/sciam/cache/file/268F292B-5DDD-4DB1-B5ABC6541A70ECDF_source.jpg', 200, 8, 0, CAST(N'2023-01-10' AS Date), N'Cockatiel', 1, 25, 150, CAST(N'2024-05-01' AS Date), N'Australia', N'Female', N'Grey', N'Feathers', N'Friendly and playful parrot species', N'Cocka-Doodle Aviary', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (24, 1, 2, N'Peach-faced Lovebird', N'https://images.twinkl.co.uk/tw1n/image/private/t_630/u/ux/chafinch-flying-flight-bird-animal-ks1_ver_1.png', 150, 12, 0, CAST(N'2023-01-15' AS Date), N'Lovebird', 1, 20, 100, CAST(N'2024-06-01' AS Date), N'South America', N'Male', N'Peach-faced', N'Feathers', N'Colorful and affectionate small parrot species', N'Lovely Birds Ltd.', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (25, 1, 1, N'Amazon Parrot', N'https://media.newyorker.com/photos/5a95a5b13d9089123c9fdb7e/1:1/w_3289,h_3289,c_limit/Petrusich-Dont-Mess-with-the-Birds.jpg', 600, 7, 0, CAST(N'2023-01-08' AS Date), N'Parrot', 3, 35, 450, CAST(N'2024-08-01' AS Date), N'South America', N'Female', N'Green', N'Feathers', N'Medium-sized parrot known for its talking ability', N'Tropical Birds Inc.', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (26, 1, 1, N'Cockatoo', N'https://customsitesmedia.usc.edu/wp-content/uploads/sites/59/2019/11/16024710/Taiwan-Blue-Magpie-web-824x549.jpg', 1000, 3, 0, CAST(N'2023-01-12' AS Date), N'Parrot', 1, 45, 800, CAST(N'2024-09-01' AS Date), N'Australia', N'Male', N'White', N'Feathers', N'Large and intelligent parrot species with a crest', N'Exotic Aviaries', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (27, 2, 2, N'Red Factor Canary', N'https://birdnet.cornell.edu/files/2022/03/kingfisher.jpg', 120, 15, 0, CAST(N'2023-02-12' AS Date), N'Canary', 1, 16, 25, CAST(N'2024-10-01' AS Date), N'Europe', N'Female', N'Red', N'Feathers', N'Canary breed known for its red plumage coloration', N'Colorful Chirps', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (28, 2, 3, N'Gouldian Finch', N'https://static.scientificamerican.com/sciam/cache/file/7A715AD8-449D-4B5A-ABA2C5D92D9B5A21_source.png', 80, 25, 0, CAST(N'2023-02-15' AS Date), N'Finch', 1, 12, 18, CAST(N'2024-11-01' AS Date), N'Australia', N'Male', N'Multi-colored', N'Feathers', N'Small finch species with vibrant plumage colors', N'Rainbow Aviaries', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (29, 1, 1, N'White-faced Cockatiel', N'https://news.stanford.edu/wp-content/uploads/2020/10/Birds_Culture-1-copy.jpg', 180, 5, 0, CAST(N'2023-01-18' AS Date), N'Cockatiel', 1, 23, 140, CAST(N'2024-12-01' AS Date), N'Australia', N'Female', N'White', N'Feathers', N'Cockatiel mutation with a white face and crest', N'Feathery Companions', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (30, 1, 2, N'Masked Lovebird', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxSIiJCY_64k1ZMbrWS2FTqxYBHHZybN5BAw&usqp=CAU', 130, 8, 0, CAST(N'2023-01-25' AS Date), N'Lovebird', 1, 17, 95, CAST(N'2025-01-01' AS Date), N'Africa', N'Male', N'Yellow', N'Feathers', N'Lovebird species with a mask-like marking on its face', N'Sweet Tweets', N'INACTIVE')
INSERT [dbo].[Product] ([ProductId], [ShopId], [CategoryId], [ProductName], [ProductImage], [UnitPrice], [Quantity], [Rating], [CreateDate], [Species], [Age], [Size], [Weight], [Expiration], [MadeIn], [Gender], [Color], [Material], [Description], [BrandName], [Status]) VALUES (31, 1, 2, N'Black-cheeked Lovebird', N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', 140, 6, 0, CAST(N'2023-01-30' AS Date), N'Lovebird', 1, 19, 110, CAST(N'2025-02-01' AS Date), N'Africa', N'Female', N'Green', N'Feathers', N'Lovebird species with black markings on its cheeks', N'Lovey Dovey Aviaries', N'INACTIVE')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImage] ON 

INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (1, 1, N'https://media.newyorker.com/photos/5a95a5b13d9089123c9fdb7e/1:1/w_3289,h_3289,c_limit/Petrusich-Dont-Mess-with-the-Birds.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (2, 1, N'https://images.unsplash.com/photo-1606567595334-d39972c85dbe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmlyZHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (3, 1, N'https://customsitesmedia.usc.edu/wp-content/uploads/sites/59/2019/11/16024710/Taiwan-Blue-Magpie-web-824x549.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (4, 1, N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (5, 1, N'https://www.example.com/african_grey_5.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (6, 2, N'https://media.newyorker.com/photos/5a95a5b13d9089123c9fdb7e/1:1/w_3289,h_3289,c_limit/Petrusich-Dont-Mess-with-the-Birds.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (7, 2, N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (8, 2, N'https://customsitesmedia.usc.edu/wp-content/uploads/sites/59/2019/11/16024710/Taiwan-Blue-Magpie-web-824x549.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (9, 2, N'https://news.stanford.edu/wp-content/uploads/2020/10/Birds_Culture-1-copy.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (10, 3, N'https://media.newyorker.com/photos/5a95a5b13d9089123c9fdb7e/1:1/w_3289,h_3289,c_limit/Petrusich-Dont-Mess-with-the-Birds.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (11, 3, N'https://images.unsplash.com/photo-1606567595334-d39972c85dbe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmlyZHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (12, 3, N'https://www.example.com/yellow_canary_3.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (13, 4, N'https://www.example.com/zebra_finch_1.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (14, 4, N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (15, 4, N'https://www.example.com/zebra_finch_3.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (16, 5, N'https://www.example.com/cockatiel_1.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (17, 5, N'https://images.unsplash.com/photo-1606567595334-d39972c85dbe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmlyZHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (18, 6, N'https://media.newyorker.com/photos/5a95a5b13d9089123c9fdb7e/1:1/w_3289,h_3289,c_limit/Petrusich-Dont-Mess-with-the-Birds.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (19, 6, N'https://customsitesmedia.usc.edu/wp-content/uploads/sites/59/2019/11/16024710/Taiwan-Blue-Magpie-web-824x549.jpg', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (20, 6, N'https://natureconservancy-h.assetsadobe.com/is/image/content/dam/tnc/nature/en/photos/a/m/AmericanGoldfinch_MattWilliams_4000x2200.jpg?crop=0%2C0%2C4000%2C2200&wid=4000&hei=2200&scl=1.0', N'ACTIVE')
INSERT [dbo].[ProductImage] ([ProductImageId], [ProductId], [ImageUrl], [Status]) VALUES (21, 6, N'https://images.unsplash.com/photo-1606567595334-d39972c85dbe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YmlyZHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80', N'ACTIVE')
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
GO
SET IDENTITY_INSERT [dbo].[Shop] ON 

INSERT [dbo].[Shop] ([ShopId], [AccountId], [ShopName], [Address], [AvatarUrl], [CreateDate], [Status]) VALUES (1, 3, N'Shop 1', N'123 Main Street, Cityville', N'https://example.com/avatar1.jpg', CAST(N'2023-01-01' AS Date), N'ACTIVE')
INSERT [dbo].[Shop] ([ShopId], [AccountId], [ShopName], [Address], [AvatarUrl], [CreateDate], [Status]) VALUES (2, 5, N'Shop 2', N'456 Elm Street, Townsville', N'https://example.com/avatar2.jpg', CAST(N'2023-02-01' AS Date), N'ACTIVE')
INSERT [dbo].[Shop] ([ShopId], [AccountId], [ShopName], [Address], [AvatarUrl], [CreateDate], [Status]) VALUES (4, NULL, N'Shop 1', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Shop] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [AccountId], [FullName], [Email], [DOB], [Gender], [CreateDate], [AvatarUrl], [Status], [Address]) VALUES (1, 1, N'User 1', N'user1st@gmail.com', CAST(N'2001-12-12' AS Date), N'male', CAST(N'2020-05-13' AS Date), N'https://example.com/avatar1.jpg', N'ACTIVE', N'HCM')
INSERT [dbo].[User] ([UserId], [AccountId], [FullName], [Email], [DOB], [Gender], [CreateDate], [AvatarUrl], [Status], [Address]) VALUES (2, 2, N'User 2', N'user2nd@gmail.com', CAST(N'2000-01-01' AS Date), N'female', CAST(N'2022-06-30' AS Date), N'https://example.com/avatar2.jpg', N'ACTIVE', N'BH')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([OrderShopId])
REFERENCES [dbo].[OrderShop] ([OrderShopId])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderShop]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderShop]  WITH CHECK ADD FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([ShopId])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([ShopId])
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
USE [master]
GO
ALTER DATABASE [BirdTradingPlatform] SET  READ_WRITE 
GO
