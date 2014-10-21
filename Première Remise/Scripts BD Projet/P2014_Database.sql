USE master
GO

if exists (select * from sysdatabases where name='P2014_BDTestFrancois')
  DROP database P2014_BDTestFrancois
GO

CREATE DATABASE P2014_BDTestFrancois
GO