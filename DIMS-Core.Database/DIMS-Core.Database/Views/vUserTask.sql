CREATE VIEW [vUserTask]
AS SELECT [UserTask].UserId, [UserTask].TaskId, [Task].Name AS TaskName,
		  [Task].Description AS Descriptions,
		  [Task].StartDate, [Task].DeadlineDate, [TaskState].StateName
FROM	[Task] INNER JOIN
		[UserTask] ON [Task].TaskId = [UserTask].UserTaskId INNER JOIN
		[TaskState] ON [UserTask].StateId = [TaskState].StateId