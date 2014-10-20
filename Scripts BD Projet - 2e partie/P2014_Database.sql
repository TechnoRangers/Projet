USE master
GO

if exists (select * from sysdatabases where name='P2014_BD_GestionHotel')
  DROP database P2014_BD_GestionHotel
GO

CREATE DATABASE P2014_BD_GestionHotel
GO