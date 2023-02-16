create proc ppGetCliente
@TipoDocumento int,
@Documento nvarchar(50)

AS

select * from tblClientes where TipoDocumento = @TipoDocumento and Documento = @Documento

RETURN 0