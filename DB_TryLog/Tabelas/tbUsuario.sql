CREATE TABLE [dbo].[tbUsuario]
(
	[Id] INT NOT NULL , 
    [Email] VARCHAR(200) NOT NULL, 
    [Senha] VARCHAR(100) NOT NULL,     
    [Tolkien] VARCHAR(250) NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbUsuario] PRIMARY KEY ([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Chave-Primaria tbUsuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tbUsuario',
    @level2type = N'COLUMN',
    @level2name = N'Id'