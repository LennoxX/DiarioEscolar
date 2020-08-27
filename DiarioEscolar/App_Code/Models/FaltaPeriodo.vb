Public Class FaltaPeriodo
    Private EE17_ID_FALTA_PERIODO As Integer
    Private EE08_ID_AULA_PERIODO As Integer
    Private EE17_NR_FALTA As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE17_ID_FALTA_PERIODO
        End Get
        Set(value As Integer)
            EE17_ID_FALTA_PERIODO = value
        End Set
    End Property

    Public Property AulaPeriodo() As Integer
        Get
            Return EE08_ID_AULA_PERIODO
        End Get
        Set(value As Integer)
            EE08_ID_AULA_PERIODO = value
        End Set
    End Property

    Public Property Falta() As Integer
        Get
            Return EE17_NR_FALTA
        End Get
        Set(value As Integer)
            EE17_NR_FALTA = value
        End Set
    End Property
End Class
