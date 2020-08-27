Public Class TipoEnsino

    Private EE15_ID_TIPO_ENSINO As Integer
    Private EE15_DS_TIPO_ENSINO As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE15_ID_TIPO_ENSINO
        End Get
        Set(value As Integer)
            EE15_ID_TIPO_ENSINO = value
        End Set
    End Property

    Public Property DsTipoEnsino() As String
        Get
            Return EE15_DS_TIPO_ENSINO
        End Get
        Set(value As String)
            EE15_DS_TIPO_ENSINO = value
        End Set
    End Property
End Class
