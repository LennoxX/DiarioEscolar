Imports System.Data

Public Class TipoAtividade
    Private EE10_ID_TIPO_ATIVIDADE As Integer
    Private EE10_DS_TIPO_ATIVIDADE As String

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE10_ID_TIPO_ATIVIDADE
        End Get
        Set(value As Integer)
            EE10_ID_TIPO_ATIVIDADE = value
        End Set
    End Property

    Public Property TipoAtividade() As String
        Get
            Return EE10_DS_TIPO_ATIVIDADE
        End Get
        Set(value As String)
            EE10_DS_TIPO_ATIVIDADE = value
        End Set
    End Property

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE10_ID_TIPO_ATIVIDADE as CODIGO, EE10_DS_TIPO_ATIVIDADE as DESCRICAO")
        strSQL.Append(" from EE10_TIPO_ATIVIDADE")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        Return dt
    End Function
    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE10_TIPO_ATIVIDADE")
        strSQL.Append(" where EE10_ID_TIPO_ATIVIDADE = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE10_ID_TIPO_ATIVIDADE = DoBanco(dr("EE10_ID_TIPO_ATIVIDADE"), eTipoValor.CHAVE)
            EE10_DS_TIPO_ATIVIDADE = DoBanco(dr("EE10_DS_TIPO_ATIVIDADE"), eTipoValor.TEXTO)

        End If

    End Sub
End Class
