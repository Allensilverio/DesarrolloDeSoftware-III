CREATE PROCEDURE [dbo].[ppUpsertCliente2]
	@Nombres nvarchar(150), 
	@Apellidos nvarchar(150), 
	@FechaNacimiento datetime,
	@Comentario nvarchar(150),
	@TipoDocumento int,
	@Documento nvarchar(50),
	@Balance decimal(18,2),
	@TipoTransaccion int
AS
--Si el cliente existe agrega el balance anterior al nuevo balance
if exists (select 1 from tblClientes where TipoDocumento = @TipoDocumento and Documento = @Documento) 
update tblClientes set Balance = Balance + (@Balance*@TipoTransaccion) where TipoDocumento = @TipoDocumento and Documento = @Documento

--Si no existe agregalo en la tabla
else 
	INSERT tblClientes(NOMBRES, APELLIDOS, FECHANACIMIENTO, SEXO, COMENTARIO, TipoDocumento, Documento, Balance) 
	VALUES (@Nombres, @Apellidos, @FechaNacimiento, 'M', @Comentario, @TipoDocumento, @Documento, @Balance)
RETURN 0