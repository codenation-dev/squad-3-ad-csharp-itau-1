CREATE TABLE [dbo].[tbUsuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NCHAR(10) NULL, 
    [Senha] NCHAR(10) NULL,     
    [Tolkien] NCHAR(10) NULL, 
    [Ativo] BIT NULL, 
    [DataCadastro] DATETIMEOFFSET NULL, 
    [DataUltimaAtualizacao] DATETIMEOFFSET NULL
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