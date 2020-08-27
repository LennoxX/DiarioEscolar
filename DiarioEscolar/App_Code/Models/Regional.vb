Public Class Regional
    Private TG02_ID_REGIONAL As Integer
    Private TG02_DS_REGIONAL As String

    Public Sub New()

    End Sub

    Public Property Codigo() As Integer
        Get
            Return TG02_ID_REGIONAL
        End Get
        Set(value As Integer)
            TG02_ID_REGIONAL = value
        End Set
    End Property

    Public Property Regional() As String
        Get
            Return TG02_DS_REGIONAL
        End Get
        Set(value As String)
            TG02_DS_REGIONAL = value
        End Set
    End Property
End Class
