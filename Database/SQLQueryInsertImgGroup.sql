insert 
into dbo.Personal	(
					firstName, 
					secondName, 
					photo,
					format_photo
					)
	select '�������', '������', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\nataly.jpg', 
		single_blob
		) as mfile
	union all
	select '�����', '��������', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\ilona.jpg', 
		single_blob
		) as mfile
	union all
	select '����', '���������', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\anna.jpg', 
		single_blob
		) as mfile
	union all
		select '����', '�����', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\ivan.jpg', 
		single_blob
		) as mfile
	union all
		select '������', '�������', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\stepan.jpg', 
		single_blob
		) as mfile
	union all
		select '���������', '��������', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\kate.jpg', 
		single_blob
		) as mfile
	union all
		select '�������', '�����', BulkColumn, 'image/jpg'
		from OpenRowSet
		(
		bulk N'c:\Users\������\Documents\GitHub\MyC#\Lab_02\Eleot\Database\vasil.jpg', 
		single_blob
		) as mfile