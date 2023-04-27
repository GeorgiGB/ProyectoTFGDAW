-- Creación de la tabla Trabajadores
CREATE TABLE Trabajadores (
    id INT PRIMARY KEY IDENTITY(1,1),
    trabNombre VARCHAR(50) NOT NULL,
    trabApellido VARCHAR(50) NOT NULL,
    trabDireccion VARCHAR(100),
    trabPuesto VARCHAR(50) NOT NULL,
    trabHorario VARCHAR(50) NOT NULL,
    trabCorreo VARCHAR(100) NOT NULL,
    trabSexo CHAR(1) NOT NULL,
    trabTel VARCHAR(20) NOT NULL,
    trabFechNa DATE NOT NULL
);

-- Creación de la tabla Usuarios
CREATE TABLE Usuarios (
    id INT PRIMARY KEY IDENTITY(1,1),
    usuNombre VARCHAR(50) NOT NULL,
    usuPwd VARCHAR(50) NOT NULL,
    usuRol VARCHAR(50) NOT NULL,
    usuTrabId INT NOT NULL,
    CONSTRAINT FK_Usuarios_Trabajadores FOREIGN KEY (usuTrabId) REFERENCES Trabajadores(id)
);

-- Creación de la tabla Pacientes
CREATE TABLE Pacientes (
    id INT PRIMARY KEY IDENTITY(1,1),
    pacNombre VARCHAR(50) NOT NULL,
    pacApellido VARCHAR(50) NOT NULL,
    pacDireccion VARCHAR(100),
    pacSexo CHAR(1) NOT NULL,
    pacGS VARCHAR(50),
    pacFechRegistro DATE NOT NULL
);

-- Creación de la tabla Citas
CREATE TABLE Citas (
    id INT PRIMARY KEY IDENTITY(1,1),
    PacienteID INT NOT NULL,
    TrabajadorID INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Duracion INT NOT NULL,
    CONSTRAINT FK_Citas_Pacientes FOREIGN KEY (PacienteID) REFERENCES Pacientes(id),
    CONSTRAINT FK_Citas_Trabajadores FOREIGN KEY (TrabajadorID) REFERENCES Trabajadores(id)
);

-- Creación de la tabla Atendido
CREATE TABLE Atendido (
    TrabajadorID INT NOT NULL,
    PacienteID INT NOT NULL,
    PRIMARY KEY (TrabajadorID, PacienteID),
    CONSTRAINT FK_Atendido_Trabajadores FOREIGN KEY (TrabajadorID) REFERENCES Trabajadores(id),
    CONSTRAINT FK_Atendido_Pacientes FOREIGN KEY (PacienteID) REFERENCES Pacientes(id)
);
