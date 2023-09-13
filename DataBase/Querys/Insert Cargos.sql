USE [prueba]
GO

INSERT INTO [dbo].[Cargos]
           ([codigo]
           ,[nombre]
           ,[activo]
           ,[idUsuarioCreacion])
     VALUES
           ('CA1', 'Administrador',1,1),
		   ('CA2', 'Cobrador',1,1),
		   ('CA3', 'Cajero',1,1),
		   ('CA4', 'Tesorero',1,1),
		   ('CA5', 'Gerente',1,1),
		   ('CA6', 'Repartidor',1,1),
	       ('CA7', 'Abogado',1,1),
	 	   ('CA8', 'Contador',1,1),
		   ('CA8', 'Conductor',1,1),
		   ('CA10', 'Desarrollador',1,1)
GO


