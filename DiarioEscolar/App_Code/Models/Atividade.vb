Public Class Atividade
    Private EE09_ID_ATIVIDADE As Integer
    Private EE10_ID_TIPO_ATIVIDADE As Integer
    Private EE13_ID_EQUIPE_DISCIPLINA As Integer
    Private EE09_DT_CADASTRO As DateTime
    Private EE09_DT_REALIZADA As DateTime

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE09_ID_ATIVIDADE
        End Get
        Set(value As Integer)
            EE09_ID_ATIVIDADE = value
        End Set
    End Property

    Public Property TipoAtividade() As Integer
        Get
            Return EE10_ID_TIPO_ATIVIDADE
        End Get
        Set(value As Integer)
            EE10_ID_TIPO_ATIVIDADE = value
        End Set
    End Property

    Public Property EquipeDisciplina() As Integer
        Get
            Return EE13_ID_EQUIPE_DISCIPLINA
        End Get
        Set(value As Integer)
            EE13_ID_EQUIPE_DISCIPLINA = value
        End Set
    End Property

    Public Property DataCadastro() As Date
        Get
            Return EE09_DT_CADASTRO
        End Get
        Set(value As Date)
            EE09_DT_CADASTRO = value
        End Set
    End Property

    Public Property DataRealizada() As Date
        Get
            Return EE09_DT_REALIZADA
        End Get
        Set(value As Date)
            EE09_DT_REALIZADA = value
        End Set
    End Property
End Class
