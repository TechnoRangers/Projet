'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré à partir d'un modèle.
'
'     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
'     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class tblEmploye
    Public Property NoEmploye As Integer
    Public Property NomEmploye As String
    Public Property PrenomEmploye As String
    Public Property SexeEmploye As String
    Public Property AdresseEmploye As String
    Public Property TypeEmploi As String
    Public Property NoTelephoneEmploye As String
    Public Property NasEmploye As String
    Public Property DateNaissance As Date
    Public Property IdentifiantEmploye As String
    Public Property MdpEmploye As String
    Public Property NombreHeuresSemaines As Nullable(Of Short)
    Public Property CodeHotel As String

    Public Overridable Property tblCommande As ICollection(Of tblCommande) = New HashSet(Of tblCommande)
    Public Overridable Property tblChiffreTravail As ICollection(Of tblChiffreTravail) = New HashSet(Of tblChiffreTravail)
    Public Overridable Property tblEntretienFourniture As ICollection(Of tblEntretienFourniture) = New HashSet(Of tblEntretienFourniture)
    Public Overridable Property tblHotel As tblHotel

End Class
