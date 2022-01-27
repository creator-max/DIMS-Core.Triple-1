CREATE TABLE [dbo].[Samples]
(
    [SamplesId] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(50) NULL
    CONSTRAINT PK_SampleId PRIMARY KEY (SamplesId)
);