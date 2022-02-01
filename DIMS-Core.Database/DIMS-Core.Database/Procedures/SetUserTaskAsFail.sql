CREATE PROCEDURE [SetUserTaskAsFail]
	@UserId int,
	@TaskId int
AS
	UPDATE [UserTask] SET [UserTask].StateId=3 WHERE [UserTask].TaskId = @TaskId AND [UserTask].UserId = @UserId
RETURN 0