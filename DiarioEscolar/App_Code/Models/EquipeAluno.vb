Imports System.Data

Public Class EquipeAluno
    Private EE05_ID_EQUIPE_ALUNO As Integer
    Private EE03_ID_ALUNO As Integer
    Private EE06_ID_EQUIPE_ESCOLA As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE05_ID_EQUIPE_ALUNO
        End Get
        Set(value As Integer)
            EE05_ID_EQUIPE_ALUNO = value
        End Set
    End Property

    Public Property CodigoAluno() As Integer

        Get
            Return EE03_ID_ALUNO
        End Get
        Set(value As Integer)
            EE03_ID_ALUNO = value
        End Set
    End Property

    Public Property CodigoEquipeEscola() As Integer
        Get
            Return EE06_ID_EQUIPE_ESCOLA
        End Get
        Set(value As Integer)
            EE06_ID_EQUIPE_ESCOLA = value
        End Set
    End Property



    Public Function Pesquisar(CodigoTurma As Integer,
                             Optional ByVal Sort As String = "",
                             Optional ByVal IdAluno As Integer = 0,
                             Optional ByVal NomeAluno As String = "",
                             Optional ByVal Matricula As String = ""
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder


        strSQL.Append(" select * ")
        strSQL.Append(" from EE05_EQUIPE_ALUNO")
            strSQL.Append(" Join EE03_ALUNO On EE05_EQUIPE_ALUNO.EE03_ID_ALUNO = EE03_ALUNO.EE03_ID_ALUNO")
            strSQL.Append(" And EE05_EQUIPE_ALUNO.EE06_ID_EQUIPE_ESCOLA = " & CodigoTurma)


        If IdAluno > 0 Then
            strSQL.Append(" and EE03_ID_ALUNO = " & IdAluno)
        End If

        If NomeAluno <> "" Then
            strSQL.Append(" and upper(EE03_NM_NOME) like '%" & NomeAluno.ToUpper & "%'")
        End If

        If Matricula <> "" Then
            strSQL.Append(" and upper(EE03_DS_MATRICULA) like '%" & Matricula.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE03_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Friend Function Excluir(Codigo As Object)
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE05_EQUIPE_ALUNO")
        strSQL.Append(" where EE05_ID_EQUIPE_ALUNO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE05_EQUIPE_ALUNO")
        strSQL.Append(" where EE03_ID_ALUNO = " & CodigoAluno)
        strSQL.Append(" and EE06_ID_EQUIPE_ESCOLA = " & CodigoEquipeEscola)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE03_ID_ALUNO") = ProBanco(EE03_ID_ALUNO, eTipoValor.CHAVE)
        dr("EE06_ID_EQUIPE_ESCOLA") = ProBanco(EE06_ID_EQUIPE_ESCOLA, eTipoValor.CHAVE)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub
End Class
