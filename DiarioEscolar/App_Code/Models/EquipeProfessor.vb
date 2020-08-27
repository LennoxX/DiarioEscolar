Imports System.Data

Public Class EquipeProfessor
    Private EE04_ID_EQUIPE_PROFESSOR As Integer
    Private EE02_ID_PROFESSOR As Integer
    Private EE02_ID_EQUIPE_ESCOLA As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE04_ID_EQUIPE_PROFESSOR
        End Get
        Set(value As Integer)
            EE04_ID_EQUIPE_PROFESSOR = value
        End Set
    End Property

    Public Property CodigoProfessor() As Integer
        Get
            Return EE02_ID_PROFESSOR
        End Get
        Set(value As Integer)
            EE02_ID_PROFESSOR = value
        End Set
    End Property

    Public Property CodigoEquipeEscola() As Integer
        Get
            Return EE02_ID_EQUIPE_ESCOLA
        End Get
        Set(value As Integer)
            EE02_ID_EQUIPE_ESCOLA = value
        End Set
    End Property

    Public Function Pesquisar(CodigoTurma As Integer,
                             Optional ByVal Sort As String = "",
                             Optional ByVal IdProfessor As Integer = 0,
                             Optional ByVal NomeProfessor As String = "",
                             Optional ByVal Matricula As String = ""
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder


        strSQL.Append(" select * ")
        strSQL.Append(" from EE04_EQUIPE_PROFESSOR")
        strSQL.Append(" Join EE02_PROFESSOR On EE04_EQUIPE_PROFESSOR.EE02_ID_PROFESSOR = EE02_PROFESSOR.EE02_ID_PROFESSOR")
        strSQL.Append(" And EE04_EQUIPE_PROFESSOR.EE06_ID_EQUIPE_ESCOLA =" & CodigoTurma)


        If IdProfessor > 0 Then
            strSQL.Append(" and EE02_ID_PROFESSOR = " & IdProfessor)
        End If

        If NomeProfessor <> "" Then
            strSQL.Append(" and upper(EE02_NM_NOME) like '%" & NomeProfessor.ToUpper & "%'")
        End If

        If Matricula <> "" Then
            strSQL.Append(" and upper(EE02_NR_MATRICULA) like '%" & Matricula.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE02_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function
End Class
