use Administracion
go
--procedimiento almacenado  de actualizar articulos

CREATE PROCEDURE ActualizarArticulos
@id_pro   int,
@nom_prod varchar(100),
@precio   float
as
--actualiza artículos
if not exists (select id_pro from Articulo where id_pro=@id_pro)
insert into Articulo (id_pro,Nom_pro,Precio) values (@id_pro,@nom_prod,@precio)

else
update Articulo set id_pro = @id_pro,
                    Nom_pro= @nom_prod,
					 Precio= @precio

go


--*******************procedimineto que elimine Artículos************

CREATE PROCEDURE EliminaArticulos
@Id_Pro   int
as
delete from  Articulo where id_pro = @Id_Pro
go



--Actualiza clientes
CREATE PROCEDURE ActualizarClientes
@id_cli int,
@nombre varchar(100),
@Ape_cli varchar(100)
as 
if not exists (select id_clientes from Cliente where id_clientes=@id_cli)
insert into Cliente(id_clientes,Nom_cli,Ape_cli) values (@id_cli,@nombre,@Ape_cli)
else
update Cliente set  id_clientes = @id_cli,
                    Nom_cli= @nombre,
					Ape_cli= @Ape_cli

go

--*******************procedimineto que elimine cuentas************

CREATE PROCEDURE EliminaClientes
@id_cli int 
as 
delete from Cliente where id_clientes=@id_cli
go
--//==================Actulice============================
CREATE PROCEDURE ActualizarDetalles
@NumFact      int,
@CodPro       int,
@PrecioVenta  float,
@CanVent      float
as
insert into Detalles (NumFac,CodPro,PrecioVenta,CantVenta) values(
@NumFact,@CodPro,@PrecioVenta,@CanVent)
go

--//Actulizar facturas----
CREATE PROCEDURE ActualizarFacturas
@CodCli     int
as
declare @NumFact int
select @NumFact =max(NumFact)from Facturas

if @NumFact is null set @NumFact=0
set @NumFact = @NumFact+1

insert into Facturas(NumFact,FecFac,CodCli) values (@NumFact,getdate(),@CodCli)
select * from Facturas where NumFact= @NumFact
go
---//recolectar mis datos facturacion

CREATE PROCEDURE DatosFactura
@NumFact int
as
select f.*,D.PrecioVenta, D.CantVenta,C.Nom_cli,A.Nom_pro,D.PrecioVenta*D.CantVenta as Importe

from Facturas F inner join Detalles D on f.NumFact=d.NumFac
inner join Articulo A on d.CodPro=a.id_pro
inner join  Cliente C on f.CodCli=C.id_clientes
where @NumFact=@NumFact