--_____________________________________________________
/*
	Creation Date	:	September 12, 2019
	Author			:	Marco Vasquez
	Company			:	
	Description		:	Creation - Log Table 
*/
--_____________________________________________________

IF OBJECT_ID('dbo.Log', 'U') IS NOT NULL
DROP TABLE [dbo].[Log];
GO

CREATE TABLE [dbo].[Log] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME        NOT NULL DEFAULT GETUTCDATE(),    
    [Level]     NVARCHAR (50)   NOT NULL,
    [Message]   NVARCHAR (MAX)  NOT NULL
);

