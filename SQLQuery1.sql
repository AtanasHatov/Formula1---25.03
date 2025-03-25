CREATE DATABASE Formula1

CREATE TABLE Teams(
[team_id] INT PRIMARY KEY IDENTITY(1,1),
[team_name] VARCHAR(255),
[country] VARCHAR(100),
[foundation_year] INT 
);

CREATE TABLE Drivers(
[driver_id] INT PRIMARY KEY IDENTITY(1,1),
[first_name] VARCHAR(100),
[last_name] VARCHAR(100),
[birth_date] DATE,
[nationality] VARCHAR(100),
[team_id] INT FOREIGN KEY REFERENCES Teams([team_id])
);

CREATE TABLE Races(
[race_id] INT PRIMARY KEY IDENTITY(1,1),
[race_name] VARCHAR(255),
[location] VARCHAR(255),
[race_date] DATE,
[season_year] INT
);

CREATE TABLE Race_Results(
[result_id] INT PRIMARY KEY IDENTITY(1,1),
[race_id] INT FOREIGN KEY REFERENCES Races([race_id]),
[driver_id] INT FOREIGN KEY REFERENCES Drivers([driver_id]),
[position] INT,
[points] DECIMAL(5,2),
[laps] INT,
[time] TIME
);

INSERT INTO Teams (team_name, country, foundation_year) 
VALUES 
('Mercedes', 'Germany', 1954),
('Red Bull Racing', 'Austria', 2005),
('Ferrari', 'Italy', 1929),
('McLaren', 'United Kingdom', 1963),
('Alpine', 'France', 2021);

INSERT INTO Drivers (first_name, last_name, birth_date, nationality, team_id)
VALUES 
('Lewis', 'Hamilton', '1985-01-07', 'British', 1),
('Max', 'Verstappen', '1997-09-30', 'Dutch', 2),
('Charles', 'Leclerc', '1997-10-16', 'Monaco', 3),
('Lando', 'Norris', '1999-11-13', 'British', 4),
('Esteban', 'Ocon', '1996-09-17', 'French', 5);

INSERT INTO Races (race_name, location, race_date, season_year)
VALUES 
('Australian Grand Prix', 'Melbourne, Australia', '2025-03-23', 2025),
('Bahrain Grand Prix', 'Sakhir, Bahrain', '2025-03-06', 2025),
('Spanish Grand Prix', 'Barcelona, Spain', '2025-05-12', 2025),
('Monaco Grand Prix', 'Monte Carlo, Monaco', '2025-05-26', 2025),
('Azerbaijan Grand Prix', 'Baku, Azerbaijan', '2025-06-09', 2025);

INSERT INTO Race_Results (race_id, driver_id, position, points, laps, time)
VALUES 
(1, 1, 1, 25.00, 58, '01:30:15'),
(1, 2, 2, 18.00, 58, '01:30:30'),
(2, 3, 1, 25.00, 57, '01:32:45'),
(2, 4, 3, 15.00, 57, '01:33:10'),
(3, 5, 1, 25.00, 66, '01:40:20');
