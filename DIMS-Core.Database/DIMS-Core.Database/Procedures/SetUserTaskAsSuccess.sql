CREATE PROCEDURE [SetUserTaskAsSuccess]
	@UserId int,
	@TaskId int
AS 
	UPDATE [UserTasks] SET [UserTasks].StateId=2 WHERE [UserTasks].TaskId = @TaskId AND [UserTasks].UserId = @UserId
RETURN 0