CREATE TABLE [dbo].[tbAmbiente]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbAmbiente] PRIMARY KEY ([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Chave primaria tbAmbiente',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tbAmbiente',
    @level2type = N'COLUMN',
    @level2name = N'Id'