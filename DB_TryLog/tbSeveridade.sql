CREATE TABLE [dbo].[tbSeveridade]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Codigo] VARCHAR(3) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [DataUltimaAtualizacao] DATETIME NOT NULL
)
