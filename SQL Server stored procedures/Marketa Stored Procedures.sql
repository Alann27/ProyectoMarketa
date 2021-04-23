USE Marketa
GO

CREATE PROCEDURE BuscarFacturasSinPaga
AS
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
WHERE  (TotalGeneral > Pago)
GO

CREATE PROCEDURE FacSinPagarMasMes @Fecha datetime
AS
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
WHERE  (Fecha <= @Fecha) AND (TotalGeneral > Pago)
ORDER BY Fecha
GO

CREATE PROCEDURE IdMasGrandeF
AS
SELECT MAX(idFactura) FROM tblFactura
GO

CREATE PROCEDURE InsertarF @Fecha datetime, @IdCliente int, @IdUsuario int, 
@Pago decimal(10,2), @TotalITBIS decimal(10,2), @TotalDescuento decimal(10,2), @TotalGeneral decimal(10,2)
AS
INSERT INTO [tblFactura] ([Fecha], [IdCliente], [IdUsuario], [Pago], [TotalITBIS], [TotalDescuento], [TotalGeneral]) 
VALUES (@Fecha, @IdCliente, @IdUsuario, @Pago, @TotalITBIS, @TotalDescuento, @TotalGeneral);
GO

CREATE PROCEDURE GetDataC
AS
SELECT IdCliente, Nombre, Telefono, Direccion, MontoDebe, Apellido, FechaRegistro
FROM     tblCliente
GO

CREATE PROCEDURE ActualizarCliente @Telefono char(10), @Direccion varchar(50), @IdCliente int
AS
UPDATE tblCliente
SET Telefono = @Telefono, Direccion = @Direccion
WHERE  (IdCliente = @IdCliente)
GO

CREATE PROCEDURE ActualizarMontoC @IdCliente int, @MontoDebe decimal(10,2)
AS
UPDATE tblCliente
SET          MontoDebe = @MontoDebe
WHERE  (IdCliente = @IdCliente)
GO

CREATE PROCEDURE ConseguirNombreC @IdCliente int
AS
SELECT Nombre + ' ' + Apellido AS Nombre
FROM     tblCliente
WHERE  (IdCliente = @IdCliente)
GO

CREATE PROCEDURE BuscarClientePorId @OriginalIdCliente int
AS
SELECT IdCliente, Nombre, Apellido, Telefono, Direccion, MontoDebe, FechaRegistro
FROM     tblCliente
WHERE  (IdCliente = @OriginalIdCliente)
GO

CREATE PROCEDURE BuscarClientePorNombre @Nombre varchar(20)
AS
SELECT IdCliente, Nombre, Telefono, Direccion, MontoDebe, Apellido, FechaRegistro
FROM     tblCliente
WHERE  (Nombre + ' ' + Apellido = @Nombre)
GO

CREATE PROCEDURE ClientesDeben
AS
SELECT IdCliente, Nombre, Telefono, Direccion, MontoDebe, Apellido, FechaRegistro
FROM     tblCliente
WHERE  (MontoDebe > 0)
GO

CREATE PROCEDURE InsertarC @Nombre varchar(20), @Telefono char(10), @Direccion varchar(50), @Apellido varchar(20)
AS
INSERT INTO [tblCliente] ([Nombre], [Telefono], [Direccion], [Apellido]) 
VALUES (@Nombre, @Telefono, @Direccion, @Apellido)
GO


CREATE PROCEDURE GetDataU
AS
SELECT IdUsuario, TipoUsuario, Telefono, Contraseña, Cedula, Nombre, Apellidos, Direccion, Activo
FROM     tblUsuario
GO

CREATE PROCEDURE CambiarEstado @Cedula char(11)
AS
UPDATE tblUsuario
SET          Activo = (CASE WHEN (Activo = 1) THEN 0 ELSE 1 END)
WHERE  (Cedula = @Cedula)
GO


CREATE PROCEDURE BuscarPorCedulaU @OriginalCedula char(11)
AS
SELECT Apellidos, Cedula, Contraseña, Direccion, IdUsuario, Nombre, Telefono, TipoUsuario, Activo
FROM     tblUsuario
WHERE  (Cedula = @OriginalCedula)
GO

CREATE PROCEDURE BuscarUsuarioPorId @IdUsuario int
AS
SELECT Apellidos, Cedula, Contraseña, Direccion, IdUsuario, Nombre, Telefono, TipoUsuario, Activo
FROM     tblUsuario
WHERE  (IdUsuario = @IdUsuario)
GO

