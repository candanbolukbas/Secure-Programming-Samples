USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [6-SecurityMisconfig-User]    Script Date: 7/11/2015 1:42:33 AM ******/
CREATE LOGIN [6-SecurityMisconfig-User] WITH PASSWORD=N'Ù\.º±Íº«ÈiTMÉ*ÑázúïààÒ', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [6-SecurityMisconfig-User] DISABLE
GO

