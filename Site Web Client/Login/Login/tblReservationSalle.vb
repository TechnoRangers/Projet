' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

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

Partial Public Class tblReservationSalle
    Public Property NoSeqReservSalle As Integer
    Public Property DateReservSalle As Date
    Public Property PrixReservSalle As Nullable(Of Decimal)
    Public Property ModePaiement As String
    Public Property StatutPaiement As String
    Public Property NbPersonne As Nullable(Of Short)
    Public Property NoCarteCredit As String
    Public Property CodeSalle As String
    Public Property NoSeqClient As Integer

    Public Overridable Property tblClient As tblClient
    Public Overridable Property tblFournitureReservationSalle As ICollection(Of tblFournitureReservationSalle) = New HashSet(Of tblFournitureReservationSalle)
    Public Overridable Property tblSalle As tblSalle

End Class
