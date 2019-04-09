CREATE PROC AddUser
@username nvarchar(50),
@password nvarchar(50),
	@name	nvarchar(50),	
	@surname	nvarchar(50),	
	@phone	nchar(10),	
	@adress	nvarchar(50)	
		

AS
   INSERT INTO login(username, password, name, surname, phone, adress)
   VALUES (@username, @password, @name, @surname, @phone, @adress)