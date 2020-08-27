Public Class MediaPeriodo
    Private EE19_ID_MEDIA_PERIODO As Integer
    Private EE09_ID_ATIVIDADE_PERIODO As Integer
    Private EE20_DS_MEDIA As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE19_ID_MEDIA_PERIODO
        End Get
        Set(value As Integer)
            EE19_ID_MEDIA_PERIODO = value
        End Set
    End Property

    Public Property AtividadePeriodo() As Integer
        Get
            Return EE09_ID_ATIVIDADE_PERIODO
        End Get
        Set(value As Integer)
            EE09_ID_ATIVIDADE_PERIODO = value
        End Set
    End Property


    Public Property Media() As String
        Get
            Return EE20_DS_MEDIA
        End Get
        Set(value As String)
            EE20_DS_MEDIA = value
        End Set
    End Property
End Class
