Public Class Equipe
    Private EE12_ID_EQUIPE As Integer
    Private EE14_ID_MATRIZ As Integer
    Private EE12_DS_EQUIPE As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE12_ID_EQUIPE
        End Get
        Set(value As Integer)
            EE12_ID_EQUIPE = value
        End Set
    End Property

    Public Property IdMatriz() As Integer
        Get
            Return EE14_ID_MATRIZ
        End Get
        Set(value As Integer)
            EE14_ID_MATRIZ = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return EE12_DS_EQUIPE
        End Get
        Set(value As String)
            EE12_DS_EQUIPE = value
        End Set
    End Property
End Class
