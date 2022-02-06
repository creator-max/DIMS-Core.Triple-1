CREATE VIEW [vUserTask] AS 
SELECT [UserTasks].UserId, [UserTasks].TaskId, [Tasks].Name AS TaskName, 
	   [Tasks].Description AS Descriptions,
	   [Tasks].StartDate, [Tasks].DeadlineDate, [TaskStates].StateName
FROM [Tasks] INNER JOIN [UserTask] ON [Tasks].TaskId = [UserTasks].UserTaskId 
INNER JOIN [TaskStates] ON [UserTasks].StateId = [TaskStates].StateId