CREATE PROCEDURE InsertarU @TipoUsuario int, @Telefono char(10), @Contraseña varchar(50), 
@Cedula char(11), @Nombre varchar(20), @Apellidos varchar(20), 
@Direccion varchar(50), @Activo bit
AS
INSERT INTO [tblUsuario] ([TipoUsuario], [Telefono], [Contraseña], [Cedula], [Nombre], [Apellidos], [Direccion], [Activo]) 
VALUES (@TipoUsuario, @Telefono, @Contraseña, @Cedula, @Nombre, @Apellidos, @Direccion, @Activo)
GO

CREATE PROCEDURE BuscarFacPorIdConCajero @IdFactura int
AS
SELECT F.IdFactura, F.Fecha, F.IdCliente, F.IdUsuario, F.TotalITBIS, F.TotalDescuento, F.TotalGeneral, F.Pago, C.Nombre + ' ' + C.Apellido AS NomCliente, C.MontoDebe, U.Nombre + ' ' + U.Apellidos AS Cajero
FROM     tblFactura AS F INNER JOIN
                  tblCliente AS C ON F.IdCliente = C.IdCliente INNER JOIN
                  tblUsuario AS U ON F.IdUsuario = U.IdUsuario
WHERE  (F.IdFactura = @IdFactura)
GO

CREATE PROCEDURE BuscarFacConCajeroHoy @Fecha datetime
AS
SELECT F.IdFactura, F.Fecha, F.IdCliente, F.IdUsuario, F.TotalITBIS, F.TotalDescuento, F.TotalGeneral, F.Pago, C.Nombre + ' ' + C.Apellido AS NomCliente, C.MontoDebe, U.Nombre + ' ' + U.Apellidos AS Cajero
FROM     tblFactura AS F INNER JOIN
                  tblCliente AS C ON F.IdCliente = C.IdCliente INNER JOIN
                  tblUsuario AS U ON F.IdUsuario = U.IdUsuario
WHERE  (F.Fecha > @Fecha)
GO

CREATE PROCEDURE BuscarFacConCajeroEntreFechas @Fecha1 datetime, @Fecha2 datetime
AS
SELECT F.IdFactura, F.Fecha, F.IdCliente, F.IdUsuario, F.TotalITBIS, F.TotalDescuento, F.TotalGeneral, F.Pago, C.Nombre + ' ' + C.Apellido AS NomCliente, C.MontoDebe, U.Nombre + ' ' + U.Apellidos AS Cajero
FROM     tblFactura AS F INNER JOIN
                  tblCliente AS C ON F.IdCliente = C.IdCliente INNER JOIN
                  tblUsuario AS U ON F.IdUsuario = U.IdUsuario
WHERE (Fecha BETWEEN @Fecha1 AND @Fecha2)
GO

CREATE PROCEDURE GetDataFD 
AS
SELECT IdDetalle, IdFactura, IdProducto, Cantidad, ITBIS, Descuento, Precio
FROM     tblFacturaD
GO

CREATE PROCEDURE BuscarDetallePorId @OriginalIdDetalle int
AS
SELECT Cantidad, Descuento, ITBIS, IdDetalle, IdFactura, IdProducto, Precio
FROM     tblFacturaD
WHERE  (IdDetalle = @OriginalIdDetalle)
GO

CREATE PROCEDURE BuscarDetallePorIdFactura @IdFactura int
AS
SELECT IdDetalle, IdFactura, IdProducto, Precio, Cantidad, ITBIS, Descuento
FROM     tblFacturaD
WHERE  (IdFactura = @IdFactura)
GO

CREATE PROCEDURE BuscarDetallePorIdProducto @IdProducto int
AS
SELECT IdDetalle, IdFactura, IdProducto, Precio, ITBIS, Cantidad, Descuento
FROM     tblFacturaD
WHERE  (IdProducto = @IdProducto)
GO

CREATE PROCEDURE InsertarFD @IdFactura int, @IdProducto int, @Precio decimal(10,2), @Cantidad int, @ITBIS decimal(10,2), @Descuento decimal(10,2)
AS
INSERT INTO tblFacturaD
(IdFactura, IdProducto, Precio, Cantidad, ITBIS, Descuento)
VALUES (@IdFactura,@IdProducto,@Precio,@Cantidad,@ITBIS,@Descuento); 
GO

