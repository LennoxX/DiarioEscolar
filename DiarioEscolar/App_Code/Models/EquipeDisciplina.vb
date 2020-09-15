Imports System.Data

Public Class EquipeDisciplina
    Private EE13_ID_EQUIPE_DISCIPLINA As Integer
    Private EE11_ID_DISCIPLINA As Integer
    Private EE04_ID_EQUIPE_PROFESSOR As Integer

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
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

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE13_EQUIPE_DISCIPLINA")
        strSQL.Append(" where EE13_ID_EQUIPE_DISCIPLINA = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE13_ID_EQUIPE_DISCIPLINA = DoBanco(dr("EE13_ID_EQUIPE_DISCIPLINA"), eTipoValor.CHAVE)
            EE11_ID_DISCIPLINA = DoBanco(dr("EE11_ID_DISCIPLINA"), eTipoValor.CHAVE)
            EE04_ID_EQUIPE_PROFESSOR = DoBanco(dr("EE04_ID_EQUIPE_PROFESSOR"), eTipoValor.CHAVE)
        End If

    End Sub

    Public Function Pesquisar(CodigoTurma As Integer,
                             Optional ByVal Sort As String = "",
                             Optional ByVal NomeProfessor As String = "",
                             Optional ByVal Disciplina As String = ""
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder


        strSQL.Append(" Select EE13_EQUIPE_DISCIPLINA.EE13_ID_EQUIPE_DISCIPLINA, EE11_DISCIPLINA.EE11_DS_DISCIPLINA, EE02_PROFESSOR.EE02_NM_NOME")
        strSQL.Append(" From EE13_EQUIPE_DISCIPLINA")
        strSQL.Append(" Join EE04_EQUIPE_PROFESSOR on EE13_EQUIPE_DISCIPLINA.EE04_ID_EQUIPE_PROFESSOR = EE04_EQUIPE_PROFESSOR.EE04_ID_EQUIPE_PROFESSOR")
        strSQL.Append(" Join EE11_DISCIPLINA on EE11_DISCIPLINA.EE11_ID_DISCIPLINA = EE13_EQUIPE_DISCIPLINA.EE11_ID_DISCIPLINA")
        strSQL.Append(" Join EE06_EQUIPE_ESCOLA on EE04_EQUIPE_PROFESSOR.EE06_ID_EQUIPE_ESCOLA = EE06_EQUIPE_ESCOLA.EE06_ID_EQUIPE_ESCOLA")
        strSQL.Append(" Join EE02_PROFESSOR on EE04_EQUIPE_PROFESSOR.EE02_ID_PROFESSOR = EE02_PROFESSOR.EE02_ID_PROFESSOR")
        strSQL.Append(" Where EE06_EQUIPE_ESCOLA.EE06_ID_EQUIPE_ESCOLA =" & CodigoTurma)



        If NomeProfessor <> "" Then
            strSQL.Append(" and upper(EE02_NM_NOME) like '%" & NomeProfessor.ToUpper & "%'")
        End If

        If Disciplina <> "" Then
            strSQL.Append(" and upper(EE11_DS_DISCIPLINA) like '%" & Disciplina.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE02_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Friend Function Excluir(Codigo As Object) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE13_EQUIPE_DISCIPLINA")
        strSQL.Append(" where EE13_ID_EQUIPE_DISCIPLINA = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE13_EQUIPE_DISCIPLINA")
        strSQL.Append(" where EE11_ID_DISCIPLINA = " & CodigoDisciplina)
        strSQL.Append(" and EE04_ID_EQUIPE_PROFESSOR = " & CodigoEquipeProfessor)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
            dr("EE11_ID_DISCIPLINA") = ProBanco(EE11_ID_DISCIPLINA, eTipoValor.CHAVE)
            dr("EE04_ID_EQUIPE_PROFESSOR") = ProBanco(EE04_ID_EQUIPE_PROFESSOR, eTipoValor.CHAVE)
            cnn.SalvarDataTable(dr)

        End If

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function ObterPorTurma(CodigoTurma As Integer) As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select *")
        strSQL.Append(" from EE13_EQUIPE_DISCIPLINA")
        strSQL.Append(" Join EE04_EQUIPE_PROFESSOR on EE13_EQUIPE_DISCIPLINA.EE04_ID_EQUIPE_PROFESSOR = EE04_EQUIPE_PROFESSOR.EE04_ID_EQUIPE_PROFESSOR")
        strSQL.Append("  Join EE06_EQUIPE_ESCOLA on EE04_EQUIPE_PROFESSOR.EE06_ID_EQUIPE_ESCOLA = EE06_EQUIPE_ESCOLA.EE06_ID_EQUIPE_ESCOLA")
        strSQL.Append(" where EE06_EQUIPE_ESCOLA.EE06_ID_EQUIPE_ESCOLA =" & CodigoTurma)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        Return dt
    End Function
End Class
