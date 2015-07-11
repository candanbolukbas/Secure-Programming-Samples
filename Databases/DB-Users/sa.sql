USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [sa]    Script Date: 7/11/2015 1:43:34 AM ******/
CREATE LOGIN [sa] WITH PASSWORD=N'½à>¾I ÂPJÔ/ú¿âQÕ@áy.GÝüX', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

ALTER LOGIN [sa] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [sa]
GO

