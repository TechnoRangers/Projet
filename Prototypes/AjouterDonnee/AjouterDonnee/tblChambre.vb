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

Partial Public Class tblChambre
    Public Property NoSeqChambre As Integer
    Public Property CodeChambre As String
    Public Property StatutChambre As String
    Public Property DescChambre As String
    Public Property TypeLit As String
    Public Property NbLit As Byte
    Public Property CodeHotel As String
    Public Property CodeTypeChambre As String

    Public Overridable Property tblFourniture As ICollection(Of tblFourniture) = New HashSet(Of tblFourniture)
    Public Overridable Property tblReservationChambre As ICollection(Of tblReservationChambre) = New HashSet(Of tblReservationChambre)
    Public Overridable Property tblHotel As tblHotel
    Public Overridable Property tblTypeChambre As tblTypeChambre

End Class
