USE [PK_2022_DB]
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 4/9/2023 5:04:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[refID_StateMst] [int] NULL,
	[CityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblState]    Script Date: 4/9/2023 5:04:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserRegistration]    Script Date: 4/9/2023 5:04:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[refID_StateMst] [int] NULL,
	[refID_CityMst] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblUserRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCity] ON 
GO
INSERT [dbo].[tblCity] ([Id], [refID_StateMst], [CityName]) VALUES (1, 1, N'Surat')
GO
INSERT [dbo].[tblCity] ([Id], [refID_StateMst], [CityName]) VALUES (2, 1, N'Bardoli')
GO
INSERT [dbo].[tblCity] ([Id], [refID_StateMst], [CityName]) VALUES (3, 1, N'Baroda')
GO
INSERT [dbo].[tblCity] ([Id], [refID_StateMst], [CityName]) VALUES (4, 2, N'Mumbai')
GO
INSERT [dbo].[tblCity] ([Id], [refID_StateMst], [CityName]) VALUES (5, 2, N'Pune')
GO
SET IDENTITY_INSERT [dbo].[tblCity] OFF
GO
SET IDENTITY_INSERT [dbo].[tblState] ON 
GO
INSERT [dbo].[tblState] ([Id], [StateName]) VALUES (1, N'Gujarat')
GO
INSERT [dbo].[tblState] ([Id], [StateName]) VALUES (2, N'Maharashtra')
GO
SET IDENTITY_INSERT [dbo].[tblState] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUserRegistration] ON 
GO
INSERT [dbo].[tblUserRegistration] ([Id], [refID_StateMst], [refID_CityMst], [Name], [Email], [Phone], [Address]) VALUES (2, 2, 5, N'Prakash', N'prakash@gmail.com', N'9979164836', N'ttt')
GO
INSERT [dbo].[tblUserRegistration] ([Id], [refID_StateMst], [refID_CityMst], [Name], [Email], [Phone], [Address]) VALUES (6, 1, 3, N'Dhanush Vasaikar', N'dhanush@gmail.com', N'7854632145', N'Test Surat')
GO
SET IDENTITY_INSERT [dbo].[tblUserRegistration] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrationInsertUpdate]    Script Date: 4/9/2023 5:04:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_RegistrationInsertUpdate]
	-- Add the parameters for the stored procedure here
	@paramId int=0,
	@paramRefID_StateMst int =0,
	@paramrefID_CityMst int =0,
	@paramName nvarchar(50),
	@paramEmail nvarchar(50),
	@paramPhone nvarchar(20),
	@paramAddress nvarchar(200)=''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if(@paramId=0)
	begin
    -- Insert statements for procedure here
		INSERT INTO [dbo].[tblUserRegistration] values(@paramRefID_StateMst,@paramrefID_CityMst,@paramName,@paramEmail,@paramPhone,@paramAddress)
		SELECT @paramId=SCOPE_IDENTITY();
	end
	else
	begin
		update [dbo].[tblUserRegistration] set refID_StateMst=@paramRefID_StateMst, refID_CityMst=@paramrefID_CityMst, Name=@paramName, Email=@paramEmail, Phone=@paramPhone, [Address]=@paramAddress 
		where Id=@paramId
	end

	select @paramId as Result
END
GO
