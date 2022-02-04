CREATE TABLE [dbo].[Tasks]
(
	[TaskId]       INT           NOT NULL IDENTITY(1, 1),
	[Name]         NVARCHAR(50)	 NOT NULL,
	[Description]  NVARCHAR(255) NOT NULL,
	[StartDate]	   DATETIME      NOT NULL,
	[DeadlineDate] DATETIME      NOT NULL,

	CONSTRAINT [PK_Tasks] PRIMARY KEY([TaskId])
)