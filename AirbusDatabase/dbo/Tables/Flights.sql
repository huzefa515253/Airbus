CREATE TABLE [dbo].[Flights] (
    [Id]                         UNIQUEIDENTIFIER NOT NULL,
    [PlaneId]                    UNIQUEIDENTIFIER NULL,
    [HarnessLength]              INT              NULL,
    [GrossWeight]                INT              NULL,
    [AtmosphericPressure]        INT              NULL,
    [RoomTemperature]            INT              NULL,
    [SourceAirport]              UNIQUEIDENTIFIER NULL,
    [DestinationAirport]         UNIQUEIDENTIFIER NULL,
    [FuelQuentityOnLeftWing]     INT              NULL,
    [FuelQuentityOnRightWing]    INT              NULL,
    [MaximumAltitudeToBeReached] INT              NULL,
    [FlightNumber]               NVARCHAR (MAX)   NULL,
    [DepartureDateTime]          DATETIME         NULL,
    [JourneyDurationInMin]       INT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PlaneId]) REFERENCES [dbo].[Plane] ([Id])
);



