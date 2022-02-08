CREATE TABLE [dbo].[UserProfiles]
(
    [UserId] INT NOT NULL IDENTITY(1,1),
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [DirectionId] INT NOT NULL,
    [Education] NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(120) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [StartDate] DATE NOT NULL,
    [UniversityAverageScore] FLOAT NOT NULL,
    [MathScore] FLOAT NOT NULL,
    [Sex] TINYINT NOT NULL,
    [Skype] NVARCHAR(50) NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [MobilePhone] NVARCHAR(50) NOT NULL,

    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED([UserId] ASC),
    CONSTRAINT [FK_UserProfiles_Directions] FOREIGN KEY([DirectionId]) REFERENCES [Directions]([DirectionId]) ON DELETE CASCADE ON UPDATE CASCADE
)
