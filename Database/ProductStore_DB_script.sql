USE [ProductStores]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Units]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitCode] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](200) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Price] [money] NULL,
	[Currency] [nvarchar](5) NULL,
	[UnitId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

GO
INSERT [dbo].[Category] ([CategoryId], [Name], [Description]) VALUES (1, N'Category 1', N'Desccriotion')
GO
INSERT [dbo].[Category] ([CategoryId], [Name], [Description]) VALUES (2, N'Category 2', N'Desc')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO

SET IDENTITY_INSERT [dbo].[Units] ON 
GO
INSERT [dbo].[Units] ([UnitId], [UnitCode], [Description]) VALUES (1, N'Per KG', N'Unit per KG')
GO
INSERT [dbo].[Units] ([UnitId], [UnitCode], [Description]) VALUES (2, N'Per Unit', N'Product unit per Quantity')
GO
INSERT [dbo].[Units] ([UnitId], [UnitCode], [Description]) VALUES (3, N'Per Gram', N'Product unit per gram')
GO
SET IDENTITY_INSERT [dbo].[Units] OFF
GO

SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [Currency], [UnitId]) VALUES (1, N'Product1', 1, 12.0000, N'INR', 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [Currency], [UnitId]) VALUES (2, N'Product 2', 2, 23.0000, N'INR', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [Currency], [UnitId]) VALUES (4, N'Prod 4', 2, 22.0000, N'USD', 3)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Units] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([UnitId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Units]
GO
/****** Object:  StoredProcedure [dbo].[ProductSearch]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Sagar Kute
-- Create date(DD/MM/YYYY): 19/12/2019
-- Description:	To save the product.
-- EXEC ProductSearch @CategoryId = -1
-- =============================================
CREATE PROCEDURE [dbo].[ProductSearch]
	@ProductName NVARCHAR(200) = NULL
	,@CategoryId INT = NULL
	,@CategoryName NVARCHAR(200) = NULL
	,@UnitId INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(ISNULL(@ProductName,'') = '')
		SET @ProductName = NULL
		
	IF(ISNULL(@CategoryName,'') = '')
		SET @CategoryName = NULL

	IF @CategoryId = -1
		SET @CategoryId = NULL

	IF @UnitId = -1
		SET @UnitId = NULL

	SELECT
		p.ProductId 'ProductId'
		, p.ProductName 'ProductName'
		, c.CategoryId 'CategoryId'
		, c.Name 'Category'
		, p.Price 'Price'
		, p.Currency 'Currency'
		, u.UnitId 'UnitId'
		, u.UnitCode 'Unit'
	FROM 
		[dbo].[Product] AS p (NOLOCK)
		INNER JOIN [dbo].[Category] AS c (NOLOCK) ON c.CategoryID = p.CategoryId
		INNER JOIN [dbo].[Units] AS u (NOLOCK) ON u.UnitId = p.UnitId
	WHERE
		(ProductName = @ProductName OR @ProductName IS NULL)
		AND (p.CategoryId = @CategoryId OR @CategoryId IS NULL)
		AND (c.Name = @CategoryName OR @CategoryName IS NULL)
		AND (p.UnitId = @UnitId OR @UnitId IS NULL)

END

GO
/****** Object:  StoredProcedure [dbo].[SaveCategory]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Sagar Kute
-- Create date(DD/MM/YYYY): 19/12/2019
-- Description:	To save the category of the product.
-- Insert
-- EXEC SaveCategory @CategoryID = NULL, @Name='Cat1', @Description='Test1'
-- Update
-- EXEC SaveCategory @CategoryID = 1, @Name='Cat1', @Description='Test1 added'
-- =============================================
CREATE PROCEDURE [dbo].[SaveCategory]
	@CategoryID INT = NULL,
	@Name NVARCHAR(200), 
	@Description NVARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION 
		IF (ISNULL(@CategoryID, 0) = 0 AND NOT EXISTS( SELECT 1 FROM [dbo].[Category] WHERE CategoryID = @CategoryID))
		BEGIN
			INSERT INTO [dbo].[Category]
			(
				Name,
				[Description]
			)
			VALUES
			(
				@Name,
				@Description
			)
		END
		ELSE IF (ISNULL(@CategoryID, 0) <> 0 AND EXISTS( SELECT 1 FROM [dbo].[Category] WHERE CategoryID = @CategoryID)) 
		BEGIN 
			UPDATE [dbo].[Category]
			SET Name = @Name
				, [Description] = @Description
			WHERE CategoryID = @CategoryID
		END
	
	IF (@@error != 0)
	BEGIN
		ROLLBACK
		PRINT'Transaction rolled back'
	END
	ELSE
	BEGIN
		COMMIT
		PRINT'Transaction committed'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveProduct]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Sagar Kute
-- Create date(DD/MM/YYYY): 19/12/2019
-- Description:	To save the product.
-- Insert
-- EXEC SaveProduct @ProductName = 'Product2', @CategoryId = 1, @Price= 20.99, @Currency = 'INR', @UnitId = 2
-- Update
-- EXEC SaveProduct @ProductId = 1, @ProductName = 'Product1', @CategoryId = 1, @Price= 12.99, @Currency = 'INR', @UnitId = 1
-- =============================================
CREATE PROCEDURE [dbo].[SaveProduct]
	@ProductId INT = 0
	,@ProductName NVARCHAR(200)
	,@CategoryId INT
	,@Price MONEY
	,@Currency NVARCHAR(20)
	,@UnitId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRANSACTION 
		IF (ISNULL(@ProductId, 0) = 0 AND NOT EXISTS( SELECT 1 FROM [dbo].[Product] WHERE ProductId = @ProductId))
		BEGIN
			INSERT INTO [dbo].[Product]
			(
				ProductName
				,CategoryId
				,Price
				,Currency
				,UnitId
			)
			VALUES
			(
				@ProductName
				,@CategoryId
				,@Price
				,@Currency
				,@UnitId
			)
		END
		ELSE IF (ISNULL(@ProductId, 0) <> 0 AND EXISTS( SELECT 1 FROM [dbo].[Product] WHERE ProductId = @ProductId))
		BEGIN
			UPDATE [dbo].[Product]
			SET ProductName	= @ProductName
				,CategoryId	= @CategoryId
				,Price		= @Price
				,Currency	= @Currency
				,UnitId		= @UnitId
			WHERE ProductId = @ProductId 
		END

	IF (@@error != 0)
	BEGIN
		ROLLBACK
		PRINT'Transaction rolled back'
	END
	ELSE
	BEGIN
		COMMIT
		PRINT'Transaction committed'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveUnit]    Script Date: 12/29/2019 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Sagar Kute
-- Create date(DD/MM/YYYY): 19/12/2019
-- Description:	To save units to be measure.
-- =============================================
CREATE PROCEDURE [dbo].[SaveUnit]
	@UnitCode NVARCHAR(100), 
	@Description NVARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Units]
	(
		UnitCode,
		[Description]
	)
	VALUES
    (
		@UnitCode,
		@Description
	)
END

GO
USE [master]
GO
ALTER DATABASE [ProductStores] SET  READ_WRITE 
GO
