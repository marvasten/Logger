IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_AddLog')
DROP PROCEDURE usp_AddLog
GO

CREATE PROCEDURE dbo.usp_AddLog
(
    @pLevel NVARCHAR(50),
    @pMessage NVARCHAR(MAX)
)
--_____________________________________________________
/*
	Creation Date	:	September 12, 2019
	Author			:	Marco Vasquez
	Company			:	
	Description		:	Insert a log entry in the DB
	Example			:   usp_AddLog('INFO', 'Application started')
*/
--_____________________________________________________
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Log] ([Level], [Message])
	VALUES (@pLevel, @pMessage)


	SET NOCOUNT OFF;
END