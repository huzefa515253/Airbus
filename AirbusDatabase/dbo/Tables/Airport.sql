CREATE TABLE [dbo].[Airport] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [AirportName] NVARCHAR (MAX)   NULL,
    [City]        NVARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

