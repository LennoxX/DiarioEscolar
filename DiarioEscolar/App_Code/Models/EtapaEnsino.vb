Imports System.Data

Public Class EtapaEnsino
    Private EE16_ID_ETAPA_ENSINO As Integer
    Private EE15_ID_TIPO_ENSINO As Integer
    Private EE16_DS_ETAPA_ENSINO As String

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE16_ID_ETAPA_ENSINO
        End Get
        Set(value As Integer)
            EE16_ID_ETAPA_ENSINO = value
        End Set
    End Property

    Public Property CodigoTipoEnsino() As Integer
        Get
            Return EE15_ID_TIPO_ENSINO
        End Get
        Set(value As Integer)
            EE15_ID_TIPO_ENSINO = value
        End Set
    End Property

    Public Property DsEtapaEnsino() As String
        Get
            Return EE16_DS_ETAPA_ENSINO
        End Get
        Set(value As String)
            EE16_DS_ETAPA_ENSINO = value
        End Set
    End Property

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select EE16_ID_ETAPA_ENSINO as CODIGO, EE16_DS_ETAPA_ENSINO as DESCRICAO")
        strSQL.Append(" from EE16_ETAPA_ENSINO")
        strSQL.Append(" Order by DESCRICAO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

        Return dt
    End Function
End Class
