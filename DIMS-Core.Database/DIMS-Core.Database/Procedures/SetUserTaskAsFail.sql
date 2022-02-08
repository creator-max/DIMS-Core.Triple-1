CREATE PROCEDURE [SetUserTaskAsFail]
	@UserId int,
	@TaskId int
AS
	UPDATE [UserTasks] SET [UserTasks].StateId=3 WHERE [UserTasks].TaskId = @TaskId AND [UserTasks].UserId = @UserId
RETURN 0