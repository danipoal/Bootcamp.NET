
--INSERCIÓN DE DATOS

DELETE FROM Vuelo_TipoAsiento;
DELETE FROM TipoAsiento;
DELETE FROM Reserva;
DELETE FROM Auxiliar_Vuelo;
DELETE FROM Vuelo;
DELETE FROM Auxiliar;
DELETE FROM CategoriaAux;
DELETE FROM Piloto;
DELETE FROM TipoServicio;
DELETE FROM Trayecto;
DELETE FROM Aeropuerto;
DELETE FROM Avion;
DELETE FROM ModeloAvion;

INSERT INTO ModeloAvion(NombreModelo, Diametro) 
VALUES	('Boeing 747', 320),
		('Boeing 777', 550),
		('Boeing 737', 215),
		('Airbus 319', 156),
		('Airbus 320', 220),
		('Airbus 300-600', NULL);

INSERT INTO Avion(NombreAvion, Capacidad, FechaConstruccion, FkIdModelo)
VALUES ('El veloz', 200, '2000-09-22', 1),
       ('El sonico', 10, '1989-01-01', 6),
       ('Arca de Noe', 20, '1999-04-23', 3),
       ('Bandido', 200, '2004-09-24', 4),
       ('Predator X', 400, '2012-12-04', 2),
       ('Charli bravo', 300, '2023-01-01', 5),
       ('American Pie', 2, '2024-03-04', 2);

INSERT INTO Aeropuerto (Lugar, Coordenadas) 
VALUES  ('Barcelona', '46.224482, 65.600512'),
		('Madrid', '67.832134, 114.438124'),
		('Valencia', '89.406166, 82.699557'),
		('Sevilla', '-47.024877, 40.762866'),
		('Bilbao', '42.477611, 69.925109'),
		('Málaga', '-63.875399, 163.977541'),
		('Zaragoza', '-80.626724, -153.838018'),
		('Gran Canaria', '64.444239, 52.575498'),
		('Alicante', '-19.0149, 139.942541'),
		('Murcia', '-28.514626, 57.69836');



INSERT INTO Trayecto(Duracion, Hora, FkIdOrigen, FkIdDestino) 
VALUES  (115, 0.34, 8, 4),
		(390, 17.32, 4, 8),
		(222, 21.74, 5, 1),
		(356, 13.23, 6, 7),
		(98, 5.9, 7, 9),
		(337, 19.12, 7, 9),
		(364, 0.97, 4, 9),
		(425, 2.1, 2, 4),
		(273, 14.96, 9, 1),
		(248, 15.86, 1, 2);

INSERT INTO TipoServicio(IsNational, IsContinental, IsInterContinental)
VALUES	(1, 0, 0),
		(0, 1, 0),
		(0, 0, 1),
		(1, 1, 0),
		(0, 1, 1),
		(1, 1, 1),
		(0, 0, 0);

INSERT INTO Piloto (Nif, Nombre, Antiguedad, FkIdTipoServicio) 
VALUES	('06814177B', 'Carlos García', 11, 1),
		('90519349I', 'Ana Martínez', 5, 2),
		('18157049P', 'Juan López', 12, 2),
		('47169771N', 'María Sánchez', 10, 2),
		('33055599Z', 'Pedro Fernández', 28, 4),
		('99306117Y', 'Lucía Gómez', 1, 2),
		('39450590U', 'Javier Ruiz', 2, 2),
		('13854784V', 'Laura Díaz', 28, 1),
		('24513472Q', 'Sergio Torres', 7, 3),
		('12636447A', 'Paula Romero', 13, 1);

INSERT INTO CategoriaAux(Categoria)
VALUES ('Azafato'),
	   ('Mantenimiento'),
	   ('Camarero');
	   
INSERT INTO Auxiliar(NIF, Nombre, FkIdCategoria)
VALUES  ('24847540B', 'Raúl Pérez', 3),
		('65947839A', 'Marta Moreno', 2),
		('09496906Y', 'Alejandro Díaz', 1),
		('78710850S', 'Sofía Ortega', 1),
		('81820992P', 'Diego Álvarez', 3),
		('79576995T', 'Elena Ramírez', 1),
		('81877694G', 'David Jiménez', 3),
		('52944186Y', 'Carla Martínez', 1),
		('89027943R', 'Andrés Gómez', 3),
		('63296355K', 'Isabel Torres', 3);

INSERT INTO Vuelo (Fecha, Duracion, FkIdAvion, FkIdTrayecto, FkIdPiloto, FkIdCopiloto) 
VALUES	('2023-02-18', 77, 4, 1, 3, 2),
		('2021-07-21', 415, 3, 2, 6, 3),
		('2022-06-18', 314, 2, 8, 7, 3),
		('2021-12-21', 285, 6, 6, 4, 2),
		('2021-08-19', 277, 5, 8, 10, 9),
		('2020-03-16', 339, 6, 2, 7, 9),
		('2024-11-26', 277, 2, 6, 1, 5),
		('2022-11-06', 443, 4, 3, 1, 2),
		('2020-06-05', 463, 1, 8, 5, 6),
		('2021-12-14', 204, 5, 3, 4, 1);

INSERT INTO Auxiliar_Vuelo(FkIdAuxiliar, FkIdVuelo)
VALUES	(1,1),
		(2,2),
		(1,2),
		(4,3),
		(5,3),
		(3,4),
		(6,6),
		(2,7);

--RESERVAS (Algunas no funcionaran, pero la mayoria si)

