CREATE TABLE [dbo].[tbLogDetalheSoftware]
(
	[Id] INT NOT NULL IDENTITY , 
    [Id_tbLog] INT NOT NULL, 
    [IP] VARCHAR(50) NULL, 
    [NavegadorNome] VARCHAR(100) NULL, 
    [NavegadorVersao] VARCHAR(50) NULL, 
    [SistemaOperacionalNome] VARCHAR(150) NULL, 
    [SistemaOperacionalVersao] VARCHAR(50) NULL, 
    [BancoDadosNome] VARCHAR(100) NULL, 
    [BancoDadosVersao] VARCHAR(50) NULL, 
    CONSTRAINT [PK_tbLogDetalheSoftware] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_tbLogDetalheSoftware_tbLog] FOREIGN KEY ([Id_tbLog]) REFERENCES [tbLog]([Id])
)
