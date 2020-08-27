Public Class Nota
    Private EE18_ID_NOTA As Integer
    Private EE09_ID_ATIVIDADE As Integer
    Private EE18_DS_NOTA As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE18_ID_NOTA
        End Get
        Set(value As Integer)
            EE18_ID_NOTA = value
        End Set
    End Property

    Public Property Atividade() As Integer
        Get
            Return EE09_ID_ATIVIDADE
        End Get
        Set(value As Integer)
            EE09_ID_ATIVIDADE = value
        End Set
    End Property

    Public Property Nota() As String
        Get
            Return EE18_DS_NOTA
        End Get
        Set(value As String)
            EE18_DS_NOTA = value
        End Set
    End Property
End Class
