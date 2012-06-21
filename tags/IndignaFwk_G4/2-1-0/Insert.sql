INSERT INTO Sitio (Nombre, Descripcion, LogoUrl, Template, Url) VALUES ('Sitio base', 'Descripcion del sitio 1', 'http://upload.wikimedia.org/wikipedia/nah/d/d3/Volkswagen_logo.png', 'template 1', 'sitio1')
INSERT INTO Sitio (Nombre, Descripcion, LogoUrl, Template, Url) VALUES ('Second base', 'Descripcion del sitio 2', 'http://carshd.net/data/media/48/skoda_logo.jpg', 'template 2', 'sitio2')

INSERT INTO Usuario (Nombre, Password, Pregunta, Descripcion, Respuesta, Email, FK_Id_Sitio) VALUES ('Usuario1', 'Password', 'Pregunta1?', 'Soy el usuario 1', 'Esta es la respuesta1', 'usuario1@hotmail.com', 4)
INSERT INTO Usuario (Nombre, Password, Pregunta, Descripcion, Respuesta, Email, FK_Id_Sitio) VALUES ('Usuario2', 'Password', 'Pregunta2?', 'Soy el usuario 2', 'Esta es la respuesta2', 'usuario2@hotmail.com', 4)
INSERT INTO Usuario (Nombre, Password, Pregunta, Descripcion, Respuesta, Email, FK_Id_Sitio) VALUES ('Usuario3', 'Password', 'Pregunta3?', 'Soy el usuario 3', 'Esta es la respuesta3', 'usuario3@hotmail.com', 4)

INSERT INTO Administrador (Nombre, Password, Pregunta, Respuesta, Email) VALUES ('Administrador1', 'Password', 'Pregunta Admin?', 'Esta es la respuesta', 'administrador1@hotmail.com')

INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Recursos más rankeados', '5')
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Recursos compartidos', '5')
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Dar de baja contenido', '5')
INSERT INTO VariableSistema (Nombre, Valor) VALUES ('Dar de baja usuario', '5')

