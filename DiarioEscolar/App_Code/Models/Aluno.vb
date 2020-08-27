Imports System.Data

Public Class Aluno
    Private EE03_ID_ALUNO As Integer
    Private EE03_NM_NOME As String
    Private EE03_NM_NOME_EXIBICAO As String
    Private EE03_DS_MATRICULA As String
    Private EE03_DS_EMAIL As String
    Private EE03_DT_NASCIMENTO As Date
    Private EE03_DS_SITUACAO As String
    Private EE03_DS_SENHA_PROVISORIA As String
    Private EE03_DS_SENHA As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub



    Public Property Codigo() As Integer
        Get
            Return EE03_ID_ALUNO
        End Get
        Set(value As Integer)
            EE03_ID_ALUNO = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return EE03_NM_NOME
        End Get
        Set(value As String)
            EE03_NM_NOME = value
        End Set
    End Property

    Public Property NomeExibicao() As String
        Get
            Return EE03_NM_NOME_EXIBICAO
        End Get
        Set(value As String)
            EE03_NM_NOME_EXIBICAO = value
        End Set
    End Property

    Public Property Matricula() As String
        Get
            Return EE03_DS_MATRICULA
        End Get
        Set(value As String)
            EE03_DS_MATRICULA = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return EE03_DS_EMAIL
        End Get
        Set(value As String)
            EE03_DS_EMAIL = value
        End Set
    End Property

    Public Property Nascimento() As Date
        Get
            Return EE03_DT_NASCIMENTO
        End Get
        Set(value As Date)
            EE03_DT_NASCIMENTO = value
        End Set
    End Property

    Public Property Situacao() As String
        Get
            Return EE03_DS_SITUACAO
        End Get
        Set(value As String)
            EE03_DS_SITUACAO = value
        End Set
    End Property

    Public Property SenhaProvisoria() As String
        Get
            Return EE03_DS_SENHA_PROVISORIA
        End Get
        Set(value As String)
            EE03_DS_SENHA_PROVISORIA = value
        End Set
    End Property

    Public Property Senha() As String
        Get
            Return EE03_DS_SENHA
        End Get
        Set(value As String)
            EE03_DS_SENHA = value
        End Set
    End Property
    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE03_ALUNO")
        strSQL.Append(" where EE03_ID_ALUNO = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE03_ID_ALUNO = DoBanco(dr("EE03_ID_ALUNO"), eTipoValor.CHAVE)
            EE03_NM_NOME = DoBanco(dr("EE03_NM_NOME"), eTipoValor.TEXTO)
            EE03_NM_NOME_EXIBICAO = DoBanco(dr("EE03_NM_NOME_EXIBICAO"), eTipoValor.TEXTO)
            EE03_DS_MATRICULA = DoBanco(dr("EE03_DS_MATRICULA"), eTipoValor.TEXTO)
            EE03_DS_EMAIL = DoBanco(dr("EE03_DS_EMAIL"), eTipoValor.TEXTO)
            EE03_DT_NASCIMENTO = DoBanco(dr("EE03_DT_NASCIMENTO"), eTipoValor.DATA)
            EE03_DS_SITUACAO = DoBanco(dr("EE03_DS_SITUACAO"), eTipoValor.TEXTO_LIVRE)
        End If

    End Sub
    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE03_ALUNO")
        strSQL.Append(" where EE03_ID_ALUNO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE03_ALUNO")
        strSQL.Append(" where EE03_ID_ALUNO = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE03_ID_ALUNO") = ProBanco(EE03_ID_ALUNO, eTipoValor.CHAVE)
        dr("EE03_NM_NOME") = ProBanco(EE03_NM_NOME, eTipoValor.TEXTO)
        dr("EE03_NM_NOME_EXIBICAO") = ProBanco(EE03_NM_NOME_EXIBICAO, eTipoValor.TEXTO)
        dr("EE03_DS_MATRICULA") = ProBanco(EE03_DS_MATRICULA, eTipoValor.TEXTO)
        dr("EE03_DS_EMAIL") = ProBanco(EE03_DS_EMAIL, eTipoValor.TEXTO)
        dr("EE03_DT_NASCIMENTO") = ProBanco(EE03_DT_NASCIMENTO, eTipoValor.DATA)
        dr("EE03_DS_SITUACAO") = ProBanco(EE03_DS_SITUACAO, eTipoValor.TEXTO)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE03_ID_ALUNO as CODIGO, EE03_NM_NOME as DESCRICAO")
        strSQL.Append(" from EE03_ALUNO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        Return dt
    End Function


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

        strSQL.Append(" Select * ")
        strSQL.Append(" from EE03_ALUNO")
        strSQL.Append(" where EE03_ID_ALUNO Is Not null")

        If Codigo > 0 Then
            strSQL.Append(" And EE03_ID_ALUNO = " & Codigo)
        End If

        If Nome <> "" Then
            strSQL.Append(" And upper(EE03_NM_NOME) Like '%" & Nome.ToUpper & "%'")
        End If

        If NomeExibicao <> "" Then
            strSQL.Append(" and upper(EE03_NM_NOME_EXIBICAO) like '%" & NomeExibicao.ToUpper & "%'")
        End If

        If Matricula <> "" Then
            strSQL.Append(" and upper(EE03_DS_MATRICULA) like '%" & Matricula.ToUpper & "%'")
        End If

        If Email <> "" Then
            strSQL.Append(" and upper(EE03_DS_EMAIL) like '%" & Matricula.ToUpper & "%'")
        End If

        If Nascimento <> Nothing Then
            strSQL.Append(" and EE03_DT_NASCIMENTO =" & Nascimento)
        End If

        If Situacao <> "" Then
            strSQL.Append(" and upper(EE03_DS_SITUACAO) like '%" & Situacao.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE03_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function
End Class
