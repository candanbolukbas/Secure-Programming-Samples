USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [5-CSRF-User]    Script Date: 7/11/2015 1:42:17 AM ******/
CREATE LOGIN [5-CSRF-User] WITH PASSWORD=N'³i¼8hÝ Ã''QI4JØf}ª.¨¾Zp\àVÊ¿è', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [5-CSRF-User] DISABLE
GO

