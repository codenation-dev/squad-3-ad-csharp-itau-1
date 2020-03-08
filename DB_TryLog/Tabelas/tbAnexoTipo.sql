CREATE TABLE [dbo].[tbAnexoTipo]
(
	[Id] INT NOT NULL IDENTITY, 
    [Codigo] CHAR(3) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbAnexoTipo] PRIMARY KEY ([Id]) 
)
