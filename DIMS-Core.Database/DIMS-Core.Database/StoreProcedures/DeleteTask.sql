CREATE PROCEDURE [dbo].[DeleteTask]
	@taskId INT
AS DELETE FROM [Tasks] WHERE [TaskId] = @taskId