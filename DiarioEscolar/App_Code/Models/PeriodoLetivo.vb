Imports System.Data

Public Class PeriodoLetivo

    Private EE00_ID_PERIODO_LETIVO As Integer
    Private EE01_ID_ESCOLA As Integer
    Private EE00_DS_PERIODO_LETIVO As String
    Private EE00_NM_PERIODO_LETIVO As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE00_ID_PERIODO_LETIVO
        End Get
        Set(value As Integer)
            EE00_ID_PERIODO_LETIVO = value
        End Set
    End Property

    Public Property CodigoEscola() As Integer
        Get
            Return EE01_ID_ESCOLA
        End Get
        Set(value As Integer)
            EE01_ID_ESCOLA = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return EE00_DS_PERIODO_LETIVO
        End Get
        Set(value As String)
            EE00_DS_PERIODO_LETIVO = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return EE00_NM_PERIODO_LETIVO
        End Get
        Set(value As String)
            EE00_NM_PERIODO_LETIVO = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE00_PERIODO_LETIVO")
        strSQL.Append(" where EE00_ID_PERIODO_LETIVO = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            EE00_ID_PERIODO_LETIVO = DoBanco(dr("EE00_ID_PERIODO_LETIVO"), eTipoValor.CHAVE)
            EE01_ID_ESCOLA = DoBanco(dr("EE01_ID_ESCOLA"), eTipoValor.CHAVE)
            EE00_DS_PERIODO_LETIVO = DoBanco(dr("EE00_DS_PERIODO_LETIVO"), eTipoValor.TEXTO_LIVRE)
            EE00_NM_PERIODO_LETIVO = DoBanco(dr("EE00_NM_PERIODO_LETIVO"), eTipoValor.TEXTO_LIVRE)
        End If

    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE00_PERIODO_LETIVO")
        strSQL.Append(" where EE00_ID_PERIODO_LETIVO = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE00_ID_PERIODO_LETIVO") = ProBanco(EE00_ID_PERIODO_LETIVO, eTipoValor.CHAVE)
        dr("EE01_ID_ESCOLA") = ProBanco(EE01_ID_ESCOLA, eTipoValor.CHAVE)
        dr("EE00_DS_PERIODO_LETIVO") = ProBanco(EE00_DS_PERIODO_LETIVO, eTipoValor.TEXTO_LIVRE)
        dr("EE00_NM_PERIODO_LETIVO") = ProBanco(EE00_NM_PERIODO_LETIVO, eTipoValor.TEXTO_LIVRE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE00_PERIODO_LETIVO")
        strSQL.Append(" where EE00_ID_PERIODO_LETIVO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                           Optional ByVal Codigo As Integer = 0,
                           Optional ByVal Escola As Integer = 0,
                           Optional ByVal Nome As String = "",
                           Optional ByVal Descricao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE00_PERIODO_LETIVO")
        strSQL.Append(" where EE00_ID_PERIODO_LETIVO is not null")

        If Codigo > 0 Then
            strSQL.Append(" and EE00_ID_PERIODO_LETIVO = " & Codigo)
        End If

        If Escola > 0 Then
            strSQL.Append(" and EE01_ID_ESCOLA = " & Escola)
        End If

        If Nome <> "" Then
            strSQL.Append(" and upper(EE00_NM_PERIODO_LETIVO) like '%" & Nome.ToUpper & "%'")
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(EE00_DS_PERIODO_LETIVO) like '%" & Descricao.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "EE00_NM_PERIODO_LETIVO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select EE00_ID_PERIODO_LETIVO as CODIGO, EE00_DS_PERIODO_LETIVO as DESCRICAO")
        strSQL.Append(" from EE00_PERIODO_LETIVO")
        strSQL.Append(" Order by DESCRICAO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

        Return dt
    End Function
End Class
