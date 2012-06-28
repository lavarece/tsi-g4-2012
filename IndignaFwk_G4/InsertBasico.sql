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
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Protección al oso panda', 'Somos un grupo sudamericano unido para protejer a los osos pandas. Se estima que quedan sólo de 2000 osos pandas. Sumate a nuestra causa! ', 'zona.panda', '(-34.89043666790253, -56.17309534374999)', '149050938552132', 1, 2); 
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No a la contaminación lumínica', 'Nuestro fin es promover medidas para prevenir la contaminación luminica', 'contaminacion.luminica', '(-34.89043666790253, -56.17309534374999)', '', 1, 3);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Contra el monopolio informático', 'Evitemos el monopolio de las empresa informaticas, ayudanos a promover medidas!', 'contra.monopolio.informatico', '(-34.89043666790253, -56.17309534374999)', '', 1, 4);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Contra el abuso infantil', 'NO al abuso infantil!', 'no.abuso', '-34.831841,-56.195068', '', 2, 1);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No a la mineria a cielo abierto en Uruguay', 'Somos firmes, Aratiri y cualquier otro megaproyecto megaminero es contaminación, destrucción y muerte.
¡La tierra no se vende, la tierra se defiende!', 'noa.megamineria', '-34.831841,-56.195068', '', 2, 2);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Igualdad de clase', 'Clases Sociales e Igualdad de las Personas, Igualdad de Deberes y de Derechos', 'todos.iguales', '(-34.89043666790253, -56.17309534374999)', '', 2, 3);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No rompan internet. No al SOAP', 'SOPA (Stop Online Piracy Act) es un proyecto de ley introducido en la Cámara de Representantes de Estados Unidos el pasado 26 de octubre de 2011,
 con el objetivo de ampliar las capacidades de los propietarios de derechos intelectuales para supuestamente combatir el tráfico de contenidos en internet y productos protegidos por derechos de autor o por la propiedad intelectual.', 'no.sopa', '(-34.89043666790253, -56.17309534374999)', '', 2, 4);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No a la piratería', 'Porque es un tema que nos afecta a todos, NO a la piratería', 'no.pirateria', '(-34.89043666790253, -56.17309534374999)', '', 3, 1);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('NO USO de agrotoxico', 'Porque las consecuencias de los agrotóxicos se transmiten a las futuras generaciones, no aceptemos alimentos envenenados con agrotoxicos', 'no.agrotoxico', '(-34.89043666790253, -56.17309534374999)', '', 3, 2);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('Discriminación de género', 'Si alguna vez sentiste discriminación, Unite! Todos contra la discriminación', 'no.discrimines', '(-34.89043666790253, -56.17309534374999)', '', 3, 3);
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, AppIDFacebook, FK_Id_Layout, FK_Id_Tematica) values ('No a la basura espacial', 'La basura espacial es un tema de preocupación que sin duda comenzará pronto a tomar importancia. No esperemos hasta ese día! Unite hoy y busquemos soluciones!', 'no.basura.espacial', '(-34.89043666790253, -56.17309534374999)', '', 3, 4);


/*variables sistema*/
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (1, 'Recursos más rankeados', '5')
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (2, 'Recursos compartidos', '5')
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (3, 'Dar de baja contenido', '5')
INSERT INTO VariableSistema (Id, Nombre, Valor) VALUES (4, 'Dar de baja usuario', '5')


/*Atención: Las contraseñas encriptadas son: password*/

/*Administrador*/ 
INSERT INTO Administrador (Nombre, Password, Pregunta, Respuesta, Email) VALUES ('Super Administrador', '5gPNqhmBNpf/o5q8UUfhug==', 'Es el administrador?', 'Esta es la respuesta', 'super@hotmail.com')

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'juan@hotmail.com', 1, 'Juan', 'Miraballes', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'maxi@hotmail.com', 1, 'Maxi', 'Silvera', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'roberto@hotmail.com', 1, 'Roberto', 'Nesta', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'richard@hotmail.com', 1, 'Richard', 'Porta', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'alexis@hotmail.com', 1, 'Alexis', 'Rolin', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'vanessa@hotmail.com', 2, 'Vanessa', 'Revetria', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'facundo@hotmail.com', 2, 'Facundo', 'Piriz', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'gonzalo@hotmail.com', 2, 'Gonzalo', 'Castro', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'marcelo@hotmail.com', 2, 'Marcelo', 'Gallardo', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'cacique@hotmail.com', 2, 'Cacique', 'Medina', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);

insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'jorge@hotmail.com', 3, 'Jorge', 'Baba', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'tabare@hotmail.com', 3, 'Tabare', 'Viudez', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'andrea@hotmail.com', 3, 'Andrea', 'Perez', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'andres@hotmail.com', 3, 'Andres', 'Aldao', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);
insert into Usuario (Descripcion, Email, FK_Id_Sitio, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, FechaRegistro) values ('Descripcion del usuario 1', 'maxi@hotmail.com', 3, 'Maxi', 'Calzada', '5gPNqhmBNpf/o5q8UUfhug==', 'Pregunta', '(-34.89043666790253, -56.17309534374999)', 'Respuesta', 22/05/2012);

