use FurnitureDatabase;
go

insert Users (Email, Password, FirstName, RoleId)
values ('admin@gmail.com', dbo.MD5HashPassword('qwerty'), N'Администратор', dbo.GetUserRoleId(N'Администратор'))