CREATE PROCEDURE GetDataCP
AS
SELECT IdCategoriaP, Nombre, Descripcion
FROM     tblCategoriaP
GO

CREATE PROCEDURE BuscarCategoriaPorId @IdCategoriaP int
AS
SELECT IdCategoriaP, Nombre, Descripcion
FROM     tblCategoriaP
WHERE  (IdCategoriaP = @IdCategoriaP)
GO

CREATE PROCEDURE GetDataP
AS
SELECT IdProducto, NombreProducto, IdCategoriaP, Precio, NumExistencias, Descuento, AplicaITBIS
FROM     tblProducto
GO

CREATE PROCEDURE ActualizarExistenciasP @IdProducto int, @NumExistencias decimal(10,2)
AS
UPDATE tblProducto
SET          NumExistencias = @NumExistencias
WHERE  (IdProducto = @IdProducto)
GO

CREATE PROCEDURE ActualizarProducto @IdProducto int, @NombreProducto varchar(50), @Precio decimal(10,2),
@NumExistencias decimal(10,2), @IdCategoriaP int, @Descuento decimal(10,2), @AplicaITBIS bit
AS
UPDATE tblProducto
SET          NombreProducto = @NombreProducto, Precio = @Precio, NumExistencias = @NumExistencias, IdCategoriaP = @IdCategoriaP, Descuento = @Descuento, AplicaITBIS = @AplicaITBIS
WHERE  (IdProducto = @IdProducto)
GO

CREATE PROCEDURE BuscarProductoPorId @IdProducto int
AS
SELECT IdCategoriaP, NombreProducto, Descuento, IdProducto, NumExistencias, Precio, AplicaITBIS
FROM     tblProducto
WHERE  (IdProducto = @IdProducto)
GO

CREATE PROCEDURE BuscarPorNombreP @NombreProducto varchar(50)
AS
SELECT IdCategoriaP, NombreProducto, Descuento, IdProducto, NumExistencias, Precio, AplicaITBIS
FROM     tblProducto
WHERE  (NombreProducto = @NombreProducto)
GO

CREATE PROCEDURE ProductosAcabandose
AS
SELECT IdCategoriaP, NombreProducto, AplicaITBIS, Descuento, IdProducto, NumExistencias, Precio
FROM     tblProducto
WHERE  (NumExistencias <= 20)
GO

CREATE PROCEDURE InsertarP @IdProducto int, @NombreProducto varchar(50), @Precio decimal(10,2), 
@NumExistencias decimal(10,2), @IdCategoriaP int, @Descuento decimal(10,2), @AplicaITBIS bit
AS
INSERT INTO tblProducto
(IdProducto, NombreProducto, Precio, NumExistencias, IdCategoriaP, Descuento, AplicaITBIS)
VALUES (@IdProducto,@NombreProducto,@Precio,@NumExistencias,@IdCategoriaP,@Descuento,@AplicaITBIS)
GO

CREATE PROCEDURE ProductosMasVendidos @Fecha datetime
AS
SELECT TOP (5) D.IdProducto, SUM(D.Cantidad) AS Vendido
FROM     tblFacturaD AS D INNER JOIN
                  tblFactura AS F ON F.IdFactura = D.IdFactura
WHERE  (F.Fecha >= @Fecha)
GROUP BY D.IdProducto
ORDER BY Vendido DESC
GO

CREATE PROCEDURE ProductosMasGeneran @Fecha datetime
AS
SELECT TOP (5) D.IdProducto, SUM(D.Cantidad * D.Precio + D.ITBIS) AS Vendido
FROM     tblFacturaD AS D INNER JOIN
                  tblFactura AS F ON F.IdFactura = D.IdFactura
WHERE  (F.Fecha >= @Fecha)
GROUP BY D.IdProducto
ORDER BY Vendido DESC
GO

CREATE PROCEDURE DetalleConProducto
AS
SELECT P.NombreProducto AS Descripcion, D.IdDetalle, D.IdFactura, D.IdProducto, D.Precio, D.ITBIS, D.Cantidad, D.Descuento
FROM     tblFacturaD AS D INNER JOIN
         tblProducto AS P ON P.IdProducto = D.IdProducto
GO

