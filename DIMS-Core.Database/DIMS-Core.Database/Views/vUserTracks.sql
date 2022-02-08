CREATE VIEW [dbo].[vUserTracks]	
AS 
SELECT	[UserTasks].[UserId],
		[Tasks].[TaskId],
		[TaskTracks].[TaskTrackId],
		[Tasks].[Name] AS [TaskName],
		[TaskTracks].[TrackNote],
		[TaskTracks].[TrackDate]
FROM [Tasks]
	INNER JOIN [UserTasks]	ON [Tasks].[TaskId] = [UserTasks].[TaskId]
	INNER JOIN [TaskTracks] ON [UserTasks].[UserTaskId] = [TaskTracks].[UserTaskId]