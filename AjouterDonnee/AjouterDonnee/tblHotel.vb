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

Partial Public Class tblHotel
    Public Property CodeHotel As String
    Public Property NomHotel As String
    Public Property NbChambre As Short
    Public Property AdresseHotel As String
    Public Property NbEtoiles As Byte
    Public Property TypeService As String
    Public Property CodeVille As String

    Public Overridable Property tblFournitureHotel As ICollection(Of tblFournitureHotel) = New HashSet(Of tblFournitureHotel)
    Public Overridable Property tblEmploye As ICollection(Of tblEmploye) = New HashSet(Of tblEmploye)
    Public Overridable Property tblChambre As ICollection(Of tblChambre) = New HashSet(Of tblChambre)
    Public Overridable Property tblEquipementRecreatifHotel As ICollection(Of tblEquipementRecreatifHotel) = New HashSet(Of tblEquipementRecreatifHotel)
    Public Overridable Property tblSalle As ICollection(Of tblSalle) = New HashSet(Of tblSalle)
    Public Overridable Property tblVille As tblVille

End Class
