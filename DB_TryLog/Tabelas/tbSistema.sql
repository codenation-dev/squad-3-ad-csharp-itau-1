CREATE TABLE [dbo].[tbSistema]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Descricao] VARCHAR(250) NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbSistema] PRIMARY KEY ([Id]) 
)
