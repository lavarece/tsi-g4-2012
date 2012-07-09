/* layouts */
insert into Layout (Id, Nombre, NombreLayout) values (1, 'Layout 1', 'layout_1'); 
insert into Layout (Id, Nombre, NombreLayout) values (2, 'Layout 2', 'layout_2');
insert into Layout (Id, Nombre, NombreLayout) values (3, 'Layout 3', 'layout_3');

/* tematicas */
insert into Tematica (Id, Nombre, NombreCSS) values (1, 'Ninguna', 'default');
insert into Tematica (Id, Nombre, NombreCSS) values (2, 'Naturaleza', 'naturaleza');
insert into Tematica (Id, Nombre, NombreCSS) values (3, 'Social', 'social');
insert into Tematica (Id, Nombre, NombreCSS) values (4, 'Tecnología', 'tecnologia');

/* grupos */
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No al abuso animal en circos y zoologicos', 'Todos vemos el maltrato a animales indefensos, a no quedarse callado! Sumate!', 'abuso.animal', '(-34.89043666790253, -56.17309534374999)', '242462659206537', 1, 1); 
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Protección al oso panda', 'Somos un grupo sudamericano unido para protejer a los osos pandas. Se estima que quedan sólo de 2000 osos pandas. Sumate a nuestra causa! ', 'zona.panda', '(-34.89043666790253, -56.17309534374999)', '149050938552132', 3, 2); 
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No a la contaminación lumínica', 'Nuestro fin es promover medidas para prevenir la contaminación luminica', 'contaminacion.luminica', '(-34.89043666790253, -56.17309534374999)', '', 3, 3);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Contra el monopolio informático', 'Evitemos el monopolio de las empresa informaticas, ayudanos a promover medidas!', 'contra.monopolio.informatico', '(-34.89043666790253, -56.17309534374999)', '', 2, 4);

/*variables sistema*/
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (1, 'Recursos más rankeados', '5')
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (2, 'Recursos compartidos', '5')
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (3, 'Dar de baja contenido', '5')
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (4, 'Dar de baja usuario', '5')

/*Atención: Las contraseñas encriptadas son: password*/

/*Administrador*/ 
INSERT INTO Administrador (Nombre, Password, Pregunta, Respuesta, Email) VALUES ('Super Administrador', '5gPNqhmBNpf/o5q8UUfhug==', 'Es el administrador?', 'Esta es la respuesta', 'super@hotmail.com')

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'juan@hotmail.com', 1, 'Juan', 'Miraballes', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'maxi@hotmail.com', 1, 'Maxi', 'Silvera', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'vanessa@hotmail.com', 1, 'Vanessa', 'Revetria', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'gonzalo@hotmail.com', 1, 'Gonzalo', 'Castro', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'andres@hotmail.com', 1, 'Andres', 'Aldao', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'juan@hotmail.com', 2, 'Juan', 'Miraballes', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'maxi@hotmail.com', 2, 'Maxi', 'Silvera', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'vanessa@hotmail.com', 2, 'Vanessa', 'Revetria', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'gonzalo@hotmail.com', 2, 'Gonzalo', 'Castro', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'andres@hotmail.com', 2, 'Andres', 'Aldao', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'juan@hotmail.com', 3, 'Juan', 'Miraballes', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'maxi@hotmail.com', 3, 'Maxi', 'Silvera', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'vanessa@hotmail.com', 3, 'Vanessa', 'Revetria', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'gonzalo@hotmail.com', 3, 'Gonzalo', 'Castro', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'andres@hotmail.com', 3, 'Andres', 'Aldao', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'juan@hotmail.com', 4, 'Juan', 'Miraballes', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'maxi@hotmail.com', 4, 'Maxi', 'Silvera', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'vanessa@hotmail.com', 4, 'Vanessa', 'Revetria', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'gonzalo@hotmail.com', 4, 'Gonzalo', 'Castro', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripción del usuario', 'andres@hotmail.com', 4, 'Andres', 'Aldao', '5gPNqhmBNpf/o5q8UUfhug==', '', '(-34.89043666790253, -56.17309534374999)', '', 22/05/2012);