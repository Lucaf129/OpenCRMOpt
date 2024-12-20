USE [OptDB]
GO
/****** Object:  Table [dbo].[Lotti]    Script Date: 20/12/2024 16:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lotti](
	[LottoID] [bigint] IDENTITY(1,1) NOT NULL,
	[Modello] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Quantita] [int] NOT NULL,
 CONSTRAINT [PK_Lotti] PRIMARY KEY CLUSTERED 
(
	[LottoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Macchine]    Script Date: 20/12/2024 16:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Macchine](
	[MacchineID] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Macchine] PRIMARY KEY CLUSTERED 
(
	[MacchineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelliLotti]    Script Date: 20/12/2024 16:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelliLotti](
	[ModelloID] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](max) NOT NULL,
	[MacchineCompatibili] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_ModelliLotti] PRIMARY KEY CLUSTERED 
(
	[ModelloID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Lotti] ON 
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (1, 1, NULL, 200)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (2, 2, NULL, 500)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (3, 2, NULL, 350)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (4, 3, NULL, 800)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (5, 4, NULL, 600)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (6, 5, NULL, 700)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (7, 4, NULL, 400)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (8, 1, NULL, 800)
GO
INSERT [dbo].[Lotti] ([LottoID], [Modello], [Note], [Quantita]) VALUES (9, 4, NULL, 1200)
GO
SET IDENTITY_INSERT [dbo].[Lotti] OFF
GO
SET IDENTITY_INSERT [dbo].[Macchine] ON 
GO
INSERT [dbo].[Macchine] ([MacchineID], [Descrizione], [Name], [IP]) VALUES (1, N'Macchina 1', N'M1', N'10.100.100.1')
GO
INSERT [dbo].[Macchine] ([MacchineID], [Descrizione], [Name], [IP]) VALUES (2, N'Macchina 2', N'M2', N'10.100.100.2')
GO
INSERT [dbo].[Macchine] ([MacchineID], [Descrizione], [Name], [IP]) VALUES (3, N'Macchina 3 ', N'M3', N'10.100.100.3')
GO
INSERT [dbo].[Macchine] ([MacchineID], [Descrizione], [Name], [IP]) VALUES (4, N'Macchina 4', N'M4', N'10.100.100.4')
GO
INSERT [dbo].[Macchine] ([MacchineID], [Descrizione], [Name], [IP]) VALUES (5, N'Macchina 5', N'M5', N'10.100.100.5')
GO
SET IDENTITY_INSERT [dbo].[Macchine] OFF
GO
SET IDENTITY_INSERT [dbo].[ModelliLotti] ON 
GO
INSERT [dbo].[ModelliLotti] ([ModelloID], [Descrizione], [MacchineCompatibili]) VALUES (1, N'Modello A', N'1;0;0;1;0')
GO
INSERT [dbo].[ModelliLotti] ([ModelloID], [Descrizione], [MacchineCompatibili]) VALUES (2, N'Modello B', N'0;0;1;0;1')
GO
INSERT [dbo].[ModelliLotti] ([ModelloID], [Descrizione], [MacchineCompatibili]) VALUES (3, N'Modello C', N'0;1;0;0;0')
GO
INSERT [dbo].[ModelliLotti] ([ModelloID], [Descrizione], [MacchineCompatibili]) VALUES (4, N'Modello D', N'1;0;1;0;0')
GO
INSERT [dbo].[ModelliLotti] ([ModelloID], [Descrizione], [MacchineCompatibili]) VALUES (5, N'Modello E', N'0;0;0;1;0')
GO
INSERT [dbo].[ModelliLotti] ([ModelloID], [Descrizione], [MacchineCompatibili]) VALUES (6, N'Modello F', N'0;0;1;1;0')
GO
SET IDENTITY_INSERT [dbo].[ModelliLotti] OFF
GO
ALTER TABLE [dbo].[Lotti]  WITH CHECK ADD  CONSTRAINT [FK_Lotti_Modelli] FOREIGN KEY([Modello])
REFERENCES [dbo].[ModelliLotti] ([ModelloID])
GO
ALTER TABLE [dbo].[Lotti] CHECK CONSTRAINT [FK_Lotti_Modelli]
GO
