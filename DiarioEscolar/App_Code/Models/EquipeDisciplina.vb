Public Class EquipeDisciplina
    Private EE13_ID_EQUIPE_DISCIPLINA As Integer
    Private EE11_ID_DISCIPLINA As Integer
    Private EE04_ID_EQUIPE_PROFESSOR As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE13_ID_EQUIPE_DISCIPLINA
        End Get
        Set(value As Integer)
            EE13_ID_EQUIPE_DISCIPLINA = value
        End Set
    End Property

    Public Property CodigoDisciplina() As Integer
        Get
            Return EE11_ID_DISCIPLINA
        End Get
        Set(value As Integer)
            EE11_ID_DISCIPLINA = value
        End Set
    End Property

    Public Property CodigoEquipeProfessor() As Integer
        Get
            Return EE04_ID_EQUIPE_PROFESSOR
        End Get
        Set(value As Integer)
            EE04_ID_EQUIPE_PROFESSOR = value
        End Set
    End Property
End Class
