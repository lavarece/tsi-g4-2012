/* layouts */
insert into Layout (Id, Nombre, NombreLayout) values (1, 'Layout 1', 'layout_1'); 
insert into Layout (Id, Nombre, NombreLayout) values (2, 'Layout 2', 'layout_2');
insert into Layout (Id, Nombre, NombreLayout) values (3, 'Layout 3', 'layout_3');

/* tematicas */
insert into Tematica (Id, Nombre, NombreCSS) values (1, 'Por defecto', 'default');

/* grupos */
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, FK_Id_Layout, FK_Id_Tematica) values ('Grupo prueba layout 1', 'Grupo para probar el layout 1 situado en uruguay', 'localhost', '-34.831841,-56.195068', 1, 1); 
insert into Sitio (Nombre, Descripcion, Url, Coordenadas, FK_Id_Layout, FK_Id_Tematica) values ('Grupo prueba layout 3', 'Grupo para probar el layout 3 situado en uruguay', 'layout3', '-34.831841,-56.195068', 3, 1); 

/*variables sistema*/
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Recursos más rankeados', '5')
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Recursos compartidos', '5')
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Dar de baja contenido', '5')
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Dar de baja usuario', '5')

/*Administrador*/
INSERT INTO Administrador (Nombre, Password, Pregunta, Respuesta, Email) VALUES ('Administrador1', 'Password', 'Pregunta Admin?', 'Esta es la respuesta', 'administrador1@hotmail.com')
