-- Creación de la tabla Trabajadores
CREATE TABLE Trabajadores (
    idtrab INT PRIMARY KEY,
    trabNombre VARCHAR(50) NOT NULL,
    trabApellido VARCHAR(50) NOT NULL,
    trabDireccion VARCHAR(100),
    trabPuesto VARCHAR(50),
    trabHorario VARCHAR(50),
    trabCorreo VARCHAR(50),
    trabSexo CHAR(1),
    trabTel VARCHAR(15),
    trabFechNa DATE
);

-- Creación de la tabla Pacientes
CREATE TABLE Pacientes (
    idpac INT PRIMARY KEY,
    pacNombre VARCHAR(50) NOT NULL,
    pacApellido VARCHAR(50) NOT NULL,
    pacDireccion VARCHAR(100),
    pacSexo CHAR(1),
    pacGS VARCHAR(50),
    pacFechRegistro DATE
);

-- Creación de la tabla Atendido
CREATE TABLE Atendido (
    TrabajadorId INT NOT NULL,
    PacienteId INT NOT NULL,
    PRIMARY KEY (TrabajadorId, PacienteId),
    FOREIGN KEY (TrabajadorId) REFERENCES Trabajadores(id),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(id)
);

-- Creación de la tabla Citas
CREATE TABLE Citas (
    idCita INT PRIMARY KEY,
    PacienteID INT NOT NULL,
    TrabajadorID INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Duracion INT NOT NULL,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(id),
    FOREIGN KEY (TrabajadorID) REFERENCES Trabajadores(id)
);
