use ButterflyShopDatabase;
go

insert Users (Email, Password, FirstName, RoleId)
values ('abfly@ukr.net', dbo.MD5HashPassword('QwErty123'), N'Администратор', dbo.GetUserRoleId(N'Администратор'))

