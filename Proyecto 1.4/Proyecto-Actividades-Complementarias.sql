CREATE DATABASE Creditos_Complementarios;

USE Creditos_Complementarios;

CREATE TABLE Carrera
(Id_Carrera Varchar(4) PRIMARY KEY,
 Nombre_Carrera VARCHAR(50)
)

CREATE TABLE Actividades_Complementarias
(Id_Actividad varchar(10) PRIMARY KEY,
 Nombre_Actividad VARCHAR(50),
 Fundamento_Actividad TEXT,
 Cant_Creditos INT
)

CREATE TABLE Docente
(Id_Docente INT PRIMARY KEY,
 Nombre VARCHAR(20),
 Ape_Pat VARCHAR(20),
 Ape_Mat VARCHAR(20)
)

CREATE TABLE Desempenio
(
Id_desempenio int primary key,
Desempenio_significado varchar(40)
)
CREATE TABLE Alumnos
(No_Control INT PRIMARY KEY,
 Nombre VARCHAR(20),
 Ape_Pat VARCHAR(20),
 Ape_Mat VARCHAR(20),
 Id_Carrera VARCHAR(4) FOREIGN KEY REFERENCES Carrera(Id_Carrera)
)

CREATE TABLE Creditos
(Id_Creditos INT PRIMARY KEY identity(1,1),
 No_Control INT FOREIGN KEY REFERENCES Alumnos(No_Control),
 Id_Actividad varchar(10) FOREIGN KEY REFERENCES Actividades_Complementarias(Id_Actividad), 
 Calificacion_Numerica INT,
 Cant_Creditos INT,
 Id_docente INT FOREIGN KEY REFERENCES Docente(Id_Docente), 
 Id_desempenio int foreign key references Desempenio(Id_desempenio),
 Periodo_Escolar VARCHAR(40),
 Fecha_Creacion DATEtime
)

CREATE TABLE Docente_Actividades
(Id_Docente_Actividades INT PRIMARY KEY identity(1,1),
Id_Docente INT FOREIGN KEY REFERENCES Docente(Id_Docente),
 Id_Actividad varchar(10) FOREIGN KEY REFERENCES Actividades_Complementarias(Id_Actividad),
)

INSERT INTO Carrera(Id_Carrera, Nombre_Carrera) VALUES
('ARQU', 'Arquitectura'),
('COPU', 'Contador P�blico'),
('IAMB', 'Ingenier�a Ambiental'),
('IARO', 'Ingenier�a Aeron�utica'),
('IBIO', 'Ingenier�a Biom�dica'),
('IBQA', 'Ingenier�a Bioqu�mica'),
('ICIV', 'Ingenier�a Civil'),
('IEDI', 'Ingenier�a en Dise�o Industrial'),
('IELC', 'Ingenier�a Electr�nica'),
('IEME', 'Ingenier�a Electromec�nica'),
('IGEM', 'Ingenier�a en Gesti�n Empresarial'),
('IINF', 'Ingenier�a Inform�tica'),
('ISIC', 'Ingenier�a en Sistemas Computacionales');

Insert into Desempenio(Id_desempenio,Desempenio_significado)VALUES
(1,'Insuficiente'),(2,'Regular'),(3,'Bueno'),(4,'Excelente');

Insert into Docente(Id_Docente,Nombre, Ape_Pat,Ape_Mat) VALUES
(1,'Maria Concepci�n','Ibarra','Gamiz');

insert into Actividades_Complementarias(Id_Actividad,Nombre_Actividad,Fundamento_Actividad,Cant_Creditos)values
('ACTUDSC','Tutor�a','La tutor�a es un programa que permite la mejora del proceso de aprendizaje por los estudiantes, permite apoyarlos en los �mbitos psicol�gicos, psicopedag�gico, familiar social y econ�mico.',1);

