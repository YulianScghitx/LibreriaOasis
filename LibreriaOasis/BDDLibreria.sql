DROP TABLE IF EXISTS Ventas_Libros;
DROP TABLE IF EXISTS Ventas;
DROP TABLE IF EXISTS Libros;
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS Sucursales;
DROP TABLE IF EXISTS Comunas;
DROP TABLE IF EXISTS Regiones;
DROP TABLE IF EXISTS Categorias;
DROP TABLE IF EXISTS TipoUsuarios;

------------------------CREACION DE TABLAS---------------------------------------
CREATE TABLE TipoUsuarios (
    id INT PRIMARY KEY IDENTITY,
    nombre VARCHAR(256) NOT NULL
);

CREATE TABLE Categorias (
    id INT PRIMARY KEY IDENTITY,
    nombre VARCHAR(256) NOT NULL
);

CREATE TABLE Regiones (
    id INT PRIMARY KEY IDENTITY,
    nombre VARCHAR(256) NOT NULL
);

CREATE TABLE Comunas (
    id INT PRIMARY KEY IDENTITY,
    nombre VARCHAR(256) NOT NULL,
    region INT NOT NULL,
    CONSTRAINT FK_Comunas_Region FOREIGN KEY (region) REFERENCES Regiones(id)
);

CREATE TABLE Sucursales (
    id INT PRIMARY KEY IDENTITY,
    nombre VARCHAR(256) NOT NULL,
    comuna INT NOT NULL,
    CONSTRAINT FK_Sucursales_Comuna FOREIGN KEY (comuna) REFERENCES Comunas(id)
);

CREATE TABLE Usuarios (
    rut VARCHAR(40) PRIMARY KEY,
    primer_nombre VARCHAR(256) NOT NULL,
    segundo_nombre VARCHAR(256),
    apellido_paterno VARCHAR(256) NOT NULL,
    apellido_materno VARCHAR(256) NOT NULL,
    contrasena VARCHAR(256) NOT NULL,
    correo VARCHAR(256) NOT NULL UNIQUE,
    numero_telefono VARCHAR(40) NOT NULL,
    activo BIT NOT NULL,
    comuna INT NOT NULL,
    tipo_usuario INT NOT NULL,
    CONSTRAINT FK_Usuarios_Comuna FOREIGN KEY (comuna) REFERENCES Comunas(id),
    CONSTRAINT FK_Usuarios_TipoUsuario FOREIGN KEY (tipo_usuario) REFERENCES TipoUsuarios(id)
);

CREATE TABLE Libros (
    id INT PRIMARY KEY IDENTITY,
    categoria INT NOT NULL,
    stock INT NOT NULL,
    sucursal INT NOT NULL,
    nombre VARCHAR(256) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    fecha DATETIME NOT NULL,
    imagen VARCHAR(256),
    CONSTRAINT FK_Libros_Categorias FOREIGN KEY (categoria) REFERENCES Categorias(id),
    CONSTRAINT FK_Libros_Sucursales FOREIGN KEY (sucursal) REFERENCES Sucursales(id)
);

CREATE TABLE Ventas (
    id INT PRIMARY KEY IDENTITY,
    saldo NUMERIC (12,0) NOT NULL,
    fecha DATETIME NOT NULL,
    rut_usuario INT NOT NULL,
    CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY (rut_usuario) REFERENCES Usuarios(rut),
);

CREATE TABLE Ventas_Libros(
    id_ventas INT NOT NULL,
    id_libros INT NOT NULL,
    cantidad INT NOT NULL,
    CONSTRAINT FK_Ventas_Libros_Ventas FOREIGN KEY (id_ventas) REFERENCES Ventas(id),
    CONSTRAINT FK_Ventas_Libros_Libros FOREIGN KEY (id_libros) REFERENCES Libros(id)
);

---POBLADO DE LA BASE DE DATOS
INSERT INTO Regiones (nombre) VALUES ('Region Metropolitana');
INSERT INTO Comunas (nombre, region) VALUES ('Maipu',1);
INSERT INTO Comunas (nombre, region) VALUES ('Providencia',1);
INSERT INTO Sucursales (nombre, comuna) VALUES ('Sucursal Central',1);
INSERT INTO TipoUsuarios (nombre) VALUES ('ADMIN');
INSERT INTO TipoUsuarios (nombre) VALUES ('CLIENTE');
---EJEMPLO DE JSON USUARIOS
/*
{
    "rut"              : "19.960.758-8",
    "primer_nombre"    : "Julian",
    "segundo_nombre"   : "Matias",
    "apellido_paterno" : "Ortega",
    "apellido_materno" : "Silva",
    "contrasena"       : "admin123",
    "correo"           : "netox1998@gmail.com",
    "numero_telefono"  : "+56972605993",
    "comuna"           : 1
}
*/