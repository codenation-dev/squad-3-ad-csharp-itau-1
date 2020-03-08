CREATE TABLE [dbo].[tbSistema]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Descricao] VARCHAR(250) NULL, 
    [Ativo] BIT NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [DataUltimaAtualizacao] DATETIME NOT NULL
)
