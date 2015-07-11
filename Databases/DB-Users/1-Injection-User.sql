USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [1-Injection-User]    Script Date: 7/11/2015 1:41:29 AM ******/
CREATE LOGIN [1-Injection-User] WITH PASSWORD=N'¢9ôÛ<=g®¸ÔvbûF	zTÔo¢I]9K', DEFAULT_DATABASE=[1-Injection], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

ALTER LOGIN [1-Injection-User] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [1-Injection-User]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [1-Injection-User]
GO

