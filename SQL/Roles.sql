if not exists(select * from sys.database_principals where name = 'admin')
BEGIN
CREATE LOGIN admin
	WITH PASSWORD = 'admin';
USE BookStoreDb;
CREATE USER admin FOR LOGIN admin;
EXEC sp_addrolemember N'db_datareader', N'admin';
EXEC sp_addrolemember N'db_datawriter', N'admin';
END;


IF not exists(select * from sys.database_principals where name = 'operator')
BEGIN
CREATE LOGIN operator
	WITH PASSWORD = 'operator';
USE BookStoreDb;
CREATE USER operator FOR LOGIN operator;
EXEC sp_addrolemember N'db_datareader', N'operator';
GRANT SELECT, INSERT, UPDATE, DELETE ON Sklyar_A.actions TO operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON Sklyar_A.cards TO operator; 
GRANT SELECT, INSERT, UPDATE, DELETE ON Sklyar_A.contractors TO operator; 
GRANT SELECT, INSERT, UPDATE, DELETE ON Sklyar_A.doc_types TO operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON Sklyar_A.entity_contr TO operator; 
GRANT SELECT, INSERT, UPDATE, DELETE ON Sklyar_A.individ_contr TO operator;
END