CREATE PROCEDURE DetallePorIdFacConProducto @IdFactura int
AS
SELECT P.NombreProducto AS Descripcion, D.IdDetalle, D.IdFactura, D.IdProducto, D.Precio, D.ITBIS, D.Cantidad, D.Descuento
FROM     tblFacturaD AS D INNER JOIN
                  tblProducto AS P ON P.IdProducto = D.IdProducto
WHERE  (D.IdFactura = @IdFactura)
GO

CREATE PROCEDURE GetDataPD
AS
BEGIN
SELECT P.IdPagoDeuda, P.IdUsuario, P.IdCliente, P.DeudaAnterior, P.Fecha, P.Abono, C.Nombre + ' ' + C.Apellido AS NomCliente, P.DeudaAnterior - P.Abono AS DeudaActual
FROM     tblPagoDeuda AS P INNER JOIN
                  tblCliente AS C ON P.IdCliente = C.IdCliente
END

CREATE PROCEDURE BuscarHoyPD @Fecha datetime
AS
BEGIN
SELECT P.DeudaAnterior - P.Abono AS DeudaActual, C.Nombre + ' ' + C.Apellido AS NomCliente, P.Abono, P.DeudaAnterior, P.Fecha, P.IdCliente, P.IdPagoDeuda, P.IdUsuario FROM tblPagoDeuda AS P INNER JOIN tblCliente AS C ON P.IdCliente = C.IdCliente WHERE (P.Fecha > @Fecha)
END


CREATE PROCEDURE BuscarPorIdClientePD @IdCliente int
AS
BEGIN
SELECT P.DeudaAnterior - P.Abono AS DeudaActual, C.Nombre + ' ' + C.Apellido AS NomCliente, P.Abono, P.DeudaAnterior, P.Fecha, P.IdCliente, P.IdPagoDeuda, P.IdUsuario FROM tblPagoDeuda AS P INNER JOIN tblCliente AS C ON P.IdCliente = C.IdCliente WHERE (P.IdCliente = @IdCliente)
END


CREATE PROCEDURE BuscarEntreFechasPD @FechaIni datetime, @FechaFin datetime
AS
BEGIN
SELECT P.DeudaAnterior - P.Abono AS DeudaActual, C.Nombre + ' ' + C.Apellido AS NomCliente, P.Abono, P.DeudaAnterior, P.Fecha, P.IdCliente, P.IdPagoDeuda, P.IdUsuario FROM tblPagoDeuda AS P INNER JOIN tblCliente AS C ON P.IdCliente = C.IdCliente WHERE (P.Fecha BETWEEN @FechaIni AND @FechaFin)
END


CREATE PROCEDURE InsertarPD @IdCliente int, @IdUsuario int, @Fecha datetime, @DeudaAnterior decimal(10,2), @Abono decimal(10,2)
AS
BEGIN
INSERT INTO tblPagoDeuda
                  (IdCliente, IdUsuario, Fecha, DeudaAnterior, Abono)
VALUES (@IdCliente,@IdUsuario,@Fecha,@DeudaAnterior,@Abono)
END


CREATE PROCEDURE GetDataF
AS
BEGIN
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
END


CREATE PROCEDURE ActualizarPagoDeFactura @Pago decimal(10,2), @IdFactura int, @IdCliente int, @Original_IdFactura int, @Original_IdCliente int
AS
BEGIN
UPDATE tblFactura
SET          Pago = @Pago
WHERE  (IdFactura = @Original_IdFactura) AND (IdCliente = @Original_IdCliente)
END



CREATE PROCEDURE BuscarFacturaPorId @IdFactura int
AS
BEGIN
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
WHERE  (IdFactura = @IdFactura)
END



CREATE PROCEDURE BuscarFacturasDeHoy @Fecha datetime
AS
BEGIN
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
WHERE  (Fecha > @Fecha)
END


CREATE PROCEDURE BuscarFacturasEntreFechas @Fecha1 datetime, @Fecha2 datetime
AS
BEGIN
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
WHERE  (Fecha BETWEEN @Fecha1 AND @Fecha2)
END


CREATE PROCEDURE BuscarFacturasSinPagarIdCliente @IdCliente int
AS
BEGIN
SELECT IdFactura, Fecha, IdCliente, IdUsuario, Pago, TotalITBIS, TotalDescuento, TotalGeneral
FROM     tblFactura
WHERE  (IdCliente = @IdCliente) AND (TotalGeneral > Pago)
END

go

CREATE PROCEDURE ReporteVentas
AS
BEGIN

