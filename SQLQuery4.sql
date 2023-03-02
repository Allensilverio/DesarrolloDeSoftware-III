ALTER PROCEDURE [dbo].[spUpsertFeligreses]
	@TipoDocumento int,
	@Documento nvarchar(50),
	@Nombres nvarchar(50),
	@Apellidos nvarchar(50),
	@FechaNacimiento Datetime,
	@FechaUltimaConfecion datetime,
	@EstadoCivil nvarchar(50),
	@Sexo nvarchar(2),
	@Diezma int,
	@PerteneceComunidad int,
	@UltimaVisitaIglesia datetime,
	@TipoEvento int /* 1 - Mortal 2 - Venial 3 - Penitencia */
AS



--Si el feligres existe agrega el balance anterior al nuevo balance
if exists (select 1 from tblFeligreses where TipoDocumento = @TipoDocumento and Documento = @Documento) 
Begin

if @TipoEvento = 1 -- Cantidad de pecados mortales + 1
begin
update tblFeligreses set CantidadPecadosMortales = CantidadPecadosMortales + 1 where TipoDocumento = @TipoDocumento and Documento = @Documento
end

if @TipoEvento = 2  -- Cantidad de pecados veniales + 1
begin
update tblFeligreses set CantidadPecadosVeniales = CantidadPecadosVeniales + 1 where TipoDocumento = @TipoDocumento and Documento = @Documento
end

if @TipoEvento = 3 -- Cantidad de pecados - 1
begin
update tblFeligreses set CantidadPecadosMortales = CantidadPecadosMortales - 1 where TipoDocumento = @TipoDocumento and Documento = @Documento
update tblFeligreses set Penitencias = Penitencias + 1 where TipoDocumento = @TipoDocumento and Documento = @Documento
end


--Si no existe agregalo en la tabla
else 
BEGIN
	
	IF @TipoEvento = 1  -- Cantidad de pecados mortales + 1
	BEGIN
	INSERT INTO tblFeligreses(TipoDocumento, Documento, Nombres, Apellidos, FechaNacimiento, FechaUltimaConfecion, EstadoCivil, Sexo,
	Diezma, PerteneceComunidad, UltimaVisitaIglesia, CantidadPecadosMortales, CantidadPecadosVeniales, Penitencias)
	VALUES (@TipoDocumento, @Documento, @Nombres, @Apellidos, @FechaNacimiento, @FechaUltimaConfecion, @EstadoCivil, @Sexo,
	@Diezma, @PerteneceComunidad, @UltimaVisitaIglesia, 1,0,0)
	END

	IF @TipoEvento = 2  -- Cantidad de pecados veniales + 1
	BEGIN
	INSERT INTO tblFeligreses(TipoDocumento, Documento, Nombres, Apellidos, FechaNacimiento, FechaUltimaConfecion, EstadoCivil, Sexo,
	Diezma, PerteneceComunidad, UltimaVisitaIglesia, CantidadPecadosMortales, CantidadPecadosVeniales, Penitencias)
	VALUES (@TipoDocumento, @Documento, @Nombres, @Apellidos, @FechaNacimiento, @FechaUltimaConfecion, @EstadoCivil, @Sexo,
	@Diezma, @PerteneceComunidad, @UltimaVisitaIglesia, 0,1,0)
	END

		IF @TipoEvento = 3  -- Cantidad de penitencias + 1
	BEGIN
	INSERT INTO tblFeligreses(TipoDocumento, Documento, Nombres, Apellidos, FechaNacimiento, FechaUltimaConfecion, EstadoCivil, Sexo,
	Diezma, PerteneceComunidad, UltimaVisitaIglesia, CantidadPecadosMortales, CantidadPecadosVeniales, Penitencias)
	VALUES (@TipoDocumento, @Documento, @Nombres, @Apellidos, @FechaNacimiento, @FechaUltimaConfecion, @EstadoCivil, @Sexo,
	@Diezma, @PerteneceComunidad, @UltimaVisitaIglesia, 0,0,1)
	END

END

END

RETURN 0