CREATE TABLE [User] (
    IdUser int IDENTITY(1,1) PRIMARY KEY,
    UserName varchar(255) UNIQUE NOT NULL,
    Email varchar(255) UNIQUE NOT NULL,
    PasswordHash varbinary(MAX),
    PasswordSalt varbinary(MAX),
    BirthDate date,
    ProfileImageUrl varchar(255)
);

CREATE TABLE Follow (
    IdFollower int,
    IdFollowed int,
    PRIMARY KEY (IdFollower, IdFollowed),
    FOREIGN KEY (IdFollower) REFERENCES User(IdUser),
    FOREIGN KEY (IdFollowed) REFERENCES User(IdUser)
);

CREATE TABLE BookList (
    IdBookList int IDENTITY(1,1) PRIMARY KEY,
    ListName varchar(255) NOT NULL,
    FkIdUser int NOT NULL,
    FOREIGN KEY (FkIdUser) REFERENCES User(IdUser)
);

CREATE TABLE Book (
    IdBook int PRIMARY KEY,
    Title varchar(255),
    Author varchar(255),
    ImageLink varchar(255),
    Subtitle varchar(255),
    Category varchar(255),
    Editorial varchar(255),
    NumberPages int,
    Score double precision
);

CREATE TABLE BookList_Book (
    FkIdBookList int,
    FkIdBook int,
    PRIMARY KEY (FkIdBookList, FkIdBook),
    FOREIGN KEY (FkIdBookList) REFERENCES BookList(IdBookList),
    FOREIGN KEY (FkIdBook) REFERENCES Book(IdBook)
);

CREATE TABLE Review (
    IdReview int PRIMARY KEY,
    Comment text,
    FkIdBook int,
    FkIdUser int,
    FOREIGN KEY (FkIdBook) REFERENCES Book(IdBook),
    FOREIGN KEY (FkIdUser) REFERENCES User(IdUser)
);

CREATE TABLE Publication (
    IdPublication int PRIMARY KEY,
    Title varchar(255),
    Content text,
    PublicationImageUrl varchar(255),
    FkIdUser int,
    FOREIGN KEY (FkIdUser) REFERENCES User(IdUser)
);

CREATE TABLE PublicationLikes (
    FkIdUser int,
    FkIdPublication int,
    PRIMARY KEY (FkIdUser, FkIdPublication),
    FOREIGN KEY (FkIdUser) REFERENCES User(IdUser),
    FOREIGN KEY (FkIdPublication) REFERENCES Publication(IdPublication)
);

CREATE TABLE Category (
    IdCategory int PRIMARY KEY,
    CategoryName varchar(255)
);

CREATE TABLE Book_Category (
    FkIdCategory int,
    FkIdBook int,
    PRIMARY KEY (FkIdCategory, FkIdBook),
    FOREIGN KEY (FkIdCategory) REFERENCES Category(IdCategory),
    FOREIGN KEY (FkIdBook) REFERENCES Book(IdBook)
);
