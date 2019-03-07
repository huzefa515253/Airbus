CREATE TABLE [dbo].[FlightCompany] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [FlightId]  UNIQUEIDENTIFIER NULL,
    [CompanyId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    FOREIGN KEY ([FlightId]) REFERENCES [dbo].[Plane] ([Id])
);

