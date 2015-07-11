USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [10-Redirects-User]    Script Date: 7/11/2015 1:41:19 AM ******/
CREATE LOGIN [10-Redirects-User] WITH PASSWORD=N'<`ð7d¡{#¨Yqlõè,³®z9á¿m', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [10-Redirects-User] DISABLE
GO

