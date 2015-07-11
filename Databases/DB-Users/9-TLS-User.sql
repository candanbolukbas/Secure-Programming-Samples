USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [9-TLS-User]    Script Date: 7/11/2015 1:43:26 AM ******/
CREATE LOGIN [9-TLS-User] WITH PASSWORD=N'å[ÉËoqêèê;ìEñÞ¬I»R£_D:Í', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [9-TLS-User] DISABLE
GO

