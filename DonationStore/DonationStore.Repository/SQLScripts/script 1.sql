select * from sys.tables

select * from AspNetUsers

exec sp_rename 'AspNetUsers.birthDate', 'BirthDate'

ALTER TABLE AspNetUsers ALTER COLUMN BirthDate datetime NULL;

--insert into AspNetRoles values (1,'User', 'USER', null),(2,'Admin', 'ADMIN', null)

ALTER TABLE AspNetUsers
DROP COLUMN UserId;