Select CONCAT(U.Nombre,' ',SUBSTRING(U.Apellidos,0,CHARINDEX(' ',U.Apellidos))) AS Cajero, P.NombreProducto AS Producto, 
FD.Precio, FD.Cantidad, FD.ITBIS, FD.Descuento, ((FD.Precio * FD.Cantidad) + FD.ITBIS - FD.Descuento) AS Importe FROM
tblFactura AS F
INNER JOIN tblUsuario AS U ON F.IdUsuario = U.IdUsuario
INNER JOIN tblFacturaD AS FD ON F.IdFactura = FD.IdFactura
INNER JOIN tblProducto AS P ON FD.IdProducto = P.IdProducto

END

go

CREATE PROCEDURE ReporteVentasPorFecha
(@Fecha DATETIME)
AS
BEGIN

Select CONCAT(U.Nombre,' ',SUBSTRING(U.Apellidos,0,CHARINDEX(' ',U.Apellidos))) AS Cajero, P.NombreProducto AS Producto, 
FD.Precio, FD.Cantidad, FD.ITBIS, FD.Descuento, ((FD.Precio * FD.Cantidad) + FD.ITBIS - FD.Descuento) AS Importe FROM
tblFactura AS F
INNER JOIN tblUsuario AS U ON F.IdUsuario = U.IdUsuario
INNER JOIN tblFacturaD AS FD ON F.IdFactura = FD.IdFactura
INNER JOIN tblProducto AS P ON FD.IdProducto = P.IdProducto
WHERE CONVERT(date,F.Fecha) = CONVERT(DATE,@Fecha)
END

go

CREATE PROCEDURE ReporteVentasEntreFecha
(@FechaInicio DATETIME, @FechaFinal DATETIME)
AS
BEGIN

Select CONCAT(U.Nombre,' ',SUBSTRING(U.Apellidos,0,CHARINDEX(' ',U.Apellidos))) AS Cajero, P.NombreProducto AS Producto, 
FD.Precio, FD.Cantidad, FD.ITBIS, FD.Descuento, ((FD.Precio * FD.Cantidad) + FD.ITBIS - FD.Descuento) AS Importe FROM
tblFactura AS F
INNER JOIN tblUsuario AS U ON F.IdUsuario = U.IdUsuario
INNER JOIN tblFacturaD AS FD ON F.IdFactura = FD.IdFactura
INNER JOIN tblProducto AS P ON FD.IdProducto = P.IdProducto
WHERE CONVERT(date,F.Fecha) BETWEEN CONVERT(DATE,@FechaInicio) AND CONVERT(DATE,@FechaFinal)

END

go

ALTER PROCEDURE TotalFacturasPorFecha
(@Fecha DATETIME)
AS
BEGIN

SELECT ISNULL(SUM(TotalGeneral),0) AS Valor FROM tblFactura
WHERE CONVERT(DATE,Fecha) = CONVERT(DATE,@Fecha)

END

go

ALTER PROCEDURE TotalFacturasEntreFecha
(@FechaInicio DATETIME, @FechaFinal DATETIME)
AS
BEGIN

SELECT ISNULL(SUM(TotalGeneral),0) AS Valor FROM tblFactura
WHERE CONVERT(DATE,Fecha) BETWEEN CONVERT(DATE,@FechaInicio) AND CONVERT(DATE,@FechaFinal)

END

go


ALTER PROCEDURE CantidadFacturasPorFecha
(@Fecha DATETIME)
AS
BEGIN

SELECT ISNULL(CONVERT(DECIMAL,COUNT(IdFactura)),0) AS Valor FROM tblFactura
WHERE CONVERT(DATE,Fecha) = CONVERT(DATE,@Fecha)

END

go

ALTER PROCEDURE CantidadFacturasEntreFecha
(@FechaInicio DATETIME, @FechaFinal DATETIME)
AS
BEGIN

SELECT ISNULL(CONVERT(DECIMAL,COUNT(IdFactura)),0) AS Valor FROM tblFactura
WHERE CONVERT(DATE,Fecha) BETWEEN CONVERT(DATE,@FechaInicio) AND CONVERT(DATE,@FechaFinal)

END

go

CREATE PROCEDURE ReporteDeudas
AS
BEGIN

