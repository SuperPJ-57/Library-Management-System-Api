create TABLE Users (
    UserId INT identity(1,1) PRIMARY KEY,
    Username VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Role nvarchar(10) NOT NULL CHECK (Role IN ('Admin'))
);
create nonclustered index idx_users on users(username,email);



--drop table students;
create table Students (
StudentId int identity(1,1) primary key,
Name varchar(255) not null,
Email varchar(255) unique not null,
ContactNumber varchar(15),
Department varchar(100)

);
create nonclustered index idx_students on students(Name,email,contactnumber);
alter table students add  IsDeleted bit default 0;

create table Authors(
AuthorId int identity(1,1) primary key,
Name varchar(255) not null,
Bio Text

);
alter table authors add  IsDeleted bit default 0;

create table Books(
BookId int identity(1,1) primary key,
Title varchar(255) not null,
AuthorId int foreign key references Authors(AuthorId),
Genre varchar(100),
ISBN varchar(13) not null,
Quantity int default 1
);
create nonclustered index idx_books on books(title);

alter table books add constraint uniq_isbn unique (isbn);
alter table Books add constraint fk_aid
foreign key(AuthorId) references Authors(AuthorId);

--quantity = 0 is book deletion

create table Transactions(
TransactionId int identity(1,1) primary key,
StudentId int foreign key references Students(StudentId),
UserId int Foreign key references Users(UserID),
BookId int Foreign key references Books(BookId),
TransactionType varchar(10) not null check(TransactionType in ('Borrow','Return')),
create nonclustered index idx_transactions on transactions(TransactionType,StudentId,status);

Date DATE not null,
Barcode int 
);

alter table transactions add DueDate DATE ;
alter table transactions alter column DueDate Date not null;

alter table transactions add constraint
fk_barcode foreign key(BarCode)
references BookCopies(BarCode);

alter table transactions add constraint
fk_Sid foreign key(StudentId)
references Students(StudentId);


alter table transactions add constraint
fk_Uid foreign key(UserId)
references Users(UserId);


alter table transactions add constraint
fk_Bid foreign key(BookId)
references Books(BookId);

alter table transactions add Status Bit;
alter table transactions alter column status varchar(10);

alter table transactions add constraint chk_status 
check (Status in ('Active','Completed','Overdue'));






----------------------------------------------------
create table BookCopies(
	BarCode int primary key  not null,
	BookId int foreign key references Books(BookId),
	IsAvailable BIT default 1

);
create nonclustered index idx_bookcopies on bookcopies(bookid);
alter table BookCopies add IsDeleted BIT default 0;



create table DailyFirstLogin(
Date Date primary key,
flag bit default 0

);