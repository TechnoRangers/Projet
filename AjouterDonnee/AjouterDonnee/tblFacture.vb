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

Partial Public Class tblFacture
    Public Property NoSeqFacture As Integer
    Public Property MontantFacture As Nullable(Of Decimal)
    Public Property TypeFacture As String
    Public Property NoSeqReservChambre As Integer

    Public Overridable Property tblReservationChambre As tblReservationChambre

End Class
