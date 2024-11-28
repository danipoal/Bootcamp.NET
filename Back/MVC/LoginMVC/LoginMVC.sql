-- Crear la tabla Usuario
CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,                  
    UserName NVARCHAR(50) NOT NULL UNIQUE,   
	[Pwd] NVARCHAR(255) NOT NULL,             
    Apellido NVARCHAR(100),                 
    Email NVARCHAR(255),               
    FechaNacimiento DATE,                            
    Telefono NVARCHAR(20),                           
    Direccion NVARCHAR(255),                         
    Ciudad NVARCHAR(100),                            
    Estado NVARCHAR(100),                            
    CodigoPostal NVARCHAR(10),                       
    FechaRegistro DATETIME DEFAULT GETDATE(),        
    Activo BIT DEFAULT 1                             
);

INSERT INTO Usuario (UserName, Pwd, Apellido, Email, 
					FechaNacimiento, Telefono, Direccion, 
					Ciudad, Estado, CodigoPostal, FechaRegistro, Activo)
VALUES (
    'user',                    
    '123',                     
    'Perez',                   
    'testuser@example.com',    
    '1990-01-01',              
    '555-1234',                
    '123 Calle Falsa',         
    'Ciudad Ficticia',         
    'Estado Ficticio',         
    '12345',                   
    GETDATE(),                 
    1                          
);

-- SALT & HASH
/*
DROP TABLE Usuario;

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,                  
    UserName NVARCHAR(50) NOT NULL UNIQUE,   
	PasswordHash VARBINARY(MAX) NOT NULL,
    PasswordSalt VARBINARY(MAX) NOT NULL,         
    Apellido NVARCHAR(100),                 
    Email NVARCHAR(255),               
    FechaNacimiento DATE,                            
    Telefono NVARCHAR(20),                           
    Direccion NVARCHAR(255),                         
    Ciudad NVARCHAR(100),                            
    Estado NVARCHAR(100),                            
    CodigoPostal NVARCHAR(10),                       
    FechaRegistro DATETIME DEFAULT GETDATE(),        
    Activo BIT DEFAULT 1                             
);
*/