INSERT INTO [Reserva] (FechaReserva,NombrePasajero,NifPasajero,Fila,Columna,FkIdVuelo)
VALUES	  ('Nov 21, 2023','Zane Branch','56352453P',27,3,10),
		  ('Jul 28, 2025','Brittany Douglas','42479519P',28,5,2),
		  ('Nov 9, 2023','Ruby Gamble','45760133D',19,3,1),
		  ('Aug 29, 2024','Jorden Watkins','28444838F',14,3,8),
		  ('Apr 11, 2024','Levi Ayers','25632682W',7,5,10),
		  ('Sep 23, 2025','Marvin Koch','40956898H',8,4,10),
		  ('Oct 2, 2025','Xavier Winters','38228981O',23,2,5),
		  ('Oct 31, 2023','Wallace Decker','88578715P',17,3,8),
		  ('Apr 15, 2024','Adrian Stanton','78665443K',17,2,4),
		  ('Nov 27, 2024','Thaddeus Gamble','31477156Y',27,6,4),
		  ('Mar 4, 2024','Dara Castro','72175272Y',2,4,9),
		  ('May 20, 2025','Rosalyn Nolan','74043502W',24,4,8),
		  ('Apr 19, 2025','Orson Jennings','74385305C',17,3,4),
		  ('Nov 9, 2023','Tatum Gibbs','88818511I',28,4,5),
		  ('Mar 25, 2025','Lucy Conway','62187534X',26,5,4),
		  ('Oct 12, 2024','Martina Hamilton','30412367D',26,2,7),
		  ('Oct 2, 2025','Acton Cantu','57976042H',18,6,3),
		  ('Feb 15, 2025','Kirby Carter','73281873I',15,5,8),
		  ('Jul 22, 2024','Zelenia Mack','29173542V',7,3,7),
		  ('Oct 24, 2024','Zenaida Garcia','16438173C',26,4,5),
		  ('Mar 17, 2025','Lionel Francis','32613575G',21,4,5),
		  ('Nov 3, 2024','Price Campos','28212944S',13,3,8),
		  ('Apr 21, 2025','Hyacinth Gomez','43891874W',3,3,4),
		  ('Aug 15, 2025','Aspen Galloway','08833135M',11,2,7),
		  ('Sep 20, 2024','Lyle Kirk','91612826B',15,4,6),
		  ('Aug 26, 2024','Breanna Levine','70406566H',24,4,2),
		  ('Jul 4, 2025','Orlando Gross','33397114U',23,3,10),
		  ('Sep 1, 2025','Chaim Gay','28232301R',13,2,9),
		  ('Oct 12, 2025','Maryam Madden','51373866E',20,2,5),
		  ('Dec 31, 2023','Hedwig Ray','45114566H',24,1,7),
		  ('Nov 11, 2023','Juliet Nguyen','21651884C',14,4,3),
		  ('Mar 8, 2025','Lucian Webb','45871189H',29,6,9),
		  ('Jul 12, 2025','Basil Shepard','27177313R',25,4,4),
		  ('Nov 19, 2024','Rosalyn Navarro','35502990U',19,5,8),
		  ('Aug 25, 2024','Signe Ramos','72833877N',17,3,2),
		  ('Oct 25, 2023','Kerry Francis','06746788C',10,6,8),
		  ('Oct 30, 2023','Uriel Ruiz','11664716W',8,3,9),
		  ('Nov 18, 2024','Wade Joseph','00783837R',2,3,3),
		  ('Dec 23, 2024','Nicholas Daugherty','03873565I',14,5,6),
		  ('Dec 5, 2024','Lillith Weaver','44572455X',28,3,9),
		  ('Nov 8, 2023','Octavia Ferrell','52938744C',24,4,9),
		  ('Feb 3, 2025','Hiram Floyd','16408234D',27,3,7),
		  ('Oct 21, 2023','Brian Whitfield','85438284C',19,4,5),
		  ('Aug 29, 2025','Melvin Haynes','19222466Q',3,3,9),
		  ('Jan 11, 2024','Xanthus Lyons','77634986Q',10,3,7),
		  ('May 1, 2025','Duncan Langley','37559091F',23,5,4),
		  ('Aug 2, 2024','Todd Olsen','76141053C',24,2,7),
		  ('Dec 4, 2024','Ali Zamora','51144861O',27,6,5),
		  ('Apr 5, 2025','Claudia Finch','41616682F',7,2,6),
		  ('May 22, 2025','Merritt Jarvis','00219239X',7,6,5);

INSERT INTO TipoAsiento(NombreTipo)
VALUES	('Primera clase'),
		('Segunda clase'),
		('Tercera clase');

INSERT INTO Vuelo_TipoAsiento(Precio, FilaInicial, FilaFinal, FkIdVuelo, FkIdTipoAsiento)
VALUES	(82.02, 1, 5, 1, 1),
		(62.02, 6, 15, 1, 2),
		(22.02, 16, 30, 1, 3),
		(82.02, 1, 5, 2, 1),
		(42.02, 6, 15, 2, 2),
		(12.02, 16, 30, 2, 3),
		(92.02, 1, 5, 3, 1),
		(22.02, 6, 15, 3, 2),
		(23.02, 16, 30, 3, 3),
		(82.02, 1, 5, 4, 1),
		(62.02, 6, 15, 4, 2),
		(22.02, 16, 30, 4, 3),
		(82.02, 1, 5, 5, 1),
		(42.02, 6, 15, 5, 2),
		(12.02, 16, 30, 5, 3),
		(92.02, 1, 5, 6, 1),
		(22.02, 6, 15, 6, 2),
		(23.02, 16, 30, 6, 3);
