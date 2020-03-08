CREATE TABLE [dbo].[tbAmbiente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [DataUltimaAtualizacao] DATETIME NOT NULL 
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