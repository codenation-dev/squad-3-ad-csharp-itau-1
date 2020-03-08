CREATE TABLE [dbo].[tbNotificacao]
(
	[Id] INT NOT NULL , 
    [IdUsuario] INT NOT NULL, 
    [EnviaEmail] BIT NOT NULL, 
    [EnviaSMS] BIT NOT NULL,
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataCadastro] DATETIME NOT NULL DEFAULT GetDate(), 
    [Deletado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_tbNotificacao] PRIMARY KEY ([Id]) 
)
