CREATE TABLE [dbo].[tbNotificacao]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdUsuario] INT NOT NULL, 
    [EnviaEmail] BIT NOT NULL, 
    [EnviaSMS] BIT NOT NULL,
    [Ativo] BIT NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [DataUltimaAtualizacao] DATETIME NOT NULL    
)
