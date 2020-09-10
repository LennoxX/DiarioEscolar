Public Class Falta
    Private EE17_ID_FALTA As Integer
    Private EE08_ID_AULA As Integer
    Private EE17_NR_FALTA As Integer
    Private EE05_ID_EQUIPE_ALUNO As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE17_ID_FALTA
        End Get
        Set(value As Integer)
            EE17_ID_FALTA = value
        End Set
    End Property

    Public Property CodigoAula() As Integer
        Get
            Return EE08_ID_AULA
        End Get
        Set(value As Integer)
            EE08_ID_AULA = value
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

    Public Property CodigoEquipeAluno() As Integer
        Get
            Return EE05_ID_EQUIPE_ALUNO
        End Get
        Set(value As Integer)
            EE05_ID_EQUIPE_ALUNO = value
        End Set
    End Property
End Class
