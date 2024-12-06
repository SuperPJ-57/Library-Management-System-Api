create TABLE Users (
    UserId INT identity(1,1) PRIMARY KEY,
    Username VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Role nvarchar(10) NOT NULL CHECK (Role IN ('Admin'))
);


create table Students (
StudentId int identity(1,1) primary key,
Name varchar(255) not null,
Email varchar(255) unique not null,
ContactNumber varchar(15),
Department varchar(100)

);

create table Authors(
AuthorId int identity(1,1) primary key,
Name varchar(255) not null,
Bio Text

);

create table Books(
BookId int identity(1,1) primary key,
Title varchar(255) not null,
AuthorId int foreign key references Authors(AuthorId),
Genre varchar(100),
ISBN varchar(13) not null,
Quantity int default 1
);


create table Transactions(
TransactionId int identity(1,1) primary key,
StudentId int foreign key references Students(StudentId),
UserId int Foreign key references Users(UserID),
BookId int Foreign key references Books(BookId),
TransactionType varchar(10) not null check(TransactionType in ('Borrow','Return')),
Date DATE not null

);
