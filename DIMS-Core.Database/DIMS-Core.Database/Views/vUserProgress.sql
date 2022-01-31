CREATE VIEW [dbo].[vUserProgress]
AS
SELECT [UserTasks].UserId,
       [UserTasks].TaskId,
       [TaskTracks].TaskTrackId, 
       [UserProfiles].FirstName + ' ' + [UserProfiles].LastName AS UserName,
       [Tasks].Name AS TaskName,
       [TaskTracks].TrackNote,
       [TaskTracks].TrackDate
FROM [UserTasks]
INNER JOIN [Tasks] ON [UserTasks].TaskId = [Tasks].TaskId
INNER JOIN [UserProfiles] ON [UserTasks].UserId = [UserProfiles].UserId
INNER JOIN [TaskTracks] ON [UserTasks].UserTaskId = [TaskTracks].UserTaskId
