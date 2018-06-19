declare @ptrnewval varbinary(max)
set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\nataly.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=1

set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\ilona.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=2

set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\anna.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=3

set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\ivan.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=4

set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\stepan.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=5

set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\kate.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=10

set @ptrnewval= (SELECT BulkColumn 
				FROM OPENROWSET 
				(BULK N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\vasil.jpg', SINGLE_BLOB) AS T
				)
update dbo.Personal
set photo=@ptrnewval
where id_person=11
