CREATE PROCEDURE [dbo].[ppInsertMovimientos]
	@TipoDocumento int,
	@Documento nvarchar(50),
	@Monto decimal (18,2),
	@Dbcr nvarchar(2),
	@TipoTransaccion int,
	@Descripcion nvarchar(150)
AS
	INSERT Movimiento(TipoDocumento, Documento, Monto, Dbcr, TipoTransaccion, Descripcion) 
	VALUES (@TipoDocumento, @Documento, @Monto, @Dbcr, @TipoTransaccion, @Descripcion)

RETURN 0