SELECT CONCAT(U.Nombre,' ',U.Apellidos) AS Cajero, CONCAT(C.Nombre,' ',C.Apellido) AS Cliente, (F.TotalGeneral - F.Pago) AS DeudaFactura, C.MontoDebe AS DeudaTotal
FROM tblFactura AS F
INNER JOIN tblCliente AS C ON F.IdCliente = C.IdCliente
INNER JOIN tblUsuario AS U ON F.IdUsuario = U.IdUsuario
WHERE F.Pago < F.TotalGeneral

END

go

ALTER PROCEDURE ReporteDeudasPorFechas
(@Fecha DATETIME)
AS
BEGIN

SELECT CONCAT(U.Nombre,' ',U.Apellidos) AS Cajero, CONCAT(C.Nombre,' ',C.Apellido) AS Cliente, (F.TotalGeneral - F.Pago) AS DeudaFactura, C.MontoDebe AS DeudaTotal
FROM tblFactura AS F
INNER JOIN tblCliente AS C ON F.IdCliente = C.IdCliente
INNER JOIN tblUsuario AS U ON F.IdUsuario = U.IdUsuario
WHERE F.Pago < F.TotalGeneral AND CONVERT(date,F.Fecha) = CONVERT(DATE,@Fecha)

END

go

CREATE PROCEDURE ReporteDeudasEntreFechas
(@FechaInicio DATETIME, @FechaFinal DATETIME)
AS
BEGIN

SELECT CONCAT(U.Nombre,' ',U.Apellidos) AS Cajero, CONCAT(C.Nombre,' ',C.Apellido) AS Cliente, (F.TotalGeneral - F.Pago) AS DeudaFactura, C.MontoDebe AS DeudaTotal
FROM tblFactura AS F
INNER JOIN tblCliente AS C ON F.IdCliente = C.IdCliente
INNER JOIN tblUsuario AS U ON F.IdUsuario = U.IdUsuario
WHERE F.Pago < F.TotalGeneral AND CONVERT(DATE,F.Fecha) BETWEEN CONVERT(DATE,@FechaInicio) AND CONVERT(DATE,@FechaFinal)

END

go

CREATE PROCEDURE ReporteAbonos
AS
BEGIN

SELECT CONCAT(C.Nombre,' ',C.Apellido) AS Cliente, CONCAT(U.Nombre,' ',U.Apellidos) AS Cajero, PD.DeudaAnterior, PD.Abono, (PD.DeudaAnterior - PD.Abono) AS DeudaActual
FROM tblPagoDeuda AS PD
INNER JOIN tblCliente AS C ON PD.IdCliente = C.IdCliente
INNER JOIN tblUsuario AS U ON PD.IdUsuario = U.IdUsuario

END

go

CREATE PROCEDURE ReporteAbonosPorFecha
(@Fecha DATETIME)
AS
BEGIN

SELECT CONCAT(C.Nombre,' ',C.Apellido) AS Cliente, CONCAT(U.Nombre,' ',U.Apellidos) AS Cajero, PD.DeudaAnterior, PD.Abono, (PD.DeudaAnterior - PD.Abono) AS DeudaActual
FROM tblPagoDeuda AS PD
INNER JOIN tblCliente AS C ON PD.IdCliente = C.IdCliente
INNER JOIN tblUsuario AS U ON PD.IdUsuario = U.IdUsuario
WHERE CONVERT(date,PD.Fecha) = CONVERT(DATE, @Fecha)

END

go

CREATE PROCEDURE ReporteAbonosEntreFecha
(@FechaInicio DATETIME, @FechaFinal DATETIME)
AS
BEGIN

SELECT CONCAT(C.Nombre,' ',C.Apellido) AS Cliente, CONCAT(U.Nombre,' ',U.Apellidos) AS Cajero, PD.DeudaAnterior, PD.Abono, (PD.DeudaAnterior - PD.Abono) AS DeudaActual
FROM tblPagoDeuda AS PD
INNER JOIN tblCliente AS C ON PD.IdCliente = C.IdCliente
INNER JOIN tblUsuario AS U ON PD.IdUsuario = U.IdUsuario
WHERE CONVERT(date,PD.Fecha) BETWEEN CONVERT(DATE,@FechaInicio) AND CONVERT(DATE,@FechaFinal)

END

go

CREATE PROCEDURE DeudaTotal
AS
BEGIN

SELECT ISNULL(SUM(F.TotalGeneral - F.Pago),0) AS Valor
FROM tblFactura AS F
WHERE F.Pago < F.TotalGeneral

END

go

CREATE PROCEDURE VentasEnUltimos30Dias
AS
BEGIN

