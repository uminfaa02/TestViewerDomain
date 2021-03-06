USE [master]
GO
/****** Object:  Database [TestViewerDB]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Administrator]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Answer]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Applications]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationName] [nvarchar](235) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[CandidateTest]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Choice]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Memberships]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowsStart] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Profiles]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](4000) NOT NULL,
	[PropertyValueStrings] [nvarchar](4000) NOT NULL,
	[PropertyValueBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TemplateQuestion]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[TestInstance]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[TestState]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[TestTemplate]    Script Date: 30/05/2013 11:17:57 AM ******/
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
/****** Object:  Table [dbo].[TestViewer]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestViewer](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DevelopedBy] [varchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[EmailPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TestViewer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 30/05/2013 11:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Administrator] ([Id], [LastName], [GivenName]) VALUES (N'ac513d6c-c0f9-4c10-a538-85a6c38d6052', N'Ileto', N'George')
INSERT [dbo].[Applications] ([ApplicationName], [ApplicationId], [Description]) VALUES (N'/', N'f2d06886-995e-49a9-a133-e72b25d4b339', NULL)
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'33ad98e9-478c-4c89-88fe-928a7b2275e0', N'1111111111')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'f0369426-4af5-42b9-92e5-50109eb0e594', N'1234567890')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'f5d4f2a8-3ca9-4d51-8a52-af7679129530', N'2222222222')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'ece04955-778d-4d44-ad4c-c8899f71ff4e', N'3333333333')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'19f64170-162c-458c-8796-9c7d33080ea9', N'4444444444')
INSERT [dbo].[Candidate] ([Id], [StudentNumber]) VALUES (N'4004a0ce-d9d4-4841-a572-a6f5b76814a7', N'5555555555')
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'ff46fd23-609c-4d07-b26d-01488ef5dcfb', N'0e8b57a3-40ba-467e-92a2-086ccae9f69b', N'19f64170-162c-458c-8796-9c7d33080ea9', 2, CAST(0x0000A1C6011C42B0 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'56169d30-1314-4725-a27b-2e6983a0a789', N'0e8b57a3-40ba-467e-92a2-086ccae9f69b', N'4004a0ce-d9d4-4841-a572-a6f5b76814a7', 2, CAST(0x0000A1C6011C42B1 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'ed8f80c9-d9ac-459c-ae4c-2fcb0e0e9fc6', N'0e8b57a3-40ba-467e-92a2-086ccae9f69b', N'33ad98e9-478c-4c89-88fe-928a7b2275e0', 2, CAST(0x0000A1C6011C42AF AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'2b1f9c2f-6d7c-4461-9a1a-958f53825891', N'0e8b57a3-40ba-467e-92a2-086ccae9f69b', N'ece04955-778d-4d44-ad4c-c8899f71ff4e', 2, CAST(0x0000A1C6011C42B4 AS DateTime), 0)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'957cea6f-c464-43f1-bf21-9f4e141d7e5f', N'01686006-d37f-4556-9314-f10c82a27092', N'33ad98e9-478c-4c89-88fe-928a7b2275e0', 1, CAST(0x0000A1CE00B87253 AS DateTime), 1)
INSERT [dbo].[CandidateTest] ([Id], [TestInstanceId], [CandidateId], [StateId], [DateTime], [IsPractice]) VALUES (N'a6700e4f-e048-4aa0-b8a1-b0afa1ea13b8', N'0e8b57a3-40ba-467e-92a2-086ccae9f69b', N'f5d4f2a8-3ca9-4d51-8a52-af7679129530', 2, CAST(0x0000A1C6011C42B2 AS DateTime), 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'179e6d89-2dfa-4544-8f7a-0eb659035bff', N'aaf04141-6d73-4067-b5a2-6c7aea071170', N'True', 1)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'6dc3e19d-4863-4b95-9139-485ee2d734f0', N'aaf04141-6d73-4067-b5a2-6c7aea071170', N'False', 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'742ead8f-4026-4889-9207-d0f7a869d453', N'd825602d-7390-4b09-a653-ca57a458c130', N'False', 1)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'8820ceb3-afb7-4c93-94af-e3e11d893043', N'de747da0-2365-4425-9205-fe2d0427dda2', N'False', 0)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'b298b470-c41f-47aa-aeaf-e8fc99056050', N'de747da0-2365-4425-9205-fe2d0427dda2', N'True', 1)
INSERT [dbo].[Choice] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (N'2ca891b8-b437-4dad-be73-ea313aa5156b', N'd825602d-7390-4b09-a653-ca57a458c130', N'True', 0)
INSERT [dbo].[Memberships] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) VALUES (N'f2d06886-995e-49a9-a133-e72b25d4b339', N'308e3493-7911-4f94-bb2d-5d01c249ffb4', N'mFWnTec/yJrD7COC3RQs9g5AGfRG7lXW1JZwKg1u27w=', 1, N'R1GKS/SsnmSj74YuYBXLMQ==', N'admin1@yahoo.com', NULL, NULL, 1, 0, CAST(0x0000A1C5005E4F3C AS DateTime), CAST(0x0000A1C5005E4F83 AS DateTime), CAST(0x0000A1C5005E4F3C AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[Memberships] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) VALUES (N'f2d06886-995e-49a9-a133-e72b25d4b339', N'ac513d6c-c0f9-4c10-a538-85a6c38d6052', N'UEXQ43gpJzvOoFgnf7d1PhhIiFDwekw3NWw6eC15RLQ=', 1, N'YsY4kEFqOf+/cfPmp7MgLw==', N'uminfaa02@gmail.com', NULL, NULL, 1, 0, CAST(0x0000A1C5001FA2F0 AS DateTime), CAST(0x0000A1C5001FA33C AS DateTime), CAST(0x0000A1C5001FA2F0 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'f0369426-4af5-42b9-92e5-50109eb0e594', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 0)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'ac513d6c-c0f9-4c10-a538-85a6c38d6052', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'33ad98e9-478c-4c89-88fe-928a7b2275e0', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'19f64170-162c-458c-8796-9c7d33080ea9', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'4004a0ce-d9d4-4841-a572-a6f5b76814a7', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'f5d4f2a8-3ca9-4d51-8a52-af7679129530', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Person] ([Id], [TestViewerId], [Active]) VALUES (N'ece04955-778d-4d44-ad4c-c8899f71ff4e', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', 1)
INSERT [dbo].[Question] ([Id], [QuestionBankId], [Text], [Active]) VALUES (N'aaf04141-6d73-4067-b5a2-6c7aea071170', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'A management information system can use data provided by a transaction processing system.', 1)
INSERT [dbo].[Question] ([Id], [QuestionBankId], [Text], [Active]) VALUES (N'd825602d-7390-4b09-a653-ca57a458c130', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'An information system must have computer hardware and software to be valid.', 1)
INSERT [dbo].[Question] ([Id], [QuestionBankId], [Text], [Active]) VALUES (N'de747da0-2365-4425-9205-fe2d0427dda2', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'An information system is an arrangement of people, data, processes, and information technology that interact to collect, process, store, and provide as output the information needed to support the organization.', 1)
INSERT [dbo].[QuestionBank] ([TestViewerId]) VALUES (N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
INSERT [dbo].[TemplateQuestion] ([TestTemplateId], [QuestionId]) VALUES (N'867075c7-4d62-4e71-96ef-9600477f6425', N'aaf04141-6d73-4067-b5a2-6c7aea071170')
INSERT [dbo].[TemplateQuestion] ([TestTemplateId], [QuestionId]) VALUES (N'867075c7-4d62-4e71-96ef-9600477f6425', N'd825602d-7390-4b09-a653-ca57a458c130')
INSERT [dbo].[TemplateQuestion] ([TestTemplateId], [QuestionId]) VALUES (N'867075c7-4d62-4e71-96ef-9600477f6425', N'de747da0-2365-4425-9205-fe2d0427dda2')
SET IDENTITY_INSERT [dbo].[TestInstance] ON 

INSERT [dbo].[TestInstance] ([Id], [TemplateId], [AdministeredBy], [TokenId], [IsPractice], [TimeLimit]) VALUES (N'0e8b57a3-40ba-467e-92a2-086ccae9f69b', N'867075c7-4d62-4e71-96ef-9600477f6425', N'ac513d6c-c0f9-4c10-a538-85a6c38d6052', 1001, 0, 50)
INSERT [dbo].[TestInstance] ([Id], [TemplateId], [AdministeredBy], [TokenId], [IsPractice], [TimeLimit]) VALUES (N'01686006-d37f-4556-9314-f10c82a27092', N'867075c7-4d62-4e71-96ef-9600477f6425', N'ac513d6c-c0f9-4c10-a538-85a6c38d6052', 1002, 1, 30)
SET IDENTITY_INSERT [dbo].[TestInstance] OFF
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (1, N'Scheduled')
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (2, N'Active')
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (3, N'In Progress')
INSERT [dbo].[TestState] ([Id], [Description]) VALUES (4, N'Closed')
INSERT [dbo].[TestTemplate] ([Id], [Name], [TestViewerId]) VALUES (N'867075c7-4d62-4e71-96ef-9600477f6425', N'SAD Chapter 1', N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2')
INSERT [dbo].[TestViewer] ([Id], [DevelopedBy], [Email], [EmailPassword]) VALUES (N'3ceb86d7-3cf8-4b5f-9f75-d908044a61a2', N'Us', N'testviewer02@gmail.com', N'sql_tafe')
INSERT [dbo].[Users] ([ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (N'f2d06886-995e-49a9-a133-e72b25d4b339', N'308e3493-7911-4f94-bb2d-5d01c249ffb4', N'admin1', 0, CAST(0x0000A1C5005E4F83 AS DateTime))
INSERT [dbo].[Users] ([ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (N'f2d06886-995e-49a9-a133-e72b25d4b339', N'ac513d6c-c0f9-4c10-a538-85a6c38d6052', N'admin', 0, CAST(0x0000A1C5001FA33C AS DateTime))
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Candidate]    Script Date: 30/05/2013 11:17:57 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Candidate] ON [dbo].[Candidate]
(
	[StudentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestInstance]    Script Date: 30/05/2013 11:17:57 AM ******/
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
ALTER TABLE [dbo].[Administrator]  WITH CHECK ADD  CONSTRAINT [FK_Administrator_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Administrator] CHECK CONSTRAINT [FK_Administrator_Users]
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
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipApplication]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipUser]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_TestViewer] FOREIGN KEY([TestViewerId])
REFERENCES [dbo].[TestViewer] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_TestViewer]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [UserProfile]
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
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [RoleApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [RoleApplication]
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
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UserApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserApplication]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleRole]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleUser]
GO
USE [master]
GO
ALTER DATABASE [TestViewerDB] SET  READ_WRITE 
GO
