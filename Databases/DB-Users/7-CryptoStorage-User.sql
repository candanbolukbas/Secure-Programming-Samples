USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [7-CryptoStorage-User]    Script Date: 7/11/2015 1:42:54 AM ******/
CREATE LOGIN [7-CryptoStorage-User] WITH PASSWORD=N'ç{:wÜæY@ÙF	ªY5ÆúhnC', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [7-CryptoStorage-User] DISABLE
GO

