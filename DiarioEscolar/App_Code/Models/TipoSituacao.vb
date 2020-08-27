Imports System.Data

Public Class TipoSituacao
    Private EE07_ID_SITUACAO As Integer
    Private EE07_DS_DESCRICAO As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE07_ID_SITUACAO
        End Get
        Set(value As Integer)
            EE07_ID_SITUACAO = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return EE07_DS_DESCRICAO
        End Get
        Set(value As String)
            EE07_DS_DESCRICAO = value
        End Set
    End Property

    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE07_TIPO_SITUACAO")
        strSQL.Append(" where EE07_ID_SITUACAO = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE07_ID_SITUACAO = DoBanco(dr("EE07_ID_SITUACAO"), eTipoValor.CHAVE)
            EE07_DS_DESCRICAO = DoBanco(dr("EE07_DS_DESCRICAO"), eTipoValor.TEXTO)

        End If

    End Sub

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE07_ID_SITUACAO as CODIGO, EE07_DS_DESCRICAO as DESCRICAO")
        strSQL.Append(" from EE07_TIPO_SITUACAO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

        Return dt
    End Function
End Class
