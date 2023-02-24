CREATE TABLE [dbo].[tblEventos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipoDocumento] NVARCHAR(50) NOT NULL, 
    [Documento] NVARCHAR(50) NOT NULL, 
    [Nota] NVARCHAR(50) NOT NULL, 
    [Descripcion] NVARCHAR(50) NOT NULL, 
    [TipoEvento] INT NOT NULL
)