SELECT ISNULL(SUM(F.TotalGeneral),0) AS Valor
FROM tblFactura AS F
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE()))

END

go

CREATE PROCEDURE FacturasEnUltimos30Dias
AS
BEGIN

SELECT ISNULL(CONVERT(decimal,COUNT(F.IdFactura)),0) AS Valor
FROM tblFactura AS F
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE()))

END

go

CREATE PROCEDURE AbonosEnUltimos30Dias
AS
BEGIN

SELECT ISNULL(SUM(PD.Abono),0) AS Valor
FROM tblPagoDeuda AS PD
WHERE CONVERT(DATE,PD.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE()))

END

go

ALTER PROCEDURE CantidadProductosAcabandose
AS
BEGIN

SELECT ISNULL(CONVERT(decimal,COUNT(P.IdProducto)),0) AS Valor
FROM tblProducto AS P
WHERE P.NumExistencias <= 15

END

go

ALTER PROCEDURE VentasPorDiaUltimos30
AS
BEGIN

SELECT CONVERT(DATE,F.Fecha) AS Fecha,CONCAT(DATEPART(DAY,CONVERT(DATE,F.Fecha)),'/',DATEPART(MONTH,CONVERT(DATE,F.Fecha))) AS FechaAbreviada, ISNULL(SUM(TotalGeneral),0) AS TotalVentas
FROM tblFactura AS F
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE()))
GROUP BY CONCAT(DATEPART(DAY,CONVERT(DATE,F.Fecha)),'/',DATEPART(MONTH,CONVERT(DATE,F.Fecha))), CONVERT(DATE,F.Fecha)
ORDER BY CONVERT(DATE,F.Fecha) asc

END

GO

ALTER PROCEDURE VentasProductosPorCategoria
AS
BEGIN

SELECT DISTINCT CP.Nombre, ISNULL((SELECT SUM(AFD.Cantidad) FROM tblFacturaD AS AFD INNER JOIN tblProducto AS AP ON AFD.IdProducto = AP.IdProducto
INNER JOIN tblCategoriaP AS BCP ON AP.IdCategoriaP = BCP.IdCategoriaP WHERE AFD.IdFactura = FD.IdFactura AND BCP.IdCategoriaP = CP.IdCategoriaP),0) AS Cantidad
FROM tblFactura AS F
INNER JOIN tblFacturaD AS FD ON F.IdFactura = FD.IdFactura
INNER JOIN tblProducto AS P ON FD.IdProducto = P.IdProducto
INNER JOIN tblCategoriaP AS CP ON P.IdCategoriaP = P.IdCategoriaP
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE()))

END

go

ALTER PROCEDURE CantidadFacturasConySinDeudas
AS
BEGIN

(SELECT 'Pagadas' AS TipoFactura, ISNULL(COUNT(CASE WHEN F.Pago >= F.TotalGeneral THEN 1 END),0) AS Cantidad
FROM tblFactura AS F
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE())))
UNION
(SELECT 'Con deuda' AS TipoFactura, ISNULL(COUNT(CASE WHEN F.Pago < F.TotalGeneral THEN 1 END),0) AS Cantidad
FROM tblFactura AS F
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE())))

END

go

ALTER PROCEDURE Top5ProductosMasVendidos
AS
BEGIN

SELECT TOP (5) P.NombreProducto, ISNULL(SUM(D.Cantidad),0) AS Vendido
FROM     tblFacturaD AS D
INNER JOIN tblFactura AS F ON F.IdFactura = D.IdFactura
INNER JOIN tblProducto AS P ON D.IdProducto = P.IdProducto
WHERE CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-30,GETDATE()))
GROUP BY P.NombreProducto
ORDER BY Vendido DESC

END

go

ALTER PROCEDURE CargarProductos
AS
BEGIN

SELECT p.NombreProducto, p.NumExistencias,
ISNULL((SELECT SUM(FD.Cantidad) FROM tblFacturaD AS FD INNER JOIN tblFactura AS F ON FD.IdFactura = F.IdFactura WHERE FD.IdProducto = P.IdProducto 
AND CONVERT(DATE,F.Fecha) >= CONVERT(DATE,DATEADD(DAY,-15,GETDATE()))),0) AS CantVendidaUlt15, P.PrecioDetalle, P.PrecioMayor
FROM tblProducto AS P
ORDER BY CantVendidaUlt15 DESC

END