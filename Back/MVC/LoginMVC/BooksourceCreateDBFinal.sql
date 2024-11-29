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
    FOREIGN KEY (IdFollower) REFERENCES [User](IdUser),
    FOREIGN KEY (IdFollowed) REFERENCES [User](IdUser)
);

CREATE TABLE BookList (
	IdBookList int IDENTITY(1,1) PRIMARY KEY,
	ListName varchar(255) NOT NULL,
	FkIdUser int NOT NULL,
	FOREIGN KEY (FkIdUser) REFERENCES [User](IdUser)
);

CREATE TABLE Book (
	IdBook int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255) NOT NULL,
	Author varchar(255) NOT NULL,
	ImageLink varchar(255) NOT NULL,
	Subtitle varchar(255),

);

CREATE TABLE BookList_Book (
	FkIdBookList int,
	FkIdBook int,
	PRIMARY KEY (FkIdBookList, FkIdBook),
	FOREIGN KEY (FkIdBookList) REFERENCES BookList(IdBookList),
	FOREIGN KEY (FkIdBookList) REFERENCES Book(IdBook)
);