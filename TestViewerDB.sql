USE [master]
GO
/****** Object:  Database [TestViewerDB]    Script Date: 9/05/2013 5:19:04 PM ******/
CREATE DATABASE [TestViewerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestViewerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TestViewerDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestViewerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TestViewerDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestViewerDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestViewerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestViewerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestViewerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestViewerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestViewerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestViewerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestViewerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestViewerDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestViewerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestViewerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestViewerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestViewerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestViewerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestViewerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestViewerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestViewerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestViewerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestViewerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestViewerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestViewerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestViewerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestViewerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestViewerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestViewerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestViewerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TestViewerDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestViewerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestViewerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestViewerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestViewerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestViewerDB', N'ON'
GO
USE [TestViewerDB]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[Id] [uniqueidentifier] NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[GivenName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ChoiceId] [uniqueidentifier] NOT NULL,
	[CandidateTestId] [uniqueidentifier] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Candidate](
	[Id] [uniqueidentifier] NOT NULL,
	[StudentNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CandidateTest]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateTest](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TestInstanceId] [uniqueidentifier] NOT NULL,
	[CandidateId] [uniqueidentifier] NOT NULL,
	[StateId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[IsPractice] [bit] NOT NULL,
 CONSTRAINT [PK_CandidateTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Choice]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Choice](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[IsCorrect] [bit] NOT NULL,
 CONSTRAINT [PK_Choice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TestViewerId] [uniqueidentifier] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[QuestionBankId] [uniqueidentifier] NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionBank](
	[TestViewerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_QuestionBank] PRIMARY KEY CLUSTERED 
(
	[TestViewerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TemplateQuestion]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemplateQuestion](
	[TestTemplateId] [uniqueidentifier] NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TemplateQuestion] PRIMARY KEY CLUSTERED 
(
	[TestTemplateId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestInstance]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestInstance](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TemplateId] [uniqueidentifier] NOT NULL,
	[AdministeredBy] [uniqueidentifier] NOT NULL,
	[TokenId] [int] IDENTITY(1000,1) NOT NULL,
	[IsPractice] [bit] NOT NULL,
	[TimeLimit] [int] NOT NULL,
 CONSTRAINT [PK_TestInstance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestState]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestState](
	[Id] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TestState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestTemplate]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTemplate](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TestViewerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TestTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestViewer]    Script Date: 9/05/2013 5:19:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestViewer](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DevelopedBy] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TestViewer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Administrator] ([Id], [LastName], [GivenName]) VALUES (N'c095c678-1828-41ed-91d0-1129105f5a3d', N'Ileto', N'George')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'cb71dfd1-1277-44a6-9777-7f65572a2257', N'123123123123')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'94384455-5f7b-43d3-b76b-c88290d55035', N'22215655')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'5349a21a-3ea9-496e-8d1e-f2fca852a0ee', N'345434545345')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'00000000-0000-0000-0000-000000000000', N'373300039')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'a3a2c9a0-3539-4226-95ca-691aa1a028ae', N'634523545345')
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'bf438627-7191-4ae4-8d6b-00ff658d0b1b', N'bc00a14f-94a3-4821-8a69-44beaaea671c', N'a3a2c9a0-3539-4226-95ca-691aa1a028ae', 1, CAST(0x0000A1B900AD4990 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'bb44ec20-8285-4009-a519-10365b17252f', N'bc00a14f-94a3-4821-8a69-44beaaea671c', N'94384455-5f7b-43d3-b76b-c88290d55035', 1, CAST(0x0000A1B900AD4989 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'a660cd8b-3c4f-4f6d-bba8-11767ec6a433', N'8fc3609d-a1a8-4610-b290-b95401758032', N'cb71dfd1-1277-44a6-9777-7f65572a2257', 1, CAST(0x0000A1B900A03615 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'b96c1e5f-7a3a-45dd-948f-11a919a0de7c', N'bc00a14f-94a3-4821-8a69-44beaaea671c', N'5349a21a-3ea9-496e-8d1e-f2fca852a0ee', 1, CAST(0x0000A1B900AD498A AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'7a142c3d-8864-44d7-bc89-33b48f3af1dc', N'bf10810f-9f81-4949-a9bd-1fb85075994c', N'cb71dfd1-1277-44a6-9777-7f65572a2257', 1, CAST(0x0000A1B900AC37E8 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'8869ecde-d566-4f88-85be-4fb1aaf41e6d', N'2d879eba-c5a9-4ae3-b1bf-958d182488c5', N'00000000-0000-0000-0000-000000000000', 1, CAST(0x0000A1B8013C2B51 AS DateTime), 1)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'7a532906-2e1b-4e60-bf7e-514a6383e1bf', N'2d879eba-c5a9-4ae3-b1bf-958d182488c5', N'5349a21a-3ea9-496e-8d1e-f2fca852a0ee', 1, CAST(0x0000A1B8013C2B4B AS DateTime), 1)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'2e9fba8b-5afd-4bc9-9c3c-54b43ac4dff0', N'8fc3609d-a1a8-4610-b290-b95401758032', N'5349a21a-3ea9-496e-8d1e-f2fca852a0ee', 1, CAST(0x0000A1B900A03617 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'd546f301-fc49-4d56-8b4a-587fb6503c3b', N'8fc3609d-a1a8-4610-b290-b95401758032', N'94384455-5f7b-43d3-b76b-c88290d55035', 1, CAST(0x0000A1B900A03616 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'd13715c6-8880-4de6-8e59-59ec90909e4c', N'bf10810f-9f81-4949-a9bd-1fb85075994c', N'a3a2c9a0-3539-4226-95ca-691aa1a028ae', 1, CAST(0x0000A1B900AC37F1 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'32ef0502-085e-4697-b4e7-83bcd204f20c', N'2d879eba-c5a9-4ae3-b1bf-958d182488c5', N'a3a2c9a0-3539-4226-95ca-691aa1a028ae', 1, CAST(0x0000A1B8013C2B52 AS DateTime), 1)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'1efef09a-317f-4fc9-b2cd-87900106515c', N'2d879eba-c5a9-4ae3-b1bf-958d182488c5', N'cb71dfd1-1277-44a6-9777-7f65572a2257', 1, CAST(0x0000A1B8013C2B49 AS DateTime), 1)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'4f0d844e-56d9-4df9-936a-9cc74e4b8de1', N'2d879eba-c5a9-4ae3-b1bf-958d182488c5', N'94384455-5f7b-43d3-b76b-c88290d55035', 1, CAST(0x0000A1B8013C2B4A AS DateTime), 1)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'2eed2e02-9e5a-44f3-b013-a14476deac0a', N'bc00a14f-94a3-4821-8a69-44beaaea671c', N'cb71dfd1-1277-44a6-9777-7f65572a2257', 1, CAST(0x0000A1B900AD4987 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'b734e08b-daa5-4161-bed9-ad3e10005b1b', N'bf10810f-9f81-4949-a9bd-1fb85075994c', N'00000000-0000-0000-0000-000000000000', 1, CAST(0x0000A1B900AC37EF AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'7f4da21d-324b-48c6-b5f5-b2b2f0ad685b', N'bc00a14f-94a3-4821-8a69-44beaaea671c', N'00000000-0000-0000-0000-000000000000', 1, CAST(0x0000A1B900AD498B AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'706da277-2175-41b8-9986-e0bb431054ad', N'8fc3609d-a1a8-4610-b290-b95401758032', N'00000000-0000-0000-0000-000000000000', 1, CAST(0x0000A1B900A03619 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'abb648fd-66a6-4653-9c04-e6bbbebef684', N'8fc3609d-a1a8-4610-b290-b95401758032', N'a3a2c9a0-3539-4226-95ca-691aa1a028ae', 1, CAST(0x0000A1B900A0361A AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'3da10fbb-ef50-4d8f-9433-ede15d30a545', N'bf10810f-9f81-4949-a9bd-1fb85075994c', N'94384455-5f7b-43d3-b76b-c88290d55035', 1, CAST(0x0000A1B900AC37EB AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'34e060c1-386f-4343-862a-eded563fe07c', N'bf10810f-9f81-4949-a9bd-1fb85075994c', N'5349a21a-3ea9-496e-8d1e-f2fca852a0ee', 1, CAST(0x0000A1B900AC37EC AS DateTime), 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'da6a2add-b0c4-40d1-8c27-16770c12dd6e', N'25473279-fc5d-4996-aade-fed0fa624b81', N'26 deg', 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'01536ef5-c51f-4e7c-87c2-3793efaba8ac', N'7dd4b958-f838-407a-9618-74ec7f83a951', N'26 deg', 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'2b9c0b36-3cae-4d9b-ae42-56cb1eba5378', N'928fcf8f-1253-409c-a6d4-e0e8884eceeb', N'Five', 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'13800aef-5eca-4f53-acb6-5e216e5be167', N'25473279-fc5d-4996-aade-fed0fa624b81', N'45.5 deg', 1)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'0a08c3c2-0342-4dd9-afae-b6f4cfbc29ff', N'25473279-fc5d-4996-aade-fed0fa624b81', N'25 deg', 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'aeb75416-657d-4cd5-81f7-c46464c4b071', N'7dd4b958-f838-407a-9618-74ec7f83a951', N'45.5 deg', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'00000000-0000-0000-0000-000000000000', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'c095c678-1828-41ed-91d0-1129105f5a3d', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'a3a2c9a0-3539-4226-95ca-691aa1a028ae', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'cb71dfd1-1277-44a6-9777-7f65572a2257', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'94384455-5f7b-43d3-b76b-c88290d55035', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 0)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'5349a21a-3ea9-496e-8d1e-f2fca852a0ee', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Question] ([Id], [QuestionBankId], [Text], [Active]) VALUES (N'7dd4b958-f838-407a-9618-74ec7f83a951', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'What is the temperature like tomorrow?', 1)
INSERT [dbo].[Question] ([Id], [QuestionBankId], [Text], [Active]) VALUES (N'928fcf8f-1253-409c-a6d4-e0e8884eceeb', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'What is the sum when you add 1 and 1?', 1)
INSERT [dbo].[Question] ([Id], [QuestionBankId], [Text], [Active]) VALUES (N'25473279-fc5d-4996-aade-fed0fa624b81', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'What''s your mood today?', 1)
INSERT [dbo].[QuestionBank] ([TestViewerId]) VALUES (N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
SET IDENTITY_INSERT [dbo].[TestInstance] ON 

INSERT [dbo].[TestInstance] ([Id], [TemplateId], [AdministeredBy], [TokenId], [IsPractice], [TimeLimit]) VALUES (N'bf10810f-9f81-4949-a9bd-1fb85075994c', N'68241242-c8e8-4d65-bd2b-074291b119e1', N'c095c678-1828-41ed-91d0-1129105f5a3d', 1007, 0, 30)
INSERT [dbo].[TestInstance] ([Id], [TemplateId], [AdministeredBy], [TokenId], [IsPractice], [TimeLimit]) VALUES (N'bc00a14f-94a3-4821-8a69-44beaaea671c', N'68241242-c8e8-4d65-bd2b-074291b119e1', N'c095c678-1828-41ed-91d0-1129105f5a3d', 1008, 0, 30)
INSERT [dbo].[TestInstance] ([Id], [TemplateId], [AdministeredBy], [TokenId], [IsPractice], [TimeLimit]) VALUES (N'2d879eba-c5a9-4ae3-b1bf-958d182488c5', N'7e45570d-bdf8-429c-8b9a-b2179e40535a', N'c095c678-1828-41ed-91d0-1129105f5a3d', 1005, 1, 40)
INSERT [dbo].[TestInstance] ([Id], [TemplateId], [AdministeredBy], [TokenId], [IsPractice], [TimeLimit]) VALUES (N'8fc3609d-a1a8-4610-b290-b95401758032', N'68241242-c8e8-4d65-bd2b-074291b119e1', N'c095c678-1828-41ed-91d0-1129105f5a3d', 1006, 0, 30)
SET IDENTITY_INSERT [dbo].[TestInstance] OFF
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (1, N'Scheduled')
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (2, N'Active')
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (3, N'Closed')
INSERT [dbo].[TestTemplate] ([Id], [Name], [TestViewerId]) VALUES (N'68241242-c8e8-4d65-bd2b-074291b119e1', N'TestTemplate for Instance Testing', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
INSERT [dbo].[TestTemplate] ([Id], [Name], [TestViewerId]) VALUES (N'e3604062-537e-4915-9488-5069496754d1', N'WE gotta change name!!', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
INSERT [dbo].[TestTemplate] ([Id], [Name], [TestViewerId]) VALUES (N'800e37fd-c7d2-48e0-bdd2-636f7af2dd4d', N'The Latest Template so far..', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
INSERT [dbo].[TestTemplate] ([Id], [Name], [TestViewerId]) VALUES (N'7e45570d-bdf8-429c-8b9a-b2179e40535a', N'Template 2', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
INSERT [dbo].[TestViewer] ([Id], [DevelopedBy]) VALUES (N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'Us')
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Candidate]    Script Date: 9/05/2013 5:19:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Candidate] ON [dbo].[Candidate]
(
	[StudentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestInstance]    Script Date: 9/05/2013 5:19:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestInstance] ON [dbo].[TestInstance]
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrator] ADD  CONSTRAINT [DF_Administrator_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [DF_Answer_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [DF_Answer_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[CandidateTest] ADD  CONSTRAINT [DF_CandidateTest_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[CandidateTest] ADD  CONSTRAINT [DF_CandidateTest_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[CandidateTest] ADD  CONSTRAINT [DF_CandidateTest_IsPractice_1]  DEFAULT ((1)) FOR [IsPractice]
GO
ALTER TABLE [dbo].[Choice] ADD  CONSTRAINT [DF_Choice_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF_Question_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF_Question_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[TestInstance] ADD  CONSTRAINT [DF_TestInstance_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[TestInstance] ADD  CONSTRAINT [DF_TestInstance_IsPractice]  DEFAULT ((1)) FOR [IsPractice]
GO
ALTER TABLE [dbo].[TestTemplate] ADD  CONSTRAINT [DF_TestTemplate_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[TestViewer] ADD  CONSTRAINT [DF_TestViewer_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Administrator]  WITH CHECK ADD  CONSTRAINT [FK_Administrator_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Administrator] CHECK CONSTRAINT [FK_Administrator_Person]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_CandidateTest] FOREIGN KEY([CandidateTestId])
REFERENCES [dbo].[CandidateTest] ([Id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_CandidateTest]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Choice] FOREIGN KEY([ChoiceId])
REFERENCES [dbo].[Choice] ([Id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Choice]
GO
ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD  CONSTRAINT [FK_Candidate_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Candidate] CHECK CONSTRAINT [FK_Candidate_Person]
GO
ALTER TABLE [dbo].[CandidateTest]  WITH CHECK ADD  CONSTRAINT [FK_CandidateTest_Candidate] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidate] ([Id])
GO
ALTER TABLE [dbo].[CandidateTest] CHECK CONSTRAINT [FK_CandidateTest_Candidate]
GO
ALTER TABLE [dbo].[CandidateTest]  WITH CHECK ADD  CONSTRAINT [FK_CandidateTest_TestInstance] FOREIGN KEY([TestInstanceId])
REFERENCES [dbo].[TestInstance] ([Id])
GO
ALTER TABLE [dbo].[CandidateTest] CHECK CONSTRAINT [FK_CandidateTest_TestInstance]
GO
ALTER TABLE [dbo].[CandidateTest]  WITH CHECK ADD  CONSTRAINT [FK_CandidateTest_TestState] FOREIGN KEY([StateId])
REFERENCES [dbo].[TestState] ([Id])
GO
ALTER TABLE [dbo].[CandidateTest] CHECK CONSTRAINT [FK_CandidateTest_TestState]
GO
ALTER TABLE [dbo].[Choice]  WITH CHECK ADD  CONSTRAINT [FK_Choice_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Choice] CHECK CONSTRAINT [FK_Choice_Question]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_TestViewer] FOREIGN KEY([TestViewerId])
REFERENCES [dbo].[TestViewer] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_TestViewer]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionBank] FOREIGN KEY([QuestionBankId])
REFERENCES [dbo].[QuestionBank] ([TestViewerId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionBank]
GO
ALTER TABLE [dbo].[QuestionBank]  WITH CHECK ADD  CONSTRAINT [FK_QuestionBank_TestViewer] FOREIGN KEY([TestViewerId])
REFERENCES [dbo].[TestViewer] ([Id])
GO
ALTER TABLE [dbo].[QuestionBank] CHECK CONSTRAINT [FK_QuestionBank_TestViewer]
GO
ALTER TABLE [dbo].[TemplateQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TemplateQuestion_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[TemplateQuestion] CHECK CONSTRAINT [FK_TemplateQuestion_Question]
GO
ALTER TABLE [dbo].[TemplateQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TemplateQuestion_TestTemplate] FOREIGN KEY([TestTemplateId])
REFERENCES [dbo].[TestTemplate] ([Id])
GO
ALTER TABLE [dbo].[TemplateQuestion] CHECK CONSTRAINT [FK_TemplateQuestion_TestTemplate]
GO
ALTER TABLE [dbo].[TestInstance]  WITH CHECK ADD  CONSTRAINT [FK_TestInstance_Administrator] FOREIGN KEY([AdministeredBy])
REFERENCES [dbo].[Administrator] ([Id])
GO
ALTER TABLE [dbo].[TestInstance] CHECK CONSTRAINT [FK_TestInstance_Administrator]
GO
ALTER TABLE [dbo].[TestInstance]  WITH CHECK ADD  CONSTRAINT [FK_TestInstance_TestTemplate] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[TestTemplate] ([Id])
GO
ALTER TABLE [dbo].[TestInstance] CHECK CONSTRAINT [FK_TestInstance_TestTemplate]
GO
ALTER TABLE [dbo].[TestTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TestTemplate_TestViewer] FOREIGN KEY([TestViewerId])
REFERENCES [dbo].[TestViewer] ([Id])
GO
ALTER TABLE [dbo].[TestTemplate] CHECK CONSTRAINT [FK_TestTemplate_TestViewer]
GO
USE [master]
GO
ALTER DATABASE [TestViewerDB] SET  READ_WRITE 
GO
