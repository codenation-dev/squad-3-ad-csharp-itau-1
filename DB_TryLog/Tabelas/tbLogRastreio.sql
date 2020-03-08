CREATE TABLE [dbo].[tbLogRastreio]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Id_tbLog] INT NOT NULL, 
    [Id_tbSituacao] INT NOT NULL, 
    [DataHora] DATETIME NOT NULL DEFAULT GetDate(), 
    CONSTRAINT [PK_tbLogRastreio] PRIMARY KEY ([Id])
)
