CREATE TABLE [dbo].[TaskTracks]
(
	[TaskTrackId] INT IDENTITY(1,1) NOT NULL,
	[UserTaskId] INT NOT NULL,
	[TrackDate] DATE NOT NULL,
	[TrackNote] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_TaskTracks] PRIMARY KEY CLUSTERED([TaskTrackId] ASC),
	
	FOREIGN KEY([UserTaskId]) REFERENCES [dbo].[UserTasks]([UserTaskId])
)