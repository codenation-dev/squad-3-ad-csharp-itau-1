CREATE TABLE [dbo].[tbSituacao]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbSituacao] PRIMARY KEY ([Id])
)
