/* layouts */
insert into Layout (Nombre, NombreLayout) values ('Layout 1', 'layout_1'); 
insert into Layout (Nombre, NombreLayout) values ('Layout 2', 'layout_2');
insert into Layout (Nombre, NombreLayout) values ('Layout 3', 'layout_3');

/* tematicas */
insert into Tematica (Nombre, NombreCSS) values ('Por defecto', 'default');

/* gruopos */
insert into Sitio (Nombre, Descripcion, NombreLayout, Url, FK_Id_Tematica) values ('Grupo prueba layout 1', 'Grupo para probar el layout 1', 'layout_1', 