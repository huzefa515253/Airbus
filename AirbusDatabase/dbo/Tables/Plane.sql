CREATE TABLE [dbo].[Plane] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [ModelNumber]             UNIQUEIDENTIFIER NULL,
    [ManufacturingDate]       DATETIME         NULL,
    [FuelCapacityOnLeftWing]  INT              NULL,
    [FuelCapacityOnRightWing] INT              NULL,
    [MSN]                     NVARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ModelNumber]) REFERENCES [dbo].[PlaneModel] ([Id])
);



