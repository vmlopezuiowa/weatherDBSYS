CREATE TABLE [dbo].[Weather] (
    [ZIP]           INT             NOT NULL,
	[Date]           DATE   NOT NULL DEFAULT getdate(),
	[Time]           TIME (7)   NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [City]          NVARCHAR (450)  NULL,
    [State]         NVARCHAR (450)  NULL,
    [AirPressure]   DECIMAL (18, 2) NULL,
    [FeelsLike]     DECIMAL (18, 2) NULL,
    [Humidity]      DECIMAL (18, 2) NULL,
    [Temperature]   DECIMAL (18, 2) NULL,
    [UVIndex]       DECIMAL (18, 2) NULL,
    [Visibility]    DECIMAL (18, 2) NULL,
    [WindDirection] NVARCHAR (MAX)  NULL,
    [WindSpeed]     DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Weather] PRIMARY KEY CLUSTERED ([ZIP] ASC, [Date] ASC, [Time] ASC ),
    CONSTRAINT [AK_Weather_City_Day_State_ZIP] UNIQUE NONCLUSTERED ([Date] ASC, [ZIP] ASC, [Time] ASC)
);

