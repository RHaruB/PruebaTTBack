USE [prueba]
GO

INSERT INTO [dbo].[Departamentos]
           ([codigo]
           ,[nombre]
           ,[activo]
           ,[idUsuarioCreacion])
     VALUES
          
           ('ADM', 'Administración',1,1),
           ('VNT', 'Ventas',1,1),
           ('TI', 'Sistemas',1,1),
           ('CBR', 'Cobros',1,1),
           ('LGL', 'Legal',1,1)
GO


