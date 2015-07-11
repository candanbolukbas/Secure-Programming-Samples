USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [3-BrokenAuth-User]    Script Date: 7/11/2015 1:41:46 AM ******/
CREATE LOGIN [3-BrokenAuth-User] WITH PASSWORD=N'°Òl|HºÝØÿó&È
äz)ÂÏ£ådú¦Ø', DEFAULT_DATABASE=[3-BrokenAuth], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [3-BrokenAuth-User] DISABLE
GO

