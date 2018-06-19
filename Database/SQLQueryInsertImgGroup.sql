insert 
into dbo.Personal	(
					firstName, 
					secondName, 
					photo,
					format_photo
					)
	select 'Наталья', 'Кошина', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\nataly.jpg', 
		single_blob
		) as mfile
	union all
	select 'Илона', 'Новикова', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\ilona.jpg', 
		single_blob
		) as mfile
	union all
	select 'Анна', 'Кузнецова', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\anna.jpg', 
		single_blob
		) as mfile
	union all
		select 'Иван', 'Гусев', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\ivan.jpg', 
		single_blob
		) as mfile
	union all
		select 'Степан', 'Логовой', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\stepan.jpg', 
		single_blob
		) as mfile
	union all
		select 'Екатерина', 'Дорохова', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\kate.jpg', 
		single_blob
		) as mfile
	union all
		select 'Василий', 'Шохин', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\Сергей\Documents\GitHub\MyC#\Lab_02\Eleot\Database\vasil.jpg', 
		single_blob
		) as mfile