USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [4-DirectObjRef-User]    Script Date: 7/11/2015 1:42:05 AM ******/
CREATE LOGIN [4-DirectObjRef-User] WITH PASSWORD=N'åÔÉ)ª½kÜwü]4îbCÖQ­¦9Zföóæ', DEFAULT_DATABASE=[4-DirectObjRef], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [4-DirectObjRef-User] DISABLE
GO

