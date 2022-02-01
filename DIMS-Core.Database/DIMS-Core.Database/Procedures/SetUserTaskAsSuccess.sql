CREATE PROCEDURE [SetUserTaskAsSuccess]
	@UserId int,
	@TaskId int
AS 
	UPDATE [UserTask] SET [UserTask].StateId=2 WHERE [UserTask].TaskId = @TaskId AND [UserTask].UserId = @UserId
RETURN 0