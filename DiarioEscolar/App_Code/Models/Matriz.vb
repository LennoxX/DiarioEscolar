Imports System.Data

Public Class Matriz
    Private EE14_ID_MATRIZ As Integer
    Private EE16_ID_ETAPA_ENSINO As Integer
    Private EE00_ID_PERIODO_LETIVO As Integer

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub



    Public Property Codigo() As Integer
        Get
            Return EE14_ID_MATRIZ
        End Get
        Set(value As Integer)
            EE14_ID_MATRIZ = value
        End Set
    End Property

    Public Property IdEtapaEnsino() As Integer
        Get
            Return EE16_ID_ETAPA_ENSINO
        End Get
        Set(value As Integer)
            EE16_ID_ETAPA_ENSINO = value
        End Set
    End Property

    Public Property IdPeriodoLetivo() As Integer
        Get
            Return EE00_ID_PERIODO_LETIVO
        End Get
        Set(value As Integer)
            EE00_ID_PERIODO_LETIVO = value
        End Set
    End Property
    Private Sub Obter(codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE14_MATRIZ")
        strSQL.Append(" where EE14_ID_MATRIZ = " & codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            EE14_ID_MATRIZ = DoBanco(dr("EE14_ID_MATRIZ"), eTipoValor.CHAVE)
            EE16_ID_ETAPA_ENSINO = DoBanco(dr("EE16_ID_ETAPA_ENSINO"), eTipoValor.CHAVE)
            EE00_ID_PERIODO_LETIVO = DoBanco(dr("EE00_ID_PERIODO_LETIVO"), eTipoValor.CHAVE)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(CodigoEscola As Integer,
                             Optional ByVal Sort As String = "",
                             Optional ByVal Codigo As Integer = 0,
                             Optional ByVal EtapaEnsino As String = "",
                             Optional ByVal PeriodoLetivo As String = ""
                            ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select EE14_MATRIZ.EE14_ID_MATRIZ, EE00_PERIODO_LETIVO.EE00_NM_PERIODO_LETIVO + ' - ' +  EE16_ETAPA_ENSINO.EE16_DS_ETAPA_ENSINO as DESCRICAO, ")
        strSQL.Append("EE00_PERIODO_LETIVO.EE00_NM_PERIODO_LETIVO, EE16_ETAPA_ENSINO.EE16_DS_ETAPA_ENSINO ")
        strSQL.Append(" from EE14_MATRIZ")
        strSQL.Append(" join EE00_PERIODO_LETIVO on EE14_MATRIZ.EE00_ID_PERIODO_LETIVO = EE00_PERIODO_LETIVO.EE00_ID_PERIODO_LETIVO")
        strSQL.Append(" join EE16_ETAPA_ENSINO on EE14_MATRIZ.EE16_ID_ETAPA_ENSINO = EE16_ETAPA_ENSINO.EE16_ID_ETAPA_ENSINO")
        strSQL.Append(" where EE14_MATRIZ.EE14_ID_MATRIZ is not null")
        strSQL.Append(" and EE00_PERIODO_LETIVO.EE01_ID_ESCOLA = " & CodigoEscola)

        If Codigo > 0 Then
            strSQL.Append(" and EE14_MATRIZ.EE14_ID_MATRIZ = " & Codigo)
        End If

        If EtapaEnsino <> "" Then
            strSQL.Append(" and upper(EE00_PERIODO_LETIVO.EE00_NM_PERIODO_LETIVO) like '%" & EtapaEnsino.ToUpper & "%'")
        End If

        If PeriodoLetivo <> "" Then
            strSQL.Append(" and upper(EE16_ETAPA_ENSINO.EE16_DS_ETAPA_ENSINO) like '%" & PeriodoLetivo.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "EE14_ID_MATRIZ", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE14_MATRIZ")
        strSQL.Append(" where EE14_ID_MATRIZ = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE14_ID_MATRIZ") = ProBanco(EE14_ID_MATRIZ, eTipoValor.CHAVE)
        dr("EE16_ID_ETAPA_ENSINO") = ProBanco(EE16_ID_ETAPA_ENSINO, eTipoValor.CHAVE)
        dr("EE00_ID_PERIODO_LETIVO") = ProBanco(EE00_ID_PERIODO_LETIVO, eTipoValor.CHAVE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Friend Function Excluir(Codigo As Object) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from EE14_MATRIZ")
        strSQL.Append(" where EE14_ID_MATRIZ = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        Return LinhasAfetadas
    End Function
End Class
