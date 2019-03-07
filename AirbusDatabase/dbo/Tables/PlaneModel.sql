CREATE TABLE [dbo].[PlaneModel] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [Name]                  NVARCHAR (MAX)   NULL,
    [FuelConsumptionPerMin] INT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



