Imports System.Data

Public Class Disciplina
    Private EE11_ID_DISCIPLINA As Integer
    Private EE11_DS_DISCIPLINA As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE11_ID_DISCIPLINA
        End Get
        Set(value As Integer)
            EE11_ID_DISCIPLINA = value
        End Set
    End Property

    Public Property Disciplina() As String
        Get
            Return EE11_DS_DISCIPLINA
        End Get
        Set(value As String)
            EE11_DS_DISCIPLINA = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE11_DISCIPLINA")
        strSQL.Append(" where EE11_ID_DISCIPLINA = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE11_ID_DISCIPLINA = DoBanco(dr("EE11_ID_DISCIPLINA"), eTipoValor.CHAVE)
            EE11_DS_DISCIPLINA = DoBanco(dr("EE11_DS_DISCIPLINA"), eTipoValor.TEXTO_LIVRE)
        End If

    End Sub
    Friend Function Excluir(Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE11_DISCIPLINA")
        strSQL.Append(" where EE11_ID_DISCIPLINA = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE11_DISCIPLINA")
        strSQL.Append(" where EE11_ID_DISCIPLINA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE11_ID_DISCIPLINA") = ProBanco(EE11_ID_DISCIPLINA, eTipoValor.CHAVE)
        dr("EE11_DS_DISCIPLINA") = ProBanco(EE11_DS_DISCIPLINA, eTipoValor.TEXTO_LIVRE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE11_ID_DISCIPLINA as CODIGO, EE11_DS_DISCIPLINA as DESCRICAO")
        strSQL.Append(" from EE11_DISCIPLINA")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        Return dt
    End Function

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                            Optional ByVal Codigo As Integer = 0,
                            Optional ByVal Descricao As String = ""
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE11_DISCIPLINA")
        strSQL.Append(" where EE11_ID_DISCIPLINA is not null")

        If Codigo > 0 Then
            strSQL.Append(" and EE11_ID_DISCIPLINA = " & Codigo)
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(EE11_DS_DISCIPLINA) like '%" & Descricao.ToUpper & "%'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "EE11_DS_DISCIPLINA", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function
End Class
