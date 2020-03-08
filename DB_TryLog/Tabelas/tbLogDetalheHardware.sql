CREATE TABLE [dbo].[tbLogDetalheHardware]
(
    [Id] INT NOT NULL IDENTITY,
    [Id_tbLog] INT NOT NULL, 
    [MemoriaRam] VARCHAR(50) NULL, 
    [Processador] VARCHAR(50) NULL, 
    [Marca] VARCHAR(50) NULL, 
    [Modelo] VARCHAR(50) NULL, 
    [Disco] VARCHAR(50) NULL, 
    [Resolucao] VARCHAR(50) NULL, 
    [EnderecoMac] VARCHAR(50) NULL, 
    [NomeDispositivo] VARCHAR(50) NULL, 
    CONSTRAINT [PK_tbLogDetalheHardware] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_tbLogDetalheHardware_tbLog] FOREIGN KEY (Id_tbLog) REFERENCES [tbLog]([Id])    
)
