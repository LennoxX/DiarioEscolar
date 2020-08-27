Public Class Media
    Private EE19_ID_MEDIA As Integer
    Private EE09_ID_ATIVIDADE As Integer
    Private EE19_DS_MEDIA As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE19_ID_MEDIA
        End Get
        Set(value As Integer)
            EE19_ID_MEDIA = value
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

    Public Property Media() As String
        Get
            Return EE19_DS_MEDIA
        End Get
        Set(value As String)
            EE19_DS_MEDIA = value
        End Set
    End Property
End Class
