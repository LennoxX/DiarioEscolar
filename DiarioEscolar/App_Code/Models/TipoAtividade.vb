Public Class TipoAtividade
    Private EE10_ID_TIPO_ATIVIDADE As Integer
    Private EE10_DS_TIPO_ATIVIDADE As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE10_ID_TIPO_ATIVIDADE
        End Get
        Set(value As Integer)
            EE10_ID_TIPO_ATIVIDADE = value
        End Set
    End Property

    Public Property TipoAtividade() As String
        Get
            Return EE10_DS_TIPO_ATIVIDADE
        End Get
        Set(value As String)
            EE10_DS_TIPO_ATIVIDADE = value
        End Set
    End Property
End Class
