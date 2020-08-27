Public Class AulaPeriodo
    Private EE08_ID_AULA_PERIODO As Integer
    Private EE13_ID_EQUIPE_DISCIPLINA As Integer
    Private EE08_DT_CADASTRO As DateTime
    Private EE08_DS_CONTEUDO As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE08_ID_AULA_PERIODO
        End Get
        Set(value As Integer)
            EE08_ID_AULA_PERIODO = value
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
            Return EE08_DT_CADASTRO
        End Get
        Set(value As Date)
            EE08_DT_CADASTRO = value
        End Set
    End Property

    Public Property Conteudo() As String
        Get
            Return EE08_DS_CONTEUDO
        End Get
        Set(value As String)
            EE08_DS_CONTEUDO = value
        End Set
    End Property
End Class
