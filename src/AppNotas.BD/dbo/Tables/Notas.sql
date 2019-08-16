CREATE TABLE [dbo].[Notas] (
    [id] INT NOT NULL IDENTITY(1,1),
    [titulo] NVARCHAR(250) NULL, 
    [contenidoHtml] NVARCHAR(MAX) NULL, 
    [contenidoSoloTexto] NVARCHAR(MAX) NULL, 
    [anclada] BIT NULL, 
    [fechaCreacion] DATETIME NULL, 
    [fechaActualizacion] DATETIME NULL, 
    [idUsuario] INT NULL, 
    CONSTRAINT [PK_Notas] PRIMARY KEY CLUSTERED ([id] ASC)
);

