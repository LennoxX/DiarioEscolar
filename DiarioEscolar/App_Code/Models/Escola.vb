Imports System.Data

Public Class Escola
    Private EE01_ID_ESCOLA As Integer
    Private EE07_ID_SITUACAO As Integer
    Private TG01_ID_CIDADE As Integer
    Private EE01_NM_NOME As String
    Private EE01_NR_MEC As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE01_ID_ESCOLA
        End Get
        Set(value As Integer)
            EE01_ID_ESCOLA = value
        End Set
    End Property

    Public Property CodigoSituacao() As Integer
        Get
            Return EE07_ID_SITUACAO
        End Get
        Set(value As Integer)
            EE07_ID_SITUACAO = value
        End Set
    End Property

    Public Property CodigoCidade() As Integer
        Get
            Return TG01_ID_CIDADE
        End Get
        Set(value As Integer)
            TG01_ID_CIDADE = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return EE01_NM_NOME
        End Get
        Set(value As String)
            EE01_NM_NOME = value
        End Set
    End Property

    Public Property NrMec() As String
        Get
            Return EE01_NR_MEC
        End Get
        Set(value As String)
            EE01_NR_MEC = value
        End Set
    End Property

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE01_ESCOLA")
        strSQL.Append(" where EE01_ID_ESCOLA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE01_ID_ESCOLA") = ProBanco(EE01_ID_ESCOLA, eTipoValor.CHAVE)
        dr("EE07_ID_SITUACAO") = ProBanco(EE07_ID_SITUACAO, eTipoValor.CHAVE)
        dr("TG01_ID_CIDADE") = ProBanco(TG01_ID_CIDADE, eTipoValor.CHAVE)
        dr("EE01_NM_NOME") = ProBanco(EE01_NM_NOME, eTipoValor.TEXTO)
        dr("EE01_NR_MEC") = ProBanco(EE01_NR_MEC, eTipoValor.TEXTO)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE01_ESCOLA")
        strSQL.Append(" where EE01_ID_ESCOLA = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE01_ID_ESCOLA = DoBanco(dr("EE01_ID_ESCOLA"), eTipoValor.CHAVE)
            EE07_ID_SITUACAO = DoBanco(dr("EE07_ID_SITUACAO"), eTipoValor.CHAVE)
            TG01_ID_CIDADE = DoBanco(dr("TG01_ID_CIDADE"), eTipoValor.CHAVE)
            EE01_NM_NOME = DoBanco(dr("EE01_NM_NOME"), eTipoValor.TEXTO)
            EE01_NR_MEC = DoBanco(dr("EE01_NR_MEC"), eTipoValor.TEXTO_LIVRE)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                             Optional ByVal Codigo As Integer = 0,
                             Optional ByVal NomeEscola As String = "",
                             Optional ByVal NrMec As String = "",
                             Optional ByVal Cidade As Integer = 0,
                             Optional ByVal Situacao As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE01_ESCOLA")
        strSQL.Append(" where EE01_ID_ESCOLA is not null")

        If Codigo > 0 Then
            strSQL.Append(" and EE01_ID_ESCOLA = " & Codigo)
        End If

        If NomeEscola <> "" Then
            strSQL.Append(" and upper(EE01_NM_NOME) like '%" & NomeEscola.ToUpper & "%'")
        End If

        If NrMec <> "" Then
            strSQL.Append(" and upper(EE01_NR_MEC) like '%" & NrMec.ToUpper & "%'")
        End If

        If Cidade > 0 Then
            strSQL.Append(" and TG01_ID_CIDADE = " & Cidade)
        End If

        If Situacao > 0 Then
            strSQL.Append(" and EE07_ID_SITUACAO = " & Situacao)
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "EE01_NM_NOME", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE01_ESCOLA")
        strSQL.Append(" where EE01_ID_ESCOLA = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function
End Class
