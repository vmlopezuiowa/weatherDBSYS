CREATE TABLE [dbo].[Feedback] (
    [ReviewId] INT           NOT NULL,
    [Email]    VARCHAR (100) NULL,
    [Comment]  VARCHAR (MAX) NULL,
    [Rating]   INT           NULL,
    PRIMARY KEY CLUSTERED ([ReviewId] ASC)
);

