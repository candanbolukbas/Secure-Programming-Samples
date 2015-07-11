USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [8-URLAccess-User]    Script Date: 7/11/2015 1:43:10 AM ******/
CREATE LOGIN [8-URLAccess-User] WITH PASSWORD=N'2°]MP9`æÝA''ÕfàEF1ÎOh,Qâ', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [8-URLAccess-User] DISABLE
GO

