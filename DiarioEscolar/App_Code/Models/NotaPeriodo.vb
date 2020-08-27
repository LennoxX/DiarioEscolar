Public Class NotaPeriodo
    Private EE18_ID_NOTA_PERIODO As Integer
    Private EE09_ID_ATIVIDADE_PERIODO As Integer
    Private EE18_DS_NOTA As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE18_ID_NOTA_PERIODO
        End Get
        Set(value As Integer)
            EE18_ID_NOTA_PERIODO = value
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

    Public Property Nota() As String
        Get
            Return EE18_DS_NOTA
        End Get
        Set(value As String)
            EE18_DS_NOTA = value
        End Set
    End Property
End Class
