CREATE TABLE [dbo].[tbAnexo]
(
	[Id] INT NOT NULL IDENTITY, 
    [Id_tbLog] INT NOT NULL, 
    [Id_tbAnexoTipo] INT NOT NULL, 
    [Nome] VARCHAR(150) NULL, 
    CONSTRAINT [PK_tbAnexo] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_tbAnexo_tbLog] FOREIGN KEY ([Id_tbLog]) REFERENCES [tbLog]([Id]), 
    CONSTRAINT [FK_tbAnexo_tbAnexoTipo] FOREIGN KEY ([Id_tbAnexoTipo]) REFERENCES [tbAnexoTipo]([Id]) 
)
