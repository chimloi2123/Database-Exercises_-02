SELECT so.name as TableName
      ,si.name as IndexName
	  ,si.type_desc as IndexType
	FROM SYS.indexes si join sys.objects so on si.[object_id]=so.[object_id]
	where so.type='U' and si.name is not null
	order by so.name,si.type