Imports System.Data

Public Class Professor
    Private EE02_ID_PROFESSOR As Integer
    Private EE02_NM_NOME As String
    Private EE02_NM_NOME_EXIBICAO As String
    Private EE02_NR_MATRICULA As String
    Private EE02_DS_EMAIL As String
    Private EE02_DT_NASCIMENTO As Date
    Private EE02_DS_SITUACAO As String
    Private EE02_DS_SENHA_PROVISORIA As String
    Private EE02_DS_SENHA As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE02_ID_PROFESSOR
        End Get
        Set(value As Integer)
            EE02_ID_PROFESSOR = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return EE02_NM_NOME
        End Get
        Set(value As String)
            EE02_NM_NOME = value
        End Set
    End Property

    Public Property NomeExibicao() As String
        Get
            Return EE02_NM_NOME_EXIBICAO
        End Get
        Set(value As String)
            EE02_NM_NOME_EXIBICAO = value
        End Set
    End Property

    Public Property Matricula() As String
        Get
            Return EE02_NR_MATRICULA
        End Get
        Set(value As String)
            EE02_NR_MATRICULA = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return EE02_DS_EMAIL
        End Get
        Set(value As String)
            EE02_DS_EMAIL = value
        End Set
    End Property

    Public Property Nascimento() As Date
        Get
            Return EE02_DT_NASCIMENTO
        End Get
        Set(value As Date)
            EE02_DT_NASCIMENTO = value
        End Set
    End Property

    Public Property Situacao() As String
        Get
            Return EE02_DS_SITUACAO
        End Get
        Set(value As String)
            EE02_DS_SITUACAO = value
        End Set
    End Property

    Public Property SenhaProvisoria() As String
        Get
            Return EE02_DS_SENHA_PROVISORIA
        End Get
        Set(value As String)
            EE02_DS_SENHA_PROVISORIA = value
        End Set
    End Property

    Public Property Senha() As String
        Get
            Return EE02_DS_SENHA
        End Get
        Set(value As String)
            EE02_DS_SENHA = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE02_PROFESSOR")
        strSQL.Append(" where EE02_ID_PROFESSOR = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE02_ID_PROFESSOR = DoBanco(dr("EE02_ID_PROFESSOR"), eTipoValor.CHAVE)
            EE02_NM_NOME = DoBanco(dr("EE02_NM_NOME"), eTipoValor.TEXTO_LIVRE)
            EE02_NM_NOME_EXIBICAO = DoBanco(dr("EE02_NM_NOME_EXIBICAO"), eTipoValor.TEXTO_LIVRE)
            EE02_NR_MATRICULA = DoBanco(dr("EE02_NR_MATRICULA"), eTipoValor.TEXTO)
            EE02_DS_EMAIL = DoBanco(dr("EE02_DS_EMAIL"), eTipoValor.TEXTO)
            EE02_DT_NASCIMENTO = DoBanco(dr("EE02_DT_NASCIMENTO"), eTipoValor.DATA)
            EE02_DS_SITUACAO = DoBanco(dr("EE02_DS_SITUACAO"), eTipoValor.TEXTO_LIVRE)
        End If

    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE02_PROFESSOR")
        strSQL.Append(" where EE02_ID_PROFESSOR = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE02_ID_PROFESSOR") = ProBanco(EE02_ID_PROFESSOR, eTipoValor.CHAVE)
        dr("EE02_NM_NOME") = ProBanco(EE02_NM_NOME, eTipoValor.TEXTO_LIVRE)
        dr("EE02_NM_NOME_EXIBICAO") = ProBanco(EE02_NM_NOME_EXIBICAO, eTipoValor.TEXTO_LIVRE)
        dr("EE02_NR_MATRICULA") = ProBanco(EE02_NR_MATRICULA, eTipoValor.TEXTO)
        dr("EE02_DS_EMAIL") = ProBanco(EE02_DS_EMAIL, eTipoValor.TEXTO)
        dr("EE02_DT_NASCIMENTO") = ProBanco(EE02_DT_NASCIMENTO, eTipoValor.DATA)
        dr("EE02_DS_SITUACAO") = ProBanco(EE02_DS_SITUACAO, eTipoValor.TEXTO)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                           Optional ByVal Codigo As Integer = 0,
                           Optional ByVal Nome As String = "",
                           Optional ByVal NomeExibicao As String = "",
                           Optional ByVal Matricula As String = "",
                           Optional ByVal Email As String = "",
                           Optional ByVal Nascimento As Date = Nothing,
                           Optional ByVal Situacao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE02_PROFESSOR")
        strSQL.Append(" where EE02_ID_PROFESSOR is not null")

        If Codigo > 0 Then
            strSQL.Append(" and EE02_ID_PROFESSOR = " & Codigo)
        End If

        If Nome <> "" Then
            strSQL.Append(" and upper(EE02_NM_NOME) like '%" & Nome.ToUpper & "%'")
        End If

        If NomeExibicao <> "" Then
            strSQL.Append(" and upper(EE02_NM_NOME_EXIBICAO) like '%" & NomeExibicao.ToUpper & "%'")
        End If

        If Matricula <> "" Then
            strSQL.Append(" and upper(EE02_NR_MATRICULA) like '%" & Matricula.ToUpper & "%'")
        End If

        If Email <> "" Then
            strSQL.Append(" and upper(EE02_DS_EMAIL) like '%" & Matricula.ToUpper & "%'")
        End If

        If Nascimento <> Nothing Then
            strSQL.Append(" and EE02_DT_NASCIMENTO =" & Nascimento)
        End If

        If Situacao <> "" Then
            strSQL.Append(" and upper(EE02_DS_SITUACAO) like '%" & Situacao.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE02_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE02_ID_PROFESSOR as CODIGO, EE02_NM_NOME as DESCRICAO")
        strSQL.Append(" from EE02_PROFESSOR")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        Return dt
    End Function


    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE02_PROFESSOR")
        strSQL.Append(" where EE02_ID_PROFESSOR = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function
End Class
