

select *from users;
select *from authors;
select *from books;
select *from Transactions;
select *from Students;
select *from BookCopies;

update BookCopies set IsAvailable = 0 where IsDeleted = 1;
update books set quantity = 2 where bookid = 2;
delete from Transactions;
update bookcopies set IsAvailable = 1;


exec Sp_BookInstance @flag='I', @BookId = 1, @BarCode=62313435;
exec Sp_BookInstance @flag='I', @BookId = 3, @BarCode=32313435;
exec Sp_BookInstance @flag='I', @BookId = 6, @BarCode=52313435;

exec Sp_BookInstance @flag='I', @BookId = 4, @BarCode=72313435;

drop table test;

truncate table student;



SELECT 
    fk.name AS FK_name,
    tp.name AS Table_name,
    ref.name AS Referenced_table
FROM 
    sys.foreign_keys AS fk
INNER JOIN 
    sys.tables AS tp ON fk.parent_object_id = tp.object_id
INNER JOIN 
    sys.tables AS ref ON fk.referenced_object_id = ref.object_id
WHERE 
    tp.name = 'bookcopies'; -- Replace with the name of your table

	ALTER TABLE bookcopies DROP CONSTRAINT FK__BookCopie__BookI__6754599E;

	delete from Transactions