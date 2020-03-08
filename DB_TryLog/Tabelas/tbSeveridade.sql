CREATE TABLE [dbo].[tbSeveridade]
(
	[Id] INT NOT NULL , 
    [Codigo] VARCHAR(3) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbSeveridade] PRIMARY KEY ([Id]) 
)
