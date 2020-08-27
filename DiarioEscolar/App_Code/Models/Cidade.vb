Imports System.Data

Public Class Cidade
    Private TG01_ID_CIDADE As Integer
    Private TG02_ID_REGIONAL As Integer
    Private TG01_DS_CIDADE As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return TG01_ID_CIDADE
        End Get
        Set(value As Integer)
            TG01_ID_CIDADE = value
        End Set
    End Property

    Public Property CodigoRegional() As Integer
        Get
            Return TG02_ID_REGIONAL
        End Get
        Set(value As Integer)
            TG02_ID_REGIONAL = value
        End Set
    End Property

    Public Property Cidade() As String
        Get
            Return TG01_DS_CIDADE
        End Get
        Set(value As String)
            TG01_DS_CIDADE = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from TG01_CIDADE")
        strSQL.Append(" where TG01_ID_CIDADE = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            TG01_ID_CIDADE = DoBanco(dr("TG01_ID_CIDADE"), eTipoValor.CHAVE)
            TG01_DS_CIDADE = DoBanco(dr("TG01_DS_CIDADE"), eTipoValor.TEXTO)

        End If

    End Sub

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select TG01_ID_CIDADE as CODIGO, TG01_DS_CIDADE as DESCRICAO")
        strSQL.Append(" from TG01_CIDADE")
        strSQL.Append(" Order by DESCRICAO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

        Return dt
    End Function
End Class
