SELECT obj.type_desc, 
       obj.NAME, 
       types.NAME, 
       col.* 
FROM   sys.objects obj 
       INNER JOIN sys.columns col 
               ON obj.object_id = col.object_id 
       INNER JOIN sys.types types 
               ON col.system_type_id = types.system_type_id 
WHERE  obj.is_ms_shipped <> 1 
ORDER  BY obj.NAME, 
          col.column_id 