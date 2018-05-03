CREATE TABLE [dbo].[Feedback]
(
	[ReviewId] INT NOT NULL PRIMARY KEY, 
    [Email] VARCHAR(100) NULL, 
    [Comment] VARCHAR(MAX) NULL,
	[Rating] int NULL
)
