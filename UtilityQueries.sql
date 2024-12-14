use LMS;
select *from users;
select *from authors;

select *from Transactions;
select *from Students;
select *from BookCopies;
select *from books;

--exec Sp_BookInstance @flag='D',@barcode=1111111;

--exec Sp_Transactions @flag='S', @TransactionId=19;

--update Transactions set DueDate = (select DATEADD(week,2,T.Date) from Transactions T where Transactions.TransactionId = T.TransactionId);

--update transactions set status = 'Active' where status = '0';

--update BookCopies set IsAvailable = 0 where IsDeleted = 1;
--update books set quantity = 2 where bookid = 2;
--delete from Transactions;
--update bookcopies set IsAvailable = 1;


--exec Sp_BookInstance @flag='I', @BookId = 1, @BarCode=62313435;
--exec Sp_BookInstance @flag='I', @BookId = 3, @BarCode=32313435;
--exec Sp_BookInstance @flag='I', @BookId = 6, @BarCode=52313435;

--exec Sp_BookInstance @flag='I', @BookId = 4, @BarCode=72313435;



--exec Sp_BookInstance @flag='S'
--select *from books;
--select books.title,count(bc.bookid) from 
--books join BookCopies bc on books.BookId=bc.BookId 
--group by title ;
--update books set quantity = 5 where BookId = 3
--SELECT 
--    fk.name AS FK_name,
--    tp.name AS Table_name,
--    ref.name AS Referenced_table
--FROM 
--    sys.foreign_keys AS fk
--INNER JOIN 
--    sys.tables AS tp ON fk.parent_object_id = tp.object_id
--INNER JOIN 
--    sys.tables AS ref ON fk.referenced_object_id = ref.object_id
--WHERE 
--    tp.name = 'bookcopies'; -- Replace with the name of your table

--	ALTER TABLE bookcopies DROP CONSTRAINT FK__BookCopie__BookI__6754599E;

--	delete from Transactions

--select 1 from Transactions where StudentId = 2 and BarCode = 34234234 and status in ('Overdue','Active')  ;


--exec sp_authors @flag='U', @AuthorId=6, @Name='Bp Koirala';

--exec sp_books @flag='U', @BookId = 6, @AuthorId=6,@Genre = 'Academic';

--exec Sp_BookInstance @flag='S',@BarCode=1111111;